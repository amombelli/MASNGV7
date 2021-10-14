using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class MopMapeo
    {
        public List<StxDocumentosNotInOperaciones> GetDocumentosNotMapped(DateTime fechaDesde)
        {
            var s = new List<StxDocumentosNotInOperaciones>();
            var remitosNot = new List<int>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from rem in db.T0055_REMITO_H
                    join op in db.T0140_MargenOperacion on rem.IDREMITO equals op.IdRemito into joinedT
                    from op in joinedT.DefaultIfEmpty()
                    where rem.StatusRemito == "IMPRESO" && rem.FECHA >= fechaDesde
                    select new
                    {
                        idR = rem.IDREMITO,
                        idr1 = op == null ? 999999 : op.IdRemito,
                        idFactura = rem.Factura ?? 0,
                        lx = rem.TIPO_REMITO,
                        numeroRemito = rem.NUMREMITO,
                        numeroDocumento = rem.NUMFACTURA,
                        fechaRemito = rem.FECHA,
                        moneda = "USD",
                        esLx = (rem.RLINK != null && rem.TIPO_REMITO == "L2") ? true : false,
                        IdCliente = rem.T0007_CLI_ENTREGA.T0006_MCLIENTES.IDCLIENTE,
                        RazonSocial = rem.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial
                    };
                var p3 = data.ToList();
                foreach (var ix in p3.Where(c => (c.idr1 == 999999) && c.esLx == false))
                {
                    var itemsR = db.T0056_REMITO_I.Where(c => c.IDREMITO == ix.idR).ToList();
                    foreach (var item in itemsR)
                    {
                        var si = new StxDocumentosNotInOperaciones()
                        {
                            item = item.MATERIAL,
                            cantidad = item.KGDESPACHADOS_R,
                            fechaRemito = ix.fechaRemito,
                            tipoLx = ix.lx,
                            numeroRemito = ix.numeroRemito,
                            moneda = ix.moneda,
                            idFactura = ix.idFactura,
                            idRemito = ix.idR,
                            idItem = -1,
                            precioU = 0,
                            precioT = 0,
                            numeroDocumento = "",
                            tipoDocumento = "",
                            RazonSocial = ix.RazonSocial,
                            idCliente = ix.IdCliente
                            
                        };
                        if (ix.idFactura >= 1)
                        {
                            var fac = db.T0401_FACTURA_I
                                .Where(c => c.IDFactura == ix.idFactura && c.ITEM == item.MATERIAL).ToList();
                            decimal kg = 0;
                            decimal pr0 = 0;
                            decimal preciou = 0;
                            foreach (var fit in fac)
                            {
                                kg += fit.KGDESPACHADOS_R.Value;
                                pr0 += (fit.KGDESPACHADOS_R.Value * fit.PRECIOU_FACT_USD);
                                si.numeroDocumento = fit.T0400_FACTURA_H.NumeroDoc;
                                si.tipoDocumento = fit.T0400_FACTURA_H.TIPO_DOC;
                                si.fechaDocumento = fit.T0400_FACTURA_H.FECHA;
                            }

                            si.idItem = fac[0].IDITEM;
                            if (kg != 0)
                            {
                                si.precioU = pr0 / kg;
                                si.precioT = pr0;
                            }
                            else
                            {
                                si.precioU = pr0;
                                si.precioT = pr0;
                            }
                        }

                        s.Add(si);
                    }
                }

                //secccion NC/ND
                var dataNc = from nc in db.T0300_NCD_H
                    join t400 in db.T0400_FACTURA_H
                        on nc.idFacturaT0400 equals t400.IDFACTURA into join1
                    join op in db.T0140_MargenOperacion on nc.IDH equals op.IdRemito into join2
                    from op in join2.DefaultIfEmpty()
                    where nc.FECHA > fechaDesde
                    select new
                    {
                        idR = nc.IDH,
                        idop = op == null ? 999999 : op.IdRemito,
                        idFactura = nc.idFacturaT0400 == null ? -1 : nc.idFacturaT0400.Value,
                        lx = nc.LX,
                        numeroNcD = nc.NDOC,
                        tipoDoc = nc.TDOC,
                        importe = nc.ImporteUSD,
                        fechaDoc = nc.FECHA,
                        motivo = nc.Motivo,
                        idCliente = nc.IdCliente,
                        RazonSocial = nc.RazonSocial
                    };
                var p4 = dataNc.ToList();
                foreach (var ix in p4.Where(c => (c.idop == 999999) && c.idFactura > 0))
                {
                    if (ix.importe > 0)
                    {
                        //ND
                        var dmotivo = new CustomerNd(-1).MapMotivoFromTextoToType(ix.motivo);
                        switch (dmotivo)
                        {
                            case CustomerNd.MotivoNotaDebito.AnulaDocumento:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.ChequeRechazado:
                                break;
                            case CustomerNd.MotivoNotaDebito.ChequeSinRechazo:
                                break;
                            case CustomerNd.MotivoNotaDebito.DiferenciaPrecio:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.DiferenciaCambio:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.DiferenciaKg:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.CargoGralDocumentos:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.CargoGralPeriodo:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNd.MotivoNotaDebito.GastoBancario:
                                break;
                            case CustomerNd.MotivoNotaDebito.SinMotivo:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        //Notas de Credito
                        var cmotivo = new CustomerNc().MapMotivoFromTextoToType(ix.motivo);
                        switch (cmotivo)
                        {
                            case CustomerNc.MotivoNotaCredito.AnulaDocumento:
                                s.AddRange(MapeoNcdValido(ix.idFactura,ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DevolucionMaterial:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DesGeneralDocumentos:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.DesGeneralPeriodo:
                                s.AddRange(MapeoNcdValido(ix.idFactura, ix.idR));
                                break;
                            case CustomerNc.MotivoNotaCredito.SinMotivo:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
            return s;
        }
        private List<StxDocumentosNotInOperaciones> MapeoNcdValido(int idFactura,int idncd )
        {
            var rtnList = new List<StxDocumentosNotInOperaciones>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemsF = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var item in itemsF)
                {
                    var si = new StxDocumentosNotInOperaciones()
                    {
                        item = item.ITEM,
                        cantidad = item.KGDESPACHADOS_R.Value,
                        fechaRemito = item.T0400_FACTURA_H.FECHA,
                        tipoLx = item.T0400_FACTURA_H.TIPOFACT,
                        numeroRemito = item.T0400_FACTURA_H.NumeroDoc,
                        moneda = "USD",
                        idFactura = idFactura,
                        idRemito =idncd,
                        idItem = item.IDITEM,
                        precioU = item.PRECIOU_FACT_USD,
                        precioT = item.PRECIOT_FACT_USD,
                        numeroDocumento = item.T0400_FACTURA_H.NumeroDoc,
                        fechaDocumento = item.T0400_FACTURA_H.FECHA,
                        tipoDocumento = item.T0400_FACTURA_H.TIPO_DOC,
                        RazonSocial = item.T0400_FACTURA_H.RAZONSOC,
                        idCliente = item.T0400_FACTURA_H.Cliente
                    };
                    rtnList.Add(si);
                }
            }
            return rtnList;
        }
        public List<int> GetListaRemitosSinMargen()
        {
            var r = new List<int>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fechaX = new DateTime(2021, 03, 01);
                var data = from rem in db.T0055_REMITO_H
                    join op in db.T0140_MargenOperacion on rem.IDREMITO equals op.IdRemito into joinedT
                    from op in joinedT.DefaultIfEmpty()
                    where rem.StatusRemito == "IMPRESO" && rem.FECHA >= fechaX
                    select new
                    {
                        idR = rem.IDREMITO,
                        idr1 = op == null ? 999999 : op.IdRemito
                    };
                var p3 = data.ToList();
                foreach (var c in p3.Where(c => c.idr1 == 999999))
                {
                    r.Add(c.idR);
                }
                return r;
            }
        }


    }
}
