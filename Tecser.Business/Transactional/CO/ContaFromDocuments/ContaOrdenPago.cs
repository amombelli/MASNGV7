using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    /// <summary>
    /// 2018.04.05
    /// aca implementar toda la secuencia de control de contabilizacion de OrdenPago
    /// Desde que la Orden de Pago ya tiene numero hasta que esta perfectamente contabilizada.-
    /// </summary>
    public class ContaOrdenPago : ContaDocumentBase
    {
        public ContaOrdenPago(int idOP, string tcode) : base(tcode)
        {
            _idOP = idOP;
            LoadDataInObjectMemory();
            SetTipoDocumento();
        }

        private T0210_OP_H _h;
        private List<T0212_OP_ITEM> _itemsPago = new List<T0212_OP_ITEM>();
        private List<T0213_OP_FACT> _itemsFact = new List<T0213_OP_FACT>();
        private readonly int _idOP;
        protected sealed override void LoadDataInObjectMemory()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _idOP);
                if (_h == null)
                    throw new InvalidOperationException("No Existe el registro en T0210*ORDENPAGO");

                _itemsPago = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP).ToList();
                _itemsFact = db.T0213_OP_FACT.Where(c => c.IDOP == _idOP).ToList();
                base.TipoLx = _h.TIPO;
                base.IdEntidad = _h.PROV_ID;
            }
        }
        protected override void AddRecordCtaCteDetalle201207()
        {
            var ctaCte = new CtaCteVendor(IdEntidad);
            var idCtaCte = ctaCte.AddCtaCteDetalleRecord(TipoDocSystem, TipoLx, _h.OPFECHA,
                _h.IDOP.ToString(), null,
                _h.MON_OP, _h.IMP_OP.Value, _h.TC.Value, _h.SaldoSinImputar.Value * -1);

            base.IdCtaCte = idCtaCte;
        }
        protected override void UpdateCtaCteSaldo(string tipoLx, string moneda, decimal importeConSigno, decimal? exchangeRate = null)
        {
            var cta = new CtaCteVendor(IdEntidad);
            cta.UpdateSaldoCtaCteResumen(tipoLx, importeConSigno, moneda, exchangeRate);
        }
        protected sealed override void SetTipoDocumento()
        {
            TipoDocSystem = ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.OrdenPago);
        }
        /// <summary>
        /// Invocar para orquestar la contabilizacion de una Orden de Pago
        /// </summary>
        public void ManageContabilizacionOP()
        {

        }


    }
}
