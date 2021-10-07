using System;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    public partial class FrmHojaRuta : Form
    {
        public FrmHojaRuta(int modo, int idRuta)
        {
            _modo = modo;
            _idRuta = idRuta;
            InitializeComponent();
        }

        private int _idRuta;
        private HojaRutaStatusManager.StatusHeader _status;
        private readonly int _modo;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRemitosToRuta_Click(object sender, EventArgs e)
        {
            if (_idRuta == 0)
            {
                var data = MapData();
                if (ValidaDataToCreateHeader(data))
                {
                    _idRuta = new HojaRutaManager().CreaHojaRutaHeader(data);
                    txtNumeroRuta.Text = _idRuta.ToString();
                    using (var f0 = new FrmAddRemitosRuta(_idRuta))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //    string custName = f0.CustomerName;
                            //    SaveToFile(custName);
                        }
                    }
                }
            }
            else
            {
                using (var f0 = new FrmAddRemitosRuta(_idRuta))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //    string custName = f0.CustomerName;
                        //    SaveToFile(custName);
                    }
                }
            }
        }

        private T0059_HOJARUTA_H MapData()
        {
            var data = new T0059_HOJARUTA_H();
            data.IdRuta = _idRuta;
            data.StatusRuta = _status.ToString();
            data.FechaDespacho = dtpFechaEnvio.Value;
            data.EmpresaFlete = txtNombreEmpresa.Text;
            data.DescripcionFlete = txtObservaciones.Text;
            data.Chofer = txtNombreChofer.Text;
            data.Matricula = txtMatricula.Text;
            data.TipoEnvio = cmbTipoEnvio.Text.ToString();
            if (string.IsNullOrEmpty(txtCostoArs.Text))
                txtCostoArs.Text = 0.ToString("N2");
            data.CostoFlete = Convert.ToDecimal(txtCostoArs.Text);

            data.HoraLlegada = dtpHoraLlegada.Value;
            data.HoraSalida = dtpHoraSalida.Value;

            if (string.IsNullOrEmpty(txtKmRecorridos.Text))
                txtKmRecorridos.Text = 0.ToString("N2");
            data.KmRecorridos = Convert.ToDecimal(txtKmRecorridos.Text); //todo: agregar campo km (decimal)
            return data;
        }

        private bool ValidaDataToCreateHeader(T0059_HOJARUTA_H data)
        {
            return _idRuta <= 0 || Merror(@"La Ruta que esta intentando crear ya existe!");
        }

        private bool Merror(string mensaje)
        {
            MessageBox.Show(@mensaje, @"Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void txtKmRecorridos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void FrmHojaRuta_Load(object sender, EventArgs e)
        {
            MapDataToScreen();
            SetComportamiento();
        }

        private void MapDataToScreen()
        {
            if (_modo == 1)
            {
                _status = HojaRutaStatusManager.StatusHeader.Pendiente;
                txtNumeroRuta.Text = @"000";
                txtEstadoRuta.Text = _status.ToString();
                dtpFechaEnvio.Value = DateTime.Today;
                cmbTipoEnvio.SelectedValue = "FLETE PROPIO";
                cmbTipoEnvio.Text = @"FLETE PROPIO";
                txtNombreEmpresa.Text = @"TECSER";
                txtNombreChofer.Text = @"DIEGO CABALEIRO";
                txtMatricula.Text = @"AB562UN";
                dtpHoraSalida.Value = DateTime.Now.AddMinutes(30);
                dtpHoraLlegada.Value = DateTime.Parse("17:00");
                txtKmRecorridos.Text = 0.ToString("N2");
                txtCostoArs.Text = 0.ToString("N2");
            }
            else
            {
                var data = new HojaRutaManager().GetHRutaData(_idRuta);
                _status = HojaRutaStatusManager.MapStatusHeaderFromText(data.StatusRuta);
                txtNumeroRuta.Text = _idRuta.ToString();
                txtEstadoRuta.Text = _status.ToString();
                dtpFechaEnvio.Value = data.FechaDespacho.Value;
                cmbTipoEnvio.SelectedValue = data.TipoEnvio;
                txtNombreEmpresa.Text = data.EmpresaFlete;
                txtNombreChofer.Text = data.Chofer;
                txtMatricula.Text = data.Matricula;
                dtpHoraSalida.Value = (DateTime)data.HoraSalida;
                dtpHoraLlegada.Value = (DateTime)data.HoraLlegada;
                txtKmRecorridos.Text = data.KmRecorridos.ToString();
                txtCostoArs.Text = data.CostoFlete.ToString();
            }
            t0059HOJARUTAIBindingSource.DataSource = new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
            dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
        }

        private void SetComportamiento()
        {
            btnAddRemitosToRuta.Enabled = false;
            btnConfirmarHRuta.Enabled = false;
            btnConfirmarHRuta.Enabled = false;
            btnImprimirHojaRuta.Enabled = false;
            switch (_status)
            {
                case HojaRutaStatusManager.StatusHeader.Pendiente:
                    switch (_modo)
                    {
                        case 1:
                            btnAddRemitosToRuta.Enabled = true;
                            btnConfirmarHRuta.Enabled = true;
                            break;
                        case 2:
                            btnAddRemitosToRuta.Enabled = true;
                            btnConfirmarHRuta.Enabled = true;
                            break;
                        case 3:
                            break;
                    }
                    break;
                case HojaRutaStatusManager.StatusHeader.EnRuta:
                    switch (_modo)
                    {
                        case 1:
                            MessageBox.Show(@"Modo-Status No Soportado", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            break;
                        case 2:
                            btnImprimirHojaRuta.Enabled = true;
                            break;
                        case 3:
                            btnImprimirHojaRuta.Enabled = true;
                            break;
                    }
                    break;
                case HojaRutaStatusManager.StatusHeader.Finalizado:
                    switch (_modo)
                    {
                        case 1:
                            MessageBox.Show(@"Modo-Status No Soportado", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            break;
                        case 2:
                            btnImprimirHojaRuta.Enabled = true;
                            break;
                        case 3:
                            break;
                    }
                    break;
                case HojaRutaStatusManager.StatusHeader.Incompleto:
                    switch (_modo)
                    {
                        case 1:
                            _status = HojaRutaStatusManager.StatusHeader.Pendiente;
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
                case HojaRutaStatusManager.StatusHeader.Cancelada:
                    switch (_modo)
                    {
                        case 1:
                            _status = HojaRutaStatusManager.StatusHeader.Pendiente;
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void cmbTipoEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvRemitosHRuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvRemitosHRuta[e.ColumnIndex, e.RowIndex].Value.ToString();

                int idRuta =
                    Convert.ToInt32(
                        dgvRemitosHRuta[dgvRemitosHRuta.Columns["idRutaDataGridViewTextBoxColumn1"].Index, e.RowIndex]
                            .Value);
                int idItem =
                    Convert.ToInt32(
                        dgvRemitosHRuta[dgvRemitosHRuta.Columns["idItemDataGridViewTextBoxColumn"].Index, e.RowIndex]
                            .Value);
                int idOrden;

                if (
                    dgvRemitosHRuta[dgvRemitosHRuta.Columns["ordenEntregaDataGridViewTextBoxColumn"].Index, e.RowIndex]
                        .Value == null)
                {
                    idOrden = idItem;
                }
                else
                {
                    idOrden =
                        Convert.ToInt32(
                            dgvRemitosHRuta[
                                dgvRemitosHRuta.Columns["ordenEntregaDataGridViewTextBoxColumn"].Index, e.RowIndex]
                                .Value);
                }

                switch (cellValue.ToUpper())
                {
                    case "DETALLE":
                        using (var f0 = new FrmAddRemitosRuta(_idRuta, idItem))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                //string custName = f0.CustomerName;
                                //SaveToFile(custName);
                                t0059HOJARUTAIBindingSource.DataSource =
                                    new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
                                dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
                            }
                        }
                        break;
                    case "+":
                        if (_status == HojaRutaStatusManager.StatusHeader.Pendiente)
                        {
                            new HojaRutaManager().SubirPrioridad(idRuta, idOrden);
                            t0059HOJARUTAIBindingSource.DataSource =
                                new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
                            dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
                        }
                        {
                            MessageBox.Show(@"Esta accion no esta disponible en el estado de esta hoja de ruta",
                                @"Accion no Permitida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "-":
                        if (_status == HojaRutaStatusManager.StatusHeader.Pendiente)
                        {
                            new HojaRutaManager().BajarPrioridad(idRuta, idOrden);
                            t0059HOJARUTAIBindingSource.DataSource =
                                new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
                            dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
                        }
                        else
                        {
                            MessageBox.Show(@"Esta accion no esta disponible en el estado de esta hoja de ruta",
                                @"Accion no Permitida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void btnImprimirHojaRuta_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmarHRuta_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(@"Confirma la Hoja de Ruta?", @"Confirmacion Hoja de Ruta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            new HojaRutaManager().ConfirmacionHojaRuta(_idRuta);
            _status = HojaRutaStatusManager.StatusHeader.EnRuta;
            txtEstadoRuta.Text = _status.ToString();
            t0059HOJARUTAIBindingSource.DataSource = new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
            dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
        }

        private void btnCerrarHojaRuta_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(@"Confirma el Cierre de la Hoja de Ruta?",
                @"Confirmacion Cierre Hoja de Ruta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            new HojaRutaManager().CierreHojaRuta(_idRuta);
            _status = HojaRutaStatusManager.StatusHeader.Finalizado;
            txtEstadoRuta.Text = _status.ToString();
            t0059HOJARUTAIBindingSource.DataSource = new HojaRutaManager().GetListRemitosEnHojaRuta(_idRuta);
            dgvRemitosHRuta.DataSource = t0059HOJARUTAIBindingSource;
        }
    }
}
