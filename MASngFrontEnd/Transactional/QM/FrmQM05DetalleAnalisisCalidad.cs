using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm05DetalleAnalisisCalidad : Form
    {
        public FrmQm05DetalleAnalisisCalidad(int idQm, int modo = 1)
        {
            _idQm = idQm;
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------------
        private readonly int _idQm;

        private string _plan;
        //--------------------------------------------------------------------------------------------


        private void BtnSalirOP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmQMAnalisisDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var Header = new QmManageList().GetQmHeader(_idQm);
            txtIP.Text = _idQm.ToString();
            txtMaterial.Text = Header.MATERIAL;
            txtLote.Text = Header.LOTE;
            _plan = Header.PlanName;
            txtPlanName.Text = Header.PlanName;
            txtOrigen.Text = Header.Origen;
            if (Header.IdOrigen != null)
                txtReferencia.Text = Header.IdOrigen.Value.ToString();

            if (Header.Origen == "C")
            {
                if (Header.IdOrigen != null)
                {
                    var data = new IngresoStockManager().GetitemIngresadoCompra(Header.IdOrigen.Value);
                    if (data != null)
                        txtSource.Text = data.PRAZONSOCIAL;
                }
            }
            txtStatusMaterial.Text = Header.EstadoMaterial;
            txtStatusPlan.Text = Header.EstadoPlan;
            txtFechaIngreso.Text = Header.FechaINPlan.Value.ToString("d");

            if (Header.FechaStart != null)
                txtFechaStart.Text = Header.FechaStart.Value.ToString("d");

            if (Header.FechaFinish != null)
                txtFechaFinish.Text = Header.FechaFinish.Value.ToString("d");

            t0811CQIBindingSource.DataSource = new QmManageList().GetQmIpList(_idQm);
        }

        private void BtnAddMetodo_Click(object sender, EventArgs e)
        {

        }

        private void DgvIP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string nombreColumna = null;

            if (e.RowIndex < 0)
            {
                return;
            }
            var idCounter = Convert.ToInt32(dgv[dgv.Columns[cOUNTERDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);
            var data = new QmManageList().GetInspectionDetail(_idQm, idCounter);
            txtCounter.Text = idCounter.ToString();
            txtIdCaracteristica.Text = data.METODO;
            var metodo = new QmManageList().GetMetodo(data.METODO);
            var definicionIP = new QmMasterIplan().GetPlanDetailSpecific(_plan, data.METODO);
            txtCaracteristica.Text = metodo.Descripcion;
            if (definicionIP != null)
            {
                txtValorMin.Text = definicionIP.ValorMin;
                txtValorMax.Text = definicionIP.ValorMax;
                txtValorStd.Text = definicionIP.ValorStd;
            }
            txtUnit.Text = metodo.ValorUnit;
            txtRespInspeccion.Text = data.UserControl;
            if (txtRespInspeccion.Text == null)
                txtRespInspeccion.Text = Environment.UserName;


            if (data.VALORCQ == null)
            {
                txtValorMedicion.Text = "";
            }
            else
            {
                txtValorMedicion.Text = data.VALORCQ.ToString();
            }

            if (data.RESULTADOCQ == null)
            {
                txtStatusMedicion.Text = @"NoDef";
                txtStatusMedicion.ForeColor = Color.DarkSlateBlue;
            }
            else
            {
                txtStatusMedicion.Text = data.RESULTADOCQ;
            }

            txtObservacion.Text = data.COMENTARIO;

            if (data.FechaControl == null)
                txtFechaInspeccion.Text = DateTime.Today.ToString("d");

        }

        private void BtnUpdateAnalisis_Click(object sender, EventArgs e)
        {
            new QmMasterData().UpdateInspeccionId(_idQm, Convert.ToInt32(txtCounter.Text), txtValorMedicion.Text, txtStatusMedicion.Text, DateTime.Today, txtRespInspeccion.Text, txtObservacion.Text);
            t0811CQIBindingSource.DataSource = new QmManageList().GetQmIpList(_idQm);

        }

        private void BtnAddMetodo_Click_1(object sender, EventArgs e)
        {
            //using (var f0 = new FrmQm06AddMetodoToPlan(_idQm))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        //string custName = f0.CustomerName;
            //       //SaveToFile(custName);
            //    }
            //    t0811CQIBindingSource.DataSource = new QmManageList().GetQmIpList(_idQm);
            //}
        }

        private void BtnEliminarMetodo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCaracteristica.Text))
            {
                MessageBox.Show(@"Se debe seleccionar un Metodo de Inspeccion para eliminar", "Eliminacion de METIP",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resp = new QmMasterData().DeleteMetodoToInspeccionId(_idQm, txtIdCaracteristica.Text);
            if (resp == false)
            {
                MessageBox.Show(
                    @"No se ha podido eliminar el metodo de inspeccion de la Inspeccion debido a que el mismo forma parte del Plan Standard.",
                    @"Error en Eliminacion del Metodo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            t0811CQIBindingSource.DataSource = new QmManageList().GetQmIpList(_idQm);
        }

        private void Green_Click(object sender, EventArgs e)
        {
            txtStatusMedicion.Text = @"Aprobado";
            txtStatusMedicion.ForeColor = Color.DarkGreen;
            if (string.IsNullOrEmpty(txtValorMedicion.Text))
            {
                txtValorMedicion.Text = txtValorStd.Text;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            txtStatusMedicion.Text = @"NOAprobado";
            txtStatusMedicion.ForeColor = Color.Red;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            txtStatusMedicion.Text = @"NoDef";
            txtStatusMedicion.ForeColor = Color.DarkSlateBlue;
        }
    }
}
