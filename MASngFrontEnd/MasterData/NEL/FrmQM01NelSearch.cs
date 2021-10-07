using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using TecserEF.Entity;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm01NelSearch : Form
    {
        public FrmQm01NelSearch(int modo)
        {
            _modo = modo;
            InitializeComponent();
            _ckStatus = new bool[8] { false, false, false, false, false, false, false, false };

            //Inicial, - no
            //0Ingresado, 0
            //1Proceso,1
            //2CodigoProv,
            //3Waiting,
            //4Cancelado,
            //5Rechazado,
            //6Aprobado,
            //7Finalizado
        }

        //----------------------------------------------------------------------------------------
        private readonly int _modo;
        private bool[] _ckStatus;
        //----------------------------------------------------------------------------------------

        private void FrmNelSearch_Load(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                btnNuevoNel.Enabled = true;
                dgvDetalleNels.Enabled = false;
            }
            else
            {
                btnNuevoNel.Enabled = false;
                dgvDetalleNels.Enabled = true;
            }
            btnNuevoNel.Enabled = false || _modo == 1;
            NelBs.DataSource = new NelManager().GetNelList();

            var data = new NelManager().GetListSegunEstado(_ckStatus);
            dgvDetalleNels.DataSource = new MySortableBindingList<T0099_NELS>(data);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoNel_Click(object sender, EventArgs e)
        {
            if (TsSecurityMng.CheckifRoleIsGrantedToRun("NEL1", "NEL1", true, true)) return;
            var f = new FrmQm02NelMainData(1);
            f.Show();
        }

        private void dgvDetalleNels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                int nelNumber =
                    Convert.ToInt32(
                        dgvDetalleNels[dgvDetalleNels.Columns[nELDataGridViewTextBoxColumn.Name].Index, e.RowIndex]
                            .Value);
                ;
                switch (cellValue)
                {
                    case "Ver":
                        if (TsSecurityMng.CheckifRoleIsGrantedToRun("NEL0", "NEL3", true, true)) return;
                        using (var f0 = new FrmQm02NelMainData(3, nelNumber))
                        {
                            var dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                            }
                        }
                        break;
                    case "Editar":
                        if (!TsSecurityMng.CheckifRoleIsGrantedToRun("NEL0", "NEL2", true, true)) return;
                        using (var f0 = new FrmQm02NelMainData(2, nelNumber))
                        {
                            var dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                            }
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void ckEsperando_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[8]
            {
                ckIngresado.Checked, ckProceso.Checked, ckProvisorio.Checked, ckEsperando.Checked, ckAprobado.Checked,
                ckRechazado.Checked, ckCancelado.Checked, ckFinalizado.Checked
            };

            var data = new NelManager().GetListSegunEstado(_ckStatus);
            dgvDetalleNels.DataSource = new MySortableBindingList<T0099_NELS>(data);
        }

        private void txtNel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNel.Text))
            {
                //busqueda por estado
                var data = new NelManager().GetListSegunEstado(_ckStatus);
                dgvDetalleNels.DataSource = new MySortableBindingList<T0099_NELS>(data);
            }
            else
            {
                //busqueda por numero de NEL
                var data = new NelManager().GetDataList(Convert.ToInt32(txtNel.Text));
                dgvDetalleNels.DataSource = new MySortableBindingList<T0099_NELS>(data);
            }
        }

        private void txtNel_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
    }
}
