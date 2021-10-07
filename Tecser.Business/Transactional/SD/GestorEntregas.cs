using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class GestorEntregas
    {
        public void AsignaTipoEntregaARemito(int idRemito, TipoEntregaStatusManager.TipoEntrega tipoEntrega, DateTime? fechaEntrega = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = new T0059_ENTREGAS();
                var remito = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (remito == null)
                    return;

                var dataEntrega = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == idRemito);
                if (dataEntrega == null)
                {
                    x.ClienteEntrega = remito.T0007_CLI_ENTREGA.ClienteEntregaDesc;
                    if (remito.T0007_CLI_ENTREGA.ClienteEntregaDesc.Length >= 30)
                        x.ClienteEntrega = remito.T0007_CLI_ENTREGA.ClienteEntregaDesc.Substring(0, 29);
                    x.ClienteId = remito.CODCLIENTREGA;
                    x.NumeroRemito = remito.NUMREMITO;
                    x.ClienteRazonSocial = remito.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;

                    if (fechaEntrega == null)
                        fechaEntrega = DateTime.Today;

                    x.FechaEntrega = fechaEntrega;
                    x.idRemito = idRemito;
                    x.TipoEntrega = tipoEntrega.ToString();
                    x.StatusEntrega = TipoEntregaStatusManager.TipoEntrega.SinAsignar.ToString();
                    db.T0059_ENTREGAS.Add(x);
                }
                else
                {
                    if (fechaEntrega == null)
                        fechaEntrega = DateTime.Today;

                    dataEntrega.FechaEntrega = fechaEntrega;
                    dataEntrega.TipoEntrega = tipoEntrega.ToString();
                }
                db.SaveChanges();
                var dataEntrega0 = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == idRemito);
                remito.IDFLETE = dataEntrega0.IdEntregas;
                db.SaveChanges();

            }
        }
        public TipoEntregaStatusManager.TipoEntrega GetTipoEntregaAsignada(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == idRemito);
                if (data == null)
                    return TipoEntregaStatusManager.TipoEntrega.SinAsignar;
                return TipoEntregaStatusManager.MapStatus(data.TipoEntrega);
            }
        }
        public List<T0059_ENTREGAS> GetListEntregasPorTipo(bool[] ckstatus, string numeroRemito = null, int idCliente = 0, int top = 30)
        {
            var filterList = new TipoEntregaStatusManager().CompletaStatusList(ckstatus);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCliente == 0)
                {
                    if (string.IsNullOrEmpty(numeroRemito))
                    {
                        //solo por tipo de entrega
                        var lista = (from entregas in db.T0059_ENTREGAS
                                     where filterList.Contains(entregas.TipoEntrega)
                                     orderby entregas.IdEntregas descending
                                     select entregas).Take(top).ToList();

                        return lista;
                    }
                    else
                    {
                        //por tipo de entrega y numero de remito
                        var lista = (from entregas in db.T0059_ENTREGAS
                                     where filterList.Contains(entregas.TipoEntrega) && entregas.NumeroRemito.Contains(numeroRemito)
                                     orderby entregas.IdEntregas descending
                                     select entregas).Take(top).ToList();

                        return lista;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(numeroRemito))
                    {
                        //por cliente
                        var lista = (from entregas in db.T0059_ENTREGAS
                                     where filterList.Contains(entregas.TipoEntrega) && entregas.ClienteId == idCliente
                                     orderby entregas.IdEntregas descending
                                     select entregas).Take(top).ToList();

                        return lista;
                    }
                    else
                    {
                        var lista = (from entregas in db.T0059_ENTREGAS
                                     where filterList.Contains(entregas.TipoEntrega) && entregas.ClienteId == idCliente && entregas.NumeroRemito.Contains(numeroRemito)
                                     orderby entregas.IdEntregas descending
                                     select entregas).Take(top).ToList();

                        return lista;
                    }
                }
            }
        }
        public List<T0059_ENTREGAS> GetListEntregasSinRutaAsignada(string numeroRemito = null)
        {
            const int top = 100;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(numeroRemito))
                {
                    //solo por tipo de entrega
                    var lista = (from entregas in db.T0059_ENTREGAS
                                 where entregas.IdRutaAsignada == null || entregas.IdRutaAsignada == 0
                                 orderby entregas.IdEntregas descending
                                 select entregas).Take(top).ToList();

                    return lista;
                }
                else
                {
                    //por tipo de entrega y numero de remito
                    var lista = (from entregas in db.T0059_ENTREGAS
                                 where (entregas.IdRutaAsignada == null || entregas.IdRutaAsignada == 0) && entregas.NumeroRemito.Contains(numeroRemito)
                                 orderby entregas.IdEntregas descending
                                 select entregas).Take(top).ToList();

                    return lista;
                }
            }
        }
        private int GetIdItemEntrega(int idRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).ToList();
                if (x.Count == 0)
                    return 1;
                return x.Count + 1;
            }
        }
        public int UpdateRemitoToRuta(int idRuta, int idItem, string comentario = null, bool entregaMuestra = false,
            bool retiraPago = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var data = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == idRuta && c.IdItem == idItem);
                if (data == null)
                    return 0;

                data.EntregaMuestra = entregaMuestra;
                data.RetiraPago = retiraPago;
                data.Observacion = comentario;
                db.SaveChanges();
                return 1;
            }

        }
        public int AddRemitoToRuta(int idRuta, int idEntrega, string comentario = null, bool entregaMuestra = false,
             bool retiraPago = false, int order = 0)
        {



            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var data = db.T0059_ENTREGAS.SingleOrDefault(c => c.IdEntregas == idEntrega);
                if (data == null)
                    return 0;

                data.IdRutaAsignada = idRuta;
                data.StatusEntrega = EntregaStatusManager.Status.EnRuta.ToString();
                db.SaveChanges();

                var idRemito = data.idRemito;
                var remData = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                var cliente = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito)
                        .T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                var clienteE = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito).T0007_CLI_ENTREGA;

                var dataI = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).ToList();

                if (order == 0)
                {
                    order = dataI.Count + 1;
                }

                var x = new T0059_HOJARUTA_I
                {
                    CantidadBultos = remData.CANTBULTOS,
                    CargoCliente = false,
                    ClienteRazonSocial = cliente,
                    DireccionCompleta = clienteE.Direccion_Entrega + " " + clienteE.DireEntre_Localidad,
                    EntregaMuestra = entregaMuestra,
                    IdItem = GetIdItemEntrega(idRuta),
                    IdRemito = idRemito,
                    IdRuta = idRuta,
                    KgEntregados = 0,
                    NumeroRemito = remData.NUMREMITO,
                    RetiraPago = retiraPago,
                    Observacion = comentario,
                    Prorrateo = 0,
                    StatusEntrega = HojaRutaStatusManager.StatusItem.NoEntregado.ToString(),
                };

                x.OrdenEntrega = order;

                db.T0059_HOJARUTA_I.Add(x);
                return db.SaveChanges() > 0 ? x.IdItem : 0;
            }
        }
        public void DeleteRemitoRuta(int idRuta, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == idRuta && c.IdItem == idItem);
                var idRemito = data.IdRemito;

                var entrega = db.T0059_ENTREGAS.SingleOrDefault(c => c.idRemito == idRemito);
                entrega.IdRutaAsignada = null;
                entrega.StatusEntrega = EntregaStatusManager.Status.SinAsignar.ToString();

                db.T0059_HOJARUTA_I.Remove(data);
                db.SaveChanges();
                reasignaOrder(idRuta);
            }
        }

        private void reasignaOrder(int idRuta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0059_HOJARUTA_I.Where(c => c.IdRuta == idRuta).OrderBy(c => c.OrdenEntrega).ToList();
                int newORder = 1;
                foreach (var item in data)
                {
                    item.OrdenEntrega = newORder;
                    newORder++;
                }
                db.SaveChanges();
            }
        }

    }
}
