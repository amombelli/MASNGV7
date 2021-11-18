using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class RtnMaterialSimpleValidation
    {
        private readonly int _idCliente;
        public bool MaterialOk { get; private set; }
        public string MaterialCode { get; private set; }
        public bool LoteOk { get; private set; }
        public string LoteCode { get; private set; }
        public RtnMaterialSimpleValidation(int idCliente)
        {
            _idCliente = idCliente;
        }

        public void SetMaterialRecibidoCliente(string material)
        {
            MaterialOk = false;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0056_REMITO_I.Where(c =>
                    c.MATERIALAKA.ToUpper().Equals(material.ToUpper()) &&
                    c.T0055_REMITO_H.T0007_CLI_ENTREGA.IDCLIENTE == _idCliente).ToList();
                if (x.Any())
                {
                    MaterialOk = true;
                    MaterialCode = material;
                }
                else
                {
                    MaterialCode = null;
                }
            }
        }
        public void SetLoteValidar(string numeroLote, string material)
        {
            if (MaterialCode == null)
            {
                SetMaterialRecibidoCliente(material);
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0056_REMITO_I.Where(c =>
                        c.MATERIALAKA.ToUpper().Equals(material.ToUpper()) &&
                        c.T0055_REMITO_H.T0007_CLI_ENTREGA.IDCLIENTE == _idCliente &&
                        c.BATCH.ToUpper().Equals(numeroLote))
                    .ToList();
                if (x.Any())
                {
                    LoteCode = numeroLote;
                    LoteOk = true;
                }
                else
                {
                    LoteCode = null;
                    LoteOk = false;
                }
            }
        }
        public void SetCantidad(decimal cantidad)
        {

        }

    }
}
