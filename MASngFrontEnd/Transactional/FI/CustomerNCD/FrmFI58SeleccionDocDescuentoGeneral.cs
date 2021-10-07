using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI58SeleccionDocDescuentoGeneral : Form
    {
        public FrmFI58SeleccionDocDescuentoGeneral(CustomerNc znc, CustomerNc.MotivoNotaCredito motivo)
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
        
        private T0400_FACTURA_H _recordSelected;
        private int _idFacturaSeleccionada;
        private decimal _importeAcumulado = 0;
        
        //para aplicar los imtes
        public List<T0401_FACTURA_I> ItemList = new List<T0401_FACTURA_I>();
        public List<int> FacturaAplica { get; private set; } 
        public List<string>NumeroDocumentoAplica { get; private set; } //En caso de un solo documento - numero para descripcion
        public DateTime? FechaAplicaDesde { get; private set; } //En caso de Periodo: Fecha Desde
        public DateTime? FechaAplicaHasta { get; private set; } //En caso de Periodo: Fecha Hasta
        //----------------------------------------------------------------------------------------
        private void FrmSeleccionMaterialNcd_Load(object sender, EventArgs e)
        {
            l1.Visible = false;
            l2.Visible = false;
            if (_motivo == CustomerNc.MotivoNotaCredito.DesGeneralDocumentos)
            {
                l1.Visible = true;
            }
            else
            {
                if (_motivo == CustomerNc.MotivoNotaCredito.DesGeneralPeriodo)
                {
                    l2.Visible = true;
                }
                else
                {
                    MessageBox.Show(@"Esta interfaz no es valida para este motivo de Nota de Credito",
                        @"Error en Motivo NC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            
            dgvFactuHeader.DataSource = CustomerDoc.GetListaDocumentosSeleccionar(_idCliente, _tipoLx, true, false, false, false, false, false);

            if (_tipoLx == "L2")
            {
                ckIVA.Checked = false;
                ckIVA.AutoCheck = false;
            }
            else
            {
                ckIVA.Checked = true;
                ckIVA.AutoCheck = true;
            }

            dgvFactuHeader.ClearSelection();
            BlanqueaDocumentoSeleccionado();
        }
        private void BlanqueaDocumentoSeleccionado()
        {
            cBruto.SetValue = 0;
            cDescuento.SetValue = 0;
            cSubtotal.SetValue = 0;
            cImponible.SetValue = 0;
            cIva.SetValue = 0;
            cPercepcionIIBB.SetValue = 0;
            cTotalFinal.SetValue = 0;
            txtNumeroDocumento.Text = null;
            txtIdFactura.Text = null;
            txtMonedaFactura.Text = null;
        }
        private void dgvFactuHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0) return;
            
            _idFacturaSeleccionada = Convert.ToInt32(dgv[__idDocumento.Name, e.RowIndex].Value);
            _recordSelected = CustomerNc.Get400Header(_idFacturaSeleccionada);
            if (_recordSelected == null) return;

            txtNumeroDocumento.Text = _recordSelected.NumeroDoc;
            txtIdFactura.Text = _idFacturaSeleccionada.ToString();
            cBruto.SetValue = _recordSelected.TotalFacturaB;
            cDescuento.SetValue = _recordSelected.Descuento.Value;
            cSubtotal.SetValue = _recordSelected.TotalFacturaB - _recordSelected.Descuento.Value;
            cImponible.SetValue = _recordSelected.TotalImpo;
            cIva.SetValue = _recordSelected.TotalIVA21;
            cPercepcionIIBB.SetValue = _recordSelected.TotalIIBB;
            cTotalFinal.SetValue = _recordSelected.TotalFacturaN;
            c1ImporteBruto.SetValue = _recordSelected.TotalFacturaB;
            c1DescuentoPeso.SetValue = 0;
            c1DescuentoPorcentaje.SetValue = 0;

            if (_motivo == CustomerNc.MotivoNotaCredito.DesGeneralDocumentos ||
                _motivo == CustomerNc.MotivoNotaCredito.DesGeneralPeriodo)
            {
                txtDescripcionItemNC.Text =
                    $@"Descuento Cond. Especial S/Doc# {_recordSelected.TIPO_DOC}|{txtNumeroDocumento.Text}";
            }
        }
       
        //Botones
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        //Boton Agregar Item
        private void tdAddButton_BotonClick(object sender, EventArgs e)
        {
            if (c1DescuentoPeso.GetValueDecimal == 0)
            {
                MessageBox.Show(@"No se genera diferencia para generar una NC", @"Sin Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcionItemNC.Text))
            {
                MessageBox.Show(@"Debe completar una descripcion para el Item", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (CheckItemAlreadyInList(_idFacturaSeleccionada))
            {
                MessageBox.Show(@"Este Item ya ha sido seleccionado y se encuentra en la lista", @"Datos Duplicados", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            //Alta del Item
            _nc.AddItems("DESCGRAL",txtDescripcionItemNC.Text, c1DescuentoPeso.GetValueDecimal,"4.1.3",ckIVA.Checked,1,"ARS");
            _nc.SetTotalesInHeaderFromItems();
            _nc.SetDocumentoAsociado(_idFacturaSeleccionada);
            if (FechaAplicaDesde == null)
            {
                FechaAplicaDesde = _recordSelected.FECHA;
                FechaAplicaHasta = _recordSelected.FECHA;
            }
            else
            {
                if (FechaAplicaDesde > _recordSelected.FECHA)
                {
                    FechaAplicaDesde = _recordSelected.FECHA;
                }

                if (FechaAplicaHasta < _recordSelected.FECHA)
                {
                    FechaAplicaHasta = _recordSelected.FECHA;
                }
            }

            if (FacturaAplica == null)
            {
                FacturaAplica = new List<int>();
                NumeroDocumentoAplica = new List<string>();
            }
            FacturaAplica.Add(_idFacturaSeleccionada);
            NumeroDocumentoAplica.Add(_recordSelected.NumeroDoc);

            c1ImporteBruto.SetValue = 0;
            c1DescuentoPeso.SetValue = 0;
            c1DescuentoPorcentaje.SetValue = 0;
            txtDescripcionItemNC.Text = null;
            _importeAcumulado = _nc.GetHeader().TotalFacturaB;
            c3PrecioUNC.SetValue = _importeAcumulado;
            dgvFactuHeader.ClearSelection();
            BlanqueaDocumentoSeleccionado();
        }

        private bool CheckItemAlreadyInList(int idFactura)
        {
            if (FacturaAplica == null) return false;
            return FacturaAplica.IndexOf(idFactura) != -1;
        }
        private void tsVolver_BotonClick(object sender, EventArgs e)
        {
            if (FacturaAplica == null || FacturaAplica.Count == 0)
            {
                var r = MessageBox.Show(@"No Ha Seleccionado Ningun Documento ni Agregado Ningun Importe para Bonificar" + Environment.NewLine +"Desea Regresar de todas formas a la pantalla anterior?",
                    @"Sin Documentos Seleccionados",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    this.Close();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                else
                {
                    return;
                }
            }
            if (FacturaAplica.Count > 1)
            {
                //Se agrega Periodo Asociado
                _nc.SetPeriodoAsociado(FechaAplicaDesde.Value, FechaAplicaHasta.Value);
            }
            else
            {
                _nc.SetDocumentoAsociado(_idFacturaSeleccionada);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private void c1DescuentoPeso_Validated(object sender, EventArgs e)
        {
            //c3PrecioUNC.SetValue = c1DescuentoPeso.GetValueDecimal;
            c1DescuentoPorcentaje.SetValue = c1DescuentoPeso.GetValueDecimal / c1ImporteBruto.GetValueDecimal;
            txtDescripcionItemNC.Text =
                $"Descuento Cond. Especial {c1DescuentoPorcentaje.GetValueDecimal.ToString("P2")} S/Doc# {_recordSelected.TIPO_DOC}|{txtNumeroDocumento.Text}";
        }
        private void c1DescuentoPorcentaje_Validated(object sender, EventArgs e)
        {
            c1DescuentoPeso.SetValue = c1ImporteBruto.GetValueDecimal * c1DescuentoPorcentaje.GetValueDecimal;
            //c3PrecioUNC.SetValue = c1DescuentoPeso.GetValueDecimal;
            txtDescripcionItemNC.Text =
                $"Descuento Cond. Especial {c1DescuentoPorcentaje.GetValueDecimal.ToString("P2")} S/Doc# {_recordSelected.TIPO_DOC}|{txtNumeroDocumento.Text}";
        }

 
    }
}
