using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Tools
{
    public static class ConfigurationDataT000
    {
        public static object GetValue(string key)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T000.SingleOrDefault(c => c.ID.ToUpper().Equals(key.ToUpper()));
                if (data == null)
                    return null;

                switch (data.TYPE)
                {
                    case "C":
                        return data.VALUE;

                    case "N":
                        return Convert.ToInt32(data.VALUE);

                    case "P":
                        return Convert.ToInt32(data.VALUE);

                    case "D":
                        return Convert.ToDecimal(data.VALUE);

                    case "I":
                        return Convert.ToInt32(data.VALUE);

                    case "B":
                        return Convert.ToBoolean(data.VALUE);

                    default:
                        return null;
                }
            }
        }
        public static bool SetData(string key, object value)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T000.SingleOrDefault(c => c.ID.ToUpper().Equals(key.ToUpper()));
                if (data == null)
                    return false;

                data.VALUE = value.ToString();
                return db.SaveChanges() > 0;
            }
        }
    }
}
