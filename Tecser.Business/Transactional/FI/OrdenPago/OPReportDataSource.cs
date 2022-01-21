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

    //Clase que provee los datos que se utilizan en el reporte de generacion de OP
    public class OPReportDataSource
    {
        private readonly int _numeroOP;
        public OPReportDataSource(int numeroOP)
        {
            _numeroOP = numeroOP;
        }
        public List<T0210_OrdenPagoHeader> GetHeader()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0210_OrdenPagoHeader.Where(c => c.IdOP == _numeroOP).ToList();
            }
        }
        public List<DsOpFacturasAplicadas> GetAplicacionFacturas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from origen in db.T0212_OrdenPagoDocumentos
                    where origen.IdOP == _numeroOP
                    join factu in db.T0203_CTACTE_PROV on origen.IdCtaCte equals factu.IDCTACTE
                    select new DsOpFacturasAplicadas()
                    {
                        IdFactura = origen.IdFactura,
                        IdCtaCte = origen.IdCtaCte,
                        Fecha = factu.Fecha,
                        Tdoc = factu.TDOC,
                        Numero = factu.NUMDOC,
                        ImporteOri = factu.IMPORTE_ARS,
                        ImporteAdeudadoAnterior = origen.SaldoAdeudado,
                        ImporteAplicado = origen.ImputadoOP,
                        SaldoAdeudado = origen.SaldoAdeudado - origen.ImputadoOP,
                    };
                return data.ToList();
            }
        }
        public List<DsOpEstructuraCreditosAplicados> GetCreditosAplicados()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lx = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == _numeroOP).Lx;
                string numeroOp = OPNumeroConversion.GetNumeroOP(_numeroOP, lx);
                var data = from origen in db.T0203_CTACTE_PROV_IMPU
                    where origen.NUMDOC == numeroOp && origen.TDOC == "OPC"
                    join ctacte in db.T0203_CTACTE_PROV on origen.CTACTE2 equals ctacte.IDCTACTE
                    select new DsOpEstructuraCreditosAplicados()
                    {
                        NumeroDoc = ctacte.NUMDOC,
                        Tdoc = ctacte.TDOC,
                        FechaDoc = ctacte.Fecha,
                        Importe = origen.MONTO_IMPU
                    };
                return data.ToList();
            }
        }


    }
}
