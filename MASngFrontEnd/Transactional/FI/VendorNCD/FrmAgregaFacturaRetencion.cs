using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI
{
    public partial class FrmAgregaFacturaRetencion : Form
    {
        public FrmAgregaFacturaRetencion(int numeroOP)
        {
            _numeroOP = numeroOP;
            InitializeComponent();
        }

        private readonly int _numeroOP;
        private List<T0213_OP_FACT> _listaFactura;
        private int _idCtaCteSeleccionado;
        private void FrmAgregaFacturaRetencion_Load(object sender, EventArgs e)
        {
            txtNumeroOP.Text = _numeroOP.ToString();
            dgvListaFacturas.DataSource = t0213OPFACTBindingSource;
            GetListaFacturasSinRetencion();
            t0213OPFACTBindingSource.DataSource = _listaFactura.ToList();
            btnAgregarRetencion.Enabled = false;
        }

        private void GetListaFacturasSinRetencion()
        {
            var factuRete = new MngRetencionesFacturasProv().GetAllRetencionesFromOP(_numeroOP).ToList();
            var listaFactura = new OrdenPagoManageDatos(_numeroOP).GetDatosFacturasPagandoFromDb().ToList();
            _listaFactura = new OrdenPagoManageDatos(_numeroOP).GetDatosFacturasPagandoFromDb().ToList();
            foreach (var item in listaFactura)
            {
                var data = factuRete.Find(c => c.ID == item.IdCtaCte);
                if (data != null)
                {
                    var xRemove = _listaFactura.Find(c => c.IdCtaCte == item.IdCtaCte);
                    _listaFactura.Remove(xRemove);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnAgregarRetencion_Click(object sender, EventArgs e)
        {
            var resultado = new MngRetencionesFacturasProv().AgregaRetencionesEnT0405(_idCtaCteSeleccionado, _numeroOP, 0, 0, 0, "");
            if (resultado == false)
            {
                MessageBox.Show(
                    @"Ha ocurrido algun error en el agregado de la retencion a la tabla de retenciones",
                    @"Error en Agregado de Retencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
            //UpdateImporteRetencionesOPFact_OPHeader(numeroOP);
        }

        private void dgvListaFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                _idCtaCteSeleccionado = Convert.ToInt32(dgvListaFacturas[6, e.RowIndex].Value);
            }
            btnAgregarRetencion.Enabled = true;
        }
    }
}
