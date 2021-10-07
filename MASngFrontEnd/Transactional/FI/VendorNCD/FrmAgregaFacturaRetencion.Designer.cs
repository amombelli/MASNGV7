namespace MASngFE.Transactional.FI
{
    partial class FrmAgregaFacturaRetencion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvListaFacturas = new System.Windows.Forms.DataGridView();
            this.t0213OPFACTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.iDITEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTSALDOODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTTIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCtaCteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarRetencion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0213OPFACTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(688, 82);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 42);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvListaFacturas
            // 
            this.dgvListaFacturas.AllowUserToAddRows = false;
            this.dgvListaFacturas.AllowUserToDeleteRows = false;
            this.dgvListaFacturas.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDITEMDataGridViewTextBoxColumn,
            this.fACTIDDataGridViewTextBoxColumn,
            this.fACTNUMDataGridViewTextBoxColumn,
            this.fACTSALDOODataGridViewTextBoxColumn,
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn,
            this.fACTTIPODataGridViewTextBoxColumn,
            this.idCtaCteDataGridViewTextBoxColumn});
            this.dgvListaFacturas.DataSource = this.t0213OPFACTBindingSource;
            this.dgvListaFacturas.Location = new System.Drawing.Point(12, 67);
            this.dgvListaFacturas.Name = "dgvListaFacturas";
            this.dgvListaFacturas.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaFacturas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaFacturas.Size = new System.Drawing.Size(654, 189);
            this.dgvListaFacturas.TabIndex = 1;
            this.dgvListaFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaFacturas_CellContentClick);
            // 
            // t0213OPFACTBindingSource
            // 
            this.t0213OPFACTBindingSource.DataSource = typeof(TecserEF.Entity.T0213_OP_FACT);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero Orden Pago";
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Location = new System.Drawing.Point(139, 6);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.ReadOnly = true;
            this.txtNumeroOP.Size = new System.Drawing.Size(100, 21);
            this.txtNumeroOP.TabIndex = 3;
            // 
            // iDITEMDataGridViewTextBoxColumn
            // 
            this.iDITEMDataGridViewTextBoxColumn.DataPropertyName = "IDITEM";
            this.iDITEMDataGridViewTextBoxColumn.HeaderText = "IDITEM";
            this.iDITEMDataGridViewTextBoxColumn.Name = "iDITEMDataGridViewTextBoxColumn";
            this.iDITEMDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDITEMDataGridViewTextBoxColumn.Width = 60;
            // 
            // fACTIDDataGridViewTextBoxColumn
            // 
            this.fACTIDDataGridViewTextBoxColumn.DataPropertyName = "FACT_ID";
            this.fACTIDDataGridViewTextBoxColumn.HeaderText = "ID FACT";
            this.fACTIDDataGridViewTextBoxColumn.Name = "fACTIDDataGridViewTextBoxColumn";
            this.fACTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fACTNUMDataGridViewTextBoxColumn
            // 
            this.fACTNUMDataGridViewTextBoxColumn.DataPropertyName = "FACT_NUM";
            this.fACTNUMDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.fACTNUMDataGridViewTextBoxColumn.Name = "fACTNUMDataGridViewTextBoxColumn";
            this.fACTNUMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fACTSALDOODataGridViewTextBoxColumn
            // 
            this.fACTSALDOODataGridViewTextBoxColumn.DataPropertyName = "FACT_SALDO_O";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.fACTSALDOODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fACTSALDOODataGridViewTextBoxColumn.HeaderText = "SALDO ORI";
            this.fACTSALDOODataGridViewTextBoxColumn.Name = "fACTSALDOODataGridViewTextBoxColumn";
            this.fACTSALDOODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fACTSALDOIMPUTARDataGridViewTextBoxColumn
            // 
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.DataPropertyName = "FACT_SALDO_IMPUTAR";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.HeaderText = "SALDO IMPUTAR";
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.Name = "fACTSALDOIMPUTARDataGridViewTextBoxColumn";
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.ReadOnly = true;
            this.fACTSALDOIMPUTARDataGridViewTextBoxColumn.Width = 120;
            // 
            // fACTTIPODataGridViewTextBoxColumn
            // 
            this.fACTTIPODataGridViewTextBoxColumn.DataPropertyName = "FACT_TIPO";
            this.fACTTIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.fACTTIPODataGridViewTextBoxColumn.Name = "fACTTIPODataGridViewTextBoxColumn";
            this.fACTTIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.fACTTIPODataGridViewTextBoxColumn.Width = 40;
            // 
            // idCtaCteDataGridViewTextBoxColumn
            // 
            this.idCtaCteDataGridViewTextBoxColumn.DataPropertyName = "IdCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn.HeaderText = "IDCTACTE";
            this.idCtaCteDataGridViewTextBoxColumn.Name = "idCtaCteDataGridViewTextBoxColumn";
            this.idCtaCteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCtaCteDataGridViewTextBoxColumn.Width = 80;
            // 
            // btnAgregarRetencion
            // 
            this.btnAgregarRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRetencion.Location = new System.Drawing.Point(688, 126);
            this.btnAgregarRetencion.Name = "btnAgregarRetencion";
            this.btnAgregarRetencion.Size = new System.Drawing.Size(101, 42);
            this.btnAgregarRetencion.TabIndex = 4;
            this.btnAgregarRetencion.Text = "AGREGAR RETENCION";
            this.btnAgregarRetencion.UseVisualStyleBackColor = true;
            this.btnAgregarRetencion.Click += new System.EventHandler(this.btnAgregarRetencion_Click);
            // 
            // FrmAgregaFacturaRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 268);
            this.Controls.Add(this.btnAgregarRetencion);
            this.Controls.Add(this.txtNumeroOP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaFacturas);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmAgregaFacturaRetencion";
            this.Text = "FACTURAS  SIN RETENCIONES EN ESTA OP";
            this.Load += new System.EventHandler(this.FrmAgregaFacturaRetencion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0213OPFACTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvListaFacturas;
        private System.Windows.Forms.BindingSource t0213OPFACTBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDITEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTSALDOODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTSALDOIMPUTARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTTIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAgregarRetencion;
    }
}