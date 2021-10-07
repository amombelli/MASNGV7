namespace MASngFE.Transactional.PP
{
    partial class FrmPP18UpdateKgFabricar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP18UpdateKgFabricar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaterialEtiqueta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialFab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtClienteOriginal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOVnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMotivoFabricacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtKgRevisado = new TSControls.CtlTextBox();
            this.txtObservacionPlan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKgIngresoPlan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.T0070Bs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPf = new System.Windows.Forms.DataGridView();
            this.iDPLANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGFABRICARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGFABRICARODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLANPARADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFusion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0070Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPf)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(670, 51);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 44);
            this.btnActualizar.TabIndex = 34;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(670, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.txtMaterialEtiqueta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaterialFab);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 77);
            this.panel1.TabIndex = 35;
            // 
            // txtMaterialEtiqueta
            // 
            this.txtMaterialEtiqueta.Location = new System.Drawing.Point(131, 50);
            this.txtMaterialEtiqueta.Name = "txtMaterialEtiqueta";
            this.txtMaterialEtiqueta.ReadOnly = true;
            this.txtMaterialEtiqueta.Size = new System.Drawing.Size(156, 22);
            this.txtMaterialEtiqueta.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Material Etiqueta";
            // 
            // txtMaterialFab
            // 
            this.txtMaterialFab.Location = new System.Drawing.Point(131, 27);
            this.txtMaterialFab.Name = "txtMaterialFab";
            this.txtMaterialFab.ReadOnly = true;
            this.txtMaterialFab.Size = new System.Drawing.Size(156, 22);
            this.txtMaterialFab.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Fabricar";
            // 
            // txtOF
            // 
            this.txtOF.Location = new System.Drawing.Point(131, 4);
            this.txtOF.Name = "txtOF";
            this.txtOF.ReadOnly = true;
            this.txtOF.Size = new System.Drawing.Size(91, 22);
            this.txtOF.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden Fabricacion #";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtClienteOriginal);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtOVnum);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtMotivoFabricacion);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 54);
            this.panel2.TabIndex = 36;
            // 
            // txtClienteOriginal
            // 
            this.txtClienteOriginal.Location = new System.Drawing.Point(300, 27);
            this.txtClienteOriginal.Name = "txtClienteOriginal";
            this.txtClienteOriginal.ReadOnly = true;
            this.txtClienteOriginal.Size = new System.Drawing.Size(356, 22);
            this.txtClienteOriginal.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cliente Original";
            // 
            // txtOVnum
            // 
            this.txtOVnum.Location = new System.Drawing.Point(131, 27);
            this.txtOVnum.Name = "txtOVnum";
            this.txtOVnum.ReadOnly = true;
            this.txtOVnum.Size = new System.Drawing.Size(67, 22);
            this.txtOVnum.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Orden de Venta";
            // 
            // txtMotivoFabricacion
            // 
            this.txtMotivoFabricacion.Location = new System.Drawing.Point(131, 4);
            this.txtMotivoFabricacion.Name = "txtMotivoFabricacion";
            this.txtMotivoFabricacion.ReadOnly = true;
            this.txtMotivoFabricacion.Size = new System.Drawing.Size(91, 22);
            this.txtMotivoFabricacion.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Motivo Fabricacion";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.txtKgRevisado);
            this.panel3.Controls.Add(this.txtObservacionPlan);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtKgIngresoPlan);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(661, 77);
            this.panel3.TabIndex = 37;
            // 
            // txtKgRevisado
            // 
            this.txtKgRevisado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtKgRevisado.BackColor = System.Drawing.Color.PaleGreen;
            this.txtKgRevisado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgRevisado.ForeColor = System.Drawing.Color.Navy;
            this.txtKgRevisado.Location = new System.Drawing.Point(160, 27);
            this.txtKgRevisado.Name = "txtKgRevisado";
            this.txtKgRevisado.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.txtKgRevisado.SetDecimales = 2;
            this.txtKgRevisado.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.txtKgRevisado.Size = new System.Drawing.Size(86, 22);
            this.txtKgRevisado.TabIndex = 8;
           this.txtKgRevisado.ValorMaximo = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.txtKgRevisado.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtKgRevisado.XReadOnly = false;
            // 
            // txtObservacionPlan
            // 
            this.txtObservacionPlan.Location = new System.Drawing.Point(160, 50);
            this.txtObservacionPlan.Name = "txtObservacionPlan";
            this.txtObservacionPlan.Size = new System.Drawing.Size(356, 22);
            this.txtObservacionPlan.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Observacion PF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "KG Planificacion Revisada";
            // 
            // txtKgIngresoPlan
            // 
            this.txtKgIngresoPlan.Location = new System.Drawing.Point(160, 4);
            this.txtKgIngresoPlan.Name = "txtKgIngresoPlan";
            this.txtKgIngresoPlan.ReadOnly = true;
            this.txtKgIngresoPlan.Size = new System.Drawing.Size(86, 22);
            this.txtKgIngresoPlan.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "KG Ingreso Plan";
            // 
            // T0070Bs
            // 
            this.T0070Bs.DataSource = typeof(TecserEF.Entity.T0070_PLANPRODUCCION);
            // 
            // dgvPf
            // 
            this.dgvPf.AllowUserToAddRows = false;
            this.dgvPf.AllowUserToDeleteRows = false;
            this.dgvPf.AutoGenerateColumns = false;
            this.dgvPf.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDPLANDataGridViewTextBoxColumn,
            this.kGFABRICARDataGridViewTextBoxColumn,
            this.kGFABRICARODataGridViewTextBoxColumn,
            this.pLANPARADataGridViewTextBoxColumn,
            this.sTATUSDataGridViewTextBoxColumn,
            this.btnFusion});
            this.dgvPf.DataSource = this.T0070Bs;
            this.dgvPf.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPf.Location = new System.Drawing.Point(3, 247);
            this.dgvPf.MultiSelect = false;
            this.dgvPf.Name = "dgvPf";
            this.dgvPf.ReadOnly = true;
            this.dgvPf.RowHeadersWidth = 20;
            this.dgvPf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPf.Size = new System.Drawing.Size(440, 258);
            this.dgvPf.TabIndex = 38;
            this.dgvPf.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPf_CellContentClick);
            // 
            // iDPLANDataGridViewTextBoxColumn
            // 
            this.iDPLANDataGridViewTextBoxColumn.DataPropertyName = "IDPLAN";
            this.iDPLANDataGridViewTextBoxColumn.HeaderText = "OF#";
            this.iDPLANDataGridViewTextBoxColumn.Name = "iDPLANDataGridViewTextBoxColumn";
            this.iDPLANDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPLANDataGridViewTextBoxColumn.Width = 60;
            // 
            // kGFABRICARDataGridViewTextBoxColumn
            // 
            this.kGFABRICARDataGridViewTextBoxColumn.DataPropertyName = "KG_FABRICAR";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kGFABRICARDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.kGFABRICARDataGridViewTextBoxColumn.HeaderText = "KG";
            this.kGFABRICARDataGridViewTextBoxColumn.Name = "kGFABRICARDataGridViewTextBoxColumn";
            this.kGFABRICARDataGridViewTextBoxColumn.ReadOnly = true;
            this.kGFABRICARDataGridViewTextBoxColumn.Width = 60;
            // 
            // kGFABRICARODataGridViewTextBoxColumn
            // 
            this.kGFABRICARODataGridViewTextBoxColumn.DataPropertyName = "KG_FABRICAR_O";
            this.kGFABRICARODataGridViewTextBoxColumn.HeaderText = "KGOri";
            this.kGFABRICARODataGridViewTextBoxColumn.Name = "kGFABRICARODataGridViewTextBoxColumn";
            this.kGFABRICARODataGridViewTextBoxColumn.ReadOnly = true;
            this.kGFABRICARODataGridViewTextBoxColumn.Width = 60;
            // 
            // pLANPARADataGridViewTextBoxColumn
            // 
            this.pLANPARADataGridViewTextBoxColumn.DataPropertyName = "PLANPARA";
            this.pLANPARADataGridViewTextBoxColumn.HeaderText = "PlanPara";
            this.pLANPARADataGridViewTextBoxColumn.Name = "pLANPARADataGridViewTextBoxColumn";
            this.pLANPARADataGridViewTextBoxColumn.ReadOnly = true;
            this.pLANPARADataGridViewTextBoxColumn.Width = 70;
            // 
            // sTATUSDataGridViewTextBoxColumn
            // 
            this.sTATUSDataGridViewTextBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.Name = "sTATUSDataGridViewTextBoxColumn";
            this.sTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnFusion
            // 
            this.btnFusion.HeaderText = "FUSION";
            this.btnFusion.Name = "btnFusion";
            this.btnFusion.ReadOnly = true;
            this.btnFusion.Text = "FUSION";
            this.btnFusion.ToolTipText = "Cancelar esta linea y agregarla a la OF editada";
            this.btnFusion.UseColumnTextForButtonValue = true;
            this.btnFusion.Width = 60;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(3, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(440, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "OTRAS ORDENES DE FABRICACION EN ESTADO MANEJABLE";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPP18UpdateKgFabricar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(775, 529);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvPf);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmPP18UpdateKgFabricar";
            this.Text = "PP18 - Actualizar KG a Fabricar";
            this.Load += new System.EventHandler(this.FrmPP18UpdateKgFabricar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0070Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaterialFab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterialEtiqueta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtClienteOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOVnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMotivoFabricacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtObservacionPlan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKgIngresoPlan;
        private System.Windows.Forms.Label label9;
        private TSControls.CtlTextBox txtKgRevisado;
        private System.Windows.Forms.BindingSource T0070Bs;
        private System.Windows.Forms.DataGridView dgvPf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPLANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGFABRICARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGFABRICARODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLANPARADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnFusion;
    }
}