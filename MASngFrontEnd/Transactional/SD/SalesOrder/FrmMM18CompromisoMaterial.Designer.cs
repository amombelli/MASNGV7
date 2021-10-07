namespace MASngFE.Transactional.SD.SalesOrder
{
    partial class FrmMM18CompromisoMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMM18CompromisoMaterial));
            this.btnComprometer = new System.Windows.Forms.Button();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.dgvListaMateriales = new System.Windows.Forms.DataGridView();
            this.iDStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oVReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLTNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservaOFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSalesOrderNumber = new System.Windows.Forms.TextBox();
            this.ckOnlyAvailable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKgComprometer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKgSolicitiados = new System.Windows.Forms.TextBox();
            this.btnLiberarCompromiso = new System.Windows.Forms.Button();
            this.panInfoMaterial = new System.Windows.Forms.Panel();
            this.txtCodigoPrimario = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panInfoMaterial.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnComprometer
            // 
            this.btnComprometer.Image = ((System.Drawing.Image)(resources.GetObject("btnComprometer.Image")));
            this.btnComprometer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprometer.Location = new System.Drawing.Point(207, 5);
            this.btnComprometer.Name = "btnComprometer";
            this.btnComprometer.Size = new System.Drawing.Size(107, 42);
            this.btnComprometer.TabIndex = 0;
            this.btnComprometer.Text = "Reservar\r\nMaterial";
            this.btnComprometer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComprometer.UseVisualStyleBackColor = true;
            this.btnComprometer.Click += new System.EventHandler(this.btnComprometer_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaterial.Location = new System.Drawing.Point(115, 3);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(159, 22);
            this.txtMaterial.TabIndex = 1;
            // 
            // dgvListaMateriales
            // 
            this.dgvListaMateriales.AllowUserToAddRows = false;
            this.dgvListaMateriales.AllowUserToDeleteRows = false;
            this.dgvListaMateriales.AutoGenerateColumns = false;
            this.dgvListaMateriales.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvListaMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMateriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDStockDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.oVReservaDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.pLTNDataGridViewTextBoxColumn,
            this.reservaOFDataGridViewTextBoxColumn});
            this.dgvListaMateriales.DataSource = this.t0030STOCKBindingSource;
            this.dgvListaMateriales.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dgvListaMateriales.Location = new System.Drawing.Point(10, 64);
            this.dgvListaMateriales.Name = "dgvListaMateriales";
            this.dgvListaMateriales.ReadOnly = true;
            this.dgvListaMateriales.RowHeadersWidth = 30;
            this.dgvListaMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaMateriales.Size = new System.Drawing.Size(733, 266);
            this.dgvListaMateriales.TabIndex = 3;
            this.dgvListaMateriales.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaMateriales_CellEnter);
            // 
            // iDStockDataGridViewTextBoxColumn
            // 
            this.iDStockDataGridViewTextBoxColumn.DataPropertyName = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.HeaderText = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.Name = "iDStockDataGridViewTextBoxColumn";
            this.iDStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDStockDataGridViewTextBoxColumn.Width = 60;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "KG";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Width = 60;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oVReservaDataGridViewTextBoxColumn
            // 
            this.oVReservaDataGridViewTextBoxColumn.DataPropertyName = "OV_Reserva";
            this.oVReservaDataGridViewTextBoxColumn.HeaderText = "ReservaSO";
            this.oVReservaDataGridViewTextBoxColumn.Name = "oVReservaDataGridViewTextBoxColumn";
            this.oVReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.oVReservaDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 50;
            // 
            // pLTNDataGridViewTextBoxColumn
            // 
            this.pLTNDataGridViewTextBoxColumn.DataPropertyName = "PLTN";
            this.pLTNDataGridViewTextBoxColumn.HeaderText = "PLTN";
            this.pLTNDataGridViewTextBoxColumn.Name = "pLTNDataGridViewTextBoxColumn";
            this.pLTNDataGridViewTextBoxColumn.ReadOnly = true;
            this.pLTNDataGridViewTextBoxColumn.Width = 50;
            // 
            // reservaOFDataGridViewTextBoxColumn
            // 
            this.reservaOFDataGridViewTextBoxColumn.DataPropertyName = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.HeaderText = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.Name = "reservaOFDataGridViewTextBoxColumn";
            this.reservaOFDataGridViewTextBoxColumn.ReadOnly = true;
            this.reservaOFDataGridViewTextBoxColumn.Width = 80;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // txtSalesOrderNumber
            // 
            this.txtSalesOrderNumber.Location = new System.Drawing.Point(115, 27);
            this.txtSalesOrderNumber.Name = "txtSalesOrderNumber";
            this.txtSalesOrderNumber.ReadOnly = true;
            this.txtSalesOrderNumber.Size = new System.Drawing.Size(83, 22);
            this.txtSalesOrderNumber.TabIndex = 5;
            // 
            // ckOnlyAvailable
            // 
            this.ckOnlyAvailable.AutoSize = true;
            this.ckOnlyAvailable.ForeColor = System.Drawing.Color.MediumBlue;
            this.ckOnlyAvailable.Location = new System.Drawing.Point(311, 5);
            this.ckOnlyAvailable.Name = "ckOnlyAvailable";
            this.ckOnlyAvailable.Size = new System.Drawing.Size(284, 18);
            this.ckOnlyAvailable.TabIndex = 7;
            this.ckOnlyAvailable.Text = "Ver UNICAMENTE Stock Disponible para Reserva";
            this.ckOnlyAvailable.UseVisualStyleBackColor = true;
            this.ckOnlyAvailable.CheckedChanged += new System.EventHandler(this.ckOnlyAvailable_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "KG a Comprometer";
            // 
            // txtKgComprometer
            // 
            this.txtKgComprometer.Location = new System.Drawing.Point(122, 27);
            this.txtKgComprometer.Name = "txtKgComprometer";
            this.txtKgComprometer.Size = new System.Drawing.Size(83, 22);
            this.txtKgComprometer.TabIndex = 10;
            this.txtKgComprometer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgComprometer_KeyPress);
            this.txtKgComprometer.Leave += new System.EventHandler(this.txtKgComprometer_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "KG Requeridos ";
            // 
            // txtKgSolicitiados
            // 
            this.txtKgSolicitiados.Location = new System.Drawing.Point(122, 4);
            this.txtKgSolicitiados.Name = "txtKgSolicitiados";
            this.txtKgSolicitiados.ReadOnly = true;
            this.txtKgSolicitiados.Size = new System.Drawing.Size(83, 22);
            this.txtKgSolicitiados.TabIndex = 8;
            // 
            // btnLiberarCompromiso
            // 
            this.btnLiberarCompromiso.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnLiberarCompromiso.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberarCompromiso.Image")));
            this.btnLiberarCompromiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiberarCompromiso.Location = new System.Drawing.Point(320, 5);
            this.btnLiberarCompromiso.Name = "btnLiberarCompromiso";
            this.btnLiberarCompromiso.Size = new System.Drawing.Size(107, 42);
            this.btnLiberarCompromiso.TabIndex = 12;
            this.btnLiberarCompromiso.Text = "Liberar\r\n Reserva";
            this.btnLiberarCompromiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberarCompromiso.UseVisualStyleBackColor = true;
            this.btnLiberarCompromiso.Click += new System.EventHandler(this.btnLiberarCompromiso_Click);
            // 
            // panInfoMaterial
            // 
            this.panInfoMaterial.BackColor = System.Drawing.Color.Gainsboro;
            this.panInfoMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panInfoMaterial.Controls.Add(this.txtCodigoPrimario);
            this.panInfoMaterial.Controls.Add(this.label24);
            this.panInfoMaterial.Controls.Add(this.label5);
            this.panInfoMaterial.Controls.Add(this.label13);
            this.panInfoMaterial.Controls.Add(this.txtMaterial);
            this.panInfoMaterial.Controls.Add(this.txtSalesOrderNumber);
            this.panInfoMaterial.Controls.Add(this.ckOnlyAvailable);
            this.panInfoMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panInfoMaterial.Location = new System.Drawing.Point(10, 8);
            this.panInfoMaterial.Name = "panInfoMaterial";
            this.panInfoMaterial.Size = new System.Drawing.Size(733, 54);
            this.panInfoMaterial.TabIndex = 13;
            // 
            // txtCodigoPrimario
            // 
            this.txtCodigoPrimario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoPrimario.Location = new System.Drawing.Point(249, 27);
            this.txtCodigoPrimario.Name = "txtCodigoPrimario";
            this.txtCodigoPrimario.ReadOnly = true;
            this.txtCodigoPrimario.Size = new System.Drawing.Size(25, 22);
            this.txtCodigoPrimario.TabIndex = 128;
            this.txtCodigoPrimario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(204, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 15);
            this.label24.TabIndex = 127;
            this.label24.Text = "Item #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Material Reserva";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(30, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 123;
            this.label13.Text = "Sales Order #";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.MediumBlue;
            this.label26.Location = new System.Drawing.Point(-117, -185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(3, 816);
            this.label26.TabIndex = 177;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.MediumBlue;
            this.label25.Location = new System.Drawing.Point(-117, -185);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1000, 3);
            this.label25.TabIndex = 176;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 400);
            this.label1.TabIndex = 179;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(857, 3);
            this.label2.TabIndex = 178;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(12, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(731, 3);
            this.label6.TabIndex = 180;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(748, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(857, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 400);
            this.label7.TabIndex = 182;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(3, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(857, 3);
            this.label8.TabIndex = 183;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtKgSolicitiados);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKgComprometer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnComprometer);
            this.panel1.Controls.Add(this.btnLiberarCompromiso);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(10, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 55);
            this.panel1.TabIndex = 129;
            // 
            // FrmMM18CompromisoMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 406);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panInfoMaterial);
            this.Controls.Add(this.dgvListaMateriales);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMM18CompromisoMaterial";
            this.Text = "MM18 - Compromiso de Material";
            this.Load += new System.EventHandler(this.FrmCompromisoMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panInfoMaterial.ResumeLayout(false);
            this.panInfoMaterial.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComprometer;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.DataGridView dgvListaMateriales;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.TextBox txtSalesOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oVReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLTNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservaOFDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox ckOnlyAvailable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKgComprometer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKgSolicitiados;
        private System.Windows.Forms.Button btnLiberarCompromiso;
        private System.Windows.Forms.Panel panInfoMaterial;
        private System.Windows.Forms.TextBox txtCodigoPrimario;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}