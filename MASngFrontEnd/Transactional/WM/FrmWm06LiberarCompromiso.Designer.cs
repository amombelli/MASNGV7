namespace MASngFE.Transactional.WM
{
    partial class FrmWm06LiberarCompromiso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.stockBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.Idstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalKgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrdenVentaReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Free = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stockBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(771, 32);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 110;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 536);
            this.label3.TabIndex = 150;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.DimGray;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(2, 2);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(880, 3);
            this.label58.TabIndex = 149;
            // 
            // stockBs
            // 
            this.stockBs.DataSource = typeof(TecserEF.Entity.DataStructure.CqStockStructure);
            // 
            // dgvStockList
            // 
            this.dgvStockList.AllowUserToAddRows = false;
            this.dgvStockList.AllowUserToDeleteRows = false;
            this.dgvStockList.AutoGenerateColumns = false;
            this.dgvStockList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvStockList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStockList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idstock,
            this.materialDataGridViewTextBoxColumn,
            this.MaterialType,
            this.loteDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.totalKgDataGridViewTextBoxColumn,
            this.clienteReservaDataGridViewTextBoxColumn,
            this.IdOrdenVentaReserva,
            this.Free});
            this.dgvStockList.DataSource = this.stockBs;
            this.dgvStockList.GridColor = System.Drawing.Color.Navy;
            this.dgvStockList.Location = new System.Drawing.Point(9, 32);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.ReadOnly = true;
            this.dgvStockList.RowHeadersWidth = 20;
            this.dgvStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockList.Size = new System.Drawing.Size(756, 496);
            this.dgvStockList.TabIndex = 151;
            this.dgvStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellContentClick);
            // 
            // Idstock
            // 
            this.Idstock.DataPropertyName = "Idstock";
            this.Idstock.HeaderText = "Idstock";
            this.Idstock.Name = "Idstock";
            this.Idstock.ReadOnly = true;
            this.Idstock.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MaterialType
            // 
            this.MaterialType.DataPropertyName = "MaterialType";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialType.DefaultCellStyle = dataGridViewCellStyle3;
            this.MaterialType.HeaderText = "TIPOM";
            this.MaterialType.Name = "MaterialType";
            this.MaterialType.ReadOnly = true;
            this.MaterialType.Width = 55;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.loteDataGridViewTextBoxColumn.HeaderText = "LOTE";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.estadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalKgDataGridViewTextBoxColumn
            // 
            this.totalKgDataGridViewTextBoxColumn.DataPropertyName = "TotalKg";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.totalKgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalKgDataGridViewTextBoxColumn.HeaderText = "TOTAL KG";
            this.totalKgDataGridViewTextBoxColumn.Name = "totalKgDataGridViewTextBoxColumn";
            this.totalKgDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalKgDataGridViewTextBoxColumn.Width = 80;
            // 
            // clienteReservaDataGridViewTextBoxColumn
            // 
            this.clienteReservaDataGridViewTextBoxColumn.DataPropertyName = "ClienteReserva";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Indigo;
            this.clienteReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.clienteReservaDataGridViewTextBoxColumn.HeaderText = "COMPROMETIDO PARA";
            this.clienteReservaDataGridViewTextBoxColumn.Name = "clienteReservaDataGridViewTextBoxColumn";
            this.clienteReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteReservaDataGridViewTextBoxColumn.Width = 150;
            // 
            // IdOrdenVentaReserva
            // 
            this.IdOrdenVentaReserva.DataPropertyName = "IdOrdenVentaReserva";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Indigo;
            this.IdOrdenVentaReserva.DefaultCellStyle = dataGridViewCellStyle8;
            this.IdOrdenVentaReserva.HeaderText = "NUM OV";
            this.IdOrdenVentaReserva.Name = "IdOrdenVentaReserva";
            this.IdOrdenVentaReserva.ReadOnly = true;
            this.IdOrdenVentaReserva.Width = 70;
            // 
            // Free
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Green;
            this.Free.DefaultCellStyle = dataGridViewCellStyle9;
            this.Free.HeaderText = "Liberar";
            this.Free.Name = "Free";
            this.Free.ReadOnly = true;
            this.Free.Text = "Free";
            this.Free.ToolTipText = "Liberar el Compromiso del Material";
            this.Free.UseColumnTextForButtonValue = true;
            this.Free.Width = 50;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 535);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(877, 3);
            this.label1.TabIndex = 152;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(879, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 530);
            this.label2.TabIndex = 153;
            // 
            // FrmWm06LiberarCompromiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStockList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmWm06LiberarCompromiso";
            this.Text = "WM06 - Liberar Compromiso";
            this.Load += new System.EventHandler(this.FrmWm06LiberarCompromiso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.BindingSource stockBs;
        private System.Windows.Forms.DataGridView dgvStockList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalKgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrdenVentaReserva;
        private System.Windows.Forms.DataGridViewButtonColumn Free;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}