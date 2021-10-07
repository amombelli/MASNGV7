using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class SubdiarioCajaManager
    {
        public SubdiarioCajaManager()
        {

        }

        public enum PC
        {
            Cliente,
            Proveedor,
            Empleado,
        };
        public bool WriteToDb(string cuentaOrigen, DateTime fechaOperacion, PC clienteProveedor, int numeroPC,
            string tipoDocumento, string numeroDocumento, string descripcion, string moneda, decimal importeIngreso,
            decimal importeEgreso, string tipoLX, string tCode, int numeroAsiento, string centroCosto = null,
            string cuentaDestinoTransferencia = null, string status = null, int idCheque = -1)
        {
            var data = new XREGISTER
            {
                IDC = cuentaOrigen,
                Fecha = fechaOperacion,
                XMES = new PeriodoConversion().GetMesMm(fechaOperacion),
                XYEAR = new PeriodoConversion().GetYearYyyy(fechaOperacion),
                Tdoc = tipoDocumento,
                Ref = numeroDocumento,
                PCID = numeroPC,
                Descripcion = descripcion,
                CCosto = centroCosto,
                XTransf = cuentaDestinoTransferencia,
                Moneda = moneda,
                Monto_I = importeIngreso,
                Monto_E = importeEgreso,
                LogUser = Environment.UserDomainName,
                LogFecha = DateTime.Now,
                ST = status,
                TIPO = tipoLX,
                CC = centroCosto,
                NAS = numeroAsiento,
                TCODE = tCode,

            };

            switch (clienteProveedor)
            {
                case PC.Cliente:
                    data.PC = "C";
                    data.Entidad = new CustomerManager().GetCustomerBillToData(numeroPC).cli_rsocial;
                    break;
                case PC.Empleado:
                    data.PC = "E";
                    data.Entidad = new VendorManager().GetSpecificVendor(numeroPC).prov_rsocial;
                    break;
                case PC.Proveedor:
                    data.PC = "P";
                    data.Entidad = new VendorManager().GetSpecificVendor(numeroPC).prov_rsocial;
                    break;
                default:
                    data.PC = "T";
                    data.Entidad = "Transferencia";
                    break;
            }

            if (idCheque > 0)
            {
                var cheque = new ChequesManager().GetCheque(idCheque);
                data.CH_BCO = cheque.CHE_BANCO;
                data.CH_FEC = cheque.CHE_FECHA;
                data.CH_ID = idCheque;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                data.IDT = db.XREGISTER.Max(c => c.IDT) + 1;
                db.XREGISTER.Add(data);
                if (db.SaveChanges() > 0)
                {
                    UpdateSaldoCuenta(cuentaOrigen, importeIngreso, importeEgreso);
                    return true;
                }
                return false;
            }
        }

        private static decimal UpdateSaldoCuenta(string cuenta, decimal montoIngreso = 0, decimal montoEgreso = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0155_SALDOS.SingleOrDefault(c => c.IDCUENTA == cuenta);
                if (data != null)
                {
                    data.SALDO = data.SALDO + montoIngreso - montoEgreso;
                    data.UMOV = DateTime.Now;
                    db.SaveChanges();
                    return Convert.ToDecimal(data.SALDO);
                }
                return 0;

            }
        }
    }


}
