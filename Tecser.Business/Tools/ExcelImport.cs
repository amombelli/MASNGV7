using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class ExcelImport
    {

        public ExcelImport(bool autoImport = false, string sheetName = "Hoja1")
        {
            Data = new DataTable();
            _autoImport = autoImport;
            SheetName = sheetName;
            if (_autoImport)
            {
                SelectFileToImport(SheetName);
            }
        }

        //--------------------------------------------------------------------------------------------
        public string FileName { get; private set; }
        public string SheetName { get; private set; }
        public DataTable Data { get; private set; }

        private readonly bool _autoImport;
        //--------------------------------------------------------------------------------------------
        public void SelectFileToImport(string sheetname)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = @"Seleccione el Archivo a Importar";
            fdlg.InitialDirectory = @"c:\";
            //fdlg.FileName = txtFilename.Text;
            fdlg.Filter = @"Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                FileName = fdlg.FileName;
            }
            else
            {
                FileName = null;
            }
            if (_autoImport)
            {
                SheetName = sheetname;
                if (string.IsNullOrEmpty(FileName))
                {
                    MessageBox.Show(@"No se puede Importar el Archivo porque no se ha seleccionado ningun archivo",
                        @"Error en Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadExcelFile(FileName, SheetName);
            }
        }

        public bool LoadExcelFile(string filePath, string sheetname = "Sheet1")
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            if (File.Exists(filePath) == false)
                return false;

            var executableFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
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
                    sda.Fill(Data);
                }
                catch
                {
                    //Error leyendo excel
                    MessageBox.Show(@"Ocurrió un error en la lectura del archivo");
                    return false;
                }
                finally
                {
                    //Funcione o no, cerramos la cadena de conexión
                    con.Close();
                }
                return true;
            }
        }
    }
}

