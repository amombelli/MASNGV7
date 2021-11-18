using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MASngFE.Transactional.Cierre;
using MASngFE.Transactional.FI.Vendor.SinRemito;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.IntegridadContable;
using TecserEF.Entity;

namespace MASngFE.Application
{
    public partial class FrmFI78ImportacionComprobantesAFIP : Form
    {
        public FrmFI78ImportacionComprobantesAFIP()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------------------------
        private readonly DataTable _dataImport = new DataTable();
        private DataTable dt = new DataTable();
        private DataView dv = new DataView();

        //---------------------------------------------------------------------------------------------------

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeriodo.Text))
            {
                MessageBox.Show(@"Debe completar el periodo de CIERRE Contable", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_dataImport.Rows.Count > 0)
            {
                var resp = MessageBox.Show(@"Desea eliminar los datos del DataTable antes de continuar?", @"Datos Existente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    _dataImport.Clear();
                    dt.Clear();
                }
            }

            if (!string.IsNullOrEmpty(txtFilename.Text))
            {
                var resp = MessageBox.Show(@"Desea Importar los datos del mismo archivo seleccionado anteriormiente?", @"Datos Existente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    OpenExcelFile(txtFilename.Text, txtSheetName.Text);
                    ImportarConvertirDatosAFIP();
                }
                else
                {
                    OpenFileDialog fdlg = new OpenFileDialog
                    {
                        Title = @"Seleccione el Archivo a Cargar",
                        InitialDirectory = @"c:\",
                        FileName = txtFilename.Text,
                        Filter = @"Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (fdlg.ShowDialog() == DialogResult.OK)
                    {
                        var sheet = "Hoja1";
                        txtFilename.Text = fdlg.FileName;
                        if (!string.IsNullOrEmpty(txtSheetName.Text))
                            sheet = txtSheetName.Text;

                        OpenExcelFile(fdlg.FileName, sheet);
                        ImportarConvertirDatosAFIP();
                    }
                }
            }
            else
            {
                OpenFileDialog fdlg = new OpenFileDialog
                {
                    Title = @"Seleccione el Archivo a Cargar",
                    InitialDirectory = @"c:\",
                    FileName = txtFilename.Text,
                    Filter = @"Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    var sheet = "Hoja1";
                    txtFilename.Text = fdlg.FileName;
                    if (!string.IsNullOrEmpty(txtSheetName.Text))
                        sheet = txtSheetName.Text;

                    OpenExcelFile(fdlg.FileName, sheet);
                    ImportarConvertirDatosAFIP();
                }
            }


        }
        private void OpenExcelFile(string filePath, string sheetName = "Hoja1")
        {
            //Obtenemos el archivo desde la ubicación actual
            var sheetname = sheetName;
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
                    sda.Fill(_dataImport);
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

        private void ImportarConvertirDatosAFIP()
        {
            var numeroRows = _dataImport.Rows.Count;
            var u = _dataImport.Rows[1]["Número desde"].ToString();
            dt.Clear();
            dt.Columns.Clear();

            dt.Columns.Add("Fecha");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Numero");
            dt.Columns.Add("TDOC");
            dt.Columns.Add("NTAX");
            dt.Columns.Add("Denominacion");
            dt.Columns.Add("TC");
            dt.Columns.Add("Mon");
            dt.Columns.Add("Neto Grav");
            dt.Columns.Add("Neto NoGrav");
            dt.Columns.Add("Importe Exento");
            dt.Columns.Add("IVA");
            dt.Columns.Add("Total");
            dt.Columns.Add("Total ARS");
            dt.Columns.Add("Status");

            int i = 0;
            do
            {
                //Convierte formato numero documento
                string suc = _dataImport.Rows[i]["Punto de Venta"].ToString().PadLeft(4, '0');
                string docu = _dataImport.Rows[i]["Número Desde"].ToString().PadLeft(8, '0');
                string doc = suc + "-" + docu;
                //
                decimal tipoCambio = Convert.ToDecimal(_dataImport.Rows[i]["Tipo Cambio"]);
                decimal NetoGrav = 0;
                decimal NetoNoGrav = 0;
                decimal OpExento = 0;
                decimal IVA = 0;
                decimal Total = 0;

                if (!string.IsNullOrEmpty(_dataImport.Rows[i]["Imp# Neto Gravado"].ToString()))
                    NetoGrav = Convert.ToDecimal(_dataImport.Rows[i]["Imp# Neto Gravado"]);

                if (!string.IsNullOrEmpty(_dataImport.Rows[i]["Imp# Neto No Gravado"].ToString()))
                    NetoNoGrav = Convert.ToDecimal(_dataImport.Rows[i]["Imp# Neto No Gravado"]);

                if (!string.IsNullOrEmpty(_dataImport.Rows[i]["Imp# Op# Exentas"].ToString()))
                    OpExento = Convert.ToDecimal(_dataImport.Rows[i]["Imp# Op# Exentas"]);

                if (!string.IsNullOrEmpty(_dataImport.Rows[i]["IVA"].ToString()))
                    IVA = Convert.ToDecimal(_dataImport.Rows[i]["IVA"]);

                if (!string.IsNullOrEmpty(_dataImport.Rows[i]["Imp# Total"].ToString()))
                    Total = Convert.ToDecimal(_dataImport.Rows[i]["Imp# Total"]);

                var row = dt.NewRow();
                {
                    row["Fecha"] = _dataImport.Rows[i]["Fecha"].ToString();
                    row["Tipo"] = _dataImport.Rows[i]["Tipo"].ToString();
                    row["Numero"] = doc;
                    row["TDOC"] = _dataImport.Rows[i]["Tipo Doc# Emisor"].ToString();
                    row["NTAX"] = _dataImport.Rows[i]["Nro# Doc# Emisor"].ToString();
                    row["Denominacion"] = _dataImport.Rows[i]["Denominación Emisor"].ToString();
                    row["TC"] = _dataImport.Rows[i]["Tipo Cambio"].ToString();
                    row["Mon"] = _dataImport.Rows[i]["Moneda"].ToString();
                    row["Neto Grav"] = NetoGrav.ToString("C2");
                    row["Neto NoGrav"] = NetoNoGrav.ToString("C2");
                    row["Importe Exento"] = OpExento.ToString("C2");
                    row["IVA"] = IVA.ToString("C2");
                    row["Total"] = Total.ToString("C2");

                    if (row["Mon"].ToString() == "$")
                    {
                        row["Total ARS"] = Total.ToString("C2");
                    }
                    else
                    {
                        row["Total ARS"] = (Total * tipoCambio).ToString("C2");
                    }
                    row["Status"] = ChequeaInfo(row["NTAX"].ToString(), doc, Convert.ToDateTime(row["Fecha"]));
                }
                dt.Rows.Add(row);
                i++;
            } while (i < _dataImport.Rows.Count);

            var x = dt.Rows.Count;
            dv = new DataView(dt);
            dv.RowFilter = "Status='NoEncontrada'";
            var z = dv.Count;

            if (ckSoloNoEncontrado.Checked)
            {
                dgvImportacion.DataSource = dv;
            }
            else
            {
                dgvImportacion.DataSource = dt;
            }



            if (_dataImport.Rows.Count > 0)
                FormatoDvg();

        }
        private void FormatoDvg()
        {
            for (var a = 0; a < dgvImportacion.Rows.Count; a++)
            {
                if ((string)dgvImportacion.Rows[a].Cells[15].Value == "NoEncontrada")
                {
                    dgvImportacion.Rows[a].Cells[15].Style.ForeColor = Color.Red;
                    dgvImportacion.Rows[a].Cells[15].Style.BackColor = Color.LightBlue;
                }
            }
        }
        private string ChequeaInfo(string cuit, string documento, DateTime fechaDoc)
        {
            var z = new ValidacionFaturasAfip().FacturaContabilizada(cuit, documento, fechaDoc);
            return z == false ? "NoEncontrada" : "FacturaOK";
        }

        private void btnVerOriginal_Click(object sender, EventArgs e)
        {
            var f = new FrmFI70ImportacionOriginal(_dataImport);
            f.Show();
        }

        private void btnVerConta403_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeriodo.Text))
            {
                MessageBox.Show(@"Debe definir primero el periodo de cierre", @"Periodo de Cierre", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var periodo = txtPeriodo.Text;
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas
            t403Bs.DataSource = new VendorConcil(periodo,"L1").GetListaFacturasIngresadasT403().OrderBy(c => c.FECHA).ToList();

            foreach (DataGridViewRow row in dgvT0403.Rows)
            {
                string cuit = row.Cells[pRTAX1DataGridViewTextBoxColumn.Name].Value.ToString();
                string numero = row.Cells[nFACTURADataGridViewTextBoxColumn.Name].Value.ToString();
                decimal importe = Convert.ToDecimal(row.Cells[iMPORIDataGridViewTextBoxColumn.Name].Value);
                DataRow dr =
                    dt.AsEnumerable()
                        .SingleOrDefault(r => r.Field<string>("NTAX") == cuit && r.Field<string>("Numero") == numero);
                if (dr == null)
                {
                    row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.BackColor = Color.LavenderBlush;
                    row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.ForeColor = Color.OrangeRed;

                }
                else
                {
                    if (FormatAndConversions.CCurrencyADecimal(dr["Total ARS"].ToString()) !=
                        Convert.ToDecimal(row.Cells[nETODataGridViewTextBoxColumn.Name].Value))
                    {
                        row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.BackColor = Color.PaleGreen;
                        row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.ForeColor = Color.Tomato;
                    }
                    else
                    {
                        row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.BackColor = Color.PaleGreen;
                        row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.ForeColor = Color.Black;
                    }
                }
            }
        }


        /// <summary>
        /// Arregla un Error de Datos que se genera en T0403 cuando se hacen ND/NC
        /// No registra bien los campos Importe Bruto, y los IVA
        /// </summary>
        private void btnFix403_Click(object sender, EventArgs e)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista403NCD = db.T0403_VENDOR_FACT_H.Where(c => c.TFACTURA.StartsWith("N")).ToList();
                foreach (var it in lista403NCD.Where(x => x.FECHA > DateTime.Today.AddMonths(-9)))
                {
                    if (it.BRUTO == 0)
                    {
                        it.BRUTO = it.SUBTOTAL + it.DTO;
                    }

                    if (it.TOTALIVA > 0)
                    {
                        if ((it.IVA10 + it.IVA21 + it.IVA27) != it.TOTALIVA)
                        {
                            //la suma de IVA no da el importe total de IVA - La diferencia la mando a IVA21
                            it.IVA21 = it.TOTALIVA - it.IVA27 - it.IVA10;
                        }
                    }

                    it.NETO = it.IMPORI;

                    db.SaveChanges();
                }
            }
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var CUIT = datagridview[datagridview.Columns["NTAX"].Index, e.RowIndex].Value.ToString();
            var numeroDocumento = datagridview[datagridview.Columns["Numero"].Index, e.RowIndex].Value.ToString();

            var cuit = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var importeTotal = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Neto Grav"].Index, e.RowIndex].Value.ToString());
            var dataX = datagridview[datagridview.Columns["Neto Grav"].Index, e.RowIndex].Value.ToString();

            var fecha = Convert.ToDateTime(datagridview[datagridview.Columns["Fecha"].Index, e.RowIndex].Value.ToString());
            var _tipoDocumento = datagridview[datagridview.Columns["Tipo"].Index, e.RowIndex].Value.ToString();
            decimal _TotalARS = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Total ARS"].Index, e.RowIndex].Value.ToString());
            decimal _TotalOrigen = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Total"].Index, e.RowIndex].Value.ToString());
            decimal _IVA = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["IVA"].Index, e.RowIndex].Value.ToString());
            decimal _Exento = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Importe Exento"].Index, e.RowIndex].Value.ToString());
            var _moneda = datagridview[datagridview.Columns["Mon"].Index, e.RowIndex].Value.ToString();
            decimal _tc = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["TC"].Index, e.RowIndex].Value.ToString());
            decimal _netoGrav = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Neto Grav"].Index, e.RowIndex].Value.ToString());
            decimal _netoNoGrav = FormatAndConversions.CCurrencyADecimal(datagridview[datagridview.Columns["Neto NoGrav"].Index, e.RowIndex].Value.ToString());
            //dt.Columns.Add("TDOC");
            //dt.Columns.Add("NTAX");
            //dt.Columns.Add("Status");

            if (_moneda == "$")
            {
                _moneda = "ARS";
                _tc = new ExchangeRateManager().GetExchangeRate(fecha);

            }


            switch (cellValue)
            {
                case "AutoADD":
                    Cursor.Current = Cursors.WaitCursor;
                    //var f0 = new FrmFI16VendorContaSinRemito(CUIT, numeroDocumento, fecha, importeTotal, 5);
                    //f0.Show();


                    var f1 = new FrmFI18IngresoFacturasInterfaz(CUIT, _tipoDocumento, numeroDocumento, fecha, _moneda,
                        _tc, _netoGrav, _netoNoGrav, _IVA, _Exento, _TotalARS);
                    f1.Show();
                    Cursor.Current = Cursors.Default;
                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void FrmFI78ImportacionComprobantesAFIP_Load(object sender, EventArgs e)
        {

        }

        private void CkSoloNoEncontrado_CheckedChanged(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (ckSoloNoEncontrado.Checked)
                {
                    dgvImportacion.DataSource = dv;
                }
                else
                {
                    dgvImportacion.DataSource = dt;
                }



                if (_dataImport.Rows.Count > 0)
                    FormatoDvg();
            }
        }

        private void DgvT0403_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
