using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP15ConfirmacionLotesCierreOF : Form
    {
        public FrmPP15ConfirmacionLotesCierreOF(int numeroOF, List<T0072_FORMULA_TEMP> xlista, decimal kgTotalIngreso,
            decimal kgIngresarAhora)
        {
            InitializeComponent();
            txtNumeroOF.Text = numeroOF.ToString();
            _listaCompletaDescuentoStock = xlista;
            _totalKgCierreOF = kgTotalIngreso;
            _numeroOF = numeroOF;
        }

        //---------------------------------------------------------------------------------------------------------------
        private List<T0072_FORMULA_TEMP> _listaCompletaDescuentoStock = new List<T0072_FORMULA_TEMP>();
        public decimal TotalKgMPUsada = 0;
        private decimal TotalInsumos = 0;
        private readonly decimal _totalKgCierreOF;
        private readonly int _numeroOF;
        //---------------------------------------------------------------------------------------------------------------

        private void FrmConfirmacionDescuentoStockOF_Load(object sender, EventArgs e)
        {
            ckVerSoloStockDescuento.Checked = true;
            LoadDataOF();
            btnConfirmarDescuento.Enabled = true;
            SetDataSourceDgvFormulaDescontar();



        }


        private void LoadDataOF()
        {
            var ofData = PlanProduccionListManager.GetOFData(Convert.ToInt32(txtNumeroOF.Text));
            if (ofData != null)
            {
                txtMaterialEtiqueta.Text = ofData.MATETIQUETA;
                if (ofData.MATETIQUETA == ofData.MATERIAL)
                {
                    txtMaterialEtiqueta.ForeColor = Color.Black;
                    txtMaterialEtiqueta.BackColor = Color.Gainsboro;
                }
                else
                {
                    txtMaterialEtiqueta.ForeColor = Color.OrangeRed;
                    txtMaterialEtiqueta.BackColor = Color.Black;
                }
                txtMaterialFabricado.Text = ofData.MATERIAL;
            }
        }


        private void SetDataSourceDgvFormulaDescontar()
        {
            //**Sumariza los Totales de Consumo Real MP/Insumos
            TotalKgMPUsada = 0;
            TotalInsumos = 0;

            var totalizado = _listaCompletaDescuentoStock.Find(c => c.Secuencia == 1000);
            _listaCompletaDescuentoStock.Remove(totalizado);

            foreach (var item in _listaCompletaDescuentoStock)
            {
                if (item.Primario.StartsWith("B"))
                {
                    if (item.CantidadKGReal != null) TotalInsumos += item.CantidadKGReal.Value;
                }
                else
                {
                    if (item.CantidadKGReal != null) TotalKgMPUsada += item.CantidadKGReal.Value;
                }
            }


            //** Agrega linea de totales en DGV - Secuencia 1000 
            var x = new T0072_FORMULA_TEMP
            {
                Primario = "TOTAL MP (Sin Insumos)>>",
                CantidadKGReal = TotalKgMPUsada,
                Secuencia = 1000,
            };
            _listaCompletaDescuentoStock.Add(x);
            dgvFormulaDescontar.DataSource = null;
            if (ckVerSoloStockDescuento.Checked)
            {
                dgvFormulaDescontar.DataSource =
                    _listaCompletaDescuentoStock.Where(c => c.CantidadKGReal.Value > 0).ToList();
            }
            else
            {
                dgvFormulaDescontar.DataSource = _listaCompletaDescuentoStock;
            }

            txtTotalMPConsumida.Text = TotalKgMPUsada.ToString("N2");
            txtTotalInsumos.Text = TotalInsumos.ToString("N1");
            txtTotalMerma.Text = (TotalKgMPUsada - _totalKgCierreOF).ToString("N2");
            txtTotalKgFabricados.Text = _totalKgCierreOF.ToString("N2");

            //******* [Formatea Lineas DGV] *********


            //Formato de Linea Sumarizada Totales
            for (var i = 0; i < dgvFormulaDescontar.Columns.Count; i++)
            {
                dgvFormulaDescontar.Rows[dgvFormulaDescontar.Rows.Count - 1].Cells[i].Style.BackColor = Color.MidnightBlue;
                dgvFormulaDescontar.Rows[dgvFormulaDescontar.Rows.Count - 1].Cells[i].Style.ForeColor = Color.DarkOrange;
            }


            for (var i = 0; i < dgvFormulaDescontar.Rows.Count - 1; i++)
            {
                //Formateo Lineas Color Segun estado Stock
                switch (dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Value.ToString())
                {
                    case "Unknown":
                        dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Style.BackColor =
                            Color.Red;
                        dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Style.ForeColor =
                            Color.White;
                        btnConfirmarDescuento.Enabled = false;
                        break;
                    case "Confirmado":
                        dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Style.BackColor = Color.LightGreen;

                        break;
                    case "StockOK":
                        dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Style.BackColor = Color.LightBlue;

                        break;
                    case "SinStock":
                        dgvFormulaDescontar.Rows[i].Cells[__statusstock.Name].Style.BackColor = Color.Pink;
                        btnConfirmarDescuento.Enabled = false;
                        break;
                }

                //Formateo Color Container
                if (dgvFormulaDescontar.Rows[i].Cells[__material.Name].Value.ToString().StartsWith("B"))
                {
                    dgvFormulaDescontar.Rows[i].Cells[__material.Name].Style.BackColor = Color.DarkKhaki;
                }

                if ((bool)dgvFormulaDescontar.Rows[i].Cells[__added.Name].Value)
                {
                    dgvFormulaDescontar.Rows[i].Cells[__material.Name].Style.BackColor = Color.GreenYellow;
                    dgvFormulaDescontar.Rows[i].Cells[__added.Name].Style.BackColor = Color.GreenYellow;
                }
            }
        }





        private void dgvFormulaDescontar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirmarDescuento_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelarDescuento_Click(object sender, EventArgs e)
        {

            ///************************  OJO LIBERAR TODO EL STOCK Y REMOVER LOS DATOS DEL DGV!!! *****************************
            var dr0 = MessageBox.Show(@"Esta seguro que desea cancelar la asignacion de lotes y el ingreso de produccion?",
                   @"Ingreso y Ciere de Produccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr0)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case DialogResult.No:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ckVerSoloStockDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerSoloStockDescuento.Checked)
            {
                ckVerSoloStockDescuento.BackColor = Color.LightGreen;
            }
            else
            {
                ckVerSoloStockDescuento.BackColor = Color.LightSalmon;
            }
            SetDataSourceDgvFormulaDescontar();
        }
    }
}
