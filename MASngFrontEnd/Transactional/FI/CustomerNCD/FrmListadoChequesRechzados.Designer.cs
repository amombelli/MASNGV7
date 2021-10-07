namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmListadoChequesRechzados
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
            System.Windows.Forms.Button btnSalir;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ckSinNotaDebitoRealizada = new System.Windows.Forms.CheckBox();
            this.dgvListaChequesRechazados = new System.Windows.Forms.DataGridView();
            this.t0156CHEQUERECHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iDCHEQUEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLIENTERSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bANCOSNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHACHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOTIVOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaChequesRechazados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0156CHEQUERECHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ckSinNotaDebitoRealizada
            // 
            this.ckSinNotaDebitoRealizada.AutoSize = true;
            this.ckSinNotaDebitoRealizada.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ckSinNotaDebitoRealizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSinNotaDebitoRealizada.Location = new System.Drawing.Point(15, 604);
            this.ckSinNotaDebitoRealizada.Name = "ckSinNotaDebitoRealizada";
            this.ckSinNotaDebitoRealizada.Size = new System.Drawing.Size(138, 17);
            this.ckSinNotaDebitoRealizada.TabIndex = 0;
            this.ckSinNotaDebitoRealizada.Text = "SIN NOTA DE DEBITO";
            this.ckSinNotaDebitoRealizada.UseVisualStyleBackColor = false;
            this.ckSinNotaDebitoRealizada.CheckedChanged += new System.EventHandler(this.ckSinNotaDebitoRealizada_CheckedChanged);
            // 
            // dgvListaChequesRechazados
            // 
            this.dgvListaChequesRechazados.AllowUserToAddRows = false;
            this.dgvListaChequesRechazados.AllowUserToDeleteRows = false;
            this.dgvListaChequesRechazados.AutoGenerateColumns = false;
            this.dgvListaChequesRechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaChequesRechazados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCHEQUEDataGridViewTextBoxColumn,
            this.cLIENTERSDataGridViewTextBoxColumn,
            this.nUMERODataGridViewTextBoxColumn,
            this.bANCOSNDataGridViewTextBoxColumn,
            this.iMPORTEDataGridViewTextBoxColumn,
            this.fECHACHDataGridViewTextBoxColumn,
            this.mOTIVOREDataGridViewTextBoxColumn,
            this.nCNUMDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn});
            this.dgvListaChequesRechazados.DataSource = this.t0156CHEQUERECHBindingSource;
            this.dgvListaChequesRechazados.Location = new System.Drawing.Point(14, 109);
            this.dgvListaChequesRechazados.MultiSelect = false;
            this.dgvListaChequesRechazados.Name = "dgvListaChequesRechazados";
            this.dgvListaChequesRechazados.ReadOnly = true;
            this.dgvListaChequesRechazados.RowHeadersWidth = 25;
            this.dgvListaChequesRechazados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaChequesRechazados.Size = new System.Drawing.Size(958, 489);
            this.dgvListaChequesRechazados.TabIndex = 1;
            // 
            // t0156CHEQUERECHBindingSource
            // 
            this.t0156CHEQUERECHBindingSource.DataSource = typeof(TecserEF.Entity.T0156_CHEQUE_RECH);
            // 
            // btnSalir
            // 
            btnSalir.Location = new System.Drawing.Point(911, 47);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(89, 38);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(14, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(958, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "LISTADO DE CHEQUES RECHAZADOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 60);
            this.panel1.TabIndex = 15;
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(105, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(307, 21);
            this.cmbFantasia.TabIndex = 16;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.Leave += new System.EventHandler(this.cmbFantasia_Leave);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(105, 7);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(307, 21);
            this.cmbRazonSocial.TabIndex = 15;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.Leave += new System.EventHandler(this.cmbFantasia_Leave);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCliente.Location = new System.Drawing.Point(415, 7);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(57, 20);
            this.txtIdCliente.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fantasia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Razon Social";
            // 
            // iDCHEQUEDataGridViewTextBoxColumn
            // 
            this.iDCHEQUEDataGridViewTextBoxColumn.DataPropertyName = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.HeaderText = "IDCh";
            this.iDCHEQUEDataGridViewTextBoxColumn.Name = "iDCHEQUEDataGridViewTextBoxColumn";
            this.iDCHEQUEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCHEQUEDataGridViewTextBoxColumn.Visible = false;
            this.iDCHEQUEDataGridViewTextBoxColumn.Width = 60;
            // 
            // cLIENTERSDataGridViewTextBoxColumn
            // 
            this.cLIENTERSDataGridViewTextBoxColumn.DataPropertyName = "CLIENTERS";
            this.cLIENTERSDataGridViewTextBoxColumn.HeaderText = "Cliente (Rs)";
            this.cLIENTERSDataGridViewTextBoxColumn.Name = "cLIENTERSDataGridViewTextBoxColumn";
            this.cLIENTERSDataGridViewTextBoxColumn.ReadOnly = true;
            this.cLIENTERSDataGridViewTextBoxColumn.Width = 180;
            // 
            // nUMERODataGridViewTextBoxColumn
            // 
            this.nUMERODataGridViewTextBoxColumn.DataPropertyName = "NUMERO";
            this.nUMERODataGridViewTextBoxColumn.HeaderText = "ChNum";
            this.nUMERODataGridViewTextBoxColumn.Name = "nUMERODataGridViewTextBoxColumn";
            this.nUMERODataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMERODataGridViewTextBoxColumn.Width = 60;
            // 
            // bANCOSNDataGridViewTextBoxColumn
            // 
            this.bANCOSNDataGridViewTextBoxColumn.DataPropertyName = "BANCO_SN";
            this.bANCOSNDataGridViewTextBoxColumn.HeaderText = "ChBanco";
            this.bANCOSNDataGridViewTextBoxColumn.Name = "bANCOSNDataGridViewTextBoxColumn";
            this.bANCOSNDataGridViewTextBoxColumn.ReadOnly = true;
            this.bANCOSNDataGridViewTextBoxColumn.Width = 130;
            // 
            // iMPORTEDataGridViewTextBoxColumn
            // 
            this.iMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Format = "C2";
            this.iMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.iMPORTEDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.iMPORTEDataGridViewTextBoxColumn.Name = "iMPORTEDataGridViewTextBoxColumn";
            this.iMPORTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEDataGridViewTextBoxColumn.Width = 80;
            // 
            // fECHACHDataGridViewTextBoxColumn
            // 
            this.fECHACHDataGridViewTextBoxColumn.DataPropertyName = "FECHA_CH";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.fECHACHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fECHACHDataGridViewTextBoxColumn.HeaderText = "ChFecha";
            this.fECHACHDataGridViewTextBoxColumn.Name = "fECHACHDataGridViewTextBoxColumn";
            this.fECHACHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mOTIVOREDataGridViewTextBoxColumn
            // 
            this.mOTIVOREDataGridViewTextBoxColumn.DataPropertyName = "MOTIVO_RE";
            this.mOTIVOREDataGridViewTextBoxColumn.HeaderText = "Motivo Rechazo";
            this.mOTIVOREDataGridViewTextBoxColumn.Name = "mOTIVOREDataGridViewTextBoxColumn";
            this.mOTIVOREDataGridViewTextBoxColumn.ReadOnly = true;
            this.mOTIVOREDataGridViewTextBoxColumn.Width = 200;
            // 
            // nCNUMDataGridViewTextBoxColumn
            // 
            this.nCNUMDataGridViewTextBoxColumn.DataPropertyName = "NC_NUM";
            this.nCNUMDataGridViewTextBoxColumn.HeaderText = "Nd Numero";
            this.nCNUMDataGridViewTextBoxColumn.Name = "nCNUMDataGridViewTextBoxColumn";
            this.nCNUMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // FrmListadoChequesRechzados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 736);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(btnSalir);
            this.Controls.Add(this.dgvListaChequesRechazados);
            this.Controls.Add(this.ckSinNotaDebitoRealizada);
            this.Name = "FrmListadoChequesRechzados";
            this.Text = "LISTADO DE CHEQUES RECHAZADOS";
            this.Load += new System.EventHandler(this.FrmListadoChequesRechzados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaChequesRechazados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0156CHEQUERECHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckSinNotaDebitoRealizada;
        private System.Windows.Forms.DataGridView dgvListaChequesRechazados;
        private System.Windows.Forms.BindingSource t0156CHEQUERECHBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCHEQUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLIENTERSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bANCOSNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHACHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOTIVOREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
    }
}