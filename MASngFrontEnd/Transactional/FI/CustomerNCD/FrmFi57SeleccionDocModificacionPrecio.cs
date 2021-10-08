using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi57SeleccionDocModificacionPrecio : Form
    {

        public FrmFi57SeleccionDocModificacionPrecio(CustomerNc znc, CustomerNc.MotivoNotaCredito motivo)
        {
            var h = znc.GetHeader();
            _nc = znc;
            _motivo = motivo;
            _idCliente = h.Cliente;
            _tipoLx = h.TIPOFACT;
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------
        private CustomerNc _nc;
        private readonly int _idCliente;
        private readonly string _tipoLx;
        private readonly CustomerNc.MotivoNotaCredito _motivo;
        private T0400_FACTURA_H _headerSelected;
        private T0401_FACTURA_I itemSelected;
        private int _idFacturaSeleccionada;
        private decimal _importeAcumulado = 0;

        //para aplicar los imtes
        public List<T0401_FACTURA_I> ItemList = new List<T0401_FACTURA_I>();
        public List<int> FacturaAplica { get; private set; }
        public List<string> NumeroDocumentoAplica { get; private set; } //En caso de un solo documento - numero para descripcion
        public DateTime? FechaAplicaDesde { get; private set; } //En caso de Periodo: Fecha Desde
        public DateTime? FechaAplicaHasta { get; private set; } //En caso de Periodo: Fecha Hasta

        
        
        //----------------------------------------------------------------------------------------
       //ver si eliminar algo ?
        

        public decimal KgNotaCredito;
        public int IdFactura;
        public int IdFacturaItem;
        public int IdDevolucion;
        private string _materialDev;

        //para aplicar los imtes
        //public List<T0401_FACTURA_I> ItemList = new List<T0401_FACTURA_I>();
        public int XIdFactura { get; private set; }
        public int XIdItem { get; private set; }
        

        //----------------------------------------------------------------------------------------
        private void FrmSeleccionMaterialNcd_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Text = _nc.H4.RAZONSOC;
            txtMotivoNc.Text = _motivo.ToString();
            txtId6.Text = _nc.H4.Cliente.ToString();
            txtLx.Text = _nc.H4.TIPOFACT;
            this.dgvFactuHeader.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactuHeader_CellEnter);
            dgvFactuHeader.DataSource = CustomerDoc.GetListaDocumentosSeleccionar(_idCliente, _tipoLx,true,false,false,false,false,false);
            ConfiguraSegunMotivo();
            dgvFactuHeader.ClearSelection();
            this.dgvFactuHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactuHeader_CellEnter);
        }
        private void ConfiguraSegunMotivo()
        {
            txt2MonCot.ReadOnly = true;
            c2PrecioUnitCot.XReadOnly = true;
            c2Tc.XReadOnly = true;
            c2Cantidad.XReadOnly = true;
            ckReingresoKg.AutoCheck = false;
            switch (_motivo)
            {
                case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                    c2PrecioUnitCot.XReadOnly = false;
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                    c2Tc.XReadOnly = false;
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                    c2Cantidad.XReadOnly = false;
                    ckReingresoKg.AutoCheck = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void dgvFactuHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dgvSeleccionItem.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeleccionItem_CellEnter);
                IdFactura = Convert.ToInt32(dgvFactuHeader[__idDocumento.Name, e.RowIndex].Value);
                var g = new GestionT400(IdFactura);
                if (g.H4 == null)
                {
                    _headerSelected = null;
                    txtNumeroDocumento.Text = null;
                    txtIdFactura.Text = null;
                    BlanqueaDatosItem();
                    return;
                }
                _headerSelected = g.H4;
                txtNumeroDocumento.Text = _headerSelected.NumeroDoc;
                txtIdFactura.Text = IdFactura.ToString();
                dgvSeleccionItem.DataSource = g.I4;
                dgvSeleccionItem.ClearSelection();
                BlanqueaDatosItem();
                this.dgvSeleccionItem.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeleccionItem_CellEnter);
            }
        }

        private void BlanqueaItemsAModificar()
        {
            itemSelected = null;
            txt2MonCot.Text = null;
            c2PrecioUnitCot.SetValue = 0;
            c2Tc.SetValue = 0;
            c2Cantidad.SetValue = 0;
            c3VarCantidad.SetValue = 0;
            ckReingresoKg.Checked = false;
            txt2MonFactu.Text = @"ARS";
            c2PrecioUnitFactu.SetValue = 0;
            c2PrecioTotFactu.SetValue = 0;
            c3PrecioUNC.SetValue = 0;
            c3PrecioTotalNC.SetValue = 0;
            cCantidadNc.SetValue = 0;
            txtDescripcionItemNC.Text = null;


        }
        private void BlanqueaDatosItem()
        {
            txtMaterial.Text = null;
            txtIdItem.Text = null;
            txtItemDescripcion.Text = null;
            //
            txt1Cantidad.Text = 0.ToString();
            txt1Tc.Text = 1.ToString("N2");
            txt1MonCotizacion.Text = @"ARS";
            txt1PrecioUCot.Text = 0.ToString("C2");
            txt1MonFactu.Text = @"ARS";
            txt1PrecioUFact.Text = 0.ToString("C2");
            txt1PrecioTotFactu.Text = 0.ToString("C2");
            BlanqueaItemsAModificar();
            return;
        }

        private void dgvSeleccionItem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var idItemSelected = Convert.ToInt32(dgvSeleccionItem[___idITem.Name, e.RowIndex].Value);
                _idFacturaSeleccionada = Convert.ToInt32(dgvSeleccionItem[___idFactura.Name, e.RowIndex].Value);
                var g = new GestionT400(_idFacturaSeleccionada);
                itemSelected = g.I4.SingleOrDefault(c => c.IDITEM == idItemSelected);
                if (_headerSelected == null)
                {
                    BlanqueaDatosItem();
                    return;
                }

                //
                txtMaterial.Text = itemSelected.ITEM;
                txtIdItem.Text = idItemSelected.ToString();
                txtItemDescripcion.Text = itemSelected.DESC_REMITO;
                //
                txt1Cantidad.Text = itemSelected.KGDESPACHADOS_R.Value.ToString();
                txt1Tc.Text = _headerSelected.TC.ToString("N2");
                txt1MonCotizacion.Text = itemSelected.MONEDA_COTIZ;
                txt1PrecioUCot.Text = itemSelected.PRECIOU_COTIZ.ToString("C2");
                txt1MonFactu.Text = itemSelected.MONEDA_FACT;
                if (itemSelected.MONEDA_FACT == "ARS")
                {
                    txt1PrecioUFact.Text = itemSelected.PRECIOU_FACT_ARS.ToString("C2");
                    txt1PrecioTotFactu.Text = itemSelected.PRECIOT_FACT_ARS.ToString("C2");
                }
                else
                {
                    txt1PrecioUFact.Text = itemSelected.PRECIOU_FACT_USD.ToString("C2");
                    txt1PrecioTotFactu.Text = itemSelected.PRECIOT_FACT_USD.ToString("C2");
                }

                //map valores a modifcar por mismo valores panel1
                txt1Cantidad.Text = itemSelected.KGDESPACHADOS_R.Value.ToString();
                txt1Tc.Text = itemSelected.TC.ToString("N2");
                txt1MonCotizacion.Text = itemSelected.MONEDA_COTIZ;
                txt1PrecioUCot.Text = itemSelected.PRECIOU_COTIZ.ToString("C2");
                txt1MonFactu.Text = itemSelected.MONEDA_FACT;
                if (itemSelected.MONEDA_FACT == "ARS")
                {
                    txt1PrecioUFact.Text = itemSelected.PRECIOU_FACT_ARS.ToString("C2");
                    txt1PrecioTotFactu.Text = itemSelected.PRECIOT_FACT_ARS.ToString("C2");
                }
                else
                {
                    txt1PrecioUFact.Text = itemSelected.PRECIOU_FACT_USD.ToString("C2");
                    txt1PrecioTotFactu.Text = itemSelected.PRECIOT_FACT_USD.ToString("C2");
                }

                c2Cantidad.SetValue = itemSelected.KGDESPACHADOS_R.Value;
                c2Tc.SetValue = _headerSelected.TC;
                txt2MonCot.Text = itemSelected.MONEDA_COTIZ;
                c2PrecioUnitCot.SetValue = itemSelected.PRECIOU_COTIZ;
                txt2MonFactu.Text = itemSelected.MONEDA_FACT;
                //
                c2PrecioUnitFactu.SetValue = FormatAndConversions.CCurrencyADecimal(txt1PrecioUFact.Text);
                c2PrecioTotFactu.SetValue = FormatAndConversions.CCurrencyADecimal(txt1PrecioTotFactu.Text);
                c3PrecioUNC.SetValue = 0;
                c3PrecioTotalNC.SetValue = 0;
                txtDescripcionItemNC.Text = null;
                ckReingresoKg.Checked = false;
                ckReingresoKg.AutoCheck = false;
            }
        }



        //modificaciones

        private void c2Cantidad_Validated(object sender, EventArgs e)
        {
            //se cambio cantidad
            CalculaModificacionPrecio();
        }
        private void txt2MonCot_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var t = (TextBox) sender;
            if (t.Text == @"ARS" || t.Text == @"USD")
            {
                e.Cancel = false;
                return;
            }

            MessageBox.Show(@"Moneda Incorrecta", @"Atencion con los datos ingresados", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            e.Cancel = true;
        }
        private void txt2MonCot_Validated(object sender, EventArgs e)
        {
            // se cambio moneda de cotizacion del Item!
            CalculaModificacionPrecio();
        }
        private void c2PrecioUnitCot_Validated(object sender, EventArgs e)
        {
            //se cambio precio unitario del item
            //actualizar precio total
            CalculaModificacionPrecio();
        }


        private void CalculaModificacionPrecio()
        {
            if (_motivo == CustomerNc.MotivoNotaCredito.DiferenciaPrecio)
            {
                cCantidadNc.SetValue = c2Cantidad.GetValueDecimal;
            }
            
            decimal vUnitArs;
            decimal vUnitUsd;
            if (c2Tc.GetValueDecimal <= (decimal) 0.1)
            {
                c2Tc.SetValue = 1;
            }

            if (txt2MonCot.Text == @"ARS")
            {
                vUnitArs = c2PrecioUnitCot.GetValueDecimal;
                vUnitUsd = c2PrecioUnitCot.GetValueDecimal / c2Tc.GetValueDecimal;
            }
            else
            {
                vUnitArs = c2PrecioUnitCot.GetValueDecimal* c2Tc.GetValueDecimal;
                vUnitUsd = c2PrecioUnitCot.GetValueDecimal;
            }

            if (txt2MonFactu.Text == @"ARS")
            {
                c2PrecioUnitFactu.SetValue = vUnitArs;
                c2PrecioTotFactu.SetValue = vUnitArs * c2Cantidad.GetValueDecimal;
            }
            else
            {
                c2PrecioUnitFactu.SetValue = vUnitUsd;
                c2PrecioTotFactu.SetValue = vUnitUsd * c2Cantidad.GetValueDecimal;
            }

            c3PrecioUNC.SetValue = Math.Round((c2PrecioUnitFactu.GetValueDecimal -
                                              FormatAndConversions.CCurrencyADecimal(txt1PrecioUFact.Text)),2);
            c3PrecioTotalNC.SetValue = Math.Round(c2PrecioTotFactu.GetValueDecimal - FormatAndConversions.CCurrencyADecimal(txt1PrecioTotFactu.Text), 2);
            
            c3VarCantidad.SetValue = c2Cantidad.GetValueDecimal - Convert.ToDecimal(txt1Cantidad.Text);
            switch (_motivo)
            {
               case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                   cCantidadNc.SetValue = c2Cantidad.GetValueDecimal;
                   if (string.IsNullOrEmpty(txtDescripcionItemNC.Text))
                   {
                       txtDescripcionItemNC.Text = $@"Dif. Precio  {txtMaterial.Text} Doc# {txtNumeroDocumento.Text}";
                   }
                   break;
                case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                    txtDescripcionItemNC.Text = $@"Dif. Precio por Dif TC {txtMaterial.Text} Doc# {txtNumeroDocumento.Text}";
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                    cCantidadNc.SetValue = c3VarCantidad.GetValueDecimal;
                    if (string.IsNullOrEmpty(txtDescripcionItemNC.Text))
                    {
                        txtDescripcionItemNC.Text = $@"Diferencia KG {txtMaterial.Text} Doc# {txtNumeroDocumento.Text}";
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        //Botones
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void tdAddButton_BotonClick(object sender, EventArgs e)
        {
            dgvFactuHeader.ReadOnly = true;
            
            //Alta del Item
            _nc.AddItems(txtMaterial.Text,txtDescripcionItemNC.Text,c3PrecioUNC.GetValueDecimal,itemSelected.GLV,itemSelected.IVA21,cCantidadNc.GetValueDecimal);
            _nc.SetTotalesInHeaderFromItems();
            _nc.SetDocumentoAsociado(_idFacturaSeleccionada);
            dgvSeleccionItem.ClearSelection();
            BlanqueaDatosItem();
        }

        private void tsVolver_BotonClick(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
