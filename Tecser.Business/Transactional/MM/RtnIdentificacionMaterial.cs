using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class RtnIdentificacionMaterial
    {
        private readonly int _idCliente;
        public bool SingleRemitoFound { get; private set; }
        public bool RemitoHeaderFound { get; private set; }
        private int _idRemito;
        public T0055_REMITO_H Header { get; private set; }
        public List<T0056_REMITO_I> ListRemitos { get; private set; }
        public bool SingleItemFound { get; private set; }
        public bool ItemFound { get; private set; }
        private int _idItem;
        public bool CantidadOk { get; private set; }
        public string LoteFound { get; private set; }

        public RtnIdentificacionMaterial(int idCliente)
        {
            _idCliente = idCliente;
        }


        /// <summary>
        /// Obtiene data de si un remito determinado # para un cliente existe
        /// </summary>
        public void SetRemito(string numeroRemito)
        {
            RemitoHeaderFound = false;
            SingleRemitoFound = false;
            Header = null;
            _idRemito = -1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0055_REMITO_H.Where(c => c.NUMREMITO == numeroRemito && c.T0007_CLI_ENTREGA.IDCLIENTE == _idCliente).ToList();
                if (!r.Any()) return;

                if (r.Count == 1)
                {
                    RemitoHeaderFound = true;
                    SingleRemitoFound = true;
                    _idRemito = r[0].IDREMITO;
                    Header = r[0];
                }
                else
                {
                    RemitoHeaderFound = true;
                    SingleRemitoFound = false;
                    _idRemito = -1;
                    Header = null;
                }
            }
        }

        public void SetMaterialRecibido(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                //SingleRemitoFound = false;
                ItemFound = false;
                _idItem = -1;
                if (!SingleRemitoFound) return;

                ListRemitos = db.T0056_REMITO_I.Where(c =>
                    c.IDREMITO == Header.IDREMITO && c.MATERIALAKA.ToUpper().Equals(material.ToUpper())).ToList();

                if (!ListRemitos.Any()) return;

                if (ListRemitos.Count == 1)
                {
                    ItemFound = true;
                    SingleRemitoFound = true;
                    _idItem = ListRemitos[0].IDITEM;
                    LoteFound = ListRemitos[0].BATCH;
                }
                else
                {
                    ItemFound = true;
                    SingleRemitoFound = false;
                    _idItem = -1;
                    LoteFound = null;
                }
            }
        }

        public void SetCantidad(decimal cantidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                CantidadOk = false;
                if (!ListRemitos.Any())
                    return;
                decimal kgDespachados = ListRemitos.Sum(c => c.KGDESPACHADOS_R);
                if (cantidad <= kgDespachados) CantidadOk = true;
            }
        }














    }
}
