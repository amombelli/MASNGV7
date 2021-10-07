using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public class AsientoVendorDocument : AsientoVendorSpecific
    {
        public AsientoVendorDocument(int idFactura, string tcode) : base(tcode)
        {
            _idFactura = idFactura;
            LoadHeaderData();
            base.TipoDocumento = _h403.TFACTURA;
        }

        //---------------------------------------------------
        private readonly int _idFactura;
        private T0403_VENDOR_FACT_H _h403;
        private List<T0404_VENDOR_FACT_I> _i404 = new List<T0404_VENDOR_FACT_I>();
        //---------------------------------------------------

        protected sealed override void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h403 = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == _idFactura);
                if (_h403 == null)
                    throw new InvalidOperationException("No Existe el registro en T0403*VENDORINVOICE");

                base.IdVendor = _h403.IDPROV;
                base.RazonSocial = new VendorManager().GetSpecificVendor(IdVendor).prov_rsocial;

                _i404 = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == _idFactura).ToList();
            }
        }
        public IdentificacionAsiento AsientoFromVendorFactura()
        {
            //Crea Header Asiento Factura
            String descripcionHeader = null;
            switch (_h403.TFACTURA)
            {
                case "NDA":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Nota Debito de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                case "ND2":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Nota Debito de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                case "NC2":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Nota Credito de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                case "NCA":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Nota Credito de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                case "FPA":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Factura de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                case "VEP":
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "VEP de PAGO >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
                default:
                    descripcionHeader = string.IsNullOrEmpty(_h403.OBSERVACION)
                        ? "Factura de >" + base.RazonSocial
                        : _h403.OBSERVACION;
                    break;
            }



            CreaHeaderMemoria(_h403.TIPO, _h403.FECHA, _h403.TFACTURA, _h403.NFACTURA, descripcionHeader,
                _h403.MON, _h403.NETO, _h403.TC);

            AddSegmentoItemsGasto();

            if (_h403.IVA21 != 0)
            {
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.IvaCompra21, IdVendor, _h403.IVA21, _h403.MON,
                    21, idTablaReferencia: _idFactura);
            }

            if (_h403.IVA10 != 0)
            {
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.IvaCompra10, IdVendor, _h403.IVA10, _h403.MON,
                    10, idTablaReferencia: _idFactura);
            }

            if (_h403.IVA27 != 0)
            {
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.IvaCompra27, IdVendor, _h403.IVA27, _h403.MON,
                    27, idTablaReferencia: _idFactura);
            }

            if (_h403.DTO != 0)
            {
                AddGenericCompleteSegment("DESC", Header.REFE, Header.TIPO,
                    GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoCompras),
                    GLAccountManagement.GetGLDescriptionFromT135(
                        GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoCompras)), "",
                    _h403.MON, DebeHaber.Debe, _h403.DTO * -1, Tcode, 0, _h403.IDPROV, "T0403_VENDOR_FACT_H",
                    _idFactura);
            }

            if (_h403.RedondeoFinal != 0)
            {
                AddGenericCompleteSegment("REDONDEO", Header.REFE, Header.TIPO,
                    GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoCompras),
                    GLAccountManagement.GetGLDescriptionFromT135(
                        GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoCompras)), "",
                    _h403.MON, DebeHaber.Debe, _h403.RedondeoFinal, Tcode, 0, _h403.IDPROV, "T0403_VENDOR_FACT_H",
                    _idFactura);
            }


            if (_h403.PerIIBB != 0)
            {

                decimal alicuota = 0;
                alicuota = _h403.PerIIBB_Alicuota ?? 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.PercepcionIIBB, _h403.IDPROV, _h403.PerIIBB,
                   _h403.MON, alicuota, _h403.PerIIBB_TXT, "T0403_VENDOR_FACT_H", _idFactura);
            }

            if (_h403.PerIVA != 0)
            {
                decimal alicuota = 0;
                alicuota = _h403.PerIVA_Alicuota ?? 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.PercepcionIVA, _h403.IDPROV, _h403.PerIVA,
                   _h403.MON, alicuota, idTablaReferencia: _idFactura);
            }

            if (_h403.PerGS != 0)
            {

                decimal alicuota = 0;
                alicuota = _h403.PerGA_Alicuota ?? 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.PercepcionGS, _h403.IDPROV, _h403.PerGS,
                   _h403.MON, alicuota, "P.Ganancias", "T0403_VENDOR_FACT_H", _idFactura);
            }


            if (_h403.ImpuestoMunicipal != 0)
            {
                decimal alicuota = 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.CompraImpuestoMunicipal, _h403.IDPROV, _h403.ImpuestoMunicipal,
                   _h403.MON, alicuota, idTablaReferencia: _idFactura);
            }

            if (_h403.ImpuestoProvincial != 0)
            {
                decimal alicuota = 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.CompraImpuestoProvincial, _h403.IDPROV, _h403.ImpuestoProvincial,
                   _h403.MON, alicuota, idTablaReferencia: _idFactura);
            }

            if (_h403.IMPINT != 0)
            {
                decimal alicuota = 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.CompraImpuestoInterno, _h403.IDPROV, _h403.IMPINT,
                   _h403.MON, alicuota, idTablaReferencia: _idFactura);
            }

            if (_h403.IMPOTR != 0)
            {
                decimal alicuota = 0;
                AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount.CompraImpuestoOtros, _h403.IDPROV, _h403.IMPOTR,
                   _h403.MON, alicuota, idTablaReferencia: _idFactura);
            }

            if (_h403.ConceptosNoGravados != 0)
            {
                AddGenericCompleteSegment("IMP", Header.REFE, Header.TIPO,
                    GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.CompraImpuestoNoGravado),
                    GLAccountManagement.GetGLDescriptionFromT135(
                        GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.CompraImpuestoNoGravado)), "",
                    _h403.MON, DebeHaber.Debe, _h403.ConceptosNoGravados, "CONTAR", 0, _h403.IDPROV,
                    "T0403_VENDOR_FACT_H", _idFactura);
            }

            //AddSegmento DiferenciaXRedondeo
            //No va segmento de diferencia de redondeo porque ya esta contemplado en el importe bruto.
            //decimal precioTotal = 0;
            //foreach (var ix in _i404)
            //{
            //    if (_h403.MON == "ARS")
            //    {
            //        precioTotal += ix.PTOTAL_ARS.Value;
            //    }
            //    else
            //    {
            //        precioTotal += ix.PTOTAL_USD.Value;
            //    }    
            //}
            //if (_h403.BRUTO.Value != precioTotal)
            //{
            //    AddGenericCompleteSegment("DIF", Header.REFE, Header.TIPO,
            //        "0.0.0.0","Diferencia Redondeo", "",_h403.MON, DebeHaber.Debe, _h403.ConceptosNoGravados.Value, "CONTAR", 0, _h403.IDPROV,
            //        "T0403_VENDOR_FACT_H", _idFactura);
            //}


            //Asiento AP
            AddSegmentoAp(_h403.NETO, _h403.MON, idTablaReferencia: _idFactura);
            return base.GrabaAsiento();
        }
        public IdentificacionAsiento GeneraAsientoPagoAutomaticoContar(int asientoGasto, string cuentaPago, decimal? saldoAPagar = null)
        {
            var resultado = new IdentificacionAsiento()
            {
                IdDocu = 0,
                NasX1 = 0,
                NasX2 = 0,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var asGasto = db.T0602_DOCU_S.SingleOrDefault(c => c.IDDOCU == asientoGasto && c.DOCUTIPO == "AP");
                if (asGasto == null)
                    throw new InvalidOperationException("No Existe el registro Asiento Gasto");

                var asAuxHeader = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == asientoGasto);
                var glAp = asGasto.GL;

                //var factu = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idFactura403);
                //if (factu == null)
                //    return resultado;

                if (saldoAPagar == null)
                {
                    saldoAPagar = _h403.SALDOIMPAGO;
                }

                if (_h403.SALDOIMPAGO > saldoAPagar)
                {
                    return resultado;
                }

                //var importeACancelar = asGasto.HABER;
                //if (factu.SALDOIMPAGO != importeACancelar)
                //    return resultado;

                var datosCuentaPago = db.T0150_CUENTAS.SingleOrDefault(c => c.ID_CUENTA == cuentaPago);

                CreaHeaderMemoria(asGasto.TIPO, asAuxHeader.FECHA.Value, "PD", _h403.NFACTURA,
                    "Pago Directo " + cuentaPago, asAuxHeader.MONE_ORI, saldoAPagar.Value, asGasto.TC.Value);

                base.AddGenericCompleteSegment("PD", _h403.NFACTURA, asGasto.TIPO, datosCuentaPago.GLMAP,
                    "Pago desde " + datosCuentaPago.CUENTA_DESC, null, asGasto.MONE_ORI, DebeHaber.Haber,
                    saldoAPagar.Value, Tcode, idProveedor: IdVendor);

                base.AddGenericCompleteSegment("PD", _h403.NFACTURA, asGasto.TIPO, glAp,
                    "A/P - Pago", null, asGasto.MONE_ORI, DebeHaber.Debe,
                    saldoAPagar.Value, Tcode, idProveedor: IdVendor);

                return base.GrabaAsiento();
            }
        }


        #region Segmentos
        private int AddSegmentoItemsGasto()
        {
            //revisar aca como forma el total!
            foreach (var i in _i404)
            {
                if (i.MONEDA == "ARS")
                {
                    AddGenericCompleteSegment("G", Header.REFE, Header.TIPO, i.GL, i.ITEM_DESC, null, Header.MONE_ORI,
                        DebeHaber.Debe, i.PUNIT_ARS.Value * i.CANT.Value, base.Tcode, 0, base.IdVendor, "T0404_VENDOR_FACT_I", i.IDIT,
                        kgMaterial: i.CANT);
                }
                else
                {
                    AddGenericCompleteSegment("G", Header.REFE, Header.TIPO, i.GL, i.ITEM_DESC, null, Header.MONE_ORI,
                        DebeHaber.Debe, i.PUNIT.Value * i.CANT.Value, base.Tcode, 0, base.IdVendor, "T0404_VENDOR_FACT_I",
                        i.IDIT,
                        kgMaterial: i.CANT);
                }
            }
            return base.Items.Count;
        }


        private void AddSegmentoAp(decimal importeNetoTotal, string moneda = "ARS",
            string nombreTablaReferencia = "T0403_VENDOR_FACT_H", int idTablaReferencia = 0)
        {
            var glap = new GLAccountManagement().GetApVendorGl(IdVendor);
            AddGenericCompleteSegment("AP", Header.REFE, Header.TIPO, glap,
                "A Proveedores " + GLAccountManagement.GetGLDescriptionFromT135(glap)
                , "", moneda, DebeHaber.Haber, importeNetoTotal, Tcode, 0, IdVendor, nombreTablaReferencia,
                idTablaReferencia);
        }

        #endregion
    }
}
