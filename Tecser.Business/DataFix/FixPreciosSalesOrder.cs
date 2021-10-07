namespace Tecser.Business.DataFix
{
    public class FixPreciosSalesOrder
    {
        //public void FixPrecios()

        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        var data = db.T0046_OV_ITEM.Where(c => c.PRECIOTOTAL == null);
        //        foreach (var i in data)
        //        {
        //            switch (i.MODO.ToUpper())
        //            {
        //                case "L1":
        //                    i.PRECIO1 = i.PrecioUnitario;
        //                    i.PRECIO2 = 0;
        //                    break;
        //                case "L2":
        //                    i.PRECIO2 = i.PrecioUnitario;
        //                    i.PRECIO1 = 0;
        //                    break;
        //                case "L5":
        //                    if (i.PRECIO2 == null)
        //                    {
        //                        i.PRECIO2 = 0;
        //                    }
        //                    i.PRECIO1 = i.PrecioUnitario - i.PRECIO2;
        //                    break;
        //            }
        //            i.PRECIOTOTAL = i.PRECIO1 + i.PRECIO2;

        //        }
        //        db.SaveChanges();
        //    }
        //}
    }
}
