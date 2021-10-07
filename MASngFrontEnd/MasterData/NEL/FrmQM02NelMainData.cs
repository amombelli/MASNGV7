using System;
using System.ComponentModel;
using System.Windows.Forms;
using MASngFE.MasterData.Material_Master;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm02NelMainData : Form
    {
        //modo1 - creacion NEL
        public FrmQm02NelMainData(int modo = 1)
        {
            _modo = modo;
            //_modo = 2;//borrar
            //_nel = 1;//borrar
            InitializeComponent();
        }

        //modo2.3
        public FrmQm02NelMainData(int modo, int nel)
        {
            _modo = modo;
            _nel = nel;
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------
        private int _modo;
        private int _nel;
#pragma warning disable CS0414 // The field 'FrmQm02NelMainData._borreFoto1' is assigned but its value is never used
        private bool _borreFoto1 = false;
#pragma warning restore CS0414 // The field 'FrmQm02NelMainData._borreFoto1' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmQm02NelMainData._borreFoto2' is assigned but its value is never used
        private bool _borreFoto2 = false;
#pragma warning restore CS0414 // The field 'FrmQm02NelMainData._borreFoto2' is assigned but its value is never used
        private NelManager.Status _estado;
        //--------------------------------------------------------------------------------------

        private void FrmNelMain_Load(object sender, EventArgs e)
        {
            ConfiguraScreen();
            AccionSegunModo();
        }

        private void ConfiguraScreen()
        {
            coloresBs.DataSource = new ColoresManagement().GetColoresList();
            cmbColor.SelectedIndex = -1;
            clientesBs.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            cmbCliente.SelectedIndex = -1;
            cmbRequeridoPorInterno.DataSource = new HumanResourcesManager().GetListAllActiveVendedor();
            cmbRequeridoPorInterno.SelectedIndex = -1;
            ckEntregoBase.Checked = false;
            ckEntregoMuestra.Checked = false;
            txtModo.Text = _modo.ToString();


            //Disable all buttons except Salir
            btnEnProceso.Enabled = false;
            btnAsignarProvisorio.Enabled = false;
            btnEsperandoRespuesta.Enabled = false;
            btnAproboCliente.Enabled = false;
            btnAsignarDefinitivo.Enabled = false;
            btnRechazoCliente.Enabled = false;
            btnCancelado.Enabled = false;
            btnGrabar.Enabled = false;
            btnBrowseDesarrollo.Enabled = false;
            btnBrowseMuestra.Enabled = false;
            btnAddSeguimiento.Enabled = false;
        }

        private void AccionSegunModo()
        {
            switch (_modo)
            {
                case 1:
                    _nel = NelManager.GetNextNel();
                    txtNel.Text = _nel.ToString();
                    txtLogFechaIn.Text = DateTime.Now.ToString();
                    txtLogUserIn.Text = GlobalApp.AppUsername;
                    txtEstado.Text = NelManager.Status.Inicial.ToString();
                    _estado = NelManager.Status.Inicial;
                    btnGrabar.Enabled = true;
                    btnBrowseDesarrollo.Enabled = true;
                    btnBrowseMuestra.Enabled = true;
                    break;
                case 2:
                    LoadExistingData();
                    AccionSegunEstado();
                    btnGrabar.Enabled = true;
                    btnBrowseDesarrollo.Enabled = true;
                    btnBrowseMuestra.Enabled = true;
                    new ReadOnlyFormControl(true, panIngreso).LockOrUnlockControlsInContainer();
                    break;
                case 3:
                    LoadExistingData();
                    new ReadOnlyFormControl(true, panIngreso).LockOrUnlockControlsInContainer();
                    new ReadOnlyFormControl(true, panDesarrollo).LockOrUnlockControlsInContainer();
                    break;
                default:
                    break;
            }
        }

        private void LoadExistingData()
        {
            var data = new NelManager().GetData(_nel);
            if (data == null)
                return;

            _estado = NelManager.MapTextToStatus(data.EstadoDesarrollo);
            txtNel.Text = _nel.ToString();
            txtEstado.Text = data.EstadoDesarrollo;
            txtIdCliente.Text = data.IdCliente.ToString();
            cmbCliente.SelectedValue = data.IdCliente;
            cmbRequeridoPorInterno.SelectedValue = data.IngresadoPor;
            dtpFechaIngresoLab.Value = data.FechaIngreso;
            txtLogUserIn.Text = data.LogUser;
            txtLogFechaIn.Text = data.LogFechaIngreso.ToString("d");

            cmbColor.SelectedValue = data.ColorDesarrollo;
            cmbCarrierDev.SelectedItem = data.BaseDesarrollo;
            cmbPresentacion.SelectedItem = data.Presentacion;
            txtDureza.Text = null; //falta mapear campo
            ckEntregoBase.Checked = data.EntregoBase;
            ckEntregoMuestra.Checked = data.EntregoMuestra;
            txtComentarioIn.Text = data.ComentarioIngreso;

            txtCodigoDefinitivo.Text = data.CodigoDefinitivo;
            txtCodigoProvisorio.Text = data.CodigoAsignado;

            if (data.FechaAprobacionCliente != null)
                dtpFechaAprobacionCliente.Text = data.FechaAprobacionCliente.Value.ToString("d");

            txtAprobadoPor.Text = data.AprobadoPor;
            pboxMuestra.Image = new ImageManager().ConvertByteToImage(data.Foto1);
            pboxDesarrollo.Image = new ImageManager().ConvertByteToImage(data.Foto2);
            nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
        }

        private T0099_NELS MapFormData()
        {
            var data = new T0099_NELS()
            {
                NEL = _nel,
                EstadoDesarrollo = _estado.ToString(),
                IdCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                ClienteDescripcion = cmbCliente.Text.ToString(),
                IngresadoPor = cmbRequeridoPorInterno.SelectedValue.ToString(),
                FechaIngreso = dtpFechaIngresoLab.Value,
                LogUser = GlobalApp.AppUsername,
                LogFechaIngreso = DateTime.Now,
                ColorDesarrollo = cmbColor.SelectedValue.ToString(),
                BaseDesarrollo = cmbCarrierDev.SelectedItem.ToString(),
                Presentacion = cmbPresentacion.SelectedItem.ToString(),
                EntregoBase = ckEntregoBase.Checked,
                EntregoMuestra = ckEntregoMuestra.Checked,
                ComentarioIngreso = txtComentarioIn.Text,
                CodigoAsignado = txtCodigoProvisorio.Text,
                CodigoDefinitivo = txtCodigoDefinitivo.Text,
                AprobadoPor = txtAprobadoPor.Text,
            };

            if (!string.IsNullOrEmpty(txtAprobadoPor.Text))
                data.FechaAprobacionCliente = dtpFechaAprobacionCliente.Value;


            // if (!string.IsNullOrEmpty(txtDureza.Text))
            // data.??=   txtDureza.Text;

            if (pboxMuestra.ImageLocation != null)
            {
                data.Foto1 = new ImageManager().ConvertFiltoByte(pboxMuestra.ImageLocation);
            }


            if (pboxDesarrollo.ImageLocation != null)
            {
                data.Foto2 = new ImageManager().ConvertFiltoByte(pboxDesarrollo.ImageLocation);
            }

            return data;
        }


        private void AccionSegunEstado()
        {
            btnEnProceso.Enabled = false;
            btnAsignarProvisorio.Enabled = false;
            btnEsperandoRespuesta.Enabled = false;
            btnAproboCliente.Enabled = false;
            btnAsignarDefinitivo.Enabled = false;
            btnRechazoCliente.Enabled = false;
            btnCancelado.Enabled = false;
            btnCrearPrimario.Enabled = false;

            switch (_estado)
            {
                case NelManager.Status.Inicial:

                    break;
                case NelManager.Status.Ingresado:
                    btnCancelado.Enabled = true;
                    btnEnProceso.Enabled = true;
                    break;
                case NelManager.Status.Proceso:
                    btnAsignarProvisorio.Enabled = true;
                    btnCancelado.Enabled = true;
                    btnAddSeguimiento.Enabled = true;
                    break;
                case NelManager.Status.CodigoProv:
                    btnEsperandoRespuesta.Enabled = true;
                    btnCancelado.Enabled = true;
                    break;
                case NelManager.Status.Waiting:
                    btnAproboCliente.Enabled = true;
                    btnRechazoCliente.Enabled = true;
                    btnAddSeguimiento.Enabled = true;
                    btnCancelado.Enabled = true;
                    break;
                case NelManager.Status.Cancelado:
                    btnEnProceso.Enabled = true;
                    btnAddSeguimiento.Enabled = true;
                    break;
                case NelManager.Status.Rechazado:
                    btnEnProceso.Enabled = true;
                    btnCancelado.Enabled = true;
                    btnAddSeguimiento.Enabled = true;
                    break;
                case NelManager.Status.Aprobado:
                    btnAsignarDefinitivo.Enabled = true;
                    btnAddSeguimiento.Enabled = true;
                    btnCancelado.Enabled = true;
                    break;
                case NelManager.Status.Finalizado:
                    btnAddSeguimiento.Enabled = true;
                    btnCancelado.Enabled = true;
                    CheckAddMaterial();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CheckAddMaterial()
        {
            if (new MaterialMasterManager().CheckIfMaterialExistInT0010(txtCodigoDefinitivo.Text) == false)
            {
                btnCrearPrimario.Enabled = true;
            }
            else
            {
                btnCrearPrimario.Enabled = false;
            }
        }

        #region botones



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaOkToSave())
            {
                MessageBox.Show(@"Debe completar la informacion faltante para poder grabar", @"Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resp = MessageBox.Show($"Confirma el Ingreso del NEL # {txtNel.Text}?", @"Ingreso de NEL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            if (_estado == NelManager.Status.Inicial)
            {
                _estado = NelManager.Status.Ingresado;
                txtEstado.Text = _estado.ToString();
            }
            var resultado = new NelManager().SaveUpdateNelData(MapFormData());
            if (resultado == true)
            {
                if (_modo == 1)
                {
                    MessageBox.Show(@"Se han Registrado correctamente el NEL", @"Datos Guardados", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _modo = 2;
                    txtModo.Text = @"2";
                    AccionSegunEstado();
                    _nel = Convert.ToInt32(txtNel.Text);
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                }
                else
                {
                    //estoy guardando un cambio en MODO=2
                    MessageBox.Show(@"Se han guardado Correctamente los datos de este NEL", @"Datos Guardados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    AccionSegunEstado();
                }
            }

            //--
        }

        private void btnBrowseMuestra_Click(object sender, EventArgs e)
        {
            var pic = new OpenFileDialog
            {
                Title = @"Seleccione una imagen que represente la MUESTRA Recibida",
                Filter = @"JPG|*.jpg|PNG|*.png|GIF|*.gif|BMP|*.bmp",
                Multiselect = false
            };

            if (pic.ShowDialog() == DialogResult.OK)
            {
                this.pboxMuestra.ImageLocation = pic.FileName;
            }
        }

        private void btnBrowseDesarrollo_Click(object sender, EventArgs e)
        {
            var pic = new OpenFileDialog
            {
                Title = @"Seleccione una imagen que represente el DESARROLLO Entregado",
                Filter = @"JPG|*.jpg|PNG|*.png|GIF|*.gif|BMP|*.bmp",
                Multiselect = false
            };

            if (pic.ShowDialog() == DialogResult.OK)
            {
                this.pboxDesarrollo.ImageLocation = pic.FileName;
            }
        }

        #endregion

        private bool ValidaOkToSave()
        {
            var resp = true;

            ep.SetError(cmbCliente, "");
            ep.SetError(cmbRequeridoPorInterno, "");
            ep.SetError(cmbColor, "");
            ep.SetError(cmbPresentacion, "");
            ep.SetError(cmbCarrierDev, "");

            if (cmbCliente.SelectedValue == null)
                resp = Validaciones.SetErrorErrorPrivider(cmbCliente, ep);

            if (cmbRequeridoPorInterno.SelectedValue == null)
                resp = Validaciones.SetErrorErrorPrivider(cmbRequeridoPorInterno, ep);

            if (cmbColor.SelectedValue == null)
                resp = Validaciones.SetErrorErrorPrivider(cmbColor, ep);

            if (cmbCarrierDev.SelectedItem == null)
                resp = Validaciones.SetErrorErrorPrivider(cmbCarrierDev, ep);

            if (cmbPresentacion.SelectedItem == null)
                resp = Validaciones.SetErrorErrorPrivider(cmbPresentacion, ep);

            return resp;
        }

        #region Validaciones

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
                txtIdCliente.Text = null;
        }

        private void cmbCliente_Validating(object sender, CancelEventArgs e)
        {
            Validaciones.CheckComboBoxFixedItems(sender, e, ep, "Debe proverr un nombre de cliente valido");
        }

        private void cmbPresentacion_Validating(object sender, CancelEventArgs e)
        {
            Validaciones.CheckComboBoxFixedItems(sender, e, ep);
        }

        private void cmbCarrierDev_Validating(object sender, CancelEventArgs e)
        {
            Validaciones.CheckComboBoxFixedItems(sender, e, ep);
        }

        private void txtDureza_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void cmbColor_Validating(object sender, CancelEventArgs e)
        {
            Validaciones.CheckComboBoxFixedItems(sender, e, ep);
        }

        private void txtNel_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtNel_Validating(object sender, CancelEventArgs e)
        {
        }

        #endregion

        private void btnAddSeguimiento_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm03NelAddProgress(1, _nel))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                }
                else
                {

                }
            }
        }

        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            _estado = NelManager.Status.Proceso;
            txtEstado.Text = _estado.ToString();
            NelManager.UpdateEstado(_nel, _estado);
            new NelManager().SetNelProgress(_nel, _estado, "Se ha colocado el NEL en estado En-Proceso");
            nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
            AccionSegunEstado();
        }

        private void btnAsignarProvisorio_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm04AsignaCodigo(_nel, NelManager.TipoCodigo.Provisorio))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtCodigoProvisorio.Text = f.CodigoAsignado;
                    _estado = NelManager.Status.CodigoProv;
                    txtEstado.Text = _estado.ToString();
                    new NelManager().SaveUpdateNelData(MapFormData());
                    new NelManager().SetNelProgress(_nel, _estado,
                        "Se ha Asignado un Codigo Provisorio/Prueba de Material", txtCodigoProvisorio.Text);
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                    AccionSegunEstado();
                }
                else
                {
                }
            }
        }

        private void btnEsperandoRespuesta_Click(object sender, EventArgs e)
        {
            _estado = NelManager.Status.Waiting;
            txtEstado.Text = _estado.ToString();
            NelManager.UpdateEstado(_nel, _estado);
            new NelManager().SetNelProgress(_nel, _estado, "Muestra Entregada - Esperando Respuesta del Cliente");
            nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
            AccionSegunEstado();
        }

        private void btnAproboCliente_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm06AprobacionMuestra(_nel))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtAprobadoPor.Text = f.AprobadoPor;
                    dtpFechaAprobacionCliente.Value = f.FechaAprobacion;
                    _estado = NelManager.Status.Aprobado;
                    txtEstado.Text = _estado.ToString();
                    new NelManager().SaveUpdateNelData(MapFormData());
                    new NelManager().SetNelProgress(_nel, _estado, "El Cliente ha aprobado la Muestra");
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                    AccionSegunEstado();
                }
                else
                {
                }
            }
        }

        private void btnAsignarDefinitivo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm04AsignaCodigo(_nel, NelManager.TipoCodigo.Definitivo))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtCodigoDefinitivo.Text = f.CodigoAsignado;
                    _estado = NelManager.Status.Finalizado;
                    txtEstado.Text = _estado.ToString();
                    new NelManager().SaveUpdateNelData(MapFormData());
                    new NelManager().SetNelProgress(_nel, _estado,
                        $"Se ha Asignado el codigo {f.CodigoAsignado} al Material y se ha Finalizado el NEL", txtCodigoProvisorio.Text);
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                    AccionSegunEstado();
                }
                else
                {
                }
            }
        }

        private void btnRechazoCliente_Click(object sender, EventArgs e)
        {
            _estado = NelManager.Status.Rechazado;
            txtEstado.Text = _estado.ToString();
            NelManager.UpdateEstado(_nel, _estado);
            new NelManager().SetNelProgress(_nel, _estado, "El Cliente ha Rechazado el desarrollo");
            nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
            AccionSegunEstado();
        }

        private void btnCancelado_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm05NelCancelation(_nel))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _estado = NelManager.Status.Cancelado;
                    txtEstado.Text = _estado.ToString();
                    NelManager.UpdateEstado(_nel, _estado);
                    new NelManager().SetNelProgress(_nel, _estado, $"NEL Cancelado Motivo: >{f.MotivoCancelacion}");
                    nelUpdateBs.DataSource = new NelManager().GetListOfUpdate(_nel);
                    AccionSegunEstado();
                }
                else
                {

                }
            }
        }

        private void dgvAkaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();


                int idSeq =
                    Convert.ToInt32(
                        dgvAkaList[dgvAkaList.Columns[nELSEQDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value
                            .ToString());
                switch (cellValue)
                {
                    case "VER":
                        using (var f0 = new FrmQm03NelAddProgress(_modo, _nel, idSeq))
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

        private void txtNel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNel_DoubleClick(object sender, EventArgs e)
        {
            txtNel.ReadOnly = !txtNel.ReadOnly;
        }

        private void txtNel_Validating_1(object sender, CancelEventArgs e)
        {
            if (_modo == 1)
            {
                if (string.IsNullOrEmpty(txtNel.Text))
                {
                    _nel = NelManager.GetNextNel();
                    txtNel.Text = _nel.ToString();
                }
                else
                {
                    var data = Convert.ToInt32(txtNel.Text);
                    if (NelManager.GetIfNelExist(data) == false)
                    {
                        _nel = data;
                    }
                    else
                    {
                        MessageBox.Show(@"El NEL ya Existe! Se completa con el proximo numero disponible", @"NEL Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _nel = NelManager.GetNextNel();
                        txtNel.Text = _nel.ToString();
                    }
                }
            }
        }

        private void txtNel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void btnCrearPrimario_Click(object sender, EventArgs e)
        {
            var data = new NelManager().GetData(_nel);
            if (data.CodigoDefinitivo == null)
            {
                MessageBox.Show(@"No se puede crear el material porque aún no se ha asignado un codigo",
                    @"Codigo Definitivo NO ASIGNADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var mat = new MaterialMasterManager().GetPrimarioInfo(data.CodigoDefinitivo);
            if (mat != null)
            {
                MessageBox.Show(@"No se puede crear el material porque el Material ya ha sido creado",
                    @"Creacion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            var fx = new FrmMdm01MaterialMasterMain(1, _nel);
            fx.Show();
            this.Close();
        }
    }
}
