namespace TSControls
{
    partial class Form1
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
            this.ctlControlCuit1 = new TSControls.CtlControlCuit();
            this.SuspendLayout();
            // 
            // ctlControlCuit1
            // 
            this.ctlControlCuit1.BackColor = System.Drawing.Color.White;
            this.ctlControlCuit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlControlCuit1.Location = new System.Drawing.Point(115, 131);
            this.ctlControlCuit1.Name = "ctlControlCuit1";
            this.ctlControlCuit1.Size = new System.Drawing.Size(189, 21);
            this.ctlControlCuit1.TabIndex = 0;
            this.ctlControlCuit1.Value = null;
            this.ctlControlCuit1.ZdoValidation = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctlControlCuit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CtlControlCuit ctlControlCuit1;
    }
}