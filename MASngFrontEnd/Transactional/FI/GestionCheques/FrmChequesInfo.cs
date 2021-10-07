using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.GestionCheques
{
    /// <summary>
    /// FC003
    /// </summary>
    public partial class FrmChequesInfo : Form
    {
        public FrmChequesInfo(int modo = 1)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CHINFO", "CHINFO", true, true)) return;
            //var f = new FrmQM02NelMainData(1);
            //f.Show();
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------
        private List<T0154_CHEQUES> _lcheques = new List<T0154_CHEQUES>();
        private int? _idCliente = null;
        private int _tipoChequeLx;  //0,1,2,3 LX
        private int _topRecords;
        private decimal _importeDesde;
        private decimal _importeHasta;
        private int _idChequeSeleccion = 0; //Sin Datos =0
#pragma warning disable CS0414 // The field 'FrmChequesInfo.MaxImporte' is assigned but its value is never used
        private decimal MaxImporte = 9999999;
#pragma warning restore CS0414 // The field 'FrmChequesInfo.MaxImporte' is assigned but its value is never used
        private int _busquedaLevel = 0; //1 Cliente, 2 NumeroCheque, 3 IDCheque, 4=CUIT
        //-----------------------------------------------------------------------------------------------------------

        private void FrmChequesInfo_Load(object sender, EventArgs e)
        {
            //Configuracion incial de pantalla y valores default


            ConfiguraScreen();
        }

        private void ActivaCheckBoxAction(bool valor)
        {
            if (valor)
            {
                this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
                this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
                this.ckNoDisponible.CheckedChanged += new System.EventHandler(this.ckDisponible_CheckedChanged);
                this.ckDisponible.CheckedChanged += new System.EventHandler(this.ckDisponible_CheckedChanged);
                this.ckRechazado.CheckedChanged += new System.EventHandler(this.ckRechazado_CheckedChanged);
                this.ckNoRechazado.CheckedChanged += new System.EventHandler(this.ckRechazado_CheckedChanged);
            }
            else
            {
                this.ckL1.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
                this.ckL2.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
                this.ckNoDisponible.CheckedChanged -= new System.EventHandler(this.ckDisponible_CheckedChanged);
                this.ckDisponible.CheckedChanged -= new System.EventHandler(this.ckDisponible_CheckedChanged);
                this.ckRechazado.CheckedChanged -= new System.EventHandler(this.ckRechazado_CheckedChanged);
                this.ckNoRechazado.CheckedChanged -= new System.EventHandler(this.ckRechazado_CheckedChanged);
            }
        }

        private void ConfiguraScreen()
        {
            ActivaCheckBoxAction(false);

            _topRecords = 1000;
            _importeDesde = 0;
            _importeHasta = 9999999;
            _tipoChequeLx = 0;

            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo();
            cmbCliente.SelectedIndex = -1;
            rbRazonSocial.Checked = true;
            ckDisponible.Checked = true;

            txtTop.Text = @"1000";
            txtImporteDesde.Text = 0.ToString("C2");
            txtImporteHasta.Text = 9999999.ToString("C2");

            ActivaCheckBoxAction(true);
            rbFechaAcred.Checked = true;

            dtpFechaDesde.Value = DateTime.Today.AddDays(-60);
            dtpFechaHasta.Value = DateTime.Today.AddDays(366);
        }
        private void rbRazonSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRazonSocial.Checked)
            {
                cmbCliente.DisplayMember = "cli_rsocial";
            }
            else
            {
                cmbCliente.DisplayMember = "cli_fantasia";
            }
        }


        //Filtros NIVEL 1
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            _busquedaLevel = 1; //Busqueda por Cliente
            ckL1.Enabled = true;
            ckL2.Enabled = true;
            ckDisponible.Enabled = true;
            ckNoDisponible.Enabled = true;
            ckRechazado.Enabled = true;
            ckNoRechazado.Enabled = true;

            if (cmbCliente.SelectedValue == null)
            {
                //Trae cheques de todos los clientes!
                txtIdCliente.Text = null;
                _idCliente = null;
            }
            else
            {
                txtIdCliente.Text = cmbCliente.SelectedValue.ToString();
                _idCliente = Convert.ToInt32(txtIdCliente.Text);
            }

            BusquedaLevel();
        }
        private void txtNumeroCheque_KeyUp(object sender, KeyEventArgs e)
        {
            ActivaCheckBoxAction(false);
            _busquedaLevel = 2;
            ckL1.Enabled = false;
            ckL2.Enabled = false;
            ckDisponible.Enabled = true;
            ckNoDisponible.Enabled = true;
            ckRechazado.Enabled = false;
            ckNoRechazado.Enabled = false;
            ckL1.Checked = false;
            ckL2.Checked = false;
            ckRechazado.Checked = false;
            ckNoRechazado.Checked = false;

            var data = (MaskedTextBox)sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                _lcheques = new List<T0154_CHEQUES>();
                t0154CHEQUESBindingSource.DataSource = _lcheques;
                return;
            }
            BusquedaLevel();
            ActivaCheckBoxAction(true);
        }
        private void txtIdChequeNew_KeyUp(object sender, KeyEventArgs e)
        {
            ActivaCheckBoxAction(false);
            _busquedaLevel = 3;
            ckL1.Enabled = false;
            ckL2.Enabled = false;
            ckDisponible.Enabled = false;
            ckNoDisponible.Enabled = false;
            ckRechazado.Enabled = false;
            ckNoRechazado.Enabled = false;


            ckL1.Checked = false;
            ckL2.Checked = false;
            ckRechazado.Checked = false;
            ckNoRechazado.Checked = false;
            ckDisponible.Checked = false;
            ckNoDisponible.Checked = false;

            var data = (TextBox)sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                _lcheques = new List<T0154_CHEQUES>();
                t0154CHEQUESBindingSource.DataSource = _lcheques;
                return;
            }

            _idChequeSeleccion = Convert.ToInt32(data.Text);
            BusquedaLevel();
            ActivaCheckBoxAction(true);
        }
        private void txtNumeroCuit_KeyUp(object sender, KeyEventArgs e)
        {
            ActivaCheckBoxAction(false);
            _busquedaLevel = 4;
            ckL1.Enabled = false;
            ckL2.Enabled = false;
            ckL1.Checked = false;
            ckL2.Checked = false;
            ckDisponible.Enabled = true;
            ckNoDisponible.Enabled = true;
            ckRechazado.Enabled = true;
            ckNoRechazado.Enabled = true;

            if (txtNumeroCuit.MaskCompleted)
            {

            }
            else
            {
                //la mascara de cuit no esta completa - deja la lista vacia
                if (_lcheques.Count == 0)
                    return;
                _lcheques = new List<T0154_CHEQUES>();
                t0154CHEQUESBindingSource.DataSource = _lcheques;
                return;
            }
            BusquedaLevel();
            ActivaCheckBoxAction(true);
        }






        private void BusquedaLevel()
        {


            switch (_busquedaLevel)
            {
                case 1:
                    //Busqueda por Cliente
                    grpTipoCliente.BackColor = Color.LightBlue;
                    panNumeroCheque.BackColor = Color.LightGray;
                    panIdCheque.BackColor = Color.LightGray;
                    panCuitFirmante.BackColor = Color.LightGray;

                    txtNumeroCheque.Text = null;
                    txtIdChequeNew.Text = null;
                    txtNumeroCuit.Text = null;

                    //Default values if NULL
                    if (ckL1.Checked == false && ckL2.Checked == false)
                    {
                        ckL1.Checked = true; //Accion Default
                    }

                    if (ckDisponible.Checked == false && ckNoDisponible.Checked == false)
                    {
                        ckDisponible.Checked = true; //Accion Default;
                    }

                    if (ckNoRechazado.Checked == false && ckRechazado.Checked == false)
                    {
                        ckNoRechazado.Checked = true; //Accion Default;
                    }

                    _lcheques = new ChequesManager().GetListaChequesGenerico01(_idCliente,
                        "L" + _tipoChequeLx, ckDisponible.Checked, ckNoDisponible.Checked, _topRecords, _importeDesde,
                        _importeHasta, ckNoRechazado.Checked, ckRechazado.Checked);

                    break;

                case 2:
                    //Busqueda por numero de cheque
                    grpTipoCliente.BackColor = Color.LightGray;
                    panNumeroCheque.BackColor = Color.LightBlue;
                    panIdCheque.BackColor = Color.LightGray;
                    panCuitFirmante.BackColor = Color.LightGray;

                    cmbCliente.SelectedIndex = -1;
                    txtIdChequeNew.Text = null;
                    txtNumeroCuit.Text = null;

                    //Default values if NULL

                    if (ckDisponible.Checked == false && ckNoDisponible.Checked == false)
                    {
                        ckDisponible.Checked = true; //Accion Default;
                    }

                    _lcheques = new ChequesManager().GetListaChequesNumeroCheque(txtNumeroCheque.Text,
                        ckDisponible.Checked,
                        ckNoDisponible.Checked);

                    break;

                case 3:
                    //Busqueda por IdCheque
                    grpTipoCliente.BackColor = Color.LightGray;
                    panNumeroCheque.BackColor = Color.LightGray;
                    panIdCheque.BackColor = Color.LightBlue;
                    panCuitFirmante.BackColor = Color.LightGray;

                    cmbCliente.SelectedIndex = -1;
                    txtNumeroCheque.Text = null;
                    txtNumeroCuit.Text = null;
                    //Default values if NULL
                    //All is locked
                    var ch = new ChequesManager().GetCheque(_idChequeSeleccion);
                    if (ch == null)
                    {
                        _lcheques = null;
                    }
                    else
                    {
                        _lcheques = new List<T0154_CHEQUES> { ch };
                    }
                    break;

                case 4:
                    //Busqueda por CUIT Firmante
                    grpTipoCliente.BackColor = Color.LightGray;
                    panNumeroCheque.BackColor = Color.LightGray;
                    panIdCheque.BackColor = Color.LightGray;
                    panCuitFirmante.BackColor = Color.LightBlue;

                    cmbCliente.SelectedIndex = -1;
                    txtNumeroCheque.Text = null;
                    txtIdChequeNew.Text = null;


                    //Default values if NULL

                    if (ckDisponible.Checked == false && ckNoDisponible.Checked == false)
                    {
                        ckDisponible.Checked = true; //Accion Default;
                    }

                    if (ckNoRechazado.Checked == false && ckRechazado.Checked == false)
                    {
                        ckNoRechazado.Checked = true; //Accion Default;
                    }

                    _lcheques = new ChequesManager().GetListaChequesPorCUIT(txtNumeroCuit.Text, ckDisponible.Checked, ckNoDisponible.Checked, ckRechazado.Checked, ckNoRechazado.Checked);
                    break;
                default:

                    break;
            }

            //re-filtra por fecha acred!
            if (_lcheques == null)
                return;

            _lcheques =
                _lcheques.Where(
                    c => c.CHE_FECHA >= dtpFechaDesde.Value && c.CHE_FECHA <= dtpFechaHasta.Value).ToList();




            //Orden
            if (rbFechaAcred.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.CHE_FECHA).ToList();
            }
            else if (rbImporte.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.IMPORTE).ToList();
            }
            else if (rbIdCheque.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.IDCHEQUE).ToList();
            }

            t0154CHEQUESBindingSource.DataSource = _lcheques;
            if (_lcheques == null)
            {
                txtCantidadChequesLista.Text = 0.ToString();
                txtNumeroRechazos.Text = 0.ToString();
                txtImporteChequesLista.Text = 0.ToString();
            }
            else
            {
                if (_lcheques.Count == 0)
                {
                    txtCantidadChequesLista.Text = 0.ToString();
                    txtNumeroRechazos.Text = 0.ToString();
                    txtImporteChequesLista.Text = 0.ToString();
                }
                else
                {
                    txtCantidadChequesLista.Text = _lcheques.Count.ToString();
                    var lrech = _lcheques.Where(c => c.CH_RECH == true).ToList();
                    if (lrech.Count == 0)
                    {
                        txtNumeroRechazos.Text = 0.ToString();
                    }
                    else
                    {
                        txtNumeroRechazos.Text = lrech.Count().ToString();
                    }
                    txtImporteChequesLista.Text = _lcheques.Sum(c => c.IMPORTE.Value).ToString("C2");
                }
            }
        }






        #region Activacion-Desactivacion de Filtros Secundarios

        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            _tipoChequeLx = 0;
            if (ckL1.Checked)
                _tipoChequeLx = 1;
            if (ckL2.Checked)
                _tipoChequeLx = _tipoChequeLx + 2;

            BusquedaLevel();
        }
        private void ckDisponible_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNoDisponible.Checked == false)
            {
                ckRechazado.Checked = false;
                ckRechazado.Enabled = false;
            }
            else
            {
                ckRechazado.Enabled = true;
            }

            BusquedaLevel();
        }
        private void ckRechazado_CheckedChanged(object sender, EventArgs e)
        {
            BusquedaLevel();
        }

        #endregion


        private void GetListaFiltrosXCliente()
        {
            _lcheques = new ChequesManager().GetListaChequesGenerico01(_idCliente,
                "L" + _tipoChequeLx, ckDisponible.Checked, ckNoDisponible.Checked, _topRecords, _importeDesde,
                _importeHasta);

            t0154CHEQUESBindingSource.DataSource = _lcheques;
            if (_lcheques == null)
            {
                txtCantidadChequesLista.Text = "0";
                txtImporteChequesLista.Text = 0.ToString("C2");
            }
            else
            {
                txtCantidadChequesLista.Text = _lcheques.Count.ToString();
                txtImporteChequesLista.Text = _lcheques.Sum(c => c.IMPORTE.Value).ToString("C2");
            }
        }




        #region Formatos

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }



        #endregion

        private void txtTop_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTop.Text))
            {
                _topRecords = 10;
                txtTop.Text = @"10";
            }
            else
            {
                _topRecords = Convert.ToInt32(txtTop.Text);
            }
            GetListaFiltrosXCliente();
        }

        private void txtImporteDesde_Validated(object sender, EventArgs e)
        {
            GetListaFiltrosXCliente();
        }

        private void txtImporteDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteDesde_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = 0.ToString("C2");
            }
            _importeDesde = FormatAndConversions.CCurrencyADecimal(txtImporteDesde.Text);
            _importeHasta = FormatAndConversions.CCurrencyADecimal(txtImporteHasta.Text);
            txtImporteDesde.Text = _importeDesde.ToString("C2");
            txtImporteHasta.Text = _importeHasta.ToString("C2");
        }


        private void txtIdChequeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void rbIdCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (_lcheques == null)
                return;

            if (_lcheques.Count == 0)
                return;
            //Orden
            if (rbFechaAcred.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.CHE_FECHA).ToList();
            }
            else if (rbImporte.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.IMPORTE).ToList();
            }
            else if (rbIdCheque.Checked)
            {
                t0154CHEQUESBindingSource.DataSource = _lcheques.OrderBy(c => c.IDCHEQUE).ToList();
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            //cuando cambia la fecha de acreditacion
            BusquedaLevel();
            ///
        }


    }
}
