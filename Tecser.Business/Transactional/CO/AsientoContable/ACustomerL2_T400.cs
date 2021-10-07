using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public class AsCustomerL2T400 : AsCustomerL1
    {
        private readonly int _idFactura;
        private T0400_FACTURA_H _h4;
        private List<T0401_FACTURA_I> _i4;
        private int signo = 1;  //signo =1 o -1

        public AsCustomerL2T400(int idFactura, string tcode) : base(tcode)
        {
            _idFactura = idFactura;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h4 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (_h4 == null) throw new InvalidOperationException("No Existe el registro en T0400");

                base.TipoDocumento = _h4.TIPO_DOC;
                base.NumeroDocumento = _h4.NumeroDoc;
                base.LX = _h4.TIPOFACT == "L1" ? AsientoNumeracion.TipoLx.L1 : AsientoNumeracion.TipoLx.L2;
                _i4 = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                IdCliente = _h4.Cliente;
                RazonSocial = _h4.RAZONSOC;
                TC = _h4.TC;
                Moneda = _h4.FacturaMoneda;
                FechaAsiento = _h4.FECHA;
            }
        }


        /// <summary>
        /// Genera Asiento de Anulacion de una Factura Completa (Reverse Asiento)
        /// </summary>
        public AsientoNumeracion.ReturnNumeracion AsNdAnunlaNcCompleta()
        {
            var rtn = new AsientoNumeracion.ReturnNumeracion()
            {
                Nasx2 = -1,
                Nasx1 = -1,
                IdDocu = -1
            };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == _h4.IDFACTURA);
                var facturaAsociada = t3?.idFacturaAsociada;
                if (facturaAsociada == null)
                    return rtn;

                var t4 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == facturaAsociada);
                if (t4 == null)
                    return rtn;
                var asientoAsociado = t4.NAS.Value;
                string texto1 = "Emision ND x Anulacion NC";
                rtn = new AsientoCopia().GeneraAsientoInverso(asientoAsociado, _h4.FECHA, TipoDocumento,
                    NumeroDocumento, texto1,
                    "NCDX", "*");
                return rtn;
            }
        }



        /// <summary>
        /// Simil a A AsNotaDebitoCreditoFromT400 pero mas basico para Ajustes
        /// No recorre items de T0401 - e incluye descripcion de ajuste + o -
        /// No incluye segmentos de impuestos
        /// </summary>
        public AsientoNumeracion.ReturnNumeracion AsAjusteCuentaCorriente()
        {
            var rtn = new AsientoNumeracion.ReturnNumeracion()
            {
                Nasx2 = -1,
                Nasx1 = -1,
                IdDocu = -1
            };
            DebeHaber dh;
            string descripcionAsientoItem;
            string texto01Header;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == _h4.IDFACTURA);
                texto01Header = "Ajuste CC >"  + t3.COMENTARIO;
                if (texto01Header.Length > 30)
                {
                    texto01Header = texto01Header.Substring(0, 29);
                }
                
                if (_h4.TotalFacturaB > 0)
                {
                    //Ajuste positivo => Facturacion
                    dh = DebeHaber.Debe;
                    descripcionAsientoItem = "Ajuste Contable +";
                }
                else
                {
                    //Ajuste negativo => Cobranza
                    dh = DebeHaber.Haber;
                    descripcionAsientoItem = "Ajuste Contable -";
                }
                CreaHeaderMemoriaNew(texto01Header, Math.Abs(_h4.TotalFacturaN)); //El Header va ABS
                
                //Segmento A/R
                SegmentoAR(dh, Math.Abs(_h4.TotalFacturaN), "A/R Ajuste: " + _h4.RAZONSOC, descripcionAsientoItem + _h4.RAZONSOC,
                    _h4.GLAR, "T400", _h4.IDFACTURA);
                
                //Segmentos Resultado -- Invierte Debe/Haber del A/R
                dh = dh == DebeHaber.Debe ? DebeHaber.Haber : DebeHaber.Debe;
                foreach (var i in _i4)
                {
                    AddGenericCompleteSegmentNew(Math.Abs(i.PRECIOT_FACT_ARS), i.DESC_REMITO, i.ITEM, dh,
                        i.GLV, base.IdCliente, nombreTablaReferencia: "T400", numeroIdReferencia: _idFactura,
                        textoIdReferencia: "@" + i.IDITEM);
                }
                return GrabaAsientoNew();
            }
        }




        public AsientoNumeracion.ReturnNumeracion AsNotaDebitoCreditoFromT400(string texto01)
        {
            var rtn = new AsientoNumeracion.ReturnNumeracion()
            {
                Nasx2 = -1,
                Nasx1 = -1,
                IdDocu = -1
            };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == _h4.IDFACTURA);
                var facturaAsociada = t3?.idFacturaAsociada;
                texto01 = texto01 +" " + t3.COMENTARIO;
                if (texto01.Length > 30)
                {
                    texto01 = texto01.Substring(0, 29);
                }
;
                CreaHeaderMemoriaNew(texto01, _h4.TotalFacturaN);
                foreach (var i in _i4)
                {
                    if (_h4.FacturaMoneda == "ARS")
                    {
                        if (i.PRECIOT_FACT_ARS > 0)
                        {
                            AddGenericCompleteSegmentNew(i.PRECIOT_FACT_ARS, i.DESC_REMITO, i.ITEM, DebeHaber.Haber,
                                i.GLV,
                                base.IdCliente, nombreTablaReferencia: "T400", numeroIdReferencia: _idFactura,
                                textoIdReferencia: "@" + i.IDITEM);
                        }
                        else
                        {
                            AddGenericCompleteSegmentNew(Math.Abs(i.PRECIOT_FACT_ARS), i.DESC_REMITO, i.ITEM, DebeHaber.Debe,
                                i.GLV, base.IdCliente, nombreTablaReferencia: "T400", numeroIdReferencia: _idFactura,
                                textoIdReferencia: "@" + i.IDITEM);
                        }
                    }
                    else
                    {
                        if (i.PRECIOT_FACT_ARS > 0)
                        {
                            AddGenericCompleteSegmentNew(i.PRECIOT_FACT_USD, i.DESC_REMITO, i.ITEM, DebeHaber.Haber,
                                i.GLV,
                                base.IdCliente, nombreTablaReferencia: "T400", numeroIdReferencia: _idFactura,
                                textoIdReferencia: "@" + i.IDITEM);
                        }
                        else
                        {
                            AddGenericCompleteSegmentNew(Math.Abs(i.PRECIOT_FACT_USD), i.DESC_REMITO, i.ITEM, DebeHaber.Debe,
                                i.GLV, base.IdCliente, nombreTablaReferencia: "T400", numeroIdReferencia: _idFactura,
                                textoIdReferencia: "@" + i.IDITEM);
                        }
                    }
                }

                //Segmento Impuesto IVA, IIBB [Debe]
                if (_h4.TIPOFACT == "L1")
                {
                    if (_h4.IIBB_PORC == null) _h4.IIBB_PORC = 0;
                    SegmentoTaxT400(DebeHaber.Haber, _h4.TotalIVA21, _h4.TotalIIBB, _h4.IIBB_PORC.Value,
                        _h4.Tax2Importe,
                        _h4.Tax2Alicuota, _h4.TotalImpo, "T400", _h4.IDFACTURA);
                }

                if (_h4.Descuento == null) _h4.Descuento = 0;
                if (_h4.DescuentoPorc == null) _h4.DescuentoPorc = 0;

                //Segmento Descuento [Debe]
                if (_h4.Descuento.Value != 0)
                    SegmentoDescuentos(DebeHaber.Debe, _h4.Descuento.Value, _h4.DescuentoPorc.Value, "T400",
                        _h4.IDFACTURA);

                //Segmento AR [Debe]

                if (_h4.TotalFacturaN > 0)
                {
                    SegmentoAR(DebeHaber.Debe, _h4.TotalFacturaN, "A/R: " + _h4.RAZONSOC, "A/R " + _h4.RAZONSOC,
                        _h4.GLAR, "T400", _h4.IDFACTURA);
                }
                else
                {
                    SegmentoAR(DebeHaber.Haber, Math.Abs(_h4.TotalFacturaN), "A/R: " + _h4.RAZONSOC, "A/R " + _h4.RAZONSOC,
                        _h4.GLAR, "T400", _h4.IDFACTURA);
                }
                return GrabaAsientoNew();
            }
        }
    





    /// <summary>
        /// Recorre la Lista de T400 y Genera el asiento completo de una Factura Normal
        /// </summary>
        public void GeneraAsientoFactura()
        {
            foreach (var i in _i4)
            {
                var stdCost = new ACostoStandard(i.ITEM, i.TC);
                decimal costoAsiento = 0;
                decimal cantidad = 1;
                if (i.KGDESPACHADOS_R != null)
                    cantidad = i.KGDESPACHADOS_R.Value;
                
                if (_h4.FacturaMoneda == "ARS")
                {
                    //Factura en ARS
                    //Segmento Item Venta Producto [Haber]
                    AddGenericCompleteSegmentNew(i.PRECIOT_FACT_ARS, "Venta Bruta@" + i.ITEM, "/", DebeHaber.Haber,
                        i.GLV, _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg:cantidad);

                    //Segmentos de Costos [Debe]
                    costoAsiento = stdCost.Encontrado ? Math.Round(stdCost.ValorARS * cantidad,2) : 0;
                    AddGenericCompleteSegmentNew(costoAsiento, "Costo STD[" + _h4.FacturaMoneda + "]@" + i.ITEM, i.ITEM,
                        DebeHaber.Debe, GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.CostoMercaderiaVendida),
                        _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg: cantidad);

                    //Segmento de Baja de Inventario [Haber]
                    AddGenericCompleteSegmentNew(costoAsiento, "Baja de Inventario [" + _h4.FacturaMoneda + "]@" + i.ITEM, i.ITEM,
                        DebeHaber.Haber, GLAccountManagement.GetGLInventarioMaterialMaster(i.ITEM), _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg: cantidad);
                }
                else
                {
                    //Factura en USD
                    //Segmento Item Venta Producto [Haber]
                    AddGenericCompleteSegmentNew(i.PRECIOT_FACT_USD, "Venta Bruta@" + i.ITEM, "/", DebeHaber.Haber,
                        i.GLV, _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg: cantidad);

                    //Segmentos de Costos [Debe]
                    costoAsiento = stdCost.Encontrado ? Math.Round(stdCost.ValorUSD * cantidad, 2) : 0;
                    AddGenericCompleteSegmentNew(costoAsiento, "Costo STD[" + _h4.FacturaMoneda + "]@" + i.ITEM, i.ITEM,
                        DebeHaber.Debe, GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.CostoMercaderiaVendida),
                        _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg: cantidad);

                    //Segmento de Baja de Inventario [Haber]
                    AddGenericCompleteSegmentNew(costoAsiento, "Baja de Inventario [" + _h4.FacturaMoneda + "]@" + i.ITEM, i.ITEM,
                        DebeHaber.Haber, GLAccountManagement.GetGLInventarioMaterialMaster(i.ITEM), _h4.Cliente, nombreTablaReferencia: "T400", numeroIdReferencia: _h4.IDFACTURA,
                        material: i.ITEM, kg: cantidad);
                }
            }
            
            //Segmento Impuesto IVA, IIBB [Haber]
            if (_h4.TIPOFACT == "L1")
            {
               if (_h4.IIBB_PORC == null) _h4.IIBB_PORC = 0;
                SegmentoTaxT400(DebeHaber.Haber, _h4.TotalIVA21, _h4.TotalIIBB, _h4.IIBB_PORC.Value, _h4.Tax2Importe,
                    _h4.Tax2Alicuota, _h4.TotalImpo,  "T400", _h4.IDFACTURA);
            }

            if (_h4.Descuento == null) _h4.Descuento = 0;
            if (_h4.DescuentoPorc == null) _h4.DescuentoPorc = 0;

            //Segmento Descuento [Debe]
            if (_h4.Descuento.Value != 0)
                SegmentoDescuentos(DebeHaber.Debe, _h4.Descuento.Value, _h4.DescuentoPorc.Value, "T400", _h4.IDFACTURA);
            
            //Segmento AR [Debe]
            SegmentoAR(DebeHaber.Debe,_h4.TotalFacturaN,"A/R: " + _h4.RAZONSOC,"Facturacion a " + _h4.RAZONSOC,_h4.GLAR,"T400", _h4.IDFACTURA);
          
        }
    }
}
