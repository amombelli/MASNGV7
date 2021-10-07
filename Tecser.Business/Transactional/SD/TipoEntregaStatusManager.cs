using System;
using System.Collections.Generic;

namespace Tecser.Business.Transactional.SD
{
    public class TipoEntregaStatusManager
    {
        public enum TipoEntrega
        {
            SinAsignar,
            EntregaConCargo,
            EntregaSinCargo,
            RetiraCliente
        };
        public static TipoEntrega MapStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = TipoEntrega.SinAsignar.ToString();

            try
            {
                return (TipoEntrega)Enum.Parse(typeof(TipoEntrega), status, true);
            }
            catch (Exception)
            {
                return TipoEntrega.SinAsignar;
                throw;
            }
        }

        private readonly List<string> _statusList = new List<string>();
        public List<string> CompletaStatusList(bool[] ckstatus)

        {
            _statusList.Clear();
            for (var i = 0; i < ckstatus.Length; i++)
            {
                if (ckstatus[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            _statusList.Add(TipoEntrega.SinAsignar.ToString());
                            break;
                        case 2:
                            _statusList.Add(TipoEntrega.EntregaSinCargo.ToString());
                            _statusList.Add(TipoEntrega.EntregaConCargo.ToString());
                            break;
                        case 3:
                            _statusList.Add(TipoEntrega.RetiraCliente.ToString());
                            break;
                        default:
                            _statusList.Add("");
                            break;
                    }
                }

            }
            return _statusList;
        }

    }
}
