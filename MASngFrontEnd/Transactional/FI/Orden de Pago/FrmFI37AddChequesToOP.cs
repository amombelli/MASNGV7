using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI37AddChequesToOP : Form
    {
        private readonly string _lx;
        private readonly FI31OrdenPagoMainScreen _f;
        private List<int?> _listaChequesInOp;
        private List<TsCheques1> _lista = new List<TsCheques1>();

        public FrmFI37AddChequesToOP(string lx, FI31OrdenPagoMainScreen frm, List<int?> listaChequesInOp)
        {
            _lx = lx;
            _f = frm;
            _listaChequesInOp = listaChequesInOp;
            InitializeComponent();
        }
        
        private void FrmFI37AddChequesToOP_Load(object sender, EventArgs e)
        {
            this.ckL2.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
            this.cImporteMinimo.Validated -= new System.EventHandler(this.cImporteMaximo_Validated);

            if (_lx == "L1")
            {
                ckL1.Checked = true;
            }
            else
            {
                ckL2.Checked = true;
            }

            cImporteMinimo.SetValue = 0;
            cImporteMaximo.SetValue = 9999999;
            ckInterior.Checked = true;
            ckCaba.Checked = true;
            AplicaFiltros();
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            this.cImporteMinimo.Validated += new System.EventHandler(this.cImporteMaximo_Validated);
        }
        private void dgvChequesFull_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            {
                var valor = Convert.ToDecimal(dgv[__importe.Name, e.RowIndex].Value);
                var idCheque = Convert.ToInt32(dgv[__idCheque.Name, e.RowIndex].Value);
                if (!new ChequesManager().GetIfDisponible(idCheque))
                {
                    MessageBox.Show(@"El Cheque seleccionado ya no está disponible",
                        @"Cheque no Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult dialogResult =
                    MessageBox.Show($@"Confirma el Agregado de este Cheque por importe $ {valor}", @"Confirmacion",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_listaChequesInOp == null)
                    {
                        _listaChequesInOp = new List<int?>();
                    }
                    _f.AddChequeOP(idCheque);
                    RefrescaDgv();
                }
                else
                {
                    //No confirmo agregado de cheques a OP
                }
            }
        }

 

        private void AplicaFiltros()
        {
            DateTime? fechaMinima = null;
            string lx;
            int idCheque = -1;
            
            if (cDiasAcred.GetValueDecimal > 0)
            {
                fechaMinima = DateTime.Today.AddDays(Convert.ToInt32(cDiasAcred.GetValueDecimal));
            }

            if (ckL1.Checked && ckL2.Checked)
            {
                lx = "L5";
            }
            else
            {
                lx = ckL1.Checked ? "L1" : "L2";
            }

            if (cIdCheque.GetValueDecimal > 0)
            {
                idCheque = Convert.ToInt32(cIdCheque.GetValueDecimal);
            }

            var listaResult = new ChequesManager().GetListaChequesFiltrada(lx, true, false, txtNumeroCheque.Text,
                idCheque, fechaMinima, ckInterior.Checked, ckCaba.Checked);
            if (listaResult != null)
            {
                _lista = listaResult.Where(c =>
                        c.Importe >= cImporteMinimo.GetValueDecimal && c.Importe <= cImporteMaximo.GetValueDecimal)
                    .ToList();
            }
            RefrescaDgv();
        }
        private void RefrescaDgv()
        {
            if (_lista == null)
            {
                dgvChequesFull.DataSource = null;
                return;
            }
            //elimina los cheques incluidos en la OP.
            foreach (var cheque in _listaChequesInOp)
            {
                var ix = _lista.Find(c => c.Idcheque == cheque);
                if (ix != null)
                {
                    _lista.Remove(ix);
                }
            }
            dgvChequesFull.DataSource = new MySortableBindingList<TsCheques1>(_lista);
        }

        private void txtNumeroCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
           FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void cImporteMaximo_Validated(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void btnResetFiltros_Click(object sender, EventArgs e)
        {
            this.ckL2.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
            this.cImporteMinimo.Validated -= new System.EventHandler(this.cImporteMaximo_Validated);

            ckL1.Checked = false;
            ckL2.Checked = false;
            if (_lx == "L1")
            {
                ckL1.Checked = true;
            }

            if (_lx == "L2")
            {
                ckL2.Checked = true;
            }

            ckCaba.Checked = true;
            ckInterior.Checked = true;
            cImporteMinimo.SetValue = 0;
            cImporteMaximo.SetValue = 9999999;
            cDiasAcred.SetValue = 365;
            cIdCheque.SetValue = 0;
            txtNumeroCheque.Text = null;
            AplicaFiltros();

            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            this.cImporteMinimo.Validated += new System.EventHandler(this.cImporteMaximo_Validated);
        }
    }
}
