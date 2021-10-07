namespace MASngFE.Forms
{
    partial class FrmMdc01CustomerSearchL1
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
            this.getOrdenFabricacionReportDataSourceTableAdapter1 = new MASng.Reports.ReportDataSource.dsOrdenFabricacionTableAdapters.GetOrdenFabricacionReportDataSourceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uDataGridView1
            // 
            this.uDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uDataGridView1_CellContentClick);
            // 
            // getOrdenFabricacionReportDataSourceTableAdapter1
            // 
            this.getOrdenFabricacionReportDataSourceTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmMdc01CustomerSearchL1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 581);
            this.Name = "FrmMdc01CustomerSearchL1";
            this.Text = "MDC01 Busqueda de Cliente Base";
            this.Load += new System.EventHandler(this.FrmCustomerSearchL1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MASng.Reports.ReportDataSource.dsOrdenFabricacionTableAdapters.GetOrdenFabricacionReportDataSourceTableAdapter getOrdenFabricacionReportDataSourceTableAdapter1;
    }
}