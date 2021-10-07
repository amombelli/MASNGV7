namespace MASngFE.Transactional.CRM
{
    partial class FrmPedidosPendientesMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListMaterial = new System.Windows.Forms.DataGridView();
            this.idSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgRequestedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgComprometidosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgRestantesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusOVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COMPRO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.materialRequestedInSOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbCodigoVenta = new System.Windows.Forms.ComboBox();
            this.t0011MATERIALESAKABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialRequestedInSOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListMaterial
            // 
            this.dgvListMaterial.AllowUserToAddRows = false;
            this.dgvListMaterial.AllowUserToDeleteRows = false;
            this.dgvListMaterial.AutoGenerateColumns = false;
            this.dgvListMaterial.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSODataGridViewTextBoxColumn,
            this.FechaSO,
            this.idClienteDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.clienteRsDataGridViewTextBoxColumn,
            this.kgRequestedDataGridViewTextBoxColumn,
            this.kgComprometidosDataGridViewTextBoxColumn,
            this.kgRestantesDataGridViewTextBoxColumn,
            this.statusOVDataGridViewTextBoxColumn,
            this.statusItemDataGridViewTextBoxColumn,
            this.VIEW,
            this.COMPRO});
            this.dgvListMaterial.DataSource = this.materialRequestedInSOBindingSource;
            this.dgvListMaterial.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListMaterial.Location = new System.Drawing.Point(16, 67);
            this.dgvListMaterial.Name = "dgvListMaterial";
            this.dgvListMaterial.ReadOnly = true;
            this.dgvListMaterial.RowHeadersWidth = 20;
            this.dgvListMaterial.Size = new System.Drawing.Size(1064, 487);
            this.dgvListMaterial.TabIndex = 0;
            // 
            // idSODataGridViewTextBoxColumn
            // 
            this.idSODataGridViewTextBoxColumn.DataPropertyName = "IdSO";
            this.idSODataGridViewTextBoxColumn.HeaderText = "SO #";
            this.idSODataGridViewTextBoxColumn.Name = "idSODataGridViewTextBoxColumn";
            this.idSODataGridViewTextBoxColumn.ReadOnly = true;
            this.idSODataGridViewTextBoxColumn.Width = 60;
            // 
            // FechaSO
            // 
            this.FechaSO.DataPropertyName = "FechaSO";
            this.FechaSO.HeaderText = "FECHA";
            this.FechaSO.Name = "FechaSO";
            this.FechaSO.ReadOnly = true;
            this.FechaSO.Width = 80;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteRsDataGridViewTextBoxColumn
            // 
            this.clienteRsDataGridViewTextBoxColumn.DataPropertyName = "ClienteRs";
            this.clienteRsDataGridViewTextBoxColumn.HeaderText = "CLIENTE RAZON SOC";
            this.clienteRsDataGridViewTextBoxColumn.Name = "clienteRsDataGridViewTextBoxColumn";
            this.clienteRsDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRsDataGridViewTextBoxColumn.Width = 160;
            // 
            // kgRequestedDataGridViewTextBoxColumn
            // 
            this.kgRequestedDataGridViewTextBoxColumn.DataPropertyName = "KgRequested";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.kgRequestedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.kgRequestedDataGridViewTextBoxColumn.HeaderText = "KG PEDIDO";
            this.kgRequestedDataGridViewTextBoxColumn.Name = "kgRequestedDataGridViewTextBoxColumn";
            this.kgRequestedDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgRequestedDataGridViewTextBoxColumn.Width = 65;
            // 
            // kgComprometidosDataGridViewTextBoxColumn
            // 
            this.kgComprometidosDataGridViewTextBoxColumn.DataPropertyName = "KgComprometidos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.kgComprometidosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.kgComprometidosDataGridViewTextBoxColumn.HeaderText = "KG COMPRO";
            this.kgComprometidosDataGridViewTextBoxColumn.Name = "kgComprometidosDataGridViewTextBoxColumn";
            this.kgComprometidosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgComprometidosDataGridViewTextBoxColumn.Width = 65;
            // 
            // kgRestantesDataGridViewTextBoxColumn
            // 
            this.kgRestantesDataGridViewTextBoxColumn.DataPropertyName = "KgRestantes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.kgRestantesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.kgRestantesDataGridViewTextBoxColumn.HeaderText = "KG RESTA";
            this.kgRestantesDataGridViewTextBoxColumn.Name = "kgRestantesDataGridViewTextBoxColumn";
            this.kgRestantesDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgRestantesDataGridViewTextBoxColumn.Width = 65;
            // 
            // statusOVDataGridViewTextBoxColumn
            // 
            this.statusOVDataGridViewTextBoxColumn.DataPropertyName = "StatusOV";
            this.statusOVDataGridViewTextBoxColumn.HeaderText = "ESTADO SO";
            this.statusOVDataGridViewTextBoxColumn.Name = "statusOVDataGridViewTextBoxColumn";
            this.statusOVDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusOVDataGridViewTextBoxColumn.Width = 80;
            // 
            // statusItemDataGridViewTextBoxColumn
            // 
            this.statusItemDataGridViewTextBoxColumn.DataPropertyName = "StatusItem";
            this.statusItemDataGridViewTextBoxColumn.HeaderText = "ESTADO ITEM";
            this.statusItemDataGridViewTextBoxColumn.Name = "statusItemDataGridViewTextBoxColumn";
            this.statusItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusItemDataGridViewTextBoxColumn.Width = 80;
            // 
            // VIEW
            // 
            this.VIEW.HeaderText = "VER";
            this.VIEW.Name = "VIEW";
            this.VIEW.ReadOnly = true;
            this.VIEW.Text = "VER";
            this.VIEW.ToolTipText = "Ver Orden de Venta";
            this.VIEW.Width = 60;
            // 
            // COMPRO
            // 
            this.COMPRO.HeaderText = "COMPRO";
            this.COMPRO.Name = "COMPRO";
            this.COMPRO.ReadOnly = true;
            this.COMPRO.Text = "COMPRO";
            this.COMPRO.ToolTipText = "Comprometer Stock";
            this.COMPRO.Width = 60;
            // 
            // materialRequestedInSOBindingSource
            // 
            this.materialRequestedInSOBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.SD_CRM.MaterialRequestedInSO);
            // 
            // cmbCodigoVenta
            // 
            this.cmbCodigoVenta.DataSource = this.t0011MATERIALESAKABindingSource;
            this.cmbCodigoVenta.DisplayMember = "CODVENTA";
            this.cmbCodigoVenta.FormattingEnabled = true;
            this.cmbCodigoVenta.Location = new System.Drawing.Point(127, 10);
            this.cmbCodigoVenta.Name = "cmbCodigoVenta";
            this.cmbCodigoVenta.Size = new System.Drawing.Size(124, 21);
            this.cmbCodigoVenta.TabIndex = 1;
            this.cmbCodigoVenta.ValueMember = "PRIMARIO";
            this.cmbCodigoVenta.SelectedIndexChanged += new System.EventHandler(this.cmbCodigoVenta_SelectedIndexChanged);
            // 
            // t0011MATERIALESAKABindingSource
            // 
            this.t0011MATERIALESAKABindingSource.DataSource = typeof(TecserEF.Entity.T0011_MATERIALES_AKA);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(979, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 33);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MATERIAL (AKA)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "si alguien ve  este mensaje avisarle a andres";
            // 
            // FrmPedidosPendientesMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 697);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cmbCodigoVenta);
            this.Controls.Add(this.dgvListMaterial);
            this.Name = "FrmPedidosPendientesMaterial";
            this.Text = "FrmPedidosPendientesMaterial";
            this.Load += new System.EventHandler(this.FrmPedidosPendientesMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialRequestedInSOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListMaterial;
        private System.Windows.Forms.BindingSource materialRequestedInSOBindingSource;
        private System.Windows.Forms.ComboBox cmbCodigoVenta;
        private System.Windows.Forms.BindingSource t0011MATERIALESAKABindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgRequestedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgComprometidosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgRestantesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusOVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VIEW;
        private System.Windows.Forms.DataGridViewButtonColumn COMPRO;
        private System.Windows.Forms.Label label2;
    }
}