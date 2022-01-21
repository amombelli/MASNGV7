using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TecserEF.Entity;
using TecserSQL.Data.TransactionalData;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

namespace Tecser.Business.Transactional.FI
{
    /// <summary>
    /// Maneja los datos y calculos al agergar facturas a OP
    /// </summary>
    public class MngRetencionesFacturasProv
    {
        /// <summary>
        /// Si la factura esta agregada en T0405 devuelve el numero de OP - sino devuelve 0
        /// </summary>
        private int CheckIfDocExistsInT405(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataR = db.T0405_FACTURAS_RETENCIONES.FirstOrDefault(c => c.IDFacturaProveedor == idFactura);
                return dataR == null ? 0 : 1;
            }
        }

        public List<T0405_FACTURAS_RETENCIONES> GetAllRetencionesFromOP(int numeroOP)
        {
            return
                new TecserData(GlobalApp.CnnApp).T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == numeroOP).ToList();
        }

        public void UpdateImporteRetencionesFacturaSeleccionada(int numeroOP, int idFactura, decimal baseImponible,
            decimal alicuotaIIBB,
            decimal importeIIBB, decimal alicuotaGanancias, decimal importeGanancias, decimal calculoGs, bool modificado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0405_FACTURAS_RETENCIONES.SingleOrDefault(
                        c => c.IDFacturaProveedor == idFactura && c.NumeroOP == numeroOP);
                if (data != null)
                {
                    data.RetIIBBAlicuota = alicuotaIIBB;
                    data.RetIIBBARetener = importeIIBB;
                    data.BaseImponibleDocumento = baseImponible;
                    data.RetGSARetener = importeGanancias;
                    data.RetGSBaseCalculo = calculoGs;
                    data.Modificado = modificado;

                    db.SaveChanges();
                }
            }
            UpdateImporteRetencionesOPFact_OPHeader(numeroOP);
        }

        public bool AgregaRetencionesEnT0405(int idCtaCte, int numeroOP, decimal baseGanancias,
            decimal alicuotaGanancias, decimal alicuotaIIBB, string conceptoGanancias)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factu = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                var idFactura = factu.IDINT;
                var dataExiste =
                    db.T0405_FACTURAS_RETENCIONES.SingleOrDefault(
                        c => c.IDFacturaProveedor == idFactura && c.NumeroOP == numeroOP);

                if (dataExiste != null)
                    return false;

                var facturaData = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (facturaData == null)
                {
                    throw new InvalidOperationException("No Existe el registro en T0403");
                }

                var opData = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOP);
                if (opData == null)
                {
                    throw new InvalidOperationException("No Existe el registro en T0210");
                }

                var f = new T0405_FACTURAS_RETENCIONES
                {
                    ProveedorRazonSocial = facturaData.PROVRS,
                    CUIT = facturaData.PRTAX1,
                    PeriodoOP = opData.Periodo,
                    TipoDocumento = facturaData.TFACTURA,
                    NumeroFactura = facturaData.NFACTURA,
                    RetGsConcepto = conceptoGanancias,
                    IdProveedor = facturaData.IDPROV,
                    NumeroOP = numeroOP,
                    FechaOP = opData.OPFECHA,
                    IDFacturaProveedor = facturaData.IDINT,
                    BaseImponibleDocumento = Convert.ToInt32(CheckBaseImponibleFixSubtotal(facturaData)),
                    RetGSBase = Convert.ToInt32(baseGanancias),
                    RetGSBaseCalculo = Convert.ToInt32(baseGanancias),
                    RetGSAlicuota = alicuotaGanancias,
                    RetGSARetener = new Retenciones().CalculoRetencionGanancias(),
                    RetIIBBAlicuota = alicuotaIIBB,
                    ID = idCtaCte,
                };
                //f.ID = 
                f.RetIIBBARetener = new Retenciones().CalculoRetencionIIBB(alicuotaIIBB, 1,
                    Convert.ToDecimal(f.BaseImponibleDocumento));
                f.RetGSCertificado = "0";
                f.RetIIBBCertificado = "0";
                f.StatusRetencion = "Inicial";
                f.Modificado = false;

                db.T0405_FACTURAS_RETENCIONES.Add(f);
                return db.SaveChanges() > 0;
            }
        }

        public void RemoveRetencionFromT0405(int idCtaCte, int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0405_FACTURAS_RETENCIONES.SingleOrDefault(c => c.ID == idCtaCte && c.NumeroOP == numeroOP);
                if (d != null)
                {
                    db.T0405_FACTURAS_RETENCIONES.Remove(d);
                }
                db.SaveChanges();
                UpdateImporteRetencionesOPFact_OPHeader(numeroOP);
            }
        }

        /// <summary>
        /// Actualiza Importe Retenciones en OP desde T0405 (Header + Imputacion Facturas)
        /// </summary>
        private void UpdateImporteRetencionesOPFact_OPHeader(int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataT405 = db.T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == numeroOP).ToList();
                decimal totalIIBB = 0;
                decimal totalGS = 0;
                foreach (var item in dataT405)
                {
                    var dataFact = db.T0213_OP_FACT.SingleOrDefault(c => c.IDOP == numeroOP && c.IdCtaCte == item.ID);
                    dataFact.RetencionGS = item.RetGSARetener.Value;
                    dataFact.RetencionIIBB = item.RetIIBBARetener.Value;
                    totalGS = (decimal)(totalGS + item.RetGSARetener);
                    totalIIBB = (decimal)(totalIIBB + item.RetIIBBARetener);
                    db.SaveChanges();
                }
                //Actualiza Header OP

                var baseGs =
                    db.T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == numeroOP).Sum(c => c.RetGSBaseCalculo);
                if (baseGs == null)
                    baseGs = 0;
                new OrdenPagoManageDatos(numeroOP).UpdateHeaderConImporteRetenciones(totalGS, baseGs.Value, totalIIBB);
            }
        }

        /// <summary>
        /// Administra la retenciones a la hora de agregar una factura a una OP
        /// Si la factura ya existe en T0405 no agrega nada y regresa False
        /// </summary>
        public bool ManageCalculoRetenciones_AddFactura(int numeroOP, int idCtaCte, decimal baseGanancias,
            decimal alicGanancias, decimal alicIIBB, int conceptoGS)
        {
            var idFactura = new VendorDocumentsManager().GetIdFacturaFromIdCtaCte(idCtaCte);
            var facturaExiste = CheckIfDocExistsInT405(idFactura);

            if (facturaExiste == 0)
            {
                var resultado = AgregaRetencionesEnT0405(idCtaCte, numeroOP, baseGanancias, alicGanancias, alicIIBB,
                    conceptoGS.ToString());
                if (resultado == false)
                {
                    MessageBox.Show(
                        @"Ha ocurrido algun error en el agregado de la retencion a la tabla de retenciones",
                        @"Error en Agregado de Retencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdateImporteRetencionesOPFact_OPHeader(numeroOP);
                return true;
            }
            else
            {
                return false;
            }
        }


        //-----sin revisar-------- de aca para abajo


        private decimal CheckIfExistRetenciones(int idFactura)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0405_FACTURAS_RETENCIONES.Where(
                    c => c.IDFacturaProveedor == idFactura && c.RetIIBBARetener > 0).Sum(c => c.RetIIBBARetener);
            return (decimal)data;
        }

        /// <summary>
        /// Esta funcion es un fix temporal que coloca como base imponible el subtotal si la BI esta null.
        /// </summary>
        private static decimal CheckBaseImponibleFixSubtotal(T0403_VENDOR_FACT_H data)
        {
#pragma warning disable CS0472 // El resultado de la expresión siempre es 'false' porque un valor del tipo 'decimal' nunca es igual a 'NULL' de tipo 'decimal?'
            if (data.BaseImponible == null)
#pragma warning restore CS0472 // El resultado de la expresión siempre es 'false' porque un valor del tipo 'decimal' nunca es igual a 'NULL' de tipo 'decimal?'
            {
                new VendorDocuments(GlobalApp.CnnApp).FixBaseImponibleFacturasAPagar(data.IDINT,
                    Convert.ToDecimal(data.SUBTOTAL));
                return Convert.ToDecimal(data.SUBTOTAL);
            }
            else
            {
                return Convert.ToDecimal(data.BaseImponible);
            }
        }


        public T0405_FACTURAS_RETENCIONES GetSpecificRecordT0405(int numeroOP, int idFactura)
        {
            return
                new TecserData(GlobalApp.CnnApp).T0405_FACTURAS_RETENCIONES.SingleOrDefault(
                    c => c.IDFacturaProveedor == idFactura && c.NumeroOP == numeroOP);
        }

        public bool UpdateT0405_RetencionesDesdeOP(T0405_FACTURAS_RETENCIONES fr)
        {
            fr.Modificado = true;
            return new VendorDocuments(GlobalApp.CnnApp).UpdateDocumentoTablaRetenciones(fr);
        }

        /// <summary>
        /// Funcion que recalcula las retenciones desde T0405
        /// </summary>
        public decimal GetTotalRetencionesGSFromFacturaInOP(int numeroOP)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == numeroOP)
                    .Sum(c => c.RetGSARetener);
            return data == null ? 0 : Convert.ToDecimal(data);
        }

        /// <summary>
        ///  Funcion que recalcula las retenciones desde T0405
        /// </summary>
        public decimal GetTotalRetencionesIIBBFromFacturaInOP(int numeroOP)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == numeroOP)
                    .Sum(c => c.RetIIBBARetener);

            if (data == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(data);
            }
        }


        public bool CheckRetencionExisteParaOP(int numeroOP, int idfactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0405_FACTURAS_RETENCIONES.SingleOrDefault(
                        c => c.IDFacturaProveedor == idfactura && c.NumeroOP == numeroOP);

                return data != null;
            }
        }
    }
}








