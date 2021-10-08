namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO16_MopSinRegistrar
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
            this.label3 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRemitosSinIngresar = new System.Windows.Forms.DataGridView();
            this.dgvNotasSinIngresar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosSinIngresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasSinIngresar)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Brown;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 578);
            this.label3.TabIndex = 150;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Brown;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(3, 3);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(992, 3);
            this.label58.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Brown;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(992, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 578);
            this.label1.TabIndex = 151;
            // 
            // dgvRemitosSinIngresar
            // 
            this.dgvRemitosSinIngresar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitosSinIngresar.Location = new System.Drawing.Point(12, 127);
            this.dgvRemitosSinIngresar.Name = "dgvRemitosSinIngresar";
            this.dgvRemitosSinIngresar.Size = new System.Drawing.Size(947, 343);
            this.dgvRemitosSinIngresar.TabIndex = 152;
            // 
            // dgvNotasSinIngresar
            // 
            this.dgvNotasSinIngresar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotasSinIngresar.Location = new System.Drawing.Point(12, 476);
            this.dgvNotasSinIngresar.Name = "dgvNotasSinIngresar";
            this.dgvNotasSinIngresar.Size = new System.Drawing.Size(947, 343);
            this.dgvNotasSinIngresar.TabIndex = 153;
            // 
            // FrmCO16_MopSinRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 836);
            this.Controls.Add(this.dgvNotasSinIngresar);
            this.Controls.Add(this.dgvRemitosSinIngresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label58);
            this.Name = "FrmCO16_MopSinRegistrar";
            this.Text = "CO16 - Registros Sin Incluir en MOP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosSinIngresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasSinIngresar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRemitosSinIngresar;
        private System.Windows.Forms.DataGridView dgvNotasSinIngresar;
    }
}