using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class IngresoStockManager
    {
        public IngresoStockManager(int numeroOC, int numeroItem)
        {
            _numeroItem = numeroItem;
            _numeroOC = numeroOC;
            GetMaterialRecibido();
        }

        public IngresoStockManager()
        {

        }

        //--------------------------------------------------------------------------------------------------------------
        private readonly int _numeroOC;
        private readonly int _numeroItem;
        private string _materialRecibido;
        //--------------------------------------------------------------------------------------------------------------

        public T0063_ITEMS_OC_INGRESADOS GetitemIngresadoCompra(int id63)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == id63);
            }

        }
        private void GetMaterialRecibido()
        {
            _materialRecibido = new OrdenCompraManager().GetDataOCItem(_numeroOC, _numeroItem).MATERIAL;
        }
        public int NewManageIngresoConOrdenCompra(DateTime fechaRecibido, DateTime fechaRemitoReal, string numeroRemito,
            string recibidoPor, decimal kgRecibidos, string loteVendor, string loteTecser, string ubicacion, StockStatusManager.EstadoLote estadoStock,
            bool keepOpen, bool materialReproceso, string comentarioRecepcion)
        {
            UpdateOrdenCompra(kgRecibidos, keepOpen);
            var id63 = AddRecordT0063(fechaRecibido, fechaRemitoReal, numeroRemito, kgRecibidos, materialReproceso,
                recibidoPor);

            //Genera Ingreso de Stock T0030 + LOG T0040
            var id40 = new StockManager().AddNewStock_withLogT40(_materialRecibido, loteTecser, kgRecibidos, estadoStock,
                ubicacion, fechaRecibido, MmLog.TipoMovimiento.IngresoStockIc, id63.ToString(), "IC1", "LX",
                "OC#" + _numeroOC, referenciaNumerica: _numeroItem, comentarioMovimiento: comentarioRecepcion, nombreTablaReferencia: "T0063", referenciaTexto: id63.ToString());

            UpdateId40T0063(id63, id40);
            return id63;

        }
        private void UpdateOrdenCompra(decimal kgRecibidos, bool keepOpen)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ocI =
                    db.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == _numeroItem && c.ORDENCOMPRA == _numeroOC);
                if (ocI.CANTIDAD_RECIBIDA == null)
                    ocI.CANTIDAD_RECIBIDA = 0;

                ocI.CANTIDAD_RECIBIDA += kgRecibidos;
                db.SaveChanges();
                new OrdenCompraStatusManager().UpdateStatusItem(_numeroOC, _numeroItem, keepOpen);
            }
        }
        private int AddRecordT0063(DateTime fechaRecepcion, DateTime fechaRemito, string numeroRemito, decimal cantidadKg, bool materialReproceso, string recibidoPor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ocHeader = new OrdenCompraManager().GetDataOcHeader(_numeroOC);
                var ocItem = new OrdenCompraManager().GetDataOCItem(_numeroOC, _numeroItem);
                var data = new T0063_ITEMS_OC_INGRESADOS()
                {
                    ID = GetNextIdT0063(),
                    PROVEEDOR = ocHeader.PROVEEDOR,
                    PCUIT = ocHeader.T0005_MPROVEEDORES.NTAX1,
                    PRAZONSOCIAL = ocHeader.T0005_MPROVEEDORES.prov_rsocial,
                    FECHA_OC = ocHeader.FECHAOC,
                    NUM_OC = _numeroOC,
                    MON_OC = ocHeader.MONEDAOC,
                    IdItemOC = _numeroItem,
                    FECHA_IN = fechaRecepcion,
                    FechaRemitoReal = fechaRemito,
                    IDMATERIAL = _materialRecibido,
                    CANTIDAD = cantidadKg,
                    NREMITO = numeroRemito,
                    CONTA = false,
                    TIPO = "LX",
                    CONTA_CANT = 0,
                    REPRO = materialReproceso,
                    ID40 = 0,
                    ADDED = false,
                    PRECIO_U_ARS = ocItem.PRECIO_UNITARIO_P,
                    PRECIO_U_USD = ocItem.PRECIO_UNITARIO_D,
                    PRECIO_T_ARS = ocItem.PRECIO_UNITARIO_P * cantidadKg,
                    PRECIO_T_USD = ocItem.PRECIO_UNITARIO_D * cantidadKg,
                    RespControlRecepcion = recibidoPor,
                    ZINCLUIR = false,
                };
                db.T0063_ITEMS_OC_INGRESADOS.Add(data);
                db.SaveChanges();
                return data.ID;
            }
        }
        private int GetNextIdT0063()
        {
            return new TecserData(GlobalApp.CnnApp).T0063_ITEMS_OC_INGRESADOS.Max(c => c.ID) + 1;
        }
        private int AddRegistroIngresoItems0063(DateTime fechaRecepcion, DateTime fechaRemito, string numeroRemito, string materialTecser, decimal kgRecibidos, string responsableControlIngreso, bool materialRepro)
        {
            var item = new T0063_ITEMS_OC_INGRESADOS();
            var dataHeaderOC = new OrdenCompraManager().GetDataOcHeader(_numeroOC);

            item.ID = this.GetNextIdT0063();
            item.PROVEEDOR = dataHeaderOC.PROVEEDOR;
            item.PCUIT = dataHeaderOC.T0005_MPROVEEDORES.NTAX1;
            item.PRAZONSOCIAL = dataHeaderOC.T0005_MPROVEEDORES.prov_rsocial;
            item.FECHA_OC = dataHeaderOC.FECHAOC;
            item.NUM_OC = _numeroOC;
            item.FECHA_IN = fechaRecepcion;

            if (string.IsNullOrEmpty(materialTecser) == true)
            {
                //obtiene el material directamente de la orden de compra
                item.IDMATERIAL = dataHeaderOC.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == _numeroItem).MATERIAL;
            }
            else
            {
                item.IDMATERIAL = materialTecser;
            }

            item.CANTIDAD = kgRecibidos;
            item.MON_OC = dataHeaderOC.MONEDAOC;
            item.TC = dataHeaderOC.TC;
            item.PRECIO_U_ARS = dataHeaderOC.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == _numeroItem).PRECIO_UNITARIO_P;
            item.PRECIO_U_USD = dataHeaderOC.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == _numeroItem).PRECIO_UNITARIO_D;
            item.PRECIO_T_ARS = item.PRECIO_U_ARS * kgRecibidos;
            item.PRECIO_T_USD = item.PRECIO_U_USD * kgRecibidos;
            item.NREMITO = numeroRemito;
            item.CONTA = false;
            item.RespControlRecepcion = responsableControlIngreso;
            item.FechaRemitoReal = fechaRemito;
            item.ID40 = 0;    //Se asgina despues   
            item.TIPO = "LX";   //Cuando se contabiliza se asgina L1 o L2;
            item.ADDED = false;
            item.ZINCLUIR = false;

            item.REPRO = materialRepro;

            /* Disponible cuando sea contabilizado

            item.NFACTURA =
            item.CONTA_CANT =
            item.CONTA_U_ARS =
            item.CONTA_U_USD =
            item.CONTA_TOTAL =
            item.ADDED =
            item.CCOSTO =
            item.ZINCLUIR =
            item.GL =          
            item.NASIENTO =
            item.NP =
            item.REPRO =
            item.MATERIALFAB=
            item.KGFAB=
            item.KGENTREGA=
            item.STATUSNP=
            
             */

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0063_ITEMS_OC_INGRESADOS.Add(item);
                if (db.SaveChanges() > 0)
                {
                    return item.ID;
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<T0063_ITEMS_OC_INGRESADOS> GetListIngresosOCItem(int idOC, int? idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idItem == null)
                    return db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.NUM_OC == idOC).ToList();
                return db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.NUM_OC == idOC && c.IdItemOC == idItem.Value).ToList();
            }
        }
        public List<T0063_ITEMS_OC_INGRESADOS> GetListIngresosProveedor(int vendorId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.PROVEEDOR == vendorId)
                        .OrderByDescending(c => c.ID)
                        .ToList();
            }
        }
        public List<T0063_ITEMS_OC_INGRESADOS> GetListIngresosSecuencia()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0063_ITEMS_OC_INGRESADOS.OrderByDescending(c => c.ID).ToList();
            }
        }
        public List<T0063_ITEMS_OC_INGRESADOS> GetListIngresosMaterial(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.IDMATERIAL == material)
                        .OrderByDescending(c => c.ID)
                        .ToList();
            }
        }
        public void ManageIngresoStock(DateTime fechaRecibido, DateTime fechaRemito, string numeroRemito,
            decimal kgRecibidos, string numeroLote, StockStatusManager.EstadoLote estadoLote, string ubicacionStock,
            bool checkParcial, string responsableControlRecepcion, bool materialReproceso,
            string comentarioRecepcion = null, string materialRecibido = null)
        {
            //if (String.IsNullOrEmpty(materialRecibido))
            //{
            //    materialRecibido = new OrdenCompraManager().GetDataOCItem(_numeroOC, _numeroItem).MATERIAL;
            //}

            ////Actualiza Item OC + Update StatusOC
            //if (
            //    this.UpdateOrdenCompraItemIc(_numeroOC, _numeroItem, fechaRecibido, numeroRemito, kgRecibidos,
            //        checkParcial, comentarioRecepcion) == false)
            //{
            //    RevierteIngresoItem();
            //    return;
            //}

            //Alta Registro Tabla CostItems Ingresados 0063
            int numeroId0063 = this.AddRegistroIngresoItems0063(fechaRecibido, fechaRemito, numeroRemito,
                materialRecibido, kgRecibidos, responsableControlRecepcion, materialReproceso);

            //Genera Ingreso de Stock T0030 + LOG T0040
            var id40 = new StockManager().AddNewStock_withLogT40(materialRecibido, numeroLote, kgRecibidos, estadoLote,
                ubicacionStock, fechaRecibido, MmLog.TipoMovimiento.IngresoStockIc, numeroId0063.ToString(), "IC", "LX",
                "OC# " + _numeroOC, comentarioMovimiento: comentarioRecepcion);

            var resultado = this.UpdateId40T0063(numeroId0063, id40);
        }

        private bool UpdateId40T0063(int id063, int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == id063);
                x.ID40 = id40;
                return db.SaveChanges() > 0;
            }
        }
        private void RevierteIngresoItem()
        {

        }
        private bool UpdateOrdenCompraItemIc(int numeroOC, int numeroItem, DateTime fechaRecibido, string numeroRemito,
            decimal kgRecibidos, bool checkParcial, string comentarioRecepcion = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataOC = new OrdenCompraManager().GetDataOCItem(numeroOC, numeroItem);

                dataOC.FECHARECIBIDO = fechaRecibido; //Todo: Remover al elminar MAS
                dataOC.REMITO = numeroRemito; //Todo: Remover al elminar MAS
                if (dataOC.CANTIDAD_RECIBIDA == null)
                    dataOC.CANTIDAD_RECIBIDA = 0;
                dataOC.CANTIDAD_RECIBIDA = dataOC.CANTIDAD_RECIBIDA + kgRecibidos;

                if (!string.IsNullOrEmpty(comentarioRecepcion))
                    dataOC.ComentarioI_RE = comentarioRecepcion;

                new OrdenCompraManager().UpdateItemOrdenCompra(dataOC);
                new OrdenCompraStatusManager().UpdateStatusItem(numeroOC, numeroItem, checkParcial);
            }
            return true;
        }

    }
}

