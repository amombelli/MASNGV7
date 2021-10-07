namespace TSControls
{
    partial class TsButton1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TsButton1));
            this.miLabel = new System.Windows.Forms.Label();
            this.miBoton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // miLabel
            // 
            this.miLabel.BackColor = System.Drawing.Color.DarkGray;
            this.miLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.miLabel.Location = new System.Drawing.Point(1, 1);
            this.miLabel.Name = "miLabel";
            this.miLabel.Size = new System.Drawing.Size(105, 24);
            this.miLabel.TabIndex = 261;
            this.miLabel.Text = "Imprimir DOC";
            this.miLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // miBoton
            // 
            this.miBoton.BackColor = System.Drawing.Color.White;
            this.miBoton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("miBoton.BackgroundImage")));
            this.miBoton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.miBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.miBoton.Location = new System.Drawing.Point(3, 2);
            this.miBoton.Name = "miBoton";
            this.miBoton.Size = new System.Drawing.Size(102, 66);
            this.miBoton.TabIndex = 262;
            this.miBoton.UseVisualStyleBackColor = false;
            this.miBoton.Click += new System.EventHandler(this.btn1_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Lime;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.miBoton);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(110, 72);
            this.panel.TabIndex = 263;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.miLabel);
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 28);
            this.panel2.TabIndex = 264;
            // 
            // TsButton1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TsButton1";
            this.Size = new System.Drawing.Size(110, 100);
            this.Load += new System.EventHandler(this.TsButton1_Load);
            this.SizeChanged += new System.EventHandler(this.TsButton1_SizeChanged);
            this.panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label miLabel;
        private System.Windows.Forms.Button miBoton;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel2;
    }
}
