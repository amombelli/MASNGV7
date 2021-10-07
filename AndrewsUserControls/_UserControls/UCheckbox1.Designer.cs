namespace MASngFE._UserControls
{
    partial class UCheckbox1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.Location = new System.Drawing.Point(1, 0);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(86, 19);
            this.ck.TabIndex = 0;
            this.ck.Text = "checkBox1";
            this.ck.UseVisualStyleBackColor = true;
            this.ck.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // UCheckbox1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ck);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCheckbox1";
            this.Size = new System.Drawing.Size(146, 19);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ck;
    }
}
