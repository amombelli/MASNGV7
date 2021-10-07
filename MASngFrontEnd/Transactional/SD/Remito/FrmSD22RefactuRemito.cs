using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmSD22RefactuRemito : Form
    {
        private readonly int _idRemitoOri;
        private string _tipoNew;
        private RemitoStatusManager.StatusHeader _statusRemitoNew;
        private List<T0057_REMITO_I_PRINT> _dataPrint;
        private T0055_REMITO_H _headerNew = new T0055_REMITO_H();
        private List<T0056_REMITO_I> _listNew = new List<T0056_REMITO_I>();
        private string _remitoSuc;
        private string _remitoNum;
        public int _idRemitoNew { get; private set; }
        public string numeroRemitoNew { get; private set; }

        public FrmSD22RefactuRemito(int idRemitoOri)
        {
            _idRemitoOri = idRemitoOri;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!CheckNumeroRemitoIsOk())
                return;

            var resp = MessageBox.Show($@"El Sistema esta listo para generar el Remito #{txtNumRemitoNew.Text}. Desea Continuar?",
                @"Generacion/Impresion de Remito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            _headerNew.NUMREMITO = txtNumRemitoNew.Text;
            if (cFechaRemitoNew.Value == null)
                cFechaRemitoNew.Value = DateTime.Today;
            _headerNew.FECHA = cFechaRemitoNew.Value.Value;
            _headerNew.OBSERVACION_REM = txtObservacionRemito.Text;

            _idRemitoNew = new ReRemision().GeneraRemitoHeaderFromCopyInvertLx(_headerNew);
            if (_idRemitoNew != 0)
            {
                _headerNew.IDREMITO = _idRemitoNew;
                _statusRemitoNew = RemitoStatusManager.StatusHeader.Generado;
                txtStatusRemitoNew.Text = _statusRemitoNew.ToString();
                var itemsGenerados = new ReRemision().GeneraRemitoItemsFromCopy(_listNew, _idRemitoNew);
                new ReRemision().GeneraRemitoItemsPrintFromCopy(_dataPrint, _idRemitoNew);

                MessageBox.Show(@"El Remito se ha Generado Correctamente", @"Generacion de Remito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int numeroRemito;


            bool result = Int32.TryParse(_remitoNum, out numeroRemito);
            if (result)
            {
                new RemitoGeneracionImpresion().UpdateUltimoNumeroRemitoUtilizado(_remitoNum, txtLxNew.Text);
            }
            else
            {
                MessageBox.Show(
                    @"Atencion, este numero de Remito no ha sido actualizado en el sistema como Ultimo Numero de Remito",
                    @"Ultimo numero de Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            new RemitoGeneracionImpresion().SetRemitoToStatusImpreso(_idRemitoNew, txtNumRemitoNew.Text);
        }

        private bool CheckNumeroRemitoIsOk()
        {
            if (_tipoNew == @"L1")
            {
                if (txtNumRemitoNew.Text.Contains("X") || txtNumRemitoNew.Text.Contains("x"))
                {
                    MessageBox.Show(
                        @"El Numero de Remito es Incorrecto. Confirme el Numero y Retire la 'X' para continuar",
                        @"Validacion de Numero Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                    return false;
                }
            }

            _remitoNum = txtNumRemitoNew.Text.Substring(5);

            if (new RemitoGeneracionImpresion().CheckIfRemitoNumberExist(_remitoSuc, _remitoNum, _tipoNew))
            {
                MessageBox.Show(
                    @"El Numero de Remito se encuentra Duplicado.- Verifique el numero e intente nuevamente",
                    @"# Remito Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_tipoNew == @"L1")
            {
                txtNumRemitoNew.Text = _remitoSuc + @"-" + (_remitoNum).PadLeft(8, '0');
            }
            else
            {
                txtNumRemitoNew.Text = _remitoSuc + @"-" + _remitoNum;
            }
            return true;
        }

        private void FrmSD22RefactuRemito_Load(object sender, EventArgs e)
        {
            var remOri = new RemitoGeneracionImpresion().GetRemitoHeader(_idRemitoOri);
            txtNumRemitoOri.Text = remOri.NUMREMITO;
            txtLxOri.Text = remOri.TIPO_REMITO;
            _tipoNew = txtLxOri.Text == @"L1" ? @"L2" : @"L1";
            txtLxNew.Text = _tipoNew;
            txtStatusRemitoOri.Text = remOri.StatusRemito;
            _statusRemitoNew = RemitoStatusManager.StatusHeader.Inicial;
            txtStatusRemitoNew.Text = _statusRemitoNew.ToString();

            _listNew = new RemitoGeneracionImpresion().GetItemsRemito56(_idRemitoOri);
            _dataPrint = new RemitoGeneracionImpresion().GetDataItemRemito(_idRemitoOri);
            _remitoNum = new RemitoGeneracionImpresion().DefineNumeroRemito(txtLxNew.Text);
            _remitoSuc = new RemitoGeneracionImpresion().DefineSucursalRemito(txtLxNew.Text);

            foreach (var ix in _dataPrint)
            {
                ix.IDITEM = 0;
                ix.IDREMITO = 0;
                ix.NUMREMITO = "";
            }

            if (_tipoNew == @"L1")
            {
                _remitoNum = _remitoNum.Remove(_remitoNum.Length - 1, 1);
                txtNumRemitoNew.Text = _remitoSuc + @"-" + (_remitoNum + "X").PadLeft(8, '0');
            }
            else
            {
                txtNumRemitoNew.Text = _remitoSuc + @"-" + _remitoNum;
            }
            t0057REMITOIPRINTBindingSource.DataSource = _dataPrint;
            numeroRemitoNew = txtNumRemitoNew.Text;
            PreparaDataRemitoHeader();

        }


        private void PreparaDataRemitoHeader()
        {
            _headerNew = new RemitoGeneracionImpresion().GetRemitoHeader(_idRemitoOri);
            _headerNew.StatusRemito = _statusRemitoNew.ToString();
            _headerNew.NUMREMITO = null;
            _headerNew.TIPO_REMITO = txtLxNew.Text;
            _headerNew.FACTPEND = true;
            _headerNew.FECHA = DateTime.Today;
            _headerNew.Factura = null;
            _headerNew.IDREMITO = 0;
            _headerNew.Impreso = false;
            _headerNew.NUMFACTURA = null;
            _headerNew.RLINK = null;
            _headerNew.OBSERVACION_REM = null;
        }

        private void txtNumRemitoNew_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckNumeroRemitoIsOk())
            {
                //MessageBox.Show(@"Para poder continuar debe proveer un numero de remito valido",
                //    @"Error en numero de Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
