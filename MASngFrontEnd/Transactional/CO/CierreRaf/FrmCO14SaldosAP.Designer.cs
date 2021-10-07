namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCO14SaldosAP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadPeriodos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.ckVerDetalleAP = new System.Windows.Forms.CheckBox();
            this.txtSaldoAPeriodoAP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetalleAP = new System.Windows.Forms.Button();
            this.lperiodo = new System.Windows.Forms.Label();
            this.txtSaldoAPHoy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaldosIniciales = new System.Windows.Forms.Button();
            this.btnSaldosFinales = new System.Windows.Forms.Button();
            this.dgvSaldoProveedores = new System.Windows.Forms.DataGridView();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoLXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deudaTotalARSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStructuraBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldoProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructuraBs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFechaHasta);
            this.panel2.Controls.Add(this.txtFechaDesde);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCantidadPeriodos);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtPeriodo);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(10, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 72);
            this.panel2.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Periodo";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(85, 47);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.txtFechaHasta.TabIndex = 91;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(85, 26);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDesde.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Fecha Desde";
            // 
            // txtCantidadPeriodos
            // 
            this.txtCantidadPeriodos.Location = new System.Drawing.Point(157, 4);
            this.txtCantidadPeriodos.Name = "txtCantidadPeriodos";
            this.txtCantidadPeriodos.Size = new System.Drawing.Size(28, 20);
            this.txtCantidadPeriodos.TabIndex = 92;
            this.txtCantidadPeriodos.Text = "1";
            this.txtCantidadPeriodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(139, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "#";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AllowPromptAsInput = false;
            this.txtPeriodo.BeepOnError = true;
            this.txtPeriodo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPeriodo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtPeriodo.Location = new System.Drawing.Point(85, 4);
            this.txtPeriodo.Mask = "0000-00";
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(51, 20);
            this.txtPeriodo.TabIndex = 87;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriodo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckL2);
            this.panel1.Controls.Add(this.ckL1);
            this.panel1.Location = new System.Drawing.Point(187, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 41);
            this.panel1.TabIndex = 94;
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(9, 22);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 17);
            this.ckL2.TabIndex = 1;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(9, 3);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 17);
            this.ckL1.TabIndex = 0;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            // 
            // ckVerDetalleAP
            // 
            this.ckVerDetalleAP.AutoSize = true;
            this.ckVerDetalleAP.Location = new System.Drawing.Point(312, 117);
            this.ckVerDetalleAP.Name = "ckVerDetalleAP";
            this.ckVerDetalleAP.Size = new System.Drawing.Size(130, 17);
            this.ckVerDetalleAP.TabIndex = 110;
            this.ckVerDetalleAP.Text = "Ver Detalle Saldos AP";
            this.ckVerDetalleAP.UseVisualStyleBackColor = true;
            // 
            // txtSaldoAPeriodoAP
            // 
            this.txtSaldoAPeriodoAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAPeriodoAP.Location = new System.Drawing.Point(193, 114);
            this.txtSaldoAPeriodoAP.Name = "txtSaldoAPeriodoAP";
            this.txtSaldoAPeriodoAP.ReadOnly = true;
            this.txtSaldoAPeriodoAP.Size = new System.Drawing.Size(104, 21);
            this.txtSaldoAPeriodoAP.TabIndex = 109;
            this.txtSaldoAPeriodoAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 108;
            this.label3.Text = "A/P A Inicio Periodo";
            // 
            // btnDetalleAP
            // 
            this.btnDetalleAP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleAP.Location = new System.Drawing.Point(579, 12);
            this.btnDetalleAP.Name = "btnDetalleAP";
            this.btnDetalleAP.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleAP.TabIndex = 107;
            this.btnDetalleAP.Text = "Detalle\r\n A/P Hoy";
            this.btnDetalleAP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleAP.UseVisualStyleBackColor = true;
            this.btnDetalleAP.Click += new System.EventHandler(this.btnDetalleAP_Click);
            // 
            // lperiodo
            // 
            this.lperiodo.AutoSize = true;
            this.lperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lperiodo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lperiodo.Location = new System.Drawing.Point(142, 117);
            this.lperiodo.Name = "lperiodo";
            this.lperiodo.Size = new System.Drawing.Size(49, 15);
            this.lperiodo.TabIndex = 111;
            this.lperiodo.Text = "201899";
            // 
            // txtSaldoAPHoy
            // 
            this.txtSaldoAPHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAPHoy.Location = new System.Drawing.Point(193, 92);
            this.txtSaldoAPHoy.Name = "txtSaldoAPHoy";
            this.txtSaldoAPHoy.ReadOnly = true;
            this.txtSaldoAPHoy.Size = new System.Drawing.Size(104, 21);
            this.txtSaldoAPHoy.TabIndex = 106;
            this.txtSaldoAPHoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 105;
            this.label5.Text = "Saldo A/P Final HOY";
            // 
            // btnSaldosIniciales
            // 
            this.btnSaldosIniciales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldosIniciales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaldosIniciales.Location = new System.Drawing.Point(579, 53);
            this.btnSaldosIniciales.Name = "btnSaldosIniciales";
            this.btnSaldosIniciales.Size = new System.Drawing.Size(100, 40);
            this.btnSaldosIniciales.TabIndex = 104;
            this.btnSaldosIniciales.Text = "A/P\r\nPeriodo";
            this.btnSaldosIniciales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaldosIniciales.UseVisualStyleBackColor = true;
            this.btnSaldosIniciales.Click += new System.EventHandler(this.btnSaldosIniciales_Click);
            // 
            // btnSaldosFinales
            // 
            this.btnSaldosFinales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldosFinales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaldosFinales.Location = new System.Drawing.Point(579, 93);
            this.btnSaldosFinales.Name = "btnSaldosFinales";
            this.btnSaldosFinales.Size = new System.Drawing.Size(100, 40);
            this.btnSaldosFinales.TabIndex = 103;
            this.btnSaldosFinales.Text = "Saldos\r\nFinales";
            this.btnSaldosFinales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaldosFinales.UseVisualStyleBackColor = true;
            this.btnSaldosFinales.Click += new System.EventHandler(this.btnSaldosFinales_Click);
            // 
            // dgvSaldoProveedores
            // 
            this.dgvSaldoProveedores.AllowUserToAddRows = false;
            this.dgvSaldoProveedores.AllowUserToDeleteRows = false;
            this.dgvSaldoProveedores.AutoGenerateColumns = false;
            this.dgvSaldoProveedores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSaldoProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldoProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorIdDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.tipoLXDataGridViewTextBoxColumn,
            this.vendorTypeDataGridViewTextBoxColumn,
            this.deudaTotalARSDataGridViewTextBoxColumn,
            this.tipoDocDataGridViewTextBoxColumn});
            this.dgvSaldoProveedores.DataSource = this.dgvStructuraBs;
            this.dgvSaldoProveedores.GridColor = System.Drawing.Color.IndianRed;
            this.dgvSaldoProveedores.Location = new System.Drawing.Point(12, 140);
            this.dgvSaldoProveedores.Name = "dgvSaldoProveedores";
            this.dgvSaldoProveedores.ReadOnly = true;
            this.dgvSaldoProveedores.RowHeadersWidth = 20;
            this.dgvSaldoProveedores.Size = new System.Drawing.Size(557, 509);
            this.dgvSaldoProveedores.TabIndex = 102;
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "IdProv";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // tipoLXDataGridViewTextBoxColumn
            // 
            this.tipoLXDataGridViewTextBoxColumn.DataPropertyName = "TipoLX";
            this.tipoLXDataGridViewTextBoxColumn.HeaderText = "LX";
            this.tipoLXDataGridViewTextBoxColumn.Name = "tipoLXDataGridViewTextBoxColumn";
            this.tipoLXDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoLXDataGridViewTextBoxColumn.Width = 35;
            // 
            // vendorTypeDataGridViewTextBoxColumn
            // 
            this.vendorTypeDataGridViewTextBoxColumn.DataPropertyName = "VendorType";
            this.vendorTypeDataGridViewTextBoxColumn.HeaderText = "VendorType";
            this.vendorTypeDataGridViewTextBoxColumn.Name = "vendorTypeDataGridViewTextBoxColumn";
            this.vendorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deudaTotalARSDataGridViewTextBoxColumn
            // 
            this.deudaTotalARSDataGridViewTextBoxColumn.DataPropertyName = "DeudaTotalARS";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "0";
            this.deudaTotalARSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.deudaTotalARSDataGridViewTextBoxColumn.HeaderText = "SaldoCtaCte";
            this.deudaTotalARSDataGridViewTextBoxColumn.Name = "deudaTotalARSDataGridViewTextBoxColumn";
            this.deudaTotalARSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDocDataGridViewTextBoxColumn
            // 
            this.tipoDocDataGridViewTextBoxColumn.DataPropertyName = "TipoDoc";
            this.tipoDocDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tipoDocDataGridViewTextBoxColumn.Name = "tipoDocDataGridViewTextBoxColumn";
            this.tipoDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDocDataGridViewTextBoxColumn.Width = 30;
            // 
            // dgvStructuraBs
            // 
            this.dgvStructuraBs.DataSource = typeof(Tecser.Business.Transactional.Cierre.EstructuraSaldosProveedores);
            // 
            // FrmCO14SaldosAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 722);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ckVerDetalleAP);
            this.Controls.Add(this.txtSaldoAPeriodoAP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDetalleAP);
            this.Controls.Add(this.lperiodo);
            this.Controls.Add(this.txtSaldoAPHoy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaldosIniciales);
            this.Controls.Add(this.btnSaldosFinales);
            this.Controls.Add(this.dgvSaldoProveedores);
            this.Name = "FrmCO14SaldosAP";
            this.Text = "FrmCO14SaldosAP";
            this.Load += new System.EventHandler(this.FrmCO14SaldosAP_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldoProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructuraBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadPeriodos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtPeriodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.CheckBox ckVerDetalleAP;
        private System.Windows.Forms.TextBox txtSaldoAPeriodoAP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetalleAP;
        private System.Windows.Forms.Label lperiodo;
        private System.Windows.Forms.TextBox txtSaldoAPHoy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaldosIniciales;
        private System.Windows.Forms.Button btnSaldosFinales;
        private System.Windows.Forms.BindingSource dgvStructuraBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deudaTotalARSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoLXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvSaldoProveedores;
    }
}