using System;

namespace Tecser.Business.Transactional.FI
{
    public class ComboboxTipoDocumento
    {
        public enum VendorDocumentType
        {
            FPA,
            FPB,
            FPC,
            RPC,
            NCA,
            NDA,
            VEP,
            IMP,
            TKT,
            NON,
        };

        public VendorDocumentType MapFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return VendorDocumentType.FPA;

            //Mapeo to fix errores
            if (status.ToUpper().Equals("@@") || status.ToUpper().Equals("@@@"))
                return VendorDocumentType.FPA;

            try
            {
                return (VendorDocumentType)Enum.Parse(typeof(VendorDocumentType), status, true);
            }
            catch (Exception)
            {
                return VendorDocumentType.FPA;
                throw;
            }
        }

        public string Text { get; set; }
        public VendorDocumentType Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public VendorDocumentType ValueZ()
        {
            return Value;
        }

    }
}
