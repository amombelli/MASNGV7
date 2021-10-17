using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;
using TextBox = System.Windows.Forms.TextBox;

namespace MASngFE.Transactional.HR
{
    /// <summary>
    /// ABM de HHRR Personal
    /// Version nueva 2021.03.21
    /// </summary>

    public partial class FrmHr03PersonalABMMain : Form
    {
        private int _modo;
        private string _shortname;

        public FrmHr03PersonalABMMain(int modo = 1, string shortname = null)
        {
            _modo = modo;
            _shortname = shortname;
            InitializeComponent();
        }

        private void FrmHR03_PersonalABMMain_Load(object sender, EventArgs e)
        {
            posicionesBs.DataSource = HrPosicionesManagement.GetPosiciones();
            cmbPosicion.SelectedIndex = -1;
            cmbBanco.SelectedIndex = -1;
            LoadGLAccountsPrefix();
            ConfiguraSegunModo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaGrabar())
                return;
            new HrMasterManagement().SaveBasicData(MapBasicData());
            if (_modo == 1)
                _shortname = txtShortname.Text.ToUpper();
            HrMasterManagement.UpdateCreateDatosPersonales(_shortname, cmbBanco.Text, txtNumeroCuenta.Text, txtDireccion.Text, txtBarrio.Text, txtLocalidad_.Text, txtCodigoPostal.Text, txtemail.Text, ctlFechaNacimiento.Value, txtTelefono1.Text, txtTelefono2.Text);
            HrDisponibilidadYPermisos.SetRegistroPermiso(_shortname, ckPventa.Checked, ckPDespacho.Checked,
                ckPCq.Checked, ckPoperario.Checked, ckPCobranza.Checked, ckPIngresoIc.Checked, ckPVendedor.Checked,
                ckPAutorizaSC.Checked);

            if (_modo == 1)
            {
                _shortname = txtShortname.Text.ToUpper();
                CreaGLAccounts();

                MessageBox.Show(@"Se ha Creado Correctamente el Registro en el Sistema", @"Operacion Completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _modo = 2;
            }
            else
            {
                MessageBox.Show(@"Se han Actualizado Correctamente los Datos", @"Operacion Completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ConfiguraSegunModo();
            }
        }
        private bool ValidaGrabar()
        {
            if (string.IsNullOrEmpty(txtShortname.Text))
            {
                MessageBox.Show(@"Debe proveer un shortname", @"Error en Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_modo == 1)
            {
                if (HrMasterManagement.ExisteShortname(txtShortname.Text))
                {
                    MessageBox.Show(@"El Shortname Ingresado Ya Existe", @"Error en Validacion de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                MessageBox.Show(@"Debe proveer un Nombre de Empleado", @"Error en Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show(@"Debe proveer un Apellido de Empleado", @"Error en Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //if (txtSubfix.GetValueDecimal == 0)
            //{
            //    MessageBox.Show(@"Debe proveer un GL (Subfix)", @"Error en Validacion de Datos", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return false;
            //}

            if (_modo == 1)
            {
                if (!string.IsNullOrEmpty(txtGlSubfix.Text))
                {
                    if (HrMasterManagement.ExisteGL(Convert.ToInt32(txtGlSubfix.Text)))
                    {
                        MessageBox.Show(@"Debe proveer un GL Diferente", @"Error en Validacion de Datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        public void RecargaValoresPosicion()
        {
            if (cmbPosicion.SelectedIndex == -1)
            {
                txtIdPosicion.Text = null;
                txtValorHora.Text = 0.ToString("C2");
                txtValorMensual.Text = 0.ToString("C2");
                txtPresentismo.Text = 0.ToString("C2");
                txtOtrasSumasSindicato.Text = 0.ToString("C2");
            }
            else
            {
                txtIdPosicion.Text = cmbPosicion.SelectedValue.ToString();
                var pos = HrPosicionesManagement.GetPosicion(Convert.ToInt32(cmbPosicion.SelectedValue));
                if (pos != null)
                {
                    txtValorHora.Text = pos.ValorHora.ToString("C2");
                    txtValorMensual.Text = pos.ValorMensual.ToString("C2");
                    txtPresentismo.Text = pos.AdicionalPresentismo.ToString("C2");
                    txtOtrasSumasSindicato.Text = pos.AdicionalBono1.ToString("C2");
                    ckConvenio.Checked = pos.EnConvenio;
                }
                else
                {
                    txtValorHora.Text = 0.ToString("C2");
                    txtValorMensual.Text = 0.ToString("C2");
                    txtPresentismo.Text = 0.ToString("C2");
                    txtOtrasSumasSindicato.Text = 0.ToString("C2");
                }
            }
        }
        private void cmbPosicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecargaValoresPosicion();
        }

        private void LoadDataFromDb()
        {
            var data = HrMasterManagement.GetBasicData(_shortname);
            var personalData = HrMasterManagement.GetDatosPersonales(_shortname);
            if (data == null)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Cargar los Datos", @"Error de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            txtShortname.Text = data.Shortname;
            txtNombres.Text = data.Nombre;
            txtApellido.Text = data.Apellidos;
            txtLegajoRaffone.Text = data.LegajoRaf;
            txtGlSubfix.Text = data.GLSubfix.ToString();
            ckActivo.Checked = data.Activo;

            if (data.Foto != null)
                pictureEmpl.Image = new ImageManager().ConvertByteToImage(data.Foto);

            if (data.Documento != null)
                txtDni.Text = data.Documento.ToString();

            txtCuil.Text = data.CUIL;

            //Tab Permisos
            if (HrDisponibilidadYPermisos.GetRegistroPermisosCompletos(_shortname) == null)
            {
                ckPventa.Checked = false;
                ckPDespacho.Checked = false;
                ckPCq.Checked = false;
                ckPoperario.Checked = false;
                ckPCobranza.Checked = false;
                ckPIngresoIc.Checked = false;
                ckPVendedor.Checked = false;
                ckPAutorizaSC.Checked = false;
            }
            else
            {
                var permiso = HrDisponibilidadYPermisos.GetRegistroPermisosCompletos(_shortname);
                ckPventa.Checked = permiso.Venta;
                ckPDespacho.Checked = permiso.Despacho;
                ckPCq.Checked = permiso.ControlCalidad;
                ckPoperario.Checked = permiso.Operario;
                ckPCobranza.Checked = permiso.Cobranza;
                ckPIngresoIc.Checked = permiso.IngresoIC;
                ckPVendedor.Checked = permiso.Vendedor;
                ckPAutorizaSC.Checked = permiso.AutorizaSinCargo;
            }

            //Tab SYJ Posicion
            if (data.PosicionID == null)
            {
                cmbPosicion.SelectedIndex = -1;
                txtValorMensual.Text = 0.ToString("C2");
                txtPresentismo.Text = 0.ToString("C2");
                txtOtrasSumasSindicato.Text = 0.ToString("C2");
                ckConvenio.Checked = false;
            }
            else
            {
                cmbPosicion.SelectedValue = data.PosicionID.Value;
                var pos = HrPosicionesManagement.GetPosicion(data.PosicionID.Value);
                txtValorHora.Text = pos.ValorHora.ToString("C2");
                txtValorMensual.Text = pos.ValorMensual.ToString("C2");
                txtPresentismo.Text = pos.AdicionalPresentismo.ToString("C2");
                txtOtrasSumasSindicato.Text = pos.AdicionalBono1.ToString("C2");
                ckConvenio.Checked = pos.EnConvenio;
            }

            ckMensual.Checked = data.BitMensual;
            ckQuincena.Checked = data.BitQuincena;
            GLAP.Text = data.GLAP;
            if (!string.IsNullOrEmpty(GLAP.Text))
            {
                if (GLAP.Text == @"2.0.2.1")
                {
                    cmbGLAP.SelectedItem = "SYJ - Empleados";
                }
                else
                {
                    if (GLAP.Text == @"2.0.2.2")
                    {
                        cmbGLAP.SelectedItem = "SYJ - Direccion";
                    }
                    else
                    {
                        MessageBox.Show(@"Error en la definicion de GLAP - Pago SYJ", @"Error en GLAP",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            txtBonoAdicionalEmpleado.Text = data.SumaExtra.ToString("C2");

            if (_modo == 2)
            {
                txtGlSubfix.Enabled = string.IsNullOrEmpty(txtGlSubfix.Text);
            }

            if (personalData != null)
            {
                cmbBanco.SelectedValue = personalData.Banco;
                txtBancoId.Text = personalData.Banco;
                txtNumeroCuenta.Text = personalData.Cuenta;
                //Tab Datos Personales
                txtDireccion.Text = personalData.DireccionCalle;
                txtLocalidad_.Text = personalData.DireccionLocalidad;
                txtBarrio.Text = personalData.DireccionBarrio;
                txtCodigoPostal.Text = personalData.DireccionCodPostal;
                txtTelefono1.Text = personalData.Telefono1;
                txtTelefono2.Text = personalData.Telefono2;
                txtemail.Text = personalData.EmailPersonal;
                ctlFechaNacimiento.Value = personalData.FechaNacimiento;
            }
        }

        private void ConfiguraSegunModo()
        {
            //disbled all buttons
            txtShortname.ReadOnly = true;
            btnGrabar.Enabled = false;
            btnUpdGL.Enabled = false;
            switch (_modo)
            {
                case 1:
                    txtShortname.ReadOnly = false;
                    btnGrabar.Enabled = true;
                    btnUpdGL.Enabled = true;
                    EnableGLInfo(true);
                    txtGlSubfix.Enabled = true;
                    break;
                case 2:
                    btnGrabar.Enabled = true;
                    btnUpdGL.Enabled = true;
                    LoadDataFromDb();
                    EnableGLInfo(true);
                    CompletaGLInfo();
                    break;
                case 3:
                    LoadDataFromDb();
                    EnableGLInfo(false);
                    txtGlSubfix.Enabled = false;
                    break;

                default:
                    break;

            }
        }

        private void cmbGLAP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLAP.SelectedItem == null)
            {
                GLAP.Text = null;
            }
            else
            {
                if (cmbGLAP.SelectedItem.ToString() == "SYJ - Empleados")
                {
                    GLAP.Text = @"2.0.2.1";
                }

                if (cmbGLAP.SelectedItem.ToString() == "SYJ - Direccion")
                {
                    GLAP.Text = @"2.0.2.2";
                }
            }
        }

        private void txtShortname_Validating(object sender, CancelEventArgs e)
        {
            if (_modo != 1)
                return;
            var txt = (TextBox)sender;
            if (HrMasterManagement.ExisteShortname(txt.Text))
            {
                MessageBox.Show(@"El Shortname Ingresado Ya Existe - Debe Modificarlo", @"Error en Shortname",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
        private T0085_HHRR_PERSONAL_BASIC MapBasicData()
        {
            var stx = new T0085_HHRR_PERSONAL_BASIC()
            {
                BitMensual = ckMensual.Checked,
                BitQuincena = ckQuincena.Checked,
                Activo = ckActivo.Checked,
                Apellidos = txtApellido.Text,
                Nombre = txtNombres.Text,
                Shortname = txtShortname.Text.ToUpper(),
                CUIL = txtCuil.Text,
                GLAP = GLAP.Text,
                GLSubfix = string.IsNullOrEmpty(txtGlSubfix.Text) ? null : (int?)Convert.ToInt32(txtGlSubfix.Text),
                Documento = string.IsNullOrEmpty(txtDni.Text) ? null : (decimal?)Convert.ToDecimal(txtDni.Text),
                PosicionID = string.IsNullOrEmpty(txtIdPosicion.Text) ? null : (int?)Convert.ToInt32(txtIdPosicion.Text),
                LegajoRaf = txtLegajoRaffone.Text,
                VendorId = string.IsNullOrEmpty(txtVendorId.Text) ? null : (int?)Convert.ToInt32(txtVendorId.Text),
                SumaExtra = FormatAndConversions.CCurrencyADecimal(txtBonoAdicionalEmpleado.Text)
            };
            if (pictureEmpl.ImageLocation != null)
            {
                stx.Foto = new ImageManager().ConvertFiltoByte(pictureEmpl.ImageLocation);
            }
            else
            {
                pictureEmpl.Image = pictureEmpl.Image;
            }
            return stx;
        }
        private void txtVendorId_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void btnUpdGL_Click(object sender, EventArgs e)
        {
            CreaGLAccounts();
        }

        /// <summary>
        /// Carga los Prefijox en el TextBox de la cuenta GL correspondiente
        /// </summary>
        private void LoadGLAccountsPrefix()
        {
            txtGlSueldo.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Salario);
            txtGlVacaciones.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Vacaciones);
            txtGlSac.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.SAC);
            txtGlHHEE.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.HoraExtra);
            txtGlBonificaciones.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Bonos);
            txtGlPrestamos.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Prestamo);
            txtGlViatico.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Viaticos);
            txtGlHonorario.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Honorarios);
            txtGlComisiones.Text = SyJConceptos.ReturnGL(SyJConceptos.HrConceptos.Comisiones);
            //
        }

        private void GeneraColorCuentaGL(TextBox t)
        {
            if (t.Text == @"Cuenta Inexistente")
            {
                t.BackColor = Color.Orange;
                t.ForeColor = Color.Red;
            }
            else
            {
                t.BackColor = Color.LightBlue;
                t.ForeColor = Color.DarkBlue;
            }
        }


        /// <summary>
        /// Creacion de cuentas GL de Empleados para SYJ segun prefijo
        /// </summary> 
        private void CreaGLAccounts()
        {
            if (_modo > 2)
                return;
            if (string.IsNullOrEmpty(txtGlSubfix.Text))
                return;

            if (ckSueldo.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlSueldo.Text + txtGlSubfix.Text, "Sueldo - " + _shortname);

            if (ckVacaciones.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlVacaciones.Text + txtGlSubfix.Text, "Vacaciones - " + _shortname);

            if (ckSac.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlSac.Text + txtGlSubfix.Text, "SAC - " + _shortname);

            if (ckHHEE.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlHHEE.Text + txtGlSubfix.Text, "HHEE - " + _shortname);

            if (ckBonificaciones.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlBonificaciones.Text + txtGlSubfix.Text, "Bonificacion - " + _shortname);

            if (ckPrestamos.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlPrestamos.Text + txtGlSubfix.Text, "Prestamos y Dev - " + _shortname);

            if (ckViatico.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlViatico.Text + txtGlSubfix.Text, "Viaticos y Retornos - " + _shortname);

            if (ckHonorario.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlHonorario.Text + txtGlSubfix.Text, "Honorario y Div - " + _shortname);

            if (ckComisiones.Checked)
                HrMasterManagement.CreateGLAccountsForEmployees(_shortname, txtGlComisiones.Text + txtGlSubfix.Text, "Comisiones - " + _shortname);
            CompletaGLInfo();
        }
        private void EnableGLInfo(bool enable)
        {
            txtDescSueldo.ReadOnly = !enable;
            txtDescVacaciones.ReadOnly = !enable;
            txtDescSac.ReadOnly = !enable;
            txtDescHHEE.ReadOnly = !enable;
            txtDescBonos.ReadOnly = !enable;
            txtDescPrestamos.ReadOnly = !enable;
            txtDescViatico.ReadOnly = !enable;
            txtGlHonorario.ReadOnly = !enable;
            txtGlComisiones.ReadOnly = !enable;
            //
            ckSueldo.AutoCheck = enable;
            ckVacaciones.AutoCheck = enable;
            ckSac.AutoCheck = enable;
            ckHHEE.AutoCheck = enable;
            ckBonificaciones.AutoCheck = enable;
            ckPrestamos.AutoCheck = enable;
            ckViatico.AutoCheck = enable;
            ckHonorario.AutoCheck = enable;
            ckComisiones.AutoCheck = enable;
            //

        }
        private void CompletaGLInfo()
        {
            if (string.IsNullOrEmpty(txtGlSubfix.Text))
            {
                txtDescSueldo.Text = null;
                txtDescVacaciones.Text = null;
                txtDescSac.Text = null;
                txtDescHHEE.Text = null;
                txtDescBonos.Text = null;
                txtDescPrestamos.Text = null;
                txtDescViatico.Text = null;
                txtDescHonorario.Text = null;
                txtDescComisiones.Text = null;

                ckSueldo.Checked = false;
                ckVacaciones.Checked = false;
                ckSac.Checked = false;
                ckHHEE.Checked = false;
                ckBonificaciones.Checked = false;
                ckPrestamos.Checked = false;
                ckViatico.Checked = false;
                ckHonorario.Checked = false;
                ckComisiones.Checked = false;
                return;
            }

            int glsub = Convert.ToInt32(txtGlSubfix.Text);
            if (glsub > 0)
            {
                txtDescSueldo.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlSueldo.Text + glsub.ToString());
                ckeSueldo.Checked = txtDescSueldo.Text != @"Cuenta Inexistente";

                txtDescVacaciones.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlVacaciones.Text + glsub.ToString());
                ckeVac.Checked = txtDescVacaciones.Text != @"Cuenta Inexistente";

                txtDescSac.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlSac.Text + glsub.ToString());
                ckeSac.Checked = txtDescSac.Text != @"Cuenta Inexistente";

                txtDescHHEE.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlHHEE.Text + glsub.ToString());
                ckeHHEE.Checked = txtDescHHEE.Text != @"Cuenta Inexistente";

                txtDescBonos.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlBonificaciones.Text + glsub.ToString());
                ckeBono.Checked = txtDescBonos.Text != @"Cuenta Inexistente";

                txtDescPrestamos.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlPrestamos.Text + glsub.ToString());
                ckePrestamo.Checked = txtDescPrestamos.Text != @"Cuenta Inexistente";

                txtDescViatico.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlViatico.Text + glsub.ToString());
                ckeViatico.Checked = txtDescViatico.Text != @"Cuenta Inexistente";

                txtDescHonorario.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlHonorario.Text + glsub.ToString());
                ckeHonorario.Checked = txtDescHonorario.Text != @"Cuenta Inexistente";

                txtDescComisiones.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlComisiones.Text + glsub.ToString());
                ckeComisiones.Checked = txtDescComisiones.Text != @"Cuenta Inexistente";
            }

            if (ckeSueldo.Checked)
            {
                ckSueldo.Checked = false;
                ckSueldo.AutoCheck = false;
            }
            else
            {
                ckSueldo.AutoCheck = true;
            }

            if (ckeVac.Checked)
            {
                ckVacaciones.Checked = false;
                ckVacaciones.AutoCheck = false;
            }
            else
            {
                ckVacaciones.AutoCheck = true;
            }

            if (ckeSac.Checked)
            {
                ckSac.Checked = false;
                ckSac.AutoCheck = false;
            }
            else
            {
                ckSac.AutoCheck = true;
            }

            if (ckeHHEE.Checked)
            {
                ckHHEE.Checked = false;
                ckHHEE.AutoCheck = false;
            }
            else
            {
                ckHHEE.AutoCheck = true;
            }

            if (ckeBono.Checked)
            {
                ckBonificaciones.Checked = false;
                ckBonificaciones.AutoCheck = false;
            }
            else
            {
                ckBonificaciones.AutoCheck = true;
            }

            if (ckePrestamo.Checked)
            {
                ckPrestamos.Checked = false;
                ckPrestamos.AutoCheck = false;
            }
            else
            {
                ckPrestamos.AutoCheck = true;
            }

            if (ckeViatico.Checked)
            {
                ckViatico.Checked = false;
                ckViatico.AutoCheck = false;
            }
            else
            {
                ckViatico.AutoCheck = true;
            }

            if (ckeHonorario.Checked)
            {
                ckHonorario.Checked = false;
                ckHonorario.AutoCheck = false;
            }
            else
            {
                ckHonorario.AutoCheck = true;
            }

            if (ckeComisiones.Checked)
            {
                ckComisiones.Checked = false;
                ckComisiones.AutoCheck = false;
            }
            else
            {
                ckComisiones.AutoCheck = true;
            }

            GeneraColorCuentaGL(txtDescSueldo);
            GeneraColorCuentaGL(txtDescVacaciones);
            GeneraColorCuentaGL(txtDescSac);
            GeneraColorCuentaGL(txtDescHHEE);
            GeneraColorCuentaGL(txtDescBonos);
            GeneraColorCuentaGL(txtDescPrestamos);
            GeneraColorCuentaGL(txtDescViatico);
            GeneraColorCuentaGL(txtDescHonorario);
            GeneraColorCuentaGL(txtGlComisiones);
        }
        private void txtGlSubfix_Validating(object sender, CancelEventArgs e)
        {
            if (_modo != 1)
                return;
        }
        private void tbSyJ_Click(object sender, EventArgs e)
        {

        }
        private void txtBonoAdicionalEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, allowSignoMoneda: true);
        }
        private void txtBonoAdicionalEmpleado_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBonoAdicionalEmpleado.Text))
                txtBonoAdicionalEmpleado.Text = @"0";

            decimal valor = FormatAndConversions.CCurrencyADecimal(txtBonoAdicionalEmpleado.Text);
            txtBonoAdicionalEmpleado.Text = valor.ToString("C2");
        }
        private void cmbGLAP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbGLAP.SelectedItem == null)
            {
                GLAP.Text = null;
            }
            else
            {
                if (cmbGLAP.SelectedItem.ToString() == "SYJ - Empleados")
                {
                    GLAP.Text = @"2.0.2.1";
                }

                if (cmbGLAP.SelectedItem.ToString() == "SYJ - Direccion")
                {
                    GLAP.Text = @"2.0.2.2";
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog
            {
                Title = @"Seleccione Foto de Empleado",
                Filter = @"JPG|*.jpg|PNG|*.png|GIF|*.gif|BMP|*.bmp",
                Multiselect = false
            };

            if (pic.ShowDialog() == DialogResult.OK)
            {
                this.pictureEmpl.ImageLocation = pic.FileName;
            }
        }

        private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBanco.SelectedIndex == -1)
            {
                txtBancoId.Text = null;
            }
            else
            {
                txtBancoId.Text = cmbBanco.SelectedValue.ToString();
            }
        }

        private void btnDeleteFoto_Click(object sender, EventArgs e)
        {
            pictureEmpl.Image = null;
        }

        private void btnPosiciones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPosicion.Text))
            {
                MessageBox.Show(@"Debe Seleccionar una Posicion para Administrarla", @"Adminsitracion de Posiciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            using (var f = new FrmHr05PosicionMaintain(1, Convert.ToInt32(txtIdPosicion.Text)))
            {
                f.ShowDialog();
                if (f.DialogResult == DialogResult.Yes)
                {
                    RecargaValoresPosicion();
                }
                else
                {

                }
                RecargaValoresPosicion();
            }
        }
    }
}
