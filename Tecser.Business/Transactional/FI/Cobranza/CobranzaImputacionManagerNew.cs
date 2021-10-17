using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.Customers;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public class CobranzaImputacionManagerNew
    {
        public enum ModoImputacion
        {
            SoloFacturasCompletasOldNew, //Desde la mas vieja a mas nueva hasta importe completo
            TotalOldnNew, //Desde la mas vieja a mas nueva solo factura completa
            Manual //Imputacion manual
        }
        private readonly int? _id208;
        private readonly int _idctacteFactu207;
        private readonly int _numeroSplit;
        private readonly decimal _montoImputar;
        public bool ResultadoImputacion { get; private set; }
        public decimal ImportePendienteImputar { get; private set; }
        public bool OKImpuFinal { get; private set; } //Todas las validaciones OK
        public bool OKImpuIIBB { get; private set; }
        public bool OK208 { get; private set; }
        public bool OK207 { get; private set; }
        private T0207_SPLITFACTURAS data207;
        private T0201_CTACTE data201Factura;
        private T0201_CTACTE data201Credito;
        private T0208_COB_NO_APLICADA data208;
        public bool OKImporteSplits { get; private set; }
        public bool OKSumaImputadoNoImputado { get; private set; }

        public bool OK207_400 { get; private set; }     //Datos de 207 estan OK con data 400
        public bool ErrorDataIIBBnoRegistrada { get; private set; } //Los datos en Tabla IIBB no estan y deberian
        public decimal ImportePendienteIibb { get; private set; }
        public bool MontoImputarValidacionOK { get; private set; }
        public T0400_FACTURA_H DataFacturaSeleccionada { get; private set; }
        public int DiasCobranza { get; private set; }
        public int DiasImputacion { get; private set; }
        public decimal ImporteUSD { get; private set; }
        public decimal ResultadoAunSinImputar { get; private set; }

        public decimal ImporteAImputar { get; private set; }


        //Al instanciar la clase hace todas las validacions
        public CobranzaImputacionManagerNew(int id208, int idctacteFactu207, int numeroSplit, decimal montoImputar)
        {
            _id208 = id208;
            _idctacteFactu207 = idctacteFactu207;
            _numeroSplit = numeroSplit;
            _montoImputar = montoImputar;
            OKImpuFinal = false;
            OKImpuIIBB = false;
            OK207 = false;
            OK208 = false;
            OKImporteSplits = false;
            OKSumaImputadoNoImputado = false;
            OK207_400 = false;
            ErrorDataIIBBnoRegistrada = false;
            ImportePendienteIibb = 0;
            MontoImputarValidacionOK = false;
            //cargamos factura
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                data207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c => c.IDCTACTE == _idctacteFactu207 && c.FACTSPLIT == _numeroSplit);
                data208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == id208);
                data201Factura = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == data207.IDCTACTE);
                data201Credito = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == data208.IDCTACTE.Value);

                var y = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == data207.IDCTACTE).ToList();
                if (!y.Any()) return;

                if (data208.CLIENTE != data201Credito.IDCLI)
                {
                    OK208 = false;
                    return;
                }
                if (data208.CLIENTE != data201Factura.IDCLI)
                {
                    OK208 = false;
                    return;
                }
                var data208sum = db.T0208_COB_NO_APLICADA.Where(c => c.IDCTACTE.Value == data208.IDCTACTE.Value)
                    .ToList();
                if (data208sum.Sum(c => c.MONTO.Value) != Math.Abs(data201Credito.SALDOFACTURA))
                {
                    OK208 = false;
                    return;
                }
                OK208 = true;




                //Valida Importe a Imputar (la suma de los splits da OK)
                decimal importeSplit = y.Sum(c => c.ImporteAImputar);
                if (importeSplit != data207.ImporteDocumento)
                {
                    OKImporteSplits = false;
                    return;
                }
                if (data207.ImporteDocumento != data201Factura.IMPORTE_ARS)
                {
                    OKImporteSplits = false;
                    return;
                }
                OKImporteSplits = true;

                //Valida Suma de Importe Imputado + No Imputado da ImporteDocumento
                decimal importeYaImputado = y.Where(c => c.MontoImputado != 0).Sum(c => c.MontoImputado);
                ImportePendienteImputar = y.Where(c => c.MontoImputado == 0).Sum(c => c.ImporteAImputar);
                if (ImportePendienteImputar + importeYaImputado != data207.ImporteDocumento)
                {
                    OKSumaImputadoNoImputado = false;
                    return;
                }
                OKSumaImputadoNoImputado = true;

                if (data201Factura.IMPORTE_ARS != data207.ImporteDocumento)
                {
                    OK207 = false;
                    return;
                }
                if (data201Factura.IDCLI != data207.CLIENTE)
                {
                    OK207 = false;
                    return;
                }
                OK207 = true;
                DataFacturaSeleccionada = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == data207.IDCTACTE);
                if (DataFacturaSeleccionada == null)
                {
                    OK207_400 = false;
                    return;
                }
                if (DataFacturaSeleccionada.TotalFacturaN != data207.ImporteDocumento)
                {
                    OK207_400 = false;
                    return;
                }
                OK207_400 = true;


                ImportePendienteIibb = 0;
                if (data201Factura.TIPO == "L2")
                {
                    OKImpuIIBB = true;
                }
                else
                {
                    if (DataFacturaSeleccionada.TotalIIBB == 0)
                    {
                        OKImpuIIBB = true;
                    }
                    else
                    {
                        var iibb = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == DataFacturaSeleccionada.IDFACTURAX);
                        if (iibb == null)
                        {
                            OKImpuIIBB = false;
                            ErrorDataIIBBnoRegistrada = true;
                            return;

                        }
                        else
                        {
                            //validar IIBB
                            ErrorDataIIBBnoRegistrada = false;
                            ImportePendienteIibb = iibb.IIBB_Perc_ARS_Saldo.Value;
                            if (montoImputar < ImportePendienteIibb)
                            {
                                OKImpuIIBB = false;
                                return;
                            }
                            else
                            {
                                OKImpuIIBB = true;
                            }
                        }
                    }
                }
            }
            OKImpuFinal = true;
        }

        public void Imputar(ModoImputacion modo = ModoImputacion.Manual)
        {
            ResultadoImputacion = false;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal importe208 = data208.MONTO.Value;
                decimal importeSaldoPendienteFactura = data201Factura.SALDOFACTURA;
                ImporteAImputar = _montoImputar;
                //
                data207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c => c.IDCTACTE == _idctacteFactu207 && c.FACTSPLIT == _numeroSplit);
                data208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == _id208);
                data201Factura = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == data207.IDCTACTE);
                data201Credito = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == data208.IDCTACTE.Value);
                //
                //no hace falta validar porque ya lo valida pero lo hacemo
                if (ImporteAImputar > data208.MONTO)
                {
                    return;
                }

                if (ImporteAImputar > importeSaldoPendienteFactura)
                {
                    //Ajusta el Importe a Imputar al Maximo posible
                    ImporteAImputar = importeSaldoPendienteFactura;
                }

                data208.MONTO = data208.MONTO - ImporteAImputar; //recalcula el credito pendiente

                //1.Ajustar Importe a Imputar
                decimal creditoPendiente = data208.MONTO.Value;
                if (ImporteAImputar > importeSaldoPendienteFactura)
                {
                    ImporteAImputar = importeSaldoPendienteFactura;
                    creditoPendiente = data208.MONTO.Value - ImporteAImputar;
                    data208.MONTO = creditoPendiente; //ajuste al credito pendiente
                }
                else
                {
                    if (creditoPendiente == 0)
                    {
                        db.T0208_COB_NO_APLICADA.Remove(data208);//remover 208
                    }
                }

                decimal saldoSplit = importeSaldoPendienteFactura - ImporteAImputar;
                if (saldoSplit == 0)
                {
                    //no hace split
                }
                else
                {
                    //hacer split en T0207
                    var newLine = new T0207_SPLITFACTURAS()
                    {
                        INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1,
                        TDOC = data207.TDOC,
                        IDCTACTE = data207.IDCTACTE,
                        IDDOC = data207.IDDOC,
                        NDOC = data207.NDOC,
                        FACTSPLIT = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == data207.IDCTACTE).Max(c => c.FACTSPLIT) + 1,
                        FACT_MONEDA = data207.FACT_MONEDA,
                        ImporteDocumento = data207.ImporteDocumento,
                        ImporteAImputar = saldoSplit,
                        MontoImputado = 0,
                        TIPO = data207.TIPO,
                        CLIENTE = data207.CLIENTE,
                        FECHA_FACT = data207.FECHA_FACT,
                        ZTERM = data207.ZTERM,
                        FECHA_VENC = data207.FECHA_VENC,
                        DIAS_VENC = data207.DIAS_VENC,
                        //
                        NRECIBO = null,
                        PFECHA = null,
                        XCOMENTARIO = null,
                        IDCOB = null,
                        IDNC = null,
                        NumeroDoc = null,
                        TipoDocCancel = null,
                        DiasPPCob = 0,
                        DiasImpu = 0,
                        USDImpu = 0,
                        //
                    };
                    db.T0207_SPLITFACTURAS.Add(newLine);
                    //modifica Importes en Linea Actual
                    data207.ImporteAImputar = ImporteAImputar;
                }
                //
                data207.MontoImputado = ImporteAImputar;
                int diasImpu = (data208.FECHA.Value - data207.FECHA_FACT).Days;
                switch (data208.TIPODOC)
                {
                    case "COB":
                        var cobData = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == data208.IDRECIBO.Value);
                        data207.NRECIBO = data208.NRECIBO;
                        data207.PFECHA = data208.FECHA;
                        //data207.XCOMENTARIO
                        data207.IDCOB = data208.IDRECIBO;
                        data207.IDNC = null;
                        data207.NumeroDoc = string.IsNullOrEmpty(cobData.NRECIBOOFI) ? cobData.NRECIBO : cobData.NRECIBOOFI;
                        data207.TipoDocCancel = "COB";
                        data207.DiasPPCob = cobData.DIAS_PP;
                        data207.DiasImpu = diasImpu < 0 ? 0 : diasImpu;
                        data207.USDImpu = Math.Round(ImporteAImputar / cobData.TC, 2);
                        break;
                    case "NCD":
                    case "NC":
                        var ncData = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == data208.IDNCD.Value);
                        if (ncData == null)
                        {
                            ncData = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == data208.IDRECIBO);
                            if (ncData == null)
                            {
                                data207.NumeroDoc = data208.NRECIBO;
                                data207.USDImpu = Math.Round(ImporteAImputar / new ExchangeRateManager().GetExchangeRate(data208.FECHA.Value), 2);
                                data207.IDNC = 0;
                                data207.XCOMENTARIO += " " + "No se encontro ID NotaCredito";
                            }
                            else
                            {
                                data207.NumeroDoc = ncData.NDOC;
                                data207.IDNC = data208.IDRECIBO;
                                data207.USDImpu = Math.Round(ImporteAImputar / ncData.TC, 2);
                            }
                        }
                        else
                        {
                            data207.NumeroDoc = ncData.NDOC;
                            data207.IDNC = data208.IDNCD;
                            data207.USDImpu = Math.Round(ImporteAImputar / ncData.TC, 2);
                        }
                        data207.NRECIBO = data208.NRECIBO;
                        data207.PFECHA = data208.FECHA;
                        //data207.XCOMENTARIO
                        data207.IDCOB = null;
                        data207.TipoDocCancel = "NC";
                        data207.DiasPPCob = 0;
                        data207.DiasImpu = diasImpu < 0 ? 0 : diasImpu;
                        break;
                    case "AJ":
                        //Ver si Ajuste va igual que NC.- 
                        var ncData1 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == data208.IDNCD.Value);
                        data207.NRECIBO = data208.NRECIBO;
                        data207.PFECHA = data208.FECHA;
                        //data207.XCOMENTARIO
                        data207.IDCOB = null;
                        data207.IDNC = data208.IDNCD;
                        data207.NumeroDoc = ncData1.NDOC;
                        data207.TipoDocCancel = "NC";
                        data207.DiasPPCob = 0;
                        data207.DiasImpu = diasImpu < 0 ? 0 : diasImpu;
                        data207.USDImpu = Math.Round(ImporteAImputar / ncData1.TC, 2);
                        break;
                }

                DiasCobranza = data207.DiasPPCob ?? 0;
                DiasImputacion = data207.DiasImpu ?? 0;
                ImporteUSD = data207.USDImpu ?? 0;
                ResultadoAunSinImputar = saldoSplit;
                data201Factura.SALDOFACTURA = saldoSplit;
                data201Credito.SALDOFACTURA = creditoPendiente * -1;
                var x = db.SaveChanges();


                if (data201Factura.TIPO == "L1" && data201Factura.TDOC != "AJ")
                {
                    if (new PercepcionesManager().ImputaPagoUpdatePercepcion(data201Factura.IDCTACTE, data201Credito.IDCTACTE) ==
                        false)
                    {
                        //MessageBox.Show(@"Ha Ocurrido un error en la imputacion de Percepciones",
                        //  @"Error en Imputacion de Percepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //todo: se puede validar aca o traer aca el importe de IIBB - Saldo 

                if (x > 0)
                {
                    ResultadoImputacion = true;
                }
            }
        }

        public void ConsolidaCredito208(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }
    }
}
