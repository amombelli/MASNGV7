namespace MASngFE.Transactional.QM
{
    partial class FrmQm10ListadoMetodos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm10ListadoMetodos));
            this.dgvListadoMetodos = new System.Windows.Forms.DataGridView();
            this.IdMetodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valorUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0800CQMETODOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddMetodoToPlan = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckPlanActivo = new System.Windows.Forms.CheckBox();
            this.txtIplanDescription = new System.Windows.Forms.TextBox();
            this.txtIPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoMetodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoMetodos
            // 
            this.dgvListadoMetodos.AllowUserToAddRows = false;
            this.dgvListadoMetodos.AllowUserToDeleteRows = false;
            this.dgvListadoMetodos.AutoGenerateColumns = false;
            this.dgvListadoMetodos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListadoMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoMetodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMetodoDataGridViewTextBoxColumn,
            this.dESCRIPCIONDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewTextBoxColumn,
            this.valorUnitDataGridViewTextBoxColumn,
            this.valorTypeDataGridViewTextBoxColumn});
            this.dgvListadoMetodos.DataSource = this.t0800CQMETODOSBindingSource;
            this.dgvListadoMetodos.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvListadoMetodos.Location = new System.Drawing.Point(3, 64);
            this.dgvListadoMetodos.MultiSelect = false;
            this.dgvListadoMetodos.Name = "dgvListadoMetodos";
            this.dgvListadoMetodos.ReadOnly = true;
            this.dgvListadoMetodos.RowHeadersWidth = 20;
            this.dgvListadoMetodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoMetodos.Size = new System.Drawing.Size(519, 460);
            this.dgvListadoMetodos.TabIndex = 0;
            this.dgvListadoMetodos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListadoMetodos_CellEnter);
            // 
            // IdMetodoDataGridViewTextBoxColumn
            // 
            this.IdMetodoDataGridViewTextBoxColumn.DataPropertyName = "IdMetodo";
            this.IdMetodoDataGridViewTextBoxColumn.HeaderText = "Metodo";
            this.IdMetodoDataGridViewTextBoxColumn.Name = "IdMetodoDataGridViewTextBoxColumn";
            this.IdMetodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdMetodoDataGridViewTextBoxColumn.Width = 70;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.dESCRIPCIONDataGridViewTextBoxColumn.Name = "dESCRIPCIONDataGridViewTextBoxColumn";
            this.dESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCRIPCIONDataGridViewTextBoxColumn.Width = 180;
            // 
            // aCTIVODataGridViewTextBoxColumn
            // 
            this.aCTIVODataGridViewTextBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewTextBoxColumn.Name = "aCTIVODataGridViewTextBoxColumn";
            this.aCTIVODataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVODataGridViewTextBoxColumn.Width = 60;
            // 
            // valorUnitDataGridViewTextBoxColumn
            // 
            this.valorUnitDataGridViewTextBoxColumn.DataPropertyName = "ValorUnit";
            this.valorUnitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.valorUnitDataGridViewTextBoxColumn.Name = "valorUnitDataGridViewTextBoxColumn";
            this.valorUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorUnitDataGridViewTextBoxColumn.Width = 50;
            // 
            // valorTypeDataGridViewTextBoxColumn
            // 
            this.valorTypeDataGridViewTextBoxColumn.DataPropertyName = "ValorType";
            this.valorTypeDataGridViewTextBoxColumn.HeaderText = "ValorType";
            this.valorTypeDataGridViewTextBoxColumn.Name = "valorTypeDataGridViewTextBoxColumn";
            this.valorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // t0800CQMETODOSBindingSource
            // 
            this.t0800CQMETODOSBindingSource.DataSource = typeof(TecserEF.Entity.T0800_QMMetodosInspeccion);
            // 
            // btnAddMetodoToPlan
            // 
            this.btnAddMetodoToPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMetodoToPlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMetodoToPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMetodoToPlan.Image")));
            this.btnAddMetodoToPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMetodoToPlan.Location = new System.Drawing.Point(528, 64);
            this.btnAddMetodoToPlan.Name = "btnAddMetodoToPlan";
            this.btnAddMetodoToPlan.Size = new System.Drawing.Size(100, 40);
            this.btnAddMetodoToPlan.TabIndex = 70;
            this.btnAddMetodoToPlan.Text = "Agregar\r\nMetodo";
            this.btnAddMetodoToPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMetodoToPlan.UseVisualStyleBackColor = true;
            this.btnAddMetodoToPlan.Click += new System.EventHandler(this.BtnSavePlan_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(528, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 17);
            this.label2.TabIndex = 75;
            this.label2.Text = "METODOS DE INSPECCION DISPONIBLES PARA AGREGADO AL PLAN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.ckPlanActivo);
            this.panel1.Controls.Add(this.txtIplanDescription);
            this.panel1.Controls.Add(this.txtIPName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 31);
            this.panel1.TabIndex = 76;
            // 
            // ckPlanActivo
            // 
            this.ckPlanActivo.AutoSize = true;
            this.ckPlanActivo.Enabled = false;
            this.ckPlanActivo.Location = new System.Drawing.Point(422, 6);
            this.ckPlanActivo.Name = "ckPlanActivo";
            this.ckPlanActivo.Size = new System.Drawing.Size(85, 19);
            this.ckPlanActivo.TabIndex = 4;
            this.ckPlanActivo.Text = "Plan Activo";
            this.ckPlanActivo.UseVisualStyleBackColor = true;
            // 
            // txtIplanDescription
            // 
            this.txtIplanDescription.BackColor = System.Drawing.Color.AliceBlue;
            this.txtIplanDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIplanDescription.ForeColor = System.Drawing.Color.Navy;
            this.txtIplanDescription.Location = new System.Drawing.Point(152, 4);
            this.txtIplanDescription.Name = "txtIplanDescription";
            this.txtIplanDescription.ReadOnly = true;
            this.txtIplanDescription.Size = new System.Drawing.Size(264, 21);
            this.txtIplanDescription.TabIndex = 3;
            // 
            // txtIPName
            // 
            this.txtIPName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtIPName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPName.ForeColor = System.Drawing.Color.Navy;
            this.txtIPName.Location = new System.Drawing.Point(71, 4);
            this.txtIPName.Name = "txtIPName";
            this.txtIPName.ReadOnly = true;
            this.txtIPName.Size = new System.Drawing.Size(78, 21);
            this.txtIPName.TabIndex = 2;
            this.txtIPName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plan Insp";
            // 
            // FrmQm10ListadoMetodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 532);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAddMetodoToPlan);
            this.Controls.Add(this.dgvListadoMetodos);
            this.Name = "FrmQm10ListadoMetodos";
            this.Text = "QM10 - Listado de Metodos de Inspeccion [METIP]";
            this.Load += new System.EventHandler(this.FrmQm10ListadoMetodos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoMetodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoMetodos;
        private System.Windows.Forms.BindingSource t0800CQMETODOSBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMetodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddMetodoToPlan;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckPlanActivo;
        private System.Windows.Forms.TextBox txtIplanDescription;
        private System.Windows.Forms.TextBox txtIPName;
        private System.Windows.Forms.Label label1;
    }
}