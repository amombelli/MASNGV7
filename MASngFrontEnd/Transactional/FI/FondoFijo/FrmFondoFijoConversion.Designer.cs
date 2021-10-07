namespace MASngFE.Transactional.FI.FondoFijo
{
    partial class FrmFondoFijoConversion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPendienteImputar = new System.Windows.Forms.TextBox();
            this.txtGlFondoFijo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaldoFF = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCuentaFF = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvListadoConversion = new System.Windows.Forms.DataGridView();
            this.t0406RendicionFFHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idRendicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoLxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusRendicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeNetoFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONVERTIR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoConversion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0406RendicionFFHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.txtPendienteImputar);
            this.panel3.Controls.Add(this.txtGlFondoFijo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtMon);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtSaldoFF);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.cmbCuentaFF);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 56);
            this.panel3.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(306, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "PENDIENTE";
            // 
            // txtPendienteImputar
            // 
            this.txtPendienteImputar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPendienteImputar.Location = new System.Drawing.Point(381, 5);
            this.txtPendienteImputar.Name = "txtPendienteImputar";
            this.txtPendienteImputar.ReadOnly = true;
            this.txtPendienteImputar.Size = new System.Drawing.Size(96, 20);
            this.txtPendienteImputar.TabIndex = 20;
            this.txtPendienteImputar.TabStop = false;
            // 
            // txtGlFondoFijo
            // 
            this.txtGlFondoFijo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtGlFondoFijo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0150CUENTASBindingSource, "GLMAP", true));
            this.txtGlFondoFijo.Location = new System.Drawing.Point(83, 28);
            this.txtGlFondoFijo.Name = "txtGlFondoFijo";
            this.txtGlFondoFijo.ReadOnly = true;
            this.txtGlFondoFijo.Size = new System.Drawing.Size(103, 20);
            this.txtGlFondoFijo.TabIndex = 19;
            this.txtGlFondoFijo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "MON";
            // 
            // txtMon
            // 
            this.txtMon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtMon.Location = new System.Drawing.Point(229, 28);
            this.txtMon.Name = "txtMon";
            this.txtMon.ReadOnly = true;
            this.txtMon.Size = new System.Drawing.Size(54, 20);
            this.txtMon.TabIndex = 16;
            this.txtMon.TabStop = false;
            this.txtMon.Text = "ARS";
            this.txtMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "SALDO";
            // 
            // txtSaldoFF
            // 
            this.txtSaldoFF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSaldoFF.Location = new System.Drawing.Point(381, 27);
            this.txtSaldoFF.Name = "txtSaldoFF";
            this.txtSaldoFF.ReadOnly = true;
            this.txtSaldoFF.Size = new System.Drawing.Size(96, 20);
            this.txtSaldoFF.TabIndex = 4;
            this.txtSaldoFF.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "GL CUENTA";
            // 
            // cmbCuentaFF
            // 
            this.cmbCuentaFF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCuentaFF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCuentaFF.DataSource = this.t0150CUENTASBindingSource;
            this.cmbCuentaFF.DisplayMember = "CUENTA_DESC";
            this.cmbCuentaFF.FormattingEnabled = true;
            this.cmbCuentaFF.Location = new System.Drawing.Point(83, 5);
            this.cmbCuentaFF.Name = "cmbCuentaFF";
            this.cmbCuentaFF.Size = new System.Drawing.Size(200, 21);
            this.cmbCuentaFF.TabIndex = 0;
            this.cmbCuentaFF.ValueMember = "ID_CUENTA";
            this.cmbCuentaFF.SelectedIndexChanged += new System.EventHandler(this.cmbCuentaFF_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "CUENTA FF";
            // 
            // dgvListadoConversion
            // 
            this.dgvListadoConversion.AllowUserToAddRows = false;
            this.dgvListadoConversion.AllowUserToDeleteRows = false;
            this.dgvListadoConversion.AutoGenerateColumns = false;
            this.dgvListadoConversion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoConversion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRendicionDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.tipoDocumentoDataGridViewTextBoxColumn,
            this.numeroDocumentoDataGridViewTextBoxColumn,
            this.tipoLxDataGridViewTextBoxColumn,
            this.statusRendicionDataGridViewTextBoxColumn,
            this.importeNetoFinalDataGridViewTextBoxColumn,
            this.comentarioDataGridViewTextBoxColumn,
            this.CONVERTIR});
            this.dgvListadoConversion.DataSource = this.t0406RendicionFFHBindingSource;
            this.dgvListadoConversion.Location = new System.Drawing.Point(3, 65);
            this.dgvListadoConversion.Name = "dgvListadoConversion";
            this.dgvListadoConversion.ReadOnly = true;
            this.dgvListadoConversion.RowHeadersWidth = 20;
            this.dgvListadoConversion.Size = new System.Drawing.Size(752, 400);
            this.dgvListadoConversion.TabIndex = 2;
            this.dgvListadoConversion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoConversion_CellContentClick);
            // 
            // t0406RendicionFFHBindingSource
            // 
            this.t0406RendicionFFHBindingSource.DataSource = typeof(TecserEF.Entity.T0406_RendicionFF_H);
            // 
            // idRendicionDataGridViewTextBoxColumn
            // 
            this.idRendicionDataGridViewTextBoxColumn.DataPropertyName = "idRendicion";
            this.idRendicionDataGridViewTextBoxColumn.HeaderText = "IDR";
            this.idRendicionDataGridViewTextBoxColumn.Name = "idRendicionDataGridViewTextBoxColumn";
            this.idRendicionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRendicionDataGridViewTextBoxColumn.Width = 30;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "razonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // tipoDocumentoDataGridViewTextBoxColumn
            // 
            this.tipoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "tipoDocumento";
            this.tipoDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tipoDocumentoDataGridViewTextBoxColumn.Name = "tipoDocumentoDataGridViewTextBoxColumn";
            this.tipoDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDocumentoDataGridViewTextBoxColumn.Width = 30;
            // 
            // numeroDocumentoDataGridViewTextBoxColumn
            // 
            this.numeroDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numeroDocumento";
            this.numeroDocumentoDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.numeroDocumentoDataGridViewTextBoxColumn.Name = "numeroDocumentoDataGridViewTextBoxColumn";
            this.numeroDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroDocumentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipoLxDataGridViewTextBoxColumn
            // 
            this.tipoLxDataGridViewTextBoxColumn.DataPropertyName = "tipoLx";
            this.tipoLxDataGridViewTextBoxColumn.HeaderText = "LX";
            this.tipoLxDataGridViewTextBoxColumn.Name = "tipoLxDataGridViewTextBoxColumn";
            this.tipoLxDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoLxDataGridViewTextBoxColumn.Width = 30;
            // 
            // statusRendicionDataGridViewTextBoxColumn
            // 
            this.statusRendicionDataGridViewTextBoxColumn.DataPropertyName = "StatusRendicion";
            this.statusRendicionDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.statusRendicionDataGridViewTextBoxColumn.Name = "statusRendicionDataGridViewTextBoxColumn";
            this.statusRendicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeNetoFinalDataGridViewTextBoxColumn
            // 
            this.importeNetoFinalDataGridViewTextBoxColumn.DataPropertyName = "ImporteNetoFinal";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "c2";
            this.importeNetoFinalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.importeNetoFinalDataGridViewTextBoxColumn.HeaderText = "IMPORTE";
            this.importeNetoFinalDataGridViewTextBoxColumn.Name = "importeNetoFinalDataGridViewTextBoxColumn";
            this.importeNetoFinalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CONVERTIR
            // 
            this.CONVERTIR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CONVERTIR.HeaderText = "CONVERTIR";
            this.CONVERTIR.Name = "CONVERTIR";
            this.CONVERTIR.ReadOnly = true;
            this.CONVERTIR.Text = "CONVERTIR";
            this.CONVERTIR.UseColumnTextForButtonValue = true;
            this.CONVERTIR.Width = 80;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(626, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 48);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // FrmFondoFijoConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 468);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvListadoConversion);
            this.Controls.Add(this.panel3);
            this.Name = "FrmFondoFijoConversion";
            this.Text = "CONVERSION DE INGRESO TEMPORAL";
            this.Load += new System.EventHandler(this.FrmFondoFijoConversion_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoConversion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0406RendicionFFHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPendienteImputar;
        private System.Windows.Forms.TextBox txtGlFondoFijo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSaldoFF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCuentaFF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvListadoConversion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRendicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoLxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusRendicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeNetoFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn CONVERTIR;
        private System.Windows.Forms.BindingSource t0406RendicionFFHBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
    }
}