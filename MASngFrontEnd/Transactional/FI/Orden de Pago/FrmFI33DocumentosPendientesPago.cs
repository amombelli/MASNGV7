using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData.Vendor_Master;
using Tecser.Business.Transactional.FI.ContabilizacionProveedores;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI33DocumentosPendientesPago : Form
    {
        private readonly int _idVendor;
        private readonly int _modofuncion;
        private string _lx;

        public int IdCtaCteSeleccion { get; private set; }
        public int NumeroDgv { get; private set; }

        //Modo funcion = 1 (Orden de Pago)
        public FrmFI33DocumentosPendientesPago(int idVendor, int modofuncion)
        {
            _idVendor = idVendor;
            _modofuncion = modofuncion;
            _lx = "L0";
            InitializeComponent();
        }
        public FrmFI33DocumentosPendientesPago(int idVendor, int modofuncion, string tipoLx)
        {
            _idVendor = idVendor;
            _modofuncion = modofuncion;
            _lx = tipoLx;
            InitializeComponent();
        }

        private void FrmFI32DocumentosPendientesPago_Load(object sender, EventArgs e)
        {
            //esto esta pensado para usar esta interfaz para agregar creditos
            //pero ahora esta en deshuso
            if (_modofuncion == 1)
            {
                btn1.Text = @"AddOP";
                _btn2.Text = @"Add";

            }

            if (_modofuncion == 0)
            {
                btn1.Visible = false;
            }

            var d = VendorMng2.GetVendor(_idVendor);
            txtRazonSocial.Text = d.RazonSocial;
            txtFantasia.Text = d.Fantasia;
            if (_lx == "L1")
            {
                ckL1.Checked = true;
                ckL1.AutoCheck = false;
                ckL2.AutoCheck = false;
            }

            if (_lx == @"L2")
            {
                ckL2.Checked = true;
                ckL1.AutoCheck = false;
                ckL2.AutoCheck = false;
            }

            if (_lx == "L0")
            {
                //sin seleccion de tipo 
                ckL1.AutoCheck = true;
                ckL2.AutoCheck = true;
            }
            CalculaDeuda();
        }
        private void CalculaDeuda()
        {
            var lst = new DetalleDocumentosPP().GetDocumentList(_idVendor, _lx,!ckAllDocuments.Checked).ToList();
            dgvListadoDocumentos.DataSource = lst.Where(c=>c.ImporteDoc >0 && c.TDoc!="OPZ").ToList();
            dgvCredito.DataSource = lst.Where(c => c.ImporteDoc < 0 || c.TDoc == "OPZ").ToList();
            if (lst.Count == 0)
            {
                cImporteAdeudado.DisplayValue = 0;
                cImporteVencido.DisplayValue = 0;
            }
            cImporteAdeudado.DisplayValue = lst.Sum(c => c.ImporteDeuda);
            var dv2 = lst.Where(c => c.FechaVencimiento <= DateTime.Today).ToList();
            if (dv2.Count == 0)
            {
                cImporteVencido.DisplayValue = 0;
            }
            else
            {
                cImporteVencido.DisplayValue = dv2.Sum(c => c.ImporteDeuda);
            }
        }

        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked && ckL2.Checked)
            {
                _lx = "L3";
                CalculaDeuda();
                return;
            }

            if (ckL1.Checked == false && ckL2.Checked == false)
            {
                _lx = "L0";
                CalculaDeuda();
                return;
            }

            _lx = ckL1.Checked ? "L1" : "L2";
            CalculaDeuda();
        }

        private void dgvListadoDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "AddOP":
                    IdCtaCteSeleccion = Convert.ToInt32(dgv[IdCtaCte.Name, e.RowIndex].Value);
                    NumeroDgv = 1;
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void dgvCredito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Add":
                    IdCtaCteSeleccion = Convert.ToInt32(dgv[_2IdCtaCte.Name, e.RowIndex].Value);
                    NumeroDgv = 2;
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void ckAllDocuments_CheckedChanged(object sender, EventArgs e)
        {
            CalculaDeuda();
        }


        //botones
        private void btnSalirOP_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
