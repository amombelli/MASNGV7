using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{

    /// <summary>
    /// 2018.03.11 En esta clase de asiento generico que deriva de asiento contable base iran todos los asientos que no son
    /// ni de customer ni de vendors..
    /// </summary>
    public class AsientoGenerico : AsientoBase
    {
        public AsientoGenerico(string transactionCode)
            : base(transactionCode)
        {
            //
        }

        public IdentificacionAsiento? CreaAsientoAjusteCtaCte(string tDoc, DateTime fechaDoc, int idCliente, string lX, decimal importeMoneda, decimal tc, string numeroDocumento, string observacionAjuste, string glResultado, string monedaRegistracion = "ARS")
        {
            var glAR = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
            if (tc <= 0)
                tc = new ExchangeRateManager().GetExchangeRate(fechaDoc);

            decimal importeArs = monedaRegistracion == "ARS" ? importeMoneda : Decimal.Round(importeMoneda / tc, 2);
            var importeRegistracion = monedaRegistracion != "ARS" ? decimal.Round((importeArs / tc), 2) : importeArs;
            var tdoc = tDoc; //por el momento es AJ para identifcar todos los ajustes
            string descripcion1;
            string razonSocial = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial;
            string tipoX = lX;
            DebeHaber dh;

            if (importeArs > 0)
            {
                //Ajuste positivo => Facturacion
                dh = DebeHaber.Debe;
                descripcion1 = "Ajuste Contable +";
            }
            else
            {
                //Ajuste negativo => Cobranza
                dh = DebeHaber.Haber;
                descripcion1 = "Ajuste Contable -";
            }

            base.CreaHeaderMemoria(tipoX, fechaDoc, tdoc, numeroDocumento, observacionAjuste, monedaRegistracion,
                importeRegistracion, tc, Math.Abs(importeArs));

            //Segmento A/R
            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, glAR, descripcion1, observacionAjuste,
                monedaRegistracion, dh, Math.Abs(importeRegistracion), Tcode, idCliente);

            //Segmento Resultado
            dh = dh == DebeHaber.Debe ? DebeHaber.Haber : DebeHaber.Debe;
            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, glResultado, descripcion1, observacionAjuste,
                monedaRegistracion, dh, Math.Abs(importeRegistracion), Tcode, idCliente);
            return GrabaAsiento();
        }

        /// <summary>
        /// Traspaso de Saldos entre cuentas
        /// Opcion de traspaso entre clientes (mismo LX) o Traspaso en mismo cliente (LX1 -> LX2)
        /// No se tendria que permitir en un solo paso pasar de cliente1 - a cliente 2 cambiando los tipos
        /// </summary>
        public IdentificacionAsiento? CreaAsientoTraspasoSaldos(string tipoAjuste, DateTime fechaDoc, int idCliente,
            string tipoLxOrigen, int idClienteAlternativo, string tipoLxDestino, decimal importeARS, decimal tc, string numeroDocumento, string descripcion2, string monedaRegistracion = "ARS")
        {
            var gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
            var importeRegistracion = monedaRegistracion != "ARS" ? decimal.Round((importeARS / tc), 2) : importeARS;
            var tdoc = tipoAjuste;
            string descripcion1 = null;
            var clienteDesc = new CustomerManager().GetCustomerBillToData(idClienteAlternativo).cli_rsocial;
            DebeHaber dh;
            string tipoX;
            switch (tipoAjuste)
            {
                case "AJN":
                    dh = DebeHaber.Haber;
                    tipoX = tipoLxOrigen;
                    if (tipoLxOrigen == tipoLxDestino)
                    {
                        //Es Traspaso entre diferentes clientes 
                        descripcion1 = "Movimiento Saldo Hacia: " + clienteDesc + "[" + tipoLxDestino + "]";
                    }
                    else
                    {
                        //Es Traspaso entre cuentas de mismo cliente
                        descripcion1 = "Movmiento Saldo Hacia cuenta [" + tipoLxDestino + "]";
                    }
                    break;
                case "AJP":
                    //Es el que recibo el saldo
                    dh = DebeHaber.Debe;
                    tipoX = tipoLxDestino;
                    if (tipoLxOrigen == tipoLxDestino)
                    {
                        //Es Traspaso entre diferentes clientes
                        descripcion1 = "Movimiento Saldo Desde: " + clienteDesc + "[" + tipoLxOrigen + "]";
                    }
                    else
                    {
                        //Es Traspaso entre cuentas de mismo cliente
                        descripcion1 = "Movmiento Saldo Desde cuenta [" + tipoLxOrigen + "]";
                    }
                    break;
                default:
                    //El tipo de documento solo podra ser AJUSTE NEGATIVO o AJUSTE POSITIVO
                    return null;
            }

            base.CreaHeaderMemoria(tipoX, fechaDoc, tdoc, numeroDocumento, descripcion2, monedaRegistracion,
                importeRegistracion, tc, importeARS);

            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, gl, descripcion1, descripcion2,
                monedaRegistracion, dh, importeRegistracion, Tcode, idCliente);

            dh = dh == DebeHaber.Debe ? DebeHaber.Haber : DebeHaber.Debe;
            gl = "4.1.4.1";
            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, gl, descripcion1, descripcion2,
                monedaRegistracion, dh, importeRegistracion, Tcode, idCliente);



            return GrabaAsiento();
        }

        /// <summary>
        /// Asiento de Reingreso de Cheque a Cartera SIN ND
        /// </summary>
        public IdentificacionAsiento AsientoReingresoACarteraSinNd(int idCheque, int idTracker, string motivoReingreso,
            string tipoLx, decimal importeGastos = 0, decimal importeIva = 0)
        {

            var dataCheque = new ChequesManager().GetCheque(idCheque);
            var importeTotal = dataCheque.IMPORTE.Value + importeGastos + importeIva;
            var xrate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            var glGasto = "5.6.6";
            var glIVA = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaCompra21);
            var gl1 = "0.0.0.0"; //GLAP o GLCYB
            var gl2 = new CuentasManager().GetGL("CHE"); //Gl cuenta destino (reingreso a CHE)
            var trackerInfo = new ChequeRechazadoManager().GetTracker(idTracker);

            if (trackerInfo.Origen == "EnBanco")
            {
                //Cheque estaba en entidad financiera -- GL es de cuenta de Entidad Bancaria **C21
                gl1 = new CuentasManager().GetGL(dataCheque.PROVEEDOR);
            }
            else
            {
                if (trackerInfo.Origen == "EnProveedor")
                {
                    //Cheque estaba en proveedor //EnProveedor
                    gl1 = new GLAccountManagement().GetApVendorGl(dataCheque.IdProveedorSalida.Value);
                }
                else
                {
                    //Situacion de Error.
                    return new IdentificacionAsiento()
                    {
                        IdDocu = -1,
                        NasX1 = 0,
                        NasX2 = 0
                    };
                }
            }

            base.CreaHeaderMemoria(tipoLx, DateTime.Today, "CHR", trackerInfo.DocumentoRef,
                "REING:" + motivoReingreso, dataCheque.MONEDA, importeTotal, xrate);

            base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, gl1,
                "Reingreso Cartera  @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Haber,
                dataCheque.IMPORTE.Value, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);

            if (importeGastos > 0)
            {
                //Es Raro en un Reingreso los con Gastos pero lo consideramos
                base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, gl1,
                    "Reingreso Cartera - Gs Rechazo @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Haber,
                    importeGastos, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                    idNumerico: idCheque);
            }

            if (importeIva > 0)
            {
                //Es Raro en un Reingreso IVA de Gastos pero lo consideramos
                base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, gl1,
                    "Reingreso Cartera - Gs IVA @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Haber,
                    importeIva, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                    idNumerico: idCheque);
            }


            base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, gl2,
                "Reingreso Cartera  @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Debe,
                dataCheque.IMPORTE.Value, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);

            if (importeGastos > 0)
            {
                //Es Raro en un Reingreso los con Gastos pero lo consideramos
                base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, glGasto,
                    "Reingreso Cartera - Gs Rechazo @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Debe,
                    importeGastos, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                    idNumerico: idCheque);
            }

            if (importeIva > 0)
            {
                //Es Raro en un Reingreso IVA de Gastos pero lo consideramos
                base.AddGenericCompleteSegment("CHR", trackerInfo.DocumentoRef, tipoLx, glIVA,
                    "Reingreso Cartera - Gs IVA @" + idCheque, motivoReingreso, dataCheque.MONEDA, DebeHaber.Debe,
                    importeIva, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                    idNumerico: idCheque);
            }
            return GrabaAsiento();
        }


        /// <summary>
        /// Asiento de Retorno de Cheque a Cliente sin Rechazo
        /// Gastos + Importe Cheque a A/R
        /// </summary>
        public IdentificacionAsiento AsientoDevolucionChequeAClienteSr(int idNcdH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNcdH);
                var i = db.T0301_NCD_I.Where(c => c.IDH == idNcdH).ToList();
                decimal ImporteIVA = 0;
                string dataCheque = null;
                base.CreaHeaderMemoria(h.LX, h.FECHA, "CHR", h.NDOC, @"RTNCH-" + h.COMENTARIO, "ARS", h.ImporteARS,
                    h.TC);
                foreach (var ix in i)
                {
                    string Descripcion2 = null;
                    if (ix.ITEM == "ZCHRECH")
                    {
                        Descripcion2 = @"IDCHEQUE=" + ix.IDCHE;
                        dataCheque = ix.Descripcion;
                    }

                    base.AddGenericCompleteSegment("CHR", h.NDOC, h.LX, ix.GL, ix.Descripcion, Descripcion2, h.MON,
                        DebeHaber.Debe, ix.PTOTAL, "CHR", h.IdCliente, nombreTabla: "T0301_NCD_H", idNumerico: idNcdH);
                    ImporteIVA += ix.PIVA;
                }

                if (ImporteIVA > 0)
                {
                    var glIVA = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaVenta21);
                    base.AddGenericCompleteSegment("CHR", h.NDOC, h.LX, glIVA, "IVA 21% - Gastos Bancarios", "", h.MON,
                        DebeHaber.Debe, ImporteIVA, "CHR", h.IdCliente, nombreTabla: "T0301_NCD_H", idNumerico: idNcdH);
                }

                //Haber --> Cuenta A/R Cliente
                var glAR = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
                base.AddGenericCompleteSegment("CHR", h.NDOC, h.LX, glAR, "Devolucion Cheque", dataCheque, h.MON,
                    DebeHaber.Haber, h.ImporteARS, "CHR", h.IdCliente, nombreTabla: "T0301_NCD_H", idNumerico: idNcdH);
                return GrabaAsiento();
            }
        }


        /// <summary>
        /// Asiento Cheque Rechzado Desde Entidad Financiera o Desde Proveedor
        /// Caso Proveedor -> GLAP - Caso Entidad es GLCuenta
        /// </summary>
        public IdentificacionAsiento CreaAsientoChequeRechazado(int idCheque, string motivoRechazo, string glAP_glCuentaCyB,
            DateTime fechaRechazo, decimal importeGastos, decimal importeIva, string tipoLx = null)
        {
            //Importe Cheque 'Banco o AP' D
            //Importe Gastos 'Banco o AP' D
            //Importe Cheque 'GL Cheque' H
            //Importe Gastos 'IVA, etc' H
            var dataCheque = new ChequesManager().GetCheque(idCheque);
            var importeTotal = dataCheque.IMPORTE.Value + importeGastos + importeIva;
            var xrate = new ExchangeRateManager().GetExchangeRate(fechaRechazo);
            var numeroDocumento = "CHRE@" + idCheque.ToString("D8");
            var glGastos = "5.6.6";
            var glIVA = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaCompra21);
            var glChequeRechazado = "1.0.0.8";

            if (tipoLx == null)
            {
                tipoLx = dataCheque.TIPOSAL;
            }

            base.CreaHeaderMemoria(tipoLx, fechaRechazo, "CHR", numeroDocumento,
                "CH.Rech-" + motivoRechazo, dataCheque.MONEDA, importeTotal, xrate);

            //Agrupa en Haber Importe de Cheque + Importe Gastos 

            base.AddGenericCompleteSegment("CHR", numeroDocumento, tipoLx, glAP_glCuentaCyB,
                "Debito x Cheque Rechazado@" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Haber,
                importeTotal, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);


            //Debe
            base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glChequeRechazado,
                "Rechazo de Cheque @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                dataCheque.IMPORTE.Value, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);

            if (importeGastos > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glGastos,
                    "Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                    importeGastos, "CHR", dataCheque.IdClienteRecibido.Value);
            }

            if (importeIva > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glIVA,
                    "IVA Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                    importeIva, "CHR", dataCheque.IdClienteRecibido.Value);
            }
            return GrabaAsiento();
        }



        public IdentificacionAsiento CreaAsientoTransferenciaEC(int idRegister, string observacion = null)
        {
            TipoDocumento = ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.TransferenciaEC);
            var h = new TransferenciaEntreCuentasManager().GetHeaderTransferencia(idRegister);
            var listI = new TecserData(GlobalApp.CnnApp).XREGISTER_I.Where(c => c.IDINT == idRegister).ToList();

            string textoObservacion;

            if (string.IsNullOrEmpty(observacion))
            {
                textoObservacion = "Transf E/C Destino" + h.CUENTAD;
            }
            else
            {
                textoObservacion = observacion;
            }

            base.CreaHeaderMemoria(h.TIPO, h.FECHA.Value, TipoDocumento, h.REFNUM, textoObservacion, h.MONEDA,
                h.IMPORTE_TOTAL.Value, h.TC.Value);

            foreach (var i in listI)
            {
                AddSegmentoTransferenciaEC(i.CUENTA_O, i.CUENTA_D, h.TIPO, i.IMPORTE_D.Value, i.MONEDA, i.CHID);
            }
            return GrabaAsiento();
        }

        /// <summary>
        /// Agrega segmento de cuenta transferencia entre cuentas
        /// </summary>
        private void AddSegmentoTransferenciaEC(string cuentaCajaBancoOrigen, string cuentaCajaBancoDestino, string tipoLx, decimal importeMonedaTx, string monedaTransaccion, int? chequeId = null)
        {
            var dataOrigen = new CuentasManager().GetSpecificCuentaInfo(cuentaCajaBancoOrigen);
            var dataDestino = new CuentasManager().GetSpecificCuentaInfo(cuentaCajaBancoDestino);
            //
            var glo = new CuentasManager().GetGL(cuentaCajaBancoOrigen);
            var gld = new CuentasManager().GetGL(cuentaCajaBancoDestino);
            var monedaO = dataOrigen.CUENTA_MONEDA;
            var monedaD = dataDestino.CUENTA_MONEDA;
            string desc2 = null;
            string nombreTablaReferencia = null;

            //todo: si la moneda no coincide monedaO - monedaD --- convertir a monedaTransaccion los importes


            switch (cuentaCajaBancoOrigen)
            {
                case "CHE":
                    nombreTablaReferencia = "T0154_CHEQUES";
                    desc2 = "CHID@" + chequeId.ToString();
                    break;

                default:
                    nombreTablaReferencia = null;
                    desc2 = cuentaCajaBancoOrigen + ">>" + cuentaCajaBancoDestino;
                    break;
            }

            base.AddGenericCompleteSegment("TXS", base.Header.REFE, tipoLx, glo, "Tx Destino " + cuentaCajaBancoDestino, desc2,
                monedaTransaccion, DebeHaber.Haber, importeMonedaTx, base.Tcode, 0, 0, nombreTablaReferencia, chequeId);

            base.AddGenericCompleteSegment("TXE", base.Header.REFE, tipoLx, gld, "Tx Origen " + cuentaCajaBancoOrigen, desc2,
                monedaTransaccion, DebeHaber.Debe, importeMonedaTx, base.Tcode, 0, 0, nombreTablaReferencia, chequeId);
        }

    }
}
