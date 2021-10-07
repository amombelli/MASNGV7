namespace MASngFE.Forms
{
    partial class FrmTestUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestUserControl));
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this._idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uck01 = new MASngFE._UserControls.UCheckbox1();
            this.uCustomerSearch1 = new MASngFE._UserControls.UCustomerSearch();
            this.uck11 = new MASngFE._UserControls.UCheckbox1();
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
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._idCliente,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1,
            this.Accion});
            this.dgvClientes.DataSource = this.T0006DgvBs;
            this.dgvClientes.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dgvClientes.Location = new System.Drawing.Point(1, 135);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 20;
            this.dgvClientes.Size = new System.Drawing.Size(579, 338);
            this.dgvClientes.TabIndex = 98;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // _idCliente
            // 
            this._idCliente.DataPropertyName = "IDCLIENTE";
            this._idCliente.HeaderText = "Id6";
            this._idCliente.Name = "_idCliente";
            this._idCliente.ReadOnly = true;
            this._idCliente.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cli_rsocial";
            this.dataGridViewTextBoxColumn2.HeaderText = "Razon Social";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cli_fantasia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Fantasia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 160;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "ACTIVO";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Activo";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 60;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Text = "GO";
            this.Accion.ToolTipText = "Ejecutar la Accion";
            this.Accion.UseColumnTextForButtonValue = true;
            this.Accion.Width = 60;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(586, 7);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 41);
            this.btnSalir.TabIndex = 99;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 524);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 101;
            // 
            // uck01
            // 
            this.uck01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uck01.Location = new System.Drawing.Point(53, 524);
            this.uck01.Name = "uck01";
            this.uck01.Size = new System.Drawing.Size(146, 19);
            this.uck01.TabIndex = 100;
            this.uck01.CheckBoxClick += new System.EventHandler(this.UserControl_ButtonClick);
            // 
            // uCustomerSearch1
            // 
            this.uCustomerSearch1.Location = new System.Drawing.Point(2, 5);
            this.uCustomerSearch1.Name = "uCustomerSearch1";
            this.uCustomerSearch1.Size = new System.Drawing.Size(579, 124);
            this.uCustomerSearch1.TabIndex = 0;
            // 
            // uck11
            // 
            this.uck11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uck11.Location = new System.Drawing.Point(53, 570);
            this.uck11.Name = "uck11";
            this.uck11.Size = new System.Drawing.Size(146, 19);
            this.uck11.TabIndex = 102;
            this.uck11.CheckBoxClick += new System.EventHandler(this.uck11_CheckBoxClick);
            // 
            // FrmTestUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 651);
            this.Controls.Add(this.uck11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uck01);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.uCustomerSearch1);
            this.Name = "FrmTestUserControl";
            this.Text = "frmTestUserControl";
            this.Load += new System.EventHandler(this.frmTestUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _UserControls.UCustomerSearch uCustomerSearch1;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        public System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn _idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Button btnSalir;
        private _UserControls.UCheckbox1 uck01;
        private System.Windows.Forms.TextBox textBox1;
        private _UserControls.UCheckbox1 uck11;
    }
}