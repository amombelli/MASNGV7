namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCo34DetallesEgresosReg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetallesEgresos = new System.Windows.Forms.DataGridView();
            this.regBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.@__idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMontoOut = new System.Windows.Forms.TextBox();
            this.txtMontoIn = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetallesEgresos
            // 
            this.dgvDetallesEgresos.AllowUserToAddRows = false;
            this.dgvDetallesEgresos.AllowUserToDeleteRows = false;
            this.dgvDetallesEgresos.AutoGenerateColumns = false;
            this.dgvDetallesEgresos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetallesEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idt,
            this.@__cuenta,
            this.cCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.pCDataGridViewTextBoxColumn,
            this.entidadDataGridViewTextBoxColumn,
            this.tdocDataGridViewTextBoxColumn,
            this.refDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.montoIDataGridViewTextBoxColumn,
            this.montoEDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.logUserDataGridViewTextBoxColumn,
            this.tCODEDataGridViewTextBoxColumn,
            this.pCIDDataGridViewTextBoxColumn,
            this.logFechaDataGridViewTextBoxColumn,
            this.nASDataGridViewTextBoxColumn});
            this.dgvDetallesEgresos.DataSource = this.regBs;
            this.dgvDetallesEgresos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDetallesEgresos.Location = new System.Drawing.Point(11, 98);
            this.dgvDetallesEgresos.Name = "dgvDetallesEgresos";
            this.dgvDetallesEgresos.ReadOnly = true;
            this.dgvDetallesEgresos.RowHeadersWidth = 20;
            this.dgvDetallesEgresos.Size = new System.Drawing.Size(1191, 696);
            this.dgvDetallesEgresos.TabIndex = 0;
            // 
            // regBs
            // 
            this.regBs.DataSource = typeof(TecserEF.Entity.XREGISTER);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1085, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1207, 2);
            this.label8.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(8, 1001);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1069, 2);
            this.label1.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 813);
            this.label2.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(16, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "Detalles de Egresos por Cuenta";
            // 
            // __idt
            // 
            this.@__idt.DataPropertyName = "IDT";
            this.@__idt.HeaderText = "IDT";
            this.@__idt.Name = "__idt";
            this.@__idt.ReadOnly = true;
            this.@__idt.Visible = false;
            this.@__idt.Width = 120;
            // 
            // __cuenta
            // 
            this.@__cuenta.DataPropertyName = "IDC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.@__cuenta.DefaultCellStyle = dataGridViewCellStyle7;
            this.@__cuenta.HeaderText = "Cuenta";
            this.@__cuenta.Name = "__cuenta";
            this.@__cuenta.ReadOnly = true;
            this.@__cuenta.ToolTipText = "Cuenta";
            this.@__cuenta.Width = 50;
            // 
            // cCDataGridViewTextBoxColumn
            // 
            this.cCDataGridViewTextBoxColumn.DataPropertyName = "CC";
            this.cCDataGridViewTextBoxColumn.HeaderText = "CC";
            this.cCDataGridViewTextBoxColumn.Name = "cCDataGridViewTextBoxColumn";
            this.cCDataGridViewTextBoxColumn.ReadOnly = true;
            this.cCDataGridViewTextBoxColumn.Width = 70;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "g";
            dataGridViewCellStyle8.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pCDataGridViewTextBoxColumn
            // 
            this.pCDataGridViewTextBoxColumn.DataPropertyName = "PC";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.pCDataGridViewTextBoxColumn.HeaderText = "PC";
            this.pCDataGridViewTextBoxColumn.Name = "pCDataGridViewTextBoxColumn";
            this.pCDataGridViewTextBoxColumn.ReadOnly = true;
            this.pCDataGridViewTextBoxColumn.ToolTipText = "Proveedor/Cliente";
            this.pCDataGridViewTextBoxColumn.Width = 30;
            // 
            // entidadDataGridViewTextBoxColumn
            // 
            this.entidadDataGridViewTextBoxColumn.DataPropertyName = "Entidad";
            this.entidadDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.entidadDataGridViewTextBoxColumn.Name = "entidadDataGridViewTextBoxColumn";
            this.entidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.entidadDataGridViewTextBoxColumn.Width = 200;
            // 
            // tdocDataGridViewTextBoxColumn
            // 
            this.tdocDataGridViewTextBoxColumn.DataPropertyName = "Tdoc";
            this.tdocDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tdocDataGridViewTextBoxColumn.Name = "tdocDataGridViewTextBoxColumn";
            this.tdocDataGridViewTextBoxColumn.ReadOnly = true;
            this.tdocDataGridViewTextBoxColumn.ToolTipText = "Tipo Documento Reg";
            this.tdocDataGridViewTextBoxColumn.Width = 30;
            // 
            // refDataGridViewTextBoxColumn
            // 
            this.refDataGridViewTextBoxColumn.DataPropertyName = "Ref";
            this.refDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.refDataGridViewTextBoxColumn.Name = "refDataGridViewTextBoxColumn";
            this.refDataGridViewTextBoxColumn.ReadOnly = true;
            this.refDataGridViewTextBoxColumn.Width = 80;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 200;
            // 
            // montoIDataGridViewTextBoxColumn
            // 
            this.montoIDataGridViewTextBoxColumn.DataPropertyName = "Monto_I";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Format = "C2";
            this.montoIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.montoIDataGridViewTextBoxColumn.HeaderText = "IN";
            this.montoIDataGridViewTextBoxColumn.Name = "montoIDataGridViewTextBoxColumn";
            this.montoIDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoIDataGridViewTextBoxColumn.Width = 85;
            // 
            // montoEDataGridViewTextBoxColumn
            // 
            this.montoEDataGridViewTextBoxColumn.DataPropertyName = "Monto_E";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Format = "C2";
            this.montoEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.montoEDataGridViewTextBoxColumn.HeaderText = "OUT";
            this.montoEDataGridViewTextBoxColumn.Name = "montoEDataGridViewTextBoxColumn";
            this.montoEDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoEDataGridViewTextBoxColumn.Width = 85;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tIPODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.tIPODataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // logUserDataGridViewTextBoxColumn
            // 
            this.logUserDataGridViewTextBoxColumn.DataPropertyName = "LogUser";
            this.logUserDataGridViewTextBoxColumn.HeaderText = "LogUser";
            this.logUserDataGridViewTextBoxColumn.Name = "logUserDataGridViewTextBoxColumn";
            this.logUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tCODEDataGridViewTextBoxColumn
            // 
            this.tCODEDataGridViewTextBoxColumn.DataPropertyName = "TCODE";
            this.tCODEDataGridViewTextBoxColumn.HeaderText = "Tcode";
            this.tCODEDataGridViewTextBoxColumn.Name = "tCODEDataGridViewTextBoxColumn";
            this.tCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCODEDataGridViewTextBoxColumn.Width = 60;
            // 
            // pCIDDataGridViewTextBoxColumn
            // 
            this.pCIDDataGridViewTextBoxColumn.DataPropertyName = "PCID";
            this.pCIDDataGridViewTextBoxColumn.HeaderText = "PCID";
            this.pCIDDataGridViewTextBoxColumn.Name = "pCIDDataGridViewTextBoxColumn";
            this.pCIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pCIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // logFechaDataGridViewTextBoxColumn
            // 
            this.logFechaDataGridViewTextBoxColumn.DataPropertyName = "LogFecha";
            this.logFechaDataGridViewTextBoxColumn.HeaderText = "LogFecha";
            this.logFechaDataGridViewTextBoxColumn.Name = "logFechaDataGridViewTextBoxColumn";
            this.logFechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.logFechaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nASDataGridViewTextBoxColumn
            // 
            this.nASDataGridViewTextBoxColumn.DataPropertyName = "NAS";
            this.nASDataGridViewTextBoxColumn.HeaderText = "NAS";
            this.nASDataGridViewTextBoxColumn.Name = "nASDataGridViewTextBoxColumn";
            this.nASDataGridViewTextBoxColumn.ReadOnly = true;
            this.nASDataGridViewTextBoxColumn.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(1208, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 813);
            this.label4.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Tomato;
            this.label5.Location = new System.Drawing.Point(3, 815);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1207, 2);
            this.label5.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 97;
            this.label6.Text = "Fecha Desde";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFechaDesde.Location = new System.Drawing.Point(81, 32);
            this.txtFechaDesde.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.ReadOnly = true;
            this.txtFechaDesde.Size = new System.Drawing.Size(116, 23);
            this.txtFechaDesde.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 99;
            this.label7.Text = "Fecha Hasta";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFechaHasta.Location = new System.Drawing.Point(81, 56);
            this.txtFechaHasta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.ReadOnly = true;
            this.txtFechaHasta.Size = new System.Drawing.Size(116, 23);
            this.txtFechaHasta.TabIndex = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFechaHasta);
            this.panel1.Controls.Add(this.txtFechaDesde);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(11, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 88);
            this.panel1.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtLx);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtMontoOut);
            this.panel2.Controls.Add(this.txtMontoIn);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(215, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 88);
            this.panel2.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 94;
            this.label9.Text = "Tipo Operacion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 97;
            this.label10.Text = "Total Ingresos";
            // 
            // txtMontoOut
            // 
            this.txtMontoOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMontoOut.Location = new System.Drawing.Point(95, 55);
            this.txtMontoOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMontoOut.Name = "txtMontoOut";
            this.txtMontoOut.ReadOnly = true;
            this.txtMontoOut.Size = new System.Drawing.Size(116, 23);
            this.txtMontoOut.TabIndex = 100;
            this.txtMontoOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoIn
            // 
            this.txtMontoIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMontoIn.Location = new System.Drawing.Point(95, 31);
            this.txtMontoIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMontoIn.Name = "txtMontoIn";
            this.txtMontoIn.ReadOnly = true;
            this.txtMontoIn.Size = new System.Drawing.Size(116, 23);
            this.txtMontoIn.TabIndex = 98;
            this.txtMontoIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 99;
            this.label11.Text = "Total Egresos";
            // 
            // txtLx
            // 
            this.txtLx.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLx.Location = new System.Drawing.Point(95, 7);
            this.txtLx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(37, 23);
            this.txtLx.TabIndex = 101;
            this.txtLx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmCo34DetallesEgresosReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1214, 821);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDetallesEgresos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCo34DetallesEgresosReg";
            this.Text = "CO34 - Detalles de Egresos x Cuenta [Reg]";
            this.Load += new System.EventHandler(this.FrmDetalleEgresosREG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetallesEgresos;
        private System.Windows.Forms.BindingSource regBs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn __cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nASDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMontoOut;
        private System.Windows.Forms.TextBox txtMontoIn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLx;
    }
}