namespace MASngFE.MasterData.Customer_Master
{
    partial class FrmMdc01CustomerSearch
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
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clirsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clifantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.uCustomerSearch1 = new MASngFE._UserControls.UCustomerSearch();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // T0006DgvBs
            // 
            this.T0006DgvBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AutoGenerateColumns = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clirsocialDataGridViewTextBoxColumn,
            this.clifantasiaDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewCheckBoxColumn,
            this.@__Accion});
            this.dgvClientes.DataSource = this.T0006DgvBs;
            this.dgvClientes.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvClientes.Location = new System.Drawing.Point(6, 126);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 20;
            this.dgvClientes.Size = new System.Drawing.Size(577, 378);
            this.dgvClientes.TabIndex = 101;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "Id6";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Width = 40;
            // 
            // clirsocialDataGridViewTextBoxColumn
            // 
            this.clirsocialDataGridViewTextBoxColumn.DataPropertyName = "cli_rsocial";
            this.clirsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clirsocialDataGridViewTextBoxColumn.Name = "clirsocialDataGridViewTextBoxColumn";
            this.clirsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clirsocialDataGridViewTextBoxColumn.Width = 250;
            // 
            // clifantasiaDataGridViewTextBoxColumn
            // 
            this.clifantasiaDataGridViewTextBoxColumn.DataPropertyName = "cli_fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.Name = "clifantasiaDataGridViewTextBoxColumn";
            this.clifantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clifantasiaDataGridViewTextBoxColumn.Width = 160;
            // 
            // aCTIVODataGridViewCheckBoxColumn
            // 
            this.aCTIVODataGridViewCheckBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewCheckBoxColumn.Name = "aCTIVODataGridViewCheckBoxColumn";
            this.aCTIVODataGridViewCheckBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewCheckBoxColumn.Width = 40;
            // 
            // __Accion
            // 
            this.@__Accion.HeaderText = "Accion";
            this.@__Accion.Name = "__Accion";
            this.@__Accion.ReadOnly = true;
            this.@__Accion.ToolTipText = "Ejecuta la accion seleccionada";
            this.@__Accion.UseColumnTextForButtonValue = true;
            this.@__Accion.Width = 60;
            // 
            // uCustomerSearch1
            // 
            this.uCustomerSearch1.Location = new System.Drawing.Point(6, 7);
            this.uCustomerSearch1.Name = "uCustomerSearch1";
            this.uCustomerSearch1.Size = new System.Drawing.Size(577, 119);
            this.uCustomerSearch1.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(2, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 507);
            this.label17.TabIndex = 187;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(689, 3);
            this.label18.TabIndex = 186;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(584, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 42);
            this.btnClose.TabIndex = 188;
            this.btnClose.Text = "Cancelar\r\nSeleccion";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(688, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 507);
            this.label1.TabIndex = 189;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(2, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(689, 3);
            this.label2.TabIndex = 190;
            // 
            // FrmMdc01CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 511);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.uCustomerSearch1);
            this.Name = "FrmMdc01CustomerSearch";
            this.Text = "MDC01 Busqueda de Cliente > Customer Master Data";
            this.Load += new System.EventHandler(this.FrmMDC01CustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _UserControls.UCustomerSearch uCustomerSearch1;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        public System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clirsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clifantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn __Accion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}