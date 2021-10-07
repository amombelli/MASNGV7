using System;
using System.Windows.Forms;
using MASngFE.Transactional.FI.Orden_de_Pago;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.FI
{
    public partial class FrmFI34BusquedaCheques : Form
    {
        public FrmFI34BusquedaCheques()
        {
            InitializeComponent();
        }

        public FrmFI34BusquedaCheques(string lx, string modo)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
        }

        public FrmFI34BusquedaCheques(string lx, string modo, int id)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
            _id = id;
        }

        public FrmFI34BusquedaCheques(FrmFI31OPMainScreen frm, string lx, string modo, int id)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
            _id = id;
            _f = frm;
        }

        //-------------------------------------------------------------------------------------------------------------
        private string _lx;
        private readonly string _modo; //OP
        private readonly int _id; //numero de OP...
        private readonly FrmFI31OPMainScreen _f;
        //-------------------------------------------------------------------------------------------------------------


        private void FrmBusquedaCheques_Load(object sender, EventArgs e)
        {
            dgvChequesNew.Visible = false;
            dgvChequesFull.Visible = false;
            switch (_modo)
            {
                case "OP":
                    //OP modo para agregar cheques a una orden de pago
                    btnAdd.Enabled = true;
                    if (_lx == "L1")
                    {
                        ckL1.Checked = true;
                        ckL2.Checked = false;
                    }
                    else
                    {
                        ckL1.Checked = false;
                        ckL2.Checked = true;
                    }

                    dgvChequesNew.Visible = true;
                    ckVerDisponible.Checked = true;
                    ckVerNoDisponible.Checked = false;
                    ckNoInterior.Checked = true;
                    ckInterior.Checked = true;

                    int idChequeSelect = -1;
                    if (!string.IsNullOrEmpty(txtId.Text))
                    {
                        idChequeSelect = Convert.ToInt32(txtId.Text);
                    }

                    DateTime? fechaMaxAcred = null;
                    if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
                    {
                        fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
                    }

                    var lista = new ChequesManager().GetListaChequesFiltrada(_lx,
                        ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                        fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);

                    //tsCheques1BindingSource.DataSource = lista;
                    dgvChequesNew.DataSource = new MySortableBindingList<TsCheques1>(lista);
                    dgvChequesFull.DataSource = new MySortableBindingList<TsCheques1>(lista);


                    break;
                default:

                    MessageBox.Show(@"Situacion no manejada aun", @"Sin implementar", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
            }
        }



        private void AplicaFiltros()
        {
            int idChequeSelect = -1;
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                idChequeSelect = Convert.ToInt32(txtId.Text);
            }

            DateTime? fechaMaxAcred = null;
            if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
            }

            var lista = new ChequesManager().GetListaChequesFiltrada(_lx,
                ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);

            dgvChequesNew.DataSource = new MySortableBindingList<TsCheques1>(lista);
            dgvChequesFull.DataSource = new MySortableBindingList<TsCheques1>(lista);
        }

        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked == ckL2.Checked)
            {
                _lx = "L5";
            }
            else
            {
                if (ckL1.Checked == true)
                {
                    _lx = "L1";
                }
                else
                {
                    _lx = "L2";
                }
            }
            AplicaFiltros();
        }
        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked == ckL2.Checked)
            {
                _lx = "L5";
            }
            else
            {
                if (ckL1.Checked == true)
                {
                    _lx = "L1";
                }
                else
                {
                    _lx = "L2";
                }
            }
            AplicaFiltros();
        }
        private void ckVerDisponible_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void ckVerNoDisponible_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            txtId.Text = null;
            int idChequeSelect = -1;
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                idChequeSelect = Convert.ToInt32(txtId.Text);
            }

            DateTime? fechaMaxAcred = null;
            if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
            }

            var lista = new ChequesManager().GetListaChequesFiltrada(_lx,
                ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);

            dgvChequesNew.DataSource = new MySortableBindingList<TsCheques1>(lista);
            dgvChequesFull.DataSource = new MySortableBindingList<TsCheques1>(lista);

        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtNumber.Text = null;
            AplicaFiltros();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddChequeAOrdenPago(decimal importe, int idCheque)
        {
            new OrdenPagoManageDatos(_id).AddItemPago("CHE", importe, idCheque);
            new OPImputaFacturas(_id).ImputaFacturasOP();
            new ChequesManager().UtilizaChequeEnOrdenPago(idCheque, _id);
            _f.RefreshDgvItemsdePago();
            _f.RecalculaTotalesOP();
            _f.RefreshDgvFacturasEnOP();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"!");
        }

        private void CopyAlltoClipboard()
        {
            dgvChequesFull.SelectAll();
            DataObject dataObj = dgvChequesFull.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            CopyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range cr = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            cr.Select();
            xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void CkNoInterior_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void TxtDiasAcredMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void TxtDiasAcredMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                //
            }
            else
            {
                if (Convert.ToDecimal(txtDiasAcredMax.Text) > 365)
                {
                    MessageBox.Show(@"Dias Maximos de Acreditacion no pueden superar los 365 dias");
                    e.Cancel = true;
                }
            }
        }

        private void CkInterior_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChequesNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            {
                var valor = Convert.ToDecimal(dgv[importeDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                var idCheque = Convert.ToInt32(dgv[idchequeDataGridViewTextBoxColumn.Name, e.RowIndex].Value);

                switch (dgv[e.ColumnIndex, e.RowIndex].Value)
                {
                    case "+": //Boton Agregar Cheque
                        switch (_modo)
                        {
                            case "OP":
                                //Boton Agregar Cheque a Orden de Pago
                                if (!new ChequesManager().GetIfDisponible(idCheque))
                                {
                                    MessageBox.Show(@"El Cheque seleccionado ya no está disponible",
                                        @"Cheque no Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                DialogResult dialogResult =
                                    MessageBox.Show($@"Confirma el Agregado de este Cheque por importe $ {valor}", @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    AddChequeAOrdenPago(valor, idCheque);
                                }
                                else
                                {
                                    //No confirmo agregado de cheques a OP
                                }

                                break;

                            default:
                                MessageBox.Show(@"Modo no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                break;
                        }
                        break;

                    default:
                        MessageBox.Show(@"Situacion no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void dgvChequesFull_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            {
                var valor = Convert.ToDecimal(dgv[importeDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                var idCheque = Convert.ToInt32(dgv[idchequeDataGridViewTextBoxColumn.Name, e.RowIndex].Value);

                switch (dgv[e.ColumnIndex, e.RowIndex].Value)
                {
                    case "+": //Boton Agregar Cheque
                        switch (_modo)
                        {
                            case "OP":
                                //Boton Agregar Cheque a Orden de Pago
                                if (!new ChequesManager().GetIfDisponible(idCheque))
                                {
                                    MessageBox.Show(@"El Cheque seleccionado ya no está disponible",
                                        @"Cheque no Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                DialogResult dialogResult =
                                    MessageBox.Show($@"Confirma el Agregado de este Cheque por importe $ {valor}", @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    AddChequeAOrdenPago(valor, idCheque);
                                }
                                else
                                {
                                    //No confirmo agregado de cheques a OP
                                }

                                break;

                            default:
                                MessageBox.Show(@"Modo no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                break;
                        }
                        break;

                    default:
                        MessageBox.Show(@"Situacion no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
