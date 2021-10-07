namespace MASngFE.Transactional.WM
{
    partial class FrmWM07LiberarReservaRE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.lineaDerecha = new System.Windows.Forms.Label();
            this.lineaAbajo = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.stockBs = new System.Windows.Forms.BindingSource(this.components);
            this.Idstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalKgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrdenVentaReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRemito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Free = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBs)).BeginInit();
            this.SuspendLayout();
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DimGray;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 536);
            this.LineaIzq.TabIndex = 156;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DimGray;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(880, 3);
            this.lineaArriba.TabIndex = 155;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(730, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 154;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvStockList
            // 
            this.dgvStockList.AllowUserToAddRows = false;
            this.dgvStockList.AllowUserToDeleteRows = false;
            this.dgvStockList.AutoGenerateColumns = false;
            this.dgvStockList.BackgroundColor = System.Drawing.Color.DimGray;
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
            this.loteDataGridViewTextBoxColumn,
            this.totalKgDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.clienteReservaDataGridViewTextBoxColumn,
            this.IdOrdenVentaReserva,
            this.idRemito,
            this.EstadoReserva,
            this.Free});
            this.dgvStockList.DataSource = this.stockBs;
            this.dgvStockList.GridColor = System.Drawing.Color.Navy;
            this.dgvStockList.Location = new System.Drawing.Point(9, 51);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.ReadOnly = true;
            this.dgvStockList.RowHeadersWidth = 20;
            this.dgvStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockList.Size = new System.Drawing.Size(821, 472);
            this.dgvStockList.TabIndex = 157;
            this.dgvStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellContentClick);
            // 
            // lineaDerecha
            // 
            this.lineaDerecha.BackColor = System.Drawing.Color.DimGray;
            this.lineaDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaDerecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaDerecha.Location = new System.Drawing.Point(879, 5);
            this.lineaDerecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaDerecha.Name = "lineaDerecha";
            this.lineaDerecha.Size = new System.Drawing.Size(3, 533);
            this.lineaDerecha.TabIndex = 159;
            // 
            // lineaAbajo
            // 
            this.lineaAbajo.BackColor = System.Drawing.Color.DimGray;
            this.lineaAbajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaAbajo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaAbajo.Location = new System.Drawing.Point(2, 535);
            this.lineaAbajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaAbajo.Name = "lineaAbajo";
            this.lineaAbajo.Size = new System.Drawing.Size(877, 3);
            this.lineaAbajo.TabIndex = 158;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Green;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewButtonColumn1.HeaderText = "Liberar";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Free";
            this.dataGridViewButtonColumn1.ToolTipText = "Liberar el Compromiso del Material";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 50;
            // 
            // stockBs
            // 
            this.stockBs.DataSource = typeof(TecserEF.Entity.DataStructure.CqStockStructure);
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
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote#";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalKgDataGridViewTextBoxColumn
            // 
            this.totalKgDataGridViewTextBoxColumn.DataPropertyName = "TotalKg";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.totalKgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalKgDataGridViewTextBoxColumn.HeaderText = "KG";
            this.totalKgDataGridViewTextBoxColumn.Name = "totalKgDataGridViewTextBoxColumn";
            this.totalKgDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalKgDataGridViewTextBoxColumn.Width = 70;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.estadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteReservaDataGridViewTextBoxColumn
            // 
            this.clienteReservaDataGridViewTextBoxColumn.DataPropertyName = "ClienteReserva";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Indigo;
            this.clienteReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.clienteReservaDataGridViewTextBoxColumn.HeaderText = "Reservado Para";
            this.clienteReservaDataGridViewTextBoxColumn.Name = "clienteReservaDataGridViewTextBoxColumn";
            this.clienteReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteReservaDataGridViewTextBoxColumn.Width = 150;
            // 
            // IdOrdenVentaReserva
            // 
            this.IdOrdenVentaReserva.DataPropertyName = "IdOrdenVentaReserva";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Indigo;
            this.IdOrdenVentaReserva.DefaultCellStyle = dataGridViewCellStyle7;
            this.IdOrdenVentaReserva.HeaderText = "OV#";
            this.IdOrdenVentaReserva.Name = "IdOrdenVentaReserva";
            this.IdOrdenVentaReserva.ReadOnly = true;
            this.IdOrdenVentaReserva.Width = 70;
            // 
            // idRemito
            // 
            this.idRemito.DataPropertyName = "idRemito";
            this.idRemito.HeaderText = "idRemito";
            this.idRemito.Name = "idRemito";
            this.idRemito.ReadOnly = true;
            this.idRemito.Width = 60;
            // 
            // EstadoReserva
            // 
            this.EstadoReserva.DataPropertyName = "EstadoReserva";
            this.EstadoReserva.HeaderText = "EstadoReserva";
            this.EstadoReserva.Name = "EstadoReserva";
            this.EstadoReserva.ReadOnly = true;
            this.EstadoReserva.Width = 110;
            // 
            // Free
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Green;
            this.Free.DefaultCellStyle = dataGridViewCellStyle8;
            this.Free.HeaderText = "Liberar";
            this.Free.Name = "Free";
            this.Free.ReadOnly = true;
            this.Free.Text = "Free";
            this.Free.ToolTipText = "Liberar el Compromiso del Material";
            this.Free.UseColumnTextForButtonValue = true;
            this.Free.Width = 50;
            // 
            // FrmWM07LiberarReservaRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvStockList);
            this.Controls.Add(this.lineaDerecha);
            this.Controls.Add(this.lineaAbajo);
            this.Name = "FrmWM07LiberarReservaRE";
            this.Text = "WM07 - Visualizacion de Stock ReservaRE";
            this.Load += new System.EventHandler(this.FrmWM07LiberarReservaRE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource stockBs;
        private System.Windows.Forms.DataGridView dgvStockList;
        private System.Windows.Forms.Label lineaDerecha;
        private System.Windows.Forms.Label lineaAbajo;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalKgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrdenVentaReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoReserva;
        private System.Windows.Forms.DataGridViewButtonColumn Free;
    }
}