namespace TSControls
{
    partial class CtlControlCuit
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
            this.myMsk = new System.Windows.Forms.MaskedTextBox();
            this.ctlSemaforo = new TSControls.CtlSemaforo();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // myMsk
            // 
            this.myMsk.BeepOnError = true;
            this.myMsk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myMsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myMsk.Location = new System.Drawing.Point(1, 1);
            this.myMsk.Margin = new System.Windows.Forms.Padding(0);
            this.myMsk.Mask = "00-00000000-0";
            this.myMsk.Name = "myMsk";
            this.myMsk.Size = new System.Drawing.Size(91, 21);
            this.myMsk.TabIndex = 0;
            this.myMsk.TextChanged += new System.EventHandler(this.myMsk_TextChanged);
            this.myMsk.DoubleClick += new System.EventHandler(this.myMsk_DoubleClick);
            this.myMsk.Validating += new System.ComponentModel.CancelEventHandler(this.myMsk_Validating);
            // 
            // ctlSemaforo
            // 
            this.ctlSemaforo.Location = new System.Drawing.Point(100, 1);
            this.ctlSemaforo.Name = "ctlSemaforo";
            this.ctlSemaforo.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.ctlSemaforo.Size = new System.Drawing.Size(23, 23);
            this.ctlSemaforo.TabIndex = 1;
            // 
            // CtlControlCuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctlSemaforo);
            this.Controls.Add(this.myMsk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtlControlCuit";
            this.Size = new System.Drawing.Size(125, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox myMsk;
        private CtlSemaforo ctlSemaforo;
        private System.Windows.Forms.ToolTip tt;
    }
}
