using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class XCustomerNcd : XCustomerDocumentBase
    {
        private readonly int _idNcd;

        public XCustomerNcd(int idCliente, string tcode) : base(idCliente, tcode)
        {
            //se usa para iniciar 
        }
        private T0300_NCD_H _h;
        private List<T0301_NCD_I> _i = new List<T0301_NCD_I>();
        public enum TipoDoc
        {
            NotaDebito,
            NotaCredito,
            DocumentoX
        }
        public string GetTdoc(NotaCreditoDebitoCustomer.TipoDoc tipoDoc)
        {
            switch (tipoDoc)
            {
                case NotaCreditoDebitoCustomer.TipoDoc.NotaDebito:
                    return "ND";
                case NotaCreditoDebitoCustomer.TipoDoc.NotaCredito:
                    return "NC";
                case NotaCreditoDebitoCustomer.TipoDoc.DocumentoX:
                    return "AX";
                case NotaCreditoDebitoCustomer.TipoDoc.Ajuste:
                    return "AJ";
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoDoc), tipoDoc, null);
            }
        }


        /// <summary>
        /// Constructor para cargar datos NCD
        /// </summary>
        public XCustomerNcd(int idNcd) : base()
        {
            _idNcd = idNcd;
        }

        private void LoadNcdData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h = new T0300_NCD_H();
                _h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _idNcd);
                _i = db.T0301_NCD_I.Where(c => c.IDH == _idNcd).ToList();
                base._tcode = "CHR";
                base._idCliente = _h.IdCliente;
                base._tipoLx = _h.LX;
            }
        }


        //Modifiaciones para RG
        public void AddDocumentoAsociado(int idFacturaAsociada)
        {
            this._nh.idFacturaAsociada = idFacturaAsociada;
        }
        //Modifiaciones para RG
        public void AddPeriodoAsociadoAjuste(DateTime fechaDesde, DateTime fechaHasta)
        {
            this._nh.PeriodoAjusteDesde = fechaDesde;
            this._nh.PeriodoAjusteHasta = fechaHasta;
        }
    }
}
