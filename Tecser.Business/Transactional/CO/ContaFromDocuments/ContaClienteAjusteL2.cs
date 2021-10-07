using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class ContaClienteAjusteL2:ContaClienteT400L1
    {
        public ContaClienteAjusteL2(int idFactura, int idCliente,string tDocXx="AJ"):base(idCliente,idFactura)
        {
            if (T4H.TotalFacturaB < 0)
            {
                Signo = -1;
            }
            else
            {
                Signo = 1;
            }

            TipoDocumentoXX = tDocXx;
            _idNcd = T4H.IdNCD ?? 0;
        }

        private readonly int _idNcd;

        /// <summary>
        /// Normal - El asiento lo hace desde los Items de T400
        /// </summary>
        public void ContabilizaCompletaAjusteRedondeo()
        {
            AddData201(_idNcd);
            UpdateData202();
            if (Signo == 1)
            {
                AddData207AltaDocumentoNuevo(10); //dias de vencimiento
            }
            else
            {
                AddData208();
            }
            var as1 = new AsCustomerL2T400(IdFactura, "NCDX");
            var z = as1.AsAjusteCuentaCorriente();
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
