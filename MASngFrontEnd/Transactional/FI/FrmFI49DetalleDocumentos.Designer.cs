namespace MASngFE.Transactional.FI
{
    partial class FrmFI49DetalleDocumentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.t0201CTACTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtDeudaTotal = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtZtermL2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtZtermL1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDeudaL2 = new System.Windows.Forms.TextBox();
            this.txtDeudaL1 = new System.Windows.Forms.TextBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckSoloSaldoPendiente = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEORIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0201CTACTEBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(814, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 42);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.mONEDADataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.iMPORTEORIDataGridViewTextBoxColumn,
            this.sALDOFACTURADataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.t0201CTACTEBindingSource;
            this.dgvDetalle.GridColor = System.Drawing.Color.Black;
            this.dgvDetalle.Location = new System.Drawing.Point(6, 91);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 20;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalle.Size = new System.Drawing.Size(795, 443);
            this.dgvDetalle.TabIndex = 51;
            // 
            // t0201CTACTEBindingSource
            // 
            this.t0201CTACTEBindingSource.DataSource = typeof(TecserEF.Entity.T0201_CTACTE);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.txtFantasia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 56);
            this.panel1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fantasia";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdCliente.Location = new System.Drawing.Point(366, 5);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(55, 22);
            this.txtIdCliente.TabIndex = 3;
            this.txtIdCliente.TabStop = false;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFantasia.Location = new System.Drawing.Point(89, 29);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(275, 22);
            this.txtFantasia.TabIndex = 19;
            this.txtFantasia.TabStop = false;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRazonSocial.Location = new System.Drawing.Point(89, 5);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(275, 22);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label37);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Controls.Add(this.txtDeudaTotal);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtLimiteCredito);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtDeudaL2);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.txtDeudaL1);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtZtermL2);
            this.panel3.Controls.Add(this.txtZtermL1);
            this.panel3.Location = new System.Drawing.Point(436, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 78);
            this.panel3.TabIndex = 53;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label37.Location = new System.Drawing.Point(197, 50);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(59, 13);
            this.label37.TabIndex = 151;
            this.label37.Text = "Lim Credito";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label36.Location = new System.Drawing.Point(9, 50);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(66, 13);
            this.label36.TabIndex = 149;
            this.label36.Text = "Deuda Total";
            // 
            // txtDeudaTotal
            // 
            this.txtDeudaTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeudaTotal.Location = new System.Drawing.Point(86, 46);
            this.txtDeudaTotal.Name = "txtDeudaTotal";
            this.txtDeudaTotal.ReadOnly = true;
            this.txtDeudaTotal.Size = new System.Drawing.Size(96, 20);
            this.txtDeudaTotal.TabIndex = 148;
            this.txtDeudaTotal.TabStop = false;
            this.txtDeudaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.ForeColor = System.Drawing.Color.Navy;
            this.label34.Location = new System.Drawing.Point(203, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 13);
            this.label34.TabIndex = 25;
            this.label34.Text = "ZTerm L2";
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLimiteCredito.Location = new System.Drawing.Point(264, 46);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.ReadOnly = true;
            this.txtLimiteCredito.Size = new System.Drawing.Size(96, 20);
            this.txtLimiteCredito.TabIndex = 150;
            this.txtLimiteCredito.TabStop = false;
            this.txtLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(203, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "ZTerm L1";
            // 
            // txtZtermL2
            // 
            this.txtZtermL2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtZtermL2.Location = new System.Drawing.Point(264, 24);
            this.txtZtermL2.Name = "txtZtermL2";
            this.txtZtermL2.ReadOnly = true;
            this.txtZtermL2.Size = new System.Drawing.Size(51, 20);
            this.txtZtermL2.TabIndex = 15;
            this.txtZtermL2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(8, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 14;
            // 
            // txtZtermL1
            // 
            this.txtZtermL1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtZtermL1.Location = new System.Drawing.Point(264, 2);
            this.txtZtermL1.Name = "txtZtermL1";
            this.txtZtermL1.ReadOnly = true;
            this.txtZtermL1.Size = new System.Drawing.Size(51, 20);
            this.txtZtermL1.TabIndex = 13;
            this.txtZtermL1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(28, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Saldo L1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(28, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Saldo L2";
            // 
            // txtDeudaL2
            // 
            this.txtDeudaL2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeudaL2.Location = new System.Drawing.Point(86, 24);
            this.txtDeudaL2.Name = "txtDeudaL2";
            this.txtDeudaL2.ReadOnly = true;
            this.txtDeudaL2.Size = new System.Drawing.Size(96, 20);
            this.txtDeudaL2.TabIndex = 5;
            this.txtDeudaL2.TabStop = false;
            this.txtDeudaL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeudaL1
            // 
            this.txtDeudaL1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeudaL1.Location = new System.Drawing.Point(86, 2);
            this.txtDeudaL1.Name = "txtDeudaL1";
            this.txtDeudaL1.ReadOnly = true;
            this.txtDeudaL1.Size = new System.Drawing.Size(96, 20);
            this.txtDeudaL1.TabIndex = 3;
            this.txtDeudaL1.TabStop = false;
            this.txtDeudaL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckL1.Location = new System.Drawing.Point(13, 63);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(79, 18);
            this.ckL1.TabIndex = 54;
            this.ckL1.Text = "Incluir L1";
            this.ckL1.UseVisualStyleBackColor = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckL2.Location = new System.Drawing.Point(109, 63);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(79, 18);
            this.ckL2.TabIndex = 55;
            this.ckL2.Text = "Incluir L2";
            this.ckL2.UseVisualStyleBackColor = true;
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // ckSoloSaldoPendiente
            // 
            this.ckSoloSaldoPendiente.AutoSize = true;
            this.ckSoloSaldoPendiente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloSaldoPendiente.Location = new System.Drawing.Point(280, 63);
            this.ckSoloSaldoPendiente.Name = "ckSoloSaldoPendiente";
            this.ckSoloSaldoPendiente.Size = new System.Drawing.Size(148, 18);
            this.ckSoloSaldoPendiente.TabIndex = 56;
            this.ckSoloSaldoPendiente.Text = "Solo Saldo Pendiente";
            this.ckSoloSaldoPendiente.UseVisualStyleBackColor = true;
            this.ckSoloSaldoPendiente.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(3, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(798, 3);
            this.label9.TabIndex = 161;
            // 
            // iDCTACTEDataGridViewTextBoxColumn
            // 
            this.iDCTACTEDataGridViewTextBoxColumn.DataPropertyName = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.HeaderText = "CtaCte#";
            this.iDCTACTEDataGridViewTextBoxColumn.Name = "iDCTACTEDataGridViewTextBoxColumn";
            this.iDCTACTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCTACTEDataGridViewTextBoxColumn.Width = 55;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "Docu #";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "Mon";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDADataGridViewTextBoxColumn.Width = 40;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEORIDataGridViewTextBoxColumn
            // 
            this.iMPORTEORIDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE_ORI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            this.iMPORTEORIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iMPORTEORIDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.iMPORTEORIDataGridViewTextBoxColumn.Name = "iMPORTEORIDataGridViewTextBoxColumn";
            this.iMPORTEORIDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEORIDataGridViewTextBoxColumn.Width = 80;
            // 
            // sALDOFACTURADataGridViewTextBoxColumn
            // 
            this.sALDOFACTURADataGridViewTextBoxColumn.DataPropertyName = "SALDOFACTURA";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.sALDOFACTURADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sALDOFACTURADataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.sALDOFACTURADataGridViewTextBoxColumn.Name = "sALDOFACTURADataGridViewTextBoxColumn";
            this.sALDOFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.sALDOFACTURADataGridViewTextBoxColumn.Width = 80;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 40;
            // 
            // FrmFI49DetalleDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 537);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ckSoloSaldoPendiente);
            this.Controls.Add(this.ckL2);
            this.Controls.Add(this.ckL1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmFI49DetalleDocumentos";
            this.Text = "FI49 - Detalle de Documentos ";
            this.Load += new System.EventHandler(this.FrmFI49DetalleDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0201CTACTEBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource t0201CTACTEBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtDeudaTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLimiteCredito;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDeudaL2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtDeudaL1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtZtermL2;
        private System.Windows.Forms.TextBox txtZtermL1;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckSoloSaldoPendiente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEORIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
    }
}