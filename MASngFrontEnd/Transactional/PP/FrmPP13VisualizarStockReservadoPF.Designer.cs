namespace MASngFE.Transactional.PP
{
    partial class FrmPP13VisualizarStockReservadoPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP13VisualizarStockReservadoPF));
            this.dgvStockReservado = new System.Windows.Forms.DataGridView();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLiberarOrden = new System.Windows.Forms.Button();
            this.txtCantidadKgIngresados = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstadoOF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialFabricado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IDStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oVReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimoMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.despachoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLTNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservaOFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReservado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStockReservado
            // 
            this.dgvStockReservado.AllowUserToAddRows = false;
            this.dgvStockReservado.AllowUserToDeleteRows = false;
            this.dgvStockReservado.AutoGenerateColumns = false;
            this.dgvStockReservado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvStockReservado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockReservado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDStock,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.oVReservaDataGridViewTextBoxColumn,
            this.ultimoMovimientoDataGridViewTextBoxColumn,
            this.despachoDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.pLTNDataGridViewTextBoxColumn,
            this.reservaOFDataGridViewTextBoxColumn});
            this.dgvStockReservado.DataSource = this.t0030STOCKBindingSource;
            this.dgvStockReservado.Location = new System.Drawing.Point(1, 130);
            this.dgvStockReservado.MultiSelect = false;
            this.dgvStockReservado.Name = "dgvStockReservado";
            this.dgvStockReservado.ReadOnly = true;
            this.dgvStockReservado.RowHeadersWidth = 20;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStockReservado.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockReservado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockReservado.Size = new System.Drawing.Size(902, 401);
            this.dgvStockReservado.TabIndex = 1;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnLiberarOrden);
            this.panel1.Controls.Add(this.txtCantidadKgIngresados);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEstadoOF);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaterialFabricado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNumeroOF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Navy;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 82);
            this.panel1.TabIndex = 37;
            // 
            // btnLiberarOrden
            // 
            this.btnLiberarOrden.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberarOrden.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberarOrden.Image")));
            this.btnLiberarOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiberarOrden.Location = new System.Drawing.Point(699, 40);
            this.btnLiberarOrden.Name = "btnLiberarOrden";
            this.btnLiberarOrden.Size = new System.Drawing.Size(100, 40);
            this.btnLiberarOrden.TabIndex = 65;
            this.btnLiberarOrden.Text = "Liberar\r\nOrden";
            this.btnLiberarOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberarOrden.UseVisualStyleBackColor = true;
            this.btnLiberarOrden.Click += new System.EventHandler(this.btnLiberarOrden_Click);
            // 
            // txtCantidadKgIngresados
            // 
            this.txtCantidadKgIngresados.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCantidadKgIngresados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadKgIngresados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadKgIngresados.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtCantidadKgIngresados.Location = new System.Drawing.Point(537, 6);
            this.txtCantidadKgIngresados.Name = "txtCantidadKgIngresados";
            this.txtCantidadKgIngresados.ReadOnly = true;
            this.txtCantidadKgIngresados.Size = new System.Drawing.Size(87, 22);
            this.txtCantidadKgIngresados.TabIndex = 7;
            this.txtCantidadKgIngresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(699, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kg Total Fabricados";
            // 
            // txtEstadoOF
            // 
            this.txtEstadoOF.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtEstadoOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoOF.Location = new System.Drawing.Point(154, 54);
            this.txtEstadoOF.Name = "txtEstadoOF";
            this.txtEstadoOF.ReadOnly = true;
            this.txtEstadoOF.Size = new System.Drawing.Size(158, 22);
            this.txtEstadoOF.TabIndex = 5;
            this.txtEstadoOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado OF";
            // 
            // txtMaterialFabricado
            // 
            this.txtMaterialFabricado.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtMaterialFabricado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialFabricado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialFabricado.Location = new System.Drawing.Point(154, 30);
            this.txtMaterialFabricado.Name = "txtMaterialFabricado";
            this.txtMaterialFabricado.ReadOnly = true;
            this.txtMaterialFabricado.Size = new System.Drawing.Size(158, 22);
            this.txtMaterialFabricado.TabIndex = 3;
            this.txtMaterialFabricado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Fabricado";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.Location = new System.Drawing.Point(154, 6);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.ReadOnly = true;
            this.txtNumeroOF.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroOF.TabIndex = 1;
            this.txtNumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden Fabricacion #";
            // 
            // IDStock
            // 
            this.IDStock.DataPropertyName = "IDStock";
            this.IDStock.HeaderText = "IdSTK";
            this.IDStock.Name = "IDStock";
            this.IDStock.ReadOnly = true;
            this.IDStock.Width = 40;
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
            this.batchDataGridViewTextBoxColumn.HeaderText = "Batch";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "Documento";
            this.documentoDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oVReservaDataGridViewTextBoxColumn
            // 
            this.oVReservaDataGridViewTextBoxColumn.DataPropertyName = "OV_Reserva";
            this.oVReservaDataGridViewTextBoxColumn.HeaderText = "OV_Reserva";
            this.oVReservaDataGridViewTextBoxColumn.Name = "oVReservaDataGridViewTextBoxColumn";
            this.oVReservaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ultimoMovimientoDataGridViewTextBoxColumn
            // 
            this.ultimoMovimientoDataGridViewTextBoxColumn.DataPropertyName = "UltimoMovimiento";
            this.ultimoMovimientoDataGridViewTextBoxColumn.HeaderText = "UltimoMovimiento";
            this.ultimoMovimientoDataGridViewTextBoxColumn.Name = "ultimoMovimientoDataGridViewTextBoxColumn";
            this.ultimoMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // despachoDataGridViewTextBoxColumn
            // 
            this.despachoDataGridViewTextBoxColumn.DataPropertyName = "Despacho";
            this.despachoDataGridViewTextBoxColumn.HeaderText = "Despacho";
            this.despachoDataGridViewTextBoxColumn.Name = "despachoDataGridViewTextBoxColumn";
            this.despachoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pLTNDataGridViewTextBoxColumn
            // 
            this.pLTNDataGridViewTextBoxColumn.DataPropertyName = "PLTN";
            this.pLTNDataGridViewTextBoxColumn.HeaderText = "PLTN";
            this.pLTNDataGridViewTextBoxColumn.Name = "pLTNDataGridViewTextBoxColumn";
            this.pLTNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reservaOFDataGridViewTextBoxColumn
            // 
            this.reservaOFDataGridViewTextBoxColumn.DataPropertyName = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.HeaderText = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.Name = "reservaOFDataGridViewTextBoxColumn";
            this.reservaOFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmPP13VisualizarStockReservadoPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 685);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStockReservado);
            this.Name = "FrmPP13VisualizarStockReservadoPF";
            this.Text = "PP13 - Visualizar Stock Reservado Orden de Fabricacion";
            this.Load += new System.EventHandler(this.FrmPP13VisualizarStockReservadoPF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReservado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.DataGridView dgvStockReservado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCantidadKgIngresados;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstadoOF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaterialFabricado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLiberarOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oVReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimoMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn despachoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLTNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservaOFDataGridViewTextBoxColumn;
    }
}