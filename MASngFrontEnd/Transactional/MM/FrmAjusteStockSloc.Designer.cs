namespace MASngFE.Transactional.MM
{
    partial class FrmAjusteStockSloc
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
            this.btnAjustar = new System.Windows.Forms.Button();
            this.txtSloc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKgAjustar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComentarioAjuste = new System.Windows.Forms.TextBox();
            this.dtpFechaAjuste = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAjustar
            // 
            this.btnAjustar.Location = new System.Drawing.Point(620, 37);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(112, 38);
            this.btnAjustar.TabIndex = 0;
            this.btnAjustar.Text = "Ajustar Stock";
            this.btnAjustar.UseVisualStyleBackColor = true;
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // txtSloc
            // 
            this.txtSloc.Location = new System.Drawing.Point(107, 25);
            this.txtSloc.Name = "txtSloc";
            this.txtSloc.Size = new System.Drawing.Size(51, 20);
            this.txtSloc.TabIndex = 1;
            this.txtSloc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSloc_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ubicacion SLOC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "KG SLOC";
            // 
            // txtKgAjustar
            // 
            this.txtKgAjustar.Location = new System.Drawing.Point(107, 47);
            this.txtKgAjustar.Name = "txtKgAjustar";
            this.txtKgAjustar.ReadOnly = true;
            this.txtKgAjustar.Size = new System.Drawing.Size(75, 20);
            this.txtKgAjustar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comentario Ajuste";
            // 
            // txtComentarioAjuste
            // 
            this.txtComentarioAjuste.Location = new System.Drawing.Point(107, 95);
            this.txtComentarioAjuste.Name = "txtComentarioAjuste";
            this.txtComentarioAjuste.Size = new System.Drawing.Size(392, 20);
            this.txtComentarioAjuste.TabIndex = 5;
            this.txtComentarioAjuste.Leave += new System.EventHandler(this.txtComentarioAjuste_Leave);
            // 
            // dtpFechaAjuste
            // 
            this.dtpFechaAjuste.Location = new System.Drawing.Point(107, 117);
            this.dtpFechaAjuste.Name = "dtpFechaAjuste";
            this.dtpFechaAjuste.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaAjuste.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Ajuste";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Documento";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(107, 69);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(105, 20);
            this.txtNumeroDocumento.TabIndex = 9;
            this.txtNumeroDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroDocumento_Validating);
            // 
            // FrmAjusteStockSloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 627);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaAjuste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComentarioAjuste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKgAjustar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSloc);
            this.Controls.Add(this.btnAjustar);
            this.Name = "FrmAjusteStockSloc";
            this.Text = "FrmAjusteStockSloc";
            this.Load += new System.EventHandler(this.FrmAjusteStockSloc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjustar;
        private System.Windows.Forms.TextBox txtSloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKgAjustar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComentarioAjuste;
        private System.Windows.Forms.DateTimePicker dtpFechaAjuste;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
    }
}