using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.HR;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.MM
{

    //ApruebaRtnFe
    //ApruebaRtnCliente

    public partial class FrmRetornoMaterialAPlanta : Form
    {
        public FrmRetornoMaterialAPlanta(int modo, int idH)
        {
            _idh = idH;
            InitializeComponent();
        }
        public FrmRetornoMaterialAPlanta(int modo = 0)
        {
            //modo standard de ingreso a RTN
            InitializeComponent();
        }

        private int? _id6;
        private RtnIdentificacionMaterial _rtnInfo;
        private RtnMaterialSimpleValidation _rtnSimple;
        private int _idh;
        private MotivoDevolucion.Motivo _motivoIngreso;
        private T0360_RTN _data = new T0360_RTN();

        //-------------------------    Funcionalidad de Combos ------------------------------------

        private void FrmRetornoMaterialAPlanta_Load(object sender, EventArgs e)
        {
            cmbRecibidoPor.Items.AddRange(HRComboManager.GetListaEmployee("RTNRECIBE").ToArray());
            cmbRecibidoPor.SelectedIndex = -1;
            t0028SLOCBindingSource.DataSource = new StorageLocationManager().ListOfLoc();
            cmbRecibidoPor.SelectedIndex = -1;
            cmbAprobadoPor.SelectedIndex = -1;
            cmbSloc.SelectedValue = "LAB1";
            BlanqueaData();
            grp1.Enabled = false;
        }
        private void MapDataFromScreen()
        {
            var x = new T0360_RTN()
            {
                IDCLI = _id6.Value,
                CLIENTE = new CustomerManager().GetCustomerBillToData(_id6.Value).cli_rsocial,
                MATERIAL = txtMaterialRecibido.Text.ToUpper(),
                FECHA = cFechaRececpcion.Value.Value,
                KG = cCantidadRtn.GetValueDecimal,
                LOTE = txtNumeroLoteRecepcion.Text,
                RECIBIO = cmbRecibidoPor.SelectedItem.ToString(),
                UBICACION = cmbSloc.SelectedValue.ToString(),
                MOTIVO = _motivoIngreso.ToString(),
                COMENTARIO = txtMotivoDevolucion.Text,
                TIPO_MOV = "LX",
                IDX = _idh,
                AprobadoPor = cmbAprobadoPor.SelectedItem.ToString(),
            };
            _data = x;
        }
        private void BlanqueaData()
        {
            txtMaterialRecibido.Text = null;
            cCantidadRtn.SetValue = 0;
            txtNumeroLoteRecepcion.Text = null;
            cFechaRececpcion.Value = DateTime.Today;
            cSemMaterialOk.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            cSemCantidadOk.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            cSemLoteRecibidoOk.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            //
            cmbRecibidoPor.SelectedIndex = -1;
            cmbAprobadoPor.SelectedIndex = -1;
            cmbSloc.SelectedValue = "LAB1";
            cCantidadRtn.SetValue = 0;

            //
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!AllowReception())
                return;

            var pregunta = MessageBox.Show(@"Confirma el RE-INGRESO del Material Seleccionado?",
                @"Confirmacion de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.No)
                return;

            MapDataFromScreen();
            _idh = new ManageRetornoMaterial().GuardaRtn(_data);
            if (_idh > 0)
            {
                txtIdH.Text = _idh.ToString();
                new StockABM().AltaNewStockLine(_data.MATERIAL, _data.LOTE, _data.KG,
                    StockStatusManager.EstadoLote.Restringido, cmbSloc.SelectedValue.ToString(), "RTN1", false,
                    txtMotivoDevolucion.Text);
                var id40 = new MmLog().LogMMAltaNewStockDevolucion(_motivoIngreso, _idh, StockStatusManager.EstadoLote.Restringido);
                new ManageRetornoMaterial().UpdateId40(_idh, id40);
                MessageBox.Show(@"Se ha ingresado el Stock en Forma Correcta!", @"Re-Ingreso de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIngresar.Enabled = false;
            }
        }
        private bool AllowReception()
        {
            if (_id6 == null || _id6 == 0)
            {
                MessageBox.Show(@"Debe Selecionar un Cliente", @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_rtnSimple.MaterialOk == false)
            {
                MessageBox.Show(@"El Material no Corresponde", @"Error en Validacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_rtnSimple.LoteOk == false)
            {
                MessageBox.Show(
                    @"El Numero de Lote a Ingresar no se corresponde con un Lote Valido para este material/cliente",
                    @"Error en Validacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (cCantidadRtn.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"La Cantidad a Reingresar en Kg es Incorrecta", @"Error en Validacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var ckMotivoSeleccionado = grpMotivo.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (ckMotivoSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Motivo por el que se realiza el Ingreso a Stock", @"Kg a Ingresar Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbRecibidoPor.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Seleccionar quien fue el responsable de Recibir el Material",
                    @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbAprobadoPor.SelectedItem == null)
            {
                MessageBox.Show(@"Debe Seleccionar quien es el responsable de Aceptar el Material/Devolucion",
                    @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void rbOtro_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpMotivo.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            cmbAprobadoPor.SelectedItem = -1;
            cmbAprobadoPor.Items.Clear();
            if (checkedButton == null)
            {
                return;
            }

            switch (checkedButton.Name)
            {
                case "rbFE":
                    _motivoIngreso = MotivoDevolucion.Motivo.FE;
                    cmbAprobadoPor.Items.AddRange(HRComboManager.GetListaEmployee("RTNAPRUEBAFE").ToArray());
                    break;
                case "rbOtro":
                    _motivoIngreso = MotivoDevolucion.Motivo.Otro;
                    cmbAprobadoPor.Items.AddRange(HRComboManager.GetListaEmployee("RTNAPRUEBAOTRO").ToArray());
                    break;
                case "rbPedidoIncorrecto":
                    _motivoIngreso = MotivoDevolucion.Motivo.PedidoIncorrecto;
                    cmbAprobadoPor.Items.AddRange(HRComboManager.GetListaEmployee("RTNAPRUEBAOTRO").ToArray());
                    break;
                case "rbStockSobrante":
                    _motivoIngreso = MotivoDevolucion.Motivo.SobranteCliente;
                    cmbAprobadoPor.Items.AddRange(HRComboManager.GetListaEmployee("RTNAPRUEBAOTRO").ToArray());
                    break;
                default:
                    break;
            }
            cmbAprobadoPor.SelectedItem = -1;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsUcCustomerSearch11_ClienteModificado(object source, _0TSUserControls.TsCustomerSearchEventArgs args)
        {
            if (tsUcCustomerSearch11.ClienteId == null)
            {
                grp1.Enabled = false;
                btnIngresar.Enabled = false;
                _rtnSimple = null;
                _rtnInfo = null;
                _id6 = null;
                return;
            }
            _id6 = tsUcCustomerSearch11.ClienteId;
            _rtnInfo = new RtnIdentificacionMaterial(_id6.Value);
            _rtnSimple = new RtnMaterialSimpleValidation(_id6.Value);
            btnIngresar.Enabled = true;
            grp1.Enabled = true;
        }

        private void txtMaterialRecibido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cSemMaterialOk.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            cSemLoteRecibidoOk.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
            cSemCantidadOk.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
            _rtnSimple.SetMaterialRecibidoCliente(txtMaterialRecibido.Text);
            if (_rtnSimple.MaterialOk)
            {
                cSemMaterialOk.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            btnIngresar.Enabled = _rtnSimple.LoteOk;
        }

        private void cCantidadRtn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cSemCantidadOk.SetLights = cCantidadRtn.GetValueDecimal > 0
                ? CtlSemaforo.ColoresSemaforo.Verde
                : CtlSemaforo.ColoresSemaforo.Rojo;
        }
        private void txtNumeroLoteRecepcion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cSemLoteRecibidoOk.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            _rtnSimple.SetLoteValidar(txtNumeroLoteRecepcion.Text, txtMaterialRecibido.Text);
            if (_rtnSimple.LoteOk)
            {
                cSemLoteRecibidoOk.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                btnIngresar.Enabled = true;
            }
            else
            {
                btnIngresar.Enabled = false;
            }
        }
        private void btnImprimirRecepcion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Proximamente se podra imprimir un papel para hacer seguimiento y enviar a administracion");
        }

        private void cmbRecibidoPor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedItem == null && !string.IsNullOrEmpty(combo.Text))
                e.Cancel = true;
        }


        //var x = new HRComboManager();
        //x.Addfuncion("RecibeRtn","Recibe Devoluciones de Materiales de Cliente");
        //x.Addfuncion("ApruebaRtnFe", "Aprueba la Devolucion del Material FE (Lab)");
        //x.Addfuncion("ApruebaRtnCliente", "Aprueba la Devolucion por Error de Cliente");

        //x.AddAsignacion("JFILARDO","RECIBERTN");
        //x.AddAsignacion("NPEREYRA", "RECIBERTN");
        //x.AddAsignacion("LAVILA", "RECIBERTN");
        //x.AddAsignacion("NMOMBELLI", "RECIBERTN");

        //x.AddAsignacion("NMOMBELLI", "ApruebaRtnFe");
        //x.AddAsignacion("MMOMBELLI", "ApruebaRtnFe");
        //x.AddAsignacion("JFILARDO", "ApruebaRtnFe");
        //x.AddAsignacion("NPEREYRA", "ApruebaRtnFe");

        //x.AddAsignacion("NMOMBELLI", "ApruebaRtnCliente");
        //x.AddAsignacion("MMOMBELLI", "ApruebaRtnCliente");
    }


}
