namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmFI65GastosFinancieros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI65GastosFinancieros));
            this.btnClose = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.panelAClientes = new System.Windows.Forms.Panel();
            this.ckCalcularIva = new System.Windows.Forms.CheckBox();
            this.txtGlIva = new System.Windows.Forms.TextBox();
            this.txtGlFinanciero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cAClienteGastoFinanciero = new TSControls.CtlTextBox();
            this.txtAClientesMotivo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cAClientesImporteTotal = new TSControls.CtlTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cAClientesIva = new TSControls.CtlTextBox();
            this.cCantidad = new TSControls.CtlTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.panelAClientes.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(702, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 48);
            this.btnClose.TabIndex = 188;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Crimson;
            this.label16.Location = new System.Drawing.Point(825, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(3, 245);
            this.label16.TabIndex = 187;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 245);
            this.label17.TabIndex = 186;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(825, 3);
            this.label18.TabIndex = 185;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(3, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(825, 3);
            this.label1.TabIndex = 189;
            // 
            // btnRechazar
            // 
            this.btnRechazar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.Image = ((System.Drawing.Image)(resources.GetObject("btnRechazar.Image")));
            this.btnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRechazar.Location = new System.Drawing.Point(702, 57);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(120, 48);
            this.btnRechazar.TabIndex = 196;
            this.btnRechazar.Text = "Ingresar";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // panelAClientes
            // 
            this.panelAClientes.BackColor = System.Drawing.Color.Honeydew;
            this.panelAClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAClientes.Controls.Add(this.ckCalcularIva);
            this.panelAClientes.Controls.Add(this.txtGlIva);
            this.panelAClientes.Controls.Add(this.txtGlFinanciero);
            this.panelAClientes.Controls.Add(this.label7);
            this.panelAClientes.Controls.Add(this.cAClienteGastoFinanciero);
            this.panelAClientes.Controls.Add(this.txtAClientesMotivo);
            this.panelAClientes.Controls.Add(this.label15);
            this.panelAClientes.Controls.Add(this.label19);
            this.panelAClientes.Controls.Add(this.cAClientesImporteTotal);
            this.panelAClientes.Controls.Add(this.label23);
            this.panelAClientes.Controls.Add(this.label24);
            this.panelAClientes.Controls.Add(this.cAClientesIva);
            this.panelAClientes.Controls.Add(this.cCantidad);
            this.panelAClientes.Location = new System.Drawing.Point(9, 92);
            this.panelAClientes.Name = "panelAClientes";
            this.panelAClientes.Size = new System.Drawing.Size(671, 120);
            this.panelAClientes.TabIndex = 223;
            // 
            // ckCalcularIva
            // 
            this.ckCalcularIva.AutoSize = true;
            this.ckCalcularIva.Location = new System.Drawing.Point(426, 31);
            this.ckCalcularIva.Name = "ckCalcularIva";
            this.ckCalcularIva.Size = new System.Drawing.Size(91, 19);
            this.ckCalcularIva.TabIndex = 226;
            this.ckCalcularIva.Text = "Calcular IVA";
            this.ckCalcularIva.UseVisualStyleBackColor = true;
            this.ckCalcularIva.CheckedChanged += new System.EventHandler(this.ckCalcularIva_CheckedChanged);
            // 
            // txtGlIva
            // 
            this.txtGlIva.Location = new System.Drawing.Point(229, 70);
            this.txtGlIva.Name = "txtGlIva";
            this.txtGlIva.ReadOnly = true;
            this.txtGlIva.Size = new System.Drawing.Size(69, 21);
            this.txtGlIva.TabIndex = 224;
            this.txtGlIva.TabStop = false;
            this.txtGlIva.Text = "2.0.3.1";
            // 
            // txtGlFinanciero
            // 
            this.txtGlFinanciero.Location = new System.Drawing.Point(229, 48);
            this.txtGlFinanciero.Name = "txtGlFinanciero";
            this.txtGlFinanciero.ReadOnly = true;
            this.txtGlFinanciero.Size = new System.Drawing.Size(69, 21);
            this.txtGlFinanciero.TabIndex = 223;
            this.txtGlFinanciero.TabStop = false;
            this.txtGlFinanciero.Text = "4.5.2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 192;
            this.label7.Text = "Importe Gastos";
            // 
            // cAClienteGastoFinanciero
            // 
            this.cAClienteGastoFinanciero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cAClienteGastoFinanciero.BackColor = System.Drawing.Color.White;
            this.cAClienteGastoFinanciero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cAClienteGastoFinanciero.Location = new System.Drawing.Point(121, 48);
            this.cAClienteGastoFinanciero.Margin = new System.Windows.Forms.Padding(0);
            this.cAClienteGastoFinanciero.Name = "cAClienteGastoFinanciero";
            this.cAClienteGastoFinanciero.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.cAClienteGastoFinanciero.SetDecimales = 2;
            this.cAClienteGastoFinanciero.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cAClienteGastoFinanciero.Size = new System.Drawing.Size(107, 21);
            this.cAClienteGastoFinanciero.TabIndex = 193;
            this.cAClienteGastoFinanciero.ValorMaximo = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.cAClienteGastoFinanciero.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cAClienteGastoFinanciero.XReadOnly = false;
            this.cAClienteGastoFinanciero.Validated += new System.EventHandler(this.cAClienteGastoFinanciero_Validated);
            // 
            // txtAClientesMotivo
            // 
            this.txtAClientesMotivo.BackColor = System.Drawing.Color.White;
            this.txtAClientesMotivo.Location = new System.Drawing.Point(121, 4);
            this.txtAClientesMotivo.MaxLength = 100;
            this.txtAClientesMotivo.Name = "txtAClientesMotivo";
            this.txtAClientesMotivo.Size = new System.Drawing.Size(544, 21);
            this.txtAClientesMotivo.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "Texto Documento";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(49, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 15);
            this.label19.TabIndex = 7;
            this.label19.Text = "IVA Gastos";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cAClientesImporteTotal
            // 
            this.cAClientesImporteTotal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cAClientesImporteTotal.BackColor = System.Drawing.Color.PowderBlue;
            this.cAClientesImporteTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cAClientesImporteTotal.Location = new System.Drawing.Point(121, 93);
            this.cAClientesImporteTotal.Margin = new System.Windows.Forms.Padding(0);
            this.cAClientesImporteTotal.Name = "cAClientesImporteTotal";
            this.cAClientesImporteTotal.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.cAClientesImporteTotal.SetDecimales = 2;
            this.cAClientesImporteTotal.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cAClientesImporteTotal.Size = new System.Drawing.Size(107, 21);
            this.cAClientesImporteTotal.TabIndex = 188;
            this.cAClientesImporteTotal.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.cAClientesImporteTotal.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.cAClientesImporteTotal.XReadOnly = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(58, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 15);
            this.label23.TabIndex = 5;
            this.label23.Text = "Cantidad";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 15);
            this.label24.TabIndex = 187;
            this.label24.Text = "Importe Total";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cAClientesIva
            // 
            this.cAClientesIva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cAClientesIva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cAClientesIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cAClientesIva.Location = new System.Drawing.Point(121, 70);
            this.cAClientesIva.Margin = new System.Windows.Forms.Padding(0);
            this.cAClientesIva.Name = "cAClientesIva";
            this.cAClientesIva.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.cAClientesIva.SetDecimales = 2;
            this.cAClientesIva.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cAClientesIva.Size = new System.Drawing.Size(107, 21);
            this.cAClientesIva.TabIndex = 15;
            this.cAClientesIva.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.cAClientesIva.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.cAClientesIva.XReadOnly = false;
            // 
            // cCantidad
            // 
            this.cCantidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cCantidad.BackColor = System.Drawing.Color.White;
            this.cCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cCantidad.Location = new System.Drawing.Point(121, 26);
            this.cCantidad.Margin = new System.Windows.Forms.Padding(0);
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cCantidad.SetDecimales = 2;
            this.cCantidad.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cCantidad.Size = new System.Drawing.Size(70, 21);
            this.cCantidad.TabIndex = 16;
            this.cCantidad.ValorMaximo = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.cCantidad.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.cCantidad.XReadOnly = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.PaleGreen;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(9, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(671, 21);
            this.label11.TabIndex = 224;
            this.label11.Text = "Gastos A Facturar Cliente";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtLx);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtTipoDocumento);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtId6);
            this.panel5.Controls.Add(this.txtMotivo);
            this.panel5.Location = new System.Drawing.Point(9, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(671, 56);
            this.panel5.TabIndex = 225;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(94, 2);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(246, 21);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Motivo Debito";
            // 
            // txtId6
            // 
            this.txtId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6.Location = new System.Drawing.Point(342, 2);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(46, 21);
            this.txtId6.TabIndex = 9;
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(94, 24);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(246, 21);
            this.txtMotivo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(393, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipo Documento";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDocumento.Location = new System.Drawing.Point(495, 2);
            this.txtTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(170, 21);
            this.txtTipoDocumento.TabIndex = 10;
            // 
            // txtLx
            // 
            this.txtLx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLx.Location = new System.Drawing.Point(342, 24);
            this.txtLx.Margin = new System.Windows.Forms.Padding(2);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(27, 21);
            this.txtLx.TabIndex = 12;
            // 
            // FrmFI64GastosFinancieros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 251);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panelAClientes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI65GastosFinancieros";
            this.Text = "FI64 - Gastos Financieros";
            this.Load += new System.EventHandler(this.FrmFI64GastosFinancieros_Load);
            this.panelAClientes.ResumeLayout(false);
            this.panelAClientes.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Panel panelAClientes;
        private System.Windows.Forms.CheckBox ckCalcularIva;
        private System.Windows.Forms.TextBox txtGlIva;
        private System.Windows.Forms.TextBox txtGlFinanciero;
        private System.Windows.Forms.Label label7;
        private TSControls.CtlTextBox cAClienteGastoFinanciero;
        private System.Windows.Forms.TextBox txtAClientesMotivo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private TSControls.CtlTextBox cAClientesImporteTotal;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private TSControls.CtlTextBox cAClientesIva;
        private TSControls.CtlTextBox cCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtLx;
    }
}