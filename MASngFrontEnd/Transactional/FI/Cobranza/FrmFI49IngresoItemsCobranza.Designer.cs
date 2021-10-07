namespace MASngFE.Transactional.FI.Cobranza
{
    partial class FrmFI49IngresoItemsCobranza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI49IngresoItemsCobranza));
            this.txtCuentaDescripcion = new System.Windows.Forms.TextBox();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtImporteEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();
            this.panelEfectivo = new System.Windows.Forms.Panel();
            this.panelCheque = new System.Windows.Forms.Panel();
            this.mskFechaAcreditacion = new System.Windows.Forms.MaskedTextBox();
            this.txtDiasAcerditacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBancoDescripcionLong = new System.Windows.Forms.TextBox();
            this.t0160BANCOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtxtCuitCheque = new System.Windows.Forms.MaskedTextBox();
            this.txtBancoDescripcionShort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckChequeInterior = new System.Windows.Forms.CheckBox();
            this.cmbBancoNumero = new System.Windows.Forms.ComboBox();
            this.txtDescripcionCuit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporteCheque = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroCheque = new System.Windows.Forms.TextBox();
            this.panelRetencion = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRetProvincia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRetAlicuota = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImporteRetencion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelTransferencia = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImporteTransferencia = new System.Windows.Forms.TextBox();
            this.ckConexionAfipPadron = new System.Windows.Forms.CheckBox();
            this.btnAddItemPago = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelBono = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtImporteBono = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNumeroBono = new System.Windows.Forms.TextBox();
            this.txtImporteGenearlValidacion = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtChPendientesAcred = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtChRechazados = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtChRecibidos = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ckValidacionCheques = new System.Windows.Forms.CheckBox();
            this.ckIsEcheque = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEfectivo.SuspendLayout();
            this.panelCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0160BANCOSBindingSource)).BeginInit();
            this.panelRetencion.SuspendLayout();
            this.panelTransferencia.SuspendLayout();
            this.panelBono.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCuentaDescripcion
            // 
            this.txtCuentaDescripcion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCuentaDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_DESC", true));
            this.txtCuentaDescripcion.Location = new System.Drawing.Point(212, 3);
            this.txtCuentaDescripcion.Name = "txtCuentaDescripcion";
            this.txtCuentaDescripcion.ReadOnly = true;
            this.txtCuentaDescripcion.Size = new System.Drawing.Size(258, 23);
            this.txtCuentaDescripcion.TabIndex = 0;
            this.txtCuentaDescripcion.TabStop = false;
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "CUENTA ";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCuenta.DataSource = this.t0150CUENTASBindingSource;
            this.cmbCuenta.DisplayMember = "Descripcion2";
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(67, 3);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(144, 23);
            this.cmbCuenta.TabIndex = 0;
            this.cmbCuenta.ValueMember = "ID_CUENTA";
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.cmbCuenta_SelectedIndexChanged);
            this.cmbCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCuenta_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "MONEDA";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMoneda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_MONEDA", true));
            this.txtMoneda.Location = new System.Drawing.Point(67, 27);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(70, 23);
            this.txtMoneda.TabIndex = 4;
            this.txtMoneda.TabStop = false;
            // 
            // txtImporteEfectivo
            // 
            this.txtImporteEfectivo.Location = new System.Drawing.Point(157, 9);
            this.txtImporteEfectivo.Name = "txtImporteEfectivo";
            this.txtImporteEfectivo.Size = new System.Drawing.Size(105, 23);
            this.txtImporteEfectivo.TabIndex = 0;
            this.txtImporteEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImporteEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress_1);
            this.txtImporteEfectivo.Leave += new System.EventHandler(this.txtImporteBono_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "IMPORTE MON ORIGEN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtTipoCuenta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCuentaDescripcion);
            this.panel1.Controls.Add(this.cmbCuenta);
            this.panel1.Controls.Add(this.txtMoneda);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 53);
            this.panel1.TabIndex = 0;
            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoCuenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_TIPO", true));
            this.txtTipoCuenta.Location = new System.Drawing.Point(471, 3);
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.ReadOnly = true;
            this.txtTipoCuenta.Size = new System.Drawing.Size(66, 23);
            this.txtTipoCuenta.TabIndex = 5;
            this.txtTipoCuenta.TabStop = false;
            this.txtTipoCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelEfectivo
            // 
            this.panelEfectivo.BackColor = System.Drawing.Color.Pink;
            this.panelEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEfectivo.Controls.Add(this.label3);
            this.panelEfectivo.Controls.Add(this.txtImporteEfectivo);
            this.panelEfectivo.Location = new System.Drawing.Point(3, 62);
            this.panelEfectivo.Name = "panelEfectivo";
            this.panelEfectivo.Size = new System.Drawing.Size(542, 46);
            this.panelEfectivo.TabIndex = 1;
            // 
            // panelCheque
            // 
            this.panelCheque.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCheque.Controls.Add(this.ckIsEcheque);
            this.panelCheque.Controls.Add(this.mskFechaAcreditacion);
            this.panelCheque.Controls.Add(this.txtDiasAcerditacion);
            this.panelCheque.Controls.Add(this.label11);
            this.panelCheque.Controls.Add(this.txtBancoDescripcionLong);
            this.panelCheque.Controls.Add(this.mtxtCuitCheque);
            this.panelCheque.Controls.Add(this.txtBancoDescripcionShort);
            this.panelCheque.Controls.Add(this.label8);
            this.panelCheque.Controls.Add(this.ckChequeInterior);
            this.panelCheque.Controls.Add(this.cmbBancoNumero);
            this.panelCheque.Controls.Add(this.txtDescripcionCuit);
            this.panelCheque.Controls.Add(this.label7);
            this.panelCheque.Controls.Add(this.label6);
            this.panelCheque.Controls.Add(this.label5);
            this.panelCheque.Controls.Add(this.txtImporteCheque);
            this.panelCheque.Controls.Add(this.label4);
            this.panelCheque.Controls.Add(this.txtNumeroCheque);
            this.panelCheque.Location = new System.Drawing.Point(3, 62);
            this.panelCheque.Name = "panelCheque";
            this.panelCheque.Size = new System.Drawing.Size(542, 143);
            this.panelCheque.TabIndex = 2;
            // 
            // mskFechaAcreditacion
            // 
            this.mskFechaAcreditacion.AsciiOnly = true;
            this.mskFechaAcreditacion.BackColor = System.Drawing.SystemColors.Info;
            this.mskFechaAcreditacion.BeepOnError = true;
            this.mskFechaAcreditacion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFechaAcreditacion.Location = new System.Drawing.Point(140, 43);
            this.mskFechaAcreditacion.Mask = "00/00/0000";
            this.mskFechaAcreditacion.Name = "mskFechaAcreditacion";
            this.mskFechaAcreditacion.Size = new System.Drawing.Size(100, 23);
            this.mskFechaAcreditacion.TabIndex = 2;
            this.mskFechaAcreditacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskFechaAcreditacion.ValidatingType = typeof(System.DateTime);
            this.mskFechaAcreditacion.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskFechaAcreditacion_MaskInputRejected);
            this.mskFechaAcreditacion.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mskFechaAcreditacion_TypeValidationCompleted);
            this.mskFechaAcreditacion.Leave += new System.EventHandler(this.mskFechaAcreditacion_Leave);
            // 
            // txtDiasAcerditacion
            // 
            this.txtDiasAcerditacion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiasAcerditacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_TIPO", true));
            this.txtDiasAcerditacion.Location = new System.Drawing.Point(331, 43);
            this.txtDiasAcerditacion.Name = "txtDiasAcerditacion";
            this.txtDiasAcerditacion.ReadOnly = true;
            this.txtDiasAcerditacion.Size = new System.Drawing.Size(57, 23);
            this.txtDiasAcerditacion.TabIndex = 6;
            this.txtDiasAcerditacion.TabStop = false;
            this.txtDiasAcerditacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(257, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "DIAS ACRED";
            // 
            // txtBancoDescripcionLong
            // 
            this.txtBancoDescripcionLong.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBancoDescripcionLong.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0160BANCOSBindingSource, "BANCO_DESC", true));
            this.txtBancoDescripcionLong.Location = new System.Drawing.Point(243, 92);
            this.txtBancoDescripcionLong.Name = "txtBancoDescripcionLong";
            this.txtBancoDescripcionLong.ReadOnly = true;
            this.txtBancoDescripcionLong.Size = new System.Drawing.Size(282, 23);
            this.txtBancoDescripcionLong.TabIndex = 16;
            this.txtBancoDescripcionLong.TabStop = false;
            // 
            // t0160BANCOSBindingSource
            // 
            this.t0160BANCOSBindingSource.DataSource = typeof(TecserEF.Entity.T0160_BANCOS);
            // 
            // mtxtCuitCheque
            // 
            this.mtxtCuitCheque.BeepOnError = true;
            this.mtxtCuitCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtxtCuitCheque.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtCuitCheque.Location = new System.Drawing.Point(140, 68);
            this.mtxtCuitCheque.Mask = "00-00000000-0";
            this.mtxtCuitCheque.Name = "mtxtCuitCheque";
            this.mtxtCuitCheque.PromptChar = '*';
            this.mtxtCuitCheque.Size = new System.Drawing.Size(100, 23);
            this.mtxtCuitCheque.TabIndex = 4;
            this.mtxtCuitCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtCuitCheque.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtCuitCheque.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mtxtCuitCheque_TypeValidationCompleted);
            this.mtxtCuitCheque.Leave += new System.EventHandler(this.mtxtCuitCheque_Leave);
            this.mtxtCuitCheque.Validated += new System.EventHandler(this.mtxtCuitCheque_Validated);
            // 
            // txtBancoDescripcionShort
            // 
            this.txtBancoDescripcionShort.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBancoDescripcionShort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0160BANCOSBindingSource, "BCO_SHORTDESC", true));
            this.txtBancoDescripcionShort.Location = new System.Drawing.Point(140, 92);
            this.txtBancoDescripcionShort.Name = "txtBancoDescripcionShort";
            this.txtBancoDescripcionShort.ReadOnly = true;
            this.txtBancoDescripcionShort.Size = new System.Drawing.Size(100, 23);
            this.txtBancoDescripcionShort.TabIndex = 15;
            this.txtBancoDescripcionShort.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "BANCO";
            // 
            // ckChequeInterior
            // 
            this.ckChequeInterior.AutoSize = true;
            this.ckChequeInterior.Location = new System.Drawing.Point(401, 45);
            this.ckChequeInterior.Name = "ckChequeInterior";
            this.ckChequeInterior.Size = new System.Drawing.Size(124, 19);
            this.ckChequeInterior.TabIndex = 3;
            this.ckChequeInterior.Text = "CHEQUE INTERIOR";
            this.ckChequeInterior.UseVisualStyleBackColor = true;
            // 
            // cmbBancoNumero
            // 
            this.cmbBancoNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBancoNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBancoNumero.DataSource = this.t0160BANCOSBindingSource;
            this.cmbBancoNumero.DisplayMember = "ID_BANCO";
            this.cmbBancoNumero.FormattingEnabled = true;
            this.cmbBancoNumero.Location = new System.Drawing.Point(62, 92);
            this.cmbBancoNumero.Name = "cmbBancoNumero";
            this.cmbBancoNumero.Size = new System.Drawing.Size(76, 23);
            this.cmbBancoNumero.TabIndex = 5;
            this.cmbBancoNumero.ValueMember = "ID_BANCO";
            this.cmbBancoNumero.SelectedIndexChanged += new System.EventHandler(this.cmbBancoNumero_SelectedIndexChanged);
            this.cmbBancoNumero.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBancoNumero_Validating);
            this.cmbBancoNumero.Validated += new System.EventHandler(this.cmbBancoNumero_Validated);
            // 
            // txtDescripcionCuit
            // 
            this.txtDescripcionCuit.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcionCuit.Location = new System.Drawing.Point(243, 68);
            this.txtDescripcionCuit.Name = "txtDescripcionCuit";
            this.txtDescripcionCuit.ReadOnly = true;
            this.txtDescripcionCuit.Size = new System.Drawing.Size(282, 23);
            this.txtDescripcionCuit.TabIndex = 13;
            this.txtDescripcionCuit.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "CUIT ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "FECHA ACREDITACION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "IMPORTE $";
            // 
            // txtImporteCheque
            // 
            this.txtImporteCheque.Location = new System.Drawing.Point(422, 6);
            this.txtImporteCheque.Name = "txtImporteCheque";
            this.txtImporteCheque.Size = new System.Drawing.Size(103, 23);
            this.txtImporteCheque.TabIndex = 1;
            this.txtImporteCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImporteCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress_1);
            this.txtImporteCheque.Leave += new System.EventHandler(this.txtImporteBono_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "NUMERO CHEQUE";
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.Location = new System.Drawing.Point(140, 6);
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.Size = new System.Drawing.Size(100, 23);
            this.txtNumeroCheque.TabIndex = 0;
            this.txtNumeroCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroCheque.TextChanged += new System.EventHandler(this.txtNumeroCheque_TextChanged);
            this.txtNumeroCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCheque_KeyPress);
            // 
            // panelRetencion
            // 
            this.panelRetencion.BackColor = System.Drawing.Color.SteelBlue;
            this.panelRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRetencion.Controls.Add(this.label14);
            this.panelRetencion.Controls.Add(this.label13);
            this.panelRetencion.Controls.Add(this.txtRetProvincia);
            this.panelRetencion.Controls.Add(this.label12);
            this.panelRetencion.Controls.Add(this.txtRetAlicuota);
            this.panelRetencion.Controls.Add(this.label9);
            this.panelRetencion.Controls.Add(this.txtImporteRetencion);
            this.panelRetencion.Location = new System.Drawing.Point(3, 62);
            this.panelRetencion.Name = "panelRetencion";
            this.panelRetencion.Size = new System.Drawing.Size(542, 88);
            this.panelRetencion.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(306, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "[Bs.As / Misiones / Santa Fe / ....]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "RETENCION PROVINCIA >>";
            // 
            // txtRetProvincia
            // 
            this.txtRetProvincia.Location = new System.Drawing.Point(157, 58);
            this.txtRetProvincia.Name = "txtRetProvincia";
            this.txtRetProvincia.Size = new System.Drawing.Size(143, 23);
            this.txtRetProvincia.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "ALICUOTA %";
            // 
            // txtRetAlicuota
            // 
            this.txtRetAlicuota.Location = new System.Drawing.Point(157, 34);
            this.txtRetAlicuota.Name = "txtRetAlicuota";
            this.txtRetAlicuota.Size = new System.Drawing.Size(57, 23);
            this.txtRetAlicuota.TabIndex = 6;
            this.txtRetAlicuota.Enter += new System.EventHandler(this.txtRetAlicuota_Enter);
            this.txtRetAlicuota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetAlicuota_KeyPress);
            this.txtRetAlicuota.Leave += new System.EventHandler(this.txtRetAlicuota_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "IMPORTE RETENCION";
            // 
            // txtImporteRetencion
            // 
            this.txtImporteRetencion.Location = new System.Drawing.Point(157, 10);
            this.txtImporteRetencion.Name = "txtImporteRetencion";
            this.txtImporteRetencion.Size = new System.Drawing.Size(105, 23);
            this.txtImporteRetencion.TabIndex = 0;
            this.txtImporteRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImporteRetencion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress_1);
            this.txtImporteRetencion.Leave += new System.EventHandler(this.txtImporteBono_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(553, 74);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 44);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Agregar\r\nVolver";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(553, 118);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 44);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Volver\r\nCancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelTransferencia
            // 
            this.panelTransferencia.BackColor = System.Drawing.Color.MistyRose;
            this.panelTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransferencia.Controls.Add(this.label10);
            this.panelTransferencia.Controls.Add(this.txtImporteTransferencia);
            this.panelTransferencia.Location = new System.Drawing.Point(3, 62);
            this.panelTransferencia.Name = "panelTransferencia";
            this.panelTransferencia.Size = new System.Drawing.Size(542, 46);
            this.panelTransferencia.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "IMPORTE TRANSFERENCIA";
            // 
            // txtImporteTransferencia
            // 
            this.txtImporteTransferencia.Location = new System.Drawing.Point(157, 10);
            this.txtImporteTransferencia.Name = "txtImporteTransferencia";
            this.txtImporteTransferencia.Size = new System.Drawing.Size(105, 23);
            this.txtImporteTransferencia.TabIndex = 0;
            this.txtImporteTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImporteTransferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress_1);
            this.txtImporteTransferencia.Leave += new System.EventHandler(this.txtImporteBono_Leave);
            // 
            // ckConexionAfipPadron
            // 
            this.ckConexionAfipPadron.AutoSize = true;
            this.ckConexionAfipPadron.Checked = true;
            this.ckConexionAfipPadron.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckConexionAfipPadron.Location = new System.Drawing.Point(557, 4);
            this.ckConexionAfipPadron.Name = "ckConexionAfipPadron";
            this.ckConexionAfipPadron.Size = new System.Drawing.Size(104, 19);
            this.ckConexionAfipPadron.TabIndex = 17;
            this.ckConexionAfipPadron.Text = "Conexion AFIP";
            this.ckConexionAfipPadron.UseVisualStyleBackColor = true;
            // 
            // btnAddItemPago
            // 
            this.btnAddItemPago.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItemPago.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItemPago.Image")));
            this.btnAddItemPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItemPago.Location = new System.Drawing.Point(553, 30);
            this.btnAddItemPago.Name = "btnAddItemPago";
            this.btnAddItemPago.Size = new System.Drawing.Size(107, 44);
            this.btnAddItemPago.TabIndex = 3;
            this.btnAddItemPago.Text = "Agregar\r\nContinuar";
            this.btnAddItemPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItemPago.UseVisualStyleBackColor = true;
            this.btnAddItemPago.Click += new System.EventHandler(this.btnAddItemPago_Click);
            // 
            // panelBono
            // 
            this.panelBono.BackColor = System.Drawing.Color.Gold;
            this.panelBono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBono.Controls.Add(this.label16);
            this.panelBono.Controls.Add(this.txtImporteBono);
            this.panelBono.Controls.Add(this.label17);
            this.panelBono.Controls.Add(this.txtNumeroBono);
            this.panelBono.Location = new System.Drawing.Point(3, 62);
            this.panelBono.Name = "panelBono";
            this.panelBono.Size = new System.Drawing.Size(542, 39);
            this.panelBono.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(349, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "IMPORTE $";
            // 
            // txtImporteBono
            // 
            this.txtImporteBono.Location = new System.Drawing.Point(422, 6);
            this.txtImporteBono.Name = "txtImporteBono";
            this.txtImporteBono.Size = new System.Drawing.Size(114, 23);
            this.txtImporteBono.TabIndex = 1;
            this.txtImporteBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImporteBono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRetencion_KeyPress_1);
            this.txtImporteBono.Leave += new System.EventHandler(this.txtImporteBono_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 15);
            this.label17.TabIndex = 5;
            this.label17.Text = "NUMERO DE BONO";
            // 
            // txtNumeroBono
            // 
            this.txtNumeroBono.Location = new System.Drawing.Point(140, 6);
            this.txtNumeroBono.Name = "txtNumeroBono";
            this.txtNumeroBono.Size = new System.Drawing.Size(82, 23);
            this.txtNumeroBono.TabIndex = 0;
            this.txtNumeroBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtImporteGenearlValidacion
            // 
            this.txtImporteGenearlValidacion.Enabled = false;
            this.txtImporteGenearlValidacion.Location = new System.Drawing.Point(553, 164);
            this.txtImporteGenearlValidacion.Name = "txtImporteGenearlValidacion";
            this.txtImporteGenearlValidacion.Size = new System.Drawing.Size(107, 23);
            this.txtImporteGenearlValidacion.TabIndex = 8;
            this.txtImporteGenearlValidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txtChPendientesAcred);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtChRechazados);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtChRecibidos);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(3, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 82);
            this.panel2.TabIndex = 19;
            // 
            // txtChPendientesAcred
            // 
            this.txtChPendientesAcred.BackColor = System.Drawing.Color.Gainsboro;
            this.txtChPendientesAcred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_TIPO", true));
            this.txtChPendientesAcred.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChPendientesAcred.Location = new System.Drawing.Point(178, 53);
            this.txtChPendientesAcred.Name = "txtChPendientesAcred";
            this.txtChPendientesAcred.ReadOnly = true;
            this.txtChPendientesAcred.Size = new System.Drawing.Size(57, 23);
            this.txtChPendientesAcred.TabIndex = 22;
            this.txtChPendientesAcred.TabStop = false;
            this.txtChPendientesAcred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(29, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 15);
            this.label19.TabIndex = 23;
            this.label19.Text = "Pendientes Acreditacion";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChRechazados
            // 
            this.txtChRechazados.BackColor = System.Drawing.Color.Gainsboro;
            this.txtChRechazados.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_TIPO", true));
            this.txtChRechazados.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChRechazados.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.txtChRechazados.Location = new System.Drawing.Point(178, 29);
            this.txtChRechazados.Name = "txtChRechazados";
            this.txtChRechazados.ReadOnly = true;
            this.txtChRechazados.Size = new System.Drawing.Size(57, 23);
            this.txtChRechazados.TabIndex = 20;
            this.txtChRechazados.TabStop = false;
            this.txtChRechazados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DeepPink;
            this.label18.Location = new System.Drawing.Point(5, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(164, 15);
            this.label18.TabIndex = 21;
            this.label18.Text = "Cheques RECHAZADOS CUIT #";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChRecibidos
            // 
            this.txtChRecibidos.BackColor = System.Drawing.Color.Gainsboro;
            this.txtChRecibidos.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "CUENTA_TIPO", true));
            this.txtChRecibidos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChRecibidos.Location = new System.Drawing.Point(178, 5);
            this.txtChRecibidos.Name = "txtChRecibidos";
            this.txtChRecibidos.ReadOnly = true;
            this.txtChRecibidos.Size = new System.Drawing.Size(57, 23);
            this.txtChRecibidos.TabIndex = 18;
            this.txtChRecibidos.TabStop = false;
            this.txtChRecibidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 15);
            this.label15.TabIndex = 19;
            this.label15.Text = "Cheques Recibidos CUIT #";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckValidacionCheques
            // 
            this.ckValidacionCheques.AutoSize = true;
            this.ckValidacionCheques.Checked = true;
            this.ckValidacionCheques.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckValidacionCheques.Location = new System.Drawing.Point(258, 213);
            this.ckValidacionCheques.Name = "ckValidacionCheques";
            this.ckValidacionCheques.Size = new System.Drawing.Size(203, 19);
            this.ckValidacionCheques.TabIndex = 20;
            this.ckValidacionCheques.Text = "Validacion Estadisticas Cheques";
            this.ckValidacionCheques.UseVisualStyleBackColor = true;
            // 
            // ckIsEcheque
            // 
            this.ckIsEcheque.AutoSize = true;
            this.ckIsEcheque.Location = new System.Drawing.Point(58, 119);
            this.ckIsEcheque.Name = "ckIsEcheque";
            this.ckIsEcheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckIsEcheque.Size = new System.Drawing.Size(80, 19);
            this.ckIsEcheque.TabIndex = 18;
            this.ckIsEcheque.Text = "E-CHEQUE";
            this.ckIsEcheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckIsEcheque.UseVisualStyleBackColor = true;
            // 
            // FrmFI49IngresoItemsCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 295);
            this.Controls.Add(this.ckValidacionCheques);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtImporteGenearlValidacion);
            this.Controls.Add(this.panelBono);
            this.Controls.Add(this.btnAddItemPago);
            this.Controls.Add(this.panelCheque);
            this.Controls.Add(this.panelTransferencia);
            this.Controls.Add(this.ckConexionAfipPadron);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEfectivo);
            this.Controls.Add(this.panelRetencion);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI49IngresoItemsCobranza";
            this.Text = "FI49 - Ingreso de Items de Cobranza";
            this.Load += new System.EventHandler(this.FromInterfazSeleccionCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEfectivo.ResumeLayout(false);
            this.panelEfectivo.PerformLayout();
            this.panelCheque.ResumeLayout(false);
            this.panelCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0160BANCOSBindingSource)).EndInit();
            this.panelRetencion.ResumeLayout(false);
            this.panelRetencion.PerformLayout();
            this.panelTransferencia.ResumeLayout(false);
            this.panelTransferencia.PerformLayout();
            this.panelBono.ResumeLayout(false);
            this.panelBono.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuentaDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtImporteEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelEfectivo;
        private System.Windows.Forms.Panel panelCheque;
        private System.Windows.Forms.TextBox txtBancoDescripcionShort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckChequeInterior;
        private System.Windows.Forms.ComboBox cmbBancoNumero;
        private System.Windows.Forms.TextBox txtDescripcionCuit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporteCheque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroCheque;
        private System.Windows.Forms.Panel panelRetencion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtImporteRetencion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelTransferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtImporteTransferencia;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
        private System.Windows.Forms.TextBox txtTipoCuenta;
        private System.Windows.Forms.MaskedTextBox mtxtCuitCheque;
        private System.Windows.Forms.TextBox txtBancoDescripcionLong;
        private System.Windows.Forms.BindingSource t0160BANCOSBindingSource;
        private System.Windows.Forms.CheckBox ckConexionAfipPadron;
        private System.Windows.Forms.TextBox txtDiasAcerditacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddItemPago;
        private System.Windows.Forms.MaskedTextBox mskFechaAcreditacion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelBono;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtImporteBono;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNumeroBono;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRetProvincia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRetAlicuota;
        private System.Windows.Forms.TextBox txtImporteGenearlValidacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtChPendientesAcred;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtChRechazados;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtChRecibidos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckValidacionCheques;
        private System.Windows.Forms.CheckBox ckIsEcheque;
    }
}