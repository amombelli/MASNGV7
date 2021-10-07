using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm32DetallePlanInspeccion : Form
    {
        public FrmQm32DetallePlanInspeccion(int idRi, int counterH2)
        {
            this._idRi = idRi;
            _counterH2 = counterH2;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        private readonly int _idRi;
        private readonly int _counterH2;
        private int _counterDetail;
        private bool _metodoAprobado;
        private string _valorMedido;
        //------------------------------------------------------------------------------
        private void LoadData()
        {
            txtRi.Text = _idRi.ToString();
            txtIdCounter.Text = _counterH2.ToString();
            var dataH2 = new QmRegistroInspeccionH1H2().GetRegistroH2(_idRi, _counterH2);
            txtLote.Text = dataH2.Lote;
            var dataH1 = new QmRegistroInspeccionH1H2().GetRegistroH1(_idRi);
            txtLotePadre.Text = dataH1.Lote;
            txtPlanName.Text = dataH2.IdPlan;
            txtIplanDescription.Text = new QmMasterIplan().GetPlanHeader(dataH2.IdPlan).DESCRIPCION;
            ckPlanEditado.Checked = dataH2.PlanEditado;
            txtMaterial.Text = dataH2.Material;
            txtLote.Text = dataH2.Lote;
            txtKgInspeccion.Text = dataH2.KGInspeccion.ToString("N2");
            txtStatusPlan.Text = dataH2.EstadoInspeccion;
            var estadoPlan = new QmInspectionStatus().MapFromText(txtStatusPlan.Text);

            if (dataH2.AprobadoDudoso)
            {
                ckAprobacionDudosa.Checked = true;
                ckAprobacionDudosa.BackColor = Color.OrangeRed;
            }
            else
            {
                if (estadoPlan == QmInspectionStatus.StatusIRecord.Aprobado)
                {
                    ckAprobacionDudosa.BackColor = Color.GreenYellow;
                }
            }
            txtFechaIngreso.Text = dataH2.LogDate.Value.ToString("g");
            txtFechaStart.Text = dataH2.FechaInspeccion.ToString("g");
            if (dataH2.FechaCierre != null)
                txtFechaFinish.Text = dataH2.FechaCierre.Value.ToString("g");

            txtResponsableCQ.Text = dataH2.ResponsableCQ;
            txtObservacionH2.Text = dataH2.ComentarioH2;

            t0807DetailBs.DataSource =
                new QmRegistroInspeccion().GetDetalleMetodosInInspectionRecord(_idRi, _counterH2);

            var zStatus = new StockManager().GetEstadoLote(txtMaterial.Text, txtLote.Text);
            txtStatusMaterial.Text = zStatus.ToString();
            if (zStatus != StockStatusManager.EstadoLote.Restringido)
            {
                MessageBox.Show(@"El Material no se encuentra restringido.- No se puede operar QM04");
                btnAddMetodo.Enabled = false;
                btnAprobarPlan.Enabled = false;
                btnEliminarMetodo.Enabled = false;
                btnUpdateAnalisis.Enabled = false;
                return;
            }

            if (estadoPlan == QmInspectionStatus.StatusIRecord.SinIniciar ||
                estadoPlan == QmInspectionStatus.StatusIRecord.Comenzado)
            {
                EvaluarPlan();
            }

            switch (estadoPlan)
            {
                case QmInspectionStatus.StatusIRecord.SinIniciar:
                    btnAprobarPlan.Enabled = true;
                    break;
                case QmInspectionStatus.StatusIRecord.Comenzado:
                    btnAprobarPlan.Enabled = true;
                    break;
                case QmInspectionStatus.StatusIRecord.Aprobado:
                    btnAprobarPlan.Enabled = false;
                    break;
                case QmInspectionStatus.StatusIRecord.Rechazado:
                    btnAprobarPlan.Enabled = true;
                    break;
                case QmInspectionStatus.StatusIRecord.Cancelado:
                    btnAprobarPlan.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FormatoStatusControl()
        {
            if (string.IsNullOrEmpty(txtStatusMedicion.Text))
            {
                txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Indeterminado.ToString();
                txtStatusMedicion.BackColor = Color.Yellow;
            }

            var status = QmMasterIplan.MapTipoDatoFromText(txtStatusMedicion.Text);
            switch (status)
            {
                case QmMasterIplan.StatusMedicion.Indeterminado:
                    txtStatusMedicion.BackColor = Color.Yellow;
                    txtStatusMedicion.ForeColor = Color.Black;
                    green.Visible = false;
                    red.Visible = true;
                    break;
                case QmMasterIplan.StatusMedicion.Aprobado:
                    txtStatusMedicion.BackColor = Color.DarkSeaGreen;
                    txtStatusMedicion.ForeColor = Color.DarkBlue;
                    green.Visible = true;
                    red.Visible = false;
                    break;
                case QmMasterIplan.StatusMedicion.NoAprobado:
                    txtStatusMedicion.BackColor = Color.DarkOrange;
                    txtStatusMedicion.ForeColor = Color.Red;
                    green.Visible = false;
                    red.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void BtnSplitRegistro_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm33SplitRegistroInspeccion(_idRi, _counterH2))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show(@"Se ha cancelado el SPLIT del Registro de Inspeccion", @"Accion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DgvIP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }

            _counterDetail =
                Convert.ToInt32(dgv[dgv.Columns[idcounterdetail.Name].Index, e.RowIndex]
                    .Value);
            var data = new QmRegistroInspeccion().GetSpecificMetodoInInspectionRecord(_idRi, _counterH2,
                _counterDetail);
            txtCounter.Text = _counterDetail.ToString();
            //
            var metodo = new QmManageList().GetMetodo(data.Metodo);
            txtIdCaracteristica.Text = metodo.IdMetodo;
            txtUoM.Text = metodo.ValorUnit;
            txtDataType.Text = metodo.ValorType;
            txtCaracteristica.Text = metodo.Descripcion;
            //
            txtValorMin.Text = data.ValorMin;
            txtValorMax.Text = data.ValorMax;
            txtValorStd.Text = data.ValorStd;
            _valorMedido = data.ValorMedido;
            _metodoAprobado = data.CQAprobado;
            //txtStatusMedicion.Text = data.Resultado;
            if (data.FechaResultado != null)
                txtFechaInspeccion.Text = DateTime.Today.ToString("d");
            txtRespInspeccion.Text = data.UserLog;
            txtObservacion.Text = data.ComentarioDetail;

            ConfiguraValorMedicionLab(data.ValorMedido, data.CQAprobado);
            txtStatusMedicion.Text = data.Resultado;
            FormatoStatusControl();
            ckRegistroAgregado.Checked = Convert.ToBoolean(dgv[dgv.Columns[MetodoAdded.Name].Index, e.RowIndex].Value);
            if (ckRegistroAgregado.Checked)
            {
                txtValorMax.ReadOnly = false;
                txtValorMin.ReadOnly = false;
                txtValorStd.ReadOnly = false;
            }
            else
            {
                txtValorMax.ReadOnly = true;
                txtValorMin.ReadOnly = true;
                txtValorStd.ReadOnly = true;
            }
        }

        private void ConfiguraValorMedicionLab(string valorMedido, bool cqAprobado)
        {
            txtValorMedicion.Visible = false;
            grpMedicion.Visible = false;
            txtValorMedicion.Text = null;
            rb1.Checked = false;
            rb2.Checked = false;

            var tipoDato = QmMetodoDataType.MapTipoDatoFromText(txtDataType.Text);
            switch (tipoDato)
            {
                case QmMetodoDataType.TipoDato.Decimal:
                    txtValorMedicion.Visible = true;
                    txtValorMedicion.Text = valorMedido;
                    break;
                case QmMetodoDataType.TipoDato.Entero:
                    txtValorMedicion.Visible = true;
                    txtValorMedicion.Text = valorMedido;
                    break;
                case QmMetodoDataType.TipoDato.Si_No:
                    grpMedicion.Visible = true;
                    rb1.Text = @"Si";
                    rb2.Text = @"No";

                    if (valorMedido != null)
                    {
                        if (cqAprobado)
                        {
                            rb1.Checked = true;
                        }
                        else
                        {
                            rb2.Checked = true;
                        }
                    }

                    break;
                case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                    grpMedicion.Visible = true;
                    rb1.Text = @"Correcto";
                    rb2.Text = @"Incorrecto";
                    if (valorMedido != null)
                    {
                        if (cqAprobado)
                        {
                            rb1.Checked = true;
                        }
                        else
                        {
                            rb2.Checked = true;
                        }
                    }

                    break;
                case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                    grpMedicion.Visible = true;
                    rb1.Text = @"Aprobado";
                    rb2.Text = @"Rechazado";
                    if (valorMedido != null)
                    {
                        if (cqAprobado)
                        {
                            rb1.Checked = true;
                        }
                        else
                        {
                            rb2.Checked = true;
                        }
                    }

                    break;
                case QmMetodoDataType.TipoDato.TextoLibre:
                    txtValorMedicion.Visible = true;
                    txtValorMedicion.Text = valorMedido;
                    break;
                case QmMetodoDataType.TipoDato.True_False:
                    grpMedicion.Visible = true;
                    rb1.Text = @"Verdadero";
                    rb2.Text = @"Falso";
                    if (valorMedido != null)
                    {
                        if (cqAprobado)
                        {
                            rb1.Checked = true;
                        }
                        else
                        {
                            rb2.Checked = true;
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TxtValorMedicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tipoDato = QmMetodoDataType.MapTipoDatoFromText(txtDataType.Text);
            switch (tipoDato)
            {
                case QmMetodoDataType.TipoDato.Decimal:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e);
                    break;
                case QmMetodoDataType.TipoDato.Entero:
                    FormatAndConversions.SoloEnteroKeyPress(sender, e);
                    break;
                case QmMetodoDataType.TipoDato.Si_No:
                    break;
                case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                    break;
                case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                    break;
                case QmMetodoDataType.TipoDato.TextoLibre:
                    break;
                case QmMetodoDataType.TipoDato.True_False:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void BtnAddMetodo_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm06AddMetodoToPlan(_idRi, _counterH2))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }

                t0807DetailBs.DataSource =
                    new QmRegistroInspeccion().GetDetalleMetodosInInspectionRecord(_idRi, _counterH2);
            }
        }

        private void BtnEliminarMetodo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCaracteristica.Text))
            {
                MessageBox.Show(@"Se debe seleccionar un Metodo de Inspeccion para eliminar", @"Eliminacion de METIP",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resp = new QmMasterData().DeleteMetodoToInspeccionId(_idRi, txtIdCaracteristica.Text);
            if (resp == false)
            {
                MessageBox.Show(
                    @"No se ha podido eliminar el metodo de inspeccion de la Inspeccion debido a que el mismo forma parte del Plan Standard.",
                    @"Error en Eliminacion del Metodo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            t0807DetailBs.DataSource =
                new QmRegistroInspeccion().GetDetalleMetodosInInspectionRecord(_idRi, _counterH2);
        }

        private void Rb1_CheckedChanged(object sender, EventArgs e)
        {
            _metodoAprobado = rb1.Checked;
            var tipoDato = QmMetodoDataType.MapTipoDatoFromText(txtDataType.Text);
            if (_metodoAprobado)
            {
                txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Aprobado.ToString();
                switch (tipoDato)
                {
                    case QmMetodoDataType.TipoDato.Decimal:
                        break;
                    case QmMetodoDataType.TipoDato.Entero:
                        break;
                    case QmMetodoDataType.TipoDato.Si_No:
                        _valorMedido = @"SI";
                        break;
                    case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                        _valorMedido = @"OK";
                        break;
                    case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                        _valorMedido = @"APROBADO";
                        break;
                    case QmMetodoDataType.TipoDato.TextoLibre:
                        break;
                    case QmMetodoDataType.TipoDato.True_False:
                        _valorMedido = @"VERDADERO";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.NoAprobado.ToString();
                switch (tipoDato)
                {
                    case QmMetodoDataType.TipoDato.Decimal:
                        break;
                    case QmMetodoDataType.TipoDato.Entero:
                        break;
                    case QmMetodoDataType.TipoDato.Si_No:
                        _valorMedido = @"NO";
                        break;
                    case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                        _valorMedido = @"INCORRECTO";
                        break;
                    case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                        _valorMedido = @"RECHAZADO";
                        break;
                    case QmMetodoDataType.TipoDato.TextoLibre:
                        break;
                    case QmMetodoDataType.TipoDato.True_False:
                        _valorMedido = @"FALSO";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            FormatoStatusControl();
            txtFechaInspeccion.Text = DateTime.Now.ToString("g");
        }

        private void TxtValorMedicion_Validating(object sender, CancelEventArgs e)
        {
            var tipoDato = QmMetodoDataType.MapTipoDatoFromText(txtDataType.Text);
            switch (tipoDato)
            {
                case QmMetodoDataType.TipoDato.Decimal:
                    if (string.IsNullOrEmpty(txtValorMedicion.Text))
                    {
                        _metodoAprobado = false;
                        txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Indeterminado.ToString();
                        _valorMedido = null;
                    }
                    else
                    {
                        _valorMedido = txtValorMedicion.Text;
                        decimal valor = Convert.ToDecimal(txtValorMedicion.Text);

                        if (string.IsNullOrEmpty(txtValorMin.Text))
                            txtValorMin.Text = 0.ToString("n2");

                        if (string.IsNullOrEmpty(txtValorMax.Text))
                            txtValorMax.Text = 0.ToString("n2");

                        if ((valor >= Convert.ToDecimal(txtValorMin.Text)) &&
                            (valor <= Convert.ToDecimal(txtValorMax.Text)))
                        {
                            _metodoAprobado = true;
                            txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Aprobado.ToString();
                        }
                        else
                        {
                            _metodoAprobado = false;
                            txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.NoAprobado.ToString();
                        }
                    }

                    break;
                case QmMetodoDataType.TipoDato.Entero:
                    if (string.IsNullOrEmpty(txtValorMedicion.Text))
                    {
                        _metodoAprobado = false;
                        txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Indeterminado.ToString();
                        _valorMedido = null;
                    }
                    else
                    {
                        _valorMedido = txtValorMedicion.Text;
                        int valor = Convert.ToInt32(txtValorMedicion.Text);

                        if (string.IsNullOrEmpty(txtValorMin.Text))
                            txtValorMin.Text = 0.ToString();

                        if (string.IsNullOrEmpty(txtValorMax.Text))
                            txtValorMax.Text = 0.ToString();


                        if ((valor >= Convert.ToInt32(txtValorMin.Text)) &&
                            (valor <= Convert.ToInt32(txtValorMax.Text)))
                        {
                            _metodoAprobado = true;
                            txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.Aprobado.ToString();
                        }
                        else
                        {
                            _metodoAprobado = false;
                            txtStatusMedicion.Text = QmMasterIplan.StatusMedicion.NoAprobado.ToString();
                        }
                    }

                    break;
                case QmMetodoDataType.TipoDato.TextoLibre:

                    break;
                case QmMetodoDataType.TipoDato.Si_No:
                    //No se evalua en el textbox
                    break;
                case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                    //No se evalua en el textbox
                    break;
                case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                    //No se evalua en el textbox
                    break;
                case QmMetodoDataType.TipoDato.True_False:
                    //No se evalua en el textbox
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            FormatoStatusControl();
            txtFechaInspeccion.Text = DateTime.Now.ToString("g");
        }

        private void BtnUpdateAnalisis_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFechaInspeccion.Text))
            {
                var resp = MessageBox.Show(
                    @"El Metodo ya había sido evaluado con anterioridad, desea actualizar el resultado?",
                    @"Actualizacion de Resultado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                var resultadoUpdate = new QmRegistroInspeccion().ActualizaResultadoDetalleMetodo(_idRi, _counterH2,
                    _counterDetail,
                    _valorMedido, txtStatusMedicion.Text, _metodoAprobado, txtRespInspeccion.Text,
                    txtObservacion.Text);
                if (resultadoUpdate)
                {
                    MessageBox.Show(@"El Resultado del metodo de inspeccion se ha actualizado correctamente",
                        @"Resultado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFechaInspeccion.Text = DateTime.Today.ToString("g");
                }
                else
                {
                    MessageBox.Show(@"No se ha actualizado ningún resultado",
                        @"Resultado NO Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                t0807DetailBs.DataSource =
                    new QmRegistroInspeccion().GetDetalleMetodosInInspectionRecord(_idRi, _counterH2);

                if (uCkAutoEvaluate.Value)
                {
                    EvaluarPlan();
                }
            }
        }


        private void EvaluarPlan()
        {
            var resultadoPlan = new QmRegistroInspeccion().AutoEvaluate(_idRi, _counterH2);
            if (resultadoPlan == QmInspectionStatus.StatusIRecord.Rechazado)
            {
                var resp = MessageBox.Show(
                    @"Atencion: Los valores de Inspeccion determinan que el plan no se encuentra aprobado. Desea Continuar colocando el material como FE?",
                    @"Plan no Aprobado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
            }
            txtStatusPlan.Text = resultadoPlan.ToString();
            new QmInspectionStatus().UpdateStatusH2Normal(_idRi, _counterH2, resultadoPlan);
            if (resultadoPlan == QmInspectionStatus.StatusIRecord.Aprobado)
            {
                ckAprobacionDudosa.Checked = false;
                ckAprobacionDudosa.BackColor = Color.GreenYellow;
                new StockManager().ChangeStatusFromRestringido(txtMaterial.Text, txtLote.Text, StockStatusManager.EstadoLote.Liberado, txtObservacionH2.Text);
                return;
            }

            if (resultadoPlan == QmInspectionStatus.StatusIRecord.Rechazado)
            {
                MessageBox.Show(@"El Material se encuentra Fuera de Especificacion", @"Material FE",
                    MessageBoxButtons.OK);
                new StockManager().ChangeStatusFromRestringido(txtMaterial.Text, txtLote.Text, StockStatusManager.EstadoLote.FE, txtObservacionH2.Text);
            }
        }

        private void FrmQm32DetallePlanInspeccion_Load(object sender, EventArgs e)
        {
            uCkAutoEvaluate.SetLabel(@"Auto Evaluate Inspection Plan");
            uCkAutoEvaluate.SetValor(true);
            LoadData();
        }

        private void BtnAprobarPlan_Click(object sender, EventArgs e)
        {
            var resultadoPlan = new QmRegistroInspeccion().AutoEvaluate(_idRi, _counterH2);
            if (resultadoPlan != QmInspectionStatus.StatusIRecord.Aprobado)
            {
                var resp = MessageBox.Show(
                    @"El Plan no se encuentra en condiciones de definir la APROBACION del material. Desea continuar dejando el material en estado APROBADO C/DUDAS",
                    @"Aprobacion Dudosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;

                new QmInspectionStatus().SetAprobadoDudoso(_idRi, _counterH2, "");
                ckAprobacionDudosa.Checked = true;
                ckAprobacionDudosa.BackColor = Color.OrangeRed;
                txtStatusPlan.Text = QmInspectionStatus.StatusIRecord.Aprobado.ToString();
                new StockManager().ChangeStatusFromRestringido(txtMaterial.Text, txtLote.Text, StockStatusManager.EstadoLote.Liberado, txtObservacionH2.Text);
            }
            else
            {
                ckAprobacionDudosa.Checked = false;
                ckAprobacionDudosa.BackColor = Color.GreenYellow;
                new StockManager().ChangeStatusFromRestringido(txtMaterial.Text, txtLote.Text, StockStatusManager.EstadoLote.Liberado, txtObservacionH2.Text);
            }
        }

        private void BtnPrintCertificado_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"El Certificado AUN NO SE ENCUENTRA DISPONIBLE");
        }

        private void TxtObservacionH2_Validated(object sender, EventArgs e)
        {
            new QmRegistroInspeccionH1H2().UpdateDescripcionH2(_idRi, _counterH2, txtObservacionH2.Text);
        }

        private void TxtValorMin_Leave(object sender, EventArgs e)
        {
            if (ckRegistroAgregado.Checked)
                new QmRegistroInspeccion().UpdateValorMinimoManual(_idRi, _counterH2, _counterDetail, txtValorMin.Text);
        }

        private void TxtValorStd_TextChanged(object sender, EventArgs e)
        {
            if (ckRegistroAgregado.Checked)
                new QmRegistroInspeccion().UpdateValorStandardManual(_idRi, _counterH2, _counterDetail, txtValorStd.Text);
        }

        private void TxtValorMax_TextChanged(object sender, EventArgs e)
        {
            if (ckRegistroAgregado.Checked)
                new QmRegistroInspeccion().UpdateValorMaximoManual(_idRi, _counterH2, _counterDetail, txtValorMax.Text);
        }
    }
}