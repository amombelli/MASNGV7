using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    //todo: por ahora vamos a permitir solamennte un item por NC
    //habra que generar una lista de idRemito-Material-Lote-Cantidad para el retorno de stock al contabilizar
    public partial class FrmFI52DiferenciaKg : Form
    {
        public struct DataRetornonStock
        {
            public int IdRemito;
            public string Item;
            public string Lote;
            public decimal Cantidad;
            public bool Reingreso;
        }
        public List<DataRetornonStock> ListaRetornoDevolucion = new List<DataRetornonStock>();
        private readonly CustomerNc.MotivoNotaCredito _motivoNotaCredito;
        private readonly int _idCliente;
        private readonly string _tipoLx;
        private readonly TipoDocumento _tipoDocx;
        private CustomerNc _nc; //para nota de credito
        private T0400_FACTURA_H _headerSelected;
        private T0401_FACTURA_I _itemSelected;
        private enum TipoDocumento
        {
            Credito,
            Debito,
        };

        public int IdFactura { private set; get; }
        private int idRemitoAsociado;
        public FrmFI52DiferenciaKg(CustomerNc znc, CustomerNc.MotivoNotaCredito motivoNotaCredito)
        {
            _motivoNotaCredito = motivoNotaCredito;
            _nc = znc;
            var h = znc.GetHeader();
            _idCliente = h.Cliente;
            _tipoLx = h.TIPOFACT;
            _tipoDocx = TipoDocumento.Credito;
            InitializeComponent();
        }
        private void FrmFI52DiferenciaKg_Load(object sender, EventArgs e)
        {
            var x = _nc.GetHeader();
            txtRazonSocial.Text = x.RAZONSOC;
            txtMotivoNc.Text = _motivoNotaCredito.ToString();
            txtId6.Text = x.Cliente.ToString();
            txtLx.Text = x.TIPOFACT;

            this.dgvListadoFacturas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
            t0400FACTURAHBindingSource.DataSource = GetTabla400401.GetListaDocumentos(_idCliente, _tipoLx).Where(c => c.TIPO_DOC != "NC").ToList();
            dgvListadoFacturas.ClearSelection();
            this.dgvListadoFacturas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
            idRemitoAsociado = 0; 
            IdFactura = -1;
        }
        private void rbSinReingresoStock_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void dgvListadoFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IdFactura = -1;
            if (e.RowIndex >= 0)
            {
                this.dgvListadoFacturas.CellEnter -=
                    new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
                IdFactura = Convert.ToInt32(dgvListadoFacturas[__idFactura.Name, e.RowIndex].Value);
                var g = new GestionT400(IdFactura);
                if (g.H4 == null)
                {
                    _headerSelected = null;
                    txtNumeroDocumento.Text = null;
                    txtIdFactura.Text = null;
                    BlanqueaDatosItem();
                    if (g.H4.IDRemito != null)
                    {
                        idRemitoAsociado = g.H4.IDRemito.Value;
                    }
                    return;
                }
                _headerSelected = g.H4;
                if (g.H4.TIPOFACT == "L2" && string.IsNullOrEmpty(g.H4.NumeroDoc))
                {
                    txtNumeroDocumento.Text = _headerSelected.Remito;
                    txtNumeroDocSelccionado.Text = _headerSelected.Remito;
                }
                else
                {
                    txtNumeroDocumento.Text = _headerSelected.NumeroDoc;
                    txtNumeroDocSelccionado.Text = _headerSelected.Remito;
                }
                txtIdFactura.Text = IdFactura.ToString();
                if (_headerSelected.IDRemito != null)
                {
                    txtIdRemito.Text = _headerSelected.IDRemito.Value.ToString();
                    idRemitoAsociado = _headerSelected.IDRemito.Value;
                    txtNumeroRemito.Text = _headerSelected.Remito;
                }
                else
                {
                    idRemitoAsociado = -1;
                }
                dgvFactuItems.DataSource = g.I4;
                dgvFactuItems.ClearSelection();
                BlanqueaDatosItem();
                this.dgvListadoFacturas.CellEnter +=
                    new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
            }
        }
        private void dgvFactuItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IdFactura <= 0)
            {
                BlanqueaDatosItem();
                return;
            }

            if (e.RowIndex >= 0)
            {
                var idItemSelected = Convert.ToInt32(dgvFactuItems[_2IdItem.Name, e.RowIndex].Value);
                var g = new GestionT400(IdFactura);
                if (_headerSelected == null)
                {
                    BlanqueaDatosItem();
                    return;
                }
                _itemSelected = g.I4.SingleOrDefault(c => c.IDITEM == idItemSelected); //
                txtMaterial.Text = _itemSelected.ITEM;
                txtItemDescripcion.Text = _itemSelected.DESC_REMITO;
                txtIdItem.Text = idItemSelected.ToString();
                txt1MonFactu.Text = _itemSelected.MONEDA_FACT;
                cCantidad.SetValue = _itemSelected.KGDESPACHADOS_R.Value;
                if (_itemSelected.MONEDA_FACT == "ARS")
                {
                    txt1PrecioUFact.Text = _itemSelected.PRECIOU_FACT_ARS.ToString("C2");
                    txt1PrecioTotFactu.Text = _itemSelected.PRECIOT_FACT_ARS.ToString("C2");
                    c3PrecioUNC.SetValue = _itemSelected.PRECIOU_FACT_ARS;
                    c3PrecioTotalNC.SetValue = 0;
                }
                else
                {
                    txt1PrecioUFact.Text = _itemSelected.PRECIOU_FACT_USD.ToString("C2");
                    txt1PrecioTotFactu.Text = _itemSelected.PRECIOT_FACT_USD.ToString("C2");
                    c3PrecioUNC.SetValue = _itemSelected.PRECIOU_FACT_USD;
                    c3PrecioTotalNC.SetValue = 0;
                }

                txt1Tc.Text = _headerSelected.TC.ToString("N2");
                //
                cNuevaCantidad.SetValue = _itemSelected.KGDESPACHADOS_R.Value;
                cVariacionCantidad.SetValue = 0;
                grpReingresarCantidad.Enabled = false;
                rbSinReingresoStock.Checked = false;
                rbReingresoStock.Checked = false;
                c3CantidadNC.SetValue = 0;
                txtDescripcionItemNC.Text = null;
                //manejo de remito
                if (idRemitoAsociado > 0)
                {

                    var x = new RemitoItemManager().GetLoteFromFactura(idRemitoAsociado, _itemSelected.ITEM);
                    if (!x.InfoFound)
                    {
                        MessageBox.Show(
                            @"No se encontro el material en el remito y no se puede determinar el lote a reingresar",
                            @"Datos no Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; //todo: ver como resolver esto
                    }
                    if (x.UnicoRecordFound)
                    {
                        txtLoteReingreso.Text = x.Lote1;
                        txtLoteReingreso.BackColor=Color.LightGreen;
                        txtLoteReingreso.ReadOnly = true;
                    }
                    else
                    {
                        txtLoteReingreso.Text = x.Lote1;
                        txtLoteReingreso.BackColor= Color.LightPink;
                        MessageBox.Show(
                            @"El lote seleccionado es el primero que se encontro pero deberia verificar en el stock cual es el correcto",
                            @"Mas de un lote encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLoteReingreso.ReadOnly = false;
                    }
                }

            }
        }
        private void BlanqueaDatosItem()
        {
            txtMaterial.Text = null;
            txtIdItem.Text = null;
            txtItemDescripcion.Text = null;
            cCantidad.SetValue=0;
            txt1Tc.Text = 1.ToString("N2");
            txt1MonFactu.Text = @"ARS";
            txt1PrecioUFact.Text = 0.ToString("C2");
            txt1PrecioTotFactu.Text = 0.ToString("C2");
            grpReingresarCantidad.Enabled = false;
            rbSinReingresoStock.Checked = false;
            rbReingresoStock.Checked = false;
            c3CantidadNC.SetValue = 0;
            c3PrecioUNC.SetValue = 0;
            c3PrecioTotalNC.SetValue = 0;
            txtDescripcionItemNC.Text = null;
            cNuevaCantidad.SetValue = 0;
            return;
        }
        private void tdAddButton_BotonClick(object sender, EventArgs e)
        {
            dgvListadoFacturas.ReadOnly = true;
            if (_tipoDocx == TipoDocumento.Credito)
            {
                //Alta del Item
                _nc.AddItems(txtMaterial.Text, txtDescripcionItemNC.Text, c3PrecioUNC.GetValueDecimal,
                    _itemSelected.GLV,
                    _itemSelected.IVA21, c3CantidadNC.GetValueDecimal);
                _nc.SetTotalesInHeaderFromItems();
                _nc.SetDocumentoAsociado(IdFactura);
                var rtx = new DataRetornonStock()
                {
                    IdRemito = idRemitoAsociado,
                    Cantidad = c3CantidadNC.GetValueDecimal,
                    Item = txtMaterial.Text,
                    Lote = txtLoteReingreso.Text,
                    Reingreso = rbReingresoStock.Checked
                };
                ListaRetornoDevolucion.Add(rtx);
            }
            else
            {
                //no esta contemplado diferencia de KG por ND.- 
                //Alta del Item
                //_nd.AddItems(txtMaterial.Text, txtDescripcionItemNC.Text, c3PrecioUNC.GetValueDecimal, _itemSelected.GLV,
                //    _itemSelected.IVA21, cCantidadNc.GetValueDecimal);
                //_nd.SetTotalesInHeaderFromItems();
                //_nd.SetDocumentoAsociado(_idFacturaSeleccionada);
            }
            dgvFactuItems.ClearSelection();
            BlanqueaDatosItem();
        }
        private void tsVolver_BotonClick(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private void cNuevaCantidad_Validated(object sender, EventArgs e)
        {
            cVariacionCantidad.SetValue = cNuevaCantidad.GetValueDecimal - cCantidad.GetValueDecimal;
            grpReingresarCantidad.Enabled = true;
            rbReingresoStock.Checked = true;
            c3PrecioTotalNC.SetValue = c3PrecioUNC.GetValueDecimal * cVariacionCantidad.GetValueDecimal;
            c3CantidadNC.SetValue = cVariacionCantidad.GetValueDecimal;
            txtDescripcionItemNC.Text = $@"Diferencia de KG Factura #{txtNumeroDocSelccionado.Text}";
        }
        private void cNuevaCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (cNuevaCantidad.GetValueDecimal > cCantidad.GetValueDecimal)
            {
                MessageBox.Show(@"La Cantidad no puede sobrepasar al maximo despachado",
                    @"Error en Definicion de Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            
        }
    }
}
