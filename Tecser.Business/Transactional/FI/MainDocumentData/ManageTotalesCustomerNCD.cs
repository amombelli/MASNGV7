using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class ManageTotalesCustomerNcd : CustDocTotalesStruct
    {
        //-----------------------------------------------------------------------
        private readonly int _idFactura;
        private decimal newTC;
        //-----------------------------------------------------------------------

        public ManageTotalesCustomerNcd(int idFactura, string monedaDocumento = "ARS")
            : base(idFactura, monedaDocumento)
        {
            //Obtiene totales totales desde documento almacenado DB
            _idFactura = idFactura;
            if (idFactura <= 0)
                return;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                ImporteTotalBrutoInicial = x.TotalFacturaB;
                ImporteBaseImponible = x.TotalImpo;
                ImporteDescuento = x.Descuento.Value;
                ImporteSubtotal = x.TotalFacturaB - x.Descuento.Value;
                ImporteIva21 = x.TotalIVA21;
                AlicuotaPerRetIIBB = x.IIBB_PORC.Value;
                ImportePerRetIIBB = x.TotalIIBB;
                ExchangeRate = x.TC;
                MonedaDocumento = x.FacturaMoneda;
                ImporteTotalNetoFinal = x.TotalFacturaN;
            }
        }
        public void GetUpdatedImporteAfterTCisChanged(decimal newTC)
        {
            this.newTC = newTC;
            ExchangeRate = newTC;
            CalculoBaseImponibleSegunItems();
        }

        public void CalculaAfterUnitPriceIsChanged(int idItem, decimal newUnitPrice)
        {
            decimal brutoOri = 0;
            decimal brutoNew = 0;
            decimal baseImponibleNew = 0;
            CalculoPorcentajeDescuento(ImporteTotalBrutoInicial, ImporteDescuento);
            var y = this.PorcentajeDescuento;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var it in items)
                {
                    if (MonedaDocumento == "ARS")
                    {
                        brutoOri += it.PRECIOT_FACT_ARS;
                        if (it.IDITEM == idItem)
                        {
                            brutoNew += (newUnitPrice * Math.Abs(it.KGDESPACHADOS_R.Value));
                            if (it.IVA21)
                            {
                                baseImponibleNew += (newUnitPrice * Math.Abs(it.KGDESPACHADOS_R.Value));
                            }
                        }
                        else
                        {
                            brutoNew += it.PRECIOT_FACT_ARS;
                            if (it.IVA21)
                            {
                                baseImponibleNew += it.PRECIOT_FACT_ARS;
                            }
                        }
                    }
                    else
                    {
                        //moneda documento =USD
                    }
                }
            }
            if (ImporteTotalBrutoInicial != brutoOri)
                return;

            ImporteTotalBrutoInicial = brutoNew;
            ImporteDescuento = brutoNew * PorcentajeDescuento;
            ImporteSubtotal = ImporteTotalBrutoInicial - ImporteDescuento;
            ImporteBaseImponible = baseImponibleNew - (baseImponibleNew * PorcentajeDescuento);
            ImporteIva21 = ImporteBaseImponible * (decimal)0.21;
            ImportePerRetIIBB = ImporteBaseImponible * AlicuotaPerRetIIBB;
            decimal importeFinalAnterior = ImporteTotalNetoFinal;
            ImporteTotalNetoFinal = ImporteSubtotal + ImporteIva21 + ImportePerRetIIBB;
        }


        private void CalculoBaseImponibleSegunItems()
        {
            decimal brutoOri = 0;
            decimal brutoNew = 0;
            decimal baseImponibleNew = 0;
            CalculoPorcentajeDescuento(ImporteTotalBrutoInicial, ImporteDescuento);
            var y = this.PorcentajeDescuento;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var it in items)
                {
                    if (MonedaDocumento == "ARS")
                    {
                        brutoOri += it.PRECIOT_FACT_ARS;
                        if (it.MONEDA_COTIZ == "ARS")
                        {
                            brutoNew += it.PRECIOT_FACT_ARS;
                            if (it.IVA21)
                                baseImponibleNew += it.PRECIOT_FACT_ARS;
                        }
                        else
                        {
                            brutoNew += (it.PRECIOU_COTIZ * newTC) * it.KGDESPACHADOS_R.Value;
                            if (it.IVA21)
                                baseImponibleNew += (it.PRECIOU_COTIZ * newTC) * it.KGDESPACHADOS_R.Value;
                        }
                    }
                    else
                    {
                        //moneda documento =USD
                    }
                }
            }
            if (ImporteTotalBrutoInicial != brutoOri)
                return;

            ImporteTotalBrutoInicial = brutoNew;
            ImporteDescuento = brutoNew * PorcentajeDescuento;
            ImporteSubtotal = ImporteTotalBrutoInicial - ImporteDescuento;
            ImporteBaseImponible = baseImponibleNew - (baseImponibleNew * PorcentajeDescuento);
            ImporteIva21 = ImporteBaseImponible * (decimal)0.21;
            ImportePerRetIIBB = ImporteBaseImponible * AlicuotaPerRetIIBB;
            decimal importeFinalAnterior = ImporteTotalNetoFinal;
            ImporteTotalNetoFinal = ImporteSubtotal + ImporteIva21 + ImportePerRetIIBB;
        }
        public ManageTotalesCustomerNcd(decimal importeBruto, decimal importeBaseImponible, decimal descuento,
            decimal totalIva21, decimal alicuotaIIBB, decimal ImporteretencionIIBB, decimal exchangeRate,
            decimal importeNetoFinal, string monedaDocu) : base(0, monedaDocu)
        {
            //Totales desde memoria
            ImporteTotalBrutoInicial = importeBruto;
            ImporteBaseImponible = importeBaseImponible;
            ImporteDescuento = descuento;
            ImporteSubtotal = importeBruto - descuento;
            ImporteIva21 = totalIva21;
            AlicuotaPerRetIIBB = alicuotaIIBB;
            ImportePerRetIIBB = ImporteretencionIIBB;
            ExchangeRate = exchangeRate;
            MonedaDocumento = monedaDocu;
            ImporteTotalNetoFinal = importeNetoFinal;
        }
        public void ChangeMoneda(string moneda)
        {
            if (base.MonedaDocumento == moneda)
                return; // no hubo cambios en la moneda
            if (base.MonedaDocumento == "ARS")
            {
                //antes ARS ahora USD
                base.ImporteDescuento = ImporteDescuento / base.ExchangeRate;
            }
            else
            {
                //ANTES USD ahora ARS
                base.ImporteDescuento = ImporteDescuento * base.ExchangeRate;
            }
            base.MonedaDocumento = moneda;
            CalculaAllValues();
        }
        private decimal? _suma;
        private void CalculoImporteBrutoInicial()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (MonedaDocumento == "ARS")
                {
                    _suma = db.T0401_FACTURA_I.Where(c => c.IDFactura == IdFactura).Sum(c => c.PRECIOT_FACT_ARS);
                }
                else
                {
                    _suma = db.T0401_FACTURA_I.Where(c => c.IDFactura == IdFactura).Sum(c => c.PRECIOT_FACT_USD);
                }

                ImporteTotalBrutoInicial = _suma != null ? decimal.Round((decimal)_suma, 2) : 0;
            }
        }
        private void CalculoPorcentajeDescuento(decimal importeBruto, decimal importeDescuento)
        {
            if (importeDescuento == 0)
            {
                this.ImporteDescuento = 0;
                this.PorcentajeDescuento = 0;
            }
            else
            {
                this.PorcentajeDescuento = decimal.Round(importeDescuento / importeBruto, 3);
                this.ImporteDescuento = decimal.Round(importeDescuento, 2);
            }
        }
        private void CalculoBaseImponible()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal? sum;
                if (MonedaDocumento == "ARS")
                {
                    sum =
                        db.T0401_FACTURA_I.Where(c => c.IDFactura == IdFactura && c.IVA21 == true)
                            .Sum(c => c.PRECIOT_FACT_ARS);
                }
                else
                {
                    sum =
                        db.T0401_FACTURA_I.Where(c => c.IDFactura == IdFactura && c.IVA21 == true)
                            .Sum(c => c.PRECIOT_FACT_USD);
                }

                this.ImporteBaseImponible = sum != null
                    ? decimal.Round((decimal)sum - ((decimal)sum * this.PorcentajeDescuento), 2)
                    : 0;
            }
        }
        private void CalculoPercepcionIIBB()
        {
            //Segun normativa - Alicuota Percepcion va de 0.00%, 0.10, 0.15 ... maximo 8.00%
            //Son 4 decimales.-
            ImportePerRetIIBB = decimal.Round(ImporteBaseImponible * AlicuotaPerRetIIBB, 2);
        }
        private void CalculoImporteIVA21()
        {
            ImporteIva21 = decimal.Round(this.ImporteBaseImponible * (decimal)0.21, 2);
        }
        public void RecalculaUpdateValores(decimal exchangeRate, decimal importeDescuento = 0, decimal alicuotaIIBB = 0)
        {
            this.ExchangeRate = exchangeRate;
            this.ImporteDescuento = importeDescuento;
            this.AlicuotaPerRetIIBB = alicuotaIIBB;
            CalculaAllValues();
        }
        public void SetTotalesToTable400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdFactura);

                header.TC = this.ExchangeRate;
                header.TotalFacturaB = this.ImporteTotalBrutoInicial;
                header.Descuento = this.ImporteDescuento;
                header.TotalImpo = this.ImporteBaseImponible;
                header.TotalIVA21 = this.ImporteIva21;
                header.IIBB_PORC = this.AlicuotaPerRetIIBB;
                header.TotalIIBB = this.ImportePerRetIIBB;
                header.TotalFacturaN = ImporteTotalNetoFinal;

                db.SaveChanges();
            }
        }
        public void GetTotalesFromTable400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdFactura);
                if (data != null)
                    return;

                this.ImporteTotalBrutoInicial = data.TotalFacturaB;
                this.ImporteDescuento = data.Descuento.Value;

                if (ImporteTotalBrutoInicial != 0)
                    this.PorcentajeDescuento = decimal.Round(data.Descuento.Value / data.TotalFacturaB, 2);

                this.ImporteSubtotal = data.Descuento.Value;
                this.ImporteBaseImponible = data.TotalImpo;
                this.ImporteIva21 = data.TotalIVA21;
                this.ImporteIva105 = 0;
                this.ImportePerRetIVA = data.TotalIIBB;
                this.AlicuotaPerRetIIBB = data.IIBB_PORC.Value; //Alicuota IIBB
            }
        }
        private void CalculaAllValues()
        {
            CalculoImporteBrutoInicial(); //Round2
            CalculoPorcentajeDescuento(ImporteTotalBrutoInicial, ImporteDescuento); //Round3
            ImporteSubtotal = ImporteTotalBrutoInicial - ImporteDescuento;
            CalculoBaseImponible(); //Round2
            this.AlicuotaPerRetIIBB = decimal.Round(AlicuotaPerRetIIBB, 4); //Round4
            CalculoPercepcionIIBB(); //Round2
            CalculoImporteIVA21(); //Round2
            ImporteTotalNetoFinal = ImporteSubtotal + ImporteIva21 + ImporteIva105 + ImportePerRetIIBB;
        }
    }
}
