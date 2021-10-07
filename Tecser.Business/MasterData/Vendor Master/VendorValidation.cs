using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Vendor_Master
{
    public class VendorValidation: AbstractValidator<T0005_MPROVEEDORES>
    {
        public VendorValidation()
        {
           RuleFor(customer => customer.prov_rsocial).NotNull();
        }


    }
}
