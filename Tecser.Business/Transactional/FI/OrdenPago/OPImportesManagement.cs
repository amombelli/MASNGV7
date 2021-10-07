using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class OPImportesManagement
    {
        public OPImportesManagement(int idOP)
        {
            _idOP = idOP;
            _header = new TecserData(GlobalApp.CnnApp).T0210_OP_H.SingleOrDefault(c => c.IDOP == idOP);
        }


        //-------------------------------------------------------------------------------
        private readonly int _idOP;
        private readonly T0210_OP_H _header;
        //-------------------------------------------------------------------------------


        public decimal GetImporteFacturasAPagar()
        {
            var sum = new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _idOP).Sum(c => c.FACT_SALDO_IMPUTAR);
            return sum ?? 0;
        }

        public decimal GetImporteCheques()
        {
            //el importe en cheques contempla la emision de cheques propios (-5)
            var sum =
                new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "CHE").Sum(c => c.IMPORTE);
            sum += new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CH_ID == -5).Sum(c => c.IMPORTE);
            return sum != null ? Convert.ToDecimal(sum) : 0;
        }

        public decimal GetImporteARS()
        {
            var sum =
                new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "ARS").Sum(c => c.IMPORTE);
            return sum != null ? Convert.ToDecimal(sum) : 0;
        }

        public decimal GetImporteUSD()
        {
            var sum =
                new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "USD").Sum(c => c.IMPORTE);
            return sum != null ? Convert.ToDecimal(sum) : 0;
        }

        public decimal GetImporteCreditos()
        {
            var sum =
                new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "OPCRED")
                    .Sum(c => c.IMPORTE);
            return sum != null ? Convert.ToDecimal(sum) : 0;
        }

        public decimal GetImporteRetencionesIIBB_FromHeaderOP()
        {
            if (_header.ImporteRetIIBB == null)
            {
                return 0;
            }
            return (decimal)_header.ImporteRetIIBB;
        }

        public decimal GetImporteRetencionesGS_FromHeaderOP()
        {
            if (_header.ImporteRetGS == null)
            {
                return 0;
            }
            return (decimal)_header.ImporteRetGS;
        }

        public decimal GetImporteOtros()
        {
            return this.GetImporteTotalItemsPago_ExcluidoRetenciones() - this.GetImporteCheques() -
                   this.GetImporteCreditos() - this.GetImporteARS() - this.GetImporteUSD();
        }

        public decimal GetImporteOPTotal()
        {
            return GetImporteTotalItemsPago_ExcluidoRetenciones() + this.GetImporteTotalRetenciones();
        }

        public decimal GetImporteOrdenPagoFinal()
        {
            return GetImporteTotalItemsPago_ExcluidoRetenciones() + this.GetImporteTotalRetenciones() - GetImporteCreditos();
        }

        public decimal GetImporteTotalItemsPago_ExcluidoRetenciones()
        {
            var sum = new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _idOP).Sum(c => c.IMPORTE);
            return sum != null ? Convert.ToDecimal(sum) : 0;
        }

        public decimal GetImporteTotalRetenciones()
        {
            return GetImporteRetencionesIIBB_FromHeaderOP() + GetImporteRetencionesGS_FromHeaderOP();
        }

























    }
}
