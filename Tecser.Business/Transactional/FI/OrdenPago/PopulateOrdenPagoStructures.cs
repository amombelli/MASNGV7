using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class PopulateOrdenPagoStructures
    {
        public List<DsFacturasOP> PopulateFacturasInOp(List<T0212_OrdenPagoDocumentos> docs)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from docu in docs
                    join factux in db.T0403_VENDOR_FACT_H on docu.IdFactura equals factux.IDINT
                    select new DsFacturasOP()
                    {
                        IdFactura = docu.IdFactura,
                        IdCtaCte = docu.IdCtaCte,
                        TC = docu.TCDoc,
                        Moneda = docu.MonedaDoc,
                        TDoc = factux.TFACTURA,
                        ImporteOri = docu.ImporteOri,
                        FechaDoc = factux.FECHA,
                        NumDoc = factux.NFACTURA,
                        ImporteArs = docu.ImporteOP,
                        Imputado = docu.ImputadoOP,
                        SaldoPendiente = docu.SaldoAdeudado,
                    };
                return data.ToList();
            }
        }
        public List<DsCreditosOP> PopulateCreditosInOP(int idProveedor, string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from cred in db.T0203_CTACTE_PROV
                    where cred.TIPO == lx && cred.IDPROV == idProveedor
                    select new DsCreditosOP()
                    {
                        TDoc = cred.TDOC,
                        Fecha = cred.Fecha,
                        NumDoc = cred.NUMDOC,
                        Importe = cred.SALDOFACTURA * -1
                    };
                return data.ToList();
            }
        }


        //public List<DsCreditosOP> PopulateCreditosInOP(int numeroOP)
        //{
        //esta info sacarla de t0203 impu y armarla segun el numero op? o idctacte op
        //}

    }
}
