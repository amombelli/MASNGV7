using System.Data.SqlClient;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.Tools
{
    public class ConfigurationKeyManager
    {
        public ConfigurationKeyManager(string key)
        {
            _key = key;
        }

        private readonly string _key;
        public string KeyType;
        private object _value;
        public bool keyExist;

        private bool KeyExist()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                try
                {
                    var data =
                        new Repository<TApplicationConfig>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IdKey == _key.Trim());

                    if (data != null)
                    {
                        KeyType = data.ValueType.ToUpper().Trim();
                        if (KeyType == "STRING")
                        {
                            _value = data.ValueString;
                        }
                        else
                        {
                            _value = (int)data.ValueInt;
                        }
                        keyExist = true;
                        return true;
                    }

                    keyExist = false;
                    KeyType = null;
                    return false;
                }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
                catch (SqlException e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
                {
                    //throw new System.Data.SqlClient.SqlException("No se encontro el server");
                }
                return false;
            }
        }

        public object GetValueData()
        {
            if (KeyExist())
            {
                if (_value != null)

                    return _value;

                return false;
            }

            return false;
        }



    }
}
