using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class CustomerNcdAjustes
    {
        public struct ReturnContaAjuste
        {
            //estructura de retorno
            public int IdH;
            public int IdCtaCte;
            public bool DocumentoEncontrado;
            public ManageDocumentType.TipoDocumento TipoDoc;
            public int NumeroAsientoIdDocu;
            public decimal NumeroAsientoX1X2;
            public string NumeroDocumentoCompleto;
        }

        protected ReturnContaAjuste VarRtn = new ReturnContaAjuste();
        private int GetSignoCtaCte(ManageDocumentType.TipoDocumento tdoc, decimal importe)
        {
            if (importe < 0)
                return 1;

            switch (tdoc)
            {
                case ManageDocumentType.TipoDocumento.FacturaVentaA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVentaA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoVentaA:
                    return -1;
                case ManageDocumentType.TipoDocumento.ReciboCobranza:
                    break;
                case ManageDocumentType.TipoDocumento.Remito:
                    break;
                case ManageDocumentType.TipoDocumento.OrdenPago:
                    break;
                case ManageDocumentType.TipoDocumento.OrdenCompra:
                    break;
                case ManageDocumentType.TipoDocumento.NoDefinido:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVenta2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVenta2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoVenta2:
                    return -1;
                case ManageDocumentType.TipoDocumento.TransferenciaEC:
                    break;
                case ManageDocumentType.TipoDocumento.Cobranza:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaGastosConRemito:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaGastosSinRemito:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedorA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedorA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedor2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedor2:
                    break;
                case ManageDocumentType.TipoDocumento.AjusteSaldoPositivo:
                    break;
                case ManageDocumentType.TipoDocumento.AjusteSaldoNegativo:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVentaB:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVentaM:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoClientesB:
                    return -1;
                case ManageDocumentType.TipoDocumento.NotaCreditoClientesM:
                    return -1;
                case ManageDocumentType.TipoDocumento.NotaDebitoClientesB:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoClientesM:
                    break;
                case ManageDocumentType.TipoDocumento.AjusteContable:
                    break;
                case ManageDocumentType.TipoDocumento.DebitoNoFiscalCli:
                    return 1;
                case ManageDocumentType.TipoDocumento.CreditoNoFiscalCli:
                    return -1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tdoc), tdoc, null);
            }
            return 1;
        }

        public int UpdateCtaCteDesdeNCD(int idNcd)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNcd);
                if (header == null)
                    return -1;

                var xTdoc = ManageDocumentType.GetTipoDocumentoFromTdocString(header.TDOC, header.LX);
                decimal importeArs = 0;
                decimal importeOrigen = 0;

                if (header.MON == @"ARS")
                {
                    importeOrigen = header.ImporteARS;
                    importeArs = importeOrigen;
                }
                else
                {
                    importeOrigen = header.ImporteUSD;
                    importeArs = Math.Round(importeOrigen * header.TC, 2);
                }

                //----------------------------------------------------------------------------------
                var signo = GetSignoCtaCte(xTdoc, importeArs);
                var cc = new CtaCteCustomer(header.IdCliente);

                //T201
                int idCtaCte = 0;
                if (header.idFacturaT0400 == null)
                {
                    //Documento no tiene registro en T0400
                    idCtaCte = cc.AddCtaCteDetalleRecord(header.TDOC, header.LX, header.FECHA, header.NDOC,
                    idNcd.ToString(), header.MON, importeOrigen * signo, header.TC, importeOrigen * signo, importeArs, idNcd);
                }
                else
                {
                    idCtaCte = cc.AddCtaCteDetalleRecord(header.TDOC, header.LX, header.FECHA, header.NDOC,
                        header.idFacturaX.ToString(), header.MON, importeOrigen * signo, header.TC, importeOrigen * signo, importeArs, idNcd, header.idFacturaT0400.Value);
                }
                //T202
                cc.UpdateSaldoCtaCteResumen(header.LX, importeOrigen, header.MON, header.TC);
                if (importeArs * signo > 0)
                {
                    //Importe + --> T0207
                    cc.AddRecordDocumentT0207FromIdCtaCte(idCtaCte);
                }
                else
                {
                    //Importe - --> T020
                    new CobranzaNoImputada().AddSinImputarRecord(idCtaCte);
                }
                return idCtaCte;
            }
        }


        public ReturnContaAjuste ContabilizaCompletoAjuste(int idH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var HNcd = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
                var INcd = db.T0301_NCD_I.FirstOrDefault(c => c.IDH == idH); //Contempla solo 1 Item
                VarRtn.IdH = idH;
                VarRtn.TipoDoc = ManageDocumentType.TipoDocumento.AjusteContable;
                VarRtn.NumeroDocumentoCompleto = HNcd.NDOC;

                var DataCtaCte = new CtaCteCustomer(HNcd.IdCliente);
                decimal importaARS;
                decimal importeOrigen;

                if (HNcd.MON == "ARS")
                {
                    importeOrigen = HNcd.ImporteARS;
                    importaARS = importeOrigen;
                }
                else
                {
                    importeOrigen = HNcd.ImporteUSD;
                    importaARS = importeOrigen * HNcd.TC;
                }

                //Registros T201
                VarRtn.IdCtaCte = DataCtaCte.AddCtaCteDetalleRecord(HNcd.TDOC, HNcd.LX, HNcd.FECHA, HNcd.NDOC,
                    HNcd.IDH.ToString(), HNcd.MON, importeOrigen, HNcd.TC, importeOrigen, importaARS, HNcd.IDH);

                //Update Saldo Cliente T0202
                DataCtaCte.UpdateSaldoCtaCteResumen(HNcd.LX, importeOrigen, HNcd.MON, HNcd.TC);


                //visualizar si es lo mismo un ajuste que un traspaso! nooo
                if (importaARS > 0)
                {
                    //Se comporta como una facturacion
                    DataCtaCte.AddRecordDocumentT0207FromIdCtaCte(VarRtn.IdCtaCte);
                }
                else
                {
                    //Se comporta como una cobranza
                    new CobranzaNoImputada().AddSinImputarRecord(VarRtn.IdCtaCte);
                }

                var resultadoAsiento =
                    new AsientoGenerico(GlobalApp.Tcode).CreaAsientoAjusteCtaCte(HNcd.TDOC, HNcd.FECHA, HNcd.IdCliente,
                        HNcd.LX, importeOrigen, HNcd.TC, HNcd.NDOC, HNcd.COMENTARIO, INcd.GL, HNcd.MON);

                if (resultadoAsiento == null)
                {
                    //Atencion capturar porque se paso mal el tipo de documento!
                }
                else
                {
                    VarRtn.NumeroAsientoIdDocu = resultadoAsiento.Value.IdDocu;
                    HNcd.idCtaCte = VarRtn.IdCtaCte;
                    new CustomerNcdAjustes().UpdateNCDHAfterConta(idH, resultadoAsiento.Value.IdDocu,
                        VarRtn.IdCtaCte);
                }
            }

            return VarRtn;
        }


        //Funcion Grabacion de HeaderData Ajuste de Saldos
        public int GrabaT0300HeaderData(int idNcd, DateTime fecha, int idCliente, string lx, string motivo,
            string moneda, decimal importeMoneda, string tDoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h1 = new T0300_NCD_H()
                {
                    IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1,
                    FECHA = fecha,
                    IdCliente = idCliente,
                    LX = lx,
                    idCtaCte = 0,
                    COMENTARIO = motivo,
                    MON = moneda,
                    LOGDATE = DateTime.Now,
                    LOGUSER = GlobalApp.AppUsername,
                    RazonSocial = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial,
                    TC = new ExchangeRateManager().GetExchangeRate(fecha),
                    ASIENTO = null,
                    NDOC = GetMaxDocument(ManageDocumentType.TipoDocumento.AjusteSaldoPositivo, lx),
                    TDOC = tDoc,
                    TEMP = true,
                    idFacturaT0400 = null,
                    idFacturaX = null
                };
                if (h1.TC == 0)
                    h1.TC = 1;

                if (moneda == "ARS")
                {
                    h1.ImporteARS = importeMoneda;
                    h1.ImporteUSD = importeMoneda / h1.TC;
                }
                else
                {
                    h1.ImporteUSD = importeMoneda;
                    h1.ImporteARS = importeMoneda * h1.TC;
                }

                db.T0300_NCD_H.Add(h1);
                //db.SaveChanges();
                return db.SaveChanges() > 0 ? h1.IDH : 0;
            }
        }

        public int GrabaT300HeaderData(T0300_NCD_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == header.IDH);
                if (data == null)
                {
                    header.TEMP = false;
                    header.IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1;
                    header.NDOC = GetMaxDocument(ManageDocumentType.TipoDocumento.AjusteSaldoPositivo, header.LX);
                    header.LOGUSER = GlobalApp.AppUsername;
                    header.LOGDATE = DateTime.Now;
                    db.T0300_NCD_H.Add(header);
                    db.SaveChanges();
                    return header.IDH;
                }
                else
                {
                    //var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == header.IDH);
                    header.LOGUSER = GlobalApp.AppUsername;
                    header.LOGDATE = DateTime.Now;
                    db.Entry(data).CurrentValues.SetValues(header);
                    db.SaveChanges();
                    return header.IDH;
                }
            }
        }

        public void UpdateNCDHAfterConta(int idh, int numeroAsiento, int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                data.ASIENTO = numeroAsiento;
                data.idCtaCte = idCtaCte;
                db.SaveChanges();
            }
        }

        public int AddItemAjusteContableNCD(T0301_NCD_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0301_NCD_I.SingleOrDefault(c => c.IDH == item.IDH);
                if (x != null)
                {
                    db.T0301_NCD_I.Remove(x);
                    db.SaveChanges();
                }

                var header = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == item.IDH);
                item.TDOC = header.TDOC;
                item.NDOC = header.NDOC;
                db.T0301_NCD_I.Add(item);
                return db.SaveChanges();
            }
        }

        public int AddNcdItem(int idH, string item, string moneda, decimal importe, string gl)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataHeader = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
                string descripcion;
                if (item == "AJCONTA")
                {
                    descripcion = "Ajuste Contable de Saldos A/R";
                }
                else
                {
                    //buscar la descripcion de tabla T0010?
                    descripcion = null;
                }

                var data = new T0301_NCD_I()
                {
                    IDH = idH,
                    CANT = 1,
                    IDITEM = 1,
                    IVA21 = false,
                    TDOC = dataHeader.TDOC,
                    NDOC = dataHeader.NDOC,
                    Descripcion = descripcion,
                    ITEM = "AJCONTA",
                    MON = moneda,
                    PUNITARIO = importe,
                    PTOTAL = importe,
                    GL = gl
                };
                db.T0301_NCD_I.Add(data);
                return db.SaveChanges();
            }
        }

        private string GetMaxDocument(ManageDocumentType.TipoDocumento tdoc, string tipoLx)
        {
            var tipoD = ManageDocumentType.GetSystemDocumentType(tdoc);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var y = db.T0300_NCD_H.Where(c => c.TDOC == tipoD && c.LX == tipoLx).OrderByDescending(c => c.IDH)
                    .ToList();
                if (y.Any() == false)
                {
                    return tipoLx == "L1" ? "0091-00000001" : "0092-00000001";
                }
                else
                {
                    var x = y[0].NDOC;
                    string pre;
                    if (tipoLx == "L1")
                    {
                        pre = "0091";
                    }
                    else
                    {
                        pre = "0092";
                    }

                    //var pre = x.Substring(0, 4);
                    var num = x.Substring(x.Length - 8);
                    var numX = Convert.ToInt32(num) + 1;
                    return pre + "-" + numX.ToString("00000000");
                }
            }
        }
    }
}