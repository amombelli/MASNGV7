using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class TotalesCustomerFi
    {
        public decimal Bruto { get; private set; }
        public decimal Descuento { get; private set; }
        public decimal PorcentajeDescuento { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal BaseImponible { get; private set; }
        public decimal NoImponible { get; private set; }
        public decimal Iva21 { get; private set; }
        public decimal AlicuotaIIBB { get; private set; }
        public decimal IIBB { get; private set; }
        public decimal Tax2 { get; private set; }
        public decimal AlicuotaTax2 { get; private set; }
        public decimal TotalImpuestos { get; private set; }
        public decimal TotalFinal { get; private set; }
        public bool OK;

        /// <summary>
        /// Mapea los Importes desde el Header ya calculado a la estructura
        /// </summary>
        public void MapImportesFrom400Header(T0400_FACTURA_H h)
        {
            OK = false;
            Bruto = h.TotalFacturaB;
            Descuento = h.Descuento ?? 0;
            if (Bruto == 0)
            {
                PorcentajeDescuento = 0;
                Subtotal = 0;
                NoImponible = 0;
                BaseImponible = 0;
            }
            else
            {
                PorcentajeDescuento = Descuento / Bruto;
                Subtotal = Bruto - Descuento;
                BaseImponible = BaseImponible;
                NoImponible = Subtotal - BaseImponible;
                Iva21 = h.TotalIVA21;
            }

            AlicuotaIIBB = h.IIBB_PORC ?? 0;
            IIBB = h.TotalIIBB;

            AlicuotaTax2 = h.Tax2Alicuota;
            Tax2 = h.Tax2Importe;
            TotalImpuestos = Iva21 + IIBB + Tax2;
            TotalFinal = h.TotalFacturaN;
            if (h.TotalFacturaN == (Subtotal + Iva21 + IIBB + Tax2))
                OK = true;
        }

        /// <summary>
        /// Calcula y Mapea los importes desde los Items -Descuento tiene prioridad % al valor
        /// </summary>
        public void CalculaTotalesFromItems(List<T0401_FACTURA_I> items, decimal alicuotaIIBB = 0,
            decimal descuentoImporte = 0, decimal descuentoPorcentaje = 0, decimal alicuotaTax2 = 0)
        {
            decimal baseImpo = 0;
            decimal importeBruto = 0;
            foreach (var i in items)
            {
                if (i.MONEDA_FACT == "ARS")
                {
                    if (i.IVA21)
                    {
                        baseImpo += i.PRECIOT_FACT_ARS;
                    }
                    importeBruto += i.PRECIOT_FACT_ARS;
                }
                else
                {
                    //calculo en moneda de facturacion USD
                    if (i.IVA21)
                    {
                        baseImpo += i.PRECIOT_FACT_USD;
                    }
                    importeBruto += i.PRECIOT_FACT_USD;
                }
            }
            Bruto = importeBruto;
            //Manejo de Descuento
            if (descuentoImporte != 0 || descuentoPorcentaje != 0)
            {
                //Tiene prioridad el porcentaje al valor
                if (descuentoPorcentaje != 0)
                {
                    Descuento = Math.Round(Bruto * descuentoPorcentaje, 2);
                    PorcentajeDescuento = descuentoPorcentaje;
                }
                else
                {
                    //descuento por monto fijo
                    Descuento = descuentoImporte;
                    PorcentajeDescuento = Math.Round(descuentoImporte / Bruto, 4);
                }
            }
            Subtotal = Bruto - Descuento;
            decimal porcentajeImponibleAntesDescuento = Math.Round(baseImpo / Bruto, 4);
            BaseImponible = Math.Round(Subtotal * porcentajeImponibleAntesDescuento, 2);
            NoImponible = Subtotal - BaseImponible;
            Iva21 = Math.Round(BaseImponible * (decimal) 0.21, 2);
            AlicuotaIIBB = Math.Round(alicuotaIIBB, 4);
            AlicuotaTax2 = Math.Round(alicuotaTax2, 4);
            IIBB = Math.Round(baseImpo * AlicuotaIIBB, 2);
            Tax2 = Math.Round(baseImpo * alicuotaTax2, 2);
            TotalImpuestos = Iva21 + IIBB + Tax2;
            TotalFinal = Subtotal + TotalImpuestos;
            OK = true;
        }
    }
}

