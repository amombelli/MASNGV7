using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CRM
{
    public class CustomerMessageManager
    {
        private int _idCliente;
        public TecserData Context = new TecserData(GlobalApp.CnnApp);

        public CustomerMessageManager(int idCliente)
        {
            _idCliente = idCliente;
        }

        public CustomerMessageManager()
        {
        }

        public void AsignaCliente(int idCliente)
        {
            _idCliente = idCliente;
        }

        public List<CustomerMensajes> GetListOfMessages()
        {
            return
                new TecserData(GlobalApp.CnnApp).CustomerMensajes.Where(c => c.idCliente == _idCliente)
                    .OrderByDescending(c => c.LogDate).ToList();
        }

        public BindingList<CustomerMensajes> GetActiveMessage()

        {
            Context.CustomerMensajes.Where(c => c.idCliente == _idCliente && c.Activo == true).Load();

            return Context.CustomerMensajes.Local.ToBindingList();
        }


        public List<CustomerMensajes> GetActiveMessage1()
        {
            return Context.CustomerMensajes.Where(c => c.idCliente == _idCliente && c.Activo == true).ToList();
        }

        public TecserData GetContextForActiveMessage()
        {
            Context.CustomerMensajes.Where(c => c.idCliente == _idCliente && c.Activo == true);
            return Context;
        }


    }
}
