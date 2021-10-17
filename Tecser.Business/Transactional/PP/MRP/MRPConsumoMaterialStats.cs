using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP.MRP
{

    /// <summary>
    /// Clase que retorna KG segun movimientos
    /// </summary>
    public class MRPConsumoMaterialStats
    {
        public string Material { get; private set; }
        public decimal KgFabricados { get; private set; }
        public decimal KgConsumidos { get; private set; }
        public decimal KgDespachados { get; private set; }
        public decimal KgRetornados { get; private set; }
        public DateTime fechaDesde { get; private set; }

        public MRPConsumoMaterialStats(string material)
        {
            Material = material.ToUpper();
            KgFabricados = 0;
            KgConsumidos = 0;
            KgDespachados = 0;
            KgRetornados = 0;
        }

        public void CalculoDeConsumo(int diasCalculo = 30)
        {
            if (diasCalculo < 1) diasCalculo = 30;
            fechaDesde = DateTime.Today.AddDays(diasCalculo * -1);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var p = from mov in db.T0040_MAT_MOVIMIENTOS
                        where
                            (mov.TIPOMOVIMIENTO == 50 || mov.TIPOMOVIMIENTO == 51 || mov.TIPOMOVIMIENTO == 5 ||
                             mov.TIPOMOVIMIENTO == 6 || mov.TIPOMOVIMIENTO == 7 || mov.TIPOMOVIMIENTO == 10 ||
                             mov.TIPOMOVIMIENTO == 11 || mov.TIPOMOVIMIENTO == 1 || mov.TIPOMOVIMIENTO == 2) &&
                            (mov.FECHAMOV >= fechaDesde) &&
                            mov.IDMATERIAL.ToUpper().Equals(Material)
                        group mov by new
                        {
                            mov.TIPOMOVIMIENTO
                        }
                    into grp
                        select new
                        {
                            TipoMov = grp.Key.TIPOMOVIMIENTO.Value,
                            SumKG = grp.Sum(x => x.CANTIDAD.Value)
                        };

                foreach (var i in p)
                {
                    switch (i.TipoMov)
                    {
                        case 1:
                        case 2:
                            KgFabricados += i.SumKG;
                            break;
                        case 5:
                        case 6:
                        case 7:
                            KgRetornados += i.SumKG;
                            break;
                        case 10:
                        case 11:
                            KgConsumidos += i.SumKG;
                            break;
                        case 50:
                        case 51:
                            KgDespachados += i.SumKG;
                            break;
                    }

                    Console.WriteLine($"Tipo Movimiento {i.TipoMov} KG= {i.SumKG}");
                }

                KgConsumidos = KgConsumidos * -1;
                KgDespachados = KgDespachados * -1;
            }
        }

    }
}
