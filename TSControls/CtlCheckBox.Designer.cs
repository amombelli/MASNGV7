namespace TSControls
{
    partial class CtlCheckBox
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
            this.miCk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // miCk
            // 
            this.miCk.AutoSize = true;
            this.miCk.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miCk.Location = new System.Drawing.Point(0, 0);
            this.miCk.Name = "miCk";
            this.miCk.Size = new System.Drawing.Size(69, 18);
            this.miCk.TabIndex = 0;
            this.miCk.Text = "ck label";
            this.miCk.UseVisualStyleBackColor = true;
            this.miCk.CheckedChanged += new System.EventHandler(this.miCk_CheckedChanged);
            // 
            // CtlCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.miCk);
            this.Name = "CtlCheckBox";
            this.Size = new System.Drawing.Size(150, 16);
            this.SizeChanged += new System.EventHandler(this.CtlCheckBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox miCk;
    }
}
