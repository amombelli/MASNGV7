using System.Data.Entity;

namespace TecserSQL.Data.EDMX.TSSecurity
{
    public partial class TecserDataS : DbContext
    {
        public TecserDataS(string con)
            : base(con)
        {
        }
    }
}
