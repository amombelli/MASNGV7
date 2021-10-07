using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class ContaClienteNotaCreditoL2:ContaClienteT400L1
    {
        public ContaClienteNotaCreditoL2(int idFactura, int idCliente, string tDocXX = "NC") : base(idCliente, idFactura)
        {
            Signo = -1;
            TipoDocumentoXX = tDocXX;
            _idNcd = T4H.IdNCD ?? 0;
        }
        private readonly int _idNcd;
        
        /// <summary>
        /// Anulacion completa de Nota de Debito o Factura //El Asiento es Copiando Invertido el link
        /// </summary>
        public void ContabilizacionAnulaDocumentoCompleto()
        {
            AddData201(_idNcd);
            UpdateData202();
            AddData208();
            //AddData207AltaDocumentoNuevo(10); //dias de vencimiento
            var as1 = new AsCustomerL2T400(IdFactura, "NCDX");
            var z = as1.AsNdAnunlaNcCompleta();
            RtnAsiento.IdDocu = z.IdDocu;
            RtnAsiento.Nasx1 = z.Nasx1;
            RtnAsiento.Nasx2 = z.Nasx2;
            new GestionT300(_idNcd).UpdateDatosAfterConta();
        }

        /// <summary>
        /// Normal - El asiento lo hace desde los Items de T400
        /// </summary>
        public void ContabilizaCompletoHeaderND()
        {
            AddData201(_idNcd);
            UpdateData202();
            AddData208();
            //AddData207AltaDocumentoNuevo(10); //dias de vencimiento
            var as1 = new AsCustomerL2T400(IdFactura, "NCDX");
            var z = as1.AsNotaDebitoCreditoFromT400("Emision NC");
            RtnAsiento.IdDocu = z.IdDocu;
            RtnAsiento.Nasx1 = z.Nasx1;
            RtnAsiento.Nasx2 = z.Nasx2;
            new GestionT300(_idNcd).UpdateDatosAfterConta();
        }


        /// <summary>
        /// Alta de NC como credito en T0208
        /// </summary>
        public override int AddData208()
        {
            return CtaCteMng.AddSinImputarRecord(FechaConta, _idNcd, MonedaConta, Math.Abs(T4H.TotalFacturaN), LX.ToString(),
                "NCD", NumeroDocumento, IdCtaCte, _idNcd);
            
        }
    }
}
