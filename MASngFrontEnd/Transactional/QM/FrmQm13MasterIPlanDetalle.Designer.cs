namespace MASngFE.Transactional.QM
{
    partial class FrmQm13MasterIPlanDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm13MasterIPlanDetalle));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddMetodo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckPlanActivo = new System.Windows.Forms.CheckBox();
            this.txtIplanDescription = new System.Windows.Forms.TextBox();
            this.txtIPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDefinicionIP = new System.Windows.Forms.DataGridView();
            this.iDPLANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mETODODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorStd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0802CQIPDEFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDocumentacionMetodo = new System.Windows.Forms.TextBox();
            this.txtTipo3 = new System.Windows.Forms.TextBox();
            this.txtTipo1 = new System.Windows.Forms.TextBox();
            this.txtTipo2 = new System.Windows.Forms.TextBox();
            this.btnUpdateMetodoPlan = new System.Windows.Forms.Button();
            this.txtObservacionMetodoPlan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit3 = new System.Windows.Forms.TextBox();
            this.txtValorMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit1 = new System.Windows.Forms.TextBox();
            this.txtValorMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdMetodoodo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnit2 = new System.Windows.Forms.TextBox();
            this.txtValorStd = new System.Windows.Forms.TextBox();
            this.txtMetodoDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreaMasterIP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToMaterial = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinicionIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0802CQIPDEFBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddMetodo
            // 
            this.btnAddMetodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMetodo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMetodo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMetodo.Image")));
            this.btnAddMetodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMetodo.Location = new System.Drawing.Point(530, 149);
            this.btnAddMetodo.Name = "btnAddMetodo";
            this.btnAddMetodo.Size = new System.Drawing.Size(102, 42);
            this.btnAddMetodo.TabIndex = 5;
            this.btnAddMetodo.Text = "Agregar\r\nMetodos";
            this.btnAddMetodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMetodo.UseVisualStyleBackColor = true;
            this.btnAddMetodo.Click += new System.EventHandler(this.BtnAddMetodo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(530, 63);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.ckPlanActivo);
            this.panel1.Controls.Add(this.txtIplanDescription);
            this.panel1.Controls.Add(this.txtIPName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 31);
            this.panel1.TabIndex = 0;
            // 
            // ckPlanActivo
            // 
            this.ckPlanActivo.AutoSize = true;
            this.ckPlanActivo.Location = new System.Drawing.Point(422, 6);
            this.ckPlanActivo.Name = "ckPlanActivo";
            this.ckPlanActivo.Size = new System.Drawing.Size(85, 19);
            this.ckPlanActivo.TabIndex = 4;
            this.ckPlanActivo.Text = "Plan Activo";
            this.ckPlanActivo.UseVisualStyleBackColor = true;
            // 
            // txtIplanDescription
            // 
            this.txtIplanDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIplanDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIplanDescription.ForeColor = System.Drawing.Color.Navy;
            this.txtIplanDescription.Location = new System.Drawing.Point(152, 4);
            this.txtIplanDescription.Name = "txtIplanDescription";
            this.txtIplanDescription.Size = new System.Drawing.Size(264, 21);
            this.txtIplanDescription.TabIndex = 3;
            // 
            // txtIPName
            // 
            this.txtIPName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            // dgvDefinicionIP
            // 
            this.dgvDefinicionIP.AllowUserToAddRows = false;
            this.dgvDefinicionIP.AllowUserToDeleteRows = false;
            this.dgvDefinicionIP.AutoGenerateColumns = false;
            this.dgvDefinicionIP.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDefinicionIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefinicionIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDPLANDataGridViewTextBoxColumn,
            this.mETODODataGridViewTextBoxColumn,
            this.ValorStd,
            this.Observacion,
            this.aCTIVODataGridViewTextBoxColumn,
            this.Eliminar});
            this.dgvDefinicionIP.DataSource = this.t0802CQIPDEFBindingSource;
            this.dgvDefinicionIP.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvDefinicionIP.Location = new System.Drawing.Point(5, 63);
            this.dgvDefinicionIP.MultiSelect = false;
            this.dgvDefinicionIP.Name = "dgvDefinicionIP";
            this.dgvDefinicionIP.ReadOnly = true;
            this.dgvDefinicionIP.RowHeadersWidth = 20;
            this.dgvDefinicionIP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefinicionIP.Size = new System.Drawing.Size(519, 169);
            this.dgvDefinicionIP.TabIndex = 1;
            this.dgvDefinicionIP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDefinicionIP_CellContentClick);
            this.dgvDefinicionIP.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDefinicionIP_CellEnter);
            // 
            // iDPLANDataGridViewTextBoxColumn
            // 
            this.iDPLANDataGridViewTextBoxColumn.DataPropertyName = "IDPLAN";
            this.iDPLANDataGridViewTextBoxColumn.HeaderText = "IDPLAN";
            this.iDPLANDataGridViewTextBoxColumn.Name = "iDPLANDataGridViewTextBoxColumn";
            this.iDPLANDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPLANDataGridViewTextBoxColumn.Visible = false;
            // 
            // mETODODataGridViewTextBoxColumn
            // 
            this.mETODODataGridViewTextBoxColumn.DataPropertyName = "METODO";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mETODODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mETODODataGridViewTextBoxColumn.HeaderText = "Metodo";
            this.mETODODataGridViewTextBoxColumn.Name = "mETODODataGridViewTextBoxColumn";
            this.mETODODataGridViewTextBoxColumn.ReadOnly = true;
            this.mETODODataGridViewTextBoxColumn.Width = 60;
            // 
            // ValorStd
            // 
            this.ValorStd.DataPropertyName = "ValorStd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            this.ValorStd.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValorStd.HeaderText = "Valor Std";
            this.ValorStd.Name = "ValorStd";
            this.ValorStd.ReadOnly = true;
            this.ValorStd.Width = 80;
            // 
            // Observacion
            // 
            this.Observacion.DataPropertyName = "Observacion";
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.Name = "Observacion";
            this.Observacion.ReadOnly = true;
            this.Observacion.Width = 220;
            // 
            // aCTIVODataGridViewTextBoxColumn
            // 
            this.aCTIVODataGridViewTextBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewTextBoxColumn.Name = "aCTIVODataGridViewTextBoxColumn";
            this.aCTIVODataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVODataGridViewTextBoxColumn.Width = 40;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Eliminar el Metodo de Inspeccion del Plan";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 60;
            // 
            // t0802CQIPDEFBindingSource
            // 
            this.t0802CQIPDEFBindingSource.DataSource = typeof(TecserEF.Entity.T0802_QMMasterIPDetail);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.txtDocumentacionMetodo);
            this.panel2.Controls.Add(this.txtTipo3);
            this.panel2.Controls.Add(this.txtTipo1);
            this.panel2.Controls.Add(this.txtTipo2);
            this.panel2.Controls.Add(this.btnUpdateMetodoPlan);
            this.panel2.Controls.Add(this.txtObservacionMetodoPlan);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtUnit3);
            this.panel2.Controls.Add(this.txtValorMax);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtUnit1);
            this.panel2.Controls.Add(this.txtValorMin);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtIdMetodoodo);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtUnit2);
            this.panel2.Controls.Add(this.txtValorStd);
            this.panel2.Controls.Add(this.txtMetodoDescripcion);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(5, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 139);
            this.panel2.TabIndex = 2;
            // 
            // txtDocumentacionMetodo
            // 
            this.txtDocumentacionMetodo.Location = new System.Drawing.Point(90, 25);
            this.txtDocumentacionMetodo.Name = "txtDocumentacionMetodo";
            this.txtDocumentacionMetodo.ReadOnly = true;
            this.txtDocumentacionMetodo.Size = new System.Drawing.Size(315, 20);
            this.txtDocumentacionMetodo.TabIndex = 28;
            this.txtDocumentacionMetodo.TabStop = false;
            this.txtDocumentacionMetodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipo3
            // 
            this.txtTipo3.Location = new System.Drawing.Point(352, 90);
            this.txtTipo3.Name = "txtTipo3";
            this.txtTipo3.ReadOnly = true;
            this.txtTipo3.Size = new System.Drawing.Size(53, 20);
            this.txtTipo3.TabIndex = 27;
            this.txtTipo3.TabStop = false;
            this.txtTipo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipo1
            // 
            this.txtTipo1.Location = new System.Drawing.Point(352, 46);
            this.txtTipo1.Name = "txtTipo1";
            this.txtTipo1.ReadOnly = true;
            this.txtTipo1.Size = new System.Drawing.Size(53, 20);
            this.txtTipo1.TabIndex = 26;
            this.txtTipo1.TabStop = false;
            this.txtTipo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipo2
            // 
            this.txtTipo2.Location = new System.Drawing.Point(352, 68);
            this.txtTipo2.Name = "txtTipo2";
            this.txtTipo2.ReadOnly = true;
            this.txtTipo2.Size = new System.Drawing.Size(53, 20);
            this.txtTipo2.TabIndex = 25;
            this.txtTipo2.TabStop = false;
            this.txtTipo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdateMetodoPlan
            // 
            this.btnUpdateMetodoPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdateMetodoPlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMetodoPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMetodoPlan.Image")));
            this.btnUpdateMetodoPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateMetodoPlan.Location = new System.Drawing.Point(411, 89);
            this.btnUpdateMetodoPlan.Name = "btnUpdateMetodoPlan";
            this.btnUpdateMetodoPlan.Size = new System.Drawing.Size(102, 42);
            this.btnUpdateMetodoPlan.TabIndex = 4;
            this.btnUpdateMetodoPlan.Text = "Actualiza\r\nValores";
            this.btnUpdateMetodoPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateMetodoPlan.UseVisualStyleBackColor = true;
            this.btnUpdateMetodoPlan.Click += new System.EventHandler(this.BtnUpdatePlan_Click);
            // 
            // txtObservacionMetodoPlan
            // 
            this.txtObservacionMetodoPlan.Location = new System.Drawing.Point(90, 112);
            this.txtObservacionMetodoPlan.Name = "txtObservacionMetodoPlan";
            this.txtObservacionMetodoPlan.Size = new System.Drawing.Size(315, 20);
            this.txtObservacionMetodoPlan.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Observacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Unit";
            // 
            // txtUnit3
            // 
            this.txtUnit3.Location = new System.Drawing.Point(313, 90);
            this.txtUnit3.Name = "txtUnit3";
            this.txtUnit3.ReadOnly = true;
            this.txtUnit3.Size = new System.Drawing.Size(37, 20);
            this.txtUnit3.TabIndex = 21;
            this.txtUnit3.TabStop = false;
            this.txtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorMax
            // 
            this.txtValorMax.Location = new System.Drawing.Point(90, 90);
            this.txtValorMax.Name = "txtValorMax";
            this.txtValorMax.Size = new System.Drawing.Size(92, 20);
            this.txtValorMax.TabIndex = 2;
            this.txtValorMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorMin_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(7, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Valor MAX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unit";
            // 
            // txtUnit1
            // 
            this.txtUnit1.Location = new System.Drawing.Point(313, 46);
            this.txtUnit1.Name = "txtUnit1";
            this.txtUnit1.ReadOnly = true;
            this.txtUnit1.Size = new System.Drawing.Size(37, 20);
            this.txtUnit1.TabIndex = 16;
            this.txtUnit1.TabStop = false;
            this.txtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorMin
            // 
            this.txtValorMin.Location = new System.Drawing.Point(90, 46);
            this.txtValorMin.Name = "txtValorMin";
            this.txtValorMin.Size = new System.Drawing.Size(92, 20);
            this.txtValorMin.TabIndex = 0;
            this.txtValorMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorMin_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(7, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Valor MIN";
            // 
            // txtIdMetodoodo
            // 
            this.txtIdMetodoodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdMetodoodo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtIdMetodoodo.Location = new System.Drawing.Point(90, 4);
            this.txtIdMetodoodo.Name = "txtIdMetodoodo";
            this.txtIdMetodoodo.ReadOnly = true;
            this.txtIdMetodoodo.Size = new System.Drawing.Size(92, 20);
            this.txtIdMetodoodo.TabIndex = 12;
            this.txtIdMetodoodo.TabStop = false;
            this.txtIdMetodoodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(281, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Unit";
            // 
            // txtUnit2
            // 
            this.txtUnit2.Location = new System.Drawing.Point(313, 68);
            this.txtUnit2.Name = "txtUnit2";
            this.txtUnit2.ReadOnly = true;
            this.txtUnit2.Size = new System.Drawing.Size(37, 20);
            this.txtUnit2.TabIndex = 10;
            this.txtUnit2.TabStop = false;
            this.txtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorStd
            // 
            this.txtValorStd.BackColor = System.Drawing.Color.Aquamarine;
            this.txtValorStd.Location = new System.Drawing.Point(90, 68);
            this.txtValorStd.Name = "txtValorStd";
            this.txtValorStd.Size = new System.Drawing.Size(92, 20);
            this.txtValorStd.TabIndex = 1;
            this.txtValorStd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorStd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorMin_KeyPress);
            // 
            // txtMetodoDescripcion
            // 
            this.txtMetodoDescripcion.Location = new System.Drawing.Point(184, 4);
            this.txtMetodoDescripcion.Name = "txtMetodoDescripcion";
            this.txtMetodoDescripcion.ReadOnly = true;
            this.txtMetodoDescripcion.Size = new System.Drawing.Size(221, 20);
            this.txtMetodoDescripcion.TabIndex = 2;
            this.txtMetodoDescripcion.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(7, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Valor STD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Metodo";
            // 
            // btnCreaMasterIP
            // 
            this.btnCreaMasterIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreaMasterIP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreaMasterIP.Image = ((System.Drawing.Image)(resources.GetObject("btnCreaMasterIP.Image")));
            this.btnCreaMasterIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreaMasterIP.Location = new System.Drawing.Point(530, 106);
            this.btnCreaMasterIP.Name = "btnCreaMasterIP";
            this.btnCreaMasterIP.Size = new System.Drawing.Size(102, 42);
            this.btnCreaMasterIP.TabIndex = 4;
            this.btnCreaMasterIP.Text = "Crear\r\nMaster IP";
            this.btnCreaMasterIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreaMasterIP.UseVisualStyleBackColor = true;
            this.btnCreaMasterIP.Click += new System.EventHandler(this.BtnSavePlan_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "METODOS DE INSPECCION INCLUIDOS EN EL PLAN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddToMaterial
            // 
            this.btnAddToMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddToMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToMaterial.Image")));
            this.btnAddToMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToMaterial.Location = new System.Drawing.Point(530, 192);
            this.btnAddToMaterial.Name = "btnAddToMaterial";
            this.btnAddToMaterial.Size = new System.Drawing.Size(102, 42);
            this.btnAddToMaterial.TabIndex = 6;
            this.btnAddToMaterial.Text = "Asignar A\r\nMaterial\r\n";
            this.btnAddToMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToMaterial.UseVisualStyleBackColor = true;
            this.btnAddToMaterial.Click += new System.EventHandler(this.BtnAddToMaterial_Click);
            // 
            // FrmQm13MasterIPlanDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 379);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddToMaterial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreaMasterIP);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDefinicionIP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddMetodo);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmQm13MasterIPlanDetalle";
            this.Text = "QM13 - Detalle de Plan de Inspeccion Maestro [MIP]";
            this.Load += new System.EventHandler(this.FrmQM03IPDef_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinicionIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0802CQIPDEFBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddMetodo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIplanDescription;
        private System.Windows.Forms.TextBox txtIPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckPlanActivo;
        private System.Windows.Forms.DataGridView dgvDefinicionIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORSTD1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORSTD2DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0802CQIPDEFBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtIdMetodoodo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUnit2;
        private System.Windows.Forms.TextBox txtValorStd;
        private System.Windows.Forms.TextBox txtMetodoDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdateMetodoPlan;
        private System.Windows.Forms.Button btnCreaMasterIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacionMetodoPlan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnit3;
        private System.Windows.Forms.TextBox txtValorMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnit1;
        private System.Windows.Forms.TextBox txtValorMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipo3;
        private System.Windows.Forms.TextBox txtTipo1;
        private System.Windows.Forms.TextBox txtTipo2;
        private System.Windows.Forms.TextBox txtDocumentacionMetodo;
        private System.Windows.Forms.Button btnAddToMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPLANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mETODODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}