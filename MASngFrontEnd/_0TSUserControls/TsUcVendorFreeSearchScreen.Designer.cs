namespace MASngFE._0TSUserControls
{
    partial class TsUcVendorFreeSearchScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTipoProveedor = new System.Windows.Forms.ComboBox();
            this.t0014TIPOPROVEEDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusquedaCuit = new System.Windows.Forms.TextBox();
            this.txtBusquedaRazon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusquedaFantasia = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vendorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StxVendorSimpleBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0014TIPOPROVEEDORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StxVendorSimpleBs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.cmbTipoProveedor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBusquedaCuit);
            this.panel1.Controls.Add(this.txtBusquedaRazon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBusquedaFantasia);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 58);
            this.panel1.TabIndex = 7;
            // 
            // cmbTipoProveedor
            // 
            this.cmbTipoProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoProveedor.DataSource = this.t0014TIPOPROVEEDORBindingSource;
            this.cmbTipoProveedor.DisplayMember = "TIPOPROV";
            this.cmbTipoProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoProveedor.FormattingEnabled = true;
            this.cmbTipoProveedor.Location = new System.Drawing.Point(543, 30);
            this.cmbTipoProveedor.Name = "cmbTipoProveedor";
            this.cmbTipoProveedor.Size = new System.Drawing.Size(145, 23);
            this.cmbTipoProveedor.TabIndex = 131;
            this.cmbTipoProveedor.ValueMember = "TIPOPROV";
            this.cmbTipoProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProveedor_SelectedIndexChanged);
            this.cmbTipoProveedor.TextUpdate += new System.EventHandler(this.cmbTipoProveedor_TextUpdate);
            // 
            // t0014TIPOPROVEEDORBindingSource
            // 
            this.t0014TIPOPROVEEDORBindingSource.DataSource = typeof(TecserEF.Entity.T0014_TIPO_PROVEEDOR);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo de Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "CUIT";
            // 
            // txtBusquedaCuit
            // 
            this.txtBusquedaCuit.Location = new System.Drawing.Point(304, 30);
            this.txtBusquedaCuit.Name = "txtBusquedaCuit";
            this.txtBusquedaCuit.Size = new System.Drawing.Size(115, 23);
            this.txtBusquedaCuit.TabIndex = 5;
            this.txtBusquedaCuit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaRazon_KeyUp);
            // 
            // txtBusquedaRazon
            // 
            this.txtBusquedaRazon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtBusquedaRazon.Location = new System.Drawing.Point(85, 5);
            this.txtBusquedaRazon.Name = "txtBusquedaRazon";
            this.txtBusquedaRazon.Size = new System.Drawing.Size(169, 23);
            this.txtBusquedaRazon.TabIndex = 1;
            this.txtBusquedaRazon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaRazon_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fantasia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razon Social";
            // 
            // txtBusquedaFantasia
            // 
            this.txtBusquedaFantasia.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtBusquedaFantasia.Location = new System.Drawing.Point(85, 30);
            this.txtBusquedaFantasia.Name = "txtBusquedaFantasia";
            this.txtBusquedaFantasia.Size = new System.Drawing.Size(169, 23);
            this.txtBusquedaFantasia.TabIndex = 3;
            this.txtBusquedaFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaRazon_KeyUp);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorIdDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.fantasiaDataGridViewTextBoxColumn,
            this.cuitDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn,
            this.vendorTypeDataGridViewTextBoxColumn,
            this.Seleccion});
            this.dgvData.DataSource = this.StxVendorSimpleBs;
            this.dgvData.GridColor = System.Drawing.Color.Navy;
            this.dgvData.Location = new System.Drawing.Point(4, 66);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(694, 456);
            this.dgvData.TabIndex = 6;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "#";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorIdDataGridViewTextBoxColumn.ToolTipText = "Vendor ID";
            this.vendorIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // fantasiaDataGridViewTextBoxColumn
            // 
            this.fantasiaDataGridViewTextBoxColumn.DataPropertyName = "Fantasia";
            this.fantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.fantasiaDataGridViewTextBoxColumn.Name = "fantasiaDataGridViewTextBoxColumn";
            this.fantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fantasiaDataGridViewTextBoxColumn.Width = 180;
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            this.cuitDataGridViewTextBoxColumn.DataPropertyName = "Cuit";
            this.cuitDataGridViewTextBoxColumn.HeaderText = "Cuit";
            this.cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            this.cuitDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuitDataGridViewTextBoxColumn.Width = 80;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Act";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activoDataGridViewCheckBoxColumn.ToolTipText = "Proveedor Activo";
            this.activoDataGridViewCheckBoxColumn.Width = 35;
            // 
            // vendorTypeDataGridViewTextBoxColumn
            // 
            this.vendorTypeDataGridViewTextBoxColumn.DataPropertyName = "VendorType";
            this.vendorTypeDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.vendorTypeDataGridViewTextBoxColumn.Name = "vendorTypeDataGridViewTextBoxColumn";
            this.vendorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorTypeDataGridViewTextBoxColumn.ToolTipText = "Tipo de Proveedor";
            this.vendorTypeDataGridViewTextBoxColumn.Width = 85;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "SEL";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.ReadOnly = true;
            this.Seleccion.Text = "SEL";
            this.Seleccion.ToolTipText = "Seleccionar Cliente";
            this.Seleccion.UseColumnTextForButtonValue = true;
            this.Seleccion.Width = 40;
            // 
            // StxVendorSimpleBs
            // 
            this.StxVendorSimpleBs.DataSource = typeof(Tecser.Business.MasterData.Vendor_Master.StxVendnorSimple);
            // 
            // TsUcVendorFreeSearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 526);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TsUcVendorFreeSearchScreen";
            this.Text = "Busqueda Avanzada de Proveedores";
            this.Load += new System.EventHandler(this.TsUcVendorFreeSearchScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0014TIPOPROVEEDORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StxVendorSimpleBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusquedaCuit;
        private System.Windows.Forms.TextBox txtBusquedaRazon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusquedaFantasia;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource StxVendorSimpleBs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccion;
        private System.Windows.Forms.ComboBox cmbTipoProveedor;
        private System.Windows.Forms.BindingSource t0014TIPOPROVEEDORBindingSource;
    }
}