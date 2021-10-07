using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class PFFixSinIdItem
    {
        public PFFixSinIdItem(int idplan)
        {
            _idplan = idplan;
        }

        private readonly int _idplan;

        public int FixT0072_SIN_IDITEM()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                var t72 = db.T0072_FORMULA_TEMP.Count(c => c.OF == _idplan && c.idItemFormula == null);
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                if (t72 > 0)
                {
                    //Reasigno
                    var x = db.T0072_FORMULA_TEMP.Where(c => c.OF == _idplan).ToList();
                    int id = 1;
                    foreach (var item in x)
                    {
                        item.idItemFormula = id;
                        var ofprint =
                            db.T0073_FORMULA_PRINT.SingleOrDefault(
                                c =>
                                    c.OF == item.OF && c.Primario == item.Primario && c.Modificado == item.Modificado && c.BatchNumber == item.BatchNumber);
                        if (ofprint != null)
                        {
                            ofprint.idItemFormula = id;
                            id++;
                        }
                    }

                }
                return db.SaveChanges();

            }

        }



    }
}
