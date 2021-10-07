namespace MASngFE.Transactional.CO.GL
{
    partial class FrmCO32GLSReclass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO32GLSReclass));
            this.btnUpdateGL = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbGLAccountDescripcion = new System.Windows.Forms.ComboBox();
            this.t0135GLXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbGLAccount = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtGlOriDescripcion = new System.Windows.Forms.TextBox();
            this.txtGLOri = new System.Windows.Forms.TextBox();
            this.txtSegmento = new System.Windows.Forms.TextBox();
            this.txtAsiento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDetalleAsiento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtValorDebe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorHaber = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLXBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateGL
            // 
            this.btnUpdateGL.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateGL.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateGL.Image")));
            this.btnUpdateGL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateGL.Location = new System.Drawing.Point(659, 126);
            this.btnUpdateGL.Name = "btnUpdateGL";
            this.btnUpdateGL.Size = new System.Drawing.Size(100, 44);
            this.btnUpdateGL.TabIndex = 79;
            this.btnUpdateGL.Text = "Update\r\nGL";
            this.btnUpdateGL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateGL.UseVisualStyleBackColor = true;
            this.btnUpdateGL.Click += new System.EventHandler(this.btnUpdateGL_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(658, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 78;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.cmbGLAccountDescripcion);
            this.panel1.Controls.Add(this.cmbGLAccount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 32);
            this.panel1.TabIndex = 80;
            // 
            // cmbGLAccountDescripcion
            // 
            this.cmbGLAccountDescripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGLAccountDescripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLAccountDescripcion.DataSource = this.t0135GLXBindingSource;
            this.cmbGLAccountDescripcion.DisplayMember = "GLDESC";
            this.cmbGLAccountDescripcion.FormattingEnabled = true;
            this.cmbGLAccountDescripcion.Location = new System.Drawing.Point(250, 4);
            this.cmbGLAccountDescripcion.Name = "cmbGLAccountDescripcion";
            this.cmbGLAccountDescripcion.Size = new System.Drawing.Size(388, 23);
            this.cmbGLAccountDescripcion.TabIndex = 85;
            this.cmbGLAccountDescripcion.ValueMember = "GL";
            // 
            // t0135GLXBindingSource
            // 
            this.t0135GLXBindingSource.DataSource = typeof(TecserEF.Entity.T0135_GLX);
            // 
            // cmbGLAccount
            // 
            this.cmbGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLAccount.DataSource = this.t0135GLXBindingSource;
            this.cmbGLAccount.DisplayMember = "GL";
            this.cmbGLAccount.FormattingEnabled = true;
            this.cmbGLAccount.Location = new System.Drawing.Point(136, 4);
            this.cmbGLAccount.Name = "cmbGLAccount";
            this.cmbGLAccount.Size = new System.Drawing.Size(112, 23);
            this.cmbGLAccount.TabIndex = 84;
            this.cmbGLAccount.ValueMember = "GL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 15);
            this.label9.TabIndex = 83;
            this.label9.Text = "Cuenta Contable (GL)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtGlOriDescripcion);
            this.panel3.Controls.Add(this.txtGLOri);
            this.panel3.Controls.Add(this.txtSegmento);
            this.panel3.Controls.Add(this.txtAsiento);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 57);
            this.panel3.TabIndex = 82;
            // 
            // txtGlOriDescripcion
            // 
            this.txtGlOriDescripcion.Location = new System.Drawing.Point(144, 30);
            this.txtGlOriDescripcion.Name = "txtGlOriDescripcion";
            this.txtGlOriDescripcion.ReadOnly = true;
            this.txtGlOriDescripcion.Size = new System.Drawing.Size(363, 22);
            this.txtGlOriDescripcion.TabIndex = 53;
            // 
            // txtGLOri
            // 
            this.txtGLOri.Location = new System.Drawing.Point(72, 30);
            this.txtGLOri.Name = "txtGLOri";
            this.txtGLOri.ReadOnly = true;
            this.txtGLOri.Size = new System.Drawing.Size(70, 22);
            this.txtGLOri.TabIndex = 52;
            // 
            // txtSegmento
            // 
            this.txtSegmento.Location = new System.Drawing.Point(218, 6);
            this.txtSegmento.Name = "txtSegmento";
            this.txtSegmento.ReadOnly = true;
            this.txtSegmento.Size = new System.Drawing.Size(26, 22);
            this.txtSegmento.TabIndex = 51;
            // 
            // txtAsiento
            // 
            this.txtAsiento.Location = new System.Drawing.Point(72, 6);
            this.txtAsiento.Name = "txtAsiento";
            this.txtAsiento.ReadOnly = true;
            this.txtAsiento.Size = new System.Drawing.Size(70, 22);
            this.txtAsiento.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 49;
            this.label6.Text = "Cuenta GL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 47;
            this.label7.Text = "Segmento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 14);
            this.label8.TabIndex = 43;
            this.label8.Text = "Asiento #";
            // 
            // btnDetalleAsiento
            // 
            this.btnDetalleAsiento.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleAsiento.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleAsiento.Image")));
            this.btnDetalleAsiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleAsiento.Location = new System.Drawing.Point(658, 48);
            this.btnDetalleAsiento.Name = "btnDetalleAsiento";
            this.btnDetalleAsiento.Size = new System.Drawing.Size(100, 44);
            this.btnDetalleAsiento.TabIndex = 38;
            this.btnDetalleAsiento.Text = "Detalle\r\nAsiento";
            this.btnDetalleAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleAsiento.UseVisualStyleBackColor = true;
            this.btnDetalleAsiento.Click += new System.EventHandler(this.btnDetalleAsiento_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(6, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 3);
            this.label1.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(6, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(647, 3);
            this.label2.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(517, 3);
            this.label3.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.txtValorHaber);
            this.panel2.Controls.Add(this.txtValorDebe);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 51);
            this.panel2.TabIndex = 83;
            // 
            // txtValorDebe
            // 
            this.txtValorDebe.Location = new System.Drawing.Point(72, 25);
            this.txtValorDebe.Name = "txtValorDebe";
            this.txtValorDebe.ReadOnly = true;
            this.txtValorDebe.Size = new System.Drawing.Size(92, 22);
            this.txtValorDebe.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 49;
            this.label4.Text = "Haber";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 14);
            this.label10.TabIndex = 43;
            this.label10.Text = "Debe";
            // 
            // txtValorHaber
            // 
            this.txtValorHaber.Location = new System.Drawing.Point(166, 25);
            this.txtValorHaber.Name = "txtValorHaber";
            this.txtValorHaber.ReadOnly = true;
            this.txtValorHaber.Size = new System.Drawing.Size(92, 22);
            this.txtValorHaber.TabIndex = 51;
            // 
            // FrmCO32GLSReclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 174);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUpdateGL);
            this.Controls.Add(this.btnDetalleAsiento);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmCO32GLSReclass";
            this.Text = "CO32 - GL Account Reclass";
            this.Load += new System.EventHandler(this.FrmCO32GLSReclass_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLXBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateGL;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtGlOriDescripcion;
        private System.Windows.Forms.TextBox txtGLOri;
        private System.Windows.Forms.TextBox txtSegmento;
        private System.Windows.Forms.TextBox txtAsiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDetalleAsiento;
        private System.Windows.Forms.BindingSource t0135GLXBindingSource;
        private System.Windows.Forms.ComboBox cmbGLAccountDescripcion;
        private System.Windows.Forms.ComboBox cmbGLAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtValorHaber;
        private System.Windows.Forms.TextBox txtValorDebe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
    }
}