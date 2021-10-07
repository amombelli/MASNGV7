namespace MASngFE.MasterData.Customer_Master
{
    partial class FrmUt01ObtieneDatosPadronAFIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUt01ObtieneDatosPadronAFIP));
            this.txtNumeroDocumento = new System.Windows.Forms.MaskedTextBox();
            this.txtValidacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPadron = new System.Windows.Forms.Button();
            this.txtDireccionFiscal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMapear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.AsciiOnly = true;
            this.txtNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDocumento.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNumeroDocumento.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(118, 7);
            this.txtNumeroDocumento.Mask = "00-00000000-0";
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.PromptChar = '*';
            this.txtNumeroDocumento.Size = new System.Drawing.Size(134, 23);
            this.txtNumeroDocumento.TabIndex = 6;
            this.txtNumeroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroDocumento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
           // 
            // txtValidacion
            // 
            this.txtValidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidacion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidacion.Location = new System.Drawing.Point(259, 7);
            this.txtValidacion.Name = "txtValidacion";
            this.txtValidacion.ReadOnly = true;
            this.txtValidacion.Size = new System.Drawing.Size(110, 23);
            this.txtValidacion.TabIndex = 5;
            this.txtValidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número CUIT";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(118, 6);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(416, 22);
            this.txtRazonSocial.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rázon Social";
            // 
            // btnPadron
            // 
            this.btnPadron.Image = ((System.Drawing.Image)(resources.GetObject("btnPadron.Image")));
            this.btnPadron.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPadron.Location = new System.Drawing.Point(549, 44);
            this.btnPadron.Name = "btnPadron";
            this.btnPadron.Size = new System.Drawing.Size(110, 44);
            this.btnPadron.TabIndex = 7;
            this.btnPadron.Text = "Consultar\r\nPadron";
            this.btnPadron.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPadron.UseVisualStyleBackColor = true;
            this.btnPadron.Click += new System.EventHandler(this.btnPadron_Click);
            // 
            // txtDireccionFiscal
            // 
            this.txtDireccionFiscal.Location = new System.Drawing.Point(118, 29);
            this.txtDireccionFiscal.Name = "txtDireccionFiscal";
            this.txtDireccionFiscal.Size = new System.Drawing.Size(416, 22);
            this.txtDireccionFiscal.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion Fiscal";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(118, 52);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(192, 22);
            this.txtEstado.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(118, 75);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(192, 22);
            this.txtLocalidad.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Localidad";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(118, 98);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(192, 22);
            this.txtProvincia.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Provincia";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(118, 121);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(84, 22);
            this.txtCodigoPostal.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "Codigo Postal";
            // 
            // btnMapear
            // 
            this.btnMapear.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMapear.Image = ((System.Drawing.Image)(resources.GetObject("btnMapear.Image")));
            this.btnMapear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapear.Location = new System.Drawing.Point(549, 87);
            this.btnMapear.Name = "btnMapear";
            this.btnMapear.Size = new System.Drawing.Size(110, 44);
            this.btnMapear.TabIndex = 18;
            this.btnMapear.Text = "Mapear\r\nDatos";
            this.btnMapear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapear.UseVisualStyleBackColor = true;
            this.btnMapear.Click += new System.EventHandler(this.btnMapear_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtRazonSocial);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtCodigoPostal);
            this.panel3.Controls.Add(this.txtDireccionFiscal);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtProvincia);
            this.panel3.Controls.Add(this.txtEstado);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtLocalidad);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(5, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(540, 150);
            this.panel3.TabIndex = 20;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(549, 131);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(110, 44);
            this.btnRegresar.TabIndex = 71;
            this.btnRegresar.Text = "Volver";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNumeroDocumento);
            this.panel1.Controls.Add(this.txtValidacion);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 37);
            this.panel1.TabIndex = 72;
            // 
            // FrmUT01ObtieneDatosPadronAFIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnMapear);
            this.Controls.Add(this.btnPadron);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmUt01ObtieneDatosPadronAFIP";
            this.Text = "UT01 - Obtiene Datos Padron AFIP";
            this.Load += new System.EventHandler(this.FrmDatosPadronAfip_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtValidacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtNumeroDocumento;
        private System.Windows.Forms.Button btnPadron;
        private System.Windows.Forms.TextBox txtDireccionFiscal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMapear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Panel panel1;
    }
}