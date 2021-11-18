namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCo35ResumenPagosCtaCte
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
            this.dgvDatosPagosCtaCte = new System.Windows.Forms.DataGridView();
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEARSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t203Bs = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMontoOut = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaldoImpago = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPagosCtaCte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatosPagosCtaCte
            // 
            this.dgvDatosPagosCtaCte.AllowUserToAddRows = false;
            this.dgvDatosPagosCtaCte.AllowUserToDeleteRows = false;
            this.dgvDatosPagosCtaCte.AutoGenerateColumns = false;
            this.dgvDatosPagosCtaCte.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatosPagosCtaCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosPagosCtaCte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.iMPORTEARSDataGridViewTextBoxColumn,
            this.sALDOFACTURADataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn});
            this.dgvDatosPagosCtaCte.DataSource = this.t203Bs;
            this.dgvDatosPagosCtaCte.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dgvDatosPagosCtaCte.Location = new System.Drawing.Point(8, 100);
            this.dgvDatosPagosCtaCte.Name = "dgvDatosPagosCtaCte";
            this.dgvDatosPagosCtaCte.ReadOnly = true;
            this.dgvDatosPagosCtaCte.RowHeadersWidth = 20;
            this.dgvDatosPagosCtaCte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosPagosCtaCte.Size = new System.Drawing.Size(542, 632);
            this.dgvDatosPagosCtaCte.TabIndex = 0;
            // 
            // iDCTACTEDataGridViewTextBoxColumn
            // 
            this.iDCTACTEDataGridViewTextBoxColumn.DataPropertyName = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.HeaderText = "IdCtaCte";
            this.iDCTACTEDataGridViewTextBoxColumn.Name = "iDCTACTEDataGridViewTextBoxColumn";
            this.iDCTACTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCTACTEDataGridViewTextBoxColumn.ToolTipText = "ID CtaCte";
            this.iDCTACTEDataGridViewTextBoxColumn.Width = 60;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tDOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "Td";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.ToolTipText = "Tipo Documento";
            this.tDOCDataGridViewTextBoxColumn.Width = 30;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "Documento#";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMDOCDataGridViewTextBoxColumn.ToolTipText = "Numero de Documento";
            this.nUMDOCDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEARSDataGridViewTextBoxColumn
            // 
            this.iMPORTEARSDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE_ARS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "C2";
            this.iMPORTEARSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iMPORTEARSDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.iMPORTEARSDataGridViewTextBoxColumn.Name = "iMPORTEARSDataGridViewTextBoxColumn";
            this.iMPORTEARSDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEARSDataGridViewTextBoxColumn.ToolTipText = "Importe Pesos";
            this.iMPORTEARSDataGridViewTextBoxColumn.Width = 90;
            // 
            // sALDOFACTURADataGridViewTextBoxColumn
            // 
            this.sALDOFACTURADataGridViewTextBoxColumn.DataPropertyName = "SALDOFACTURA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle3.Format = "C2";
            this.sALDOFACTURADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.sALDOFACTURADataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.sALDOFACTURADataGridViewTextBoxColumn.Name = "sALDOFACTURADataGridViewTextBoxColumn";
            this.sALDOFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.sALDOFACTURADataGridViewTextBoxColumn.ToolTipText = "Saldo";
            this.sALDOFACTURADataGridViewTextBoxColumn.Width = 90;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // t203Bs
            // 
            this.t203Bs.DataSource = typeof(TecserEF.Entity.T0203_CTACTE_PROV);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(530, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 88;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 734);
            this.label2.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(650, 2);
            this.label8.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(653, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 734);
            this.label1.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(3, 735);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(650, 2);
            this.label3.TabIndex = 97;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoImpago);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtLx);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtMontoOut);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(212, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 88);
            this.panel2.TabIndex = 104;
            // 
            // txtLx
            // 
            this.txtLx.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLx.Location = new System.Drawing.Point(95, 8);
            this.txtLx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(37, 23);
            this.txtLx.TabIndex = 101;
            this.txtLx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 94;
            this.label9.Text = "Tipo Operacion";
            // 
            // txtMontoOut
            // 
            this.txtMontoOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMontoOut.Location = new System.Drawing.Point(95, 32);
            this.txtMontoOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMontoOut.Name = "txtMontoOut";
            this.txtMontoOut.ReadOnly = true;
            this.txtMontoOut.Size = new System.Drawing.Size(116, 23);
            this.txtMontoOut.TabIndex = 100;
            this.txtMontoOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 99;
            this.label11.Text = "Total Egresos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFechaHasta);
            this.panel1.Controls.Add(this.txtFechaDesde);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 88);
            this.panel1.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(16, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 15);
            this.label4.TabIndex = 94;
            this.label4.Text = "Detalles de Egresos por Cuenta";
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
            // txtSaldoImpago
            // 
            this.txtSaldoImpago.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSaldoImpago.Location = new System.Drawing.Point(95, 56);
            this.txtSaldoImpago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSaldoImpago.Name = "txtSaldoImpago";
            this.txtSaldoImpago.ReadOnly = true;
            this.txtSaldoImpago.Size = new System.Drawing.Size(116, 23);
            this.txtSaldoImpago.TabIndex = 103;
            this.txtSaldoImpago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 102;
            this.label5.Text = "Saldo Impago";
            // 
            // FrmCo35ResumenPagosCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 740);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDatosPagosCtaCte);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCo35ResumenPagosCtaCte";
            this.Text = "CO35 - Resumen de Pagos [CtaCte]";
            this.Load += new System.EventHandler(this.FrmCo35ResumenPagosCtaCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPagosCtaCte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosPagosCtaCte;
        private System.Windows.Forms.BindingSource t203Bs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEARSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMontoOut;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSaldoImpago;
        private System.Windows.Forms.Label label5;
    }
}