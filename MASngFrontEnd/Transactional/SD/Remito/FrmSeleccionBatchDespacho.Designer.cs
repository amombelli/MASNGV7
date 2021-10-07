namespace MASngFE.Transactional.SD.Remito
{
    partial class FrmSeleccionBatchDespacho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.idstock_dgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lote_dgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kg_dgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oVReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0030StockBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtPrimario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKGRequerido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKGSeleccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKgADespachar = new System.Windows.Forms.TextBox();
            this.ckVerTodoStock = new System.Windows.Forms.CheckBox();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtIdStockSeleccionado = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030StockBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoGenerateColumns = false;
            this.dgvStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idstock_dgv,
            this.materialDataGridViewTextBoxColumn,
            this.lote_dgv,
            this.kg_dgv,
            this.estadoDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.oVReservaDataGridViewTextBoxColumn});
            this.dgvStock.DataSource = this.t0030StockBs;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvStock.Location = new System.Drawing.Point(31, 38);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 20;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(500, 258);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            this.dgvStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellContentClick);
            // 
            // idstock_dgv
            // 
            this.idstock_dgv.DataPropertyName = "IDStock";
            this.idstock_dgv.HeaderText = "IDStock";
            this.idstock_dgv.Name = "idstock_dgv";
            this.idstock_dgv.ReadOnly = true;
            this.idstock_dgv.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialDataGridViewTextBoxColumn.Width = 150;
            // 
            // lote_dgv
            // 
            this.lote_dgv.DataPropertyName = "Batch";
            this.lote_dgv.HeaderText = "LOTE";
            this.lote_dgv.Name = "lote_dgv";
            this.lote_dgv.ReadOnly = true;
            // 
            // kg_dgv
            // 
            this.kg_dgv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kg_dgv.DataPropertyName = "Stock";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kg_dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.kg_dgv.HeaderText = "KG STK";
            this.kg_dgv.Name = "kg_dgv";
            this.kg_dgv.ReadOnly = true;
            this.kg_dgv.Width = 71;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 80;
            // 
            // oVReservaDataGridViewTextBoxColumn
            // 
            this.oVReservaDataGridViewTextBoxColumn.DataPropertyName = "OV_Reserva";
            this.oVReservaDataGridViewTextBoxColumn.HeaderText = "RESERVA OV";
            this.oVReservaDataGridViewTextBoxColumn.Name = "oVReservaDataGridViewTextBoxColumn";
            this.oVReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.oVReservaDataGridViewTextBoxColumn.Visible = false;
            this.oVReservaDataGridViewTextBoxColumn.Width = 150;
            // 
            // t0030StockBs
            // 
            this.t0030StockBs.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // txtPrimario
            // 
            this.txtPrimario.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtPrimario.Location = new System.Drawing.Point(136, 5);
            this.txtPrimario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrimario.Name = "txtPrimario";
            this.txtPrimario.ReadOnly = true;
            this.txtPrimario.Size = new System.Drawing.Size(122, 21);
            this.txtPrimario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label1.Location = new System.Drawing.Point(28, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MATERIAL [PRIMARIO]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "LOTE [SELECCION]";
            // 
            // txtLote
            // 
            this.txtLote.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtLote.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtLote.Location = new System.Drawing.Point(119, 7);
            this.txtLote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLote.Name = "txtLote";
            this.txtLote.ReadOnly = true;
            this.txtLote.Size = new System.Drawing.Size(122, 21);
            this.txtLote.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "KG [REQUERIDOS]";
            // 
            // txtKGRequerido
            // 
            this.txtKGRequerido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKGRequerido.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtKGRequerido.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtKGRequerido.Location = new System.Drawing.Point(119, 30);
            this.txtKGRequerido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKGRequerido.Name = "txtKGRequerido";
            this.txtKGRequerido.ReadOnly = true;
            this.txtKGRequerido.Size = new System.Drawing.Size(77, 21);
            this.txtKGRequerido.TabIndex = 5;
            this.txtKGRequerido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "KG [SELECCION]";
            // 
            // txtKGSeleccion
            // 
            this.txtKGSeleccion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKGSeleccion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtKGSeleccion.Location = new System.Drawing.Point(119, 54);
            this.txtKGSeleccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKGSeleccion.Name = "txtKGSeleccion";
            this.txtKGSeleccion.ReadOnly = true;
            this.txtKGSeleccion.Size = new System.Drawing.Size(77, 21);
            this.txtKGSeleccion.TabIndex = 7;
            this.txtKGSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "KG [ A DESPACHAR ]";
            // 
            // txtKgADespachar
            // 
            this.txtKgADespachar.BackColor = System.Drawing.Color.Khaki;
            this.txtKgADespachar.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtKgADespachar.Location = new System.Drawing.Point(119, 77);
            this.txtKgADespachar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKgADespachar.Name = "txtKgADespachar";
            this.txtKgADespachar.Size = new System.Drawing.Size(77, 21);
            this.txtKgADespachar.TabIndex = 9;
            this.txtKgADespachar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgADespachar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgADespachar_KeyPress);
            this.txtKgADespachar.Leave += new System.EventHandler(this.txtKgADespachar_Leave);
            // 
            // ckVerTodoStock
            // 
            this.ckVerTodoStock.AutoSize = true;
            this.ckVerTodoStock.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ckVerTodoStock.Location = new System.Drawing.Point(422, 7);
            this.ckVerTodoStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckVerTodoStock.Name = "ckVerTodoStock";
            this.ckVerTodoStock.Size = new System.Drawing.Size(114, 17);
            this.ckVerTodoStock.TabIndex = 11;
            this.ckVerTodoStock.Text = "VER TODO EL STOCK";
            this.ckVerTodoStock.UseVisualStyleBackColor = true;
            this.ckVerTodoStock.CheckedChanged += new System.EventHandler(this.ckVerTodoStock_CheckedChanged);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(429, 310);
            this.btnSeleccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(101, 32);
            this.btnSeleccion.TabIndex = 12;
            this.btnSeleccion.Text = "SELECCION";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(429, 341);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 32);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtIdStockSeleccionado
            // 
            this.txtIdStockSeleccionado.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtIdStockSeleccionado.Location = new System.Drawing.Point(245, 7);
            this.txtIdStockSeleccionado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdStockSeleccionado.Name = "txtIdStockSeleccionado";
            this.txtIdStockSeleccionado.ReadOnly = true;
            this.txtIdStockSeleccionado.Size = new System.Drawing.Size(66, 21);
            this.txtIdStockSeleccionado.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdStockSeleccionado);
            this.panel1.Controls.Add(this.txtLote);
            this.panel1.Controls.Add(this.txtKGRequerido);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtKGSeleccion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKgADespachar);
            this.panel1.Location = new System.Drawing.Point(31, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 104);
            this.panel1.TabIndex = 15;
            // 
            // FrmSeleccionBatchDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 409);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.ckVerTodoStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrimario);
            this.Controls.Add(this.dgvStock);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSeleccionBatchDespacho";
            this.Text = "SELECCION DE BATCH / KG A DESPACHAR";
            this.Load += new System.EventHandler(this.FrmSeleccionBatchDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030StockBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.BindingSource t0030StockBs;
        private System.Windows.Forms.TextBox txtPrimario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKGRequerido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKGSeleccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKgADespachar;
        private System.Windows.Forms.CheckBox ckVerTodoStock;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtIdStockSeleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idstock_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lote_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kg_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oVReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
    }
}