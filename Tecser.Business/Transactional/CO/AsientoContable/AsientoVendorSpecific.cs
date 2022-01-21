namespace Tecser.Business.Transactional.CO.AsientoContable
{
    /// <summary>
    /// 2018.03.11 Funciones especificas para asientos de Vendors/Proveedores
    /// Se inicia siempre creando el Header, luego se agregan los segmentos y luego se graba el asiento
    /// </summary>
    public abstract class AsientoVendorSpecific : AsientoBase
    {
        protected AsientoVendorSpecific(string tcode) : base(tcode)
        {
        }

        protected int IdVendor;
        protected string RazonSocial;
        protected abstract void LoadHeaderData();

        protected void GeneraSegmentoAP(string tipoDocumento, string numeroDocumento, string tipoLx, DebeHaber DH,
            string moneda, decimal importe, string tableName, int idTableName)
        {
            var GLAP = new GLAccountManagement().GetApVendorGl(IdVendor);
            var descripcion1 = "A/P" + RazonSocial;
            string descripcion2;
            switch (tipoDocumento)
            {
                case "OP":
                    descripcion2 = "Orden Pago " + RazonSocial;
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
            AddGenericCompleteSegment(tipoDocumento, numeroDocumento, tipoLx, GLAP, descripcion1, descripcion2, moneda,
                DH, importe, Tcode, 0, IdVendor, tableName, idTableName);
        }

        protected void AddSegmentoRetencionesAProveedores(GLAccountManagement.GLAccount tipoImpuesto,
            decimal importeImpuesto, string moneda = "ARS", decimal? alicuota = 0, string distrito = null,
            string nombreTablaReferencia = "_T0210_OP_H", int idTablaReferencia = 0)
        {
            var glAccount = GLAccountManagement.GetGLAccount(tipoImpuesto);
            var glAccountDescription = GLAccountManagement.GetGLDescriptionFromT135(glAccount);

            string descripcion1;
            string descripcion2 = null;

            if (alicuota > 0)
            {
                descripcion1 = glAccountDescription + "Alic: " + alicuota;
            }
            else
            {
                descripcion1 = glAccountDescription;
            }

            if (string.IsNullOrEmpty(distrito) == false)
            {
                descripcion2 = "(Alic: " + alicuota + ")" + distrito;
            }

            AddGenericCompleteSegment("IMP", Header.REFE, Header.TIPO, glAccount, descripcion1, descripcion2, moneda,
                DebeHaber.Haber, importeImpuesto, Tcode, 0, IdVendor, nombreTablaReferencia, idTablaReferencia);
        }

        protected void AddSegmentoImpuestosFromVendorInvoice(GLAccountManagement.GLAccount tipoImpuesto, int idVendor,
            decimal importeImpuesto, string moneda = "ARS", decimal? alicuota = 0, string distrito = null,
            string nombreTablaReferencia = "T0403_VENDOR_FACT_H", int idTablaReferencia = 0)
        {
            var glAccount = GLAccountManagement.GetGLAccount(tipoImpuesto);
            var glAccountDescription = GLAccountManagement.GetGLDescriptionFromT135(glAccount);

            string descripcion1;
            string descripcion2 = null;

            if (alicuota > 0)
            {
                descripcion1 = glAccountDescription + "Alic: " + alicuota;
            }
            else
            {
                descripcion1 = glAccountDescription;
            }

            if (string.IsNullOrEmpty(distrito) == false)
            {
                descripcion2 = "(Alic: " + alicuota + ")" + distrito;
            }

            AddGenericCompleteSegment("IMP", Header.REFE, Header.TIPO, glAccount, descripcion1, descripcion2, moneda,
                DebeHaber.Debe, importeImpuesto, Tcode, 0, idVendor, nombreTablaReferencia,
                idNumerico: idTablaReferencia);
        }
    }
}
