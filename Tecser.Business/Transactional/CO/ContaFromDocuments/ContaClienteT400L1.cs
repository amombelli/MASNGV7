using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public abstract class ContaClienteT400L1:ContaClienteBase
    {

        protected readonly int IdFactura;
        protected T0400_FACTURA_H T4H;
        
        protected ContaClienteT400L1(int idCliente, int idFactura) : base(idCliente)
        {
            IdFactura = idFactura;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                T4H = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                LX = T4H.TIPOFACT == "L1" ? AsientoNumeracion.TipoLx.L1 : AsientoNumeracion.TipoLx.L2;
                FechaConta = this.T4H.FECHA;
                NumeroDocumento = T4H.NumeroDoc;
                MonedaConta = T4H.FacturaMoneda;

            }
        }
        protected int AddData207AltaDocumentoNuevo(int diasVencimiento = 30)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = new T0207_SPLITFACTURAS()
                {
                    INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1,
                    TDOC = TipoDocumentoXX,
                    IDCTACTE = IdCtaCte,
                    IDDOC = IdFactura,
                    NDOC = NumeroDocumento,
                    FACTSPLIT = 1,
                    FACT_MONEDA = MonedaConta,
                    ImporteDocumento = T4H.TotalFacturaN,
                    ImporteAImputar = T4H.TotalFacturaN,
                    MontoImputado = 0,
                    TIPO = LX.ToString(),
                    CLIENTE = _idCliente,
                    FECHA_FACT = FechaConta,
                    ZTERM = diasVencimiento,
                    FECHA_VENC = FechaConta.AddDays(diasVencimiento),
                    DIAS_VENC = 0,
                    NRECIBO = null,
                    PFECHA = null,
                    XCOMENTARIO = null,
                    IDCOB = null,
                    IDNC = null,
                    NumeroDoc = null,
                    TipoDocCancel = null,
                    DiasPPCob = null,
                    DiasImpu = null,
                    USDImpu = 0,
                };
                db.T0207_SPLITFACTURAS.Add(h);
                if (db.SaveChanges() > 0)
                    return (int)h.INTDOC;
                return 0;
            }
        }


        /// <summary>
        /// Utilizara idT2 para enviar IDH en NC/ND
        /// </summary>
        protected void AddData201(int idT2)
        {
            base.AddData201(T4H.TotalFacturaN, IdFactura.ToString(), IdFactura, idT2, true);
        }
        protected void UpdateData202(DateTime? fechaUltimaFacturaEmitida=null)
        {
            base.AddData202(T4H.TotalFacturaN,fechaUltimaFacturaEmitida);
        }
    }
}
