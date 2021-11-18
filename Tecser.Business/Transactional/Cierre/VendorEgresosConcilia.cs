using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.Cierre
{
    public class Stx1
    {
        public string Td { get; set; }
        public string NumeroDoc { get; set; }
        public decimal ImporteReg { get; set; }
        public decimal ImporteCc { get; set; }
        public bool SaldosOk { get; set; }
        public bool DocEncnontradoCc { get; set; }
    }
}

public class VendorEgresosConcilia
{
    public List<Stx1> ListaRegCc;
    public List<Stx1> ProcesaRegEnCc(string periodo, string lx)
    {
        DateTime _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
        DateTime _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
        ListaRegCc = new List<Stx1>();
        //traia problemas con el ultimo dia + horas
        using (var db = new TecserData(GlobalApp.CnnApp))
        {
            var reg = db.XREGISTER
                .Where(c => c.Fecha >= _fechaI && c.Fecha < _fechaD && c.PC == "P" && c.TIPO == lx)
                .ToList();

            foreach (var ireg in reg)
            {
                var cs = ListaRegCc.FirstOrDefault(c => c.Td == ireg.Tdoc && c.NumeroDoc == ireg.Ref);
                if (cs == null)
                {
                    if (ireg.Ref == "400000983")
                    {
                        var c = 1;
                    }
                    var itemcc = db.T0203_CTACTE_PROV.SingleOrDefault(c =>
                        c.TDOC == ireg.Tdoc && c.NUMDOC == ireg.Ref && c.Fecha.Month == ireg.Fecha.Value.Month && c.Fecha.Year == ireg.Fecha.Value.Year &
                        c.IDPROV == ireg.PCID.Value);
                    var sumareg = db.XREGISTER.Where(c => c.NAS == ireg.NAS).Sum(d => d.Monto_E);
                    var item = new Stx1
                    {
                        NumeroDoc = ireg.Ref,
                        Td = ireg.Tdoc,
                        DocEncnontradoCc = itemcc != null,
                        ImporteReg = (decimal) sumareg,
                        ImporteCc = 0,
                        SaldosOk = false
                    };

                    if (itemcc != null)
                    {
                        (item.ImporteCc) = Math.Abs(itemcc.IMPORTE_ARS);
                    }

                    if (item.ImporteCc == item.ImporteReg)
                    {
                        item.SaldosOk = true;
                    }


                    ListaRegCc.Add(item);
                }
            }
            return ListaRegCc;
        }
    }
}
