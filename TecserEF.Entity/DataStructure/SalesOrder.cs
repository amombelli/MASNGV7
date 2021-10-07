using System.Collections.Generic;

namespace TecserEF.Entity.DataStructure
{
    public class SalesOrder
    {
        public T0045_OV_HEADER Header;
        public List<T0046_OV_ITEM> Item = new List<T0046_OV_ITEM>();

        public SalesOrder()
        {
        }
    }
}
