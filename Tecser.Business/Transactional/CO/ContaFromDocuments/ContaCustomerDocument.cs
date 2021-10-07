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
    /// 2018.03.29 - Maneja toda la contabilizacion de documentos CUSTOMER
    /// en T0400.T0401.-
    /// </summary>
    public abstract class ContaCustomerDocument : ContaDocumentBase
    {
        protected ContaCustomerDocument(string tcode) : base(tcode)
        {
            //pasa los parametros para la base
        }

        public struct ReturnContaCustomerDocument
        {
            //estructura de retorno
            public int IdFactura;
            public decimal IdFacturaX;
            public int IdCtaCte;
            public bool DocumentoEncontrado;
            public ManageDocumentType.TipoDocumento TipoDoc;
            public int NumeroAsientoIdDocu;
            public decimal NumeroAsientoX1X2;
        }

        protected int IdFactura;
        protected int IdFacturaX;
        protected T0400_FACTURA_H H400 = new T0400_FACTURA_H();
        private List<T0401_FACTURA_I> _i401 = new List<T0401_FACTURA_I>();
        protected string NumeroDocumento;
        private bool DocumentoEncontrado { get; set; }
        protected override void LoadDataInObjectMemory()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdFactura);
                if (H400 == null)
                {
                    DocumentoEncontrado = false;
                    throw new InvalidOperationException("No Existe el registro en T400*CUSTOMERINVOICE");
                }

                _i401 = db.T0401_FACTURA_I.Where(c => c.IDFactura == IdFactura).ToList();
                IdFacturaX = H400.IDFACTURAX.Value;
                DocumentoEncontrado = true;
                TipoLx = H400.TIPOFACT;
                base.IdEntidad = H400.Cliente;
            }
        }
        protected override void UpdateCtaCteSaldo(string tipoLx, string moneda, decimal importeConSigno, decimal? exchangeRate = null)
        {
            var cta = new CtaCteCustomer(IdEntidad);
            cta.UpdateSaldoCtaCteResumen(tipoLx, importeConSigno, moneda, exchangeRate);
        }
        public abstract ReturnContaCustomerDocument ManageContabilizacionCompleta();




    }
}
