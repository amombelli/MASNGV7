using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    /// <summary>
    /// 2018.03.29
    /// UPD: 2019.12.11
    /// 
    /// Manejo de todos los tipos de documentos de la aplicacion ya sea vendor/customer/Otros
    /// se mapea con su correspondiente tabla T0605...  Caducar >>>T0603_DOCUTYPES
    /// </summary>
    public class ManageDocumentType
    {
        public enum TipoDocumento
        {
            FacturaVentaA,
            NotaDebitoVentaA,
            NotaCreditoVentaA,
            ReciboCobranza,
            Remito,
            OrdenPago,
            OrdenCompra,
            NoDefinido,
            FacturaVenta2,
            NotaDebitoVenta2,
            NotaCreditoVenta2,
            TransferenciaEC,
            Cobranza,
            FacturaGastosConRemito,
            FacturaGastosSinRemito,
            NotaDebitoProveedorA,
            NotaCreditoProveedorA,
            NotaDebitoProveedor2,
            NotaCreditoProveedor2,
            AjusteSaldoPositivo,
            AjusteSaldoNegativo,
            FacturaVentaB,
            FacturaVentaM,
            NotaCreditoClientesB,
            NotaCreditoClientesM,
            NotaDebitoClientesB,
            NotaDebitoClientesM,
            AjusteContable,
            //DocumentoInternoX1,
            //DocumentoInternoX2,
            //DocumentoNoFiscalCliente,
            DebitoNoFiscalCli,
            CreditoNoFiscalCli,
        };
        public TipoDocumento MapTipoDocumentFromText(string tipoDocumento)
        {
            if (String.IsNullOrEmpty(tipoDocumento))
                return TipoDocumento.NoDefinido;

            //Mapeo to fix errores
            if (tipoDocumento.ToUpper().Equals("@@") || tipoDocumento.ToUpper().Equals("@@@"))
                return TipoDocumento.NoDefinido;
            try
            {
                return (TipoDocumento)Enum.Parse(typeof(TipoDocumento), tipoDocumento, true);
            }
            catch (Exception)
            {
                return TipoDocumento.NoDefinido;
                throw;
            }
        }
        public string GetDocumentDescription(TipoDocumento documentype)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string tipodocumento = documentype.ToString();
                var data = db.T0605_DOCUCONFIG.SingleOrDefault(c => c.DESCRIPCION_ENUM == tipodocumento);
                if (data == null)
                    return "No Encontrado";
                return data.DESCRIPTION;
            }
        }

        public static TipoDocumento GetTipoDocumentoFromTdocString(string tdoc, string tipoLx)
        {
            switch (tdoc)
            {
                case "FA":
                    return TipoDocumento.FacturaVentaA;
                case "FM":
                    return TipoDocumento.FacturaVentaM;
                case "FB":
                    return TipoDocumento.FacturaVentaB;
                case "NC":
                    return tipoLx == "L1" ? TipoDocumento.NotaCreditoVentaA : TipoDocumento.NotaCreditoVenta2;
                case "CM":
                    return TipoDocumento.NotaCreditoClientesM;
                case "CB":
                    return TipoDocumento.NotaCreditoClientesB;
                case "ND":
                    return tipoLx == "L1" ? TipoDocumento.NotaDebitoVentaA : TipoDocumento.NotaDebitoVenta2;
                case "DB":
                    return TipoDocumento.NotaDebitoClientesB;
                case "DM":
                    return TipoDocumento.NotaCreditoClientesM;
                case "AJ":
                    return TipoDocumento.AjusteContable;
                //case "X1":
                //    return TipoDocumento.DocumentoInternoX1;
                //case "X2":
                //    return TipoDocumento.DocumentoInternoX2;
                //case "AX":
                //    return TipoDocumento.DocumentoNoFiscalCliente;
                case "DX":
                    return TipoDocumento.DebitoNoFiscalCli;
                case "CX":
                    return TipoDocumento.CreditoNoFiscalCli;
                default:
                    return TipoDocumento.NoDefinido;
            }
        }


        public static string GetDocumentDescriptionHardCode(TipoDocumento docu)
        {
            switch (docu)
            {
                case TipoDocumento.Cobranza:
                    return "No Definido";
                case TipoDocumento.FacturaVenta2:
                    return "Presupuesto X";
                case TipoDocumento.FacturaVentaA:
                    return "Factura de Venta A";
                case TipoDocumento.NotaDebitoVentaA:
                    return "Nota de Debito A";
                case TipoDocumento.NotaCreditoVentaA:
                    return "Nota de Credito A";
                case TipoDocumento.ReciboCobranza:
                    break;
                case TipoDocumento.Remito:
                    break;
                case TipoDocumento.OrdenPago:
                    break;
                case TipoDocumento.OrdenCompra:
                    break;
                case TipoDocumento.NoDefinido:
                    break;
                case TipoDocumento.NotaDebitoVenta2:
                    return "Nota de Debito X";
                case TipoDocumento.NotaCreditoVenta2:
                    return "Nota de Credito X";
                case TipoDocumento.TransferenciaEC:
                    break;
                case TipoDocumento.FacturaGastosConRemito:
                    break;
                case TipoDocumento.FacturaGastosSinRemito:
                    break;
                case TipoDocumento.NotaDebitoProveedorA:
                    return "Nota de Debito 'A'";
                case TipoDocumento.NotaCreditoProveedorA:
                    return "Nota de Credito 'A'";
                case TipoDocumento.NotaDebitoProveedor2:
                    return "Nota de Debito 'L2'";
                case TipoDocumento.NotaCreditoProveedor2:
                    return "Nota de Credito 'L2'";
                case TipoDocumento.AjusteSaldoPositivo:
                    return "Ajuste a Proveedores [+]";
                case TipoDocumento.AjusteSaldoNegativo:
                    return "Ajuste a Priveedores [-]";
                case TipoDocumento.FacturaVentaB:
                    return "Factua de Venta B";
                case TipoDocumento.FacturaVentaM:
                    return "Factura de Venta M";
                case TipoDocumento.NotaCreditoClientesB:
                    return "Nota de Credito B";
                case TipoDocumento.NotaCreditoClientesM:
                    return "Nota de Credito M";
                case TipoDocumento.NotaDebitoClientesB:
                    return "Nota de Debito B";
                case TipoDocumento.NotaDebitoClientesM:
                    return "Nota de Debito M";
                case TipoDocumento.AjusteContable:
                    return "Ajuste de Saldos Contable";
                //case TipoDocumento.DocumentoInternoX1:
                //    return "Documento No Fiscal";
                //case TipoDocumento.DocumentoInternoX2:
                //    return "Documento No Fiscal";
                //case TipoDocumento.DocumentoNoFiscalCliente:
                //    return "Documento No Fiscal X"; //NC/ND Cliente
                case TipoDocumento.DebitoNoFiscalCli:
                    return "Debito No Fiscal";
                case TipoDocumento.CreditoNoFiscalCli:
                    return "Credito No Fiscal";
                default:
                    throw new ArgumentOutOfRangeException(nameof(docu), docu, null);
            }
            return "??";
        }


        public static string GetSystemDocumentType(TipoDocumento docu)
        {
            switch (docu)
            {
                case TipoDocumento.Cobranza:
                    return "CO";
                case TipoDocumento.FacturaVenta2:
                    return "FA";
                case TipoDocumento.FacturaVentaA:
                    return "FA";
                case TipoDocumento.NotaDebitoVentaA:
                    return "ND";
                case TipoDocumento.NotaCreditoVentaA:
                    return "NC";
                case TipoDocumento.ReciboCobranza:
                    break;
                case TipoDocumento.Remito:
                    break;
                case TipoDocumento.OrdenPago:
                    break;
                case TipoDocumento.OrdenCompra:
                    break;
                case TipoDocumento.NoDefinido:
                    break;
                case TipoDocumento.NotaDebitoVenta2:
                    return "ND";
                case TipoDocumento.NotaCreditoVenta2:
                    return "NC";
                case TipoDocumento.TransferenciaEC:
                    break;
                case TipoDocumento.FacturaGastosConRemito:
                    break;
                case TipoDocumento.FacturaGastosSinRemito:
                    break;
                case TipoDocumento.NotaDebitoProveedorA:
                    return "NDA";
                case TipoDocumento.NotaCreditoProveedorA:
                    return "NCA";
                case TipoDocumento.NotaDebitoProveedor2:
                    return "ND2";
                case TipoDocumento.NotaCreditoProveedor2:
                    return "NC2";
                case TipoDocumento.AjusteSaldoPositivo:
                    return "AJ";
                case TipoDocumento.AjusteSaldoNegativo:
                    return "AJ";
                case TipoDocumento.FacturaVentaB:
                    return "FB";
                case TipoDocumento.FacturaVentaM:
                    return "FM";
                case TipoDocumento.NotaCreditoClientesB:
                    return "CB";
                case TipoDocumento.NotaCreditoClientesM:
                    return "CM";
                case TipoDocumento.NotaDebitoClientesB:
                    return "DB";
                case TipoDocumento.NotaDebitoClientesM:
                    return "DM";
                case TipoDocumento.AjusteContable:
                    return "AJ";
                case TipoDocumento.DebitoNoFiscalCli:
                    return "DX";
                case TipoDocumento.CreditoNoFiscalCli:
                    return "CX";
                default:
                    throw new ArgumentOutOfRangeException(nameof(docu), docu, null);
            }
            return "??";
        }
    }
}

