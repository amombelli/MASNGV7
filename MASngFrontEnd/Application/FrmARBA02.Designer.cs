namespace MASngFE.Application
{
    partial class FrmArba02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArba02));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheck1 = new System.Windows.Forms.Button();
            this.dgvListadoPerc = new System.Windows.Forms.DataGridView();
            this.idFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importIIBBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoImpagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refCobranzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaImputadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCobroRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCtaCteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presentadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.percepcionBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdPresentado = new System.Windows.Forms.Button();
            this.ckSoloPendientePresentacion = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(90, 22);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDesde.TabIndex = 1;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(90, 44);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Hasta";
            // 
            // btnCheck1
            // 
            this.btnCheck1.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck1.Image")));
            this.btnCheck1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck1.Location = new System.Drawing.Point(296, 24);
            this.btnCheck1.Name = "btnCheck1";
            this.btnCheck1.Size = new System.Drawing.Size(98, 39);
            this.btnCheck1.TabIndex = 4;
            this.btnCheck1.Text = "Obtener\r\nDatos";
            this.btnCheck1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck1.UseVisualStyleBackColor = true;
            this.btnCheck1.Click += new System.EventHandler(this.btnCheck1_Click);
            // 
            // dgvListadoPerc
            // 
            this.dgvListadoPerc.AllowUserToAddRows = false;
            this.dgvListadoPerc.AllowUserToDeleteRows = false;
            this.dgvListadoPerc.AutoGenerateColumns = false;
            this.dgvListadoPerc.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoPerc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListadoPerc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListadoPerc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFacturaDataGridViewTextBoxColumn,
            this.tipoDocDataGridViewTextBoxColumn,
            this.numDocDataGridViewTextBoxColumn,
            this.fechaDocDataGridViewTextBoxColumn,
            this.taxNumDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.importeDocDataGridViewTextBoxColumn,
            this.importIIBBDataGridViewTextBoxColumn,
            this.saldoImpagoDataGridViewTextBoxColumn,
            this.refCobranzaDataGridViewTextBoxColumn,
            this.fechaImputadoDataGridViewTextBoxColumn,
            this.fechaCobroRealDataGridViewTextBoxColumn,
            this.idCtaCteDataGridViewTextBoxColumn,
            this.presentadoDataGridViewCheckBoxColumn});
            this.dgvListadoPerc.DataSource = this.percepcionBs;
            this.dgvListadoPerc.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvListadoPerc.Location = new System.Drawing.Point(12, 94);
            this.dgvListadoPerc.Name = "dgvListadoPerc";
            this.dgvListadoPerc.ReadOnly = true;
            this.dgvListadoPerc.RowHeadersWidth = 20;
            this.dgvListadoPerc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoPerc.Size = new System.Drawing.Size(1240, 463);
            this.dgvListadoPerc.TabIndex = 5;
            // 
            // idFacturaDataGridViewTextBoxColumn
            // 
            this.idFacturaDataGridViewTextBoxColumn.DataPropertyName = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.HeaderText = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.Name = "idFacturaDataGridViewTextBoxColumn";
            this.idFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFacturaDataGridViewTextBoxColumn.Width = 60;
            // 
            // tipoDocDataGridViewTextBoxColumn
            // 
            this.tipoDocDataGridViewTextBoxColumn.DataPropertyName = "TipoDoc";
            this.tipoDocDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tipoDocDataGridViewTextBoxColumn.Name = "tipoDocDataGridViewTextBoxColumn";
            this.tipoDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDocDataGridViewTextBoxColumn.Width = 35;
            // 
            // numDocDataGridViewTextBoxColumn
            // 
            this.numDocDataGridViewTextBoxColumn.DataPropertyName = "NumDoc";
            this.numDocDataGridViewTextBoxColumn.HeaderText = "NumDoc";
            this.numDocDataGridViewTextBoxColumn.Name = "numDocDataGridViewTextBoxColumn";
            this.numDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocDataGridViewTextBoxColumn.Width = 70;
            // 
            // fechaDocDataGridViewTextBoxColumn
            // 
            this.fechaDocDataGridViewTextBoxColumn.DataPropertyName = "FechaDoc";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.fechaDocDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaDocDataGridViewTextBoxColumn.HeaderText = "FechaDoc";
            this.fechaDocDataGridViewTextBoxColumn.Name = "fechaDocDataGridViewTextBoxColumn";
            this.fechaDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDocDataGridViewTextBoxColumn.Width = 70;
            // 
            // taxNumDataGridViewTextBoxColumn
            // 
            this.taxNumDataGridViewTextBoxColumn.DataPropertyName = "TaxNum";
            this.taxNumDataGridViewTextBoxColumn.HeaderText = "TaxNum";
            this.taxNumDataGridViewTextBoxColumn.Name = "taxNumDataGridViewTextBoxColumn";
            this.taxNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxNumDataGridViewTextBoxColumn.Width = 70;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // importeDocDataGridViewTextBoxColumn
            // 
            this.importeDocDataGridViewTextBoxColumn.DataPropertyName = "ImporteDoc";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "0";
            this.importeDocDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.importeDocDataGridViewTextBoxColumn.HeaderText = "ImporteDoc";
            this.importeDocDataGridViewTextBoxColumn.Name = "importeDocDataGridViewTextBoxColumn";
            this.importeDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeDocDataGridViewTextBoxColumn.Width = 80;
            // 
            // importIIBBDataGridViewTextBoxColumn
            // 
            this.importIIBBDataGridViewTextBoxColumn.DataPropertyName = "ImportIIBB";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Format = "C2";
            this.importIIBBDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.importIIBBDataGridViewTextBoxColumn.HeaderText = "ImportIIBB";
            this.importIIBBDataGridViewTextBoxColumn.Name = "importIIBBDataGridViewTextBoxColumn";
            this.importIIBBDataGridViewTextBoxColumn.ReadOnly = true;
            this.importIIBBDataGridViewTextBoxColumn.Width = 80;
            // 
            // saldoImpagoDataGridViewTextBoxColumn
            // 
            this.saldoImpagoDataGridViewTextBoxColumn.DataPropertyName = "SaldoImpago";
            dataGridViewCellStyle10.Format = "C2";
            this.saldoImpagoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.saldoImpagoDataGridViewTextBoxColumn.HeaderText = "SaldoImpago";
            this.saldoImpagoDataGridViewTextBoxColumn.Name = "saldoImpagoDataGridViewTextBoxColumn";
            this.saldoImpagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoImpagoDataGridViewTextBoxColumn.Width = 80;
            // 
            // refCobranzaDataGridViewTextBoxColumn
            // 
            this.refCobranzaDataGridViewTextBoxColumn.DataPropertyName = "RefCobranza";
            this.refCobranzaDataGridViewTextBoxColumn.HeaderText = "RefCobranza";
            this.refCobranzaDataGridViewTextBoxColumn.Name = "refCobranzaDataGridViewTextBoxColumn";
            this.refCobranzaDataGridViewTextBoxColumn.ReadOnly = true;
            this.refCobranzaDataGridViewTextBoxColumn.Width = 75;
            // 
            // fechaImputadoDataGridViewTextBoxColumn
            // 
            this.fechaImputadoDataGridViewTextBoxColumn.DataPropertyName = "FechaImputado";
            this.fechaImputadoDataGridViewTextBoxColumn.HeaderText = "FechaImputado";
            this.fechaImputadoDataGridViewTextBoxColumn.Name = "fechaImputadoDataGridViewTextBoxColumn";
            this.fechaImputadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCobroRealDataGridViewTextBoxColumn
            // 
            this.fechaCobroRealDataGridViewTextBoxColumn.DataPropertyName = "FechaCobroReal";
            this.fechaCobroRealDataGridViewTextBoxColumn.HeaderText = "FechaCobroReal";
            this.fechaCobroRealDataGridViewTextBoxColumn.Name = "fechaCobroRealDataGridViewTextBoxColumn";
            this.fechaCobroRealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCtaCteDataGridViewTextBoxColumn
            // 
            this.idCtaCteDataGridViewTextBoxColumn.DataPropertyName = "idCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn.HeaderText = "idCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn.Name = "idCtaCteDataGridViewTextBoxColumn";
            this.idCtaCteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCtaCteDataGridViewTextBoxColumn.Width = 60;
            // 
            // presentadoDataGridViewCheckBoxColumn
            // 
            this.presentadoDataGridViewCheckBoxColumn.DataPropertyName = "Presentado";
            this.presentadoDataGridViewCheckBoxColumn.HeaderText = "Presentado";
            this.presentadoDataGridViewCheckBoxColumn.Name = "presentadoDataGridViewCheckBoxColumn";
            this.presentadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.presentadoDataGridViewCheckBoxColumn.Width = 30;
            // 
            // percepcionBs
            // 
            this.percepcionBs.DataSource = typeof(TecserEF.Entity.DataStructure.PercepcionArbaStructure);
            // 
            // btnUpdPresentado
            // 
            this.btnUpdPresentado.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdPresentado.Image")));
            this.btnUpdPresentado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdPresentado.Location = new System.Drawing.Point(5, 4);
            this.btnUpdPresentado.Name = "btnUpdPresentado";
            this.btnUpdPresentado.Size = new System.Drawing.Size(108, 39);
            this.btnUpdPresentado.TabIndex = 6;
            this.btnUpdPresentado.Text = "Update\r\nPresentado";
            this.btnUpdPresentado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdPresentado.UseVisualStyleBackColor = true;
            this.btnUpdPresentado.Click += new System.EventHandler(this.btnUpdPresentado_Click);
            // 
            // ckSoloPendientePresentacion
            // 
            this.ckSoloPendientePresentacion.AutoSize = true;
            this.ckSoloPendientePresentacion.Location = new System.Drawing.Point(17, 71);
            this.ckSoloPendientePresentacion.Name = "ckSoloPendientePresentacion";
            this.ckSoloPendientePresentacion.Size = new System.Drawing.Size(203, 17);
            this.ckSoloPendientePresentacion.TabIndex = 7;
            this.ckSoloPendientePresentacion.Text = "VER Solo Pendiente de Presentacion";
            this.ckSoloPendientePresentacion.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnUpdPresentado);
            this.panel1.Location = new System.Drawing.Point(845, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 70);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(119, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Actualiza la Base de Datos con el listado de Presentacion de Raffone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Image = global::MASngFE.Properties.Resources._1ms_excel_icon;
            this.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiar.Location = new System.Drawing.Point(396, 24);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(98, 39);
            this.btnCopiar.TabIndex = 11;
            this.btnCopiar.Text = "Copiar\r\nDatos";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // FrmArba02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 650);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckSoloPendientePresentacion);
            this.Controls.Add(this.dgvListadoPerc);
            this.Controls.Add(this.btnCheck1);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label1);
            this.Name = "FrmArba02";
            this.Text = "ARB02 - Generacion de Listado de Percepciones a Depositar";
            this.Load += new System.EventHandler(this.FrmArba02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheck1;
        private System.Windows.Forms.DataGridView dgvListadoPerc;
        private System.Windows.Forms.Button btnUpdPresentado;
        private System.Windows.Forms.BindingSource percepcionBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importIIBBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoImpagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refCobranzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaImputadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCobroRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn presentadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.CheckBox ckSoloPendientePresentacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopiar;
    }
}