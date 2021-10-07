namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    /// <summary>
    /// 2018.03.20 
    /// Clase Base de mantenimiento de Documentos (400.401.403.404)
    /// </summary>
    public abstract class MainDocumentBase
    {
        protected MainDocumentBase(int idEntidad, string tcode)
        {
            Tcode = tcode;
            IdEntidad = idEntidad;
        }

        protected MainDocumentBase(string tcode, int idDocument)
        {
            Tcode = tcode;
            IdDocument = idDocument;
        }

        protected int IdDocument;               //Id documento principal    --
        protected readonly string Tcode;        //Desde el constructor      --
        protected string Moneda;
        protected decimal ImporteARS;
        protected decimal ImporteOri;
        protected readonly int IdEntidad;

        public struct FacturaId
        {
            public int IdFactura { get; set; }
            public decimal IdFacturaX { get; set; }
            public int CantidadItems { get; set; }
        }
        protected string TipoLX { get; set; }
        protected decimal ExchangeRate;
        protected string TipoDocSystem; //(OP,FA,NC,ND)
        protected string NumeroDocumento { get; set; } = "???? -????????";
        protected bool ModificaSigno { get; set; } = false; //Si true los valores se pasan invertidos
        protected bool InicializacionCorrecta { get; set; } = false;
        protected DocumentFIStatusManager.StatusHeader StatusDocumento; //tendrian que ser los mismos status vendor/custome
        protected abstract bool AddMainDocumentHeader();
        protected abstract bool AddMainDocumentItems();
        protected abstract void LoadDataObject();

    }
}
