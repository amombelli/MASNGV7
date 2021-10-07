using System;
using System.Collections.Generic;
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
    public partial class FrmFI66NCDAjustes : Form
    {
        public FrmFI66NCDAjustes(int idCliente, string tipoLx, string indicador)
        {
            //Creacion de Nuevo Ajuste
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
            _indicador = indicador;
            _idH = -1;
            _modo = 1;
            InitializeComponent();
        }
        public FrmFI66NCDAjustes(int modo, int idH)
        {
            _idH = idH;
            _modo = modo;
            InitializeComponent();
        }

        private readonly int _modo;
        private int _idCliente;
        private string _tipoLx;
        private string _tdoc;
        private int _idH;
        private DocumentFIStatusManager.StatusHeader _estado;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private readonly string _indicador;
        private List<T0301_NCD_I> _listaItems = new List<T0301_NCD_I>();
        private XCustomerNcd _docData;

        private void FrmFI66NCDAjustes_Load(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                //Creacion de Documento
                LoadHeaderDataFromMasterData();
                LoadCustomerDataInfo();
                AccionSegunIndicadorInicial();

            }
            else
            {
                //Edicion o Visualizacion de documento
                LoadInitialDataFromExistingDocument();
                LoadCustomerDataInfo();


            }
            AccionEstadoDocumento();

        }

        private void LoadCustomerDataInfo()
        {
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cli.cli_rsocial;
            txtCuit.Text = cli.CUIT;
            txtCuitValidado.BackColor = new CuitValidation().ValidarCuit(txtCuit.Text) ? Color.GreenYellow : Color.Red;
            txtDireccionFiscal.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtCP.Text = cli.ZIP;
        }
        private void LoadHeaderDataFromMasterData()
        {
            txtTipoLx.Text = _tipoLx;
            txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;
            txtEstadoDocumento.Text = _estado.ToString();
            txtNumeroDocumento.Text = @"NO-ASIGNADO";
            dtpFechaDocumento.Value = DateTime.Today;
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value).ToString("N2");
            txtSaldoActual.Text = new CtaCteCustomer(_idCliente).GetResultadoCtaCte(_tipoLx).SaldoResumen.ToString("C2");
        }

        private void AccionSegunIndicadorInicial()
        {
            _listaItems.Clear();
            switch (_indicador)
            {
                case "AJ":
                    txtGL.Text = @"7.1.1";
                    AccionAjusteRedondeo();
                    break;
                case "AP":
                    txtGL.Text = @"7.2";
                    AccionAjustePerdida();
                    ckBloqueoCliente.Checked = true;
                    ckInactivarCliente.Checked = true;
                    break;
                case "AI":
                    txtGL.Text = @"7.3";
                    AccionPerdidaAsumidaConCobranza();
                    ckBloqueoCliente.Checked = true;
                    ckInactivarCliente.Checked = true;
                    break;
                default:
                    MessageBox.Show(@"Atencion El Tipo de Documento no tiene una Accion Predefinida", @"Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            txtGLDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGL.Text);
        }

        private void LoadInitialDataFromExistingDocument()
        {
            //los datos se cargan siempre desde el documento en T300
            var ncdData = new NcdTableManager().GetNCDHData(_idH);
            if (ncdData == null)
            {
                MessageBox.Show(@"No se puede continuar porque los datos estan incompletos/mal mantenidos",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            txtNumeroDocumento.Text = ncdData.NDOC;
            txtTipoCambio.Text = ncdData.TC.ToString("N2");
            txtMotivoAjuste.Text = ncdData.COMENTARIO;
            _estado = DocumentFIStatusManager.StatusHeader.Contabilizada;
            _idCliente = ncdData.IdCliente;
            _listaItems = new NcdTableManager().GetItemList(_idH);
            _tipoLx = ncdData.LX;
            txtIdNCD.Text = _idH.ToString();
            txtTipoLx.Text = _tipoLx;
            _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTdocString(ncdData.TDOC, _tipoLx);
            txtGL.Text = _listaItems[0].GL;
            txtGLDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGL.Text);
            if (ncdData.MON == "ARS")
            {
                txtImporteDocumento.Text = ncdData.ImporteARS.ToString("C2");
            }
            else
            {
                txtImporteDocumento.Text = ncdData.ImporteUSD.ToString("C2");
            }
        }

        private void AccionEstadoDocumento()
        {
            dtpFechaDocumento.Enabled = false;
            txtTipoCambio.ReadOnly = true;
            txtMotivoAjuste.ReadOnly = true;
            switch (_estado)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    dtpFechaDocumento.Enabled = true;
                    txtTipoCambio.ReadOnly = false;
                    txtMotivoAjuste.ReadOnly = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    txtMotivoAjuste.ReadOnly = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        private void AccionAjustePerdida()
        {
            var data = new T0301_NCD_I()
            {
                MON = txtMonedaDocumento.Text,
                CANT = 1,
                Descripcion = "Perdidas Incobrables",
                GL = txtGL.Text,
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = false,
                PUNITARIO = txtAjuste.GetValueDecimal,
                PTOTAL = txtAjuste.GetValueDecimal,
            };
            _listaItems.Add(data);
        }
        private void AccionPerdidaAsumidaConCobranza()
        {
            var data = new T0301_NCD_I()
            {
                MON = txtMonedaDocumento.Text,
                CANT = 1,
                Descripcion = "Perdidas Incobrables a Cahsflow +",
                GL = txtGL.Text,
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = false,
                PUNITARIO = txtAjuste.GetValueDecimal,
                PTOTAL = txtAjuste.GetValueDecimal,
            };
            _listaItems.Add(data);
        }
        private void AccionAjusteRedondeo()
        {
            //Ajuste por Redondeo
            var data = new T0301_NCD_I()
            {
                MON = txtMonedaDocumento.Text,
                CANT = 1,
                Descripcion = "Ajuste de Saldo/Redondeo",
                GL = txtGL.Text,
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = false,
                PUNITARIO = txtAjuste.GetValueDecimal,
                PTOTAL = txtAjuste.GetValueDecimal,
            };
            _listaItems.Add(data);
            AsignaNumeroItem();
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



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNuevoSaldo_Validated(object sender, EventArgs e)
        {
            txtAjuste.SetValue = txtNuevoSaldo.GetValueDecimal -
                                 FormatAndConversions.CCurrencyADecimal(txtSaldoActual.Text);

            //Por ahora todos los ajustes generan mismo tipo de documento == "AJ"
            if (_indicador == "AJ")
            {
                //Ajuste Positivo o Negativo por redondeo
                _tdoc = "AJ";

            }
            else
            {
                if (_indicador == "AP")
                {
                    //Ajuste Perdida por Mala Gestión Cobranza
                    _tdoc = "AJ";
                }
                else
                {
                    //Ajuste Perdida con Simulacion de Cobranza
                    _tdoc = "AJ";

                }
            }
            txtTdoc.Text = _tdoc;
            txtImporteDocumento.Text = txtAjuste.GetValueDecimal.ToString("C2");

            if (string.IsNullOrEmpty(txtMotivoAjuste.Text))
            {
                txtMotivoAjuste.Text = $@"Ajuste de {txtImporteDocumento.Text} :-  ";
            }

            if (ckBloqueoCliente.Checked)
            {
                txtComentarioBloqueo.Text = $@"Bloqueo con Ajuste de {txtImporteDocumento.Text}.";
            }
        }
        private bool ValidaRegistradoOK()
        {
            if (_listaItems.Count == 0)
            {
                MessageBox.Show(@"El documento no contiene Items", @"Datos Incompletos or Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtGL.Text))
            {
                MessageBox.Show(@"Error en el GL Definido", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivoAjuste.Text))
            {
                MessageBox.Show(@"Debe proveer una descripcion para el documento", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (txtAjuste.GetValueDecimal == 0)
            {
                MessageBox.Show(@"El Ajuste debe ser diferente a $0.00-", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ckBloqueoCliente.Checked == true || ckInactivarCliente.Checked == true)
            {
                if (string.IsNullOrEmpty(txtComentarioBloqueo.Text))
                {
                    MessageBox.Show(@"Debe ingresar un comentario para el bloqueo/Inactivacion", @"Comentario Faltante",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }


        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (!ValidaRegistradoOK())
                return;

            var confirma = MessageBox.Show(@"Confirma la REGISTRACION del Documento?", @"Registracion de Documento",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;

            var xAjuste = new CustomerNcdAjustes().GrabaT0300HeaderData(-1, dtpFechaDocumento.Value, _idCliente,
                _tipoLx, txtMotivoAjuste.Text, txtMonedaDocumento.Text, txtAjuste.GetValueDecimal, _tdoc);

            if (xAjuste > 0)
            {
                _listaItems[0].IDH = xAjuste;
                var xAjusteItem = new CustomerNcdAjustes().AddItemAjusteContableNCD(_listaItems[0]);
                if (xAjusteItem > 0)
                {
                    MessageBox.Show($@"Se ha registrado el documento con el numero# {xAjuste}. Debe contabilizarlo",
                        @"Registracion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un Error al Registrar el documento. No se puede continuar",
                        @"Error en Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ojo que se creo el header pero sin items!
                }
                _estado = DocumentFIStatusManager.StatusHeader.Registrada;
                txtEstadoDocumento.Text = _estado.ToString();
                txtIdNCD.Text = xAjuste.ToString();
                txtIdNCD.BackColor = Color.GreenYellow;
                _idH = xAjuste;
                var ResultadoFinalConta = new CustomerNcdAjustes().ContabilizaCompletoAjuste(_idH);
                txtNAS.Text = ResultadoFinalConta.NumeroAsientoIdDocu.ToString();
                txtIdCtaCte.Text = ResultadoFinalConta.IdCtaCte.ToString();
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
            AccionEstadoDocumento();
            if (ckBloqueoCliente.Checked || ckInactivarCliente.Checked)
            {
                ProcesarBloqueo();
            }
            this.Close();
        }

        private void btnBloqueos_Click(object sender, EventArgs e)
        {
            if (ckBloqueoCliente.Checked || ckInactivarCliente.Checked)
            {
                ProcesarBloqueo();
            }
            else
            {
                MessageBox.Show(@"No Hay Bloqueos para procesar", @"Debe Seleccionar una Opcion de Bloqueo/Inactividad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ProcesarBloqueo()
        {
            string comentario;
            if (ckBloqueoCliente.Checked == true || ckInactivarCliente.Checked == true)
            {
                if (string.IsNullOrEmpty(txtComentarioBloqueo.Text))
                {
                    if (string.IsNullOrEmpty(txtMotivoAjuste.Text))
                    {
                        MessageBox.Show(@"Debe ingresar un comentario para el bloqueo/Inactivacion", @"Comentario Faltante",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        comentario = txtMotivoAjuste.Text;
                    }
                }
                else
                {
                    comentario = txtComentarioBloqueo.Text;
                }

                if (ckBloqueoCliente.Checked)
                {
                    CustomerMDActionsAndLog.BloqueaClientePedido(_idCliente, comentario);
                }

                if (ckInactivarCliente.Checked)
                {
                    CustomerMDActionsAndLog.InactivaCliente(_idCliente, comentario);
                }
                new CustomerManager().UpdateComentarioCliente(_idCliente, comentario);
                this.Close();
            }
        }
    }
}
