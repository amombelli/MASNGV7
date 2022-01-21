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
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0213_OP_FACT.Where(c => c.IDOP == _idOP).ToList();
                return x.Any() == false ? 0 : x.Sum(c => c.FACT_SALDO_IMPUTAR);
            }
        }

        public decimal GetImporteCheques()
        {
            //el importe en cheques contempla la emision de cheques propios (-5)
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal impx = 0;
                var x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "CHE").ToList();
                if (x.Any()) impx = x.Sum(c => c.IMPORTE);
                //
                x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CH_ID == -5).ToList();
                if (x.Any()) impx += x.Sum(c => c.IMPORTE);
                return impx;
            }
        }

        public decimal GetImporteARS()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "ARS").ToList();
                return x.Any() == false ? 0 : x.Sum(c => c.IMPORTE);
            }
        }

        public decimal GetImporteUSD()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "USD").ToList();
                return x.Any() == false ? 0 : x.Sum(c => c.IMPORTE);
            }
        }

        public decimal GetImporteCreditos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP && c.CUENTA_O == "OPCRED").ToList();
                return x.Any() == false ? 0 : x.Sum(c => c.IMPORTE);
            }
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
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP).ToList();
                return x.Any() == false ? 0 : x.Sum(c => c.IMPORTE);
            }
        }

        public decimal GetImporteTotalRetenciones()
        {
            return GetImporteRetencionesIIBB_FromHeaderOP() + GetImporteRetencionesGS_FromHeaderOP();
        }

























    }
}
