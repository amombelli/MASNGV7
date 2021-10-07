namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmCustomerNcd2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerNcd2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvNCD = new System.Windows.Forms.DataGridView();
            this.iDHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLITXTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_ARS_NETO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0300NCDHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnVerChrPendientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0300NCDHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.txtCuit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 86);
            this.panel1.TabIndex = 0;
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(105, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(307, 23);
            this.cmbFantasia.TabIndex = 16;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.Leave += new System.EventHandler(this.cmbRazonSocial_Leave);
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(105, 7);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(307, 23);
            this.cmbRazonSocial.TabIndex = 15;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.Leave += new System.EventHandler(this.cmbRazonSocial_Leave);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCliente.Location = new System.Drawing.Point(415, 7);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(57, 21);
            this.txtIdCliente.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(231, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(28, 21);
            this.textBox3.TabIndex = 6;
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCuit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0006MCLIENTESBindingSource, "CUIT", true));
            this.txtCuit.Location = new System.Drawing.Point(105, 56);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(125, 21);
            this.txtCuit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "CUIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fantasia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social";
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Location = new System.Drawing.Point(97, 6);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoL1.TabIndex = 9;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Location = new System.Drawing.Point(97, 29);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoL2.TabIndex = 11;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saldo L2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(615, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 86);
            this.panel2.TabIndex = 12;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(97, 52);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoTotal.TabIndex = 13;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Deduda Total";
            // 
            // dgvNCD
            // 
            this.dgvNCD.AllowUserToAddRows = false;
            this.dgvNCD.AllowUserToDeleteRows = false;
            this.dgvNCD.AutoGenerateColumns = false;
            this.dgvNCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNCD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDHDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nDOCDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.cLITXTDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.TOTAL_ARS_NETO,
            this.VER});
            this.dgvNCD.DataSource = this.t0300NCDHBindingSource;
            this.dgvNCD.Location = new System.Drawing.Point(3, 117);
            this.dgvNCD.Name = "dgvNCD";
            this.dgvNCD.ReadOnly = true;
            this.dgvNCD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNCD.Size = new System.Drawing.Size(679, 402);
            this.dgvNCD.TabIndex = 14;
            this.dgvNCD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCD_CellContentClick);
            // 
            // iDHDataGridViewTextBoxColumn
            // 
            this.iDHDataGridViewTextBoxColumn.DataPropertyName = "IDH";
            this.iDHDataGridViewTextBoxColumn.HeaderText = "IDH";
            this.iDHDataGridViewTextBoxColumn.Name = "iDHDataGridViewTextBoxColumn";
            this.iDHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.Width = 45;
            // 
            // nDOCDataGridViewTextBoxColumn
            // 
            this.nDOCDataGridViewTextBoxColumn.DataPropertyName = "NDOC";
            this.nDOCDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.nDOCDataGridViewTextBoxColumn.Name = "nDOCDataGridViewTextBoxColumn";
            this.nDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDOCDataGridViewTextBoxColumn.Visible = false;
            this.nDOCDataGridViewTextBoxColumn.Width = 120;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            this.fECHADataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cLITXTDataGridViewTextBoxColumn
            // 
            this.cLITXTDataGridViewTextBoxColumn.DataPropertyName = "CLITXT";
            this.cLITXTDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.cLITXTDataGridViewTextBoxColumn.Name = "cLITXTDataGridViewTextBoxColumn";
            this.cLITXTDataGridViewTextBoxColumn.ReadOnly = true;
            this.cLITXTDataGridViewTextBoxColumn.Width = 150;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // TOTAL_ARS_NETO
            // 
            this.TOTAL_ARS_NETO.DataPropertyName = "TOTAL_ARS_NETO";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Format = "c2";
            this.TOTAL_ARS_NETO.DefaultCellStyle = dataGridViewCellStyle1;
            this.TOTAL_ARS_NETO.HeaderText = "IMPORTE [ARS]";
            this.TOTAL_ARS_NETO.Name = "TOTAL_ARS_NETO";
            this.TOTAL_ARS_NETO.ReadOnly = true;
            this.TOTAL_ARS_NETO.Width = 120;
            // 
            // VER
            // 
            this.VER.HeaderText = "VER";
            this.VER.Name = "VER";
            this.VER.ReadOnly = true;
            this.VER.Text = "VER";
            this.VER.ToolTipText = "Visualizar o Editar NC/ND";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 45;
            // 
            // t0300NCDHBindingSource
            // 
            this.t0300NCDHBindingSource.DataSource = typeof(TecserEF.Entity.T0300_NCD_H);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(6, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(289, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "LISTADO DE NOTAS DE CREDITO Y DEBITO";
            // 
            // btnVerChrPendientes
            // 
            this.btnVerChrPendientes.Image = ((System.Drawing.Image)(resources.GetObject("btnVerChrPendientes.Image")));
            this.btnVerChrPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerChrPendientes.Location = new System.Drawing.Point(713, 140);
            this.btnVerChrPendientes.Name = "btnVerChrPendientes";
            this.btnVerChrPendientes.Size = new System.Drawing.Size(112, 43);
            this.btnVerChrPendientes.TabIndex = 18;
            this.btnVerChrPendientes.Text = "Rechazos\r\nPendientes";
            this.btnVerChrPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerChrPendientes.UseVisualStyleBackColor = true;
            this.btnVerChrPendientes.Click += new System.EventHandler(this.btnVerChrPendientes_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(713, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 43);
            this.button1.TabIndex = 35;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCustomerNcd2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerChrPendientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvNCD);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCustomerNcd2";
            this.Text = "BUSQUEDA Y SELECCION DE NOTAS DE CREDITO / NOTAS DE DEBITO";
            this.Load += new System.EventHandler(this.FrmCustomerNCDMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0300NCDHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.DataGridView dgvNCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLITXTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_ARS_NETO;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
        private System.Windows.Forms.BindingSource t0300NCDHBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerChrPendientes;
        private System.Windows.Forms.Button button1;
    }
}