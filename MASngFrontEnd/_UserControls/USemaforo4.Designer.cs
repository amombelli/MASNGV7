namespace MASngFE._UserControls
{
    partial class USemaforo4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USemaforo4));
            this.blue = new System.Windows.Forms.PictureBox();
            this.yellow = new System.Windows.Forms.PictureBox();
            this.green = new System.Windows.Forms.PictureBox();
            this.red = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            this.SuspendLayout();
            // 
            // blue
            // 
            this.blue.Image = ((System.Drawing.Image)(resources.GetObject("blue.Image")));
            this.blue.Location = new System.Drawing.Point(-1, 0);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(25, 26);
            this.blue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.blue.TabIndex = 55;
            this.blue.TabStop = false;
            this.blue.Click += new System.EventHandler(this.blue_Click);
            // 
            // yellow
            // 
            this.yellow.Image = ((System.Drawing.Image)(resources.GetObject("yellow.Image")));
            this.yellow.Location = new System.Drawing.Point(-1, 0);
            this.yellow.Name = "yellow";
            this.yellow.Size = new System.Drawing.Size(25, 26);
            this.yellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.yellow.TabIndex = 54;
            this.yellow.TabStop = false;
            this.yellow.Click += new System.EventHandler(this.yellow_Click);
            // 
            // green
            // 
            this.green.Image = global::MASngFE.Properties.Resources.iconGreen;
            this.green.Location = new System.Drawing.Point(-1, 0);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(25, 26);
            this.green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.green.TabIndex = 53;
            this.green.TabStop = false;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // red
            // 
            this.red.Image = global::MASngFE.Properties.Resources.iconRed;
            this.red.Location = new System.Drawing.Point(-1, 0);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(25, 26);
            this.red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.red.TabIndex = 52;
            this.red.TabStop = false;
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // USemaforo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.blue);
            this.Controls.Add(this.yellow);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Name = "USemaforo4";
            this.Size = new System.Drawing.Size(23, 26);
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox blue;
        private System.Windows.Forms.PictureBox yellow;
        private System.Windows.Forms.PictureBox green;
        private System.Windows.Forms.PictureBox red;
    }
}
