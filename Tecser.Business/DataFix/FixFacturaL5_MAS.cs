using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{

    public class StructuraFixRemitoL5
    {
        public int IdRemito { get; set; }
        public string RazonSocial { get; set; }
        public string LX { get; set; }
        public bool L5 { get; set; }
        public int Rlink { get; set; }
        public string LXRlink { get; set; }
    }


    public class FixFacturaL5MAS
    {
        public StructuraFixRemitoL5 GetCustomerFromRemitoId(int idRemitoInterno)
        {
            var data = new StructuraFixRemitoL5();
            data.IdRemito = idRemitoInterno;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var remitoH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemitoInterno);
                if (remitoH != null)
                {
                    data.RazonSocial = remitoH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                    data.LX = remitoH.TIPO_REMITO;
                    if (remitoH.RLINK != null)
                    {
                        data.Rlink = remitoH.RLINK.Value;
                        var remitoRlink = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == data.Rlink);
                        if (remitoRlink != null)
                            data.LXRlink = remitoRlink.TIPO_REMITO;
                    }
                }
                else
                {
                    data.RazonSocial = "REMITO NO CORRESPONDE A CLIENTE";
                    data.L5 = false;
                    data.LX = "L0";
                }

            }
            return data;
        }

        public bool FixDataL5(int idRemitoL1)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var remitoL1H = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemitoL1);
                if (remitoL1H == null)
                    return false;

                if (remitoL1H.TIPO_REMITO != "L1")
                    return false;

                if (remitoL1H.RLINK == null)
                    return false;

                var rLink = remitoL1H.RLINK;

                var remitoL2L5 = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == rLink.Value);
                if (remitoL2L5 == null)
                    return false;

                if (remitoL2L5.TIPO_REMITO != "L2")
                    return false;

                remitoL2L5.StatusRemito = RemitoStatusManager.StatusHeader.Preparado.ToString();

                var itemsL2 =
                    db.T0056_REMITO_I.Where(
                        c => c.IDREMITO == rLink.Value && c.RLINK == idRemitoL1).ToList();

                foreach (var item in itemsL2)
                {
                    var dataL1 =
                        db.T0056_REMITO_I.Where(
                            c =>
                                c.IDREMITO == item.RLINK.Value && c.STATUSITEM.ToUpper().Equals("DESPACHADO") &&
                                c.RLINK == rLink && c.MATERIAL == item.MATERIAL).ToList();
                    if (dataL1.Count > 0)
                    {
                        item.STATUSITEM = "Completo";
                        item.KGDESPACHADOS = dataL1[0].KGDESPACHADOS;
                        item.KGDESPACHADOS_R = dataL1[0].KGDESPACHADOS_R;
                        item.L5 = true;
                        item.BATCH = dataL1[0].BATCH;
                        item.BATCH_REMITO = dataL1[0].BATCH_REMITO;
                        item.GL = dataL1[0].GL;
                        item.GLV = dataL1[0].GLV;
                        item.GENERAR_REMITO = true;
                        item.DESC_REMITO = "Dif.Precio " +
                            new MaterialMasterManager().GetSpecificAkaInformation(item.MATERIALAKA).MAT_DESC2;
                        db.SaveChanges();
                    }
                }
                return true;
            }
        }






        public bool ValidaFixRemito(int idRemitoInterno)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
            return true;
        }

    }
}
