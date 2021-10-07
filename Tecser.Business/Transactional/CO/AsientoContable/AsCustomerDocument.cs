using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI.MainDocumentData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    /// <summary>
    /// Revision 2018.04.02
    /// Funciones especificas para asientos de Clientes
    /// Contiene los asientos/segmentos
    /// </summary>
    public class AsCustomerDocument : AsCustomerL1
    {
        public AsCustomerDocument(int idFactura, string transactionCode)
            : base(transactionCode)
        {
            _idFactura = idFactura;
            LoadHeaderData();
            base.TipoDocumento = _h400.TIPO_DOC;
        }

        private readonly int _idFactura;
        private T0400_FACTURA_H _h400;
        private List<T0401_FACTURA_I> _i401 = new List<T0401_FACTURA_I>();

        protected  void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                if (_h400 == null)
                    throw new InvalidOperationException("No Existe el registro en T0400");

                base.IdCliente = _h400.Cliente;
                base.RazonSocial = new CustomerManager().GetCustomerBillToData(IdCliente).cli_rsocial;

                _i401 = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
            }
        }

        /// <summary>
        /// Genera asiento completo 
        /// </summary>
        public IdentificacionAsiento AsientoFromCustomerFactura()
        {
            //Crea Header Asiento Factura
            var headerDescription = "Emision Doc Fac > " + _h400.RAZONSOC;
            NumeroDocumento = new CustomerInvoice(base.Tcode, _idFactura).GetNumeroDocumentoCompleto();
            base.CreaHeaderMemoria(_h400.TIPOFACT, _h400.FECHA, _h400.TIPO_DOC, NumeroDocumento,
                headerDescription, _h400.FacturaMoneda, _h400.TotalFacturaN, _h400.TC);

            GeneraSegmentoFromFacturaItems();
            GeneraSegmentoCMV_BajaInventario();

            if (_h400.TotalIVA21 > 0)
            {
                GeneraSegmentoIVA21();
            }

            if (_h400.Descuento > 0)
            {
                GeneraSegmentoDescuentoVentas();
            }

            if (_h400.TotalIIBB > 0)
            {
                GeneraSegmentoPercepcionIIBB();
            }
            base.GeneraSegmentoAR(TipoDocumento, Header.REFE, _h400.TIPOFACT, DebeHaber.Debe, _h400.FacturaMoneda,
                _h400.TotalFacturaN, "T0400_FACTURA_H", _idFactura);

            return GrabaAsiento();
        }

        
        public IdentificacionAsiento AsientoFromCustomerNotaDebito()
        {
            //Crea Header Asiento NotaDebito
            var headerDescription = "Emision Doc Debito > " + _h400.RAZONSOC;
            NumeroDocumento = _h400.NumeroDoc;

            //NumeroDocumento = new CustomerInvoice(base.Tcode, _idFactura).GetNumeroDocumentoCompleto();

            base.CreaHeaderMemoria(_h400.TIPOFACT, _h400.FECHA, _h400.TIPO_DOC, NumeroDocumento,
                headerDescription, _h400.FacturaMoneda, _h400.TotalFacturaN, _h400.TC);

            GeneraSegmentoFromNdItems();

            if (_h400.TotalIVA21 > 0)
            {
                GeneraSegmentoIVA21();
            }

            if (_h400.Descuento > 0)
            {
                GeneraSegmentoDescuentoVentas();
            }

            if (_h400.TotalIIBB > 0)
            {
                GeneraSegmentoPercepcionIIBB();
            }

            base.GeneraSegmentoAR(TipoDocumento, Header.REFE, _h400.TIPOFACT, DebeHaber.Debe, _h400.FacturaMoneda,
                _h400.TotalFacturaN, "T0400_FACTURA_H", _idFactura);

            return GrabaAsiento();
        }






        public IdentificacionAsiento AsientoFromCustomerNotaCreditoFromT400()
        {
            //Crea Header Asiento Nota de Credito
            var headerDescription = "Emision Nota Credito:> " + _h400.RAZONSOC;
            NumeroDocumento = _h400.NumeroDoc;

            //NumeroDocumento = new CustomerInvoice(base.Tcode, _idFactura).GetNumeroDocumentoCompleto();
            
            base.CreaHeaderMemoria(_h400.TIPOFACT, _h400.FECHA, _h400.TIPO_DOC, NumeroDocumento,
                headerDescription, _h400.FacturaMoneda, _h400.TotalFacturaN, _h400.TC);

            GeneraSegmentoFromNdItems(); //revisar aca, debe ser al reves!
            if (_h400.TotalIVA21 > 0)
            {
                GeneraSegmentoIVA21();
            }

            if (_h400.Descuento > 0)
            {
                GeneraSegmentoDescuentoVentas();
            }

            if (_h400.TotalIIBB > 0)
            {
                GeneraSegmentoPercepcionIIBB();
            }
            base.GeneraSegmentoAR(TipoDocumento, Header.REFE, _h400.TIPOFACT, DebeHaber.Debe, _h400.FacturaMoneda,
                _h400.TotalFacturaN, "T0400_FACTURA_H", _idFactura);
            return GrabaAsiento();
        }
        
        #region Segmentos

        private void GeneraSegmentoCMV_BajaInventario()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factItems = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var item in factItems)
                {
                    //segmento de Asiento de CMV (DEBE)
                    string descripcion1 = null;
                    var descripcion2 = item.ITEM;
                    decimal importeDh = 0;

                    var costoStd = new ACostoMfgNowStd(item.ITEM);
                    costoStd.GetCost();

                    if (_h400.FacturaMoneda == "ARS")
                    {
                        descripcion1 = "Costo [ARS]@" + item.ITEM;
                        importeDh = costoStd.ValorARS;
                    }
                    else
                    {
                        descripcion1 = "Costo [USD]@" + item.ITEM;
                        importeDh = costoStd.ValorUSD;
                    }

                    AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                        GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.CostoMercaderiaVendida),
                        descripcion1, descripcion2, _h400.FacturaMoneda, DebeHaber.Debe, importeDh, base.Tcode,
                        _h400.Cliente, 0, "T0400_FACTURA_H", _idFactura, null, item.KGDESPACHADOS_R, item.ITEM);


                    //segmento de Asiento de Baja de Inventario (HABER)

                    if (_h400.FacturaMoneda == "ARS")
                    {
                        descripcion1 = "Baja Inventario [ARS]@" + item.ITEM;
                    }
                    else
                    {
                        descripcion1 = "Baja Inventario [USD]@" + item.ITEM;
                    }

                    AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                        GLAccountManagement.GetGLInventarioMaterialMaster(item.ITEM),
                        descripcion1, descripcion2, _h400.FacturaMoneda, DebeHaber.Haber, importeDh, base.Tcode,
                        _h400.Cliente, 0, "T0400_FACTURA_H", _idFactura, null, item.KGDESPACHADOS_R, item.ITEM);
                }
            }
        }
        private void GenerateSegmentoAr()
        {
            AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR),
                "A/R - " + _h400.RAZONSOC, null, _h400.FacturaMoneda, DebeHaber.Debe, _h400.TotalFacturaN, base.Tcode,
                _h400.Cliente, 0, "T0400_FACTURA_H", _idFactura);
        }

        /// <summary>
        /// Crea el segmento de venta de todos los items valido para Factura
        /// Atencion que en NOTA CREDITO los valores van en el DEBE.
        /// </summary>
        /// 
        private void GeneraSegmentoFromFacturaItems()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factItems = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var item in factItems)
                {
                    var descripcion1 = "Venta@" + item.ITEM;
                    var descripcion2 = "";
                    decimal importeDH = 0;
                    importeDH = _h400.FacturaMoneda == "ARS" ? item.PRECIOT_FACT_ARS : item.PRECIOT_FACT_USD;
                    
                    AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT, item.GLV, descripcion1,
                        descripcion2, _h400.FacturaMoneda, DebeHaber.Haber, importeDH, base.Tcode, _h400.Cliente,
                        0, "T0400_FACTURA_H", _idFactura, null, item.KGDESPACHADOS_R, item.ITEM);
                }
            }
        }
        private void GeneraSegmentoFromNdItems()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factItems = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var item in factItems)
                {
                    var descripcion1 = item.ITEM;
                    var descripcion2 = "Iditem@" + item.IDITEM;
                    decimal importeDH = 0;
                    importeDH = _h400.FacturaMoneda == "ARS" ? item.PRECIOT_FACT_ARS : item.PRECIOT_FACT_USD;
                    
                    var rtn = AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT, item.GLV, descripcion1,
                        descripcion2, _h400.FacturaMoneda, DebeHaber.Haber, importeDH, base.Tcode, _h400.Cliente,
                        0, "T0400_FACTURA_H", _idFactura, null, item.KGDESPACHADOS_R, item.ITEM);

                    item.NASSEG = rtn;
                    item.NUMFACTURA = NumeroDocumento;
                    item.NAS = Header.IDDOCU;

                    db.SaveChanges();
                }
            }
        }
        private void GeneraSegmentoPercepcionIIBB()
        {
            AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.PercepcionIIBB),
                "Perecpcion IIBB Prov BsAs", null, _h400.FacturaMoneda, DebeHaber.Haber, _h400.TotalIIBB, base.Tcode,
                _h400.Cliente, 0, "T0400_FACTURA_H", _idFactura);
        }
        private void GeneraSegmentoIVA21()
        {
            AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaVenta21),
                "Iva Debito Fiscal 21%", null, _h400.FacturaMoneda, DebeHaber.Haber, _h400.TotalIVA21, base.Tcode,
                _h400.Cliente, 0, "T0400_FACTURA_H", _idFactura);
        }
        private void GeneraSegmentoDescuentoVentas()
        {
            AddGenericCompleteSegment(_h400.TIPO_DOC, Header.REFE, _h400.TIPOFACT,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoVentas),
                "Descuento en Ventas", null, _h400.FacturaMoneda, DebeHaber.Debe, _h400.Descuento.Value, base.Tcode,
                _h400.Cliente,0, "T0400_FACTURA_H", _idFactura);
        }

        #endregion
    }

}
