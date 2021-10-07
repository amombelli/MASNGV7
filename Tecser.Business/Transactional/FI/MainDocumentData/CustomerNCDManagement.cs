using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class CustomerNcdManagement
    {
        public CustomerNcdManagement(int idCliente, string tipoLx, ManageDocumentType.TipoDocumento tipoDocumento)
        {
            _idCliente = idCliente;
            _tipoDocumento = tipoDocumento;
            _tipoLx = tipoLx;

        }

        public CustomerNcdManagement(int idHeaderNcd)
        {
            _idHeaderNcd = idHeaderNcd;
        }

        //----------------------------------------------------------------------------------------------------------
        private int _idHeaderNcd;
        private readonly int _idCliente;
        private readonly string _tipoLx;
        private readonly ManageDocumentType.TipoDocumento _tipoDocumento;

        //----------------------------------------------------------------------------------------------------------
        public int AddNewDocument(DateTime fechaDoc, string comentario, string moneda, decimal exchangeRate, decimal importeDescuento, decimal importeIIBB)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = new T0300_NCD_H()
                {
                    IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1,
                    IdCliente = _idCliente,
                    RazonSocial = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial,
                    FECHA = fechaDoc,
                    COMENTARIO = comentario,
                    MON = moneda,
                    LOGDATE = DateTime.Now,
                    LOGUSER = Environment.UserName,
                    LX = _tipoLx,
                    TDOC = ManageDocumentType.GetSystemDocumentType(_tipoDocumento),
                    TC = exchangeRate,
                    TEMP = false,
                };
                h.NDOC = "NCD-" + h.IDH;
            }
            return 1;
        }
    }

}
