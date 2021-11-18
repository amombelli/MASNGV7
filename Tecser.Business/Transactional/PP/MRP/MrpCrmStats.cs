using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP.MRP
{
    public class MrpCrmStats
    {

        //Maneja datos de CRM - Cliente/ Estadisticas de consumo - etc

        private readonly string _material;

        public struct RetornoVeces
        {
            public int IdCliente;
            public int Veces;
            public decimal KGVendidos;
        }
        public DateTime fechaDesde { get; private set; }
        public MrpCrmStats(string material)
        {
            _material = material.ToUpper();
        }
        //Ejecutar un fix para convertir todos los movimientos 50 en negativos y todos los 51 en positivos. 
        public int RegistrosVentas { get; private set; }
        public decimal KgVendidos { get; private set; }
        public decimal CantidadClientes { get; private set; }
        public List<RetornoVeces> Lista { get; private set; }
        public int VecesMinimo { get; private set; }

        //
        public void EstadisticasDespachoMaterial(int vecesminimo, int diasEvaluacion)
        {
            if (vecesminimo < 1) VecesMinimo = 1;
            if (diasEvaluacion < 1) diasEvaluacion = 30;
            fechaDesde = DateTime.Today.AddDays(diasEvaluacion * -1);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from tmov in db.T0040_MAT_MOVIMIENTOS
                            where (tmov.TIPOMOVIMIENTO == 50 || tmov.TIPOMOVIMIENTO == 51) && tmov.FECHAMOV >= fechaDesde &&
                                  tmov.IDMATERIAL.ToUpper().Equals(_material)
                            select new
                            {
                                tmov.TIPOMOVIMIENTO,
                                IDCLI = tmov.IDCLI ?? 0,
                                KG = tmov.CANTIDAD ?? 0
                            };

                RegistrosVentas = query.Count(c => c.TIPOMOVIMIENTO == 50) - query.Count(c => c.TIPOMOVIMIENTO == 51);
                if (RegistrosVentas > 0)
                {
                    KgVendidos = query.Sum(c => c.KG) * -1;
                }
                else
                {
                    KgVendidos = 0;
                }

                var query2 = from tmov2 in query
                             group tmov2 by new
                             {
                                 Cliente = tmov2.IDCLI
                             }
                    into g
                             select new
                             {
                                 cliente = g.Key.Cliente,
                                 KgDespachados = g.Sum(c => c.KG),
                                 CantOperaciones = g.Count(c => c.TIPOMOVIMIENTO == 50) - g.Count(c => c.TIPOMOVIMIENTO == 51)
                             };
                CantidadClientes = query2.Count(c => c.KgDespachados != 0);
                Lista = new List<RetornoVeces>();
                foreach (var item in query2)
                {
                    var i0 = new RetornoVeces()
                    {
                        IdCliente = item.cliente,
                        Veces = item.CantOperaciones,
                        KGVendidos = item.KgDespachados
                    };
                    Lista.Add(i0);
                    Console.WriteLine($"Item {item.cliente} -- Kg Totales = {item.KgDespachados}");
                }
            }
        }
    }
}
