namespace MASngFE._0TSUserControls
{
    sealed partial class TsUcCustomer3
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
            this.lineDown = new System.Windows.Forms.Label();
            this.ckSoloClientesActivos = new System.Windows.Forms.CheckBox();
            this.txtClienteId = new TSControls.CtlTextBox();
            this.txtCuit = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.CustomerBs = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.lineD = new System.Windows.Forms.Label();
            this.lineI = new System.Windows.Forms.Label();
            this.lineUp = new System.Windows.Forms.Label();
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.ckBusquedaLibre = new System.Windows.Forms.CheckBox();
            this.txtChar = new TSControls.CtlTextBox();
            this.ctlCustomerOk = new TSControls.CtlIconos();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            this.SuspendLayout();
            // 
            // lineDown
            // 
            this.lineDown.BackColor = System.Drawing.Color.Navy;
            this.lineDown.Location = new System.Drawing.Point(0, 89);
            this.lineDown.Name = "lineDown";
            this.lineDown.Size = new System.Drawing.Size(577, 2);
            this.lineDown.TabIndex = 124;
            // 
            // ckSoloClientesActivos
            // 
            this.ckSoloClientesActivos.AutoSize = true;
            this.ckSoloClientesActivos.ForeColor = System.Drawing.Color.Navy;
            this.ckSoloClientesActivos.Location = new System.Drawing.Point(220, 60);
            this.ckSoloClientesActivos.Name = "ckSoloClientesActivos";
            this.ckSoloClientesActivos.Size = new System.Drawing.Size(91, 19);
            this.ckSoloClientesActivos.TabIndex = 4;
            this.ckSoloClientesActivos.Text = "Sólo Activos";
            this.ckSoloClientesActivos.UseVisualStyleBackColor = true;
            this.ckSoloClientesActivos.CheckedChanged += new System.EventHandler(this.ckSoloClientesActivos_CheckedChanged);
            // 
            // txtClienteId
            // 
            this.txtClienteId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtClienteId.BackColor = System.Drawing.Color.White;
            this.txtClienteId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteId.Location = new System.Drawing.Point(503, 7);
            this.txtClienteId.Margin = new System.Windows.Forms.Padding(0);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtClienteId.SetDecimales = 0;
            this.txtClienteId.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtClienteId.Size = new System.Drawing.Size(44, 23);
            this.txtClienteId.TabIndex = 2;
            this.txtClienteId.ValorMaximo = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtClienteId.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtClienteId.XReadOnly = false;
            this.txtClienteId.KeyUP += new TSControls.CtlTextBox.tsKeyUp(this.txtClienteId_KeyUP_1);
            this.txtClienteId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtClienteId_KeyUp);
            this.txtClienteId.Validated += new System.EventHandler(this.txtClienteId_Validated);
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCuit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuit.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtCuit.Location = new System.Drawing.Point(99, 57);
            this.txtCuit.Mask = "00-00000000-0";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(110, 25);
            this.txtCuit.TabIndex = 3;
            this.txtCuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 120;
            this.label6.Text = "CUIT #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(477, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 119;
            this.label5.Text = "ID#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 36);
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
            this.cmbFantasia.Location = new System.Drawing.Point(99, 32);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(375, 23);
            this.cmbFantasia.TabIndex = 1;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbFantasia_TextUpdate);
            // 
            // CustomerBs
            // 
            this.CustomerBs.DataSource = typeof(Tecser.Business.MasterData.Customer.StxCustomerSimple);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 11);
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
            this.cmbRazonSocial.Location = new System.Drawing.Point(99, 7);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(375, 23);
            this.cmbRazonSocial.TabIndex = 0;
            this.cmbRazonSocial.ValueMember = "IdCliente";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbFantasia_TextUpdate);
            // 
            // lineD
            // 
            this.lineD.BackColor = System.Drawing.Color.Navy;
            this.lineD.Location = new System.Drawing.Point(575, 0);
            this.lineD.Name = "lineD";
            this.lineD.Size = new System.Drawing.Size(2, 91);
            this.lineD.TabIndex = 114;
            // 
            // lineI
            // 
            this.lineI.BackColor = System.Drawing.Color.Navy;
            this.lineI.Location = new System.Drawing.Point(0, 0);
            this.lineI.Name = "lineI";
            this.lineI.Size = new System.Drawing.Size(2, 91);
            this.lineI.TabIndex = 113;
            // 
            // lineUp
            // 
            this.lineUp.BackColor = System.Drawing.Color.Navy;
            this.lineUp.Location = new System.Drawing.Point(0, 0);
            this.lineUp.Name = "lineUp";
            this.lineUp.Size = new System.Drawing.Size(577, 2);
            this.lineUp.TabIndex = 112;
            // 
            // ckBusquedaLibre
            // 
            this.ckBusquedaLibre.AutoSize = true;
            this.ckBusquedaLibre.ForeColor = System.Drawing.Color.Navy;
            this.ckBusquedaLibre.Location = new System.Drawing.Point(335, 60);
            this.ckBusquedaLibre.Name = "ckBusquedaLibre";
            this.ckBusquedaLibre.Size = new System.Drawing.Size(107, 19);
            this.ckBusquedaLibre.TabIndex = 5;
            this.ckBusquedaLibre.Text = "Busqueda Libre";
            this.ckBusquedaLibre.UseVisualStyleBackColor = true;
            this.ckBusquedaLibre.CheckedChanged += new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
            // 
            // txtChar
            // 
            this.txtChar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtChar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChar.Location = new System.Drawing.Point(443, 57);
            this.txtChar.Margin = new System.Windows.Forms.Padding(0);
            this.txtChar.Name = "txtChar";
            this.txtChar.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtChar.SetDecimales = 0;
            this.txtChar.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtChar.Size = new System.Drawing.Size(31, 23);
            this.txtChar.TabIndex = 6;
            this.txtChar.ValorMaximo = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtChar.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtChar.XReadOnly = false;
            this.txtChar.Validated += new System.EventHandler(this.txtChar_Validated);
            // 
            // ctlCustomerOk
            // 
            this.ctlCustomerOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCustomerOk.IconLocation = TSControls.UbicacionIcono.Normal;
            this.ctlCustomerOk.IconSize = TSControls.TamañoIcono.Chico;
            this.ctlCustomerOk.Location = new System.Drawing.Point(554, 10);
            this.ctlCustomerOk.Name = "ctlCustomerOk";
            this.ctlCustomerOk.Set = TSControls.CIconos.ExclamacionYellow;
            this.ctlCustomerOk.Size = new System.Drawing.Size(17, 18);
            this.ctlCustomerOk.TabIndex = 128;
            // 
            // TsUcCustomer3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctlCustomerOk);
            this.Controls.Add(this.txtChar);
            this.Controls.Add(this.ckBusquedaLibre);
            this.Controls.Add(this.lineDown);
            this.Controls.Add(this.ckSoloClientesActivos);
            this.Controls.Add(this.txtClienteId);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFantasia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRazonSocial);
            this.Controls.Add(this.lineD);
            this.Controls.Add(this.lineI);
            this.Controls.Add(this.lineUp);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TsUcCustomer3";
            this.Size = new System.Drawing.Size(577, 91);
            this.Load += new System.EventHandler(this.TsUcCustomer3_Load);
            this.Resize += new System.EventHandler(this.TsUcCustomer3_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineDown;
        private System.Windows.Forms.CheckBox ckSoloClientesActivos;
        private TSControls.CtlTextBox txtClienteId;
        private System.Windows.Forms.MaskedTextBox txtCuit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Label lineD;
        private System.Windows.Forms.Label lineI;
        private System.Windows.Forms.Label lineUp;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        private System.Windows.Forms.BindingSource CustomerBs;
        private System.Windows.Forms.CheckBox ckBusquedaLibre;
        private TSControls.CtlTextBox txtChar;
        private TSControls.CtlIconos ctlCustomerOk;
    }
}
