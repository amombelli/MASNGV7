using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace MASngFE.Application
{
    public partial class FrmForm1 : Form
    {
        public FrmForm1()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------------------------
        private DataTable data = new DataTable();
        //---------------------------------------------------------------------------------------------------
        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = @"Seleccione el Archivo a Cargar";
            fdlg.InitialDirectory = @"c:\";
            fdlg.FileName = txtFilename.Text;
            fdlg.Filter = @"Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = fdlg.FileName;
                OpenExcelFile(fdlg.FileName);
            }
        }
        private void OpenExcelFile(string filePath)
        {
            //Obtenemos el archivo desde la ubicación actual
            var sheetname = "Hoja1";
            var executableFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilename.Text +
                              ";Extended Properties='Excel 8.0;HDR=YES;';";

            using (OleDbConnection con = new OleDbConnection(conexion))
            {
                OleDbCommand cmd = new OleDbCommand("Select * From [" + sheetname + "$]", con);
                //Consulta contra la hoja de Excel
                try
                {
                    //Conectarse al archivo de Excel
                    con.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(data);
                    dgv1.DataSource = data;
                }
                catch
                {
                    //Error leyendo excel
                    MessageBox.Show(@"Ocurrió un error en la lectura del archivo");
                }
                finally
                {
                    //Funcione o no, cerramos la cadena de conexión
                    con.Close();
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            var z = data.Rows.Count;
            var u = data.Rows[1]["N_EMIS"].ToString();
            int i = 0;
            do
            {
                string suc = data.Rows[i]["N_SUC"].ToString().PadLeft(4, '0');
                string docu = data.Rows[i]["N_EMIS"].ToString().PadLeft(8, '0');
                string doc = suc + "-" + docu;
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var dPer = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.NumFactura == doc);
                    if (dPer != null)
                    {
                        dPer.Informado = true;
                    }
                    db.SaveChanges();
                }
                i++;
            } while (i < data.Rows.Count);
            MessageBox.Show(@"Emine!");

        }
    }
}
