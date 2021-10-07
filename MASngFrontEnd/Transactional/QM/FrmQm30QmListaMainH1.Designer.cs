namespace MASngFE.Transactional.QM
{
    partial class FrmQm30QmListaMainH1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm30QmListaMainH1));
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.idIRecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrigenTextoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoRecordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGTotalBatchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioH1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoPlanGeneralDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspeccionOKDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0805QMIRecordH1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCrearIRecord = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0805QMIRecordH1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.AutoGenerateColumns = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.OldLace;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idIRecDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.idPlanDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.fechaLoteDataGridViewTextBoxColumn,
            this.origenDataGridViewTextBoxColumn,
            this.idOrigenDataGridViewTextBoxColumn,
            this.idOrigenTextoDataGridViewTextBoxColumn,
            this.tipoRecordDataGridViewTextBoxColumn,
            this.kGTotalBatchDataGridViewTextBoxColumn,
            this.comentarioH1DataGridViewTextBoxColumn,
            this.estadoPlanGeneralDataGridViewTextBoxColumn,
            this.logUserDataGridViewTextBoxColumn,
            this.inspeccionOKDataGridViewCheckBoxColumn,
            this.View});
            this.dgvLista.DataSource = this.t0805QMIRecordH1BindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLista.GridColor = System.Drawing.Color.Navy;
            this.dgvLista.Location = new System.Drawing.Point(3, 35);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(1053, 484);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellContentClick);
            // 
            // idIRecDataGridViewTextBoxColumn
            // 
            this.idIRecDataGridViewTextBoxColumn.DataPropertyName = "IdIRec";
            this.idIRecDataGridViewTextBoxColumn.HeaderText = "IR#";
            this.idIRecDataGridViewTextBoxColumn.Name = "idIRecDataGridViewTextBoxColumn";
            this.idIRecDataGridViewTextBoxColumn.ReadOnly = true;
            this.idIRecDataGridViewTextBoxColumn.ToolTipText = "Numero de Registro de Inspeccion";
            this.idIRecDataGridViewTextBoxColumn.Width = 50;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPlanDataGridViewTextBoxColumn
            // 
            this.idPlanDataGridViewTextBoxColumn.DataPropertyName = "IdPlan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idPlanDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idPlanDataGridViewTextBoxColumn.HeaderText = "IPlan";
            this.idPlanDataGridViewTextBoxColumn.Name = "idPlanDataGridViewTextBoxColumn";
            this.idPlanDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPlanDataGridViewTextBoxColumn.Width = 60;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaLoteDataGridViewTextBoxColumn
            // 
            this.fechaLoteDataGridViewTextBoxColumn.DataPropertyName = "FechaLote";
            this.fechaLoteDataGridViewTextBoxColumn.HeaderText = "FechaLote";
            this.fechaLoteDataGridViewTextBoxColumn.Name = "fechaLoteDataGridViewTextBoxColumn";
            this.fechaLoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaLoteDataGridViewTextBoxColumn.Width = 80;
            // 
            // origenDataGridViewTextBoxColumn
            // 
            this.origenDataGridViewTextBoxColumn.DataPropertyName = "Origen";
            this.origenDataGridViewTextBoxColumn.HeaderText = "Origen";
            this.origenDataGridViewTextBoxColumn.Name = "origenDataGridViewTextBoxColumn";
            this.origenDataGridViewTextBoxColumn.ReadOnly = true;
            this.origenDataGridViewTextBoxColumn.Width = 45;
            // 
            // idOrigenDataGridViewTextBoxColumn
            // 
            this.idOrigenDataGridViewTextBoxColumn.DataPropertyName = "IdOrigen";
            this.idOrigenDataGridViewTextBoxColumn.HeaderText = "IdOrigen";
            this.idOrigenDataGridViewTextBoxColumn.Name = "idOrigenDataGridViewTextBoxColumn";
            this.idOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOrigenDataGridViewTextBoxColumn.Visible = false;
            // 
            // idOrigenTextoDataGridViewTextBoxColumn
            // 
            this.idOrigenTextoDataGridViewTextBoxColumn.DataPropertyName = "IdOrigenTexto";
            this.idOrigenTextoDataGridViewTextBoxColumn.HeaderText = "Supplier";
            this.idOrigenTextoDataGridViewTextBoxColumn.Name = "idOrigenTextoDataGridViewTextBoxColumn";
            this.idOrigenTextoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOrigenTextoDataGridViewTextBoxColumn.Width = 150;
            // 
            // tipoRecordDataGridViewTextBoxColumn
            // 
            this.tipoRecordDataGridViewTextBoxColumn.DataPropertyName = "TipoRecord";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoRecordDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.tipoRecordDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoRecordDataGridViewTextBoxColumn.Name = "tipoRecordDataGridViewTextBoxColumn";
            this.tipoRecordDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoRecordDataGridViewTextBoxColumn.Width = 40;
            // 
            // kGTotalBatchDataGridViewTextBoxColumn
            // 
            this.kGTotalBatchDataGridViewTextBoxColumn.DataPropertyName = "KGTotalBatch";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.kGTotalBatchDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.kGTotalBatchDataGridViewTextBoxColumn.HeaderText = "KG";
            this.kGTotalBatchDataGridViewTextBoxColumn.Name = "kGTotalBatchDataGridViewTextBoxColumn";
            this.kGTotalBatchDataGridViewTextBoxColumn.ReadOnly = true;
            this.kGTotalBatchDataGridViewTextBoxColumn.Width = 60;
            // 
            // comentarioH1DataGridViewTextBoxColumn
            // 
            this.comentarioH1DataGridViewTextBoxColumn.DataPropertyName = "ComentarioH1";
            this.comentarioH1DataGridViewTextBoxColumn.HeaderText = "ComentarioH1";
            this.comentarioH1DataGridViewTextBoxColumn.Name = "comentarioH1DataGridViewTextBoxColumn";
            this.comentarioH1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoPlanGeneralDataGridViewTextBoxColumn
            // 
            this.estadoPlanGeneralDataGridViewTextBoxColumn.DataPropertyName = "EstadoPlanGeneral";
            this.estadoPlanGeneralDataGridViewTextBoxColumn.HeaderText = "EstadoGRAL";
            this.estadoPlanGeneralDataGridViewTextBoxColumn.Name = "estadoPlanGeneralDataGridViewTextBoxColumn";
            this.estadoPlanGeneralDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoPlanGeneralDataGridViewTextBoxColumn.Width = 80;
            // 
            // logUserDataGridViewTextBoxColumn
            // 
            this.logUserDataGridViewTextBoxColumn.DataPropertyName = "LogUser";
            this.logUserDataGridViewTextBoxColumn.HeaderText = "LogUser";
            this.logUserDataGridViewTextBoxColumn.Name = "logUserDataGridViewTextBoxColumn";
            this.logUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.logUserDataGridViewTextBoxColumn.Width = 70;
            // 
            // inspeccionOKDataGridViewCheckBoxColumn
            // 
            this.inspeccionOKDataGridViewCheckBoxColumn.DataPropertyName = "InspeccionOK";
            this.inspeccionOKDataGridViewCheckBoxColumn.HeaderText = "OK";
            this.inspeccionOKDataGridViewCheckBoxColumn.Name = "inspeccionOKDataGridViewCheckBoxColumn";
            this.inspeccionOKDataGridViewCheckBoxColumn.ReadOnly = true;
            this.inspeccionOKDataGridViewCheckBoxColumn.Width = 30;
            // 
            // View
            // 
            this.View.DataPropertyName = "IdIRec";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.View.DefaultCellStyle = dataGridViewCellStyle6;
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Text = "View";
            this.View.ToolTipText = "Ver Detalle de Registro de Inspeccion";
            this.View.UseColumnTextForButtonValue = true;
            this.View.Width = 40;
            // 
            // t0805QMIRecordH1BindingSource
            // 
            this.t0805QMIRecordH1BindingSource.DataSource = typeof(TecserEF.Entity.T0805_QMIRecordH1);
            // 
            // btnCrearIRecord
            // 
            this.btnCrearIRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrearIRecord.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearIRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearIRecord.Image")));
            this.btnCrearIRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearIRecord.Location = new System.Drawing.Point(1062, 77);
            this.btnCrearIRecord.Name = "btnCrearIRecord";
            this.btnCrearIRecord.Size = new System.Drawing.Size(102, 42);
            this.btnCrearIRecord.TabIndex = 69;
            this.btnCrearIRecord.Text = "Crear\r\nIRecord";
            this.btnCrearIRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearIRecord.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1062, 35);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.TabIndex = 68;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmQm30QmListaMainH1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 524);
            this.Controls.Add(this.btnCrearIRecord);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvLista);
            this.Name = "FrmQm30QmListaMainH1";
            this.Text = "QM30 - Listado Registros Inspeccion H1";
            this.Load += new System.EventHandler(this.FrmQm30QmListaMainH1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0805QMIRecordH1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.BindingSource t0805QMIRecordH1BindingSource;
        private System.Windows.Forms.Button btnCrearIRecord;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIRecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrigenTextoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoRecordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGTotalBatchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioH1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoPlanGeneralDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inspeccionOKDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn View;
    }
}