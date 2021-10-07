using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    /// <summary>
    /// Fecha Creacion 2018.03.28
    /// Manejo de contabilizacion completa desde documentos FI (Factura, OP, NC,ND, etc)
    /// Coordina la contabilizacion completa. - Cada clase hace su tarea
    /// </summary>
    public abstract class ContaDocumentBase
    {
        protected ContaDocumentBase(string tcode)
        {
            Tcode = tcode;
        }

        //-------------------------------------------------------------------------------
        protected string Tcode { get; set; }
        public string TipoLx { get; protected set; }
        protected int IdEntidad { get; set; }
        public string TipoDocSystem { get; protected set; }

        protected ManageDocumentType.TipoDocumento TipoDocumento;
        public int IdCtaCte { get; protected set; }

        //-------------------------------------------------------------------------------

        protected T0605_DOCUCONFIG GetDocumentConfigInformation(ManageDocumentType.TipoDocumento documentType)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0605_DOCUCONFIG.SingleOrDefault(c => c.DESCRIPCION_ENUM == documentType.ToString());
            }
        }
        protected abstract void AddRecordCtaCteDetalle201207(); //T0201 - T0203
        protected abstract void UpdateCtaCteSaldo(string tipoLx, string moneda, decimal importeConSigno, decimal? exchangeRate = null); //T0202 - T0204
        protected abstract void SetTipoDocumento();
        protected abstract void LoadDataInObjectMemory();

    }
}
