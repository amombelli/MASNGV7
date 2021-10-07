namespace TSControls
{
    partial class CtlSemaforo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlSemaforo));
            this.zYellow = new System.Windows.Forms.PictureBox();
            this.zGreen = new System.Windows.Forms.PictureBox();
            this.zRed = new System.Windows.Forms.PictureBox();
            this.zBlue = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // zYellow
            // 
            this.zYellow.Image = ((System.Drawing.Image)(resources.GetObject("zYellow.Image")));
            this.zYellow.Location = new System.Drawing.Point(0, 0);
            this.zYellow.Name = "zYellow";
            this.zYellow.Size = new System.Drawing.Size(23, 23);
            this.zYellow.TabIndex = 7;
            this.zYellow.TabStop = false;
            // 
            // zGreen
            // 
            this.zGreen.Image = ((System.Drawing.Image)(resources.GetObject("zGreen.Image")));
            this.zGreen.Location = new System.Drawing.Point(0, 0);
            this.zGreen.Name = "zGreen";
            this.zGreen.Size = new System.Drawing.Size(23, 23);
            this.zGreen.TabIndex = 6;
            this.zGreen.TabStop = false;
            // 
            // zRed
            // 
            this.zRed.Image = ((System.Drawing.Image)(resources.GetObject("zRed.Image")));
            this.zRed.Location = new System.Drawing.Point(0, 0);
            this.zRed.Name = "zRed";
            this.zRed.Size = new System.Drawing.Size(23, 23);
            this.zRed.TabIndex = 5;
            this.zRed.TabStop = false;
            // 
            // zBlue
            // 
            this.zBlue.Image = ((System.Drawing.Image)(resources.GetObject("zBlue.Image")));
            this.zBlue.Location = new System.Drawing.Point(0, 1);
            this.zBlue.Name = "zBlue";
            this.zBlue.Size = new System.Drawing.Size(23, 23);
            this.zBlue.TabIndex = 8;
            this.zBlue.TabStop = false;
            // 
            // CtlSemaforo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zBlue);
            this.Controls.Add(this.zYellow);
            this.Controls.Add(this.zGreen);
            this.Controls.Add(this.zRed);
            this.Name = "CtlSemaforo";
            this.Size = new System.Drawing.Size(23, 23);
            this.Load += new System.EventHandler(this.CtlSemaforo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox zYellow;
        private System.Windows.Forms.PictureBox zGreen;
        private System.Windows.Forms.PictureBox zRed;
        private System.Windows.Forms.PictureBox zBlue;
    }
}
