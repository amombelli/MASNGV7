namespace MASngFE.Application
{
    partial class FrmArba03ListadoPresentacionesRaffone
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
            this.dgvListadoArba = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArba)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoArba
            // 
            this.dgvListadoArba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoArba.Location = new System.Drawing.Point(13, 77);
            this.dgvListadoArba.Name = "dgvListadoArba";
            this.dgvListadoArba.Size = new System.Drawing.Size(1004, 699);
            this.dgvListadoArba.TabIndex = 0;
            // 
            // FrmARBA03ListadoPresentacionesRaffone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 788);
            this.Controls.Add(this.dgvListadoArba);
            this.Name = "FrmArba03ListadoPresentacionesRaffone";
            this.Text = "ARBA03 - Listado Presentaciones ARBA Raffone";
            this.Load += new System.EventHandler(this.FrmARBA03ListadoPresentacionesRaffone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoArba;
    }
}