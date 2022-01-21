using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable.Modules
{
    public class AsientoOrdenPagoNew:AsientoVendorSpecific
    {
        private readonly int _numeroOP;
        private T0210_OrdenPagoHeader _headerOP;
        private List<T0211_OrdenPagoItems> _itemsOP;

        public AsientoOrdenPagoNew(int numeroOP, string tcode):base(tcode)
        {
            _numeroOP = numeroOP;
            LoadHeaderData();
            TipoDocumento = "OP";
            NumeroDocumento = _numeroOP.ToString(); //se puede pasar en formato.
        }

        protected sealed override void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _headerOP = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == _numeroOP);
                if (_headerOP == null)
                {
                    throw new InvalidOperationException("No Existe el registro en T0210*ORDENPAGO");
                }

                base.IdVendor = _headerOP.IdProveedor;
                base.RazonSocial = new VendorManager().GetSpecificVendor(IdVendor).prov_rsocial;
                _itemsOP = db.T0211_OrdenPagoItems.Where(c => c.IdOP == _numeroOP).ToList();
            }
        }
        
        public IdentificacionAsiento GeneraAsientoOP()
        {
            var descripcionHeader = "OP - " + RazonSocial;
            CreaHeaderMemoria(_headerOP.Lx,_headerOP.Fecha,_headerOP.TipoOPDoc,_numeroOP.ToString(),descripcionHeader,_headerOP.Moneda,_headerOP.ImporteOP,_headerOP.TC);
            AddSegmentoItemsPago();
            AddSegmentoRentecionesPago();
            GeneraSegmentoAP(TipoDocumento, NumeroDocumento, _headerOP.Lx, DebeHaber.Debe, _headerOP.Moneda,_headerOP.ImporteOP, "T0210_OrdenPagoHeader", _numeroOP);
            return GrabaAsiento();
        }

        private void AddSegmentoItemsPago()
        {
            var cuentaMng = new CuentasManager();
            string descripcion2=null;

            foreach (var i in _itemsOP)
            {
                var descripcion1 = "Egreso caja " + i.CuentaItem;
                if (i.EsCheque)
                {
                    if (i.ChIdCartera > 0)
                    {
                        descripcion2 = "Ch Cartera@" + i.ChIdCartera;
                    }
                    else
                    {
                        descripcion2 = "Cheque Propio P.Acreditacion";
                        i.GLCuenta = "1.0.0.50"; //GL Pendiente Acreditacion
                    }
                }
                AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _headerOP.Lx, i.GLCuenta, descripcion1, descripcion2, _headerOP.Moneda, DebeHaber.Haber, (decimal)i.ImporteOP, Tcode, 0, IdVendor, "T0211_OrdenPagoItems", i.IdItem);
            }
        }
        private void AddSegmentoRentecionesPago()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                GLAccountManagement.GLAccount tipoRetencion; //Solo para llevar la referencia para un futuro
                var retenciones = db.T0213_OrdenPagoRetenciones.Where(c => c.IdOP == _numeroOP).ToList();
                foreach (var ret in retenciones)
                {
                    var descripcion1 = String.Empty;
                    var descripcion2 = String.Empty;
                    
                    switch (ret.RetencionTipo)
                    {
                        case "RGA":
                            tipoRetencion = GLAccountManagement.GLAccount.RetencionGS;
                            descripcion1 = "Retencion Ganancias";
                            break;
                        case "RIB":
                            tipoRetencion = GLAccountManagement.GLAccount.RetencionIIBB;
                            descripcion1 = "Retencion IIBB";
                            break;
                        case "RIVA":
                            tipoRetencion = GLAccountManagement.GLAccount.RetencionIVA;
                            descripcion1 = "Retencion IVA";
                            break;
                    }

                    if (ret.Alicuota > 0)
                    {
                        descripcion1 = descripcion1 + @" Alic. " + ret.Alicuota.ToString("P4");
                        descripcion2 = "Base Imponible " + ret.BaseImponibleCalculo;
                    }
                    AddGenericCompleteSegment("RET", Header.REFE, Header.TIPO, ret.GL, descripcion1, descripcion2, "ARS",
                        DebeHaber.Haber, ret.ImporteRetencion, Tcode, 0, IdVendor, "T0213_OrdenPagoRetenciones", ret.IdItemRetencion);
                }
            }
        }
    }
}
