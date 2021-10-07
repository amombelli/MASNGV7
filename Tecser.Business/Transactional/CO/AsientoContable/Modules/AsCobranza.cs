using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable.Modules
{
    public class AsCobranza : AsCustomerL1
    {
        public AsCobranza(int idCob, string transactionCode) : base(transactionCode)
        {
            _idCob = idCob;
            LoadHeaderData();
            TipoDocumento = GetSystemDocumentType(ManageDocumentType.TipoDocumento.Cobranza);
            _numeroRecibo = _h.NRECIBO;
        }

        private readonly int _idCob;
        private T0205_COBRANZA_H _h;
        private readonly string _numeroRecibo;

        protected  void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == _idCob);
                if (_h == null)
                    throw new InvalidOperationException("No Existe el registro en T0205*COBRANZAS");

                base.IdCliente = _h.IdCliente.Value;
                base.RazonSocial = new CustomerManager().GetCustomerBillToData(IdCliente).cli_rsocial;
            }
        }

        public IdentificacionAsiento GeneraAsientoFromRecibo()
        {
            string descripcion1 = "Recibo Cobranza - " + RazonSocial;
#pragma warning disable CS0219 // The variable 'descripcion2' is assigned but its value is never used
            string descripcion2 = null;
#pragma warning restore CS0219 // The variable 'descripcion2' is assigned but its value is never used
            base.CreaHeaderMemoria(_h.CUENTA, _h.FECHA, TipoDocumento, _numeroRecibo, descripcion1, _h.MON,
                _h.Monto, _h.TC);

            base.GeneraSegmentoAR(TipoDocumento, _numeroRecibo, _h.CUENTA, DebeHaber.Haber, _h.MON, _h.Monto,
                "T0205_COBRANZA_H", _idCob);

            GeneraAsientoCajaItems();
            return GrabaAsiento();
        }

        private void GeneraAsientoCajaItems()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0206_COBRANZA_I.Where(c => c.IDCOB == _idCob).ToList();
                foreach (var i in items)
                {
                    var glItem = new CuentasManager().GetGL(i.CUENTA);
                    var glDesc = GLAccountManagement.GetGLDescriptionFromT135(glItem);
                    var descripcion1 = "Caja > " + glDesc;
                    string descripcion2 = null;
                    switch (i.CUENTA)
                    {
                        case "CHE":
                            descripcion2 = "chequeId@ " + i.IDCH;
                            break;
                        default:
                            descripcion2 = null;
                            break;
                    }

                    AddGenericCompleteSegment(TipoDocumento, _numeroRecibo, _h.CUENTA, glItem, descripcion1,
                        descripcion2, _h.MON, DebeHaber.Debe, i.IMP_RECIBO, Tcode, IdCliente, 0,
                        "T0206_COBRANZA_I", i.LINE);
                }
            }
        }
    }
}
