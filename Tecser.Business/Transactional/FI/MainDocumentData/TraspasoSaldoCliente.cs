using System;
using System.Collections.Generic;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class TraspasoSaldoCliente
    {
        //---------------------------------------------------------------------------------------------------------------------------
        private List<T0300_NCD_H> _data300 = new List<T0300_NCD_H>();

        //---------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Genera documento traspaso saldos mismo tipo -> a diferente cliente
        /// ->Son 2 documentos AJN + AJP juntos
        /// </summary>
        public void GeneraDocumentoTraspasoADiferenteCliente(string tipoLx, int idClienteOri, int idClienteDest, DateTime fechaDoc,
            decimal tc, decimal importe, string comentario, string moneda = "ARS")
        {
            GeneraT300HeaderMemoria(tipoLx, idClienteOri, idClienteDest, importe, tc, fechaDoc, comentario, moneda);
            foreach (var item in _data300)
            {
                decimal signo;
                bool addRecordTo208 = false;
                var clienteAlternativo = 0;
                if (item.TDOC == "AJN")
                {
                    signo = -1;
                    clienteAlternativo = idClienteDest;
                    addRecordTo208 = true;
                }
                else
                {
                    signo = 1;
                    clienteAlternativo = idClienteOri;
                    addRecordTo208 = false;
                }
                var ncdH = new CustomerNcdAjustes().GrabaT300HeaderData(item);
                var gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
                new CustomerNcdAjustes().AddNcdItem(ncdH, "AJCONTA", item.MON, importe, gl);

                var ctacte = new CtaCteCustomer(item.IdCliente);
                var idCtaCte = ctacte.AddCtaCteDetalleRecord(item.TDOC, item.LX, item.FECHA,
                    item.NDOC, ncdH.ToString(), item.MON, item.ImporteARS * signo, item.TC, item.ImporteARS * signo,
                    item.ImporteARS * signo, ncdH);

                if (addRecordTo208)
                {
                    new CobranzaNoImputada().AddSinImputarRecord(idCtaCte);
                }
                else
                {
                    ctacte.AddRecordDocumentT0207FromIdCtaCte(idCtaCte);
                }
                ctacte.UpdateSaldoCtaCteResumen(item.LX, item.ImporteARS * signo, item.MON, item.TC);


                var resultadoAsiento =
                    new AsientoGenerico(GlobalApp.Tcode).CreaAsientoTraspasoSaldos(item.TDOC, fechaDoc, item.IdCliente, tipoLx, clienteAlternativo, tipoLx, importe, tc, item.NDOC,
                        comentario,
                        moneda);

                if (resultadoAsiento == null)
                {
                    //Atencion capturar porque se paso mal el tipo de documento!
                }
                else
                {
                    item.ASIENTO = resultadoAsiento.Value.IdDocu;
                    item.idCtaCte = idCtaCte;
                    new CustomerNcdAjustes().UpdateNCDHAfterConta(ncdH, item.ASIENTO.Value, item.idCtaCte.Value);
                }
            }
        }


        public void GeneraDocTraspasoEntreCuentas()
        {

        }

        public void GeneraDocTraspasoEntreTipos()
        {

        }


        /// <summary>
        /// Genera en memoria 2 documentos de ajuste uno Neg y otro POS
        /// </summary>
        private void GeneraT300HeaderMemoria(string tipoLx, int id6Ori, int id6Des, decimal importe, decimal tc,
            DateTime fechaDoc, string comentario, string moneda = "ARS")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Cliente Original Resta Deuda AJN
                var dataNegativo = new T0300_NCD_H()
                {
                    IDH = 0,
                    TDOC =
                        ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.AjusteSaldoNegativo),
                    NDOC = "0",
                    IdCliente = id6Ori,
                    MON = moneda,
                    RazonSocial = new CustomerManager().GetCustomerBillToData(id6Ori).cli_rsocial,
                    TC = tc,
                    FECHA = fechaDoc,
                    LOGDATE = DateTime.Now,
                    LOGUSER = Environment.UserName,
                    idCtaCte = 0,
                    ASIENTO = 0,
                    COMENTARIO = comentario,
                    LX = tipoLx,
                };

                if (moneda == "ARS")
                {
                    dataNegativo.ImporteARS = importe;
                    dataNegativo.ImporteUSD = decimal.Round(importe / tc, 2);
                }
                else
                {
                    dataNegativo.ImporteARS = decimal.Round(importe * tc, 2);
                    dataNegativo.ImporteUSD = importe;
                }
                _data300.Add(dataNegativo);

                //En Cliente Destino suma Saldo Positivo
                var dataPositivo = new T0300_NCD_H()
                {
                    IDH = 0,
                    TDOC =
                        ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.AjusteSaldoPositivo),
                    NDOC = "0",
                    IdCliente = id6Des,
                    MON = moneda,
                    RazonSocial = new CustomerManager().GetCustomerBillToData(id6Des).cli_rsocial,
                    TC = tc,
                    FECHA = fechaDoc,
                    LOGDATE = DateTime.Now,
                    LOGUSER = Environment.UserName,
                    idCtaCte = 0,
                    ASIENTO = 0,
                    COMENTARIO = comentario,
                    LX = tipoLx,
                };

                if (moneda == "ARS")
                {
                    dataPositivo.ImporteARS = importe;
                    dataPositivo.ImporteUSD = decimal.Round(importe / tc, 2);
                }
                else
                {
                    dataPositivo.ImporteARS = decimal.Round(importe * tc, 2);
                    dataPositivo.ImporteUSD = importe;
                }
                _data300.Add(dataPositivo);
            }
        }







    }
}
