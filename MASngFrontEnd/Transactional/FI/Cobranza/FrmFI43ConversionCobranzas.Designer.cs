namespace MASngFE.Transactional.FI.Cobranza
{
    partial class FrmFI43ConversionCobranzas
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
            this.dgvListadoCobranzas = new System.Windows.Forms.DataGridView();
            this.idCobTempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCobRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeReciboDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusReciboDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PRINT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t1205CobranzaConvertirHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckViewAll = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCobranzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t1205CobranzaConvertirHeaderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoCobranzas
            // 
            this.dgvListadoCobranzas.AllowUserToAddRows = false;
            this.dgvListadoCobranzas.AllowUserToDeleteRows = false;
            this.dgvListadoCobranzas.AutoGenerateColumns = false;
            this.dgvListadoCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoCobranzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCobTempDataGridViewTextBoxColumn,
            this.idCobRealDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.monedaDataGridViewTextBoxColumn,
            this.importeReciboDataGridViewTextBoxColumn,
            this.lXDataGridViewTextBoxColumn,
            this.statusReciboDataGridViewTextBoxColumn,
            this.CONTA,
            this.PRINT});
            this.dgvListadoCobranzas.DataSource = this.t1205CobranzaConvertirHeaderBindingSource;
            this.dgvListadoCobranzas.Location = new System.Drawing.Point(5, 49);
            this.dgvListadoCobranzas.Name = "dgvListadoCobranzas";
            this.dgvListadoCobranzas.ReadOnly = true;
            this.dgvListadoCobranzas.Size = new System.Drawing.Size(776, 557);
            this.dgvListadoCobranzas.TabIndex = 0;
            this.dgvListadoCobranzas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCobranzas_CellContentClick);
            // 
            // idCobTempDataGridViewTextBoxColumn
            // 
            this.idCobTempDataGridViewTextBoxColumn.DataPropertyName = "idCobTemp";
            this.idCobTempDataGridViewTextBoxColumn.HeaderText = "ID#";
            this.idCobTempDataGridViewTextBoxColumn.Name = "idCobTempDataGridViewTextBoxColumn";
            this.idCobTempDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCobTempDataGridViewTextBoxColumn.Width = 45;
            // 
            // idCobRealDataGridViewTextBoxColumn
            // 
            this.idCobRealDataGridViewTextBoxColumn.DataPropertyName = "idCobReal";
            this.idCobRealDataGridViewTextBoxColumn.HeaderText = "IDCOB";
            this.idCobRealDataGridViewTextBoxColumn.Name = "idCobRealDataGridViewTextBoxColumn";
            this.idCobRealDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCobRealDataGridViewTextBoxColumn.Width = 50;
            // 
            // fechaIngresoDataGridViewTextBoxColumn
            // 
            this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "FechaIngreso";
            dataGridViewCellStyle1.Format = "d";
            this.fechaIngresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "FECHA ING";
            this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
            this.fechaIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "CLIENTE RAZON SOCIAL";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // monedaDataGridViewTextBoxColumn
            // 
            this.monedaDataGridViewTextBoxColumn.DataPropertyName = "Moneda";
            this.monedaDataGridViewTextBoxColumn.HeaderText = "MON";
            this.monedaDataGridViewTextBoxColumn.Name = "monedaDataGridViewTextBoxColumn";
            this.monedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.monedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // importeReciboDataGridViewTextBoxColumn
            // 
            this.importeReciboDataGridViewTextBoxColumn.DataPropertyName = "ImporteRecibo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.importeReciboDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.importeReciboDataGridViewTextBoxColumn.HeaderText = "IMPORTE";
            this.importeReciboDataGridViewTextBoxColumn.Name = "importeReciboDataGridViewTextBoxColumn";
            this.importeReciboDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeReciboDataGridViewTextBoxColumn.Width = 80;
            // 
            // lXDataGridViewTextBoxColumn
            // 
            this.lXDataGridViewTextBoxColumn.DataPropertyName = "LX";
            this.lXDataGridViewTextBoxColumn.HeaderText = "LX";
            this.lXDataGridViewTextBoxColumn.Name = "lXDataGridViewTextBoxColumn";
            this.lXDataGridViewTextBoxColumn.ReadOnly = true;
            this.lXDataGridViewTextBoxColumn.Width = 35;
            // 
            // statusReciboDataGridViewTextBoxColumn
            // 
            this.statusReciboDataGridViewTextBoxColumn.DataPropertyName = "StatusRecibo";
            this.statusReciboDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.statusReciboDataGridViewTextBoxColumn.Name = "statusReciboDataGridViewTextBoxColumn";
            this.statusReciboDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusReciboDataGridViewTextBoxColumn.Width = 80;
            // 
            // CONTA
            // 
            this.CONTA.HeaderText = "CONTA";
            this.CONTA.Name = "CONTA";
            this.CONTA.ReadOnly = true;
            this.CONTA.Text = "CONTA";
            this.CONTA.ToolTipText = "Contabilizar esta Cobranza";
            this.CONTA.UseColumnTextForButtonValue = true;
            this.CONTA.Width = 50;
            // 
            // PRINT
            // 
            this.PRINT.HeaderText = "PRINT";
            this.PRINT.Name = "PRINT";
            this.PRINT.ReadOnly = true;
            this.PRINT.Text = "PRINT";
            this.PRINT.UseColumnTextForButtonValue = true;
            this.PRINT.Width = 60;
            // 
            // t1205CobranzaConvertirHeaderBindingSource
            // 
            this.t1205CobranzaConvertirHeaderBindingSource.DataSource = typeof(TecserEF.Entity.T1205_CobranzaConvertirHeader);
            // 
            // ckViewAll
            // 
            this.ckViewAll.AutoSize = true;
            this.ckViewAll.Location = new System.Drawing.Point(5, 610);
            this.ckViewAll.Name = "ckViewAll";
            this.ckViewAll.Size = new System.Drawing.Size(152, 18);
            this.ckViewAll.TabIndex = 2;
            this.ckViewAll.Text = "Ver Todos los Registros";
            this.ckViewAll.UseVisualStyleBackColor = true;
            this.ckViewAll.CheckedChanged += new System.EventHandler(this.ckViewAll_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(681, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 43);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmFI43ConversionCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 689);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ckViewAll);
            this.Controls.Add(this.dgvListadoCobranzas);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI43ConversionCobranzas";
            this.Text = "FI43 - Listado de Cobranzas por Convertir";
            this.Load += new System.EventHandler(this.FrmConversionCobranzas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCobranzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t1205CobranzaConvertirHeaderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoCobranzas;
        private System.Windows.Forms.BindingSource t1205CobranzaConvertirHeaderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCobTempDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCobRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeReciboDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusReciboDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn CONTA;
        private System.Windows.Forms.DataGridViewButtonColumn PRINT;
        private System.Windows.Forms.CheckBox ckViewAll;
        private System.Windows.Forms.Button btnExit;
    }
}