using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi54NcDevolucion : Form
    {
        public FrmFi54NcDevolucion(CustomerNc znc)
        {
            var h = znc.GetHeader();
            _nc = znc;
            _motivo = CustomerNc.MotivoNotaCredito.DevolucionMaterial;
            _idCliente = h.Cliente;
            _tipoLx = h.TIPOFACT;
            InitializeComponent();
            txtRazonSocial.Text = h.RAZONSOC;
            txtId6.Text = _idCliente.ToString();
            txtMotivo.Text = _motivo.ToString();
            txtTipoDocumento.Text = h.TIPO_DOC;
            if (_tipoLx == "L2")
            {
                ckAplicaIVA.Checked = false;
                ckAplicaIVA.AutoCheck = false;
            }
            else
            {
                ckAplicaIVA.Checked = true;
                ckAplicaIVA.AutoCheck = true;
            }
        }

        private CustomerNc _nc;
        private readonly int _idCliente;
        private readonly string _tipoLx;
        private readonly CustomerNc.MotivoNotaCredito _motivo;
        public int? IdFacturaSeleccionada { get; private set; }
        public int IdRetornoSeleccionado { get; private set; }
        public decimal KgNotaCredito { get; private set; }
        
    

        private void FrmSeleccionMaterialNcd_Load(object sender, EventArgs e)
        {
            this.dgvSeleccionDevolucion.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeleccionDevolucion_CellEnter);
            t0360RTNBindingSource.DataSource = new ManageRetornoMaterial().GetDevolucionesFromCustomer(_idCliente,true).OrderByDescending(c=>c.IDX).ToList();
            dgvSeleccionDevolucion.DataSource = t0360RTNBindingSource;
            dgvSeleccionDevolucion.ClearSelection();
            this.dgvSeleccionDevolucion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeleccionDevolucion_CellEnter);
            IdFacturaSeleccionada = null;
            IdRetornoSeleccionado = -1;
        }

        private void FrmSeleccionMaterialNcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private bool ValidaKgOK()
        {
            if (IdRetornoSeleccionado <= 0)
            {
                MessageBox.Show(@"Debe linkear la devolucion a un Retorno RTN del Sistema", @"Error en Link-Documentos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (IdFacturaSeleccionada == null)
            {
                var r = MessageBox.Show(@"No ha linkeado el Retorno a una Facturacion del Cliente" +
                                        Environment.NewLine + "" +
                                        @"Desea continuar sin el linkeo RTN-Factura-Remito?",
                    @"Valores Sin Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return false;
            }

            if (string.IsNullOrEmpty(txtComentarioNc.Text))
            {
                MessageBox.Show(@"Debe ingresar un comentario para la nota de credito", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cKgNc.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Error en la cantidad/KG de la Nota de Credito", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cPRecioTotalNc.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Error en el Total de la Nota de Credito", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cUnitarioSugerido.GetValueDecimal < cPrecioUnitarioNc.GetValueDecimal)
            {
                var r = MessageBox.Show(@"El Importe unitario de la nota de credito supera el importe sugerido." +
                                        Environment.NewLine + "" +
                                        @"Confirma el Importe de la nota de credito?",
                    @"Confirmacion de Valores Sospechosos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return false;
            }
            return true;
        }
        
        private void dgvSeleccionItem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //aca seleccion de item - var algun encabezado de la factura como fecha , etc
            if (e.RowIndex >= 0)
            {
                IdFacturaSeleccionada= Convert.ToInt32(dgvSeleccionItem[__idFacturaSeleccionada.Name, e.RowIndex].Value);
                csemFacturaEncontrada.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                var h =new GestionT400(IdFacturaSeleccionada.Value).H4;
                txtNumeroFactura.Text = h.TIPO_DOC+"#"+h.NumeroDoc;
                txtFechaFactura.Text = h.FECHA.ToString("g");
                txtTc.Text = h.TC.ToString();
                txtLx.Text = h.TIPOFACT;
                cUnitarioSugerido.SetValue = Convert.ToDecimal(dgvSeleccionItem[__precioUnitario1.Name, e.RowIndex].Value);
                if (string.IsNullOrEmpty(txtKgRtn.Text)) txtKgRtn.Text = "0";
                cTtotalSugerido.SetValue = cUnitarioSugerido.GetValueDecimal * Convert.ToDecimal(txtKgRtn.Text);
                txtGLI.Text = dgvSeleccionItem[__GLI.Name, e.RowIndex].Value.ToString();
                txtGLV.Text = dgvSeleccionItem[__GLV.Name, e.RowIndex].Value.ToString();
            }
            else
            {
                IdFacturaSeleccionada = null;
                csemFacturaEncontrada.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtNumeroFactura.Text = null;
                txtFechaFactura.Text = null;
                txtTc.Text = null;
                cUnitarioSugerido.SetValue = 0;
                cTtotalSugerido.SetValue = 0;
                txtGLV.Text = null;
                txtGLI.Text = null;
            }
        }
        

        private void dgvSeleccionDevolucion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdRetornoSeleccionado = Convert.ToInt32(dgvSeleccionDevolucion[__idReturn.Name, e.RowIndex].Value);
                var rtn = new ManageRetornoMaterial();
                var dataRtn = rtn.GetRegistroRetorno(IdRetornoSeleccionado);
                dgvSeleccionItem.DataSource =
                    rtn.GetUltimasComprasClienteMaterialReturn(dataRtn.MATERIAL, dataRtn.LOTE, dataRtn.IDCLI, 10);

                ctlSemaforo1.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtNumeroRtn.Text = IdRetornoSeleccionado.ToString();
                txtFechaRtn.Text = dataRtn.FECHA.ToString("g");
                txtMotivoRtn.Text = dataRtn.MOTIVO;
                txtRecibioRtn.Text = dataRtn.RECIBIO;
                txtComentarioRtn.Text = dataRtn.COMENTARIO;
                txtMaterialRtn.Text = dataRtn.MATERIAL;
                txtKgRtn.Text = dataRtn.KG.ToString("N2");
                txtLoteRtn.Text = dataRtn.LOTE;
                txtKgRtn.Text = dataRtn.KG.ToString("N2");
                txtAutorizoRtn.Text = dataRtn.AprobadoPor;
                //
                txtKgSugeridosNc.Text = txtKgRtn.Text;
            }
            else
            {
                IdRetornoSeleccionado = -1;
                ctlSemaforo1.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                BlanqueaRetorno();
            }
        }

        private void BlanqueaRetorno()
        {
            txtNumeroRtn.Text = null;
            txtFechaRtn.Text = null;
            txtMotivoRtn.Text = null;
            txtRecibioRtn.Text = null;
            txtComentarioRtn.Text = null;
            txtMaterialRtn.Text = null;
            txtKgRtn.Text = null;
            txtLoteRtn.Text = null;
            txtKgRtn.Text = null;
            txtAutorizoRtn.Text = null;
            txtKgSugeridosNc.Text = @"0";
            cTtotalSugerido.SetValue = 0;
            cUnitarioSugerido.SetValue = 0;
            cKgNc.SetValue = 0;
            cPrecioUnitarioNc.SetValue = 0;
            cPRecioTotalNc.SetValue = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            IdFacturaSeleccionada = null;
            IdRetornoSeleccionado = -1;
            KgNotaCredito =0;
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnSelectDocument_Click(object sender, EventArgs e)
        {
            if (ValidaKgOK() == false)
                return;

            //Alta del Item

            _nc.AddItems(txtMaterialRtn.Text, @"Devolucion Material", cUnitarioSugerido.GetValueDecimal,txtGLV.Text , ckAplicaIVA.Checked, cKgNc.GetValueDecimal*-1, "ARS",txtGLI.Text);
            _nc.SetTotalesInHeaderFromItems();
            _nc.SetDocumentoAsociado(IdRetornoSeleccionado); //en documento asociado paso el IDRTN
            KgNotaCredito = cKgNc.GetValueDecimal;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void cKgNc_Validated(object sender, EventArgs e)
        {
            cPRecioTotalNc.SetValue = cPrecioUnitarioNc.GetValueDecimal * cKgNc.GetValueDecimal;
        }
    }
}
