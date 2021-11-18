namespace MASngFE._0TSUserControls
{
    partial class TsUcCustomer3
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.ckSoloClientesActivos = new System.Windows.Forms.CheckBox();
            this.txtClienteId = new TSControls.CtlTextBox();
            this.txtCuit = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerBs = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBs)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(1, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(601, 2);
            this.label7.TabIndex = 124;
            // 
            // ckSoloClientesActivos
            // 
            this.ckSoloClientesActivos.AutoSize = true;
            this.ckSoloClientesActivos.Location = new System.Drawing.Point(236, 61);
            this.ckSoloClientesActivos.Name = "ckSoloClientesActivos";
            this.ckSoloClientesActivos.Size = new System.Drawing.Size(188, 19);
            this.ckSoloClientesActivos.TabIndex = 123;
            this.ckSoloClientesActivos.Text = "Visualizar Sólo Clientes Activos";
            this.ckSoloClientesActivos.UseVisualStyleBackColor = true;
            // 
            // txtClienteId
            // 
            this.txtClienteId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtClienteId.BackColor = System.Drawing.Color.White;
            this.txtClienteId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteId.Location = new System.Drawing.Point(540, 8);
            this.txtClienteId.Margin = new System.Windows.Forms.Padding(0);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtClienteId.SetDecimales = 0;
            this.txtClienteId.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtClienteId.Size = new System.Drawing.Size(55, 23);
            this.txtClienteId.TabIndex = 122;
            this.txtClienteId.ValorMaximo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtClienteId.ValorMinimo = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtClienteId.XReadOnly = false;
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCuit.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.txtCuit.Location = new System.Drawing.Point(101, 58);
            this.txtCuit.Mask = "00-00000000-0";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(126, 23);
            this.txtCuit.TabIndex = 121;
            this.txtCuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 120;
            this.label6.Text = "CUIT #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(506, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 119;
            this.label5.Text = "ID#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 116;
            this.label3.Text = "Fantasia";
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.CustomerBs;
            this.cmbFantasia.DisplayMember = "Fantasia";
            this.cmbFantasia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(101, 8);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(396, 23);
            this.cmbFantasia.TabIndex = 115;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 118;
            this.label4.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.CustomerBs;
            this.cmbRazonSocial.DisplayMember = "RazonSocial";
            this.cmbRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(101, 33);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(396, 23);
            this.cmbRazonSocial.TabIndex = 117;
            this.cmbRazonSocial.ValueMember = "IdCliente";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(600, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 93);
            this.label1.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 95);
            this.label2.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(601, 2);
            this.label8.TabIndex = 112;
            // 
            // CustomerBs
            // 
            this.CustomerBs.DataSource = typeof(Tecser.Business.MasterData.Customer.StxCustomerSimple);
            // 
            // TsUcCustomer3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckSoloClientesActivos);
            this.Controls.Add(this.txtClienteId);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFantasia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRazonSocial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TsUcCustomer3";
            this.Size = new System.Drawing.Size(604, 99);
            this.Load += new System.EventHandler(this.TsUcCustomer3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckSoloClientesActivos;
        private TSControls.CtlTextBox txtClienteId;
        private System.Windows.Forms.MaskedTextBox txtCuit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        private System.Windows.Forms.BindingSource CustomerBs;
    }
}
