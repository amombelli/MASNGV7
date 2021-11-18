using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Properties;
using Tecser.Business.MainApp;
using Tecser.Business.Security;

namespace MASngFE.Application
{
    public partial class FrmStartAppLogin : Form
    {
        public FrmStartAppLogin()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------
        private int _pswError = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            //Centrar el Panel
            Size desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

            //Captura el Tamaño del Monitor
            Int32 alto = (desktopSize.Height - 280) / 2;
            Int32 ancho = (desktopSize.Width - 500) / 2;
            panel1.Location = new Point(ancho, alto);

            //Mostrar Fecha y Hora
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
            txtuser.Text = Environment.UserName;
            txtpass.Text = @"TECSERAPPIN";

            GlobalApp.AppVersion = AppVersionManager.GetAppVersion();

            var modo = Settings.Default.AppMode;
            switch (modo)
            {
                case 'D':
                    GlobalApp.Modo = Tecser.Business.MainApp.ModoApp.Desarrollo;
                    break;
                case 'P':
                    GlobalApp.Modo = Tecser.Business.MainApp.ModoApp.Produccion;
                    break;
                case 'G':
                    GlobalApp.Modo = ModoApp.Desarrollo2;
                    break;
                case 'T':
                    GlobalApp.Modo = ModoApp.Testeo;
                    break;
                default:
                    MessageBox.Show($@"El Modo de Ejecucion {modo} es Incorrecto. No se puede continuar", @"Modo de Ejecucion Incorrecto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            var dataDb = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var conexionApp = dataDb.ConnectionStrings.ConnectionStrings["TecserData"].ConnectionString;
            var conexionSec = dataDb.ConnectionStrings.ConnectionStrings["TecserDataS"].ConnectionString;
            var ecsBuilderApp = new EntityConnectionStringBuilder(conexionApp);
            var ecsBuilderSec = new EntityConnectionStringBuilder(conexionSec);
            SqlConnectionStringBuilder sqlBuilderApp;
            SqlConnectionStringBuilder sqlBuilderSec;
            switch (GlobalApp.Modo)
            {
                case ModoApp.Produccion:
                    sqlBuilderApp = new SqlConnectionStringBuilder(ecsBuilderApp.ProviderConnectionString)
                    {
                        DataSource = "TS2\\TECSER",
                        Password = "andrews555",
                    };
                    ecsBuilderApp.ProviderConnectionString = sqlBuilderApp.ToString();
                    sqlBuilderSec = new SqlConnectionStringBuilder(ecsBuilderSec.ProviderConnectionString)
                    {
                        DataSource = "TS2\\TECSER",
                        Password = "andrews555",
                    };
                    ecsBuilderSec.ProviderConnectionString = sqlBuilderSec.ToString();
                    GlobalApp.CnnApp = ecsBuilderApp.ToString();
                    GlobalApp.CnnSec = ecsBuilderSec.ToString();
                    break;
                case ModoApp.Desarrollo:
                    //Para modo desarrollo utilizar el siguiente nombre de equipo/pass
                    sqlBuilderApp = new SqlConnectionStringBuilder(ecsBuilderApp.ProviderConnectionString)
                    {
                        DataSource = "ANDREWS2",
                        Password = "Andrews555",
                    };
                    ecsBuilderApp.ProviderConnectionString = sqlBuilderApp.ToString();

                    sqlBuilderSec = new SqlConnectionStringBuilder(ecsBuilderSec.ProviderConnectionString)
                    {
                        DataSource = "ANDREWS2",
                        Password = "Andrews555",
                    };
                    ecsBuilderSec.ProviderConnectionString = sqlBuilderSec.ToString();

                    //Se toman los datos default del Config.APP
                    GlobalApp.CnnApp = ecsBuilderApp.ToString();
                    GlobalApp.CnnSec = ecsBuilderSec.ToString();

                    break;
                case ModoApp.Testeo:
                    //
                    break;
                case ModoApp.Desarrollo2:
                    //modo desarrollo notebook AERO
                    sqlBuilderApp = new SqlConnectionStringBuilder(ecsBuilderApp.ProviderConnectionString)
                    {
                        DataSource = "ANDRES_GB\\SQLSERVERGB",
                        Password = "Andrews555",
                    };
                    ecsBuilderApp.ProviderConnectionString = sqlBuilderApp.ToString();

                    sqlBuilderSec = new SqlConnectionStringBuilder(ecsBuilderSec.ProviderConnectionString)
                    {
                        DataSource = "ANDRES_GB\\SQLSERVERGB",
                        Password = "Andrews555",
                    };
                    ecsBuilderSec.ProviderConnectionString = sqlBuilderSec.ToString();

                    //Se toman los datos default del Config.APP
                    GlobalApp.CnnApp = ecsBuilderApp.ToString();
                    GlobalApp.CnnSec = ecsBuilderSec.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "")
            {
                MessageBox.Show(@"Nombre de Usuario Invalido", @"Error de Acceso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtuser.Focus();
            }
            else if (txtpass.Text.Trim() == "")
            {
                MessageBox.Show(@"Contraseña Invalida", @"Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
            }
            else
            {
                if (txtuser.Text != Environment.UserName)
                {
                    //Se cambio el nombre de acceso - Se valida User/Contraseña
                    if (TsSecurityMng.CheckUsernamePasswordOK(txtuser.Text, txtpass.Text))
                    {
                        //Usuario validado
                        GlobalApp.AppUsername = txtuser.Text;
                    }
                    else
                    {
                        _pswError++;
                        MessageBox.Show(@"Usuario o Password incorrecta", @"Error en Acceso", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        if (_pswError == 3)
                        {
                            this.Close();
                        }
                        return;
                    }
                }
                else
                {
                    //usuario > ad user
                    GlobalApp.AppUsername = Environment.UserName;
                }


                if (!new SecurityAppVersion().IsAppVersionApprovedToRun())
                {
                    MessageBox.Show(
                        @"Esta version de aplicacion no puede ser ejecutada hasta que no se obtenga la proxima version",
                        @"Version Incompatible",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SecurityLog.LogSecurityAccess("APP",
                        $"Version {GlobalApp.AppVersion} Incompatible");
                    this.Close();
                }


                if (TsSecurityMng.CheckUserCanRunApplication() == false)
                {
                    MessageBox.Show($"El Usuario {Environment.UserName} no tiene permiso para utilizar la aplicacion",
                        @"Chequeo de Permisos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    SecurityLog.LogSecurityAccess("APP", $"Sin Acceso - Usuario no Permitido - AppVersion {GlobalApp.AppVersion}");
                    this.Close();
                }
                else
                {
                    SecurityLog.LogSecurityAccess("APP", $"Acceso a Aplicacion - Usuario Habilitado - AppVersion {GlobalApp.AppVersion}");
                }
                this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                this.Hide();
                var f = new Frm00MainAppStart();
                f.Show();
                GlobalApp.MainForm = new Frm00MainAppStart();
            }
        }
        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(@"Confirma la Salidad del Sistema?", @"◄ TecserMasterbatch APP ►",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Actualizar cada segundo la Hora
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            btnIngresar.Size = new Size(50, 54);
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackgroundImageLayout = ImageLayout.Stretch;
            btnIngresar.Size = new Size(43, 39);
        }
    }
}

