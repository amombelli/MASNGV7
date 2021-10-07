using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Tools
{
    public class ColumnsName
    {
        public List<string> GetColumnsName(string tableName)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var names = typeof(T0005_MPROVEEDORES).GetProperties()
                    .Select(property => property.Name)
                    .ToArray();

                return names.ToList();
            }
        }


    }


}
