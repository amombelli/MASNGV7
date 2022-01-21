namespace MASngFE.Reports.ReportManager
{
    partial class RpvBOM
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.T0020_FORMULA_HBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.T0021_FORMULA_IBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.T0020_FORMULA_HBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0021_FORMULA_IBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsBomHeader";
            reportDataSource1.Value = this.T0020_FORMULA_HBindingSource;
            reportDataSource2.Name = "dsBomItem";
            reportDataSource2.Value = this.T0021_FORMULA_IBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MASngFE.Reports.ReportDesign.GenericBOM.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(849, 509);
            this.reportViewer1.TabIndex = 0;
            // 
            // T0020_FORMULA_HBindingSource
            // 
            this.T0020_FORMULA_HBindingSource.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // T0021_FORMULA_IBindingSource
            // 
            this.T0021_FORMULA_IBindingSource.DataSource = typeof(TecserEF.Entity.T0021_FORMULA_I);
            // 
            // RpvBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 509);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RpvBOM";
            this.Text = "RpvBOM";
            this.Load += new System.EventHandler(this.RpvBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0020_FORMULA_HBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0021_FORMULA_IBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource T0020_FORMULA_HBindingSource;
        private System.Windows.Forms.BindingSource T0021_FORMULA_IBindingSource;
    }
}