using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using TecserEF.Entity;

namespace Tecser.Business.MasterData
{
    public class CuentasManager
    {
        public CuentasManager()
        {

        }
        //Cuenta caja y banco debe mapear con todas las cuentas de la Tabla 150
        public enum CuentaCyB
        {
            EfectivoARS,
            EfectivoUSD,
            Cheque,
            Cooperativa1,
            Cooperativa2,
            SantanderCtaCte,
            IcbcCtaCte,
        };

        public List<T0150_CUENTAS> GetListaCuentasFondoFijo()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0150_CUENTAS.Where(c => c.ID_CUENTA.StartsWith("FF")).ToList();
            }
        }

        public T0150_CUENTAS GetSpecificCuentaInfo(string cuenta)
        {
            return new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.FirstOrDefault(c => c.ID_CUENTA == cuenta);
        }
        public List<T0150_CUENTAS> GetListCuentasAvailableCobranza()
        {
            return new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.Where(c => c.DisponibleCobranza).ToList();
        }
        public List<T0150_CUENTAS> GetListCuentasAvailableOP()
        {
            return new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.Where(c => c.DisponibleOP).ToList();
        }
        public List<T0150_CUENTAS> GetListCuentasAvailableTransferencia()
        {
            return new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.Where(c => c.DisponibleREG).ToList();
        }

        public List<T0150_CUENTAS> GetListaCuentasAvailableForContar(string moneda = "ARS")
        {
            return new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.Where(c => c.DisponibleContar && c.CUENTA_MONEDA.ToUpper().Equals(moneda.ToUpper())).ToList();
        }
        public string GetGL(string cuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0150_CUENTAS.SingleOrDefault(c => c.ID_CUENTA.ToUpper().Equals(cuenta.ToUpper()));
                return data == null ? "0.0.0.0" : data.GLMAP;
            }
        }

        public decimal GetSaldoCuenta(string nombreCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cta = db.T0155_SALDOS.SingleOrDefault(c => c.IDCUENTA == nombreCuenta);
                if (cta == null)
                    return 0;
                return cta.SALDO.Value;
            }
        }

        public decimal GetSaldoCuentaPendienteConversion(string nombreCuenta)
        {
            decimal retornoSinPresentar = 0;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cta = db.T0150_CUENTAS.SingleOrDefault(c => c.ID_CUENTA == nombreCuenta);
                if (cta == null)
                    return 0;
                var gl = cta.GLMAP;
                var datos =
                    db.T0406_RendicionFF_H.Where(
                        c => c.RendicionCuentaGL == gl && c.StatusRendicion == RendicionFF.StatusRendicion.Ingresado.ToString())
                        .ToList();
                if (datos.Count == 0)
                {
                    return 0;
                }
                else
                {
                    foreach (var i in datos)
                    {
                        retornoSinPresentar += i.ImporteNetoFinal.Value;
                    }

                }
                return retornoSinPresentar;
            }
        }


        public void UpdateSaldoCuenta(string nombreCuenta, decimal valorConSigno)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cta = db.T0155_SALDOS.SingleOrDefault(c => c.IDCUENTA == nombreCuenta);
                if (cta == null)
                    return;

                cta.SALDO = cta.SALDO + valorConSigno;
                cta.UMOV = DateTime.Now;
                db.SaveChanges();
            }
        }


        public static List<T0150_CUENTAS> GetCuentasDisponibleSyJ()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0150_CUENTAS.Where(c => c.DisponibleSYJ).ToList();
            }
        }
    }
}
