using System;

namespace MASngFE._0TSUserControls
{
    public class TsCustomerSearchEventArgs : EventArgs
    {
        public int? ClienteId;
        public string RazonSocial;
        public string Fantasia;
    }

    public class CustomerSearchUcV3Args : EventArgs
    {
        public int? ClienteId;
        public string RazonSocial;
        public string Fantasia;
        public string Cuit;
    }
}