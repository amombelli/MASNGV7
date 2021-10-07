namespace TSControls
{
    partial class CtlTextBox
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
            this.myTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // myTextBox
            // 
            this.myTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.myTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myTextBox.Location = new System.Drawing.Point(0, 0);
            this.myTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.myTextBox.Name = "myTextBox";
            this.myTextBox.Size = new System.Drawing.Size(74, 21);
            this.myTextBox.TabIndex = 0;
            this.myTextBox.DoubleClick += new System.EventHandler(this.myTextBox_DoubleClick);
            this.myTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myTextBox_KeyPress);
            this.myTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.myTextBox_Validating);
            // 
            // CtlTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.myTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtlTextBox";
            this.Size = new System.Drawing.Size(76, 21);
            this.Load += new System.EventHandler(this.CtlTextBox_Load);
            this.SizeChanged += new System.EventHandler(this.CtlTextBox_SizeChanged);
            this.Resize += new System.EventHandler(this.CtlTextBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
