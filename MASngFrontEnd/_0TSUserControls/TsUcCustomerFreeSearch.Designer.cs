namespace MASngFE._0TSUserControls
{
    partial class TsUcCustomerFreeSearch
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtBusquedaRazon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBusquedaFantasia = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusquedaCuit = new System.Windows.Forms.TextBox();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.stxCustomerSimpleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stxCustomerSimpleBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.idClienteDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.fantasiaDataGridViewTextBoxColumn,
            this.cuitDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn,
            this.Seleccion});
            this.dgvData.DataSource = this.stxCustomerSimpleBindingSource;
            this.dgvData.GridColor = System.Drawing.Color.Navy;
            this.dgvData.Location = new System.Drawing.Point(8, 65);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(694, 377);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // txtBusquedaRazon
            // 
            this.txtBusquedaRazon.Location = new System.Drawing.Point(85, 5);
            this.txtBusquedaRazon.Name = "txtBusquedaRazon";
            this.txtBusquedaRazon.Size = new System.Drawing.Size(169, 23);
            this.txtBusquedaRazon.TabIndex = 1;
            this.txtBusquedaRazon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaRazon_KeyUp);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fantasia";
            // 
            // txtBusquedaFantasia
            // 
            this.txtBusquedaFantasia.Location = new System.Drawing.Point(85, 30);
            this.txtBusquedaFantasia.Name = "txtBusquedaFantasia";
            this.txtBusquedaFantasia.Size = new System.Drawing.Size(169, 23);
            this.txtBusquedaFantasia.TabIndex = 3;
            this.txtBusquedaFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaRazon_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBusquedaCuit);
            this.panel1.Controls.Add(this.txtBusquedaRazon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBusquedaFantasia);
            this.panel1.Location = new System.Drawing.Point(8, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 58);
            this.panel1.TabIndex = 5;
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
            this.txtBusquedaCuit.Location = new System.Drawing.Point(307, 30);
            this.txtBusquedaCuit.Name = "txtBusquedaCuit";
            this.txtBusquedaCuit.Size = new System.Drawing.Size(74, 23);
            this.txtBusquedaCuit.TabIndex = 5;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "SEL";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "SEL";
            this.dataGridViewButtonColumn1.ToolTipText = "Seleccionar Cliente";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 40;
            // 
            // stxCustomerSimpleBindingSource
            // 
            this.stxCustomerSimpleBindingSource.DataSource = typeof(Tecser.Business.MasterData.Customer.StxCustomerSimple);
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "#";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.ToolTipText = "Numero de Cliente";
            this.idClienteDataGridViewTextBoxColumn.Width = 45;
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
            this.fantasiaDataGridViewTextBoxColumn.Width = 200;
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            this.cuitDataGridViewTextBoxColumn.DataPropertyName = "Cuit";
            this.cuitDataGridViewTextBoxColumn.HeaderText = "Cuit";
            this.cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            this.cuitDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuitDataGridViewTextBoxColumn.Width = 90;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Act";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activoDataGridViewCheckBoxColumn.ToolTipText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Width = 40;
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
            // TsUcCustomerFreeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 447);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TsUcCustomerFreeSearch";
            this.Text = "Busqueda Avanzada de Clientes";
            this.Load += new System.EventHandler(this.TsUcCustomerFreeSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stxCustomerSimpleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource stxCustomerSimpleBindingSource;
        private System.Windows.Forms.TextBox txtBusquedaRazon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBusquedaFantasia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusquedaCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccion;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}