namespace MASngFE.Transactional.SD.SalesOrder
{
    partial class FrmSD01SalesOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD01SalesOrderSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SalesOrderBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevaSO = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVerCliente = new System.Windows.Forms.Button();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDescripcionT7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteFantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListadoSO = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmax = new TSControls.CtlTextBox();
            this.txtNumeroOv = new System.Windows.Forms.TextBox();
            this.CustomerFilter = new MASngFE._0TSUserControls.TsUcCustomer3();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SalesOrderBs
            // 
            this.SalesOrderBs.DataSource = typeof(TecserEF.Entity.DataStructure.DsSalesOrderList);
            // 
            // btnNuevaSO
            // 
            this.btnNuevaSO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaSO.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaSO.Image")));
            this.btnNuevaSO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaSO.Location = new System.Drawing.Point(664, 48);
            this.btnNuevaSO.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaSO.Name = "btnNuevaSO";
            this.btnNuevaSO.Size = new System.Drawing.Size(107, 42);
            this.btnNuevaSO.TabIndex = 91;
            this.btnNuevaSO.Text = "Nueva\r\nSO";
            this.btnNuevaSO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaSO.UseVisualStyleBackColor = true;
            this.btnNuevaSO.Click += new System.EventHandler(this.btnNuevaSO_Click);
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.MediumBlue;
            this.label55.Location = new System.Drawing.Point(2, 2);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(3, 623);
            this.label55.TabIndex = 180;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.MediumBlue;
            this.label22.Location = new System.Drawing.Point(2, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(776, 3);
            this.label22.TabIndex = 179;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(664, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 178;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(775, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 621);
            this.label2.TabIndex = 181;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(2, 625);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(776, 3);
            this.label5.TabIndex = 183;
            // 
            // btnVerCliente
            // 
            this.btnVerCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnVerCliente.Image")));
            this.btnVerCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerCliente.Location = new System.Drawing.Point(664, 89);
            this.btnVerCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerCliente.Name = "btnVerCliente";
            this.btnVerCliente.Size = new System.Drawing.Size(107, 42);
            this.btnVerCliente.TabIndex = 187;
            this.btnVerCliente.Text = "Ver\r\nCliente";
            this.btnVerCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerCliente.UseVisualStyleBackColor = true;
            this.btnVerCliente.Click += new System.EventHandler(this.btnVerCliente_Click);
            // 
            // EDIT
            // 
            this.EDIT.HeaderText = "Edit";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "Edit";
            this.EDIT.ToolTipText = "Editar una Orden de Venta";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 50;
            // 
            // VIEW
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VIEW.DefaultCellStyle = dataGridViewCellStyle1;
            this.VIEW.HeaderText = "View";
            this.VIEW.Name = "VIEW";
            this.VIEW.ReadOnly = true;
            this.VIEW.Text = "View";
            this.VIEW.ToolTipText = "Visualizar una Orden de Venta";
            this.VIEW.UseColumnTextForButtonValue = true;
            this.VIEW.Width = 50;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "Status Entrega";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusSalesOrderDataGridViewTextBoxColumn
            // 
            this.statusSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "StatusSalesOrder";
            this.statusSalesOrderDataGridViewTextBoxColumn.HeaderText = "Status SO";
            this.statusSalesOrderDataGridViewTextBoxColumn.Name = "statusSalesOrderDataGridViewTextBoxColumn";
            this.statusSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            this.fechaCompromisoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCompromisoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaSalesOrderDataGridViewTextBoxColumn
            // 
            this.fechaSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "FechaSalesOrder";
            this.fechaSalesOrderDataGridViewTextBoxColumn.HeaderText = "Fecha SO";
            this.fechaSalesOrderDataGridViewTextBoxColumn.Name = "fechaSalesOrderDataGridViewTextBoxColumn";
            this.fechaSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteDescripcionT7DataGridViewTextBoxColumn
            // 
            this.clienteDescripcionT7DataGridViewTextBoxColumn.DataPropertyName = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.HeaderText = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Name = "clienteDescripcionT7DataGridViewTextBoxColumn";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // clienteFantasiaDataGridViewTextBoxColumn
            // 
            this.clienteFantasiaDataGridViewTextBoxColumn.DataPropertyName = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.HeaderText = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.Name = "clienteFantasiaDataGridViewTextBoxColumn";
            this.clienteFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteFantasiaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idC6DataGridViewTextBoxColumn
            // 
            this.idC6DataGridViewTextBoxColumn.DataPropertyName = "IdC6";
            this.idC6DataGridViewTextBoxColumn.HeaderText = "IdC6";
            this.idC6DataGridViewTextBoxColumn.Name = "idC6DataGridViewTextBoxColumn";
            this.idC6DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC6DataGridViewTextBoxColumn.Visible = false;
            // 
            // idC7DataGridViewTextBoxColumn
            // 
            this.idC7DataGridViewTextBoxColumn.DataPropertyName = "IdC7";
            this.idC7DataGridViewTextBoxColumn.HeaderText = "IdC7";
            this.idC7DataGridViewTextBoxColumn.Name = "idC7DataGridViewTextBoxColumn";
            this.idC7DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC7DataGridViewTextBoxColumn.Visible = false;
            // 
            // sODataGridViewTextBoxColumn
            // 
            this.sODataGridViewTextBoxColumn.DataPropertyName = "SO";
            this.sODataGridViewTextBoxColumn.HeaderText = "SO#";
            this.sODataGridViewTextBoxColumn.Name = "sODataGridViewTextBoxColumn";
            this.sODataGridViewTextBoxColumn.ReadOnly = true;
            this.sODataGridViewTextBoxColumn.Width = 50;
            // 
            // dgvListadoSO
            // 
            this.dgvListadoSO.AllowUserToAddRows = false;
            this.dgvListadoSO.AllowUserToDeleteRows = false;
            this.dgvListadoSO.AutoGenerateColumns = false;
            this.dgvListadoSO.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoSO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sODataGridViewTextBoxColumn,
            this.idC7DataGridViewTextBoxColumn,
            this.idC6DataGridViewTextBoxColumn,
            this.clienteFantasiaDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.clienteDescripcionT7DataGridViewTextBoxColumn,
            this.fechaSalesOrderDataGridViewTextBoxColumn,
            this.fechaCompromisoDataGridViewTextBoxColumn,
            this.statusSalesOrderDataGridViewTextBoxColumn,
            this.statusEntregaDataGridViewTextBoxColumn,
            this.VIEW,
            this.EDIT});
            this.dgvListadoSO.DataSource = this.SalesOrderBs;
            this.dgvListadoSO.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvListadoSO.Location = new System.Drawing.Point(8, 139);
            this.dgvListadoSO.Name = "dgvListadoSO";
            this.dgvListadoSO.ReadOnly = true;
            this.dgvListadoSO.RowHeadersWidth = 20;
            this.dgvListadoSO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoSO.Size = new System.Drawing.Size(644, 480);
            this.dgvListadoSO.TabIndex = 88;
            this.dgvListadoSO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoSO_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtNumeroOv);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmax);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 35);
            this.panel1.TabIndex = 189;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero OV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(536, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max #";
            // 
            // cmax
            // 
            this.cmax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmax.BackColor = System.Drawing.Color.White;
            this.cmax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmax.Location = new System.Drawing.Point(582, 7);
            this.cmax.Margin = new System.Windows.Forms.Padding(0);
            this.cmax.Name = "cmax";
            this.cmax.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cmax.SetDecimales = 0;
            this.cmax.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.cmax.Size = new System.Drawing.Size(49, 23);
            this.cmax.TabIndex = 2;
            this.cmax.ValorMaximo = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.cmax.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmax.XReadOnly = false;
            this.cmax.Validated += new System.EventHandler(this.cmax_Validated);
            // 
            // txtNumeroOv
            // 
            this.txtNumeroOv.Location = new System.Drawing.Point(99, 5);
            this.txtNumeroOv.Name = "txtNumeroOv";
            this.txtNumeroOv.Size = new System.Drawing.Size(61, 23);
            this.txtNumeroOv.TabIndex = 4;
            this.txtNumeroOv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroOv_KeyPress);
            this.txtNumeroOv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroOv_KeyUp);
            // 
            // CustomerFilter
            // 
            this.CustomerFilter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CustomerFilter.ClienteId = null;
            this.CustomerFilter.ColorContorno = System.Drawing.Color.Navy;
            this.CustomerFilter.FondoControl = System.Drawing.Color.White;
            this.CustomerFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerFilter.Location = new System.Drawing.Point(8, 8);
            this.CustomerFilter.Name = "CustomerFilter";
            this.CustomerFilter.Size = new System.Drawing.Size(644, 91);
            this.CustomerFilter.TabIndex = 188;
            this.CustomerFilter.ClienteModificado += new MASngFE._0TSUserControls.TsUcCustomer3.ClienteModificadoEventHandler(this.CustomerFilter_ClienteModificado);
            // 
            // FrmSD01SalesOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 630);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CustomerFilter);
            this.Controls.Add(this.btnVerCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNuevaSO);
            this.Controls.Add(this.dgvListadoSO);
            this.Name = "FrmSD01SalesOrderSearch";
            this.Text = "SD01 - Sales Order Search";
            this.Load += new System.EventHandler(this.FrmSalesOrderSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource SalesOrderBs;
        private System.Windows.Forms.Button btnNuevaSO;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerCliente;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn VIEW;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDescripcionT7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteFantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvListadoSO;
        private _0TSUserControls.TsUcCustomer3 CustomerFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private TSControls.CtlTextBox cmax;
        private System.Windows.Forms.TextBox txtNumeroOv;
    }
}