using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class OrdenPagoDetalleImputacion
    {

        /// <summary>
        /// Obtiene por cada idctacte de Factura la forma en la que fue imputado (OP, PD, etc)
        /// </summary>
        public List<DsOpDetalleImputacionPorFactura> GetImputacionPorFactura(int idCtaCteFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from origen in db.T0203_CTACTE_PROV
                    where origen.IDCTACTE == idCtaCteFactura
                    join factu403 in db.T0403_VENDOR_FACT_H on origen.IDCTACTE equals factu403.IDCTACTE.Value
                    into list1
                    from l1 in list1.DefaultIfEmpty()
                    join Imputacion in db.T0203_CTACTE_PROV_IMPU on origen.IDCTACTE equals Imputacion.CTACTE1
                    into list2
                    from l2 in list2.DefaultIfEmpty()
                    join ctacteImpu in db.T0203_CTACTE_PROV on l2.CTACTE2 equals  ctacteImpu.IDCTACTE into list3
                    from l3 in list3.DefaultIfEmpty()
                    select new DsOpDetalleImputacionPorFactura()
                    {
                        IdCtaCteFacturaImputada = idCtaCteFactura,
                        IdFacturaImputada = l1.IDINT,
                        TdocFacturaImputada = origen.TDOC,
                        NumeroFacturaImputada = origen.NUMDOC,
                        TCFacturaImputada = origen.TC,
                        FechaEmisionFacturaImputada = origen.Fecha,
                        ImporteEmisionFacturaImputada = origen.IMPORTE_ARS,
                        ImporteImputado =l2==null? 0:l2.MONTO_IMPU,
                        FechaImputacion = l3.Fecha,
                        TdocImputacion = l3.TDOC,
                        NumeroDocImputacion = l3.NUMDOC,
                        IdCtaCteImputacion = l3.IDCTACTE,
                        TcImputacion = l3.TC,
                        DiasImputacion = 0,
                        DiasPromedioPago = 0,
                        GlImputacion = l2.GLPAGO
                    };
                return data.ToList();
            }
        }


    }
}
