using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;
using Tecser.Business.Transactional.FI;
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

    public class ConciliaEgresos2
    {
        public DateTime fecha { get; set; }
        public string Documento { get; set; }
        public string RazonSocial { get; set; }
        public bool Register { get; set; }
        public bool CtaCte { get; set; }
        public string Lx { get; set; }
        public decimal importeReg { get; set; }
        public decimal importeCtaCte { get; set; }
        public decimal importeAcredDiferido { get; set; }
        public decimal importePendAcred { get; set; }
        public bool StatusOk { get; set; }
    }
}

public class VendorEgresosConcilia
{

    //Obtiene Lista Movimientos Register Vendor
    public static List<XREGISTER> GetRegisterVendorPeriodoSeleccionado(string periodo, string lx)
    {
        using (var db = new TecserData(GlobalApp.CnnApp))
        {
            var fechaInicial = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaInicial.Month;
            var anio = fechaInicial.Year;

            if (lx == "L1" || lx == "L2")
                return db.XREGISTER.Where(c =>
                    c.Fecha.Value.Month == mes && c.Fecha.Value.Year == anio && c.TIPO == lx && c.PC == "P").ToList();
            return db.XREGISTER.Where(c =>
                c.Fecha.Value.Month == mes && c.Fecha.Value.Year == anio && c.PC == "P").ToList();
        }
    }


    public List<ConciliaEgresos2> Conciliacion2(string periodo, string lx)
    {
        var returnList = new List<ConciliaEgresos2>();
        var fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
        var mes = fechaI.Month;
        var anio = fechaI.Year;
        //
        using (var db = new TecserData(GlobalApp.CnnApp))
        {
            //Listado Register de todos los movimientos del Mes del Tipo Seleccionado
            var r = GetRegisterVendorPeriodoSeleccionado(periodo, lx);
            var rGroup = from x in r
                group x by x.Ref
                into grp
                select new ConciliaEgresos2()
                {
                    fecha = grp.FirstOrDefault().Fecha.Value,
                    Documento = grp.Key,
                    Register = true,
                    importeReg = grp.Sum(c => c.Monto_E.Value) - grp.Sum(c => c.Monto_I.Value),
                    Lx = grp.FirstOrDefault().TIPO,
                    RazonSocial = grp.FirstOrDefault().Entidad
                                        };
            returnList.AddRange(rGroup);

            //Complementar Lista de OP desde REG con Lista CtaCte [Tipos PD,OP y OPZ]
            List<T0203_CTACTE_PROV> lCtacte;
            if (lx == "L1" || lx == "L2")
            {
                lCtacte = db.T0203_CTACTE_PROV.Where(c =>
                    c.Fecha.Month == mes && c.Fecha.Year == anio && c.TIPO == lx &&
                    (c.TDOC == "PD" || c.TDOC == "OP" || c.TDOC == "OPZ")).ToList();
            }
            else
            {
                lCtacte = db.T0203_CTACTE_PROV.Where(c =>
                    c.Fecha.Month == mes && c.Fecha.Year == anio &&
                    (c.TDOC == "PD" || c.TDOC == "OP" || c.TDOC == "OPZ")).ToList();
            }
            foreach (var ordenP in lCtacte)
            {
                var xr = returnList.Find(c => c.Documento == ordenP.NUMDOC);
                if (xr == null)
                {
                    //Doc no encontrado en Register - Add from CtaCte
                    var xtmp = new ConciliaEgresos2()
                    {
                        fecha = ordenP.Fecha,
                        importeCtaCte = ordenP.IMPORTE_ARS *-1,
                        Documento = ordenP.NUMDOC,
                        CtaCte = true,
                        Register = false,
                        Lx = ordenP.TIPO,
                        importeReg = 0,
                        RazonSocial = VendorManager.GetVendorRazonSocial(ordenP.IDPROV)
                    };
                    returnList.Add(xtmp);
                }
                else
                {
                    xr.importeCtaCte = ordenP.IMPORTE_ARS*-1;
                    xr.CtaCte = true;
                }
            }
            
            //Analisis Acreditaciones de Cheques Diferidos (Emitidos en otros Periodos)
            foreach (var rx in returnList.Where(c=>c.Register))
            {
                //Para cada Numero de OP --> Obtiene lista de Cheques Acreditados
                decimal importeAcredDiferido = 0;
                var lPagoChEmitido = db.XREGISTER.Where(c =>
                    c.Ref == rx.Documento && c.Fecha.Value.Month == mes && c.Fecha.Value.Year == anio &&
                    c.ST.StartsWith("AC")).ToList();
                foreach (var iRegChAcred in lPagoChEmitido)
                {
                    var iChEmitido = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IdRegister == iRegChAcred.IDT);
                    if (iChEmitido.FechaEmision.Month == iRegChAcred.Fecha.Value.Month &&
                        iChEmitido.FechaEmision.Year == iRegChAcred.Fecha.Value.Year)
                    {
                        //el registro es de un cheque emitido en el mismo periodo
                        //no necesito computar esto porque es lo mismo que ARS u otro Medio
                    }
                    else
                    {
                        //el registro es de un cheque emitido en 'otro' periodo (diferido)
                        importeAcredDiferido += iChEmitido.ImporteCheque;
                    }
                }
                rx.importeAcredDiferido = importeAcredDiferido; //Total Acreditado difereido por OP.
            }

            //Analisis de Acreditaciones Pendientes 
            foreach (var rx in returnList.Where(c=>c.CtaCte))
            {
                decimal importePendAcreditacion = 0;
                var lChEmitidosOP = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                    c.Status != GestionChequesEmitidos.StatusChequeEmitido.Anulado.ToString() && c.OrdenPagoNumero.ToString()==rx.Documento).ToList();
                foreach (var icheque in lChEmitidosOP)
                {
                    if (icheque.PendienteAcreditacion)
                    {
                        //el cheque aun esta sin acreditar x lo que esta en REG.
                        importePendAcreditacion += icheque.ImporteCheque;
                    }
                    else
                    {
                        //el cheque esta acredtiado pero podria haber sido hecho en un periodo posterior
                        //por lo que para el analisis al mes en curso estaba Pendiente.-
                        if (icheque.FechaAcreditacionReal.Value.Month != mes)
                        {
                            importePendAcreditacion += icheque.ImporteCheque;
                        }
                        else
                        {
                            if (icheque.FechaAcreditacionReal.Value.Year != anio)
                            {
                                importePendAcreditacion += icheque.ImporteCheque;
                            }
                        }
                    }
                }
                rx.importePendAcred = importePendAcreditacion;
            }
        }

        foreach (var item in returnList)
        {
            if (item.importeCtaCte != 0)
            {
                if (item.importeAcredDiferido != 0)
                {
                    //si ctacte es porque se emitio en este periodo
                    //no puede haber acreditaciones de otros periodos
                    item.StatusOk = false;
                }
                else
                {
                    if (item.importeCtaCte - item.importeReg - item.importePendAcred == 0)
                    {
                        item.StatusOk = true;
                    }
                    else
                    {
                        item.StatusOk = false;
                    }
                }
            }
            else
            {
                //importe ctacte =>0
                if (item.importeReg - item.importeAcredDiferido == 0)
                {
                    item.StatusOk = true;
                }
                else
                {
                    item.StatusOk = false;
                }
            }
        }
        return returnList;
    }


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
