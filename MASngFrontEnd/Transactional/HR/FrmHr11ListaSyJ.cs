using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHr11ListaSyJ : Form
    {
        public FrmHr11ListaSyJ()
        {
            InitializeComponent();
        }

        private List<T0550_HHRR_SYJ_Header> _headerList;

        private void FrmHr11ListaSyJ_Load(object sender, EventArgs e)
        {
            _headerList = new SyJManagerNew().GetHeaders();
            rbAll.Checked = true;
        }


        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            int idSyj = Convert.ToInt32(datagridview[__id.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmHr10CargaSyj(2, idSyj))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;
                case "PAGAR":
                    using (var f0 = new FrmHr12PagoSyJ(idSyj))
                    {
                        if (f0.ShowDialog() == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void radioVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                dgvLista.DataSource = _headerList;
            }
            else
            {
                dgvLista.DataSource = _headerList.Where(c => c.MontoAdeudado >= 0).ToList();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
