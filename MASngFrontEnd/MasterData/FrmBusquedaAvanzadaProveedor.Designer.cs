namespace MASngFE.MasterData
{
    partial class FrmBusquedaAvanzadaProveedor
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
            this.dgvListaProveedores = new System.Windows.Forms.DataGridView();
            this.t0005MPROVEEDORESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provrsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provfantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMAILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.txtNumeroCuit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaProveedores
            // 
            this.dgvListaProveedores.AllowUserToAddRows = false;
            this.dgvListaProveedores.AllowUserToDeleteRows = false;
            this.dgvListaProveedores.AutoGenerateColumns = false;
            this.dgvListaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprovDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.provrsocialDataGridViewTextBoxColumn,
            this.provfantasiaDataGridViewTextBoxColumn,
            this.Telefono,
            this.contactoDataGridViewTextBoxColumn,
            this.clienteDataGridViewTextBoxColumn,
            this.tTAX1DataGridViewTextBoxColumn,
            this.nTAX1DataGridViewTextBoxColumn,
            this.eMAILDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewTextBoxColumn});
            this.dgvListaProveedores.DataSource = this.t0005MPROVEEDORESBindingSource;
            this.dgvListaProveedores.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListaProveedores.Location = new System.Drawing.Point(12, 126);
            this.dgvListaProveedores.MultiSelect = false;
            this.dgvListaProveedores.Name = "dgvListaProveedores";
            this.dgvListaProveedores.ReadOnly = true;
            this.dgvListaProveedores.RowHeadersWidth = 20;
            this.dgvListaProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProveedores.Size = new System.Drawing.Size(899, 341);
            this.dgvListaProveedores.TabIndex = 0;
            this.dgvListaProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaProveedores_CellContentClick);
            // 
            // t0005MPROVEEDORESBindingSource
            // 
            this.t0005MPROVEEDORESBindingSource.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // idprovDataGridViewTextBoxColumn
            // 
            this.idprovDataGridViewTextBoxColumn.DataPropertyName = "id_prov";
            this.idprovDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idprovDataGridViewTextBoxColumn.Name = "idprovDataGridViewTextBoxColumn";
            this.idprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprovDataGridViewTextBoxColumn.Width = 50;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 50;
            // 
            // provrsocialDataGridViewTextBoxColumn
            // 
            this.provrsocialDataGridViewTextBoxColumn.DataPropertyName = "prov_rsocial";
            this.provrsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.provrsocialDataGridViewTextBoxColumn.Name = "provrsocialDataGridViewTextBoxColumn";
            this.provrsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.provrsocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // provfantasiaDataGridViewTextBoxColumn
            // 
            this.provfantasiaDataGridViewTextBoxColumn.DataPropertyName = "prov_fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.Name = "provfantasiaDataGridViewTextBoxColumn";
            this.provfantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 80;
            // 
            // contactoDataGridViewTextBoxColumn
            // 
            this.contactoDataGridViewTextBoxColumn.DataPropertyName = "Contacto";
            this.contactoDataGridViewTextBoxColumn.HeaderText = "Contacto";
            this.contactoDataGridViewTextBoxColumn.Name = "contactoDataGridViewTextBoxColumn";
            this.contactoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            this.clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            this.clienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            this.clienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDataGridViewTextBoxColumn.Width = 60;
            // 
            // tTAX1DataGridViewTextBoxColumn
            // 
            this.tTAX1DataGridViewTextBoxColumn.DataPropertyName = "TTAX1";
            this.tTAX1DataGridViewTextBoxColumn.HeaderText = "TTAX1";
            this.tTAX1DataGridViewTextBoxColumn.Name = "tTAX1DataGridViewTextBoxColumn";
            this.tTAX1DataGridViewTextBoxColumn.ReadOnly = true;
            this.tTAX1DataGridViewTextBoxColumn.Width = 50;
            // 
            // nTAX1DataGridViewTextBoxColumn
            // 
            this.nTAX1DataGridViewTextBoxColumn.DataPropertyName = "NTAX1";
            this.nTAX1DataGridViewTextBoxColumn.HeaderText = "NTAX1";
            this.nTAX1DataGridViewTextBoxColumn.Name = "nTAX1DataGridViewTextBoxColumn";
            this.nTAX1DataGridViewTextBoxColumn.ReadOnly = true;
            this.nTAX1DataGridViewTextBoxColumn.Width = 70;
            // 
            // eMAILDataGridViewTextBoxColumn
            // 
            this.eMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.Name = "eMAILDataGridViewTextBoxColumn";
            this.eMAILDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCTIVODataGridViewTextBoxColumn
            // 
            this.aCTIVODataGridViewTextBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.HeaderText = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.Name = "aCTIVODataGridViewTextBoxColumn";
            this.aCTIVODataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVODataGridViewTextBoxColumn.Width = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "TAX NUMBER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "NOMBRE FANTASIA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "RAZON SOCIAL";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(143, 12);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(189, 20);
            this.txtRazonSocial.TabIndex = 21;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRazonSocial_KeyDown);
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(143, 34);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(189, 20);
            this.txtFantasia.TabIndex = 22;
            // 
            // txtNumeroCuit
            // 
            this.txtNumeroCuit.Location = new System.Drawing.Point(143, 57);
            this.txtNumeroCuit.Name = "txtNumeroCuit";
            this.txtNumeroCuit.Size = new System.Drawing.Size(113, 20);
            this.txtNumeroCuit.TabIndex = 23;
            // 
            // FrmBusquedaAvanzadaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 614);
            this.Controls.Add(this.txtNumeroCuit);
            this.Controls.Add(this.txtFantasia);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaProveedores);
            this.Name = "FrmBusquedaAvanzadaProveedor";
            this.Text = "BUSQUEDA AVANZADA DE PROVEEDORES";
            this.Load += new System.EventHandler(this.FrmBusquedaAvanzadaProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provrsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provfantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMAILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0005MPROVEEDORESBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.TextBox txtNumeroCuit;
    }
}