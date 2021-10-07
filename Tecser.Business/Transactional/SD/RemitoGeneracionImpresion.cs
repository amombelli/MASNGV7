using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoGeneracionImpresion
    {
        public T0055_REMITO_H GetRemitoHeader(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
            }
        }
        public string DefineNumeroRemito(string tipoLx, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string numero = null;
                if (tipoLx == "L1")
                {
                    var referencia = db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).REF_REL1;

                    if (db.T000.SingleOrDefault(c => c.ID == referencia).VALUE == null)
                    {
                        numero = null;
                    }
                    else
                    {
                        var valor = db.T000.SingleOrDefault(c => c.ID == referencia).VALUE;
                        if (string.IsNullOrEmpty(valor))
                        {
                            return "00000000X";
                        }
                        else
                        {
                            numero =
                                (Convert.ToInt32(valor) + 1).ToString() +
                                "X";
                        }

                    }


                    return numero;
                }
                else
                {
                    var referencia = db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).REF_REL2;
                    var xRemitoNumber = db.T000.SingleOrDefault(c => c.ID == referencia).VALUE;
                    int number;
                    var result = int.TryParse(xRemitoNumber, out number);
                    if (result)
                    {
                        return (number + 1).ToString();
                    }
                    else
                    {
                        return xRemitoNumber + "?";
                    }
                }
            }
        }
        public string DefineSucursalRemito(string tipoLx, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (tipoLx == "L1")
                    return db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).SUCREL1;

                return db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).SUCREL2;
            }
        }
        public bool UpdateUltimoNumeroRemitoUtilizado(string numeroRemito, string tipoLx, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (tipoLx == "L1")
                {
                    var referencia = db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).REF_REL1;
                    var data = db.T000.SingleOrDefault(c => c.ID == referencia);
                    data.VALUE = numeroRemito;
                }
                else
                {
                    var referencia = db.T0016_PLANTAS.SingleOrDefault(c => c.IDPLTN == planta.ToUpper()).REF_REL2;
                    var data = db.T000.SingleOrDefault(c => c.ID == referencia);
                    data.VALUE = numeroRemito;
                }
                var y = db.SaveChanges();
                if (y >= 1)
                    return true;
                return false;
            }
        }
        public List<T0057_REMITO_I_PRINT> GetDataItemRemito(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0057_REMITO_I_PRINT.Where(c => c.IDREMITO == idRemito).ToList();
            }
        }
        public void SetDataRemitoPrintModoDetalle(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d57 = db.T0057_REMITO_I_PRINT.Where(c => c.IDREMITO == idRemito).ToList();
                if (d57.Count > 0)
                {
                    db.T0057_REMITO_I_PRINT.RemoveRange(d57);
                    db.SaveChanges();
                }

                var dataInsert =
                    db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito && c.GENERAR_REMITO.Value == true).ToList();

                foreach (var it in dataInsert)
                {
                    var newData0057 = new T0057_REMITO_I_PRINT
                    {
                        IDREMITO = it.IDREMITO,
                        DESC_REMITO = it.DESC_REMITO,
                        GLI = it.GL,
                        GLV = it.GLV,
                        IDITEM = it.IDITEM,
                        IDMATERIAL = it.MATERIALAKA,
                        IVA21 = it.IVA21,
                        KGDESPACHADOS_R = it.KGDESPACHADOS_R,
                        MONEDA = it.MONEDA,
                        NUMREMITO = it.NUMREMITO,
                        BATCH_REMITO = it.BATCH_REMITO,
                        PRECIOT = it.PRECIOT,
                        PRECIOU = it.PRECIOU,
                        TC_FACTU = it.TC_FACTU,
                        VISIBLE_FA = it.VISIBLE_FA,
                        VISIBLE_RE = it.VISIBLE_RE
                    };

                    db.T0057_REMITO_I_PRINT.Add(newData0057);
                    db.SaveChanges();
                }




                //if (monedaRemito == "ARS")
                //{
                //    foreach (var it in dataInsert)
                //    {
                //        var newData0057 = new T0057_REMITO_I_PRINT
                //        {
                //            IDREMITO = it.IDREMITO,
                //            DESC_REMITO = it.DESC_REMITO,
                //            GLI = it.GL,
                //            GLV = it.GLV,
                //            IDITEM = it.IDITEM,
                //            IDMATERIAL = it.MATERIALAKA,
                //            IVA21 = it.IVA21,
                //            KGDESPACHADOS_R = it.KGDESPACHADOS_R,
                //            MONEDA = monedaRemito,
                //            NUMREMITO = it.NUMREMITO,
                //            BATCH_REMITO = it.BATCH_REMITO,
                //            PRECIOT = it.PRECIOT_ARS,
                //            PRECIOU = it.PRECIOU_ARS,
                //            TC_FACTU = it.TC_FACTU,
                //            VISIBLE_FA = it.VISIBLE_FA,
                //            VISIBLE_RE = it.VISIBLE_RE
                //        };

                //        db.T0057_REMITO_I_PRINT.Add(newData0057);
                //        db.SaveChanges();
                //    }
                //}
                //else
                //{
                //    foreach (var it in dataInsert)
                //    {
                //        var newData0057 = new T0057_REMITO_I_PRINT
                //        {
                //            IDREMITO = it.IDREMITO,
                //            DESC_REMITO = it.DESC_REMITO,
                //            GLI = it.GL,
                //            GLV = it.GLV,
                //            IDITEM = it.IDITEM,
                //            IDMATERIAL = it.MATERIALAKA,
                //            IVA21 = it.IVA21,
                //            KGDESPACHADOS_R = it.KGDESPACHADOS_R,
                //            MONEDA = monedaRemito,
                //            NUMREMITO = it.NUMREMITO,
                //            BATCH_REMITO = it.BATCH_REMITO,
                //            PRECIOT = it.PRECIOT_USD,
                //            PRECIOU = it.PRECIOU_USD,
                //            TC_FACTU = it.TC_FACTU,
                //            VISIBLE_FA = it.VISIBLE_FA,
                //            VISIBLE_RE = it.VISIBLE_RE
                //        };

                //        db.T0057_REMITO_I_PRINT.Add(newData0057);
                //        db.SaveChanges();
                //    }
                //  }
            }
        }

        public List<T0056_REMITO_I> GetItemsRemito56(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
            }
        }


        /// <summary>
        /// Genera en T0057 los datos de T0056 agrupados
        /// </summary>
        /// Removi moneda de remito
        public void SetDataRemitoPrintModoSumarizado(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d57 = db.T0057_REMITO_I_PRINT.Where(c => c.IDREMITO == idRemito).ToList();
                if (d57.Count > 0)
                {
                    db.T0057_REMITO_I_PRINT.RemoveRange(d57);
                    db.SaveChanges();
                }

                var result = from d56 in db.T0056_REMITO_I
                             group d56 by
                                 new
                                 {
                                     d56.GL,
                                     d56.MATERIALAKA,
                                     d56.IDREMITO,
                                     d56.MONEDA,
                                     d56.IVA21,
                                     d56.DESC_REMITO,
                                     d56.VISIBLE_RE,
                                     d56.VISIBLE_FA,
                                     d56.GLV,
                                     d56.GENERAR_REMITO
                                 }
                    into grp
                             where grp.Key.IDREMITO == idRemito && grp.Key.GENERAR_REMITO.Value == true
                             select new
                             {
                                 IDREMITO = grp.Key.IDREMITO,
                                 DESC_REMITO = grp.Key.DESC_REMITO,
                                 GL = grp.Key.GL,
                                 GLV = grp.Key.GLV,
                                 MATERIALAKA = grp.Key.MATERIALAKA,
                                 IVA21 = grp.Key.IVA21,
                                 KGDESPACHADOS_R = grp.Sum(c => c.KGDESPACHADOS_R),
                                 MONEDA = grp.Key.MONEDA,
                                 NUMREMITO = grp.Max(c => c.NUMREMITO),
                                 BATCH_REMITO = "*",
                                 PRECIOT = grp.Sum(c => c.PRECIOT),
                                 PRECIOU = grp.Average(c => c.PRECIOU),
                                 TC_FACTU = grp.Average(c => c.TC_FACTU),
                                 VISIBLE_FA = grp.Key.VISIBLE_FA,
                                 VISIBLE_RE = grp.Key.VISIBLE_RE
                             };
                var dataInsert = result.ToList();
                int indexA = 1;
                foreach (var it in dataInsert)
                {
                    var newData0057 = new T0057_REMITO_I_PRINT
                    {
                        IDREMITO = it.IDREMITO,
                        DESC_REMITO = it.DESC_REMITO,
                        GLI = it.GL,
                        GLV = it.GLV,
                        IDITEM = indexA,
                        IDMATERIAL = it.MATERIALAKA,
                        IVA21 = it.IVA21,
                        KGDESPACHADOS_R = it.KGDESPACHADOS_R,
                        //MONEDA = monedaRemito,
                        NUMREMITO = it.NUMREMITO,
                        BATCH_REMITO = it.BATCH_REMITO,
                        //PRECIOT = it.PRECIOT,
                        //PRECIOU = it.PRECIOU,
                        //TC_FACTU = it.TC_FACTU,
                        VISIBLE_FA = it.VISIBLE_FA,
                        VISIBLE_RE = it.VISIBLE_RE
                    };
                    indexA++;
                    db.T0057_REMITO_I_PRINT.Add(newData0057);
                    db.SaveChanges();
                }
            }
        }
        public void UpdateT0056FromT0057(int idRemito, int idItem, string descripcion, decimal kgDespachados,
            string lote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var record = db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idItem);
                if (record != null)
                {
                    record.DESC_REMITO = descripcion;
                    record.KGDESPACHADOS_R = kgDespachados;
                    record.BATCH_REMITO = lote;
                    //record.PRECIOU = precioUnitario;
                    //record.PRECIOT = precioUnitario*kgDespachados;
                    //if (record.MONEDA == "ARS")
                    //{
                    //    record.PRECIOU_ARS = precioUnitario;
                    //    record.PRECIOT_ARS = record.PRECIOT;
                    //    record.PRECIOU_USD = precioUnitario/record.TC_FACTU.Value;
                    //    record.PRECIOT_USD = precioUnitario/record.TC_FACTU.Value;
                    //}
                    //else
                    //{
                    //    record.PRECIOU_ARS = precioUnitario*record.TC_FACTU.Value;
                    //    record.PRECIOT_ARS = record.PRECIOT*record.TC_FACTU.Value;
                    //    record.PRECIOU_USD = precioUnitario;
                    //    record.PRECIOT_USD = precioUnitario;
                    //}
                    db.SaveChanges();
                }
            }
        }
        public T0400_FACTURA_H GetDataFacturaRemito(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                return data;
            }
        }
        public bool CheckIfRemitoNumberExist(string sucursal, string numero, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string numeroRemitoCompleto = sucursal + "-" + numero;
                var data = db.T0055_REMITO_H.Where(c => c.NUMREMITO.Equals(numeroRemitoCompleto) && c.TIPO_REMITO == tipoLx).ToList();
                if (data.Count == 0)
                    return false;
                return true;

            }
        }
        public bool UpdateDatosFacturaRemito(int idRemito, bool ckFacturaPendiente, string numeroFactura, int idFactura,
            string monedaFactura = "ARS")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (data != null)
                {
                    data.FACTPEND = ckFacturaPendiente;
                    data.NUMFACTURA = numeroFactura;
                    data.Factura = idFactura;
                    data.FacturaMoneda = monedaFactura;
                    return db.SaveChanges() > 0;
                }
            }
            return false;
        }
        public void SetRemitoToStatusImpreso(int idRemito, string numeroRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var remito = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                remito.Impreso = true;
                remito.StatusRemito = RemitoStatusManager.StatusHeader.Impreso.ToString().ToUpper();
                remito.NUMREMITO = numeroRemito;
                var items = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                //todo agregar campo fechaImpresion y loguear acá
                foreach (var x in items)
                {
                    x.NUMREMITO = numeroRemito;
                }
                db.SaveChanges();
            }
        }
    }
}
