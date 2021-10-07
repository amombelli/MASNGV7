using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class PpFix
    {


        public static int FixIdItemNull(int numeroOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF).Max(c => c.idItemFormula);

#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                if (max == null)
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                {
                    max = 0;
                    //Asigna todos los numeros
                }

                var result = db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF).OrderBy(c => c.idItemFormula).ToList();
                var cant = result.Count();

                if (max == cant)
                {
                    //all records are OK
                }
                else
                {

                    foreach (var item in result)
                    {
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                        if (item.idItemFormula == null || item.idItemFormula == 0)
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                        {
                            max++;
                            item.idItemFormula = max;
                        }
                    }
                }
                return db.SaveChanges();

            }
        }


    }
}
