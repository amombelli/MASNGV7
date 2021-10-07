using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmRegistroInspeccionH1H2
    {
        public List<T0805_QMIRecordH1> GetListadoH1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0805_QMIRecordH1.OrderByDescending(c => c.IdIRec).ToList();
            }
        }
        public List<T0806_QMIRecordH2> GetListadoH2(int iR)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0806_QMIRecordH2.Where(c => c.IdRec == iR).OrderByDescending(c => c.IdCounter).ToList();
            }
        }
        public T0805_QMIRecordH1 GetRegistroH1(int iR)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0805_QMIRecordH1.SingleOrDefault(c => c.IdIRec == iR);
            }
        }
        public T0806_QMIRecordH2 GetRegistroH2(int iR, int counter)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == iR && c.IdCounter == counter);
            }
        }

        public void UpdateDescripcionH2(int iR, int counter, string observacionH2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == iR && c.IdCounter == counter);
                data.ComentarioH2 = observacionH2;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Funcion para Volver un Lote a Estado Restringido
        /// </summary>
        public int PasaStockAModoRestringido(int idstockOriginal, string material, string lote, decimal cantidadKg, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string loteA;
                if (lote.Contains("/") == false)
                {
                    //si el Lote no tiene / es en T0805 /1
                    loteA = lote + ("/1");
                }
                else
                {
                    loteA = lote;
                }
                var registroH2 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.Material == material && c.Lote == loteA);
                if (registroH2 == null)
                {
                    //Atencion no se encontro el registro en QM (seguramente por datos viejos) crea registro automatico tipo 'F' Fix

                    MessageBox.Show(
                        @"Atencion no se encontro el registro de datos en el modulo de QM - Para compatibilidda se ha creado un registro en forma Automatica Modo Fix",
                        @"Compatibilidad de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new QmRegistroInspeccion().CreaRegistroInspeccionH(QmRegistroInspeccion.TipoRecord.F, material,
                        new QmMasterIplan().GetPlanFromMaterial(material), lote, DateTime.Today, cantidadKg,
                        MaterialOrigenDataType.OrigenDt.Fabricado, 0, comentarioH1: "Registro Automatico-Fix Data");
                    registroH2 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.Material == material && c.Lote == loteA);
                }

                if (registroH2.KGInspeccion != cantidadKg)
                {
                    //Los Kg del registro de inspeccion son distintos a los KG a Restringir 
                    //Por lo tanto algunos KG ya se han utilizado - Se genera un split con un nuevo Lote
                    //Se loguea primero el cambio de LOTE para la cantidad a Restringir y luego el Cambio de Estado
                    int CounterNewRecord = new QmRegistroInspeccion().SplitRegistroH2(registroH2.IdRec,
                        registroH2.IdCounter, cantidadKg, motivo);
                    var LoteNuevo = new QmRegistroInspeccionH1H2().GetRegistroH2(registroH2.IdRec, CounterNewRecord).Lote;
                    var stk1 = new StockMovements();
                    var log40m1 = stk1.ChangeLote(idstockOriginal, cantidadKg, LoteNuevo, "QM09", true);
                    var log40m2 = stk1.MoveEstado(idstockOriginal, cantidadKg, StockStatusManager.EstadoLote.Restringido, "QM09", comentario: motivo);
                    if (log40m2 > 0)
                        return 1;

                }
                else
                {
                    //Existe un Registro de Inspeccion 'Material-Lote' con la misma cantidad por lo que actualizo el estado 
                    //sin modificar el Lote.
                    int CounterNewRecord = new QmRegistroInspeccion().SplitRegistroH2(registroH2.IdRec,
                        registroH2.IdCounter, cantidadKg, motivo);
                    var LoteNuevo = new QmRegistroInspeccionH1H2().GetRegistroH2(registroH2.IdRec, CounterNewRecord).Lote;
                    var stk1 = new StockMovements();
                    var log40m1 = stk1.ChangeLote(idstockOriginal, cantidadKg, LoteNuevo, "QM09", true);
                    var log40m2 = stk1.MoveEstado(idstockOriginal, cantidadKg, StockStatusManager.EstadoLote.Restringido, "QM09", comentario: motivo);
                    if (log40m2 > 0)
                        return 1;
#pragma warning disable CS0219 // La variable 'a' está asignada pero su valor nunca se usa
                    var a = 1;
#pragma warning restore CS0219 // La variable 'a' está asignada pero su valor nunca se usa
                }

                var kgRegistroNuevo = registroH2.KGInspeccion - cantidadKg;
                int newCounter = new QmRegistroInspeccion().SplitRegistroH2(registroH2.IdRec, registroH2.IdCounter, kgRegistroNuevo,
                    motivo);

                var newLote = new QmRegistroInspeccionH1H2().GetRegistroH2(registroH2.IdRec, newCounter).Lote;
                var x = new StockMovements();
                var log40a = x.ChangeLote(idstockOriginal, cantidadKg, newLote, "QM09", true);
                var log40 = x.MoveEstado(idstockOriginal, cantidadKg, StockStatusManager.EstadoLote.Restringido, "MM0", comentario: motivo);
                if (log40 > 0)
                    MessageBox.Show(@"Se ha realizado correctamente el Cambio de Estado del Material", @"Cambio de Estado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }
        }
    }
}