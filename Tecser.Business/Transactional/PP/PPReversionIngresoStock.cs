using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP
{
    public class PPReversionIngresoStock
    {
        public enum MotivoError
        {
            NoExisteLineaT0030,
            StockNoDisponible,
            StockInsuficiente,
            MovimientoInvalido,
            OK,
            IngresoNoTempral,
            LineaYaReversada,
        }

        //---------------------------------------------------------------------------------------------------------------------------
        public bool OkReverseIngreso = false;
        public MotivoError Motivo;
        private List<T0030_STOCK> _stockList = new List<T0030_STOCK>();
        private decimal _kgReversion = 0;
        private string _material;
        private string _lote;
        private string _planta;
        private int _id40;
        private bool _soloTemporal = true;
        //---------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// El Stock tiene que estar en estado liberado
        /// Parametro IngresoTemporal es para que esta funcion funcione solo para ingresos temporales ya que 
        /// los ingresos definitivos tienen que ser manejados de otra forma - con otros controles (i.e: descontar MP primero)
        /// </summary>
        public void ChecAvailabiltyReverseManufacturedMaterial(int id40, bool ingresoTemporal = true, string planta = "CERR")
        {
            //1 chequear si el id es tipo de movimiento ingreso stock terminado tipo?
            //2.chequear si el material esta disponible en stock aun (material, kg, lote)
            //3.loguea okreverse = true
            _planta = planta;
            _soloTemporal = ingresoTemporal;
            _id40 = id40;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _stockList = null;
                _kgReversion = 0;
                OkReverseIngreso = false;

                var data40 = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == id40);
                if (data40 == null)
                {
                    Motivo = MotivoError.NoExisteLineaT0030;
                    return;
                }

                if (data40.IET == "R")
                {
                    Motivo = MotivoError.LineaYaReversada;
                    return;
                }


                Motivo = MotivoError.MovimientoInvalido;
                if (data40.TIPOMOVIMIENTO == 1 || data40.TIPOMOVIMIENTO == 503)
                {

                }
                else
                {
                    return; //devuelve el movimiento invalido
                }

                if (ingresoTemporal && data40.TIPOMOVIMIENTO == 1)
                {
                    //Se intenta reversar con Ingreso Temporal un movimiento Definitivo
                    Motivo = MotivoError.IngresoNoTempral;
                    return;
                }

                _kgReversion = data40.CANTIDAD.Value;
                _material = data40.IDMATERIAL;
                _lote = data40.BATCH;
                _stockList =
                    db.T0030_STOCK.Where(
                        c =>
                            c.Material == data40.IDMATERIAL && c.Batch == data40.BATCH &&
                            c.Estado == StockStatusManager.EstadoLote.Liberado.ToString() && c.PLTN == planta).ToList();

                if (_stockList.Any() == false)
                {
                    Motivo = MotivoError.StockNoDisponible;
                    return;
                }

                var kgLiberado = _stockList.Sum(c => c.Stock);
                if (kgLiberado < _kgReversion)
                {
                    Motivo = MotivoError.StockInsuficiente;
                    return;
                }
                OkReverseIngreso = true;
                Motivo = MotivoError.OK;
            }
        }

        /// <summary>
        /// Esta funcion se ejecuta despues de ChecAvailabiltyReverseManufacturedMaterial
        /// </summary>
        /// <returns></returns>
        public bool ReversarIngresoMaterialFabricado()
        {
            var kgRestantesDescuento = _kgReversion;

            if (OkReverseIngreso == false)
                return false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = _stockList.Where(c => c.Stock == _kgReversion).ToList();
                var idStockBorrar = 0;
                if (stk.Any())
                {
                    //Hay al menos una linea que puede usarse sin hacer split
                    idStockBorrar = stk[0].IDStock;
                    new StockManager().DeleteStockLine(idStockBorrar);
                    kgRestantesDescuento = 0;
                }
                else
                {
                    while (kgRestantesDescuento != 0)
                    {
                        _stockList =
                            db.T0030_STOCK.Where(
                                c =>
                                    c.Material == _material && c.Batch == _lote &&
                                    c.Estado == StockStatusManager.EstadoLote.Liberado.ToString() && c.PLTN == _planta)
                                .OrderByDescending(c => c.Stock)
                                .ToList();

                        idStockBorrar = _stockList[0].IDStock;
                        new StockManager().SeleccionaLineaStockParaReversacion(idStockBorrar, kgRestantesDescuento);

                        var linea = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockBorrar);
                        kgRestantesDescuento = kgRestantesDescuento - linea.Stock;
                        if (kgRestantesDescuento < 0)
                            kgRestantesDescuento = 0;

                        db.T0030_STOCK.Remove(linea);
                        db.SaveChanges();
                    }
                }

                if (kgRestantesDescuento != 0) return false;
                new MmLog().ReversionLogIngresoStock(_id40);
                return true;
            }
        }
    }
}
