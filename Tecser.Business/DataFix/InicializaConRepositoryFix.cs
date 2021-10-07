using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.DataFix
{
    public static class InicializaConRepositoryFix
    {
        public static void Init()
        {
            var x = new Repository<T0013_COLORES>(new TecserData(GlobalApp.CnnApp)).GetAll();
        }
    }
}
