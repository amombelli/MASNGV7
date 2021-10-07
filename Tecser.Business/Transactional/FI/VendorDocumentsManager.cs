using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;



namespace Tecser.Business.Transactional.FI
{
    /// <summary>caducar .... pasar todo a vendormaindocument
    /// Maneja todo lo que tiene que ver con factura/NC/ND de proveedores
    /// </summary>
    public class VendorDocumentsManager
    {
        public T0403_VENDOR_FACT_H FacturaH;

        public VendorDocumentsManager()
        {
        }


        public int GetIdFacturaFromIdCtaCte(int idCtaCte)
        {
            var data =
                new Repository<T0403_VENDOR_FACT_H>(new TecserData(GlobalApp.CnnApp)).Find(c => c.IDCTACTE == idCtaCte).FirstOrDefault();

            if (data != null)
            {
                return data.IDINT;
            }
            else
            {
                return -1;
            }
        }

    }
}
