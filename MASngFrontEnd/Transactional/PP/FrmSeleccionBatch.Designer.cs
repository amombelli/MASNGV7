namespace MASngFE.Transactional.PP
{
    partial class FrmSeleccionBatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckSoloDisponible = new System.Windows.Forms.CheckBox();
            this.dgvStockDisponible = new System.Windows.Forms.DataGridView();
            this.iDStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservaOFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKgRequeridos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaterial
            // 
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtMaterial.Location = new System.Drawing.Point(94, 6);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(92, 21);
            this.txtMaterial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MATERIAL";
            // 
            // ckSoloDisponible
            // 
            this.ckSoloDisponible.AutoSize = true;
            this.ckSoloDisponible.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ckSoloDisponible.Location = new System.Drawing.Point(351, 5);
            this.ckSoloDisponible.Name = "ckSoloDisponible";
            this.ckSoloDisponible.Size = new System.Drawing.Size(156, 17);
            this.ckSoloDisponible.TabIndex = 2;
            this.ckSoloDisponible.Text = "VER SOLO STOCK HABILITADO";
            this.ckSoloDisponible.UseVisualStyleBackColor = true;
            // 
            // dgvStockDisponible
            // 
            this.dgvStockDisponible.AllowUserToAddRows = false;
            this.dgvStockDisponible.AllowUserToDeleteRows = false;
            this.dgvStockDisponible.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockDisponible.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDisponible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDStockDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.reservaOFDataGridViewTextBoxColumn,
            this.BtnSelect});
            this.dgvStockDisponible.DataSource = this.t0030STOCKBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockDisponible.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockDisponible.Location = new System.Drawing.Point(12, 64);
            this.dgvStockDisponible.MultiSelect = false;
            this.dgvStockDisponible.Name = "dgvStockDisponible";
            this.dgvStockDisponible.ReadOnly = true;
            this.dgvStockDisponible.Size = new System.Drawing.Size(551, 189);
            this.dgvStockDisponible.TabIndex = 3;
            this.dgvStockDisponible.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellClick);
            // 
            // iDStockDataGridViewTextBoxColumn
            // 
            this.iDStockDataGridViewTextBoxColumn.DataPropertyName = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.HeaderText = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.Name = "iDStockDataGridViewTextBoxColumn";
            this.iDStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDStockDataGridViewTextBoxColumn.Visible = false;
            this.iDStockDataGridViewTextBoxColumn.Width = 30;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "LOTE #";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchDataGridViewTextBoxColumn.Width = 80;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "KG";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Width = 50;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // reservaOFDataGridViewTextBoxColumn
            // 
            this.reservaOFDataGridViewTextBoxColumn.DataPropertyName = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.HeaderText = "RESERVA OF#";
            this.reservaOFDataGridViewTextBoxColumn.Name = "reservaOFDataGridViewTextBoxColumn";
            this.reservaOFDataGridViewTextBoxColumn.ReadOnly = true;
            this.reservaOFDataGridViewTextBoxColumn.Width = 90;
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "SELECT";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Text = "SELECT";
            this.BtnSelect.UseColumnTextForButtonValue = true;
            this.BtnSelect.Width = 60;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnCancelar.Location = new System.Drawing.Point(479, 28);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "KG REQUERIDOS";
            // 
            // txtKgRequeridos
            // 
            this.txtKgRequeridos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgRequeridos.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtKgRequeridos.Location = new System.Drawing.Point(94, 29);
            this.txtKgRequeridos.Name = "txtKgRequeridos";
            this.txtKgRequeridos.ReadOnly = true;
            this.txtKgRequeridos.Size = new System.Drawing.Size(51, 21);
            this.txtKgRequeridos.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(15, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "*SOLO SE VISUALIZAN MATERIALES-LOTE CON STOCK SUPERIOR AL REQUERIDO";
            // 
            // FrmSeleccionBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 284);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKgRequeridos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvStockDisponible);
            this.Controls.Add(this.ckSoloDisponible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaterial);
            this.Name = "FrmSeleccionBatch";
            this.Text = "SELECCION DE LOTE";
            this.Load += new System.EventHandler(this.FrmSeleccionBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckSoloDisponible;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKgRequeridos;
        private System.Windows.Forms.DataGridView dgvStockDisponible;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservaOFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.Label label3;
    }
}