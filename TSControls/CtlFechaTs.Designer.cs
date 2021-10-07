namespace TSControls
{
    partial class CtlFechaTs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFechaTs));
            this.mskFecha1 = new System.Windows.Forms.MaskedTextBox();
            this.zRed = new System.Windows.Forms.PictureBox();
            this.zGreen = new System.Windows.Forms.PictureBox();
            this.zYellow = new System.Windows.Forms.PictureBox();
            this.toolTipX = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.zRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zYellow)).BeginInit();
            this.SuspendLayout();
            // 
            // mskFecha1
            // 
            this.mskFecha1.BeepOnError = true;
            this.mskFecha1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFecha1.Location = new System.Drawing.Point(1, 1);
            this.mskFecha1.Margin = new System.Windows.Forms.Padding(0);
            this.mskFecha1.Mask = "00/00/0000";
            this.mskFecha1.Name = "mskFecha1";
            this.mskFecha1.Size = new System.Drawing.Size(70, 21);
            this.mskFecha1.TabIndex = 0;
            this.mskFecha1.ValidatingType = typeof(System.DateTime);
            this.mskFecha1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskFecha1_MaskInputRejected);
            this.mskFecha1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mskFecha1_TypeValidationCompleted);
            this.mskFecha1.DoubleClick += new System.EventHandler(this.mskFecha1_DoubleClick);
            this.mskFecha1.Validating += new System.ComponentModel.CancelEventHandler(this.mskFecha1_Validating);
            // 
            // zRed
            // 
            this.zRed.Image = ((System.Drawing.Image)(resources.GetObject("zRed.Image")));
            this.zRed.Location = new System.Drawing.Point(74, 0);
            this.zRed.Margin = new System.Windows.Forms.Padding(0);
            this.zRed.Name = "zRed";
            this.zRed.Size = new System.Drawing.Size(22, 22);
            this.zRed.TabIndex = 2;
            this.zRed.TabStop = false;
            // 
            // zGreen
            // 
            this.zGreen.Image = ((System.Drawing.Image)(resources.GetObject("zGreen.Image")));
            this.zGreen.Location = new System.Drawing.Point(74, 0);
            this.zGreen.Margin = new System.Windows.Forms.Padding(0);
            this.zGreen.Name = "zGreen";
            this.zGreen.Size = new System.Drawing.Size(22, 22);
            this.zGreen.TabIndex = 3;
            this.zGreen.TabStop = false;
            // 
            // zYellow
            // 
            this.zYellow.Image = ((System.Drawing.Image)(resources.GetObject("zYellow.Image")));
            this.zYellow.Location = new System.Drawing.Point(73, 0);
            this.zYellow.Margin = new System.Windows.Forms.Padding(0);
            this.zYellow.Name = "zYellow";
            this.zYellow.Size = new System.Drawing.Size(22, 22);
            this.zYellow.TabIndex = 4;
            this.zYellow.TabStop = false;
            // 
            // CtlFechaTs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.zYellow);
            this.Controls.Add(this.zGreen);
            this.Controls.Add(this.zRed);
            this.Controls.Add(this.mskFecha1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtlFechaTs";
            this.Size = new System.Drawing.Size(97, 23);
            this.Load += new System.EventHandler(this.ctlFechaControl_Load);
            this.Resize += new System.EventHandler(this.CtlFechaTs_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.zRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zYellow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskFecha1;
        private System.Windows.Forms.PictureBox zRed;
        private System.Windows.Forms.PictureBox zGreen;
        private System.Windows.Forms.PictureBox zYellow;
        private System.Windows.Forms.ToolTip toolTipX;
    }
}
