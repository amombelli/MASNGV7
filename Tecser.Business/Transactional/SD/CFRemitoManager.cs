using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.Transactional.SD
{
    public class CFRemitoManager
    {
        private readonly List<string> _statusList = new List<string>();  //Administra la lista de estados
        public List<RemitoHeaderStructureCF> GetDataSourceCentroFacturacion(bool[] ckstatus, int maxItems)
        {
            var h = new Repository<T000>(new TecserData(GlobalApp.CnnApp));
            CompletaStatusList(ckstatus);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaRemitos = from rh in db.T0055_REMITO_H
                                   where (_statusList.Contains(rh.StatusRemito.ToUpper()))
                                   orderby rh.IDREMITO descending
                                   select new RemitoHeaderStructureCF()
                                   {
                                       DescripcionEntrega = rh.T0007_CLI_ENTREGA.ClienteEntregaDesc,
                                       Facturado = !rh.FACTPEND,
                                       FechaRemito = rh.FECHA,
                                       FleteId = rh.IDFLETE,
                                       IdRemito = rh.IDREMITO,
                                       LX = rh.TIPO_REMITO,
                                       NumeroFactura = rh.NUMFACTURA,
                                       NumRemito = rh.NUMREMITO,
                                       RazonSocial = rh.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                       RemitoImpreso = rh.Impreso,
                                       StatusRemito = rh.StatusRemito,
                                       Rlink = rh.RLINK,
                                       L5 = rh.RLINK != null,
                                       idClienteT6 = rh.T0007_CLI_ENTREGA.T0006_MCLIENTES.IDCLIENTE,
                                   };
                return listaRemitos.Take(maxItems).ToList();
            }
        }
        private void CompletaStatusList(bool[] ckstatus)
        {
            _statusList.Clear();
            for (int i = 0; i < ckstatus.Length; i++)
            {
                if (ckstatus[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            _statusList.Add("INICIAL");
                            break;
                        case 2:
                            _statusList.Add("EN PREPARACION");
                            _statusList.Add("EN_PREPARACION");
                            break;
                        case 3:
                            _statusList.Add("Preparado");
                            break;
                        case 4:
                            _statusList.Add("GENERADO");
                            _statusList.Add("EN PROCESO");
                            break;
                        case 5:
                            _statusList.Add("IMPRESO");
                            break;
                        case 6:
                            _statusList.Add("STANDBY");
                            break;
                        default:
                            _statusList.Add("");
                            break;
                    }
                }
            }



        }
        public List<T0056_REMITO_I> GetDataSourceItem(int idRemitoItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemitoItem).ToList();
            }
        }
    }
}
