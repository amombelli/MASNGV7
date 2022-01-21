namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI36Retenciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI36Retenciones));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stxVendorDocPPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.cmbTipoRetencion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAddRetencion = new System.Windows.Forms.Button();
            this.ctlImporteRetencion = new TSControls.CtlTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ctlAlicuota = new TSControls.CtlTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGLItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctlBaseImponible = new TSControls.CtlTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stxVendorDocPPBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(513, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 223);
            this.label2.TabIndex = 208;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkBlue;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(3, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(513, 3);
            this.label3.TabIndex = 209;
            // 
            // stxVendorDocPPBindingSource
            // 
            this.stxVendorDocPPBindingSource.DataSource = typeof(Tecser.Business.Transactional.FI.ContabilizacionProveedores.StxVendorDocPP);
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFantasia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(116, 41);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(372, 22);
            this.txtFantasia.TabIndex = 194;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 195;
            this.label4.Text = "Nombre Fantasia";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRazonSocial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(116, 18);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(372, 22);
            this.txtRazonSocial.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Razón Social";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Controls.Add(this.txtFantasia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 72);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado de Orden de Pago";
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(3, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 223);
            this.LineaIzq.TabIndex = 205;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(3, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(513, 3);
            this.lineaArriba.TabIndex = 204;
            // 
            // cmbTipoRetencion
            // 
            this.cmbTipoRetencion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoRetencion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoRetencion.FormattingEnabled = true;
            this.cmbTipoRetencion.Items.AddRange(new object[] {
            "Ganancias [AFIP]",
            "IIBB [ARBA]"});
            this.cmbTipoRetencion.Location = new System.Drawing.Point(130, 7);
            this.cmbTipoRetencion.Name = "cmbTipoRetencion";
            this.cmbTipoRetencion.Size = new System.Drawing.Size(189, 25);
            this.cmbTipoRetencion.TabIndex = 211;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 14);
            this.label5.TabIndex = 196;
            this.label5.Text = "Tipo de Retencion";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.Controls.Add(this.btnConfirmar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAddRetencion);
            this.panel2.Controls.Add(this.ctlImporteRetencion);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.ctlAlicuota);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtGLItem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbTipoRetencion);
            this.panel2.Controls.Add(this.ctlBaseImponible);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(10, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 138);
            this.panel2.TabIndex = 212;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(372, 82);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 46);
            this.btnCancelar.TabIndex = 216;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAddRetencion
            // 
            this.btnAddRetencion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRetencion.Image")));
            this.btnAddRetencion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRetencion.Location = new System.Drawing.Point(372, 36);
            this.btnAddRetencion.Name = "btnAddRetencion";
            this.btnAddRetencion.Size = new System.Drawing.Size(117, 46);
            this.btnAddRetencion.TabIndex = 213;
            this.btnAddRetencion.Text = "AGREGAR";
            this.btnAddRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRetencion.UseVisualStyleBackColor = true;
            this.btnAddRetencion.Click += new System.EventHandler(this.btnAddRetencion_Click);
            // 
            // ctlImporteRetencion
            // 
            this.ctlImporteRetencion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlImporteRetencion.BackColor = System.Drawing.Color.White;
            this.ctlImporteRetencion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlImporteRetencion.Location = new System.Drawing.Point(130, 85);
            this.ctlImporteRetencion.Margin = new System.Windows.Forms.Padding(0);
            this.ctlImporteRetencion.Name = "ctlImporteRetencion";
            this.ctlImporteRetencion.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlImporteRetencion.SetDecimales = 2;
            this.ctlImporteRetencion.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlImporteRetencion.Size = new System.Drawing.Size(121, 25);
            this.ctlImporteRetencion.TabIndex = 215;
            this.ctlImporteRetencion.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ctlImporteRetencion.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlImporteRetencion.XReadOnly = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 214;
            this.label10.Text = "Importe Retencion";
            // 
            // ctlAlicuota
            // 
            this.ctlAlicuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlAlicuota.BackColor = System.Drawing.Color.White;
            this.ctlAlicuota.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAlicuota.Location = new System.Drawing.Point(130, 59);
            this.ctlAlicuota.Margin = new System.Windows.Forms.Padding(0);
            this.ctlAlicuota.Name = "ctlAlicuota";
            this.ctlAlicuota.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlAlicuota.SetDecimales = 2;
            this.ctlAlicuota.SetType = TSControls.CtlTextBox.TextBoxType.Porcentaje;
            this.ctlAlicuota.Size = new System.Drawing.Size(121, 25);
            this.ctlAlicuota.TabIndex = 213;
            this.ctlAlicuota.ValorMaximo = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ctlAlicuota.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlAlicuota.XReadOnly = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 212;
            this.label6.Text = "Alicuota";
            // 
            // txtGLItem
            // 
            this.txtGLItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLItem.Location = new System.Drawing.Point(387, 7);
            this.txtGLItem.Name = "txtGLItem";
            this.txtGLItem.ReadOnly = true;
            this.txtGLItem.Size = new System.Drawing.Size(101, 25);
            this.txtGLItem.TabIndex = 206;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(329, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 205;
            this.label7.Text = "GL Item";
            // 
            // ctlBaseImponible
            // 
            this.ctlBaseImponible.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlBaseImponible.BackColor = System.Drawing.Color.White;
            this.ctlBaseImponible.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBaseImponible.Location = new System.Drawing.Point(130, 33);
            this.ctlBaseImponible.Margin = new System.Windows.Forms.Padding(0);
            this.ctlBaseImponible.Name = "ctlBaseImponible";
            this.ctlBaseImponible.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlBaseImponible.SetDecimales = 2;
            this.ctlBaseImponible.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlBaseImponible.Size = new System.Drawing.Size(121, 25);
            this.ctlBaseImponible.TabIndex = 201;
            this.ctlBaseImponible.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ctlBaseImponible.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlBaseImponible.XReadOnly = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 200;
            this.label8.Text = "Base Imponible";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(372, 36);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(117, 46);
            this.btnConfirmar.TabIndex = 217;
            this.btnConfirmar.Text = "AGREGAR";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FrmFI36Retenciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 232);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI36Retenciones";
            this.Text = "FI36 Retenciones";
            this.Load += new System.EventHandler(this.FrmFI36Retenciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stxVendorDocPPBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource stxVendorDocPPBindingSource;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.ComboBox cmbTipoRetencion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtGLItem;
        private System.Windows.Forms.Label label7;
        private TSControls.CtlTextBox ctlBaseImponible;
        private System.Windows.Forms.Label label8;
        private TSControls.CtlTextBox ctlImporteRetencion;
        private System.Windows.Forms.Label label10;
        private TSControls.CtlTextBox ctlAlicuota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddRetencion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}