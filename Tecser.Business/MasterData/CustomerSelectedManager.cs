using System.Collections.Generic;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.MasterData
{

    public class CustomerSelectedManager
    {
        private int _idBillToSelected;
        private int _idShipToSelected;
        //Estrucutura
        public T0006_MCLIENTES BillTo;
        public List<T0007_CLI_ENTREGA> ShiTos;
        public int NumberOfShipTo;

        public CustomerSelectedManager(int id7)
        {
            _idShipToSelected = id7;
            _idBillToSelected = new CustomerManager().GetId6FromCustomerT7(id7);
            BillTo = new CustomerManager().GetCustomerBillToData(_idBillToSelected);
            ShiTos.Add(new CustomerManager().GetCustomerShipToData(_idShipToSelected));
        }

        public CustomerSelectedManager()
        {
        }

        public void SetShipTo(int id7)
        {
            _idShipToSelected = id7;
            _idBillToSelected = new CustomerManager().GetId6FromCustomerT7(id7);
            SetBillTo(_idBillToSelected);
        }

        public void SetBillTo(int id6)
        {
            CustomerManager cm = new CustomerManager();
            _idBillToSelected = id6;
            BillTo = new CustomerManager().GetCustomerBillToData(_idBillToSelected);
            NumberOfShipTo = cm.GetNumberofShipTos(id6, true);
            if (NumberOfShipTo > 1)
            {
                ShiTos = cm.GetShipToListFromBillTo(id6);
            }
            else
            {
                _idShipToSelected =
                    new Repository<T0007_CLI_ENTREGA>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IDCLIENTE == id6).ID_CLI_ENTREGA;
                ShiTos = new List<T0007_CLI_ENTREGA>();
                ShiTos.Add(new CustomerManager().GetCustomerShipToData(_idShipToSelected));
            }

        }

        public int GetId6Seleccionado()
        {
            return _idBillToSelected;
        }

        public int GetId7Seleccionado()
        {
            return _idShipToSelected;
        }




    }
}
