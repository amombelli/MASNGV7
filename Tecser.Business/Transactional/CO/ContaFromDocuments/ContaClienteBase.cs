using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public abstract class ContaClienteBase
    {
        protected readonly int _idCliente;
        protected T0006_MCLIENTES ClienteData;
        protected int Signo = 1;
        protected CtaCteCustomer CtaCteMng;
        public int IdCtaCte { protected set; get; }
        public string TipoDocumentoXX { protected set; get; }
        protected DateTime FechaConta;
        public string NumeroDocumento;
        public string MonedaConta;
        public decimal TC;
        public AsientoNumeracion.TipoLx LX { protected set; get; }
        public AsientoNumeracion.ReturnNumeracion RtnAsiento;

        protected ContaClienteBase(int idCliente)
        {
            _idCliente = idCliente;
            ClienteData = new CustomerManager().GetCustomerBillToData(_idCliente);
            CtaCteMng = new CtaCteCustomer(_idCliente);
        }

        protected void AddData201(decimal importeConSigno, string documentoInterno, int idDocAlternativo1 = 0, int idDocAlternativo2 = 0, bool ck = false)
        {
            IdCtaCte = CtaCteMng.AddCtaCteDetalleRecord(TipoDocumentoXX, LX.ToString(), FechaConta, NumeroDocumento,
                documentoInterno, MonedaConta, importeConSigno, TC, importeConSigno, 0, idDocAlternativo2,
                idDocAlternativo1);
        }
        protected void AddData202(decimal importeConSigno, DateTime? fechaUltimaFacturaEmitida=null)
        {
            CtaCteMng.UpdateSaldoCtaCteResumen(LX.ToString(), importeConSigno, MonedaConta, TC,fechaUltimaFacturaEmitida);
        }
        public virtual int AddData208()
        {
            //Falta Implementar para Nota de Credito!
            //CtaCteMng.AddSinImputarRecord(FechaConta,)
            //CtaCteMng.AddSinImputarRecord(FechaConta,1,MonedaConta,Math.Abs(importec))
            //aca
            return 1;
        }

    }
}
