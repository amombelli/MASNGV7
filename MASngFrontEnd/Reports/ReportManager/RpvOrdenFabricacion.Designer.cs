namespace MASngFE.Reports.ReportManager
{
    partial class RpvOrdenFabricacion
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
            this.GetOrdenFabricacionReportDataSource_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GetOrdenFabricacionReportDataSource_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GetOrdenFabricacionReportDataSource_ResultBindingSource
            // 
            this.GetOrdenFabricacionReportDataSource_ResultBindingSource.DataSource = typeof(TecserEF.Entity.GetOrdenFabricacionReportDataSource_Result);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MASngFE.Reports.ReportDesign.RptOrdenFabricacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(789, 460);
            this.reportViewer1.TabIndex = 0;
            // 
            // RpvOrdenFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 460);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RpvOrdenFabricacion";
            this.Text = "RpvOrdenFabricacion";
            this.Load += new System.EventHandler(this.RpvOrdenFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetOrdenFabricacionReportDataSource_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource GetOrdenFabricacionReportDataSource_ResultBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}