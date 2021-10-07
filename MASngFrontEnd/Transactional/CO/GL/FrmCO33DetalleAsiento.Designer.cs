namespace MASngFE.Transactional.CO.GL
{
    partial class FrmCO33DetalleAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO33DetalleAsiento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.txtFechaAsiento = new System.Windows.Forms.TextBox();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtNas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionAsiento = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAsientoCancel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAsientoLink = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAsientoCheck = new System.Windows.Forms.TextBox();
            this.txtUserLog = new System.Windows.Forms.TextBox();
            this.txtAsientoStatus = new System.Windows.Forms.TextBox();
            this.txtFechaLog = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNasX1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.t0602DOCUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnDetalleAsiento = new System.Windows.Forms.Button();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.iDSEGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEGTEXTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCUTIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEBEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hABERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEFEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLIPROVDESCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEGTEXT2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGMATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0602DOCUSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1023, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 80;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtTC);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtLx);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtReferencia);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtTipoDoc);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtDescripcionAsiento);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtPeriodo);
            this.panel3.Controls.Add(this.txtFechaAsiento);
            this.panel3.Controls.Add(this.txtMoneda);
            this.panel3.Controls.Add(this.txtNas);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 108);
            this.panel3.TabIndex = 83;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(379, 30);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(56, 22);
            this.txtPeriodo.TabIndex = 53;
            // 
            // txtFechaAsiento
            // 
            this.txtFechaAsiento.Location = new System.Drawing.Point(92, 30);
            this.txtFechaAsiento.Name = "txtFechaAsiento";
            this.txtFechaAsiento.ReadOnly = true;
            this.txtFechaAsiento.Size = new System.Drawing.Size(125, 22);
            this.txtFechaAsiento.TabIndex = 52;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(379, 6);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(37, 22);
            this.txtMoneda.TabIndex = 51;
            this.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNas
            // 
            this.txtNas.Location = new System.Drawing.Point(92, 6);
            this.txtNas.Name = "txtNas";
            this.txtNas.ReadOnly = true;
            this.txtNas.Size = new System.Drawing.Size(52, 22);
            this.txtNas.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 49;
            this.label6.Text = "Fecha Asiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 14);
            this.label7.TabIndex = 47;
            this.label7.Text = "Moneda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 14);
            this.label8.TabIndex = 43;
            this.label8.Text = "Asiento #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 54;
            this.label1.Text = "Periodo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 55;
            this.label2.Text = "Descripcion";
            // 
            // txtDescripcionAsiento
            // 
            this.txtDescripcionAsiento.Location = new System.Drawing.Point(92, 54);
            this.txtDescripcionAsiento.Name = "txtDescripcionAsiento";
            this.txtDescripcionAsiento.ReadOnly = true;
            this.txtDescripcionAsiento.Size = new System.Drawing.Size(343, 22);
            this.txtDescripcionAsiento.TabIndex = 56;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(92, 78);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(33, 22);
            this.txtTipoDoc.TabIndex = 58;
            this.txtTipoDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 57;
            this.label3.Text = "Tipo Doc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 59;
            this.label4.Text = "Referencia #";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(339, 78);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.ReadOnly = true;
            this.txtReferencia.Size = new System.Drawing.Size(96, 22);
            this.txtReferencia.TabIndex = 60;
            // 
            // txtLx
            // 
            this.txtLx.Location = new System.Drawing.Point(185, 6);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(32, 22);
            this.txtLx.TabIndex = 62;
            this.txtLx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 14);
            this.label5.TabIndex = 61;
            this.label5.Text = "LX";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtNasX1);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtAsientoCancel);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtAsientoCheck);
            this.panel1.Controls.Add(this.txtUserLog);
            this.panel1.Controls.Add(this.txtAsientoStatus);
            this.panel1.Controls.Add(this.txtAsientoLink);
            this.panel1.Controls.Add(this.txtFechaLog);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(451, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 108);
            this.panel1.TabIndex = 84;
            // 
            // txtAsientoCancel
            // 
            this.txtAsientoCancel.Location = new System.Drawing.Point(388, 54);
            this.txtAsientoCancel.Name = "txtAsientoCancel";
            this.txtAsientoCancel.ReadOnly = true;
            this.txtAsientoCancel.Size = new System.Drawing.Size(48, 22);
            this.txtAsientoCancel.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 14);
            this.label10.TabIndex = 59;
            this.label10.Text = "Asiento Cancel";
            // 
            // txtAsientoLink
            // 
            this.txtAsientoLink.Location = new System.Drawing.Point(110, 54);
            this.txtAsientoLink.Name = "txtAsientoLink";
            this.txtAsientoLink.ReadOnly = true;
            this.txtAsientoLink.Size = new System.Drawing.Size(76, 22);
            this.txtAsientoLink.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 14);
            this.label11.TabIndex = 57;
            this.label11.Text = "Asiento LINK";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(3, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(890, 3);
            this.label12.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 14);
            this.label13.TabIndex = 54;
            this.label13.Text = "Check";
            // 
            // txtAsientoCheck
            // 
            this.txtAsientoCheck.Location = new System.Drawing.Point(388, 30);
            this.txtAsientoCheck.Name = "txtAsientoCheck";
            this.txtAsientoCheck.ReadOnly = true;
            this.txtAsientoCheck.Size = new System.Drawing.Size(48, 22);
            this.txtAsientoCheck.TabIndex = 53;
            // 
            // txtUserLog
            // 
            this.txtUserLog.Location = new System.Drawing.Point(110, 30);
            this.txtUserLog.Name = "txtUserLog";
            this.txtUserLog.ReadOnly = true;
            this.txtUserLog.Size = new System.Drawing.Size(119, 22);
            this.txtUserLog.TabIndex = 52;
            // 
            // txtAsientoStatus
            // 
            this.txtAsientoStatus.Location = new System.Drawing.Point(388, 6);
            this.txtAsientoStatus.Name = "txtAsientoStatus";
            this.txtAsientoStatus.ReadOnly = true;
            this.txtAsientoStatus.Size = new System.Drawing.Size(28, 22);
            this.txtAsientoStatus.TabIndex = 51;
            // 
            // txtFechaLog
            // 
            this.txtFechaLog.Location = new System.Drawing.Point(110, 6);
            this.txtFechaLog.Name = "txtFechaLog";
            this.txtFechaLog.ReadOnly = true;
            this.txtFechaLog.Size = new System.Drawing.Size(195, 22);
            this.txtFechaLog.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 14);
            this.label14.TabIndex = 49;
            this.label14.Text = "Usuario Registro";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(341, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 14);
            this.label15.TabIndex = 47;
            this.label15.Text = "Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 14);
            this.label16.TabIndex = 43;
            this.label16.Text = "Fecha Registro";
            // 
            // txtNasX1
            // 
            this.txtNasX1.Location = new System.Drawing.Point(110, 78);
            this.txtNasX1.Name = "txtNasX1";
            this.txtNasX1.ReadOnly = true;
            this.txtNasX1.Size = new System.Drawing.Size(76, 22);
            this.txtNasX1.TabIndex = 62;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 14);
            this.label17.TabIndex = 61;
            this.label17.Text = "Asiento Xtend #";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(388, 78);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(48, 22);
            this.txtOrigen.TabIndex = 64;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(339, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 14);
            this.label18.TabIndex = 63;
            this.label18.Text = "Origen";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDSEGDataGridViewTextBoxColumn,
            this.sEGTEXTDataGridViewTextBoxColumn,
            this.dOCUTIPODataGridViewTextBoxColumn,
            this.gLDataGridViewTextBoxColumn,
            this.dEBEDataGridViewTextBoxColumn,
            this.hABERDataGridViewTextBoxColumn,
            this.rEFEDataGridViewTextBoxColumn,
            this.cLIPROVDESCDataGridViewTextBoxColumn,
            this.sEGTEXT2DataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.tCODEDataGridViewTextBoxColumn,
            this.kGMATDataGridViewTextBoxColumn,
            this.mATERIALDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.t0602DOCUSBindingSource;
            this.dgvData.Location = new System.Drawing.Point(6, 119);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.Size = new System.Drawing.Size(1117, 305);
            this.dgvData.TabIndex = 85;
            // 
            // t0602DOCUSBindingSource
            // 
            this.t0602DOCUSBindingSource.DataSource = typeof(TecserEF.Entity.T0602_DOCU_S);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(3, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1120, 3);
            this.label9.TabIndex = 86;
            // 
            // btnDetalleAsiento
            // 
            this.btnDetalleAsiento.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleAsiento.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleAsiento.Image")));
            this.btnDetalleAsiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleAsiento.Location = new System.Drawing.Point(1023, 48);
            this.btnDetalleAsiento.Name = "btnDetalleAsiento";
            this.btnDetalleAsiento.Size = new System.Drawing.Size(100, 44);
            this.btnDetalleAsiento.TabIndex = 79;
            this.btnDetalleAsiento.Text = "Detalle\r\nAsiento";
            this.btnDetalleAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleAsiento.UseVisualStyleBackColor = true;
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(265, 30);
            this.txtTC.Name = "txtTC";
            this.txtTC.ReadOnly = true;
            this.txtTC.Size = new System.Drawing.Size(52, 22);
            this.txtTC.TabIndex = 64;
            this.txtTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(225, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 14);
            this.label19.TabIndex = 63;
            this.label19.Text = "T/C";
            // 
            // iDSEGDataGridViewTextBoxColumn
            // 
            this.iDSEGDataGridViewTextBoxColumn.DataPropertyName = "IDSEG";
            this.iDSEGDataGridViewTextBoxColumn.HeaderText = "#";
            this.iDSEGDataGridViewTextBoxColumn.Name = "iDSEGDataGridViewTextBoxColumn";
            this.iDSEGDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDSEGDataGridViewTextBoxColumn.Width = 20;
            // 
            // sEGTEXTDataGridViewTextBoxColumn
            // 
            this.sEGTEXTDataGridViewTextBoxColumn.DataPropertyName = "SEGTEXT";
            this.sEGTEXTDataGridViewTextBoxColumn.HeaderText = "Texto #1";
            this.sEGTEXTDataGridViewTextBoxColumn.Name = "sEGTEXTDataGridViewTextBoxColumn";
            this.sEGTEXTDataGridViewTextBoxColumn.ReadOnly = true;
            this.sEGTEXTDataGridViewTextBoxColumn.Width = 190;
            // 
            // dOCUTIPODataGridViewTextBoxColumn
            // 
            this.dOCUTIPODataGridViewTextBoxColumn.DataPropertyName = "DOCUTIPO";
            this.dOCUTIPODataGridViewTextBoxColumn.HeaderText = "Docu";
            this.dOCUTIPODataGridViewTextBoxColumn.Name = "dOCUTIPODataGridViewTextBoxColumn";
            this.dOCUTIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.dOCUTIPODataGridViewTextBoxColumn.Width = 50;
            // 
            // gLDataGridViewTextBoxColumn
            // 
            this.gLDataGridViewTextBoxColumn.DataPropertyName = "GL";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gLDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.gLDataGridViewTextBoxColumn.HeaderText = "GL";
            this.gLDataGridViewTextBoxColumn.Name = "gLDataGridViewTextBoxColumn";
            this.gLDataGridViewTextBoxColumn.ReadOnly = true;
            this.gLDataGridViewTextBoxColumn.Width = 70;
            // 
            // dEBEDataGridViewTextBoxColumn
            // 
            this.dEBEDataGridViewTextBoxColumn.DataPropertyName = "DEBE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Format = "C2";
            this.dEBEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dEBEDataGridViewTextBoxColumn.HeaderText = "Debe";
            this.dEBEDataGridViewTextBoxColumn.Name = "dEBEDataGridViewTextBoxColumn";
            this.dEBEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEBEDataGridViewTextBoxColumn.Width = 70;
            // 
            // hABERDataGridViewTextBoxColumn
            // 
            this.hABERDataGridViewTextBoxColumn.DataPropertyName = "HABER";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            this.hABERDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.hABERDataGridViewTextBoxColumn.HeaderText = "Haber";
            this.hABERDataGridViewTextBoxColumn.Name = "hABERDataGridViewTextBoxColumn";
            this.hABERDataGridViewTextBoxColumn.ReadOnly = true;
            this.hABERDataGridViewTextBoxColumn.Width = 70;
            // 
            // rEFEDataGridViewTextBoxColumn
            // 
            this.rEFEDataGridViewTextBoxColumn.DataPropertyName = "REFE";
            this.rEFEDataGridViewTextBoxColumn.HeaderText = "Doc #";
            this.rEFEDataGridViewTextBoxColumn.Name = "rEFEDataGridViewTextBoxColumn";
            this.rEFEDataGridViewTextBoxColumn.ReadOnly = true;
            this.rEFEDataGridViewTextBoxColumn.Width = 90;
            // 
            // cLIPROVDESCDataGridViewTextBoxColumn
            // 
            this.cLIPROVDESCDataGridViewTextBoxColumn.DataPropertyName = "CLIPROV_DESC";
            this.cLIPROVDESCDataGridViewTextBoxColumn.HeaderText = "Entidad";
            this.cLIPROVDESCDataGridViewTextBoxColumn.Name = "cLIPROVDESCDataGridViewTextBoxColumn";
            this.cLIPROVDESCDataGridViewTextBoxColumn.ReadOnly = true;
            this.cLIPROVDESCDataGridViewTextBoxColumn.Width = 130;
            // 
            // sEGTEXT2DataGridViewTextBoxColumn
            // 
            this.sEGTEXT2DataGridViewTextBoxColumn.DataPropertyName = "SEGTEXT2";
            this.sEGTEXT2DataGridViewTextBoxColumn.HeaderText = "Texto #2";
            this.sEGTEXT2DataGridViewTextBoxColumn.Name = "sEGTEXT2DataGridViewTextBoxColumn";
            this.sEGTEXT2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sEGTEXT2DataGridViewTextBoxColumn.Width = 150;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // tCODEDataGridViewTextBoxColumn
            // 
            this.tCODEDataGridViewTextBoxColumn.DataPropertyName = "TCODE";
            this.tCODEDataGridViewTextBoxColumn.HeaderText = "Tcode";
            this.tCODEDataGridViewTextBoxColumn.Name = "tCODEDataGridViewTextBoxColumn";
            this.tCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCODEDataGridViewTextBoxColumn.Width = 60;
            // 
            // kGMATDataGridViewTextBoxColumn
            // 
            this.kGMATDataGridViewTextBoxColumn.DataPropertyName = "KGMAT";
            this.kGMATDataGridViewTextBoxColumn.HeaderText = "Kg";
            this.kGMATDataGridViewTextBoxColumn.Name = "kGMATDataGridViewTextBoxColumn";
            this.kGMATDataGridViewTextBoxColumn.ReadOnly = true;
            this.kGMATDataGridViewTextBoxColumn.Width = 50;
            // 
            // mATERIALDataGridViewTextBoxColumn
            // 
            this.mATERIALDataGridViewTextBoxColumn.DataPropertyName = "MATERIAL";
            this.mATERIALDataGridViewTextBoxColumn.HeaderText = "Material";
            this.mATERIALDataGridViewTextBoxColumn.Name = "mATERIALDataGridViewTextBoxColumn";
            this.mATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            this.mATERIALDataGridViewTextBoxColumn.Width = 80;
            // 
            // FrmCO33DetalleAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 640);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnDetalleAsiento);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmCO33DetalleAsiento";
            this.Text = "CO33 - Detalle de Asiento Contable";
            this.Load += new System.EventHandler(this.FrmCO33DetalleAsiento_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0602DOCUSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcionAsiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.TextBox txtFechaAsiento;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtNas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNasX1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAsientoCancel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAsientoCheck;
        private System.Windows.Forms.TextBox txtUserLog;
        private System.Windows.Forms.TextBox txtAsientoStatus;
        private System.Windows.Forms.TextBox txtAsientoLink;
        private System.Windows.Forms.TextBox txtFechaLog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource t0602DOCUSBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDetalleAsiento;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSEGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEGTEXTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCUTIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEBEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hABERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEFEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLIPROVDESCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEGTEXT2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGMATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATERIALDataGridViewTextBoxColumn;
    }
}