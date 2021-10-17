using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;
using TecserSQL.Data.MasterData;

namespace Tecser.Business.MasterData
{
    public class CustomerManager
    {
        public CustomerManager()
        {

        }

        public bool IsActivo(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente).ACTIVO;
            }
        }

        public bool CuitIsAlreadyInDb(string numeroCuit)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cust = db.T0006_MCLIENTES.Where(c => c.CUIT == numeroCuit).ToList();
                if (cust.Count > 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Funcion usada para retornar el cliente desde vendor master al crear un nuevo
        /// </summary>
        public T0006_MCLIENTES ReturnCustomerByCuit(string numeroCUIT, string ttaxId = "80")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.FirstOrDefault(c => c.CUIT == numeroCUIT && c.TTAX == ttaxId);
                return cli;
            }
        }


        public void UpdateZterm(int idCliente, string ztermL1, string ztermL2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                cust.ZTERML1 = ztermL1;
                cust.ZTERML2 = ztermL2;
                db.SaveChanges();
            }
        }
        public void UpdateComentarioCliente(int idCliente, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                cust.Comentario = cust.Comentario + " - " + comentario;
                db.SaveChanges();
            }
        }
        public void UdpdateCreditLimite(int idCliente, decimal? limiteCredito, bool autoLimit, int autoLimitDays)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (limiteCredito == null)
                {
                    cust.Limite_credito = null;
                }
                else
                {
                    cust.Limite_credito = Convert.ToInt32(limiteCredito.Value);
                }
                cust.AutoCreditLimit = true;
                cust.AutoCreditLimitDays = autoLimitDays;
                db.SaveChanges();
            }
        }
        public bool CustomerBloqueadoDelivery(int id6)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0006_MCLIENTES.Single(c => c.IDCLIENTE == id6).BLK_DELIVERY;
            }
        }
        public bool CustomerBloqueadoIngresoPedido(int id6)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0006_MCLIENTES.Single(c => c.IDCLIENTE == id6).BLK_PEDIDO;
            }
        }


        /// <summary>
        /// Chequea por aproximacion si la calle existe para ese cliente.
        /// La regla es que toma el menor de los dos y se fija si esta adentro del otro
        /// un fragmento de 4 caracteres seguidos.
        /// </summary>
        public bool CheckIfShipToAddressExist(int id6, string calle)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                bool ex = false;
                string extract;
                var cli7 = db.T0007_CLI_ENTREGA.Where(c => c.IDCLIENTE == id6).ToList();
                foreach (var c in cli7)
                {
                    var lengthDb = c.Direccion_Entrega.Length;
                    var lenghtNew = calle.Length;
                    if (lengthDb < lenghtNew)
                    {
                        if (lengthDb > 6)
                        {
                            extract = c.Direccion_Entrega.Substring((lengthDb / 2) - 2, 4);
                            if (calle.Contains(extract))
                                ex = true;
                        }
                        else
                        {
                            //no se puede chequear porque es demasiado corto
                        }
                    }
                    else
                    {
                        if (lenghtNew > 6)
                        {
                            extract = calle.Substring((lengthDb / 2) - 2, 4);
                            if (c.Direccion_Entrega.Contains(extract))
                                ex = true;
                        }
                    }
                }

                return ex;
            }
        }

        /// <summary>
        /// Chequea que no exista una descripcion identica para otro shipto
        /// </summary>
        public bool CheckIfShipToDescriptionExist(int id7, string descripcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0007_CLI_ENTREGA.Where(c =>
                    c.ID_CLI_ENTREGA != id7 && c.Direccion_Entrega.ToUpper().Equals(descripcion.ToUpper())).ToList();
                if (z.Count == 0)
                    return false;
                return true;
            }
        }


        public List<T0006_MCLIENTES> GetCompleteListofBillTo(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return onlyActive ? db.T0006_MCLIENTES.Where(c => c.ACTIVO).ToList() : db.T0006_MCLIENTES.ToList();
            }
        }
        public IList<T0007_CLI_ENTREGA> GetCompleteListofShipTo(bool onlyActive)
        {
            if (onlyActive == true)
            {
                return new Repository<T0007_CLI_ENTREGA>(new TecserData(GlobalApp.CnnApp)).Find(c => c.Activo == true).ToList();
            }
            else
            {
                return new Repository<T0007_CLI_ENTREGA>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            }
        }
        public int GetNumberofShipTos(int id6, bool onlyActive)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive == false)
                {
                    return db.T0007_CLI_ENTREGA.Count(c => c.IDCLIENTE == id6);
                }
                else
                {
                    return db.T0007_CLI_ENTREGA.Count(c => c.IDCLIENTE == id6 && c.Activo == true);
                }
            }
        }
        public int GetId6FromCustomerT7(int id7)
        {
            var x = new CustomerBillTo(new TecserData(GlobalApp.CnnApp));
            return x.GetId6FromCustomerT7(id7, GlobalApp.CnnApp);
        }
        public T0006_MCLIENTES GetCustomerBillToData(int id6)
        {
            return new Repository<T0006_MCLIENTES>(new TecserData(GlobalApp.CnnApp)).Get(id6);
        }
        public T0007_CLI_ENTREGA GetCustomerShipToData(int id7)
        {
            return new Repository<T0007_CLI_ENTREGA>(new TecserData(GlobalApp.CnnApp)).Get(id7);
        }
        public List<T0007_CLI_ENTREGA> GetShipToListFromBillTo(int id6, bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    return db.T0007_CLI_ENTREGA.Where(c => c.IDCLIENTE == id6 && c.Activo).ToList();
                }
                else
                {
                    return db.T0007_CLI_ENTREGA.Where(c => c.IDCLIENTE == id6).ToList();
                }
            }
        }
        public List<T0006_MCLIENTES> GetCustomersByFantasyName(string clienteFantasia)
        {
            return
                new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.Where(c => c.cli_fantasia.ToUpper().Contains(clienteFantasia.ToUpper()))
                    .ToList();
        }

        public static int SetNextAvailableId7()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0007_CLI_ENTREGA.Max(c => c.ID_CLI_ENTREGA) + 1;
            }
        }
        public static int SetNextAvailableId6()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0006_MCLIENTES.Max(c => c.IDCLIENTE) + 1;
            }
        }
        public int SaveShipToData(T0007_CLI_ENTREGA c7)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (c7.ID_CLI_ENTREGA > 0)
                {
                    //Existing shipto
                    var data = db.T0007_CLI_ENTREGA.SingleOrDefault(c => c.ID_CLI_ENTREGA == c7.ID_CLI_ENTREGA);
                    if (data != null)
                    {
                        db.Entry(data).CurrentValues.SetValues(c7);
                        c7.Log_Date = DateTime.Today;
                        c7.Log_User = Environment.UserName;
                    }
                    else
                    {
                        //Se suponia que el shipto tenia que existir
                        //lanzar una excepcion  todo lanzar excepcion

                    }
                }
                else
                {
                    c7.ID_CLI_ENTREGA = SetNextAvailableId7();
                    c7.Fecha_Ingreso = DateTime.Today;
                    c7.Log_Date = DateTime.Today;
                    c7.Log_User = Environment.UserName;
                    db.T0007_CLI_ENTREGA.Add(c7);
                }
                if (db.SaveChanges() > 0)
                    return c7.ID_CLI_ENTREGA;
                return 0;
            }
        }
        public void UpdateZTermSegunLx(int idCliente, string lx, string condicionPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var customer = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (customer == null)
                    return;

                if (lx == "L1")
                {
                    customer.ZTERML1 = condicionPago;
                }
                else
                {
                    customer.ZTERML2 = condicionPago;
                }
                db.SaveChanges();
            }
        }
        public void UpdateDatosCobranza(int idCliente, string contacto, string telefono1, string telefono2, string emailCob, string direccionCob, string diasHorarioPago, bool direccionFiscal)
        {
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var customer = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                    if (customer == null)
                        return;
                    customer.CONTACTO_COB = contacto;
                    customer.TELEFONO_COB = telefono1;
                    customer.TelefonoCobranza2 = telefono2;
                    customer.EMAIL_COBR = emailCob;
                    customer.DIRECCION_COBRO_ALT = !direccionFiscal ? direccionCob : null;
                    customer.DIA_HORARIO_COBRO = diasHorarioPago;
                    db.SaveChanges();
                }
            }
        }
    }
}
