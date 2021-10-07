namespace MASngFE.Transactional.QM
{
    partial class FrmQm04IpList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAnalisis = new System.Windows.Forms.DataGridView();
            this.iDIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaINPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CQResp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0810CQHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPlanInspeccionMaster = new System.Windows.Forms.Button();
            this.btnSalirOP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddInspeccionManual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0810CQHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnalisis
            // 
            this.dgvAnalisis.AllowUserToAddRows = false;
            this.dgvAnalisis.AllowUserToDeleteRows = false;
            this.dgvAnalisis.AutoGenerateColumns = false;
            this.dgvAnalisis.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDIDataGridViewTextBoxColumn,
            this.mATERIALDataGridViewTextBoxColumn,
            this.PlanName,
            this.lOTEDataGridViewTextBoxColumn,
            this.KG,
            this.Origen,
            this.IdOrigen,
            this.NombreProv,
            this.EstadoMaterial,
            this.EstadoPlan,
            this.FechaINPlan,
            this.CQResp,
            this.cOMENTARIODataGridViewTextBoxColumn,
            this.Ver});
            this.dgvAnalisis.DataSource = this.t0810CQHBindingSource;
            this.dgvAnalisis.GridColor = System.Drawing.Color.Navy;
            this.dgvAnalisis.Location = new System.Drawing.Point(5, 76);
            this.dgvAnalisis.MultiSelect = false;
            this.dgvAnalisis.Name = "dgvAnalisis";
            this.dgvAnalisis.ReadOnly = true;
            this.dgvAnalisis.RowHeadersWidth = 20;
            this.dgvAnalisis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalisis.Size = new System.Drawing.Size(1294, 421);
            this.dgvAnalisis.TabIndex = 0;
            this.dgvAnalisis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAnalisis_CellContentClick);
            // 
            // iDIDataGridViewTextBoxColumn
            // 
            this.iDIDataGridViewTextBoxColumn.DataPropertyName = "IDI";
            this.iDIDataGridViewTextBoxColumn.HeaderText = "ID#";
            this.iDIDataGridViewTextBoxColumn.Name = "iDIDataGridViewTextBoxColumn";
            this.iDIDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDIDataGridViewTextBoxColumn.Width = 50;
            // 
            // mATERIALDataGridViewTextBoxColumn
            // 
            this.mATERIALDataGridViewTextBoxColumn.DataPropertyName = "MATERIAL";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mATERIALDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mATERIALDataGridViewTextBoxColumn.HeaderText = "Material";
            this.mATERIALDataGridViewTextBoxColumn.Name = "mATERIALDataGridViewTextBoxColumn";
            this.mATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            this.mATERIALDataGridViewTextBoxColumn.Width = 80;
            // 
            // PlanName
            // 
            this.PlanName.DataPropertyName = "PlanName";
            this.PlanName.HeaderText = "IPlan";
            this.PlanName.Name = "PlanName";
            this.PlanName.ReadOnly = true;
            this.PlanName.Width = 50;
            // 
            // lOTEDataGridViewTextBoxColumn
            // 
            this.lOTEDataGridViewTextBoxColumn.DataPropertyName = "LOTE";
            this.lOTEDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.lOTEDataGridViewTextBoxColumn.Name = "lOTEDataGridViewTextBoxColumn";
            this.lOTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lOTEDataGridViewTextBoxColumn.Width = 90;
            // 
            // KG
            // 
            this.KG.DataPropertyName = "KG";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KG.DefaultCellStyle = dataGridViewCellStyle5;
            this.KG.HeaderText = "KG";
            this.KG.Name = "KG";
            this.KG.ReadOnly = true;
            this.KG.Width = 60;
            // 
            // Origen
            // 
            this.Origen.DataPropertyName = "Origen";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Origen.DefaultCellStyle = dataGridViewCellStyle6;
            this.Origen.HeaderText = "Ori";
            this.Origen.Name = "Origen";
            this.Origen.ReadOnly = true;
            this.Origen.Width = 30;
            // 
            // IdOrigen
            // 
            this.IdOrigen.DataPropertyName = "IdOrigen";
            this.IdOrigen.HeaderText = "Ref#";
            this.IdOrigen.Name = "IdOrigen";
            this.IdOrigen.ReadOnly = true;
            this.IdOrigen.Width = 55;
            // 
            // NombreProv
            // 
            this.NombreProv.DataPropertyName = "NombreProv";
            this.NombreProv.HeaderText = "Identificacion";
            this.NombreProv.Name = "NombreProv";
            this.NombreProv.ReadOnly = true;
            this.NombreProv.Width = 180;
            // 
            // EstadoMaterial
            // 
            this.EstadoMaterial.DataPropertyName = "EstadoMaterial";
            this.EstadoMaterial.HeaderText = "EstadoMaterial";
            this.EstadoMaterial.Name = "EstadoMaterial";
            this.EstadoMaterial.ReadOnly = true;
            // 
            // EstadoPlan
            // 
            this.EstadoPlan.DataPropertyName = "EstadoPlan";
            this.EstadoPlan.HeaderText = "EstadoPlan";
            this.EstadoPlan.Name = "EstadoPlan";
            this.EstadoPlan.ReadOnly = true;
            this.EstadoPlan.Width = 80;
            // 
            // FechaINPlan
            // 
            this.FechaINPlan.DataPropertyName = "FechaINPlan";
            this.FechaINPlan.HeaderText = "FechaINPlan";
            this.FechaINPlan.Name = "FechaINPlan";
            this.FechaINPlan.ReadOnly = true;
            // 
            // CQResp
            // 
            this.CQResp.DataPropertyName = "CQResp";
            this.CQResp.HeaderText = "CQResp";
            this.CQResp.Name = "CQResp";
            this.CQResp.ReadOnly = true;
            // 
            // cOMENTARIODataGridViewTextBoxColumn
            // 
            this.cOMENTARIODataGridViewTextBoxColumn.DataPropertyName = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.cOMENTARIODataGridViewTextBoxColumn.Name = "cOMENTARIODataGridViewTextBoxColumn";
            this.cOMENTARIODataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMENTARIODataGridViewTextBoxColumn.Width = 150;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Accion";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Text = "Detalle";
            this.Ver.ToolTipText = "Ver Detalle del Plan Seleccionado";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 60;
            // 
            // t0810CQHBindingSource
            // 
            this.t0810CQHBindingSource.DataSource = typeof(TecserEF.Entity.T0810_QMHeaderData);
            // 
            // btnPlanInspeccionMaster
            // 
            this.btnPlanInspeccionMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlanInspeccionMaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanInspeccionMaster.Image = global::MASngFE.Properties.Resources.investigacion;
            this.btnPlanInspeccionMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanInspeccionMaster.Location = new System.Drawing.Point(1317, 58);
            this.btnPlanInspeccionMaster.Name = "btnPlanInspeccionMaster";
            this.btnPlanInspeccionMaster.Size = new System.Drawing.Size(100, 40);
            this.btnPlanInspeccionMaster.TabIndex = 60;
            this.btnPlanInspeccionMaster.Text = "Master\r\nInspPlan";
            this.btnPlanInspeccionMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanInspeccionMaster.UseVisualStyleBackColor = true;
            this.btnPlanInspeccionMaster.Click += new System.EventHandler(this.BtnPlanInspeccionMaster_Click);
            // 
            // btnSalirOP
            // 
            this.btnSalirOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalirOP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirOP.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalirOP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirOP.Location = new System.Drawing.Point(1317, 12);
            this.btnSalirOP.Name = "btnSalirOP";
            this.btnSalirOP.Size = new System.Drawing.Size(100, 40);
            this.btnSalirOP.TabIndex = 59;
            this.btnSalirOP.Text = "Salir";
            this.btnSalirOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalirOP.UseVisualStyleBackColor = true;
            this.btnSalirOP.Click += new System.EventHandler(this.BtnSalirOP_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::MASngFE.Properties.Resources.investigacion;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1317, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 63;
            this.button1.Text = "Metodo\r\nInspeccion";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnAddInspeccionManual
            // 
            this.btnAddInspeccionManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddInspeccionManual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInspeccionManual.Image = global::MASngFE.Properties.Resources.quimica;
            this.btnAddInspeccionManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddInspeccionManual.Location = new System.Drawing.Point(12, 7);
            this.btnAddInspeccionManual.Name = "btnAddInspeccionManual";
            this.btnAddInspeccionManual.Size = new System.Drawing.Size(118, 51);
            this.btnAddInspeccionManual.TabIndex = 64;
            this.btnAddInspeccionManual.Text = "Agregar  \r\nRegistro\r\nManual";
            this.btnAddInspeccionManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddInspeccionManual.UseVisualStyleBackColor = true;
            this.btnAddInspeccionManual.Click += new System.EventHandler(this.BtnAddInspeccionManual_Click);
            // 
            // FrmQm04IpList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 602);
            this.Controls.Add(this.btnAddInspeccionManual);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPlanInspeccionMaster);
            this.Controls.Add(this.btnSalirOP);
            this.Controls.Add(this.dgvAnalisis);
            this.Name = "FrmQm04IpList";
            this.Text = "QM04 - Control de Calidad - QM Analisis";
            this.Load += new System.EventHandler(this.FrmQMAnalisis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0810CQHBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnalisis;
        private System.Windows.Forms.BindingSource t0810CQHBindingSource;
        private System.Windows.Forms.Button btnSalirOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDEFINEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGRECIBIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uBICACIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROVEEDORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHARECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSTADORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSTADOIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHASTARTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAFINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQUSERDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnPlanInspeccionMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaINPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CQResp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMENTARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddInspeccionManual;
    }
}