namespace MASngFE.Transactional.QM
{
    partial class FrmQm22SeleccionaRegistroCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvSeleccion = new System.Windows.Forms.DataGridView();
            this.id40DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaMovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.qmLoteSupplierStructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qmLoteSupplierStructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.txtLote);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtMaterial);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 53);
            this.panel2.TabIndex = 70;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(63, 27);
            this.txtLote.Name = "txtLote";
            this.txtLote.ReadOnly = true;
            this.txtLote.Size = new System.Drawing.Size(97, 20);
            this.txtLote.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lote #";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(63, 5);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(143, 20);
            this.txtMaterial.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Material";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(672, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // dgvSeleccion
            // 
            this.dgvSeleccion.AllowUserToAddRows = false;
            this.dgvSeleccion.AllowUserToDeleteRows = false;
            this.dgvSeleccion.AutoGenerateColumns = false;
            this.dgvSeleccion.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSeleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id40DataGridViewTextBoxColumn,
            this.fechaMovDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.kgDataGridViewTextBoxColumn,
            this.supplierDataGridViewTextBoxColumn,
            this.statusInDataGridViewTextBoxColumn,
            this.id2DataGridViewTextBoxColumn,
            this.Select});
            this.dgvSeleccion.DataSource = this.qmLoteSupplierStructBindingSource;
            this.dgvSeleccion.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvSeleccion.Location = new System.Drawing.Point(2, 62);
            this.dgvSeleccion.Name = "dgvSeleccion";
            this.dgvSeleccion.ReadOnly = true;
            this.dgvSeleccion.RowHeadersWidth = 20;
            this.dgvSeleccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccion.Size = new System.Drawing.Size(772, 165);
            this.dgvSeleccion.TabIndex = 72;
            this.dgvSeleccion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSeleccion_CellContentClick);
            // 
            // id40DataGridViewTextBoxColumn
            // 
            this.id40DataGridViewTextBoxColumn.DataPropertyName = "Id40";
            this.id40DataGridViewTextBoxColumn.HeaderText = "Id40";
            this.id40DataGridViewTextBoxColumn.Name = "id40DataGridViewTextBoxColumn";
            this.id40DataGridViewTextBoxColumn.ReadOnly = true;
            this.id40DataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaMovDataGridViewTextBoxColumn
            // 
            this.fechaMovDataGridViewTextBoxColumn.DataPropertyName = "FechaMov";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaMovDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaMovDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaMovDataGridViewTextBoxColumn.Name = "fechaMovDataGridViewTextBoxColumn";
            this.fechaMovDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialDataGridViewTextBoxColumn.Width = 80;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kgDataGridViewTextBoxColumn
            // 
            this.kgDataGridViewTextBoxColumn.DataPropertyName = "Kg";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.kgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.kgDataGridViewTextBoxColumn.HeaderText = "Kg";
            this.kgDataGridViewTextBoxColumn.Name = "kgDataGridViewTextBoxColumn";
            this.kgDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgDataGridViewTextBoxColumn.Width = 70;
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.supplierDataGridViewTextBoxColumn.DataPropertyName = "Supplier";
            this.supplierDataGridViewTextBoxColumn.HeaderText = "Supplier";
            this.supplierDataGridViewTextBoxColumn.Name = "supplierDataGridViewTextBoxColumn";
            this.supplierDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierDataGridViewTextBoxColumn.Width = 180;
            // 
            // statusInDataGridViewTextBoxColumn
            // 
            this.statusInDataGridViewTextBoxColumn.DataPropertyName = "StatusIn";
            this.statusInDataGridViewTextBoxColumn.HeaderText = "Status In";
            this.statusInDataGridViewTextBoxColumn.Name = "statusInDataGridViewTextBoxColumn";
            this.statusInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // id2DataGridViewTextBoxColumn
            // 
            this.id2DataGridViewTextBoxColumn.DataPropertyName = "Id2";
            this.id2DataGridViewTextBoxColumn.HeaderText = "Id2";
            this.id2DataGridViewTextBoxColumn.Name = "id2DataGridViewTextBoxColumn";
            this.id2DataGridViewTextBoxColumn.ReadOnly = true;
            this.id2DataGridViewTextBoxColumn.Width = 50;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Text = "Select";
            this.Select.ToolTipText = "Seleccion de Registro";
            this.Select.UseColumnTextForButtonValue = true;
            this.Select.Width = 60;
            // 
            // qmLoteSupplierStructBindingSource
            // 
            this.qmLoteSupplierStructBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.QmLoteSupplierStruct);
            // 
            // FrmQm22SeleccionaRegistroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 233);
            this.ControlBox = false;
            this.Controls.Add(this.dgvSeleccion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel2);
            this.Name = "FrmQm22SeleccionaRegistroCompra";
            this.Text = "QM22 - Seleccion de Registro";
            this.Load += new System.EventHandler(this.FrmQm22SeleccionaRegistroCompra_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qmLoteSupplierStructBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvSeleccion;
        private System.Windows.Forms.BindingSource qmLoteSupplierStructBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id40DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
    }
}