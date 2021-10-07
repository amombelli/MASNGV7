using Tecser.Business.MasterData;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public abstract class AsCustomerL1 : AsientoBase
    {
        protected AsCustomerL1(string tcode) : base(tcode)
        {

        }

        //protected abstract void LoadHeaderData();
        protected int IdCliente;
        protected string RazonSocial;
        
        /// <summary>
        /// Funcion Standard de Asientos de Impuestos
        /// FA-ND = Haber ---  NC = Debe
        /// </summary>
        protected void SegmentoTaxT400(DebeHaber DH, decimal importeIva21, decimal importeIIBB, decimal alicuotaIIBB, decimal importeTax2, decimal alicuotaTax2,
            decimal baseImponible, string tablaRef = null, int? idRef = null, string glTax2="0.0.0.0")
        {
            //IVA21 [Facturacion default = Haber]
            string textoIVA = DH == DebeHaber.Haber ? "IVA Debito Fiscal 21%" : "IVA Credito Fiscal 21%";
            string textoIIBB = DH == DebeHaber.Haber ? "IIBB Provincia Bs.As" : "Anulacion IIBB Prov. BS.As";
            string textoTAX2 = DH == DebeHaber.Haber ? "TAX Debito Fiscal" : "TAX Credito Fiscal";
            

            if (importeIva21!=0)
                AddGenericCompleteSegmentNew(importeIva21, textoIVA, "Alic 21% - Base Imponible =" + baseImponible, DH,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaVenta21), IdCliente, nombreTablaReferencia: tablaRef, numeroIdReferencia: idRef);

            if (importeIIBB !=0)
                AddGenericCompleteSegmentNew(importeIIBB, textoIIBB, "Alic " + alicuotaIIBB.ToString("P2") + " - Base Imponible =" + baseImponible, DH,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.PercepcionIIBB), IdCliente,
                nombreTablaReferencia: tablaRef, numeroIdReferencia: idRef);

            if (importeTax2 != 0)
                AddGenericCompleteSegmentNew(importeTax2, textoTAX2, "Alic " + alicuotaTax2.ToString("P2") + " - Base Imponible =" + baseImponible, DH,
                    glTax2, IdCliente, nombreTablaReferencia: tablaRef, numeroIdReferencia: idRef);

        }

        /// <summary>
        /// FA-ND [Debe] -- NC [Haber]
        /// </summary>
        protected void SegmentoAR(DebeHaber DH,decimal importeTotal, string texto1=null, string texto2=null,string glar=null,string tablaRef=null, int?idRef=null)
        {
            if (glar == null || glar =="0.0.0.0") glar = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);

            if (texto1 == null)
            {
                texto1 = "A/R " + RazonSocial;
            }
            if (texto2 == null) texto2 = @"/";
            AddGenericCompleteSegmentNew(importeTotal, texto1, texto2, DH,glar,IdCliente, nombreTablaReferencia: tablaRef, numeroIdReferencia: idRef);
        }

        /// <summary>
        /// FA-ND un descuento que baja importe final va al [Debe]
        /// </summary>
        protected void SegmentoDescuentos(DebeHaber DH, decimal importeDescuento, decimal importePorcentaje, string tablaRef = null, int? idRef = null)
        {
            AddGenericCompleteSegmentNew(importeDescuento, "Descuento en Ventas " + RazonSocial,
                "Porcentaje Dto:" + importePorcentaje.ToString("P2"), DH,
                GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.DescuentoVentas), IdCliente,
                nombreTablaReferencia: tablaRef, numeroIdReferencia: idRef);
        }
        protected void GeneraSegmentoAR(string tipoDocumento, string numeroDocumento, string tipoLx, DebeHaber DH, string moneda, decimal importe, string tableName, int idTableName)
        {
            var GLAR = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
            var descripcion1 = "A/R" + RazonSocial;
            string descripcion2;

            switch (tipoDocumento)
            {
                case "CO":
                    descripcion2 = "Cobranza " + RazonSocial;
                    break;
                case "FA":
                    descripcion2 = "Factura " + RazonSocial;
                    break;
                case "NC":
                    descripcion2 = "Nota Credito " + RazonSocial;
                    break;
                case "ND":
                    descripcion2 = "Nota Debito " + RazonSocial;
                    break;
                default:
                    descripcion2 = "???????? " + RazonSocial;
                    break;
            }

            AddGenericCompleteSegment(tipoDocumento, numeroDocumento, tipoLx, GLAR, descripcion1, descripcion2, moneda,
                DH, importe, Tcode, IdCliente, 0, tableName, idTableName);
        }
    }
}
