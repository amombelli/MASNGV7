namespace MASngFE.Transactional.CRM
{
    partial class FrmCRM05GescoPagosListos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCRM05GescoPagosListos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReportePL = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dsGescoPagoListoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idRecordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeCobradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasHorariosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobradorAsignadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retiroProgramadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoCanceladoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaModificadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRecordPagoListoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRecordLastUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asigna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGescoPagoListoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReportePL
            // 
            this.btnReportePL.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePL.Image = ((System.Drawing.Image)(resources.GetObject("btnReportePL.Image")));
            this.btnReportePL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportePL.Location = new System.Drawing.Point(1104, 4);
            this.btnReportePL.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportePL.Name = "btnReportePL";
            this.btnReportePL.Size = new System.Drawing.Size(107, 40);
            this.btnReportePL.TabIndex = 161;
            this.btnReportePL.Text = "Pago\r\nListo";
            this.btnReportePL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportePL.UseVisualStyleBackColor = true;
            this.btnReportePL.Click += new System.EventHandler(this.btnReportePL_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(996, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 40);
            this.btnClose.TabIndex = 160;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.txtFantasia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 58);
            this.panel1.TabIndex = 162;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRazonSocial.Location = new System.Drawing.Point(106, 5);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(236, 22);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.TabStop = false;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFantasia.Location = new System.Drawing.Point(106, 29);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(236, 22);
            this.txtFantasia.TabIndex = 19;
            this.txtFantasia.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fantasia";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdCliente.Location = new System.Drawing.Point(345, 5);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(58, 22);
            this.txtIdCliente.TabIndex = 3;
            this.txtIdCliente.TabStop = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRecordDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.fechaPagoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.direccion2DataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.mensajeCobradorDataGridViewTextBoxColumn,
            this.diasHorariosDataGridViewTextBoxColumn,
            this.cobradorAsignadoDataGridViewTextBoxColumn,
            this.retiroProgramadoDataGridViewTextBoxColumn,
            this.pagoCanceladoDataGridViewCheckBoxColumn,
            this.fechaModificadaDataGridViewTextBoxColumn,
            this.idRecordPagoListoDataGridViewTextBoxColumn,
            this.idRecordLastUpdateDataGridViewTextBoxColumn,
            this.Asigna});
            this.dgv.DataSource = this.dsGescoPagoListoBindingSource;
            this.dgv.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgv.Location = new System.Drawing.Point(3, 66);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(1208, 541);
            this.dgv.TabIndex = 163;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // dsGescoPagoListoBindingSource
            // 
            this.dsGescoPagoListoBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.DsGescoPagoListo);
            // 
            // idRecordDataGridViewTextBoxColumn
            // 
            this.idRecordDataGridViewTextBoxColumn.DataPropertyName = "idRecord";
            this.idRecordDataGridViewTextBoxColumn.HeaderText = "#";
            this.idRecordDataGridViewTextBoxColumn.Name = "idRecordDataGridViewTextBoxColumn";
            this.idRecordDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRecordDataGridViewTextBoxColumn.Visible = false;
            this.idRecordDataGridViewTextBoxColumn.Width = 30;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // fechaPagoDataGridViewTextBoxColumn
            // 
            this.fechaPagoDataGridViewTextBoxColumn.DataPropertyName = "FechaPago";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaPagoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaPagoDataGridViewTextBoxColumn.HeaderText = "FechaPago";
            this.fechaPagoDataGridViewTextBoxColumn.Name = "fechaPagoDataGridViewTextBoxColumn";
            this.fechaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaPagoDataGridViewTextBoxColumn.Width = 80;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion Retiro Pago";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionDataGridViewTextBoxColumn.Width = 180;
            // 
            // direccion2DataGridViewTextBoxColumn
            // 
            this.direccion2DataGridViewTextBoxColumn.DataPropertyName = "Direccion2";
            this.direccion2DataGridViewTextBoxColumn.HeaderText = "Adic.";
            this.direccion2DataGridViewTextBoxColumn.Name = "direccion2DataGridViewTextBoxColumn";
            this.direccion2DataGridViewTextBoxColumn.ReadOnly = true;
            this.direccion2DataGridViewTextBoxColumn.ToolTipText = "Texto direccion adicional";
            this.direccion2DataGridViewTextBoxColumn.Width = 50;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Width = 60;
            // 
            // mensajeCobradorDataGridViewTextBoxColumn
            // 
            this.mensajeCobradorDataGridViewTextBoxColumn.DataPropertyName = "MensajeCobrador";
            this.mensajeCobradorDataGridViewTextBoxColumn.HeaderText = "Mensaje Cobrador";
            this.mensajeCobradorDataGridViewTextBoxColumn.Name = "mensajeCobradorDataGridViewTextBoxColumn";
            this.mensajeCobradorDataGridViewTextBoxColumn.ReadOnly = true;
            this.mensajeCobradorDataGridViewTextBoxColumn.Width = 180;
            // 
            // diasHorariosDataGridViewTextBoxColumn
            // 
            this.diasHorariosDataGridViewTextBoxColumn.DataPropertyName = "DiasHorarios";
            this.diasHorariosDataGridViewTextBoxColumn.HeaderText = "DiasHorarios";
            this.diasHorariosDataGridViewTextBoxColumn.Name = "diasHorariosDataGridViewTextBoxColumn";
            this.diasHorariosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cobradorAsignadoDataGridViewTextBoxColumn
            // 
            this.cobradorAsignadoDataGridViewTextBoxColumn.DataPropertyName = "CobradorAsignado";
            this.cobradorAsignadoDataGridViewTextBoxColumn.HeaderText = "Cobrador";
            this.cobradorAsignadoDataGridViewTextBoxColumn.Name = "cobradorAsignadoDataGridViewTextBoxColumn";
            this.cobradorAsignadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cobradorAsignadoDataGridViewTextBoxColumn.Width = 70;
            // 
            // retiroProgramadoDataGridViewTextBoxColumn
            // 
            this.retiroProgramadoDataGridViewTextBoxColumn.DataPropertyName = "RetiroProgramado";
            this.retiroProgramadoDataGridViewTextBoxColumn.HeaderText = "RP";
            this.retiroProgramadoDataGridViewTextBoxColumn.Name = "retiroProgramadoDataGridViewTextBoxColumn";
            this.retiroProgramadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.retiroProgramadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // pagoCanceladoDataGridViewCheckBoxColumn
            // 
            this.pagoCanceladoDataGridViewCheckBoxColumn.DataPropertyName = "PagoCancelado";
            this.pagoCanceladoDataGridViewCheckBoxColumn.HeaderText = "PC";
            this.pagoCanceladoDataGridViewCheckBoxColumn.Name = "pagoCanceladoDataGridViewCheckBoxColumn";
            this.pagoCanceladoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.pagoCanceladoDataGridViewCheckBoxColumn.ToolTipText = "Pago Cancelado";
            this.pagoCanceladoDataGridViewCheckBoxColumn.Width = 30;
            // 
            // fechaModificadaDataGridViewTextBoxColumn
            // 
            this.fechaModificadaDataGridViewTextBoxColumn.DataPropertyName = "FechaModificada";
            this.fechaModificadaDataGridViewTextBoxColumn.HeaderText = "FechaModificada";
            this.fechaModificadaDataGridViewTextBoxColumn.Name = "fechaModificadaDataGridViewTextBoxColumn";
            this.fechaModificadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idRecordPagoListoDataGridViewTextBoxColumn
            // 
            this.idRecordPagoListoDataGridViewTextBoxColumn.DataPropertyName = "IdRecordPagoListo";
            this.idRecordPagoListoDataGridViewTextBoxColumn.HeaderText = "IdRecordPagoListo";
            this.idRecordPagoListoDataGridViewTextBoxColumn.Name = "idRecordPagoListoDataGridViewTextBoxColumn";
            this.idRecordPagoListoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRecordPagoListoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idRecordLastUpdateDataGridViewTextBoxColumn
            // 
            this.idRecordLastUpdateDataGridViewTextBoxColumn.DataPropertyName = "IdRecordLastUpdate";
            this.idRecordLastUpdateDataGridViewTextBoxColumn.HeaderText = "IdRecordLastUpdate";
            this.idRecordLastUpdateDataGridViewTextBoxColumn.Name = "idRecordLastUpdateDataGridViewTextBoxColumn";
            this.idRecordLastUpdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRecordLastUpdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // Asigna
            // 
            this.Asigna.HeaderText = "Asigna";
            this.Asigna.Name = "Asigna";
            this.Asigna.ReadOnly = true;
            this.Asigna.Text = "ASSIG";
            this.Asigna.ToolTipText = "Asigna Cobrador - Visualizar Detalle";
            this.Asigna.UseColumnTextForButtonValue = true;
            this.Asigna.Width = 50;
            // 
            // FrmCRM05GescoDetallePagoListo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 635);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReportePL);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmCRM05GescoDetallePagoListo";
            this.Text = "CRM05  - Detalle de Pago Listo";
            this.Load += new System.EventHandler(this.FrmCRM05GescoDetallePagoListo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGescoPagoListoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportePL;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dsGescoPagoListoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRecordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeCobradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasHorariosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobradorAsignadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retiroProgramadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pagoCanceladoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRecordPagoListoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRecordLastUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Asigna;
    }
}