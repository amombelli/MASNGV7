using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Brushes = System.Windows.Media.Brushes;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO02_Reposicion : Form
    {
        public FrmCO02_Reposicion()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO01", "CO01"))
                return;
            InitializeComponent();
            _material = null;
        }
        public FrmCO02_Reposicion(string material)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO01", "CO01"))
                return;
            InitializeComponent();
            _material = material;
        }

        private string _material;
        private ACostoRepo _costoRepo;
        private ACostoStandard _costoStd;

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCO02_Reposicion_Load(object sender, EventArgs e)
        {
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetCompraMaterialList(false);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            tc.SetValue = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            txtRecordsUc.SetValue = 50;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            if (_material != null)
            {
                cmbMaterial.SelectedItem = _material;
            }

            //gr1.AxisX.Add(new Axis
            //{
            //    Title = "Fecha",
            //    //Labels = new[] {"01", "02","03","04","05","06","07","08","09","10","11","12"}
            //});

            gr1.AxisY.Add(new Axis
            {
                Title = "Costo USD",
                //Labels = new[] {"", ""}
            });
            gr1.LegendLocation = LiveCharts.LegendLocation.Right;


        }


        private void CargaHistoData()
        {
            var rtn = new RepoHistoryManager().PopulateTable(_material, (int)txtRecordsUc.GetValueDecimal);
            if (rtn != 0)
            {
                MessageBox.Show($@"Se han Agregado a la Tabla Historia {rtn} registros!", @"Alta de Registros",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var listaDatosHistoricos = new RepoHistoryManager().GetData(_material);
            t0039REPOHISTORYBindingSource.DataSource = listaDatosHistoricos;

            //Configuracion de Grafico
            SeriesCollection x = new SeriesCollection();
            gr1.Series.Clear();
            var years = (from o in listaDatosHistoricos select new { Year = o.FechaFactura.Year }).OrderBy(c => c.Year).Distinct();
            List<decimal> costoR = new List<decimal>();
            List<string> periodoR = new List<string>();
            foreach (var year in years)
            {
                for (int mes = 1; mes <= 12; mes++)
                {
                    string periodoX = year.Year.ToString() + "-" + mes.ToString();
                    periodoR.Add(periodoX);
                    decimal value = 0;
                    var data1 = from o in listaDatosHistoricos
                                where o.FechaFactura.Year.Equals(year.Year) && o.FechaFactura.Month == mes
                                orderby o.FechaFactura.Month ascending
                                select new { o.PrecioUsd, o.FechaFactura.Month };

                    if (data1.Any())
                    {
                        if (data1.Count() == 1)
                        {
                            value = data1.SingleOrDefault().PrecioUsd;
                        }
                        else
                        {
                            value = data1.Max(c => c.PrecioUsd);
                        }
                        costoR.Add(value);
                    }
                }
            }
            var lineSeries1 = new LineSeries
            {
                Title = "Costo USD",
                Values = new ChartValues<decimal>(costoR),
                DataLabels = false,
                Stroke = Brushes.DarkBlue,
                Fill = Brushes.LightBlue,
                ScalesYAt = 0,

            };
            x.Add(lineSeries1);
            //gr1.AxisX.Add(new Axis
            //{
            //    Title = "Fecha",
            //    Labels =periodoR,
            //});

            gr1.Series = x;


            //series.Add(new LineSeries() { Title = year.Year.ToString(), Values = new ChartValues<decimal>(costoR) });

            //series.Add(new LineSeries() { Title = "Periodo", Values = new ChartValues<decimal>(costoR) });
            //gr1.Series = series;

        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex != -1)
            {
                _material = cmbMaterial.SelectedValue.ToString();
                _costoRepo = new ACostoRepo(_material, tc.GetValueDecimal);
                _costoStd = new ACostoStandard(_material, tc.GetValueDecimal);
                _costoRepo.SetAutoFixIfRecordNotFound(true);
                _costoRepo.FixCostosReposicionCeroOldVersion();
                var materialData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
                txtDescripcion.Text = materialData.MAT_DESC;
                txtOrigen.Text = materialData.ORIGEN;
                txtMtype.Text = materialData.TIPO_MATERIAL;
                txtMonedaCosto.Text = materialData.MonedaCosto;
                MapCostData();
                CargaHistoData();

                var dataUC = new RepoHistoryManager().GetDataLastPurchase(_material);
                if (dataUC == null)
                {
                    btnSetUC.Enabled = false;
                }
                else
                {
                    if (_costoRepo.ValorUSD != dataUC.PrecioUsd)
                    {
                        btnSetUC.Enabled = true;
                    }
                    else
                    {
                        btnSetUC.Enabled = false;
                    }
                }
            }
            else
            {
                //Blanquea Info Costos
                txtCostoUCARS.Text = 0.ToString("C2");
                txtCostoUCUSD.Text = 0.ToString("C2");
                txtFechaUC.Text = null;
                txtKGUC.Text = 0.ToString("N2");
                txtProveedorUC.Text = null;
                _material = null;
                txtOrigen.Text = null;
                txtDescripcion.Text = null;
                txtCostoUCARS.BackColor = Color.DarkGray;
                txtCostoUCUSD.BackColor = Color.DarkGray;
                costoUltimasComprasBindingSource.DataSource = null;
                txtVarPrecioArs.Text = 0.ToString("C2");
                txtVarPrecioUsd.Text = 0.ToString("C2");
                ckManualUpdated.Checked = false;
                txtFechaUpdAnterior.Text = null;
                btnSetUC.Enabled = false;
            }
        }

        private void MapCostData()
        {
            _costoRepo.GetCost();
            _costoStd.GetCost();

            var cr = new CostRollManager().GetRegistroCostRoll(_material);
            txtCostoStdArs.Text = _costoStd.ValorARS.ToString("C3");
            txtCostoStdUsd.Text = _costoStd.ValorUSD.ToString("C3");
            if (cr == null)
            {
                MessageBox.Show(@"No se encontro un cost-roll generado para este material", @"Cost-Roll no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFechaCostRoll.Text = null;
                ckManualUpdated.Checked = false;
            }
            else
            {
                txtFechaCostRoll.Text = cr.CostRollDate.ToString("g");
                ckManualUpdated.Checked = cr.ManualUpdated;
            }

            if (!_costoRepo.Encontrado)
            {
                var rsp = MessageBox.Show(
                    @"No se ha encontrado Informacion de Ultima Compra. Se intentara obtener info automaticamente basada en datos guaradados de reporte FI",
                    @"Datos No Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _costoRepo.FixObtieneCostoUcFromUltimoRegistro(); //corre el fix en la tabla 404
                _costoRepo.SetAutoFixIfRecordNotFound(false);
                _costoRepo.GetCost();
                txtCostoUCARS.Text = _costoRepo.ValorARS.ToString("C2");
                txtCostoUCUSD.Text = _costoRepo.ValorUSD.ToString("C2");
                if (!_costoRepo.Encontrado)
                {
                    MessageBox.Show(@"No hay manera de conseguir un costo para este material",
                        @"Informacion No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFechaUC.Text = null;
                    txtKGUC.Text = null;
                    txtProveedorUC.Text = null;
                    txtMonedaUC.Text = null;
                    txtCostoUCARS.Text = null;
                    txtCostoUCUSD.Text = null;
                    txtMonedaUC.Text = null;
                    txtVarPrecioArs.Text = null;
                    txtVarPrecioUsd.Text = null;
                    ckManualUpdated.Checked = false;
                    txtFechaUpdAnterior.Text = null;
                }
            }
            else
            {
                txtCostoUCARS.Text = _costoRepo.ValorARS.ToString("C2");
                txtCostoUCUSD.Text = _costoRepo.ValorUSD.ToString("C2");
                txtFechaUC.Text = _costoRepo.DatosUc.FechaUCompra.ToString("d");
                txtKGUC.Text = _costoRepo.DatosUc.KgUCompra.ToString("N2");
                txtProveedorUC.Text = _costoRepo.DatosUc.Proveedor;
                txtMonedaUC.Text = _costoRepo.Moneda;
                if (txtMonedaUC.Text == @"USD")
                {
                    txtCostoUCARS.BackColor = Color.DarkGray;
                    txtCostoUCUSD.BackColor = Color.Yellow;
                }
                else
                {
                    txtCostoUCARS.BackColor = Color.Yellow;
                    txtCostoUCUSD.BackColor = Color.DarkGray;
                }

                txtVarPrecioArs.Text = _costoRepo.VariacionARS.ToString("C2");
                txtVarPrecioUsd.Text = _costoRepo.VariacionUSD.ToString("C2");
                ckManualUpdated.Checked = _costoRepo.RecordT0036.ManualUpdated;
                txtFechaUpdAnterior.Text = _costoRepo.RecordT0036.FechaCompraAnterior.ToString("g");
                if (_costoRepo.RecordT0036.UpdatedAfterCR)
                {
                    MessageBox.Show(@"Atencion este costo ha variado desde el ultimo Cost Roll",
                        @"Precio Actualizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }
        private void BtnUpdateUC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_material))
            {
                MessageBox.Show(@"Debe seleccionar un material para actualizar el precio de la ultima compra",
                    @"Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var f = new FrmCo12UpdateRepoCost(_material))
            {
                f.ShowDialog();
            }
        }

        private void BtnSetAsStandard_Click(object sender, EventArgs e)
        {

            //todo: Hay que hacer una funcion para setear el STD en la clase nueva ACostoSTD

            var resp = MessageBox.Show(@"Desea definir este costo como Costo Standard para calculos de Margen?",
                @"Definicion de Costo Standard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            MessageBox.Show(@"Se ha definido el costo de Ultima Compra como Costo Standard", @"Actualizacion Existosa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idF = Convert.ToInt32(datagridview[IdFactura.Name, e.RowIndex].Value);
            var idI = Convert.ToInt32(datagridview[IdItem.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "EDIT":
                    using (var f0 = new FrmCO04_UpdateRepoCostHistory(idF, idI))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            CargaHistoData();
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);}
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(
                @"Desea regenerar todos los costos de compra desde el valor ORIGINAL de contabilizacion?",
                @"Regeneracion de Costo Unitario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            new RepoHistoryManager().PopulateTable(_material, (int)txtRecordsUc.GetValueDecimal, true);
            CargaHistoData();
            MessageBox.Show(@"Se ha regenerado correctamente los costos Unitarios", @"Operacion Completada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSetUC_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(@"Desea Actualizar el Costo de Reposicion al de la Ultima Compra?",
                @"Actualizacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            var uc = new RepoHistoryManager().GetDataLastPurchase(_material);
            var tc = uc.PrecioArs / uc.PrecioUsd;
            _costoRepo.SaveCost(uc.VendorId, uc.KG, Monedas.SMonedas.USD, uc.PrecioUsd, uc.FechaFactura, tc, manualUpdate: true);
        }
    }
}
