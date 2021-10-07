namespace MASngFE.Transactional.QM
{
    partial class FrmQm01MetodoInspeccionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm01MetodoInspeccionList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListaMetodo = new System.Windows.Forms.DataGridView();
            this.t0800CQMETODOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCrearMetodo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IdMetodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaMetodo
            // 
            this.dgvListaMetodo.AllowUserToAddRows = false;
            this.dgvListaMetodo.AllowUserToDeleteRows = false;
            this.dgvListaMetodo.AutoGenerateColumns = false;
            this.dgvListaMetodo.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvListaMetodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMetodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMetodoDataGridViewTextBoxColumn,
            this.Descripcion,
            this.valorUnitDataGridViewTextBoxColumn,
            this.valorTypeDataGridViewTextBoxColumn,
            this.documentacionDataGridViewTextBoxColumn,
            this.Add});
            this.dgvListaMetodo.DataSource = this.t0800CQMETODOSBindingSource;
            this.dgvListaMetodo.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvListaMetodo.Location = new System.Drawing.Point(4, 25);
            this.dgvListaMetodo.Name = "dgvListaMetodo";
            this.dgvListaMetodo.ReadOnly = true;
            this.dgvListaMetodo.RowHeadersWidth = 15;
            this.dgvListaMetodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaMetodo.Size = new System.Drawing.Size(652, 416);
            this.dgvListaMetodo.TabIndex = 3;
            this.dgvListaMetodo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaMetodo_CellContentClick);
            // 
            // t0800CQMETODOSBindingSource
            // 
            this.t0800CQMETODOSBindingSource.DataSource = typeof(TecserEF.Entity.T0800_QMMetodosInspeccion);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(662, 43);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 64;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnCrearMetodo
            // 
            this.btnCrearMetodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrearMetodo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearMetodo.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearMetodo.Image")));
            this.btnCrearMetodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearMetodo.Location = new System.Drawing.Point(662, 3);
            this.btnCrearMetodo.Name = "btnCrearMetodo";
            this.btnCrearMetodo.Size = new System.Drawing.Size(100, 40);
            this.btnCrearMetodo.TabIndex = 63;
            this.btnCrearMetodo.Text = "Crear\r\nMetodo";
            this.btnCrearMetodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearMetodo.UseVisualStyleBackColor = true;
            this.btnCrearMetodo.Click += new System.EventHandler(this.BtnCrearMetodo_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Listado de Metodos de Inspeccion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IdMetodoDataGridViewTextBoxColumn
            // 
            this.IdMetodoDataGridViewTextBoxColumn.DataPropertyName = "IdMetodo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.IdMetodoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdMetodoDataGridViewTextBoxColumn.HeaderText = "Metodo";
            this.IdMetodoDataGridViewTextBoxColumn.Name = "IdMetodoDataGridViewTextBoxColumn";
            this.IdMetodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdMetodoDataGridViewTextBoxColumn.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 180;
            // 
            // valorUnitDataGridViewTextBoxColumn
            // 
            this.valorUnitDataGridViewTextBoxColumn.DataPropertyName = "ValorUnit";
            this.valorUnitDataGridViewTextBoxColumn.HeaderText = "UoM";
            this.valorUnitDataGridViewTextBoxColumn.Name = "valorUnitDataGridViewTextBoxColumn";
            this.valorUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorUnitDataGridViewTextBoxColumn.ToolTipText = "Unidad de Medida (Unit of Mesasure)";
            this.valorUnitDataGridViewTextBoxColumn.Width = 50;
            // 
            // valorTypeDataGridViewTextBoxColumn
            // 
            this.valorTypeDataGridViewTextBoxColumn.DataPropertyName = "ValorType";
            this.valorTypeDataGridViewTextBoxColumn.HeaderText = "DType";
            this.valorTypeDataGridViewTextBoxColumn.Name = "valorTypeDataGridViewTextBoxColumn";
            this.valorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorTypeDataGridViewTextBoxColumn.ToolTipText = "Tipo de Dato (Data Type)";
            this.valorTypeDataGridViewTextBoxColumn.Width = 120;
            // 
            // documentacionDataGridViewTextBoxColumn
            // 
            this.documentacionDataGridViewTextBoxColumn.DataPropertyName = "Documentacion";
            this.documentacionDataGridViewTextBoxColumn.HeaderText = "Documentacion";
            this.documentacionDataGridViewTextBoxColumn.Name = "documentacionDataGridViewTextBoxColumn";
            this.documentacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Add
            // 
            this.Add.HeaderText = "Accion";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            this.Add.Text = "Update";
            this.Add.ToolTipText = "Modificar el Metodo de Inspeccion";
            this.Add.UseColumnTextForButtonValue = true;
            this.Add.Width = 50;
            // 
            // FrmQm01MetodoInspeccionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 445);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearMetodo);
            this.Controls.Add(this.dgvListaMetodo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQm01MetodoInspeccionList";
            this.Text = "QM01 - Metodos de Inspeccion";
            this.Load += new System.EventHandler(this.FrmQm01MetodoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaMetodo;
        private System.Windows.Forms.BindingSource t0800CQMETODOSBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCrearMetodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMetodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
    }
}