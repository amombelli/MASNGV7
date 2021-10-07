namespace MASngFE.Forms
{
    partial class FrmMdc00CustomerSearchSaldos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtSaldoTotal);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.txtSaldoL1);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.txtSaldoL2);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Location = new System.Drawing.Point(586, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 116);
            this.panel3.TabIndex = 97;
            this.panel3.UseWaitCursor = true;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(88, 90);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoTotal.TabIndex = 67;
            this.txtSaldoTotal.TabStop = false;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaldoTotal.UseWaitCursor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(12, 91);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 15);
            this.label45.TabIndex = 68;
            this.label45.Text = "Saldo Total";
            this.label45.UseWaitCursor = true;
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Location = new System.Drawing.Point(88, 9);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL1.TabIndex = 63;
            this.txtSaldoL1.TabStop = false;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaldoL1.UseWaitCursor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 15);
            this.label26.TabIndex = 64;
            this.label26.Text = "Saldo L1";
            this.label26.UseWaitCursor = true;
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtSaldoL2.Location = new System.Drawing.Point(88, 30);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL2.TabIndex = 65;
            this.txtSaldoL2.TabStop = false;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaldoL2.UseWaitCursor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(12, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 15);
            this.label25.TabIndex = 66;
            this.label25.Text = "Saldo L2";
            this.label25.UseWaitCursor = true;
            // 
            // FrmMdc00CustomerSearchSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 261);
            this.Controls.Add(this.panel3);
            this.Name = "FrmMdc00CustomerSearchSaldos";
            this.Text = "FrmMdc00CustomerSearchSaldos";
            this.Load += new System.EventHandler(this.FrmCustomerSearchSaldos_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label25;
    }
}