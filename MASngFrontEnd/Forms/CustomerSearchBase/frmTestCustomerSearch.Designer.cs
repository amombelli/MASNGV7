namespace MASngFE.Forms.CustomerSearchBase
{
    partial class frmTestCustomerSearch
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
            this.tsUcCustomer31 = new MASngFE._0TSUserControls.TsUcCustomer3();
            this.SuspendLayout();
            // 
            // tsUcCustomer31
            // 
            this.tsUcCustomer31.BackColor = System.Drawing.Color.White;
            this.tsUcCustomer31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsUcCustomer31.Location = new System.Drawing.Point(6, 5);
            this.tsUcCustomer31.Name = "tsUcCustomer31";
            this.tsUcCustomer31.Size = new System.Drawing.Size(604, 99);
            this.tsUcCustomer31.TabIndex = 0;
            // 
            // frmTestCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.tsUcCustomer31);
            this.Name = "frmTestCustomerSearch";
            this.Text = "ts";
            this.Load += new System.EventHandler(this.frmTestCustomerSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private _0TSUserControls.TsUcCustomer3 tsUcCustomer31;
    }
}