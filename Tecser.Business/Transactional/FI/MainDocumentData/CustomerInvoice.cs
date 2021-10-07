using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    /// <summary>
    /// 2018.03.23 - All relacionado con la gestion de FACTURAS 400,401
    /// </summary>
    public class CustomerInvoice : CustomerMainDocument
    {
        public CustomerInvoice(string tcode, int idFactura) :
            base(tcode, idFactura)
        {
            base.ModificaSigno = false;
            AddRecord208 = false;
            InicializacionCorrecta = CheckDocumenInicializationOK();
        }


        //public new void AddItemListToMemorySimple(string itemCode, string descripcion, decimal kg, bool iva21,
        //    string monedaCotizacion, decimal precioUCotiz, decimal precioUFactura,string glI, string glV)
        //{

        //}

        //Memory Operations


        public override void CreateItemListFromOV_InMemory(List<FsRDataStructure> data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //var dataR = db.T0056_REMITO_I.Where(c => c.IDREMITO == H.IDRemito.Value).ToList();
                var numeroItems = 0;
                foreach (var it in data)
                {
                    numeroItems++;
                    var dataSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == it.IdOV && c.IDITEM == it.IdItem);

                    var tmp = new T0401_FACTURA_I
                    {
                        IDITEM = numeroItems,
                        DESC_REMITO = "Facturacion Anticipada" + dataSO.Material,
                        GLI = GLAccountManagement.GetGLInventarioMaterialMaster(dataSO.Material),
                        GLV = GLAccountManagement.GetGLVentaMaterialMaster(dataSO.Material),
                        ITEM = "VAP",
                        IVA21 = true, //modificar
                        KGDESPACHADOS_R = dataSO.Cantidad,
                        MONEDA_COTIZ = dataSO.MonedaCotiz,
                        MONEDA_FACT = H.FacturaMoneda,
                        TC = H.TC,
                    };
                    if (H.TIPOFACT == "L1")
                    {
                        tmp.PRECIOU_COTIZ = dataSO.PRECIO1;
                        tmp.PRECIOT_COTIZ = dataSO.PRECIO1 * tmp.KGDESPACHADOS_R.Value;
                    }
                    else
                    {
                        tmp.PRECIOU_COTIZ = dataSO.PRECIO2;
                        tmp.PRECIOT_COTIZ = dataSO.PRECIO2 * tmp.KGDESPACHADOS_R.Value;
                    }

                    //**-Completa los Importes de Facturas

                    if (tmp.MONEDA_COTIZ == "ARS")
                    {
                        tmp.PRECIOU_FACT_ARS = tmp.PRECIOU_COTIZ;
                        tmp.PRECIOT_FACT_ARS = tmp.PRECIOT_COTIZ;
                        tmp.PRECIOU_FACT_USD = decimal.Round((decimal)tmp.PRECIOU_COTIZ / (decimal)H.TC, 2);
                        tmp.PRECIOT_FACT_USD = decimal.Round((decimal)tmp.PRECIOT_COTIZ / (decimal)H.TC, 2);
                    }
                    else
                    {
                        tmp.PRECIOU_FACT_ARS = decimal.Round((decimal)tmp.PRECIOU_COTIZ * (decimal)H.TC, 2);
                        tmp.PRECIOT_FACT_ARS = decimal.Round((decimal)tmp.PRECIOT_COTIZ * (decimal)H.TC, 2);
                        tmp.PRECIOU_FACT_USD = tmp.PRECIOU_COTIZ;
                        tmp.PRECIOT_FACT_USD = tmp.PRECIOT_COTIZ;
                    }

                    I.Add(tmp);
                }

                UpdateTotalsHeader_InMemory();
            }
        }


        public override void CreateItemListFromRemito_InMemory()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataR = db.T0056_REMITO_I.Where(c => c.IDREMITO == H.IDRemito.Value).ToList();
                var numeroItems = 0;
                foreach (var it in dataR)
                {
                    numeroItems++;
                    var dataSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == it.IDOV && c.IDITEM == it.IDOVITEM.Value);
                    var tmp = new T0401_FACTURA_I
                    {
                        IDITEM = numeroItems,
                        DESC_REMITO = it.DESC_REMITO,
                        GLI = it.GL,
                        GLV = it.GLV,
                        ITEM = it.MATERIALAKA,
                        IVA21 = it.IVA21,
                        KGDESPACHADOS_R = it.KGDESPACHADOS_R,
                        MONEDA_COTIZ = dataSO.MonedaCotiz,
                        MONEDA_FACT = H.FacturaMoneda,
                        TC = H.TC
                    };
                    if (H.TIPOFACT == "L1")
                    {
                        tmp.PRECIOU_COTIZ = dataSO.PRECIO1;
                        tmp.PRECIOT_COTIZ = dataSO.PRECIO1 * tmp.KGDESPACHADOS_R.Value;
                    }
                    else
                    {
                        tmp.PRECIOU_COTIZ = dataSO.PRECIO2;
                        tmp.PRECIOT_COTIZ = dataSO.PRECIO2 * tmp.KGDESPACHADOS_R.Value;
                    }

                    //**-Completa los Importes de Facturas

                    if (tmp.MONEDA_COTIZ == "ARS")
                    {
                        tmp.PRECIOU_FACT_ARS = tmp.PRECIOU_COTIZ;
                        tmp.PRECIOT_FACT_ARS = tmp.PRECIOT_COTIZ;
                        tmp.PRECIOU_FACT_USD = decimal.Round((decimal)tmp.PRECIOU_COTIZ / (decimal)H.TC, 2);
                        tmp.PRECIOT_FACT_USD = decimal.Round((decimal)tmp.PRECIOT_COTIZ / (decimal)H.TC, 2);
                    }
                    else
                    {
                        tmp.PRECIOU_FACT_ARS = decimal.Round((decimal)tmp.PRECIOU_COTIZ * (decimal)H.TC, 2);
                        tmp.PRECIOT_FACT_ARS = decimal.Round((decimal)tmp.PRECIOT_COTIZ * (decimal)H.TC, 2);
                        tmp.PRECIOU_FACT_USD = tmp.PRECIOU_COTIZ;
                        tmp.PRECIOT_FACT_USD = tmp.PRECIOT_COTIZ;
                    }
                    I.Add(tmp);
                }
                UpdateTotalsHeader_InMemory();
            }
        }
        private void UpdateTotalsHeader_InMemory()
        {
            decimal importeBruto = 0;
            decimal importeBaseImponible = 0;
            decimal importeIIBB = 0;
            decimal importeIva21 = 0;
            decimal descuentoPorcentaje = 0;

            if (H.Descuento == null)
                H.Descuento = 0;

            if (H.FacturaMoneda == "ARS")
            {
                foreach (var it in I)
                {
                    importeBruto += it.PRECIOT_FACT_ARS;
                    if (it.IVA21 == true)
                    {
                        importeBaseImponible += it.PRECIOT_FACT_ARS;
                        importeIva21 += (it.PRECIOT_FACT_ARS * (decimal)0.21);
                    }
                }
            }
            else
            {
                //moneda documento USD
                foreach (var it in I)
                {
                    importeBruto += it.PRECIOT_FACT_USD;
                    if (it.IVA21 == true)
                    {
                        importeBaseImponible += it.PRECIOT_FACT_USD;
                        importeIva21 += (it.PRECIOT_FACT_USD * (decimal)0.21);
                    }
                }
            }

            if (H.TIPOFACT == "L1")
            {
                importeIIBB = decimal.Round((decimal)H.IIBB_PORC * importeBaseImponible, 2);
            }
            else
            {
                importeBaseImponible = 0;
                importeIva21 = 0;
                importeIIBB = 0;
            }

            if (H.Descuento > 0 && importeBruto > 0)
            {
                descuentoPorcentaje = H.Descuento.Value / importeBruto;
            }

            H.TotalFacturaB = importeBruto;
            H.TotalImpo = importeBaseImponible - (importeBaseImponible * descuentoPorcentaje);
            H.TotalIVA21 = importeIva21 - (importeIva21 * descuentoPorcentaje);
            H.TotalIIBB = importeIIBB - (importeBruto * descuentoPorcentaje);
            H.TotalFacturaN = (importeBruto - H.Descuento.Value + H.TotalIVA21 + H.TotalIIBB);
        }
        public override void UpdateItemValues_InMemory(int idItem, string descripcion, decimal nuevoKg, string moneda, decimal nuevoPrecioUnitario)
        {
            var item = I.Find(c => c.IDITEM == idItem);
            if (item == null)
                return;

            item.DESC_REMITO = descripcion;
            item.KGDESPACHADOS_R = nuevoKg;
            if (moneda == "ARS")
            {
                item.PRECIOU_FACT_ARS = nuevoPrecioUnitario;
                item.PRECIOU_FACT_USD = (decimal.Round((decimal)nuevoPrecioUnitario / (decimal)H.TC, 2));
            }
            else
            {
                item.PRECIOU_FACT_ARS = (decimal.Round((decimal)nuevoPrecioUnitario * (decimal)H.TC, 2));
                item.PRECIOU_FACT_USD = nuevoPrecioUnitario;
            }

            item.PRECIOT_FACT_ARS = decimal.Round((decimal)item.PRECIOU_FACT_ARS * (decimal)item.KGDESPACHADOS_R, 2);
            item.PRECIOT_FACT_USD = decimal.Round((decimal)item.PRECIOU_FACT_USD * (decimal)item.KGDESPACHADOS_R, 2);

            UpdateTotalsHeader_InMemory();
        }
        public override void RecalcValuesAfterDataChange_InMemory(decimal exchangeRate, decimal porcentajeDescuento, decimal alicuotaiIBB)
        {
            if (exchangeRate <= 0)
                return;

            //reset values
            decimal importeBruto = 0;
            decimal importeBaseImponible = 0;
#pragma warning disable CS0219 // The variable 'importeIIBB' is assigned but its value is never used
            decimal importeIIBB = 0;
#pragma warning restore CS0219 // The variable 'importeIIBB' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'importeIva21' is assigned but its value is never used
            decimal importeIva21 = 0;
#pragma warning restore CS0219 // The variable 'importeIva21' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'descuentoPorcentaje' is assigned but its value is never used
            decimal descuentoPorcentaje = 0;
#pragma warning restore CS0219 // The variable 'descuentoPorcentaje' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'importeDescuento' is assigned but its value is never used
            decimal importeDescuento = 0;
#pragma warning restore CS0219 // The variable 'importeDescuento' is assigned but its value is never used
            decimal importeNoImponible = 0;

            H.TC = exchangeRate;
            H.DescuentoPorc = porcentajeDescuento;
            H.IIBB_PORC = alicuotaiIBB;

            //Recalcula los Precios Unitarios + Totales de acuerdo al nuevo XRate
            foreach (var it in I)
            {
                it.TC = H.TC;
                if (it.MONEDA_COTIZ == "ARS")
                {
                    //Moneda de Cotizacion ARS recalcula los PreciosU/Total en USD
                    it.PRECIOU_FACT_USD = decimal.Round((decimal)it.PRECIOU_FACT_ARS / H.TC, 3);
                    it.PRECIOT_FACT_USD = decimal.Round((decimal)it.PRECIOT_FACT_ARS / H.TC, 2);

                }
                else
                {
                    //moneda de cotizacion USD recalcula los PreciosU/Total en ARS
                    it.PRECIOU_FACT_ARS = decimal.Round((decimal)it.PRECIOU_FACT_USD * H.TC, 3);
                    it.PRECIOT_FACT_ARS = decimal.Round((decimal)it.PRECIOT_FACT_USD * H.TC, 2);
                }

                if (H.FacturaMoneda == "ARS")
                {
                    importeBruto += it.PRECIOT_FACT_ARS;
                    if (it.IVA21 == true)
                    {
                        //Si tiene IVA el Item va para el calculo de la Base Imponible
                        importeBaseImponible += it.PRECIOT_FACT_ARS * (1 - H.DescuentoPorc.Value);
                    }
                    else
                    {
                        importeNoImponible += it.PRECIOT_FACT_ARS * (1 - H.DescuentoPorc.Value);
                    }
                }
                else
                {
                    //moneda documento USD
                    importeBruto += it.PRECIOT_FACT_USD;
                    if (it.IVA21 == true)
                    {
                        importeBaseImponible += it.PRECIOT_FACT_USD * (1 - H.DescuentoPorc.Value);
                    }
                    else
                    {
                        importeNoImponible += it.PRECIOT_FACT_USD * (1 - H.DescuentoPorc.Value);
                    }
                }
            }

            //Fin Recorrido de CostItems

            H.TotalFacturaB = importeBruto; //Ya debiera estar en Round2.
            H.TotalImpo = decimal.Round(importeBaseImponible, 2);
            H.Descuento = decimal.Round((H.DescuentoPorc.Value * H.TotalFacturaB), 2);
            var descuentoRecalculado = H.TotalFacturaB - (H.TotalImpo + importeNoImponible);

            if (H.Descuento != descuentoRecalculado)
            {
                MessageBox.Show(@"Atencion con los valores de descuento - han sido recalculados backward");
                H.Descuento = descuentoRecalculado;
            }

            if (H.TIPOFACT == "L1")
            {
                H.TotalIIBB = decimal.Round((H.IIBB_PORC.Value * H.TotalImpo), 2);
                H.TotalIVA21 = decimal.Round((decimal)0.21 * H.TotalImpo, 2);
            }
            else
            {
                H.TotalImpo = 0;
                H.TotalIIBB = 0;
                H.TotalIVA21 = 0;
            }

            H.TotalFacturaN = (H.TotalFacturaB - H.Descuento.Value + H.TotalIVA21 + H.TotalIIBB);
        }

        //DataBase Operations
        public void UpdateExchangeRate(decimal updatedExchangeRate)
        {

            H.TC = updatedExchangeRate;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H.IDFACTURA);
                x.TC = updatedExchangeRate;
                db.SaveChanges();

                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == H.IDFACTURA).ToList();
                foreach (var item in items)
                {
                    item.TC = updatedExchangeRate;

                    if (item.MONEDA_COTIZ == "ARS")
                    {
                        item.PRECIOU_FACT_USD = decimal.Round(item.PRECIOU_COTIZ / updatedExchangeRate, 2);
                        item.PRECIOT_FACT_USD = decimal.Round(item.PRECIOT_COTIZ / updatedExchangeRate, 2);
                    }
                    else
                    {
                        //cotizacion USD
                        item.PRECIOU_FACT_ARS = decimal.Round(item.PRECIOU_COTIZ * updatedExchangeRate, 2);
                        item.PRECIOT_FACT_ARS = decimal.Round(item.PRECIOT_COTIZ * updatedExchangeRate, 2);
                    }
                }
                db.SaveChanges();
            }
        }
        public void RecalculaPrecioItemsFromSalesOrderPrice()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                I.Clear();
                var fi = db.T0401_FACTURA_I.Where(c => c.IDFactura == H.IDFACTURA).ToList();
                foreach (var i in fi)
                {
                    i.TC = H.TC;

                    if (i.MONEDA_COTIZ == "ARS")
                    {
                        i.PRECIOU_FACT_ARS = i.PRECIOU_COTIZ;
                        i.PRECIOT_FACT_ARS = i.PRECIOU_COTIZ * i.KGDESPACHADOS_R.Value;
                        i.PRECIOU_FACT_USD = i.PRECIOU_COTIZ * H.TC;
                        i.PRECIOT_FACT_USD = i.PRECIOU_FACT_USD * i.KGDESPACHADOS_R.Value;
                    }
                    else
                    {
                        i.PRECIOU_FACT_ARS = i.PRECIOU_COTIZ * H.TC;
                        i.PRECIOT_FACT_ARS = i.PRECIOU_COTIZ * i.KGDESPACHADOS_R.Value * H.TC;
                        i.PRECIOU_FACT_USD = i.PRECIOU_COTIZ;
                        i.PRECIOT_FACT_USD = i.PRECIOU_COTIZ * i.KGDESPACHADOS_R.Value;
                    }
                    I.Add(i);
                }
                db.SaveChanges();
            }
        }
        public void UpdateDatosItemFactura(int iditem, string descripcion, string monedaPrecio,
            decimal precioUnitario, decimal kgFactura)
        {
            //este metodo lo pongo acá porque supuestamente no se podria modificar los datos de una NC o ND
            //por lo que solo aplicaria a una factura.- pero queda para analizar despues a la hora de implementar
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == H.IDFACTURA && c.IDITEM == iditem);
                if (item != null)
                {
                    item.DESC_REMITO = descripcion;
                    item.KGDESPACHADOS_R = kgFactura;
                    if (monedaPrecio == "ARS")
                    {
                        //modificando el precio en ARS
                        item.PRECIOU_FACT_ARS = precioUnitario;
                        item.PRECIOT_FACT_ARS = decimal.Round(precioUnitario * kgFactura, 2);
                        item.PRECIOU_FACT_USD = decimal.Round(precioUnitario / (decimal)H.TC, 2);
                        item.PRECIOT_FACT_USD = decimal.Round(precioUnitario / (decimal)H.TC * kgFactura, 2);
                    }
                    else
                    {
                        //modificando el precio en USD
                        item.PRECIOU_FACT_ARS = decimal.Round(precioUnitario * (decimal)H.TC, 2);
                        item.PRECIOT_FACT_ARS = decimal.Round(precioUnitario * (decimal)H.TC * kgFactura, 2);
                        item.PRECIOU_FACT_USD = precioUnitario;
                        item.PRECIOT_FACT_USD = decimal.Round(precioUnitario * kgFactura, 2);
                    }
                    db.SaveChanges();
                }
            }
        }
        protected override bool AddMainDocumentHeader()
        {
            throw new NotImplementedException();
        }
        protected override bool AddMainDocumentItems()
        {
            throw new NotImplementedException();
        }

        public string GetStatusDocumento()
        {
            return base.StatusDocumento.ToString();
        }

        public string GetTipoDocumentoDb()
        {
            return H.TIPO_DOC;
        }
        public void UpdateDocumentType(ManageDocumentType.TipoDocumento tipoDocumento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H.IDFACTURA);
                var tdoc = x.TIPO_DOC;
                var tdoc_new = ManageDocumentType.GetSystemDocumentType(tipoDocumento);
                H.TIPO_DOC = tdoc_new;
                x.TIPO_DOC = tdoc_new;
                db.SaveChanges();
                var cta = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == x.IdCtaCte.Value);
                cta.TDOC = tdoc_new;
                db.SaveChanges();
                var cta207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == x.IdCtaCte.Value).ToList();
                foreach (var i in cta207)
                {
                    db.T0207_SPLITFACTURAS.Remove(i);
                }
                db.SaveChanges();

                var data = new CtaCteCustomer(IdEntidad);
                data.AddRecordDocumentT0207FromIdCtaCte(x.IdCtaCte.Value);

                var Asiento = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == H.NAS.Value);
                Asiento.DOCUTIPO = tdoc_new;
                var itemsA = db.T0602_DOCU_S.Where(c => c.IDDOCU == Asiento.IDDOCU).ToList();
                foreach (var it in itemsA)
                {
                    it.DOCUTIPO = tdoc_new;
                }
                db.SaveChanges();
            }
        }
    }
}
