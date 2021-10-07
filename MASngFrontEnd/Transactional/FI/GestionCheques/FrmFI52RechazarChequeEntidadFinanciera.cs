using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmFI52RechazarChequeEntidadFinanciera : Form
    {
        public FrmFI52RechazarChequeEntidadFinanciera()
        {
            InitializeComponent();
        }


        private enum AccionUbicacionCheque
        {
            EnCartera,
            EnProveedor,
            EnBanco,
            NoSeleccionado
        };

        private List<T0154_CHEQUES> _ListaCheques = new List<T0154_CHEQUES>();
        private AccionUbicacionCheque _ubicacionCheque;
        private int? _idChequeSeleccionado;
        private T0154_CHEQUES _dataChequeSeleccionado = new T0154_CHEQUES();
        private int? _idCliente;
        //------------------------------------------------------------------------------------------------------
        private void FrmFI52RechazarChequeEntidadFinanciera_Load(object sender, EventArgs e)
        {
            //deshabilitdo momentaneamente
            rbDepositado.AutoCheck = false;
            rbEnCartera.AutoCheck = false;
            rbEnProveedor.AutoCheck = false;
            rbDepositado.Checked = true;
            //Cheques en Entidades/Banco
            _ubicacionCheque = AccionUbicacionCheque.EnBanco;
            lFiltroOrigen.Text = @"Seleccion Entidad Deposito";
            cmbFiltroOrigen.DataSource = new CuentasManager().GetListCuentasAvailableTransferencia()
                .Where(c => c.CUENTA_TIPO == "TRANSF")
                .ToList();
            cmbFiltroOrigen.DisplayMember = "ID_CUENTA";
            cmbFiltroOrigen.ValueMember = "ID_CUENTA";
            cmbFiltroOrigen.BackColor = Color.LightGray;
            cmbFiltroOrigen.ForeColor = Color.Navy;
            cmbFiltroOrigen.Enabled = true;
            cmbFiltroOrigen.SelectedIndex = -1;
            //
            txtGL.Text = @"1.0.0.5"; //GL Aaccount de Cheques en Cartera.
            cIcono1Ubicacion.Set = CIconos.Tilde;
        }

        private void cmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroOrigen.SelectedIndex == -1)
                return;
            txtGL.Text = new CuentasManager().GetGL(cmbFiltroOrigen.SelectedValue.ToString());
            _ListaCheques = new ChequesManager().GetListChequesNoDisponibles(cmbFiltroOrigen.SelectedValue.ToString()).ToList();
            dgvListaCheques.DataSource = _ListaCheques;
            dgvListaCheques.ClearSelection();
            ResetSeccionChequeSeleccionado();
        }
        private void ResetSeccionChequeSeleccionado()
        {
            dgvListaCheques.ClearSelection();
            cFechaChequeAcreditacion.Value = null;
            cFechaChequeRecibido.Value = null;
            txtChBanco.Text = null;
            txtIdCheque.Text = null;
            _idChequeSeleccionado = null;
            txtChCliente.Text = null;
            txtChLxRecibido.Text = null;
            cIcono5SeleccionCheque.Set = CIconos.Amarillo;
            //
            txtMotivoRechazo.Text = null;
            cChImporte.SetValue = 0;
            cGastoRechazo.SetValue = 0;
            cIvaGastoRechazo.SetValue = 0;
            cImporteTotalRechazo.SetValue = 0;
            rbL1Rechazo.Checked = false;
            rbL2Rechazo.Checked = false;

        }
        private void dgvListaCheques_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ResetSeccionChequeSeleccionado();
                return;
            }

            var g = (DataGridView) sender;
            if (g.SelectedCells.Count != 0)
            {
                _idChequeSeleccionado = Convert.ToInt32(g[__idChequeSeleccionado.Name, e.RowIndex].Value);
                _dataChequeSeleccionado = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                PopulaDatosCheque();
            }
        }
        private void PopulaDatosCheque()
        {
            if (_idChequeSeleccionado == null)
            {
                ResetSeccionChequeSeleccionado();
            }
            else
            {
                cFechaChequeAcreditacion.Value = _dataChequeSeleccionado.CHE_FECHA;
                txtIdCheque.Text = _idChequeSeleccionado.Value.ToString();
                txtChBanco.Text = _dataChequeSeleccionado.T0160_BANCOS.BCO_SHORTDESC;
                cChImporte.SetValue = _dataChequeSeleccionado.IMPORTE.Value;
                _idCliente = _dataChequeSeleccionado.IdClienteRecibido;
                txtChCliente.Text = _dataChequeSeleccionado.CLIENTE;
                cFechaChequeRecibido.Value = _dataChequeSeleccionado.FECHA_RECIBIDO;
                txtChLxRecibido.Text = _dataChequeSeleccionado.TIPO;
                //
                txtMotivoRechazo.Text = null;
                dtpFechaRechazo.Value = DateTime.Today;
                cChImporte.SetValue = _dataChequeSeleccionado.IMPORTE.Value;
                cIvaGastoRechazo.SetValue = 0;
                cGastoRechazo.SetValue = 0;
                cImporteTotalRechazo.SetValue = cChImporte.GetValueDecimal;
                cIcono5SeleccionCheque.Set = CIconos.Tilde;
                btnRechazar.Enabled = true;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void txtGL_TextChanged(object sender, EventArgs e)
        {
        }



        private void rbL1Rechazo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1Rechazo.Checked)
            {
                if (cGastoRechazo.GetValueDecimal > 0)
                {
                    cIvaGastoRechazo.SetValue = cGastoRechazo.GetValueDecimal * (decimal) 0.21;
                    cIvaGastoRechazo.XReadOnly = false;
                }
            }
            else
            {
                if (cIvaGastoRechazo.GetValueDecimal != 0)
                {
                    toolTip1.SetToolTip(cIvaGastoRechazo, "En Cuenta L2 no puede haber IVA");
                    toolTip1.Show("Se paso el Valor a 0", this, 1500);
                    cIvaGastoRechazo.SetValue = 0;
                    cIvaGastoRechazo.XReadOnly = true;
                }
            }
            cImporteTotalRechazo.SetValue = cChImporte.GetValueDecimal + cGastoRechazo.GetValueDecimal +
                                            cIvaGastoRechazo.GetValueDecimal;
        }
        private void cGastoRechazo_Validated(object sender, EventArgs e)
        {
            if (rbL1Rechazo.Checked)
            {
                cIvaGastoRechazo.SetValue = cGastoRechazo.GetValueDecimal * (decimal)0.21;
            }
            
            cImporteTotalRechazo.SetValue = cChImporte.GetValueDecimal + cGastoRechazo.GetValueDecimal +
                                            cIvaGastoRechazo.GetValueDecimal;
        }
        private void cIvaGastoRechazo_Validated(object sender, EventArgs e)
        {
            if (rbL1Rechazo.Checked)
            {
                cIvaGastoRechazo.SetValue = cGastoRechazo.GetValueDecimal * (decimal)0.21;
            }

            cImporteTotalRechazo.SetValue = cChImporte.GetValueDecimal + cGastoRechazo.GetValueDecimal +
                                            cIvaGastoRechazo.GetValueDecimal;
        }

        private bool MessageErrorx(string mensaje)
        {
            MessageBox.Show($@"Error: {mensaje}", @"Los datos necesarios para rechazar el cheque no están completos", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }
        private bool ValidarRechazo()
        {
            if (_idChequeSeleccionado == null)
            {
                return MessageErrorx("No existe ningun cheque seleccionado");
            }

            if (cChImporte.GetValueDecimal <= 0)
            {
                return MessageErrorx("El importe del Cheque seleccionado es incorrecto");
            }

            if (_idCliente == null)
            {
                return MessageErrorx("No se ha podido identificar al Cliente");
            }

            if (string.IsNullOrEmpty(txtMotivoRechazo.Text))
            {
                return MessageErrorx("Debe completar el motivo del rechazo (ver segun banco)");
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!ValidarRechazo()) return;

            decimal importeTotal = cChImporte.GetValueDecimal + cGastoRechazo.GetValueDecimal +
                                   cIvaGastoRechazo.GetValueDecimal;

            var resp = MessageBox.Show($@"Confirma el Rechazo del Cheque Banco {txtChBanco.Text} por: " +
                                       Environment.NewLine +
                                       $@"Importe Cheque=  {cChImporte.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Gastos=  {cGastoRechazo.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Iva=  {cIvaGastoRechazo.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Operacion Total=  {importeTotal.ToString("C2")} ",
                @"Confirmacion de Operacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            
            var tipoRechazo = rbL1Rechazo.Checked ? "L1" : "L2";

        var chrmng = new ChequeRechazadoManager();
            chrmng.AddChequeRechazado(_idChequeSeleccionado.Value, dtpFechaRechazo.Value, txtMotivoRechazo.Text.ToUpper(),tipoRechazo,cGastoRechazo.GetValueDecimal,cIvaGastoRechazo.GetValueDecimal,$"Banco-{cmbFiltroOrigen.SelectedValue.ToString()}");
            chrmng.SetChequeRechazadoTablaCheque(_idChequeSeleccionado.Value, txtMotivoRechazo.Text.ToUpper());
            var asiento = new AsientoGenerico("CHR").CreaAsientoChequeRechazado(_idChequeSeleccionado.Value, txtMotivoRechazo.Text, txtGL.Text, dtpFechaRechazo.Value, cGastoRechazo.GetValueDecimal, cIvaGastoRechazo.GetValueDecimal);
            chrmng.CompleteNumeroAsientoRechazo(_idChequeSeleccionado.Value, asiento.IdDocu);
            if (asiento.IdDocu > 0)
            {
                MessageBox.Show(@"Se ha generado correctamente el Rechazo Seleccionado", @"Rechazo Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroAsiento.Text = asiento.IdDocu.ToString();
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error en el asiento de rechazo.... ", @"Ups...", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            //limpieza datos
            dgvListaCheques.ClearSelection();
            _idChequeSeleccionado = null;
            PopulaDatosCheque();
        }

        private void txtFilterChNum_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterChNum.Text))
            {
                dgvListaCheques.DataSource = _ListaCheques.ToList();
            }
            else
            {
                dgvListaCheques.DataSource =
                    _ListaCheques.Where(c => c.CHE_NUMERO.StartsWith(txtFilterChNum.Text)).ToList();

            }
        }
    }
}
