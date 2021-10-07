namespace MASngFE.Transactional.QM
{
    partial class FrmQm12ListaMasterInspPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm12ListaMasterInspPlan));
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvIP = new System.Windows.Forms.DataGridView();
            this.iDPLANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0801CQIPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnSavePlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0801CQIPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(569, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.TabIndex = 59;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // dgvIP
            // 
            this.dgvIP.AllowUserToAddRows = false;
            this.dgvIP.AllowUserToDeleteRows = false;
            this.dgvIP.AutoGenerateColumns = false;
            this.dgvIP.BackgroundColor = System.Drawing.Color.White;
            this.dgvIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDPLANDataGridViewTextBoxColumn,
            this.dESCRIPCIONDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewTextBoxColumn,
            this.FechaCreacion,
            this.LogUser,
            this.Detalle});
            this.dgvIP.DataSource = this.t0801CQIPBindingSource;
            this.dgvIP.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvIP.Location = new System.Drawing.Point(3, 23);
            this.dgvIP.Name = "dgvIP";
            this.dgvIP.ReadOnly = true;
            this.dgvIP.RowHeadersWidth = 20;
            this.dgvIP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIP.Size = new System.Drawing.Size(556, 494);
            this.dgvIP.TabIndex = 62;
            this.dgvIP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIP_CellContentClick);
            // 
            // iDPLANDataGridViewTextBoxColumn
            // 
            this.iDPLANDataGridViewTextBoxColumn.DataPropertyName = "IDPLAN";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            this.iDPLANDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iDPLANDataGridViewTextBoxColumn.HeaderText = "IP";
            this.iDPLANDataGridViewTextBoxColumn.Name = "iDPLANDataGridViewTextBoxColumn";
            this.iDPLANDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPLANDataGridViewTextBoxColumn.ToolTipText = "Nombre del Plan Maestro";
            this.iDPLANDataGridViewTextBoxColumn.Width = 60;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.dESCRIPCIONDataGridViewTextBoxColumn.Name = "dESCRIPCIONDataGridViewTextBoxColumn";
            this.dESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCRIPCIONDataGridViewTextBoxColumn.Width = 150;
            // 
            // aCTIVODataGridViewTextBoxColumn
            // 
            this.aCTIVODataGridViewTextBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewTextBoxColumn.Name = "aCTIVODataGridViewTextBoxColumn";
            this.aCTIVODataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVODataGridViewTextBoxColumn.Width = 50;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaCreacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaCreacion.HeaderText = "Creacion";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            // 
            // LogUser
            // 
            this.LogUser.DataPropertyName = "LogUser";
            this.LogUser.HeaderText = "Usuario";
            this.LogUser.Name = "LogUser";
            this.LogUser.ReadOnly = true;
            // 
            // Detalle
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Detalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "Detalle";
            this.Detalle.ToolTipText = "Visualizar Detalles de IP";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 60;
            // 
            // t0801CQIPBindingSource
            // 
            this.t0801CQIPBindingSource.DataSource = typeof(TecserEF.Entity.T0801_QMMasterIPHeader);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(556, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "LISTADO DE PLANES DE INSPECCION MAESTRO [MIP]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSavePlan
            // 
            this.btnSavePlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSavePlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePlan.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePlan.Image")));
            this.btnSavePlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePlan.Location = new System.Drawing.Point(569, 50);
            this.btnSavePlan.Name = "btnSavePlan";
            this.btnSavePlan.Size = new System.Drawing.Size(102, 42);
            this.btnSavePlan.TabIndex = 65;
            this.btnSavePlan.Text = "Crear\r\nMaster IP";
            this.btnSavePlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePlan.UseVisualStyleBackColor = true;
            this.btnSavePlan.Click += new System.EventHandler(this.BtnSavePlan_Click);
            // 
            // FrmQm12ListaMasterInspPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 524);
            this.ControlBox = false;
            this.Controls.Add(this.btnSavePlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvIP);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmQm12ListaMasterInspPlan";
            this.Text = "QM12 - Listado de Planes de Inspeccion Maestro [MIP]";
            this.Load += new System.EventHandler(this.FrmQM02ListaIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0801CQIPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvIP;
        private System.Windows.Forms.BindingSource t0801CQIPBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPLANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogUser;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
        private System.Windows.Forms.Button btnSavePlan;
    }
}