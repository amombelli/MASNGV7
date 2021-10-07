using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class ContaClienteNotaDebitoL2:ContaClienteT400L1
    {
        public ContaClienteNotaDebitoL2(int idFactura, int idCliente, string tDocXx="ND") : base(idCliente, idFactura)
        {
            Signo = 1;
            TipoDocumentoXX = tDocXx;
            _idNcd = T4H.IdNCD ?? 0;
        }
        private readonly int _idNcd;


        /// <summary>
        /// Anulacion completa de Nota de Credito //El Asiento es Copiando Invertido el link
        /// </summary>
        public void ContabilizacionAnulaDocumentoCompleto()
        {
            AddData201(_idNcd);
            UpdateData202();
            AddData207AltaDocumentoNuevo(10); //dias de vencimiento
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
            AddData207AltaDocumentoNuevo(10); //dias de vencimiento
            var as1 = new AsCustomerL2T400(IdFactura, "NCDX");
            var z =as1.AsNotaDebitoCreditoFromT400("Emision ND");
            RtnAsiento.IdDocu = z.IdDocu;
            RtnAsiento.Nasx1 = z.Nasx1;
            RtnAsiento.Nasx2 = z.Nasx2;
            new GestionT300(_idNcd).UpdateDatosAfterConta();
        }

    }
}
