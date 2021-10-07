namespace MASngFE.FIX
{
    partial class FrmFixFacturaL5
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
            this.txtIdRemitoInt = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFix = new System.Windows.Forms.Button();
            this.ckRemitoL5 = new System.Windows.Forms.CheckBox();
            this.ckRemitoL1 = new System.Windows.Forms.CheckBox();
            this.ckRemitoL2 = new System.Windows.Forms.CheckBox();
            this.txtRlink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoRlink = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIdRemitoInt
            // 
            this.txtIdRemitoInt.Location = new System.Drawing.Point(160, 23);
            this.txtIdRemitoInt.Name = "txtIdRemitoInt";
            this.txtIdRemitoInt.Size = new System.Drawing.Size(89, 22);
            this.txtIdRemitoInt.TabIndex = 0;
            this.txtIdRemitoInt.TextChanged += new System.EventHandler(this.txtIdRemitoInt_TextChanged);
            this.txtIdRemitoInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdRemitoInt_KeyPress);
            this.txtIdRemitoInt.Leave += new System.EventHandler(this.txtIdRemitoInt_Leave);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(255, 23);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(303, 22);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IDINT REMITO L1";
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(313, 220);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(84, 38);
            this.btnFix.TabIndex = 3;
            this.btnFix.Text = "FIX";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // ckRemitoL5
            // 
            this.ckRemitoL5.AutoSize = true;
            this.ckRemitoL5.Enabled = false;
            this.ckRemitoL5.Location = new System.Drawing.Point(15, 114);
            this.ckRemitoL5.Name = "ckRemitoL5";
            this.ckRemitoL5.Size = new System.Drawing.Size(227, 21);
            this.ckRemitoL5.TabIndex = 4;
            this.ckRemitoL5.Text = "CORRESPONDE A REMITO L5";
            this.ckRemitoL5.UseVisualStyleBackColor = true;
            // 
            // ckRemitoL1
            // 
            this.ckRemitoL1.AutoSize = true;
            this.ckRemitoL1.Location = new System.Drawing.Point(15, 60);
            this.ckRemitoL1.Name = "ckRemitoL1";
            this.ckRemitoL1.Size = new System.Drawing.Size(103, 21);
            this.ckRemitoL1.TabIndex = 5;
            this.ckRemitoL1.Text = "REMITO L1";
            this.ckRemitoL1.UseVisualStyleBackColor = true;
            // 
            // ckRemitoL2
            // 
            this.ckRemitoL2.AutoSize = true;
            this.ckRemitoL2.Location = new System.Drawing.Point(15, 87);
            this.ckRemitoL2.Name = "ckRemitoL2";
            this.ckRemitoL2.Size = new System.Drawing.Size(103, 21);
            this.ckRemitoL2.TabIndex = 6;
            this.ckRemitoL2.Text = "REMITO L2";
            this.ckRemitoL2.UseVisualStyleBackColor = true;
            // 
            // txtRlink
            // 
            this.txtRlink.Location = new System.Drawing.Point(201, 220);
            this.txtRlink.Name = "txtRlink";
            this.txtRlink.Size = new System.Drawing.Size(89, 22);
            this.txtRlink.TabIndex = 7;
            this.txtRlink.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "IDINT REMITO ASOCIADO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "TIPO REMITO ASOCIADO";
            // 
            // txtTipoRlink
            // 
            this.txtTipoRlink.Location = new System.Drawing.Point(201, 249);
            this.txtTipoRlink.Name = "txtTipoRlink";
            this.txtTipoRlink.Size = new System.Drawing.Size(39, 22);
            this.txtTipoRlink.TabIndex = 9;
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSalir.Location = new System.Drawing.Point(465, 220);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 38);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmFixFacturaL5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 287);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTipoRlink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRlink);
            this.Controls.Add(this.ckRemitoL2);
            this.Controls.Add(this.ckRemitoL1);
            this.Controls.Add(this.ckRemitoL5);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtIdRemitoInt);
            this.Name = "FrmFixFacturaL5";
            this.Text = "FrmFixFacturaL5";
            this.Load += new System.EventHandler(this.FrmFixFacturaL5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdRemitoInt;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.CheckBox ckRemitoL5;
        private System.Windows.Forms.CheckBox ckRemitoL1;
        private System.Windows.Forms.CheckBox ckRemitoL2;
        private System.Windows.Forms.TextBox txtRlink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoRlink;
        private System.Windows.Forms.Button btnSalir;
    }
}