namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI38DetalleImputacionPorDocumento
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dsOpDetalleImputacionPorFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idCtaCteFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdocFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEmisionFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeEmisionFacturaImputadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeImputadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdocImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDocImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCtaCteImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasPromedioPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlTextBox1 = new TSControls.CtlTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOpDetalleImputacionPorFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCtaCteFacturaImputadaDataGridViewTextBoxColumn,
            this.idFacturaImputadaDataGridViewTextBoxColumn,
            this.tdocFacturaImputadaDataGridViewTextBoxColumn,
            this.numeroFacturaImputadaDataGridViewTextBoxColumn,
            this.tCFacturaImputadaDataGridViewTextBoxColumn,
            this.fechaEmisionFacturaImputadaDataGridViewTextBoxColumn,
            this.importeEmisionFacturaImputadaDataGridViewTextBoxColumn,
            this.importeImputadoDataGridViewTextBoxColumn,
            this.fechaImputacionDataGridViewTextBoxColumn,
            this.tdocImputacionDataGridViewTextBoxColumn,
            this.numeroDocImputacionDataGridViewTextBoxColumn,
            this.idCtaCteImputacionDataGridViewTextBoxColumn,
            this.tcImputacionDataGridViewTextBoxColumn,
            this.diasImputacionDataGridViewTextBoxColumn,
            this.diasPromedioPagoDataGridViewTextBoxColumn,
            this.glImputacionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dsOpDetalleImputacionPorFacturaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1271, 261);
            this.dataGridView1.TabIndex = 0;
            // 
            // dsOpDetalleImputacionPorFacturaBindingSource
            // 
            this.dsOpDetalleImputacionPorFacturaBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.DsOpDetalleImputacionPorFactura);
            // 
            // idCtaCteFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.idCtaCteFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "IdCtaCteFacturaImputada";
            this.idCtaCteFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "IdCtaCteFacturaImputada";
            this.idCtaCteFacturaImputadaDataGridViewTextBoxColumn.Name = "idCtaCteFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // idFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.idFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "IdFacturaImputada";
            this.idFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "IdFacturaImputada";
            this.idFacturaImputadaDataGridViewTextBoxColumn.Name = "idFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // tdocFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.tdocFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "TdocFacturaImputada";
            this.tdocFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "TdocFacturaImputada";
            this.tdocFacturaImputadaDataGridViewTextBoxColumn.Name = "tdocFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // numeroFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.numeroFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "NumeroFacturaImputada";
            this.numeroFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "NumeroFacturaImputada";
            this.numeroFacturaImputadaDataGridViewTextBoxColumn.Name = "numeroFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // tCFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.tCFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "TCFacturaImputada";
            this.tCFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "TCFacturaImputada";
            this.tCFacturaImputadaDataGridViewTextBoxColumn.Name = "tCFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // fechaEmisionFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.fechaEmisionFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "FechaEmisionFacturaImputada";
            this.fechaEmisionFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "FechaEmisionFacturaImputada";
            this.fechaEmisionFacturaImputadaDataGridViewTextBoxColumn.Name = "fechaEmisionFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // importeEmisionFacturaImputadaDataGridViewTextBoxColumn
            // 
            this.importeEmisionFacturaImputadaDataGridViewTextBoxColumn.DataPropertyName = "ImporteEmisionFacturaImputada";
            this.importeEmisionFacturaImputadaDataGridViewTextBoxColumn.HeaderText = "ImporteEmisionFacturaImputada";
            this.importeEmisionFacturaImputadaDataGridViewTextBoxColumn.Name = "importeEmisionFacturaImputadaDataGridViewTextBoxColumn";
            // 
            // importeImputadoDataGridViewTextBoxColumn
            // 
            this.importeImputadoDataGridViewTextBoxColumn.DataPropertyName = "ImporteImputado";
            this.importeImputadoDataGridViewTextBoxColumn.HeaderText = "ImporteImputado";
            this.importeImputadoDataGridViewTextBoxColumn.Name = "importeImputadoDataGridViewTextBoxColumn";
            // 
            // fechaImputacionDataGridViewTextBoxColumn
            // 
            this.fechaImputacionDataGridViewTextBoxColumn.DataPropertyName = "FechaImputacion";
            this.fechaImputacionDataGridViewTextBoxColumn.HeaderText = "FechaImputacion";
            this.fechaImputacionDataGridViewTextBoxColumn.Name = "fechaImputacionDataGridViewTextBoxColumn";
            // 
            // tdocImputacionDataGridViewTextBoxColumn
            // 
            this.tdocImputacionDataGridViewTextBoxColumn.DataPropertyName = "TdocImputacion";
            this.tdocImputacionDataGridViewTextBoxColumn.HeaderText = "TdocImputacion";
            this.tdocImputacionDataGridViewTextBoxColumn.Name = "tdocImputacionDataGridViewTextBoxColumn";
            // 
            // numeroDocImputacionDataGridViewTextBoxColumn
            // 
            this.numeroDocImputacionDataGridViewTextBoxColumn.DataPropertyName = "NumeroDocImputacion";
            this.numeroDocImputacionDataGridViewTextBoxColumn.HeaderText = "NumeroDocImputacion";
            this.numeroDocImputacionDataGridViewTextBoxColumn.Name = "numeroDocImputacionDataGridViewTextBoxColumn";
            // 
            // idCtaCteImputacionDataGridViewTextBoxColumn
            // 
            this.idCtaCteImputacionDataGridViewTextBoxColumn.DataPropertyName = "IdCtaCteImputacion";
            this.idCtaCteImputacionDataGridViewTextBoxColumn.HeaderText = "IdCtaCteImputacion";
            this.idCtaCteImputacionDataGridViewTextBoxColumn.Name = "idCtaCteImputacionDataGridViewTextBoxColumn";
            // 
            // tcImputacionDataGridViewTextBoxColumn
            // 
            this.tcImputacionDataGridViewTextBoxColumn.DataPropertyName = "TcImputacion";
            this.tcImputacionDataGridViewTextBoxColumn.HeaderText = "TcImputacion";
            this.tcImputacionDataGridViewTextBoxColumn.Name = "tcImputacionDataGridViewTextBoxColumn";
            // 
            // diasImputacionDataGridViewTextBoxColumn
            // 
            this.diasImputacionDataGridViewTextBoxColumn.DataPropertyName = "DiasImputacion";
            this.diasImputacionDataGridViewTextBoxColumn.HeaderText = "DiasImputacion";
            this.diasImputacionDataGridViewTextBoxColumn.Name = "diasImputacionDataGridViewTextBoxColumn";
            // 
            // diasPromedioPagoDataGridViewTextBoxColumn
            // 
            this.diasPromedioPagoDataGridViewTextBoxColumn.DataPropertyName = "DiasPromedioPago";
            this.diasPromedioPagoDataGridViewTextBoxColumn.HeaderText = "DiasPromedioPago";
            this.diasPromedioPagoDataGridViewTextBoxColumn.Name = "diasPromedioPagoDataGridViewTextBoxColumn";
            // 
            // glImputacionDataGridViewTextBoxColumn
            // 
            this.glImputacionDataGridViewTextBoxColumn.DataPropertyName = "GlImputacion";
            this.glImputacionDataGridViewTextBoxColumn.HeaderText = "GlImputacion";
            this.glImputacionDataGridViewTextBoxColumn.Name = "glImputacionDataGridViewTextBoxColumn";
            // 
            // ctlTextBox1
            // 
            this.ctlTextBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox1.Location = new System.Drawing.Point(109, 13);
            this.ctlTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlTextBox1.Name = "ctlTextBox1";
            this.ctlTextBox1.SeparadorDecimal = false;
            this.ctlTextBox1.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlTextBox1.SetDecimales = 0;
            this.ctlTextBox1.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.ctlTextBox1.Size = new System.Drawing.Size(55, 21);
            this.ctlTextBox1.TabIndex = 1;
            this.ctlTextBox1.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ctlTextBox1.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.ctlTextBox1.XReadOnly = false;
            this.ctlTextBox1.Validated += new System.EventHandler(this.ctlTextBox1_Validated);
            // 
            // FrmFI38DetalleImputacionPorDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 450);
            this.Controls.Add(this.ctlTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmFI38DetalleImputacionPorDocumento";
            this.Text = "FrmFI38DetalleImputacionPorDocumento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOpDetalleImputacionPorFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dsOpDetalleImputacionPorFacturaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdocFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEmisionFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeEmisionFacturaImputadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeImputadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdocImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasPromedioPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glImputacionDataGridViewTextBoxColumn;
        private TSControls.CtlTextBox ctlTextBox1;
    }
}