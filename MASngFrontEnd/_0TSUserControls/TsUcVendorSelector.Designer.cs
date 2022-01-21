namespace MASngFE._0TSUserControls
{
    partial class TsUcVendorSelector
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
            this.ctlVendorOk = new TSControls.CtlIconos();
            this.ckBusquedaLibre = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.VendorBs = new System.Windows.Forms.BindingSource(this.components);
            this.lineD = new System.Windows.Forms.Label();
            this.lineI = new System.Windows.Forms.Label();
            this.lineUp = new System.Windows.Forms.Label();
            this.txtChar = new TSControls.CtlTextBox();
            this.lineDown = new System.Windows.Forms.Label();
            this.ckSoloClientesActivos = new System.Windows.Forms.CheckBox();
            this.txtVendorId = new TSControls.CtlTextBox();
            this.txtCuit = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVendorType = new System.Windows.Forms.TextBox();
            this.btnFree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VendorBs)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlVendorOk
            // 
            this.ctlVendorOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlVendorOk.IconLocation = TSControls.UbicacionIcono.Normal;
            this.ctlVendorOk.IconSize = TSControls.TamañoIcono.Chico;
            this.ctlVendorOk.Location = new System.Drawing.Point(511, 10);
            this.ctlVendorOk.Name = "ctlVendorOk";
            this.ctlVendorOk.Set = TSControls.CIconos.ExclamacionYellow;
            this.ctlVendorOk.Size = new System.Drawing.Size(17, 18);
            this.ctlVendorOk.TabIndex = 144;
            // 
            // ckBusquedaLibre
            // 
            this.ckBusquedaLibre.AutoSize = true;
            this.ckBusquedaLibre.ForeColor = System.Drawing.Color.Navy;
            this.ckBusquedaLibre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckBusquedaLibre.Location = new System.Drawing.Point(397, 59);
            this.ckBusquedaLibre.Name = "ckBusquedaLibre";
            this.ckBusquedaLibre.Size = new System.Drawing.Size(107, 19);
            this.ckBusquedaLibre.TabIndex = 134;
            this.ckBusquedaLibre.Text = "Busqueda Libre";
            this.ckBusquedaLibre.UseVisualStyleBackColor = true;
            this.ckBusquedaLibre.CheckedChanged += new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 140;
            this.label4.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.VendorBs;
            this.cmbRazonSocial.DisplayMember = "RazonSocial";
            this.cmbRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(85, 7);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(306, 23);
            this.cmbRazonSocial.TabIndex = 129;
            this.cmbRazonSocial.ValueMember = "VendorId";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbFantasia_TextUpdate);
            // 
            // VendorBs
            // 
            this.VendorBs.DataSource = typeof(Tecser.Business.MasterData.Vendor_Master.StxVendnorSimple);
            // 
            // lineD
            // 
            this.lineD.BackColor = System.Drawing.Color.Navy;
            this.lineD.Location = new System.Drawing.Point(575, 0);
            this.lineD.Name = "lineD";
            this.lineD.Size = new System.Drawing.Size(2, 91);
            this.lineD.TabIndex = 138;
            // 
            // lineI
            // 
            this.lineI.BackColor = System.Drawing.Color.Navy;
            this.lineI.Location = new System.Drawing.Point(0, 0);
            this.lineI.Name = "lineI";
            this.lineI.Size = new System.Drawing.Size(2, 91);
            this.lineI.TabIndex = 137;
            // 
            // lineUp
            // 
            this.lineUp.BackColor = System.Drawing.Color.Navy;
            this.lineUp.Location = new System.Drawing.Point(0, 0);
            this.lineUp.Name = "lineUp";
            this.lineUp.Size = new System.Drawing.Size(577, 2);
            this.lineUp.TabIndex = 136;
            // 
            // txtChar
            // 
            this.txtChar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtChar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChar.Location = new System.Drawing.Point(505, 55);
            this.txtChar.Margin = new System.Windows.Forms.Padding(0);
            this.txtChar.Name = "txtChar";
            this.txtChar.SeparadorDecimal = true;
            this.txtChar.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtChar.SetDecimales = 0;
            this.txtChar.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtChar.Size = new System.Drawing.Size(29, 23);
            this.txtChar.TabIndex = 135;
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
            // 
            // lineDown
            // 
            this.lineDown.BackColor = System.Drawing.Color.Navy;
            this.lineDown.Location = new System.Drawing.Point(0, 89);
            this.lineDown.Name = "lineDown";
            this.lineDown.Size = new System.Drawing.Size(577, 2);
            this.lineDown.TabIndex = 143;
            // 
            // ckSoloClientesActivos
            // 
            this.ckSoloClientesActivos.AutoSize = true;
            this.ckSoloClientesActivos.ForeColor = System.Drawing.Color.Navy;
            this.ckSoloClientesActivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckSoloClientesActivos.Location = new System.Drawing.Point(397, 34);
            this.ckSoloClientesActivos.Name = "ckSoloClientesActivos";
            this.ckSoloClientesActivos.Size = new System.Drawing.Size(91, 19);
            this.ckSoloClientesActivos.TabIndex = 133;
            this.ckSoloClientesActivos.Text = "Sólo Activos";
            this.ckSoloClientesActivos.UseVisualStyleBackColor = true;
            this.ckSoloClientesActivos.CheckedChanged += new System.EventHandler(this.ckSoloClientesActivos_CheckedChanged);
            // 
            // txtVendorId
            // 
            this.txtVendorId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtVendorId.BackColor = System.Drawing.Color.White;
            this.txtVendorId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorId.Location = new System.Drawing.Point(429, 7);
            this.txtVendorId.Margin = new System.Windows.Forms.Padding(0);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.SeparadorDecimal = false;
            this.txtVendorId.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtVendorId.SetDecimales = 0;
            this.txtVendorId.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtVendorId.Size = new System.Drawing.Size(59, 23);
            this.txtVendorId.TabIndex = 131;
            this.txtVendorId.ValorMaximo = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtVendorId.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVendorId.XReadOnly = false;
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuit.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtCuit.Location = new System.Drawing.Point(282, 57);
            this.txtCuit.Mask = "00-00000000-0";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(109, 23);
            this.txtCuit.TabIndex = 132;
            this.txtCuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(236, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 142;
            this.label6.Text = "CUIT #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(399, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 141;
            this.label5.Text = "ID#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 139;
            this.label3.Text = "Fantasia";
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.VendorBs;
            this.cmbFantasia.DisplayMember = "Fantasia";
            this.cmbFantasia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(85, 32);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(306, 23);
            this.cmbFantasia.TabIndex = 130;
            this.cmbFantasia.ValueMember = "VendorId";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbFantasia_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 146;
            this.label1.Text = "Tipo";
            // 
            // txtVendorType
            // 
            this.txtVendorType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtVendorType.Location = new System.Drawing.Point(85, 57);
            this.txtVendorType.Name = "txtVendorType";
            this.txtVendorType.ReadOnly = true;
            this.txtVendorType.Size = new System.Drawing.Size(120, 23);
            this.txtVendorType.TabIndex = 147;
            // 
            // btnFree
            // 
            this.btnFree.BackColor = System.Drawing.Color.Transparent;
            this.btnFree.BackgroundImage = global::MASngFE.Properties.Resources.delete_remove_13995;
            this.btnFree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFree.Location = new System.Drawing.Point(536, 51);
            this.btnFree.Name = "btnFree";
            this.btnFree.Size = new System.Drawing.Size(32, 31);
            this.btnFree.TabIndex = 148;
            this.btnFree.UseVisualStyleBackColor = false;
            this.btnFree.Click += new System.EventHandler(this.btnFree_Click);
            // 
            // TsUcVendorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnFree);
            this.Controls.Add(this.txtVendorType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlVendorOk);
            this.Controls.Add(this.ckBusquedaLibre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRazonSocial);
            this.Controls.Add(this.lineD);
            this.Controls.Add(this.lineI);
            this.Controls.Add(this.lineUp);
            this.Controls.Add(this.txtChar);
            this.Controls.Add(this.lineDown);
            this.Controls.Add(this.ckSoloClientesActivos);
            this.Controls.Add(this.txtVendorId);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFantasia);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TsUcVendorSelector";
            this.Size = new System.Drawing.Size(577, 91);
            this.Load += new System.EventHandler(this.TsUcVendorSelector_Load);
            this.Resize += new System.EventHandler(this.TsUcVendorSelector_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.VendorBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TSControls.CtlIconos ctlVendorOk;
        private System.Windows.Forms.CheckBox ckBusquedaLibre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.BindingSource VendorBs;
        private System.Windows.Forms.Label lineD;
        private System.Windows.Forms.Label lineI;
        private System.Windows.Forms.Label lineUp;
        private TSControls.CtlTextBox txtChar;
        private System.Windows.Forms.Label lineDown;
        private System.Windows.Forms.CheckBox ckSoloClientesActivos;
        private TSControls.CtlTextBox txtVendorId;
        private System.Windows.Forms.MaskedTextBox txtCuit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVendorType;
        private System.Windows.Forms.Button btnFree;
    }
}
