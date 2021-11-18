using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

namespace Tecser.Business.Transactional.FI
{
    public class OrdenPagoManageDatos
    {
        public OrdenPagoManageDatos()
        {

        }
        public OrdenPagoManageDatos(int numeroOP)
        {
            _numeroOP = numeroOP;
            Header = GetDatosHeaderFromDb();
        }

        //-----------------------------------------------------------------------------------------------------------
        private readonly int _numeroOP;
        public T0210_OP_H Header = new T0210_OP_H();

        public List<T0213_OP_FACT> GetDatosFacturasPagandoFromDb()
        {
            return new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).OrderBy(c => c.IDITEM)
                .ToList();
        }

        public List<DsOrdenPagoFacturasIncluidas> GetDatosFacturasPagandoFromDb_new()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from opfactu in db.T0213_OP_FACT
                           join facturas in db.T0203_CTACTE_PROV on opfactu.IdCtaCte equals facturas.IDCTACTE
                           where opfactu.IDOP == _numeroOP
                           select new DsOrdenPagoFacturasIncluidas()
                           {
                               Tdoc = facturas.TDOC,
                               FechaDoc = facturas.Fecha,
                               FACT_TIPO = opfactu.FACT_TIPO,
                               FACT_NUM = opfactu.FACT_NUM,
                               FACT_MON = opfactu.FACT_MON,
                               FACT_SALDO_IMPUTAR = opfactu.FACT_SALDO_IMPUTAR,
                               FACT_IMPUTADO = opfactu.FACT_IMPUTADO,
                               RetencionIIBB = opfactu.RetencionIIBB,
                               RetencionGS = opfactu.RetencionGS,
                               FACT_ID = opfactu.FACT_ID,
                               IDITEM = opfactu.IDITEM,
                               IdFacturaX = opfactu.IdFacturaX,
                               IDOP = opfactu.IDOP,
                               IdCtaCte = opfactu.IdCtaCte
                           };
                return data.OrderBy(c => c.IDITEM).ToList();
            }
        }
        public T0210_OP_H GetDatosHeaderFromDb()
        {
            return new TecserData(GlobalApp.CnnApp).T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
        }
        public List<T0212_OP_ITEM> GetDatosItemsPagoFromDb()
        {
            var lista = new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _numeroOP).OrderBy(c => c.IDITEM);
            return lista.ToList();
        }
        public bool AddFacturaAPagar(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataFactura = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                var data403 = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                var i = new T0213_OP_FACT()
                {
                    IDOP = Header.IDOP,
                    IDITEM = db.T0213_OP_FACT.Max(c => c.IDITEM) + 1,
                    PROVEEDOR = Header.PROV_ID,
                    MON_OP = Header.MON_OP,
                    TC = Header.TC,
                    FACT_ID = data403.IDINT,
                    FACT_NUM = dataFactura.NUMDOC,
                    FACT_MON = dataFactura.MONEDA,
                    FACT_TIPO = dataFactura.TIPO,
                    CK_FIN = false,
                    FACT_SALDO_O = dataFactura.SALDOFACTURA,
                    FACT_SALDO_IMPUTAR = dataFactura.SALDOFACTURA,
                    //FACT_IMPUTADO
                    //NASIENTO
                    //RetencionIIBB
                    //RetencionGS
                    IdFacturaX = dataFactura.IdFacturaX,
                    IdCtaCte = idCtaCte
                };
                db.T0213_OP_FACT.Add(i);
                return db.SaveChanges() > 0;
            }
        }

        //-----------------------------------------------------------------------------------------------------------
        public void UpdateHeaderConImporteRetenciones(decimal importeRetGs, decimal baseCalculoGanancias,
            decimal importeRetIIBB, decimal importeRetIVA = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
                h.ImporteRetGS = importeRetGs;
                h.ImporteRetIIBB = importeRetIIBB;
                h.ImporteRetIVA = importeRetIVA;
                h.BaseCalculoPagoRetGS = baseCalculoGanancias;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Se utiliza al salir cuando esta en proceso o al presionar generar
        /// </summary>
        public void UpdateValuesHeader(decimal importeTotalOP, decimal importeValores, decimal importeCreditos,
            decimal importeRetencionGs, decimal importeRetecionIIBB, decimal saldoSinImputar,
            decimal baseCalculoGanancias, string comentarioOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
                h.IMP_OP = importeTotalOP;
                h.ImporteValores = importeValores;
                h.ImporteCreditos = importeCreditos;
                h.ImporteRetGS = importeRetencionGs;
                h.ImporteRetIIBB = importeRetecionIIBB;
                if (baseCalculoGanancias != 0)
                    h.BaseCalculoPagoRetGS = baseCalculoGanancias;
                h.SaldoSinImputar = saldoSinImputar * -1;
                h.OP_COM = comentarioOP;
                db.SaveChanges();

                Header.IMP_OP = importeTotalOP;
                Header.ImporteValores = importeValores;
                Header.ImporteCreditos = importeCreditos;
                Header.ImporteRetGS = importeRetencionGs;
                Header.ImporteRetIIBB = importeRetecionIIBB;
                Header.BaseCalculoPagoRetGS = baseCalculoGanancias;
                Header.SaldoSinImputar = saldoSinImputar;
                Header.OP_COM = comentarioOP;
            }
        }
        public bool ValidaSaldosFacturaAntesGenerar()
        {
            var rtn = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fop = db.T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
                foreach (var ix in fop)
                {
                    var saldoFacturaCtaCte =
                        db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == ix.IdCtaCte.Value).SALDOFACTURA;
                    if (saldoFacturaCtaCte != ix.FACT_SALDO_IMPUTAR.Value)
                        return false;
                }
            }


            return rtn;
        }

        public bool CheckIfOPCredAvailable(int idVendor, string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0203_CTACTE_PROV.Where(
                        c => c.IDPROV == idVendor && c.TIPO == lx && c.TDOC == "OP" && c.SALDOFACTURA < 0).ToList();
                return data.Count > 0;
            }
        }

        public void SetStatusContabilizado(int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
                h.NAS = numeroAsiento;
                h.OP_STATUS = OrdenPagoStatus.StatusOP.Generada.ToString();
                db.SaveChanges();
                Header.NAS = numeroAsiento;
                Header.OP_STATUS = OrdenPagoStatus.StatusOP.Generada.ToString();
            }
        }
        public void SetStatusFinalizado()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
                h.OP_STATUS = OrdenPagoStatus.StatusOP.Finalizada.ToString();
                db.SaveChanges();
                Header.OP_STATUS = OrdenPagoStatus.StatusOP.Finalizada.ToString();
            }
        }


        public void RegistraChequesEmitidos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaItems = db.T0212_OP_ITEM.Where(c => c.IDOP == _numeroOP && c.CH_ID == -5).ToList();
                foreach (var it in listaItems)
                {
                    var obj = new GestionChequesEmitidos().SetNewRecord(it.CH_NUM, it.T0210_OP_H.OPFECHA.Value,
                        it.ChequeFecha.Value, it.IMPORTE.Value, it.CUENTA_O, it.IDOP, it.PROVEEDOR.Value,
                        it.CK_FIN.Value);
                    if (obj < 1)
                        MessageBox.Show(@"Error al Registrar el Cheque Emitido!", @"Atencion!", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                }
            }


        }
        public void GeneraSubdiario()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaItems = db.T0212_OP_ITEM.Where(c => c.IDOP == _numeroOP && c.CUENTA_O != "OPCRED").ToList();
                foreach (var it in listaItems)
                {
                    switch (it.CUENTA_O)
                    {
                        case "CHE":
                            new SubdiarioCajaManager().WriteToDb(it.CUENTA_O, Convert.ToDateTime(Header.OPFECHA),
                                SubdiarioCajaManager.PC.Proveedor,
                                Header.PROV_ID, "OP", _numeroOP.ToString(), "Orden Pago #" + Header.PROV_RS,
                                Header.MON_OP, 0, Convert.ToDecimal(it.IMPORTE), Header.TIPO,
                                "OPX", Header.NAS.Value, new CuentasManager().GetGL(it.CUENTA_O),
                                idCheque: it.CH_ID.Value);
                            break;

                        default:
                            if (it.CH_ID == -5)
                            {
                                //Son cheques emitidos propios por lo que no se registra en REG hasta que no se acrediten
                            }
                            else
                            {
                                new SubdiarioCajaManager().WriteToDb(it.CUENTA_O, Convert.ToDateTime(Header.OPFECHA),
                                    SubdiarioCajaManager.PC.Proveedor,
                                    Header.PROV_ID, "OP", _numeroOP.ToString(), "Orden Pago #" + Header.PROV_RS,
                                    Header.MON_OP, 0, Convert.ToDecimal(it.IMPORTE), Header.TIPO,
                                    "OPX", Header.NAS.Value, new CuentasManager().GetGL(it.CUENTA_O));
                            }
                            break;
                    }
                }
                //Incluye Retencion IIBB, Retencion GS, Retencion IVA
                var H = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _numeroOP);
                if (H.ImporteRetGS > 0)
                {
                    new SubdiarioCajaManager().WriteToDb("RGA", Convert.ToDateTime(Header.OPFECHA),
                        SubdiarioCajaManager.PC.Proveedor,
                        Header.PROV_ID, "OP", _numeroOP.ToString(), "Orden Pago #" + Header.PROV_RS,
                        Header.MON_OP, 0, Convert.ToDecimal(H.ImporteRetGS), Header.TIPO,
                        "OPX", Header.NAS.Value, new CuentasManager().GetGL("RGA"));
                }

                if (H.ImporteRetIIBB > 0)
                {
                    new SubdiarioCajaManager().WriteToDb("RIB", Convert.ToDateTime(Header.OPFECHA),
                        SubdiarioCajaManager.PC.Proveedor,
                        Header.PROV_ID, "OP", _numeroOP.ToString(), "Orden Pago #" + Header.PROV_RS,
                        Header.MON_OP, 0, Convert.ToDecimal(H.ImporteRetIIBB), Header.TIPO,
                        "OPX", Header.NAS.Value, new CuentasManager().GetGL("RIB"));
                }
            }
        }
        public void ActualizaCuentasCorrientes()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                if (Header.ImporteValores == null)
                    Header.ImporteValores = 0;

                if (Header.ImporteRetIVA == null)
                    Header.ImporteRetIVA = 0;

                if (Header.ImporteRetIIBB == null)
                    Header.ImporteRetIIBB = 0;

                if (Header.ImporteRetGS == null)
                    Header.ImporteRetGS = 0;


                var importeOPCtaCte = Header.ImporteValores + Header.ImporteRetIVA + Header.ImporteRetIIBB +
                                      Header.ImporteRetGS; //Es el importe que se pasas a T0203

                var cta = new CtaCteVendor(Header.PROV_ID);
                var idCtaCte = cta.AddCtaCteDetalleRecord("OP", Header.TIPO, Header.OPFECHA.Value,
                    Header.IDOP.ToString(), Header.IDOP.ToString(), Header.MON_OP, importeOPCtaCte.Value * -1,
                    Header.TC.Value, Header.SaldoSinImputar.Value * -1, idDocumentoPrincipal: Header.IDOP);

                cta.UpdateSaldoCtaCteResumen(Header.TIPO, importeOPCtaCte.Value * -1, Header.MON_OP, Header.TC.Value);

                var datosFacturas = db.T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
                foreach (var ifactu in datosFacturas)
                {
                    var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == ifactu.IdCtaCte.Value);
                    if (ifactu.RetencionGS == null)
                        ifactu.RetencionGS = 0;

                    if (ifactu.RetencionIIBB == null)
                        ifactu.RetencionIIBB = 0;

                    ifactu.CK_FIN = true;
                    var totalImputado = ifactu.FACT_IMPUTADO + ifactu.RetencionGS + ifactu.RetencionIIBB;

                    ctacte.SALDOFACTURA = ctacte.SALDOFACTURA - (decimal) totalImputado;
                    db.SaveChanges();

                }


            }
        }

        //revisado


        //sin revisar
        public void AddOPCred(int idCtaCteOPCred)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacteOpCred = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOPCred);
                if (ctacteOpCred == null)
                    return;

                AddItemPago("OPCRED", Math.Abs(ctacteOpCred.SALDOFACTURA), idCtaCteOPCred);
                ctacteOpCred.SALDOFACTURA = 0;

                Int32 numOP = Convert.ToInt32(ctacteOpCred.NUMDOC);
                var opz = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numOP);
                if (opz != null)
                {
                    opz.SaldoSinImputar = 0;
                }
                db.SaveChanges();
            }
        }

        public void AddNcCred(int idCtaCteOPCred)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacteOpCred = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOPCred);
                if (ctacteOpCred == null)
                    return;
                AddItemPago("NC", Math.Abs(ctacteOpCred.SALDOFACTURA), idCtaCteOPCred);
                ctacteOpCred.SALDOFACTURA = 0;

                //Int32 numOP = Convert.ToInt32(ctacteOpCred.NUMDOC);
                //var opz = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numOP);
                //if (opz != null)
                //{
                //    opz.SaldoSinImputar = 0;
                //}
                db.SaveChanges();
            }
        }

        private void RemoveOPCred(int idCtaCteOPCred, decimal importeRetornar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacteOpCred = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOPCred);
                if (ctacteOpCred == null)
                    return;

                ctacteOpCred.SALDOFACTURA = importeRetornar * -1;

                Int32 numOP = Convert.ToInt32(ctacteOpCred.NUMDOC);
                var opz = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numOP);
                if (opz != null)
                {
                    opz.SaldoSinImputar = importeRetornar * -1;
                }


                db.SaveChanges();
            }
        }


        private void RemoveNotaCredito(int idCtaCteNC, decimal importeRetornar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacteOpCred = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteNC);
                if (ctacteOpCred == null)
                    return;

                ctacteOpCred.SALDOFACTURA = importeRetornar * -1;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Agrega un item de pago a una orden de pago - NO USAR para OPCRED Directamente
        /// Si se provee fechaAcreditacionEmitido - Se trata de un cheque emitido desde cuentas (GAL,SAN,ICBC)
        /// Se utliliza CK_FIN para indicar que es transferencia desde banco
        /// </summary>
        public bool AddItemPago(string cuenta, decimal importe, int idCheque = -1, decimal tc = 0, DateTime? fechaAcreditacionEmitido = null, string numeroChequeEmitido = null, bool esTransferenciaDesdeCuenta = false)
        {
            if (cuenta == "CHE" && idCheque <= 0)
            {
                return false;
            }
            var infoCuentaPago = new CuentasManager().GetSpecificCuentaInfo(cuenta);
            var itemPago = new T0212_OP_ITEM()
            {
                IDOP = _numeroOP,
                CH_CK = false,
                CH_BCO = null,
                CH_ID = null,
                CH_NUM = null,
                CK_CANCEL = false,
                CK_FIN = esTransferenciaDesdeCuenta, //lo vamos a usar como indicador de transferencia desde cuenta
                CUENTA_O = cuenta,
                PROVEEDOR = Header.PROV_ID,
                TC = Header.TC,
                MON_OP = Header.MON_OP,
                IMPORTE = importe,
                MON = infoCuentaPago.CUENTA_MONEDA,
                ChequeFecha = null,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (fechaAcreditacionEmitido != null)
                {
                    //se trata de un cheque o echeque emitido por Tecser
                    var bankValue = cuenta.Substring(0, 3);
                    var bancos = new BankManager().GetBankDataNombreCuenta(bankValue);
                    if (bancos == null)
                    {
                        bancos.ID_BANCO = "000";
                    }
                    itemPago.CH_CK = true;
                    itemPago.CH_NUM = numeroChequeEmitido;
                    itemPago.CH_BCO = bancos.ID_BANCO;
                    itemPago.CH_ID = idCheque; //debiera venir -5
                    itemPago.ChequeFecha = fechaAcreditacionEmitido;
                }
                else
                {
                    switch (cuenta)
                    {
                        case "CHE":
                            var datosCheque = new ChequesManager().GetCheque(idCheque);
                            itemPago.CH_CK = true;
                            itemPago.CH_NUM = datosCheque.CHE_NUMERO;
                            itemPago.CH_BCO = datosCheque.CHE_BANCO;
                            itemPago.CH_ID = datosCheque.IDCHEQUE;
                            itemPago.ChequeFecha = datosCheque.CHE_FECHA;
                            itemPago.MON = datosCheque.MONEDA;
                            itemPago.IMPORTE = datosCheque.IMPORTE;
                            break;
                        case "OPCRED":
                            var datosCtaCte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCheque);
                            itemPago.CH_NUM = "OP@" + datosCtaCte.NUMDOC;
                            itemPago.CH_ID = idCheque;
                            itemPago.ChequeFecha = datosCtaCte.Fecha;
                            itemPago.IMPORTE = Math.Abs(datosCtaCte.SALDOFACTURA);
                            itemPago.MON = datosCtaCte.MONEDA;
                            break;
                        case "NC":
                            var datosCtaCteX = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCheque);
                            itemPago.CH_NUM = "NC@" + datosCtaCteX.NUMDOC;
                            itemPago.CH_ID = idCheque;
                            itemPago.ChequeFecha = datosCtaCteX.Fecha;
                            itemPago.IMPORTE = Math.Abs(datosCtaCteX.SALDOFACTURA);
                            itemPago.MON = datosCtaCteX.MONEDA;
                            break;
                        case "NC2":
                            var datosCtaCteY = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCheque);
                            itemPago.CH_NUM = "NC@" + datosCtaCteY.NUMDOC;
                            itemPago.CH_ID = idCheque;
                            itemPago.ChequeFecha = datosCtaCteY.Fecha;
                            itemPago.IMPORTE = Math.Abs(datosCtaCteY.SALDOFACTURA);
                            itemPago.MON = datosCtaCteY.MONEDA;
                            break;
                        default:
                            break;
                    }
                }

                if (itemPago.MON == itemPago.MON_OP)
                {
                    itemPago.IMPORTE_OP = itemPago.IMPORTE;
                }
                else
                {
                    //esto no lo voy a hacer ahora pero hay que convertir
                    //el importe del item al importe de la orden de pago
                }

                itemPago.IDITEM = db.T0212_OP_ITEM.Max(c => c.IDITEM) + 1;
                db.T0212_OP_ITEM.Add(itemPago);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Remueve la factura de la OP - Si tiene retenciones la elimina de T0405 tambien
        /// </summary>
        public bool RemoveFacturaAPagarOP(int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataOP = db.T0213_OP_FACT.SingleOrDefault(c => c.IDITEM == idItem);
                if (dataOP.T0210_OP_H.TIPO == "L1")
                {
                    new MngRetencionesFacturasProv().RemoveRetencionFromT0405(dataOP.IdCtaCte.Value, dataOP.IDOP);
                }
                db.T0213_OP_FACT.Remove(dataOP);
                return db.SaveChanges() > 0;
            }
        }
        public bool RemoveItemOrdenPago(int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0212_OP_ITEM.SingleOrDefault(c => c.IDITEM == idItem);
                if (item == null)
                    return false;

                if (item.CH_CK)
                {
                    if (item.CH_ID != -5)
                        new ChequesManager().LiberaCheque(item.CH_ID.Value);
                }
                else
                {
                    if (item.CUENTA_O == "OPCRED")
                    {
                        RemoveOPCred(item.CH_ID.Value, item.IMPORTE.Value);
                    }

                    if (item.CUENTA_O == "NCA")
                    {
                        RemoveNotaCredito(item.CH_ID.Value, item.IMPORTE.Value);
                    }

                    if (item.CUENTA_O == "NC2")
                    {
                        RemoveNotaCredito(item.CH_ID.Value, item.IMPORTE.Value);
                    }


                }

                db.T0212_OP_ITEM.Remove(item);
                return db.SaveChanges() > 0;
            }
        }
        public bool CheckifAllChequesAreAvailable()
        {
            var dispo = true;
            var dataItem = new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.T0150_CUENTAS.CUENTA_TIPO == "CHE");
            foreach (var item in dataItem)
            {
                var dataCheque = new TecserData(GlobalApp.CnnApp).T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == item.CH_ID);
                if (dataCheque == null)
                {
                    dispo = false;
                }
                else if (dataCheque.DISPONIBLE == false)
                {
                    dispo = false;
                }
            }
            return dispo;
        }
    }

}
