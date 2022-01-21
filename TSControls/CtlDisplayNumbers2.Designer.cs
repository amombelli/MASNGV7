namespace TSControls
{
    partial class CtlDisplayNumbers2
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
            this.myTextBox = new System.Windows.Forms.TextBox();
            this.cIcon = new TSControls.CtlIconos();
            this.SuspendLayout();
            // 
            // myTextBox
            // 
            this.myTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myTextBox.Location = new System.Drawing.Point(3, 3);
            this.myTextBox.Name = "myTextBox";
            this.myTextBox.Size = new System.Drawing.Size(100, 16);
            this.myTextBox.TabIndex = 2;
            this.myTextBox.Text = "156";
            // 
            // cIcon
            // 
            this.cIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIcon.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cIcon.IconSize = TSControls.TamañoIcono.Chico;
            this.cIcon.Location = new System.Drawing.Point(103, 3);
            this.cIcon.Name = "cIcon";
            this.cIcon.Set = TSControls.CIconos.Mas;
            this.cIcon.Size = new System.Drawing.Size(16, 16);
            this.cIcon.TabIndex = 3;
            // 
            // CtlDisplayNumbers2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cIcon);
            this.Controls.Add(this.myTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtlDisplayNumbers2";
            this.Size = new System.Drawing.Size(142, 22);
            this.Load += new System.EventHandler(this.CtlDisplayNumbers2_Load);
            this.Resize += new System.EventHandler(this.CtlDisplayNumbers2_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlIconos cIcon;
        private System.Windows.Forms.TextBox myTextBox;
    }
}
