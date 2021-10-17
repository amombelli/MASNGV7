namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class ContaClienteFacturaL2 : ContaClienteT400L1
    {
        public ContaClienteFacturaL2(int idFactura, int idCliente) : base(idFactura, idCliente)
        {
            Signo = 1;
            TipoDocumentoXX = "FA";
        }

        public void ContabilizacionCompleta()
        {

        }



    }
}
