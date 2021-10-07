namespace MASngFE.Transactional.QM
{
    partial class FrmQm06AddMetodoToPlan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListaMetodo = new System.Windows.Forms.DataGridView();
            this.IdMetodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0800CQMETODOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.txtPlanName);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 30);
            this.panel1.TabIndex = 1;
            // 
            // txtPlanName
            // 
            this.txtPlanName.Location = new System.Drawing.Point(299, 4);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.ReadOnly = true;
            this.txtPlanName.Size = new System.Drawing.Size(96, 20);
            this.txtPlanName.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(219, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Plan Name";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(63, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(53, 20);
            this.txtIP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP#";
            // 
            // dgvListaMetodo
            // 
            this.dgvListaMetodo.AllowUserToAddRows = false;
            this.dgvListaMetodo.AllowUserToDeleteRows = false;
            this.dgvListaMetodo.AutoGenerateColumns = false;
            this.dgvListaMetodo.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvListaMetodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMetodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMetodoDataGridViewTextBoxColumn,
            this.valorUnitDataGridViewTextBoxColumn,
            this.valorTypeDataGridViewTextBoxColumn,
            this.Agregar});
            this.dgvListaMetodo.DataSource = this.t0800CQMETODOSBindingSource;
            this.dgvListaMetodo.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvListaMetodo.Location = new System.Drawing.Point(3, 40);
            this.dgvListaMetodo.Name = "dgvListaMetodo";
            this.dgvListaMetodo.ReadOnly = true;
            this.dgvListaMetodo.RowHeadersWidth = 15;
            this.dgvListaMetodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaMetodo.Size = new System.Drawing.Size(401, 377);
            this.dgvListaMetodo.TabIndex = 2;
            this.dgvListaMetodo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaMetodo_CellContentClick);
            // 
            // IdMetodoDataGridViewTextBoxColumn
            // 
            this.IdMetodoDataGridViewTextBoxColumn.DataPropertyName = "IdMetodo";
            this.IdMetodoDataGridViewTextBoxColumn.HeaderText = "IdMetodo";
            this.IdMetodoDataGridViewTextBoxColumn.Name = "IdMetodoDataGridViewTextBoxColumn";
            this.IdMetodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdMetodoDataGridViewTextBoxColumn.Width = 50;
            // 
            // valorUnitDataGridViewTextBoxColumn
            // 
            this.valorUnitDataGridViewTextBoxColumn.DataPropertyName = "ValorUnit";
            this.valorUnitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.valorUnitDataGridViewTextBoxColumn.Name = "valorUnitDataGridViewTextBoxColumn";
            this.valorUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorUnitDataGridViewTextBoxColumn.Width = 40;
            // 
            // valorTypeDataGridViewTextBoxColumn
            // 
            this.valorTypeDataGridViewTextBoxColumn.DataPropertyName = "ValorType";
            this.valorTypeDataGridViewTextBoxColumn.HeaderText = "DType";
            this.valorTypeDataGridViewTextBoxColumn.Name = "valorTypeDataGridViewTextBoxColumn";
            this.valorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorTypeDataGridViewTextBoxColumn.Width = 45;
            // 
            // Agregar
            // 
            this.Agregar.DataPropertyName = "IdMetodo";
            this.Agregar.HeaderText = "Agregar";
            this.Agregar.Name = "Agregar";
            this.Agregar.ReadOnly = true;
            this.Agregar.Text = "Add";
            this.Agregar.ToolTipText = "Agregar el Método al Plan";
            this.Agregar.UseColumnTextForButtonValue = true;
            this.Agregar.Width = 60;
            // 
            // t0800CQMETODOSBindingSource
            // 
            this.t0800CQMETODOSBindingSource.DataSource = typeof(TecserEF.Entity.T0800_QMMetodosInspeccion);
            // 
            // FrmQm06AddMetodoToPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 423);
            this.Controls.Add(this.dgvListaMetodo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQm06AddMetodoToPlan";
            this.Text = "QM06 - Agregar un Metodo al Plan";
            this.Load += new System.EventHandler(this.FrmQm06AddMetodoToPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0800CQMETODOSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaMetodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMetodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Agregar;
        private System.Windows.Forms.BindingSource t0800CQMETODOSBindingSource;
    }
}