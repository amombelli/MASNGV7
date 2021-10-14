using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO16_MopSinRegistrar : Form
    {
        public FrmCO16_MopSinRegistrar()
        {
            InitializeComponent();
        }

        private void FrmCO16_MopSinRegistrar_Load(object sender, EventArgs e)
        {
            dgvRemitosSinIngresar.DataSource = new MopMapeo().GetDocumentosNotMapped(DateTime.Today.AddMonths(-8));
        }

        private void dgvRemitosSinIngresar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "ADD":
                    int idRemito = Convert.ToInt32(dgv[__idRemito.Name, e.RowIndex].Value);
                    int idFactura = Convert.ToInt32(dgv[__idFactura.Name, e.RowIndex].Value);
                    if (idRemito > 20000)
                    {
                        //es un remito en T0056
                        new MargenDocument().AddMargenDocumentAndMapCost(idRemito);
                    }
                    else
                    {
                        //ver como agregar NCD
                    }


                    //using (var db = new TecserData(GlobalApp.CnnApp))
                    //{
                    //    var x = db.T0140_MargenOperacion.Where(c => c.FechaFactura == null).ToList();
                    //    foreach (var f in x)
                    //    {
                    //        var fx = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDRemito == f.IdRemito);
                    //        if (fx != null)
                    //        {
                    //            //if (fx.IDFACTURA == 40137)
                    //            //{
                    //            //    var a = 1;
                    //            //}
                                //new MargenDocument().UpdateRemito_FacturaData(fx.IDFACTURA);
                    //            new MargenDocument().UpdateStatusCobranza(fx.IDFACTURA);
                    //            Debug.Print($"Linkeo Factura {fx.IDFACTURA}");
                    //        }
                    //        else
                    //        {
                    //            Debug.Print($"Factura No Encontrada--- IDRemito ={f.IdRemito} ");
                    //        }
                    //    }
                    //}





                    break;
                default:
                    break;
            }
        }
    }
}
