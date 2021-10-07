using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    public partial class FrmCentroPreparacionHojaRuta : Form
    {
        public FrmCentroPreparacionHojaRuta()
        {
            InitializeComponent();
            _ckStatus = new bool[3] { true, false, false };
        }

        private bool[] _ckStatus;
        private List<T0059_ENTREGAS> _listaEntregas = new List<T0059_ENTREGAS>();
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvEntregas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FrmHojaRutaPreparacion_Load(object sender, EventArgs e)
        {
            ckSinAsignar.Checked = true;
            ckEntregaACliente.Checked = false;
            ckRetiraCliente.Checked = false;
            ckSinRutaAsignada.Checked = true;

            _listaEntregas = new GestorEntregas().GetListEntregasPorTipo(_ckStatus);
            t0059ENTREGASBindingSource.DataSource = _listaEntregas;
            t0059ENTREGASBindingSource.DataSource = ckSinRutaAsignada.Checked
                ? _listaEntregas.Where(c => c.IdRutaAsignada == null).ToList()
                : _listaEntregas;
            dgvEntregas.DataSource = t0059ENTREGASBindingSource;

            t0059HOJARUTAHBindingSource.DataSource = new HojaRutaManager().GetListHojaRutas();
            dgvHojaRuta.DataSource = t0059HOJARUTAHBindingSource;

        }
        private void ckSinAsignar_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[3]
            {
                ckSinAsignar.Checked,
                ckEntregaACliente.Checked,
                ckRetiraCliente.Checked,
            };
            int clienteId = 0;
            if (string.IsNullOrEmpty(txtIdCliente.Text) == false)
                clienteId = Convert.ToInt32(txtIdCliente.Text);
            _listaEntregas = new GestorEntregas().GetListEntregasPorTipo(_ckStatus,
                txtNumeroRemito.Text, clienteId);
            t0059ENTREGASBindingSource.DataSource = ckSinRutaAsignada.Checked
                ? _listaEntregas.Where(c => c.IdRutaAsignada == null).ToList()
                : _listaEntregas;
        }
        private void ckSinRutaAsignada_CheckedChanged(object sender, EventArgs e)
        {
            t0059ENTREGASBindingSource.DataSource = ckSinRutaAsignada.Checked
                ? _listaEntregas.Where(c => c.IdRutaAsignada == null).ToList()
                : _listaEntregas;
        }
        private void txtNumeroRemito_Leave(object sender, EventArgs e)
        {
            int clienteId = 0;
            if (string.IsNullOrEmpty(txtIdCliente.Text) == false)
                clienteId = Convert.ToInt32(txtIdCliente.Text);
            _listaEntregas = new GestorEntregas().GetListEntregasPorTipo(_ckStatus,
                txtNumeroRemito.Text, clienteId);
            t0059ENTREGASBindingSource.DataSource = ckSinRutaAsignada.Checked
                ? _listaEntregas.Where(c => c.IdRutaAsignada == null).ToList()
                : _listaEntregas;

        }
        private void btnNewHRuta_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Desea crear una nueva hoja de ruta?", @"Nuevo Reparto", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            using (var f0 = new FrmHojaRuta(1, 0))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //string custName = f0.CustomerName;
                    //SaveToFile(custName);
                }
            }
        }
        private void dgvHojaRuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvHojaRuta[e.ColumnIndex, e.RowIndex].Value.ToString();
                int idRuta = Convert.ToInt32(dgvHojaRuta[dgvHojaRuta.Columns["idRutaDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "VER":
                        using (var f0 = new FrmHojaRuta(2, idRuta))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
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
        }
    }
}

/***en el otro form
		this.Close();
		this.DialogResult = DialogResult.OK;
		return;

        }
    }
}*/
