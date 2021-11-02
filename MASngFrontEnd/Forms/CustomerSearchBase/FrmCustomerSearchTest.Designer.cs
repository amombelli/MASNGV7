namespace MASngFE.Forms.CustomerSearchBase
{
    partial class FrmCustomerSearchTest
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
            this.tsUcVendorSelector1 = new MASngFE._0TSUserControls.TsUcVendorSelector();
            this.SuspendLayout();
            // 
            // tsUcCustomer31
            // 
            this.tsUcCustomer31.BackColor = System.Drawing.Color.White;
            this.tsUcCustomer31.ClienteId = null;
            this.tsUcCustomer31.ColorContorno = System.Drawing.Color.Navy;
            this.tsUcCustomer31.FondoControl = System.Drawing.Color.White;
            this.tsUcCustomer31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsUcCustomer31.Location = new System.Drawing.Point(13, 25);
            this.tsUcCustomer31.Name = "tsUcCustomer31";
            this.tsUcCustomer31.Size = new System.Drawing.Size(577, 91);
            this.tsUcCustomer31.TabIndex = 0;
            this.tsUcCustomer31.ClienteModificado += new MASngFE._0TSUserControls.TsUcCustomer3.ClienteModificadoEventHandler(this.tsUcCustomer31_ClienteModificado);
            // 
            // tsUcVendorSelector1
            // 
            this.tsUcVendorSelector1.BackColor = System.Drawing.Color.White;
            this.tsUcVendorSelector1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsUcVendorSelector1.Location = new System.Drawing.Point(13, 157);
            this.tsUcVendorSelector1.Name = "tsUcVendorSelector1";
            this.tsUcVendorSelector1.Size = new System.Drawing.Size(577, 91);
            this.tsUcVendorSelector1.TabIndex = 1;
            this.tsUcVendorSelector1.VendorId = null;
            // 
            // FrmCustomerSearchTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tsUcVendorSelector1);
            this.Controls.Add(this.tsUcCustomer31);
            this.Name = "FrmCustomerSearchTest";
            this.Text = "FrmCustomerSearchTest";
            this.Load += new System.EventHandler(this.FrmCustomerSearchTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private _0TSUserControls.TsUcCustomer3 tsUcCustomer31;
        private _0TSUserControls.TsUcVendorSelector tsUcVendorSelector1;
    }
}