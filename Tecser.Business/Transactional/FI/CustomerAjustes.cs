using System;

namespace Tecser.Business.Transactional.FI
{
    public class CustomerAjustes : CustomerDoc
    {
        private MotivoAjustes _motivoDocumento;

        public CustomerAjustes(MotivoAjustes xmotivo)
        {
            _motivoDocumento = xmotivo;
            MotivoDocumentoString = xmotivo.ToString();
        }

        public enum MotivoAjustes
        {
            SinMotivo,
            TraspasoCliente,
            TraspasoTipo,
            RedondeoCuenta,
            PerdidaIncobrable,
            PerdidaGestion,
            CobranzaFicticia
        }

        public MotivoAjustes MapMotivoFromTextoToType(string motivo)
        {
            if (String.IsNullOrEmpty(motivo))
                return MotivoAjustes.SinMotivo;
            try
            {
                return (MotivoAjustes)Enum.Parse(typeof(MotivoAjustes), motivo, true);
            }
            catch (Exception)
            {
                return MotivoAjustes.SinMotivo;
                throw;
            }
        }

    }
}
