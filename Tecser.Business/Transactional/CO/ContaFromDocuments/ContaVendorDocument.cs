using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    //new to implement 2018.04.04
    //replicar esta clase con ContaCustomerDocument
    //Generico T403 - T404
    public abstract class ContaVendorDocument : ContaDocumentBase
    {
        public ContaVendorDocument(string tcode) : base(tcode)
        {

        }
        protected struct ReturnContaVendorDocument
        {
            public int IdFactura;
            public int IdCtaCte;
            public int NumeroAsiento;
            public bool DocumentoEncontrado;
            public ManageDocumentType.TipoDocumento TipoDoc;
        }

        protected int IdFactura;
        protected int IdFacturaX;
        protected T0403_VENDOR_FACT_H H403 = new T0403_VENDOR_FACT_H();
        private List<T0404_VENDOR_FACT_I> I404 = new List<T0404_VENDOR_FACT_I>();
        //protected string NumeroDocumento;
        private bool DocumentoEncontrado { get; set; }

        protected override void LoadDataInObjectMemory()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h403 = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == IdFactura);
                if (h403 == null)
                {
                    DocumentoEncontrado = false;
                    throw new InvalidOperationException("No Existe el registro en T403*VENDORINVOICE");
                }

                I404 = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == IdFactura).ToList();
                IdFacturaX = (int)H403.IdFacturaX.Value;
                DocumentoEncontrado = true;
                TipoLx = H403.TIPO;
                base.IdEntidad = h403.IDPROV;
            }
        }

        //protected override void AddRecordCtaCteDetalle201207()
        //{
        //    throw new NotImplementedException();
        //}
        protected override void UpdateCtaCteSaldo(string tipoLx, string moneda, decimal importeConSigno, decimal? exchangeRate = null)
        {
            var cta = new CtaCteVendor(IdEntidad);
            cta.UpdateSaldoCtaCteResumen(tipoLx, importeConSigno, moneda, exchangeRate);
        }

        //protected override void SetTipoDocumento()
        //{
        //    throw new NotImplementedException();
        //}
        protected abstract ReturnContaVendorDocument ManageContabilizacionCompleta();

    }
}
