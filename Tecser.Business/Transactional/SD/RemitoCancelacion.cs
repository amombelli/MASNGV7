using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoCancelacion
    {
        public RemitoCancelacion(int idRemito)
        {
            _idRemito = idRemito;
        }
        private readonly int _idRemito;
        private RemitoStatusManager.StatusHeader _statusHeader;


        /// <summary>
        /// Funcion muy similar a la anterior pero hay que revisar el tema
        /// del Reingreso // aca se hace desde la NC - por RTN automatico
        /// </summary>
        public bool CancelaRemito_OV_DesdeNC()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);
                //Remito L2 de un L5 no se cancela - Se hace desde la parte L1
                if (h.TIPO_REMITO == "L2" && h.RLINK > 0)
                    return false;
                _statusHeader = new RemitoStatusManager().MapStatusHeaderFromText(h.StatusRemito);

                if (_statusHeader == RemitoStatusManager.StatusHeader.Generado ||
                    _statusHeader == RemitoStatusManager.StatusHeader.Impreso)
                {
                    //solo estas opciones son validas
                }
                else
                {
                    return false;
                }

                var lsI = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito).ToList();
                foreach (var i in lsI)
                {
                    i.STATUSITEM = RemitoStatusManager.StatusItem.Cancelado.ToString();
                    var ovItem = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == i.IDOV && c.IDITEM == i.IDOVITEM);
                    if (ovItem.Material != i.MATERIAL)
                    {
                        MessageBox.Show(@"Error en Material de OV# - Revisar Status OV");
                    }
                    else
                    {
                        ovItem.KGStockDespachados -= i.KGDESPACHADOS_R;
                        ovItem.StatusItem = ovItem.KGStockDespachados == 0
                            ? SalesOrderStatusManager.StatusItem.Pendiente.ToString()
                            : SalesOrderStatusManager.StatusItem.Parcial.ToString();
                    }
                    db.SaveChanges();
                    SalesOrderStatusManager.UpdateStatusItem(i.IDOV.Value, i.IDOVITEM.Value);
                    SalesOrderStatusManager.UpdateStatusHeaderFromStatusItem(i.IDOV.Value);
                }
                h.StatusRemito = RemitoStatusManager.StatusHeader.Cancelado.ToString();
                db.SaveChanges();
                return true;
            }
        }
        public bool CancelacionCompletaRemito()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);


                //Remito L2 de un L5 no se cancela - Se hace desde la parte L1
                if (h.TIPO_REMITO == "L2" && h.RLINK > 0)
                    return false;

                _statusHeader = new RemitoStatusManager().MapStatusHeaderFromText(h.StatusRemito);

                if (_statusHeader == RemitoStatusManager.StatusHeader.Generado ||
                    _statusHeader == RemitoStatusManager.StatusHeader.Impreso)
                {

                }
                else
                {
                    //El Estado del Remito no permite cancelacion
                    return false;
                }


                //Regresa Materiales al stock >
                var lsI = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemito).ToList();
                foreach (var i in lsI)
                {
                    if (string.IsNullOrEmpty(i.SLOC))
                    {
                        i.SLOC = "STBY";
                    }
                    new StockABM().AltaNewStockLine(i.MATERIAL, i.BATCH, i.KGDESPACHADOS,
                        StockStatusManager.EstadoLote.Liberado, i.SLOC, "CANR", false);
                    new MmLog().LogMMCancelacionRemito(i.IDREMITO, i.IDITEM);

                    i.STATUSITEM = RemitoStatusManager.StatusItem.Cancelado.ToString();

                    var ovItem = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == i.IDOV && c.IDITEM == i.IDOVITEM);
                    if (ovItem.Material != i.MATERIAL)
                        MessageBox.Show(@"DD");

                    ovItem.KGStockDespachados -= i.KGDESPACHADOS_R;
                }
                h.StatusRemito = RemitoStatusManager.StatusHeader.Cancelado.ToString();
                db.SaveChanges();
                return true;
            }
        }
    }
}
