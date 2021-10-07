using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI40AjusteSaldoCliente : Form
    {
        public enum TipoAjuste
        {
            EntreClientes,
            EntreTipos
        };

        /// <summary>
        /// Traspaso de Saldos entre clientes o mismo cliente entre tipos
        /// Similar a Ajustes pero realiza la contrapartida en forma automatica
        /// </summary>
        public FrmFI40AjusteSaldoCliente(int idClienteOrigen, int modo = 1)
        {
            _idClienteOrigen = idClienteOrigen;
            _modo = modo;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------
        private readonly int _idClienteOrigen;
        private DocumentFIStatusManager.StatusHeader _estado;
        private readonly int _modo;
        private int _idClienteDestino;
        private string _lxOrigen;
        private string _lxDestino;
        private List<T0301_NCD_I> _listaItems = new List<T0301_NCD_I>();
        private TipoAjuste _tipoAj;
        private decimal _importeT = 0;
        private string _tdoc = "AJ";

        //------------------------------------------------------------------------------------------------

        private void FrmFI40AjusteSaldoCliente_Load(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                //nuevo ajuste
                _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
                grpLxDestino.Enabled = false;
                grpLxOrigen.Enabled = false;

                LoadHeaderDataFromMasterData();
                LoadCustomerDataInfo();
                AccionSegunIndicadorInicial();
            }
            else
            {
                //por el momento no tiene sentido hacer una visualizacion
                //se realiza desde Visualizacion de NCD
            }
        }

        private void LoadCustomerDataInfo()
        {
            var cli = new CustomerManager().GetCustomerBillToData(_idClienteOrigen);
            txtIdCliente.Text = _idClienteOrigen.ToString();
            txtRazonSocial.Text = cli.cli_rsocial;
            txtClienteOrigienRs.Text = txtRazonSocial.Text;
            txtIdCliO.Text = txtIdCliente.Text;
            txtCuit.Text = cli.CUIT;
            txtCuitValidado.BackColor = new CuitValidation().ValidarCuit(txtCuit.Text) ? Color.GreenYellow : Color.Red;
            txtDireccionFiscal.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtCP.Text = cli.ZIP;
            var ctacte = new CtaCteCustomer(_idClienteOrigen);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");

        }
        private void LoadHeaderDataFromMasterData()
        {
            //txtTipoLx.Text = _tipoLx;
            //txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;
            txtEstadoDocumento.Text = _estado.ToString();
            txtNumeroDocumento.Text = @"NO-ASIGNADO";
            dtpFechaDocumento.Value = DateTime.Today;
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value).ToString("N2");
            //txtSaldoActual.Text = new CtaCteCustomer(_idCliente).GetResultadoCtaCte(_tipoLx).SaldoResumen.ToString("C2");
        }

        private void AccionSegunIndicadorInicial()
        {
            _listaItems.Clear();
            switch (_tipoAj)
            {
                case TipoAjuste.EntreClientes:
                    txtGL.Text = @"7.1.1";
                    break;
                case TipoAjuste.EntreTipos:
                    txtGL.Text = @"7.1.1";
                    break;

                default:
                    MessageBox.Show(@"Atencion El Tipo de Documento no tiene una Accion Predefinida", @"Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            txtGLDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGL.Text);
        }


        private void DefaultValues()
        {

        }





        private void cmbClienteDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClienteDestino.SelectedIndex == -1)
            {
                txtSaldoClienteDestinoLX.Text = 0.ToString("C2");
                txtSaldoClienteOrigenLX.Text = 0.ToString("C2");
                _idClienteDestino = -1;
                return;
            }
            txtIdCliDest.Text = cmbClienteDestino.SelectedValue.ToString();
            _idClienteDestino = Convert.ToInt32(cmbClienteDestino.SelectedValue);
            var ctacte = new CtaCteCustomer(_idClienteDestino);
            if (_lxDestino == "L1")
            {
                txtSaldoClienteOrigenLX.Text = txtSaldoL1.Text;
                txtSaldoClienteDestinoLX.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            }
            else
            {
                txtSaldoClienteOrigenLX.Text = txtSaldoL2.Text;
                txtSaldoClienteDestinoLX.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            }
        }

        private void txtImporteTraspaso_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtImporteTraspaso.Text))
                txtImporteTraspaso.Text = 0.ToString("C2");

            decimal importeMax = FormatAndConversions.CCurrencyADecimal(txtSaldoClienteOrigenLX.Text);
            decimal importeT = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text);
            txtImporteTraspaso.Text = importeT.ToString("C2");

            if (importeT == 0)
            {
                toolTip1.ToolTipTitle = "Error en Importe";
                toolTip1.Show("El Importe a Traspasar no puede ser igual a $0.00", txtImporteTraspaso, txtImporteTraspaso.Location, 5000);
                btnContabilizar.Enabled = false;
                _importeT = 0;
            }
            else
            {
                if (importeMax > 0)
                {
                    if (importeT > 0 && importeT <= importeMax)
                    {
                        btnContabilizar.Enabled = true;
                        _importeT = importeT;
                    }
                    else
                    {
                        btnContabilizar.Enabled = false;
                        toolTip1.ToolTipTitle = "Error en Importe";
                        toolTip1.Show("El Importe a Traspasar debe estar comprendido entre el Saldo del Cliente", txtImporteTraspaso, txtImporteTraspaso.Location, 5000);
                        _importeT = 0;
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (importeMax == 0)
                    {
                        toolTip1.ToolTipTitle = "Error en Importe";
                        toolTip1.Show("El Importe a Traspasar no puede ser igual a $0.00", txtImporteTraspaso,
                            txtImporteTraspaso.Location, 5000);
                        btnContabilizar.Enabled = false;
                        _importeT = 0;
                    }
                    else
                    {
                        //importeMax <0 (Saldo a Favor) 
                        if (importeT >= importeMax && importeT < 0)
                        {
                            btnContabilizar.Enabled = true;
                            _importeT = importeT;
                        }
                        else
                        {
                            btnContabilizar.Enabled = false;
                            toolTip1.ToolTipTitle = "Error en Importe";
                            toolTip1.Show("El Importe a Traspasar debe estar comprendido entre el Saldo del Cliente", txtImporteTraspaso, txtImporteTraspaso.Location, 5000);
                            _importeT = 0;
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void txtImporteTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, allowSignoMenos: true, allowSignoMoneda: true);
        }

        private int AsignaNumeroItem()
        {
            if (_listaItems.Count == 0)
                return 1;
            int item = 1;
            foreach (var i in _listaItems)
            {
                i.IDITEM = item;
                item++;
            }
            return item;
        }

        private void AccionAjusteTipo()
        {
            //Ajuste por Redondeo
            var data = new T0301_NCD_I()
            {
                MON = txtMonedaDocumento.Text,
                CANT = 1,
                Descripcion = $"Ajuste - Cambio LX Origen {_lxOrigen} -- Destino {_lxDestino}",
                GL = txtGL.Text,
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = false,
                PUNITARIO = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text),
                PTOTAL = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text),
            };
            _listaItems.Add(data);
            AsignaNumeroItem();
        }

        private void AccionTraspasoClientes()
        {
            if (cmbClienteDestino.SelectedIndex != -1)
            {
                var clienteDestino = (T0006_MCLIENTES)cmbClienteDestino.SelectedItem;
                //Ajuste por Redondeo
                var data = new T0301_NCD_I()
                {
                    MON = txtMonedaDocumento.Text,
                    CANT = 1,
                    Descripcion = $"Ajuste Cliente Origen {txtRazonSocial.Text} -- Destino {clienteDestino.cli_rsocial}",
                    GL = txtGL.Text,
                    IDCHE = null,
                    ITEM = "ZAJCC",
                    IVA21 = false,
                    PUNITARIO = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text),
                    PTOTAL = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text),
                };
                _listaItems.Add(data);
                AsignaNumeroItem();
            }
        }

        private void grpAccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAajusteEntreClientes.Checked)
            {
                grpLxOrigen.Enabled = true;
                cmbClienteDestino.Enabled = true;
                t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
                cmbClienteDestino.SelectedIndex = -1;
                _idClienteDestino = -1;
                _tipoAj = TipoAjuste.EntreClientes;
            }
            else
            {
                //ajuste mismo cliente -- Diferente tipo   
                grpLxOrigen.Enabled = true;
                cmbClienteDestino.SelectedIndex = -1;
                cmbClienteDestino.Enabled = false;
                _idClienteDestino = _idClienteOrigen;
                _tipoAj = TipoAjuste.EntreTipos;
            }
        }
        private void rbL1Ori_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAjusteEntreTipos.Checked)
            {
                if (rbL1Ori.Checked)
                {
                    rbL2Dest.Checked = true;
                    _lxOrigen = "L1";
                    _lxDestino = "L2";
                    txtSaldoClienteOrigenLX.Text = txtSaldoL1.Text;
                }
                else
                {
                    rbL1Dest.Checked = true;
                    _lxOrigen = "L2";
                    _lxDestino = "L1";
                    txtSaldoClienteOrigenLX.Text = txtSaldoL2.Text;
                }
            }
            else
            {
                if (rbL1Ori.Checked)
                {
                    _lxOrigen = "L1";
                    txtSaldoClienteOrigenLX.Text = txtSaldoL1.Text;
                }
                else
                {
                    _lxOrigen = "L2";
                    txtSaldoClienteOrigenLX.Text = txtSaldoL2.Text;
                }
                rbL1Dest.Checked = rbL1Ori.Checked;
                rbL2Dest.Checked = rbL2Ori.Checked;
                _lxDestino = _lxOrigen;

            }
        }

        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (_lxOrigen == null)
            {
                MessageBox.Show($@"Debe Seleccionar Tipo L1 o L2", @"Error en Tipoo de Documento",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_idClienteDestino < 1)
            {
                MessageBox.Show($@"Debe Seleccionar un Cliente Destino", @"Error en Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var importe = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text);
            if (importe == 0)
            {
                MessageBox.Show($"El Importe a traspasar no puede ser {importe.ToString("C2")}", @"Error en Importe",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _listaItems.Clear();
            switch (_tipoAj)
            {
                case TipoAjuste.EntreClientes:
                    AccionTraspasoClientes();
                    break;
                case TipoAjuste.EntreTipos:
                    AccionAjusteTipo();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            if (_listaItems.Count != 1)
            {
                MessageBox.Show($@"El Item para la NCD está vacio", @"Error en ListaItems",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtMotivoTraspaso.Text))
            {
                MessageBox.Show($@"Debe proveer un motivo/explicacion del traspaso", @"Error en Descripcion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtTipoCambio.Text))
                txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");


            var mx = MessageBox.Show(@"Confirma la generacion de los Documentos de Ajsute?", @"Ajuste de CtaCte",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mx == DialogResult.No)
                return;


            //Primer Documento
            _importeT = _importeT * -1;
            var xDoc1 = new CustomerNcdAjustes().GrabaT0300HeaderData(-1, dtpFechaDocumento.Value, _idClienteOrigen,
                _lxOrigen, txtMotivoTraspaso.Text, txtMonedaDocumento.Text, _importeT, _tdoc);

            if (xDoc1 > 0)
            {
                _listaItems[0].IDH = xDoc1;
                new CustomerNcdAjustes().AddItemAjusteContableNCD(_listaItems[0]);
                var ResultadoFinalConta = new CustomerNcdAjustes().ContabilizaCompletoAjuste(xDoc1);
            }

            _importeT = _importeT * -1;
            //Segundo Documento

            var xDoc2 = new CustomerNcdAjustes().GrabaT0300HeaderData(-1, dtpFechaDocumento.Value, _idClienteDestino,
                _lxDestino, txtMotivoTraspaso.Text, txtMonedaDocumento.Text, _importeT, _tdoc);

            if (xDoc2 > 0)
            {
                _listaItems.Clear();
                switch (_tipoAj)
                {
                    case TipoAjuste.EntreClientes:
                        AccionTraspasoClientes();
                        break;
                    case TipoAjuste.EntreTipos:
                        AccionAjusteTipo();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _listaItems[0].IDH = xDoc2;
                _listaItems[0].PUNITARIO = _listaItems[0].PUNITARIO * -1;
                _listaItems[0].PTOTAL = _listaItems[0].PTOTAL * -1;
                if (_tipoAj == TipoAjuste.EntreTipos)
                {
                    _listaItems[0].Descripcion = $"Ajuste Saldo Entre Tipos -- Origen {_lxOrigen}";

                }
                else
                {
                    _listaItems[0].Descripcion = $"Ajuste Saldo Entre Clientes -- Origen {txtClienteOrigienRs.Text}";
                }

                new CustomerNcdAjustes().AddItemAjusteContableNCD(_listaItems[0]);
                var ResultadoFinalConta = new CustomerNcdAjustes().ContabilizaCompletoAjuste(xDoc2);
                _estado = DocumentFIStatusManager.StatusHeader.Registrada;
                txtEstadoDocumento.Text = _estado.ToString();
                txtIdNCD.Text = xDoc2.ToString();
                txtIdNCD.BackColor = Color.GreenYellow;
                txtNAS.Text = ResultadoFinalConta.NumeroAsientoIdDocu.ToString();
                txtIdCtaCte.Text = ResultadoFinalConta.IdCtaCte.ToString();

                MessageBox.Show(@"Se han Creado los documentos de ajuste correspondientes", @"Creacion de Documentos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Registrar el documento. No se puede continuar",
                    @"Error en Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
                txtEstadoDocumento.Text = _estado.ToString();
                txtIdNCD.Text = 0.ToString();
                txtIdNCD.BackColor = Color.LightPink;
            }
        }

        private void txtImporteTraspaso_Validated(object sender, EventArgs e)
        {
            decimal SaldoA = (FormatAndConversions.CCurrencyADecimal(txtSaldoClienteOrigenLX.Text) +
                              (FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso) * -1));
            decimal SaldoB = (FormatAndConversions.CCurrencyADecimal(txtSaldoClienteDestinoLX.Text) +
                              (FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso)));

            txtOriNewSaldo.Text = SaldoA.ToString("C2");
            txtDestNewSaldo.Text = SaldoB.ToString("C2");
        }
    }
}
