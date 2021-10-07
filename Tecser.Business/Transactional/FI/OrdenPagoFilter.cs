using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class OrdenPagoFilter
    {
        public List<T0210_OP_H> GetOrdenPagoList(int? idVendor, string estadoOP = null, int top = 100)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idVendor == null)
                {
                    if (estadoOP == null)
                    {
                        //sin vendor y sin estado
                        return db.T0210_OP_H.OrderByDescending(c => c.LOG_DATE).Take(top).ToList();
                    }
                    else
                    {
                        //con estado
                        return
                            db.T0210_OP_H.Where(c => c.OP_STATUS.ToUpper().Equals(estadoOP.ToUpper()))
                                .OrderByDescending(c => c.LOG_DATE).Take(top).ToList();
                    }
                }
                else
                {
                    if (estadoOP == null) //con vendor
                    {
                        //con vendor y sin estado
                        return
                            db.T0210_OP_H.Where(c => c.PROV_ID == idVendor.Value)
                                .OrderByDescending(c => c.LOG_DATE)
                                .Take(top)
                                .ToList();
                    }
                    else
                    {
                        //con vendor y con estado
                        return
                            db.T0210_OP_H.Where(
                                c => c.PROV_ID == idVendor.Value && c.OP_STATUS.ToUpper().Equals(estadoOP.ToUpper()))
                                .OrderByDescending(c => c.LOG_DATE).Take(top).ToList();
                    }
                }
            }
        }
        public List<T0210_OP_H> GetOrdenPagoByNumber(int numeroOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0210_OP_H.Where(c => c.IDOP.ToString().Contains(numeroOP.ToString())).OrderByDescending(c => c.LOG_DATE).ToList();
            }
        }

        //





        public IList GetAllOPList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from op in db.T0210_OP_H
                            orderby op.OPFECHA descending
                            select new
                            {
                                NumeroOP = op.IDOP,
                                Fecha = op.OPFECHA,
                                RazonSocial = op.PROV_RS,
                                Moneda = op.MON_OP,
                                Importe = op.IMP_OP,
                                Estado = op.OP_STATUS
                            };
                return query.ToList();

            }
        }
        public IList GetListOP_IdProveedor(int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from op in db.T0210_OP_H
                            where op.PROV_ID == idProveedor
                            orderby op.OPFECHA descending
                            select new
                            {
                                NumeroOP = op.IDOP,
                                Fecha = op.OPFECHA,
                                RazonSocial = op.PROV_RS,
                                Moneda = op.MON_OP,
                                Importe = op.IMP_OP,
                                Estado = op.OP_STATUS
                            };
                return query.ToList();
            }
        }
        public IList GetListOP_IdOP(int idOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from op in db.T0210_OP_H
                            where op.IDOP == idOP
                            orderby op.OPFECHA descending
                            select new
                            {
                                NumeroOP = op.IDOP,
                                Fecha = op.OPFECHA,
                                RazonSocial = op.PROV_RS,
                                Moneda = op.MON_OP,
                                Importe = op.IMP_OP,
                                Estado = op.OP_STATUS
                            };
                return query.ToList();
            }
        }
        public IList GetListOP_IdProveedorEstado(int idProveedor, string estado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from op in db.T0210_OP_H
                            where op.PROV_ID == idProveedor && op.OP_STATUS.Trim().ToUpper().Equals(estado.ToUpper())

                            orderby op.OPFECHA descending
                            select new
                            {
                                NumeroOP = op.IDOP,
                                Fecha = op.OPFECHA,
                                RazonSocial = op.PROV_RS,
                                Moneda = op.MON_OP,
                                Importe = op.IMP_OP,
                                Estado = op.OP_STATUS
                            };
                return query.ToList();
            }
        }
        public IList GetListOP_Estado(string estado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from op in db.T0210_OP_H
                            where op.OP_STATUS.ToUpper().Equals(estado.ToUpper())
                            orderby op.OPFECHA descending
                            select new
                            {
                                NumeroOP = op.IDOP,
                                Fecha = op.OPFECHA,
                                RazonSocial = op.PROV_RS,
                                Moneda = op.MON_OP,
                                Importe = op.IMP_OP,
                                Estado = op.OP_STATUS
                            };
                return query.ToList();
            }
        }

        public T0210_OP_H GetOpData(int opNumber)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0210_OP_H.SingleOrDefault(c => c.IDOP == opNumber);
            }

        }
    }
}
