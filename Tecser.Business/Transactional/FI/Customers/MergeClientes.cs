using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Customers
{
    public class MergeClientes
    {
        public MergeClientes(int idCaducar, int idMantener)
        {
            _idCaducar = idCaducar;
            _idMantener = idMantener;
        }

        private readonly int _idCaducar;
        private readonly int _idMantener;

        public bool Merge201()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0201_CTACTE.Where(c => c.IDCLI == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.IDCLI = _idMantener;
                    LogMergeData("T0201_CTACTE", item.IDCTACTE);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool Merge202(string tipoLX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == _idCaducar && c.CUENTATIPO == tipoLX);
                if (x != null)
                {
                    var clinuevo =
                        db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == _idMantener && c.CUENTATIPO == tipoLX);
                    if (clinuevo != null)
                    {
                        clinuevo.DEUDA_ARS = clinuevo.DEUDA_ARS + x.DEUDA_ARS;
                        clinuevo.DEUDA_USD = clinuevo.DEUDA_USD + x.DEUDA_USD;
                        clinuevo.DEUDA_TOT_ARS = clinuevo.DEUDA_TOT_ARS + x.DEUDA_TOT_ARS;
                        var a = db.SaveChanges();
                        if (a > 0)
                        {
                            x.DEUDA_ARS = 0;
                            x.DEUDA_ARS = 0;
                            x.DEUDA_TOT_ARS = 0;
                            db.SaveChanges();
                        }
                        return a > 0;
                    }
                }
                return false;
            }
        }
        public bool Merge207()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0207_SPLITFACTURAS.Where(c => c.CLIENTE == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.CLIENTE = _idMantener;
                    LogMergeData("T0207_SPLITFACTURAS", item.IDCTACTE);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool Merge208()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.CLIENTE = _idMantener;
                    LogMergeData("T0208_COB_NO_APLICADA", item.ID);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeCobranzas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0205_COBRANZA_H.Where(c => c.IdCliente == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.IdCliente = _idMantener;
                    LogMergeData("T0205_COBRANZA_H", item.IDCOB);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeCheques()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var clienteCaducar = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == _idCaducar).cli_fantasia;
                var clienteNuevo = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == _idMantener).cli_fantasia;
                var x = db.T0154_CHEQUES.Where(c => c.CLIENTE == clienteCaducar).ToList();
                foreach (var item in x)
                {
                    item.CLIENTE = clienteNuevo;
                    LogMergeData("T0154_CHEQUES", item.IDCHEQUE, dataString: clienteCaducar);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeRemitos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0055_REMITO_H.Where(c => c.T0007_CLI_ENTREGA.IDCLIENTE == _idCaducar).ToList();
                var idEntrega = db.T0007_CLI_ENTREGA.FirstOrDefault(c => c.IDCLIENTE == _idMantener).ID_CLI_ENTREGA;
                foreach (var item in x)
                {
                    LogMergeData("T0055_REMITO_H", item.IDREMITO, dataInt: (int)item.CODCLIENTREGA);
                    item.CODCLIENTREGA = idEntrega;
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeOrdenVenta()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0045_OV_HEADER.Where(c => c.T0007_CLI_ENTREGA.IDCLIENTE == _idCaducar).ToList();
                var idEntrega = db.T0007_CLI_ENTREGA.FirstOrDefault(c => c.IDCLIENTE == _idMantener).ID_CLI_ENTREGA;
                foreach (var item in x)
                {
                    LogMergeData("T0045_OV_HEADER", item.IDOV, dataInt: item.CLIENTE.Value);
                    item.CLIENTE = idEntrega;

                }

                var z = db.T0046_OV_ITEM.Where(c => c.ClienteRZ == _idCaducar).ToList();
                foreach (var item in z)
                {
                    item.ClienteRZ = _idMantener;
                    LogMergeData("T0046_OV_ITEM", item.IDOV);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeT40()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0040_MAT_MOVIMIENTOS.Where(c => c.IDCLI == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.IDCLI = _idMantener;
                    LogMergeData("T0040_MAT_MOVIMIENTOS", item.IDMOVIMIENTO);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeAsientos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idclienteCaducar = _idCaducar.ToString();
                var x = db.T0602_DOCU_S.Where(c => c.CLIENTE == idclienteCaducar).ToList();
                foreach (var item in x)
                {
                    item.CLIENTE = _idMantener.ToString();
                    LogMergeData("T0602_DOCU_S", item.IDDOCU, dataInt: item.IDSEG);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool MergeFacturas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.Where(c => c.Cliente == _idCaducar).ToList();
                foreach (var item in x)
                {
                    item.Cliente = _idMantener;
                    LogMergeData("T0400_FACTURA", item.IDFACTURA);
                }
                return db.SaveChanges() > 0;
            }
        }
        private void LogMergeData(string tabla, int id, string dataString = null, int dataInt = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var log = new T1010_LOGCUSTOMERMERGE();
                log.CustomerCaducado = _idCaducar;
                log.CustomerToMerge = _idMantener;
                log.Tabla = tabla;
                log.LogUsername = Environment.UserName;
                log.LogDateTime = DateTime.Now;
                if (dataString != null)
                {
                    log.Key3 = dataString;
                }

                if (dataInt > 0)
                {
                    log.Key2 = dataInt;
                }
                log.Key1 = id;
                db.T1010_LOGCUSTOMERMERGE.Add(log);
                //db.SaveChanges();
            }
        }
    }
}
