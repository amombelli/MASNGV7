namespace MASngFE.Transactional.FI.Cobranza
{
    partial class FrmCobranzaSearchScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListadoCobranzas = new System.Windows.Forms.DataGridView();
            this.iDCOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nRECIBODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRECIBOOFI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUENTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reciboDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nRECIPROVIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCCANCELADODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dIASPPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENVIAREMAIL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ENVIADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cobranzaHeaderSerachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevaCobranza = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroShiptos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbId6 = new System.Windows.Forms.ComboBox();
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoTax = new System.Windows.Forms.ComboBox();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.btnVerMaestro = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBusquedaAvanzada = new System.Windows.Forms.Button();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.txtNumeroTax = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaxValido = new System.Windows.Forms.TextBox();
            this.txtCodigoTax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCobranzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobranzaHeaderSerachBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoCobranzas
            // 
            this.dgvListadoCobranzas.AllowUserToAddRows = false;
            this.dgvListadoCobranzas.AllowUserToDeleteRows = false;
            this.dgvListadoCobranzas.AutoGenerateColumns = false;
            this.dgvListadoCobranzas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListadoCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoCobranzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCOBDataGridViewTextBoxColumn,
            this.Column1,
            this.nRECIBODataGridViewTextBoxColumn,
            this.NRECIBOOFI,
            this.cUENTADataGridViewTextBoxColumn,
            this.mONDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.reciboDescDataGridViewTextBoxColumn,
            this.logUserDataGridViewTextBoxColumn,
            this.nRECIPROVIDataGridViewTextBoxColumn,
            this.dOCCANCELADODataGridViewTextBoxColumn,
            this.dIASPPDataGridViewTextBoxColumn,
            this.ENVIAREMAIL,
            this.ENVIADO,
            this.VER});
            this.dgvListadoCobranzas.DataSource = this.cobranzaHeaderSerachBindingSource;
            this.dgvListadoCobranzas.GridColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvListadoCobranzas.Location = new System.Drawing.Point(2, 116);
            this.dgvListadoCobranzas.Name = "dgvListadoCobranzas";
            this.dgvListadoCobranzas.ReadOnly = true;
            this.dgvListadoCobranzas.RowHeadersWidth = 20;
            this.dgvListadoCobranzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoCobranzas.Size = new System.Drawing.Size(1154, 601);
            this.dgvListadoCobranzas.TabIndex = 0;
            this.dgvListadoCobranzas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCobranzas_CellContentClick);
            // 
            // iDCOBDataGridViewTextBoxColumn
            // 
            this.iDCOBDataGridViewTextBoxColumn.DataPropertyName = "IDCOB";
            this.iDCOBDataGridViewTextBoxColumn.HeaderText = "IdCob";
            this.iDCOBDataGridViewTextBoxColumn.Name = "iDCOBDataGridViewTextBoxColumn";
            this.iDCOBDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCOBDataGridViewTextBoxColumn.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RazonSocial";
            this.Column1.HeaderText = "Razon Social";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // nRECIBODataGridViewTextBoxColumn
            // 
            this.nRECIBODataGridViewTextBoxColumn.DataPropertyName = "NRECIBO";
            this.nRECIBODataGridViewTextBoxColumn.HeaderText = "Recibo#";
            this.nRECIBODataGridViewTextBoxColumn.Name = "nRECIBODataGridViewTextBoxColumn";
            this.nRECIBODataGridViewTextBoxColumn.ReadOnly = true;
            this.nRECIBODataGridViewTextBoxColumn.Width = 60;
            // 
            // NRECIBOOFI
            // 
            this.NRECIBOOFI.DataPropertyName = "NRECIBOOFI";
            this.NRECIBOOFI.HeaderText = "Recibo Ofi";
            this.NRECIBOOFI.Name = "NRECIBOOFI";
            this.NRECIBOOFI.ReadOnly = true;
            this.NRECIBOOFI.Width = 80;
            // 
            // cUENTADataGridViewTextBoxColumn
            // 
            this.cUENTADataGridViewTextBoxColumn.DataPropertyName = "CUENTA";
            this.cUENTADataGridViewTextBoxColumn.HeaderText = "LX";
            this.cUENTADataGridViewTextBoxColumn.Name = "cUENTADataGridViewTextBoxColumn";
            this.cUENTADataGridViewTextBoxColumn.ReadOnly = true;
            this.cUENTADataGridViewTextBoxColumn.Width = 35;
            // 
            // mONDataGridViewTextBoxColumn
            // 
            this.mONDataGridViewTextBoxColumn.DataPropertyName = "MON";
            this.mONDataGridViewTextBoxColumn.HeaderText = "MON";
            this.mONDataGridViewTextBoxColumn.Name = "mONDataGridViewTextBoxColumn";
            this.mONDataGridViewTextBoxColumn.ReadOnly = true;
            this.mONDataGridViewTextBoxColumn.Width = 40;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fECHADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fECHADataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADataGridViewTextBoxColumn.Width = 80;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "c2";
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn.Width = 80;
            // 
            // reciboDescDataGridViewTextBoxColumn
            // 
            this.reciboDescDataGridViewTextBoxColumn.DataPropertyName = "ReciboDesc";
            this.reciboDescDataGridViewTextBoxColumn.HeaderText = "ReciboDesc";
            this.reciboDescDataGridViewTextBoxColumn.Name = "reciboDescDataGridViewTextBoxColumn";
            this.reciboDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logUserDataGridViewTextBoxColumn
            // 
            this.logUserDataGridViewTextBoxColumn.DataPropertyName = "LogUser";
            this.logUserDataGridViewTextBoxColumn.HeaderText = "User_In";
            this.logUserDataGridViewTextBoxColumn.Name = "logUserDataGridViewTextBoxColumn";
            this.logUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nRECIPROVIDataGridViewTextBoxColumn
            // 
            this.nRECIPROVIDataGridViewTextBoxColumn.DataPropertyName = "NRECIPROVI";
            this.nRECIPROVIDataGridViewTextBoxColumn.HeaderText = "NProvi";
            this.nRECIPROVIDataGridViewTextBoxColumn.Name = "nRECIPROVIDataGridViewTextBoxColumn";
            this.nRECIPROVIDataGridViewTextBoxColumn.ReadOnly = true;
            this.nRECIPROVIDataGridViewTextBoxColumn.Width = 50;
            // 
            // dOCCANCELADODataGridViewTextBoxColumn
            // 
            this.dOCCANCELADODataGridViewTextBoxColumn.DataPropertyName = "DOC_CANCELADO";
            this.dOCCANCELADODataGridViewTextBoxColumn.HeaderText = "Cancel";
            this.dOCCANCELADODataGridViewTextBoxColumn.Name = "dOCCANCELADODataGridViewTextBoxColumn";
            this.dOCCANCELADODataGridViewTextBoxColumn.ReadOnly = true;
            this.dOCCANCELADODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dOCCANCELADODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dOCCANCELADODataGridViewTextBoxColumn.Width = 50;
            // 
            // dIASPPDataGridViewTextBoxColumn
            // 
            this.dIASPPDataGridViewTextBoxColumn.DataPropertyName = "DIAS_PP";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dIASPPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dIASPPDataGridViewTextBoxColumn.HeaderText = "DiasPP";
            this.dIASPPDataGridViewTextBoxColumn.Name = "dIASPPDataGridViewTextBoxColumn";
            this.dIASPPDataGridViewTextBoxColumn.ReadOnly = true;
            this.dIASPPDataGridViewTextBoxColumn.Width = 50;
            // 
            // ENVIAREMAIL
            // 
            this.ENVIAREMAIL.DataPropertyName = "ENVIAREMAIL";
            this.ENVIAREMAIL.HeaderText = "Enviar";
            this.ENVIAREMAIL.Name = "ENVIAREMAIL";
            this.ENVIAREMAIL.ReadOnly = true;
            this.ENVIAREMAIL.ToolTipText = "Enviar este Recibo por Email";
            this.ENVIAREMAIL.Width = 50;
            // 
            // ENVIADO
            // 
            this.ENVIADO.DataPropertyName = "ENVIADO";
            this.ENVIADO.HeaderText = "EnviarOK";
            this.ENVIADO.Name = "ENVIADO";
            this.ENVIADO.ReadOnly = true;
            this.ENVIADO.ToolTipText = "Mensaje Enviado Correctamente";
            this.ENVIADO.Width = 55;
            // 
            // VER
            // 
            this.VER.HeaderText = "VER";
            this.VER.Name = "VER";
            this.VER.ReadOnly = true;
            this.VER.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VER.Text = "VER";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 40;
            // 
            // cobranzaHeaderSerachBindingSource
            // 
            this.cobranzaHeaderSerachBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.CobranzaHeaderSerach);
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1053, 11);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 39);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevaCobranza
            // 
            this.btnNuevaCobranza.Location = new System.Drawing.Point(1053, 51);
            this.btnNuevaCobranza.Name = "btnNuevaCobranza";
            this.btnNuevaCobranza.Size = new System.Drawing.Size(103, 39);
            this.btnNuevaCobranza.TabIndex = 2;
            this.btnNuevaCobranza.Text = "NUEVA";
            this.btnNuevaCobranza.UseVisualStyleBackColor = true;
            this.btnNuevaCobranza.Click += new System.EventHandler(this.btnNuevaCobranza_Click);
            // 
            // label48
            // 
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Location = new System.Drawing.Point(611, 68);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(200, 3);
            this.label48.TabIndex = 95;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotal);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(611, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 110);
            this.panel2.TabIndex = 96;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(88, 73);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoTotal.TabIndex = 67;
            this.txtSaldoTotal.TabStop = false;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(12, 74);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 15);
            this.label45.TabIndex = 68;
            this.label45.Text = "Saldo Total";
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Location = new System.Drawing.Point(88, 9);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL1.TabIndex = 63;
            this.txtSaldoL1.TabStop = false;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 15);
            this.label26.TabIndex = 64;
            this.label26.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Location = new System.Drawing.Point(88, 30);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL2.TabIndex = 65;
            this.txtSaldoL2.TabStop = false;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(12, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 15);
            this.label25.TabIndex = 66;
            this.label25.Text = "Saldo L2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNumeroShiptos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbId6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTipoTax);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.btnVerMaestro);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBusquedaAvanzada);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.txtNumeroTax);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTaxValido);
            this.panel1.Controls.Add(this.txtCodigoTax);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 110);
            this.panel1.TabIndex = 94;
            // 
            // txtNumeroShiptos
            // 
            this.txtNumeroShiptos.Location = new System.Drawing.Point(121, 84);
            this.txtNumeroShiptos.Name = "txtNumeroShiptos";
            this.txtNumeroShiptos.Size = new System.Drawing.Size(34, 20);
            this.txtNumeroShiptos.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "CANTIDAD SHIPTOS";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(9, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 3);
            this.label7.TabIndex = 19;
            // 
            // cmbId6
            // 
            this.cmbId6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbId6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbId6.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbId6.DisplayMember = "IDCLIENTE";
            this.cmbId6.FormattingEnabled = true;
            this.cmbId6.Location = new System.Drawing.Point(406, 8);
            this.cmbId6.Name = "cmbId6";
            this.cmbId6.Size = new System.Drawing.Size(72, 21);
            this.cmbId6.TabIndex = 15;
            this.cmbId6.ValueMember = "IDCLIENTE";
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RAZON SOCIAL";
            // 
            // cmbTipoTax
            // 
            this.cmbTipoTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoTax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbTipoTax.FormattingEnabled = true;
            this.cmbTipoTax.Items.AddRange(new object[] {
            "CUIT",
            "NI"});
            this.cmbTipoTax.Location = new System.Drawing.Point(121, 54);
            this.cmbTipoTax.Name = "cmbTipoTax";
            this.cmbTipoTax.Size = new System.Drawing.Size(71, 21);
            this.cmbTipoTax.TabIndex = 14;
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(121, 8);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(281, 21);
            this.cmbRazonSocial.TabIndex = 3;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            // 
            // btnVerMaestro
            // 
            this.btnVerMaestro.Location = new System.Drawing.Point(494, 41);
            this.btnVerMaestro.Name = "btnVerMaestro";
            this.btnVerMaestro.Size = new System.Drawing.Size(100, 35);
            this.btnVerMaestro.TabIndex = 13;
            this.btnVerMaestro.Text = "Maestro";
            this.btnVerMaestro.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOMBRE FANTASIA";
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(494, 5);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(100, 35);
            this.btnBusquedaAvanzada.TabIndex = 12;
            this.btnBusquedaAvanzada.Text = "Busqueda Avanzada";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.btnBusquedaAvanzada.Click += new System.EventHandler(this.btnBusquedaAvanzada_Click);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(121, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(281, 21);
            this.cmbFantasia.TabIndex = 5;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            // 
            // txtNumeroTax
            // 
            this.txtNumeroTax.BeepOnError = true;
            this.txtNumeroTax.Location = new System.Drawing.Point(234, 55);
            this.txtNumeroTax.Mask = "00-00000000-0";
            this.txtNumeroTax.Name = "txtNumeroTax";
            this.txtNumeroTax.ReadOnly = true;
            this.txtNumeroTax.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroTax.TabIndex = 11;
            this.txtNumeroTax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TAX NUMBER";
            // 
            // txtTaxValido
            // 
            this.txtTaxValido.Location = new System.Drawing.Point(324, 55);
            this.txtTaxValido.Name = "txtTaxValido";
            this.txtTaxValido.Size = new System.Drawing.Size(78, 20);
            this.txtTaxValido.TabIndex = 9;
            this.txtTaxValido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigoTax
            // 
            this.txtCodigoTax.Location = new System.Drawing.Point(197, 55);
            this.txtCodigoTax.Name = "txtCodigoTax";
            this.txtCodigoTax.Size = new System.Drawing.Size(34, 20);
            this.txtCodigoTax.TabIndex = 8;
            // 
            // FrmCobranzaSearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 719);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNuevaCobranza);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvListadoCobranzas);
            this.Name = "FrmCobranzaSearchScreen";
            this.Text = "BUSCADOR DE COBRANZAS - COB0";
            this.Load += new System.EventHandler(this.FrmCobranzaSearchScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCobranzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobranzaHeaderSerachBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoCobranzas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevaCobranza;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNumeroShiptos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbId6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoTax;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Button btnVerMaestro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBusquedaAvanzada;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtNumeroTax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaxValido;
        private System.Windows.Forms.TextBox txtCodigoTax;
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.BindingSource cobranzaHeaderSerachBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nRECIBODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRECIBOOFI;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUENTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reciboDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nRECIPROVIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dOCCANCELADODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIASPPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ENVIAREMAIL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ENVIADO;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
    }
}