﻿namespace MASngFE.Reports.ReportManager
{
    partial class RvpOrdenPagoPrint
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
            this.T0210_OrdenPagoHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.T0005_MPROVEEDORESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.T0210_OrdenPagoHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005_MPROVEEDORESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OpHeader";
            reportDataSource1.Value = this.T0210_OrdenPagoHeaderBindingSource;
            reportDataSource2.Name = "VendorData";
            reportDataSource2.Value = this.T0005_MPROVEEDORESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MASngFE.Reports.ReportDesign.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // T0210_OrdenPagoHeaderBindingSource
            // 
            this.T0210_OrdenPagoHeaderBindingSource.DataSource = typeof(TecserEF.Entity.T0210_OrdenPagoHeader);
            // 
            // T0005_MPROVEEDORESBindingSource
            // 
            this.T0005_MPROVEEDORESBindingSource.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // RvpOrdenPagoPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RvpOrdenPagoPrint";
            this.Text = "RV30 - IMPRESION DE ORDEN DE PAGO";
            this.Load += new System.EventHandler(this.RvpOrdenPagoPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0210_OrdenPagoHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005_MPROVEEDORESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource T0210_OrdenPagoHeaderBindingSource;
        private System.Windows.Forms.BindingSource T0005_MPROVEEDORESBindingSource;
    }
}