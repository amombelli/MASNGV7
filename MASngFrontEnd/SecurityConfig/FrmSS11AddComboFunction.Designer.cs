namespace MASngFE.SecurityConfig
{
    partial class FrmSS11AddComboFunction
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.t0091HHRRCOMBOCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t0092HHRRCOMBOASSIGNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNombreFuncion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnAddEmpleado = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cicon2 = new TSControls.CtlIconos();
            this.cicon1 = new TSControls.CtlIconos();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTcode = new System.Windows.Forms.TextBox();
            this.@__2Shortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__2Funcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__2Valor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__2BtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0091HHRRCOMBOCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0092HHRRCOMBOASSIGNBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 633);
            this.label4.TabIndex = 329;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1109, 3);
            this.label2.TabIndex = 328;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1003, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 41);
            this.btnSalir.TabIndex = 330;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__code,
            this.@__Descripcion});
            this.dgv1.DataSource = this.t0091HHRRCOMBOCODEBindingSource;
            this.dgv1.GridColor = System.Drawing.Color.Navy;
            this.dgv1.Location = new System.Drawing.Point(10, 79);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 20;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(579, 554);
            this.dgv1.TabIndex = 331;
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // t0091HHRRCOMBOCODEBindingSource
            // 
            this.t0091HHRRCOMBOCODEBindingSource.DataSource = typeof(TecserEF.Entity.T0091_HHRR_COMBOCODE);
            // 
            // t0092HHRRCOMBOASSIGNBindingSource
            // 
            this.t0092HHRRCOMBOASSIGNBindingSource.DataSource = typeof(TecserEF.Entity.T0092_HHRR_COMBOASSIGN);
            // 
            // txtNombreFuncion
            // 
            this.txtNombreFuncion.Location = new System.Drawing.Point(85, 8);
            this.txtNombreFuncion.MaxLength = 20;
            this.txtNombreFuncion.Name = "txtNombreFuncion";
            this.txtNombreFuncion.Size = new System.Drawing.Size(145, 21);
            this.txtNombreFuncion.TabIndex = 332;
            this.txtNombreFuncion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreFuncion_Validating);
            this.txtNombreFuncion.Validated += new System.EventHandler(this.txtNombreFuncion_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 333;
            this.label1.Text = "Funcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 335;
            this.label3.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(85, 30);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(355, 21);
            this.txtDescripcion.TabIndex = 334;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTcode);
            this.panel1.Controls.Add(this.cicon1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNombreFuncion);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Location = new System.Drawing.Point(10, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 61);
            this.panel1.TabIndex = 336;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1003, 91);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 41);
            this.btnUpdate.TabIndex = 337;
            this.btnUpdate.Text = "Guardar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1003, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 41);
            this.btnAdd.TabIndex = 338;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(1109, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 633);
            this.label5.TabIndex = 339;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(3, 636);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1109, 3);
            this.label6.TabIndex = 340;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AutoGenerateColumns = false;
            this.dgv2.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__2Shortname,
            this.@__2Funcion,
            this.@__2Valor,
            this.@__2BtnDel});
            this.dgv2.DataSource = this.t0092HHRRCOMBOASSIGNBindingSource;
            this.dgv2.GridColor = System.Drawing.Color.Navy;
            this.dgv2.Location = new System.Drawing.Point(696, 231);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersWidth = 20;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(266, 401);
            this.dgv2.TabIndex = 341;
            this.dgv2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 337;
            this.label7.Text = "Empleado";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(93, 15);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(172, 23);
            this.cmbEmpleado.TabIndex = 342;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            this.cmbEmpleado.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpleado_Validating);
            // 
            // btnAddEmpleado
            // 
            this.btnAddEmpleado.Location = new System.Drawing.Point(302, 6);
            this.btnAddEmpleado.Name = "btnAddEmpleado";
            this.btnAddEmpleado.Size = new System.Drawing.Size(100, 41);
            this.btnAddEmpleado.TabIndex = 343;
            this.btnAddEmpleado.Text = "Agregar Empleado";
            this.btnAddEmpleado.UseVisualStyleBackColor = true;
            this.btnAddEmpleado.Click += new System.EventHandler(this.btnAddEmpleado_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cicon2);
            this.panel2.Controls.Add(this.btnAddEmpleado);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbEmpleado);
            this.panel2.Location = new System.Drawing.Point(696, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 55);
            this.panel2.TabIndex = 344;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ComboCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo Funcion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Nombre de la Funcion";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DescripcionPermiso";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion - Uso";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Descripcion de la Funcion / Uso";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Shortname";
            this.dataGridViewTextBoxColumn3.HeaderText = "Shortname";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ComboCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "ComboCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // __code
            // 
            this.@__code.DataPropertyName = "ComboCode";
            this.@__code.HeaderText = "Codigo Funcion";
            this.@__code.Name = "__code";
            this.@__code.ReadOnly = true;
            this.@__code.ToolTipText = "Nombre de la Funcion";
            this.@__code.Width = 120;
            // 
            // __Descripcion
            // 
            this.@__Descripcion.DataPropertyName = "DescripcionPermiso";
            this.@__Descripcion.HeaderText = "Descripcion - Uso";
            this.@__Descripcion.Name = "__Descripcion";
            this.@__Descripcion.ReadOnly = true;
            this.@__Descripcion.ToolTipText = "Descripcion de la Funcion / Uso";
            this.@__Descripcion.Width = 300;
            // 
            // cicon2
            // 
            this.cicon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cicon2.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cicon2.IconSize = TSControls.TamañoIcono.Chico;
            this.cicon2.Location = new System.Drawing.Point(271, 18);
            this.cicon2.Name = "cicon2";
            this.cicon2.Set = TSControls.CIconos.ExclamacionYellow;
            this.cicon2.Size = new System.Drawing.Size(16, 23);
            this.cicon2.TabIndex = 337;
            // 
            // cicon1
            // 
            this.cicon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cicon1.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cicon1.IconSize = TSControls.TamañoIcono.Chico;
            this.cicon1.Location = new System.Drawing.Point(236, 10);
            this.cicon1.Name = "cicon1";
            this.cicon1.Set = TSControls.CIconos.ExclamacionYellow;
            this.cicon1.Size = new System.Drawing.Size(16, 17);
            this.cicon1.TabIndex = 336;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 338;
            this.label8.Text = "TCODE";
            // 
            // txtTcode
            // 
            this.txtTcode.Enabled = false;
            this.txtTcode.Location = new System.Drawing.Point(348, 8);
            this.txtTcode.MaxLength = 20;
            this.txtTcode.Name = "txtTcode";
            this.txtTcode.Size = new System.Drawing.Size(92, 21);
            this.txtTcode.TabIndex = 337;
            // 
            // __2Shortname
            // 
            this.@__2Shortname.DataPropertyName = "Shortname";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.@__2Shortname.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__2Shortname.HeaderText = "Shortname";
            this.@__2Shortname.Name = "__2Shortname";
            this.@__2Shortname.ReadOnly = true;
            this.@__2Shortname.Width = 150;
            // 
            // __2Funcion
            // 
            this.@__2Funcion.DataPropertyName = "ComboCode";
            this.@__2Funcion.HeaderText = "ComboCode";
            this.@__2Funcion.Name = "__2Funcion";
            this.@__2Funcion.ReadOnly = true;
            this.@__2Funcion.ToolTipText = "Funcion Asignada";
            this.@__2Funcion.Visible = false;
            // 
            // __2Valor
            // 
            this.@__2Valor.DataPropertyName = "Valor";
            this.@__2Valor.HeaderText = "Valor";
            this.@__2Valor.Name = "__2Valor";
            this.@__2Valor.ReadOnly = true;
            this.@__2Valor.Width = 50;
            // 
            // __2BtnDel
            // 
            this.@__2BtnDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.@__2BtnDel.DefaultCellStyle = dataGridViewCellStyle2;
            this.@__2BtnDel.HeaderText = "DEL";
            this.@__2BtnDel.Name = "__2BtnDel";
            this.@__2BtnDel.ReadOnly = true;
            this.@__2BtnDel.Text = "DEL";
            this.@__2BtnDel.ToolTipText = "Eliminar Asignacion";
            this.@__2BtnDel.UseColumnTextForButtonValue = true;
            this.@__2BtnDel.Width = 37;
            // 
            // FrmSS11AddComboFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1117, 642);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmSS11AddComboFunction";
            this.Text = "SS11 - ADD Combo Functions";
            this.Load += new System.EventHandler(this.FrmSS11AddComboFunction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0091HHRRCOMBOCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0092HHRRCOMBOASSIGNBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingSource t0091HHRRCOMBOCODEBindingSource;
        private System.Windows.Forms.BindingSource t0092HHRRCOMBOASSIGNBindingSource;
        private System.Windows.Forms.TextBox txtNombreFuncion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv2;
        private TSControls.CtlIconos cicon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn __code;
        private System.Windows.Forms.DataGridViewTextBoxColumn __Descripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Button btnAddEmpleado;
        private System.Windows.Forms.Panel panel2;
        private TSControls.CtlIconos cicon2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn __2Shortname;
        private System.Windows.Forms.DataGridViewTextBoxColumn __2Funcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __2Valor;
        private System.Windows.Forms.DataGridViewButtonColumn __2BtnDel;
    }
}