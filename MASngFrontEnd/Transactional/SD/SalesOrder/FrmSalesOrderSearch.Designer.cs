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
            this.btnViewAll = new System.Windows.Forms.Button();
            this.dgvListadoSO = new System.Windows.Forms.DataGridView();
            this.sODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteFantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDescripcionT7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SalesOrderBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevaSO = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tsUcCustomerSearch11 = new MASngFE._0TSUserControls.TsUcCustomerSearch1();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAll.Image")));
            this.btnViewAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAll.Location = new System.Drawing.Point(545, 7);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(98, 42);
            this.btnViewAll.TabIndex = 89;
            this.btnViewAll.Text = "Ver\r\nTodas SO";
            this.btnViewAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
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
            this.dgvListadoSO.Location = new System.Drawing.Point(8, 101);
            this.dgvListadoSO.Name = "dgvListadoSO";
            this.dgvListadoSO.ReadOnly = true;
            this.dgvListadoSO.RowHeadersWidth = 20;
            this.dgvListadoSO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoSO.Size = new System.Drawing.Size(644, 513);
            this.dgvListadoSO.TabIndex = 88;
            this.dgvListadoSO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoSO_CellContentClick);
            // 
            // sODataGridViewTextBoxColumn
            // 
            this.sODataGridViewTextBoxColumn.DataPropertyName = "SO";
            this.sODataGridViewTextBoxColumn.HeaderText = "SO#";
            this.sODataGridViewTextBoxColumn.Name = "sODataGridViewTextBoxColumn";
            this.sODataGridViewTextBoxColumn.ReadOnly = true;
            this.sODataGridViewTextBoxColumn.Width = 50;
            // 
            // idC7DataGridViewTextBoxColumn
            // 
            this.idC7DataGridViewTextBoxColumn.DataPropertyName = "IdC7";
            this.idC7DataGridViewTextBoxColumn.HeaderText = "IdC7";
            this.idC7DataGridViewTextBoxColumn.Name = "idC7DataGridViewTextBoxColumn";
            this.idC7DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC7DataGridViewTextBoxColumn.Visible = false;
            // 
            // idC6DataGridViewTextBoxColumn
            // 
            this.idC6DataGridViewTextBoxColumn.DataPropertyName = "IdC6";
            this.idC6DataGridViewTextBoxColumn.HeaderText = "IdC6";
            this.idC6DataGridViewTextBoxColumn.Name = "idC6DataGridViewTextBoxColumn";
            this.idC6DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC6DataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteFantasiaDataGridViewTextBoxColumn
            // 
            this.clienteFantasiaDataGridViewTextBoxColumn.DataPropertyName = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.HeaderText = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.Name = "clienteFantasiaDataGridViewTextBoxColumn";
            this.clienteFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteFantasiaDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // clienteDescripcionT7DataGridViewTextBoxColumn
            // 
            this.clienteDescripcionT7DataGridViewTextBoxColumn.DataPropertyName = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.HeaderText = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Name = "clienteDescripcionT7DataGridViewTextBoxColumn";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaSalesOrderDataGridViewTextBoxColumn
            // 
            this.fechaSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "FechaSalesOrder";
            this.fechaSalesOrderDataGridViewTextBoxColumn.HeaderText = "Fecha SO";
            this.fechaSalesOrderDataGridViewTextBoxColumn.Name = "fechaSalesOrderDataGridViewTextBoxColumn";
            this.fechaSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            this.fechaCompromisoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCompromisoDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusSalesOrderDataGridViewTextBoxColumn
            // 
            this.statusSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "StatusSalesOrder";
            this.statusSalesOrderDataGridViewTextBoxColumn.HeaderText = "Status SO";
            this.statusSalesOrderDataGridViewTextBoxColumn.Name = "statusSalesOrderDataGridViewTextBoxColumn";
            this.statusSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "Status Entrega";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
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
            // SalesOrderBs
            // 
            this.SalesOrderBs.DataSource = typeof(TecserEF.Entity.DataStructure.DsSalesOrderList);
            // 
            // btnNuevaSO
            // 
            this.btnNuevaSO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaSO.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaSO.Image")));
            this.btnNuevaSO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaSO.Location = new System.Drawing.Point(664, 49);
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
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(8, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(644, 2);
            this.label6.TabIndex = 184;
            // 
            // tsUcCustomerSearch11
            // 
            this.tsUcCustomerSearch11.ClienteId = null;
            this.tsUcCustomerSearch11.Location = new System.Drawing.Point(8, 8);
            this.tsUcCustomerSearch11.Name = "tsUcCustomerSearch11";
            this.tsUcCustomerSearch11.Size = new System.Drawing.Size(537, 89);
            this.tsUcCustomerSearch11.TabIndex = 185;
            this.tsUcCustomerSearch11.ClienteModificado += new MASngFE._0TSUserControls.TsUcCustomerSearch1.ClienteModificadoEventHandler(this.tsUcCustomerSearch11_ClienteModificado);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(658, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 620);
            this.label1.TabIndex = 186;
            // 
            // btnVerCliente
            // 
            this.btnVerCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnVerCliente.Image")));
            this.btnVerCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerCliente.Location = new System.Drawing.Point(545, 50);
            this.btnVerCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerCliente.Name = "btnVerCliente";
            this.btnVerCliente.Size = new System.Drawing.Size(98, 42);
            this.btnVerCliente.TabIndex = 187;
            this.btnVerCliente.Text = "Ver\r\nCliente";
            this.btnVerCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerCliente.UseVisualStyleBackColor = true;
            this.btnVerCliente.Click += new System.EventHandler(this.btnVerCliente_Click);
            // 
            // FrmSD01SalesOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 630);
            this.Controls.Add(this.btnVerCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsUcCustomerSearch11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNuevaSO);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.dgvListadoSO);
            this.Name = "FrmSD01SalesOrderSearch";
            this.Text = "SD01 - Sales Order Search";
            this.Load += new System.EventHandler(this.FrmSalesOrderSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvListadoSO;
        private System.Windows.Forms.BindingSource SalesOrderBs;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn sODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteFantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDescripcionT7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VIEW;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.Button btnNuevaSO;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private _0TSUserControls.TsUcCustomerSearch1 tsUcCustomerSearch11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerCliente;
    }
}