namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class VendorInvoice : VendorMainDocument
    {
        public VendorInvoice(string tcode, int idFactura) : base(tcode, idFactura)
        {

        }

        public VendorInvoice(int idVendor, string tcode) : base(idVendor, tcode)
        {

        }


    }
}
