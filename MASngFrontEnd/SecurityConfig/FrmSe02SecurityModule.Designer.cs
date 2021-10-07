namespace MASngFE.SecurityConfig
{
    partial class FrmSe02SecurityModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSe02SecurityModule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.userBs = new System.Windows.Forms.BindingSource(this.components);
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.roleBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.idUserConRoleDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRoleConRoleDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idActivoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.desAsignar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.roleAssignBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewTCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSinAsignar = new System.Windows.Forms.DataGridView();
            this.roleSinasignarDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.roleSinAssignBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtUserSelected = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoleSelected = new System.Windows.Forms.TextBox();
            this.dgvUsuariosSinElRoleAsignado = new System.Windows.Forms.DataGridView();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuariosSinElRoleAsignadoBs = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditTcode = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ckTcode = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBs)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleAssignBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleSinAssignBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosSinElRoleAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosSinElRoleAsignadoBs)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewRole
            // 
            this.btnNewRole.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRole.Image = ((System.Drawing.Image)(resources.GetObject("btnNewRole.Image")));
            this.btnNewRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewRole.Location = new System.Drawing.Point(985, 66);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(110, 44);
            this.btnNewRole.TabIndex = 2;
            this.btnNewRole.Text = "Crear\r\nRole";
            this.btnNewRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewRole.UseVisualStyleBackColor = true;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // userBs
            // 
            this.userBs.DataSource = typeof(TecserEF.Entity.TSecUsr);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsuario.DataSource = this.userBs;
            this.cmbUsuario.DisplayMember = "Username";
            this.cmbUsuario.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(67, 2);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(216, 22);
            this.cmbUsuario.TabIndex = 5;
            this.cmbUsuario.ValueMember = "Username";
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            this.cmbUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.cmbUsuario_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Role";
            // 
            // cmbRole
            // 
            this.cmbRole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRole.DataSource = this.roleBs;
            this.cmbRole.DisplayMember = "RoleName";
            this.cmbRole.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(67, 26);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(216, 22);
            this.cmbRole.TabIndex = 7;
            this.cmbRole.ValueMember = "RoleName";
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            this.cmbRole.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRole_Validating);
            // 
            // roleBs
            // 
            this.roleBs.DataSource = typeof(TecserEF.Entity.TSecRole);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbUsuario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRole);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 55);
            this.panel1.TabIndex = 9;
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvAsignacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsignacion.AutoGenerateColumns = false;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUserConRoleDgv,
            this.idRoleConRoleDgv,
            this.idActivoDataGridViewCheckBoxColumn,
            this.desAsignar});
            this.dgvAsignacion.DataSource = this.roleAssignBs;
            this.dgvAsignacion.Location = new System.Drawing.Point(5, 23);
            this.dgvAsignacion.MultiSelect = false;
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.ReadOnly = true;
            this.dgvAsignacion.RowHeadersWidth = 20;
            this.dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacion.Size = new System.Drawing.Size(360, 477);
            this.dgvAsignacion.TabIndex = 10;
            this.dgvAsignacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellContentClick);
            this.dgvAsignacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellEnter);
            // 
            // idUserConRoleDgv
            // 
            this.idUserConRoleDgv.DataPropertyName = "idUser";
            this.idUserConRoleDgv.HeaderText = "Usuario";
            this.idUserConRoleDgv.Name = "idUserConRoleDgv";
            this.idUserConRoleDgv.ReadOnly = true;
            // 
            // idRoleConRoleDgv
            // 
            this.idRoleConRoleDgv.DataPropertyName = "idRole";
            this.idRoleConRoleDgv.HeaderText = "Role";
            this.idRoleConRoleDgv.Name = "idRoleConRoleDgv";
            this.idRoleConRoleDgv.ReadOnly = true;
            // 
            // idActivoDataGridViewCheckBoxColumn
            // 
            this.idActivoDataGridViewCheckBoxColumn.DataPropertyName = "idActivo";
            this.idActivoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.idActivoDataGridViewCheckBoxColumn.Name = "idActivoDataGridViewCheckBoxColumn";
            this.idActivoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.idActivoDataGridViewCheckBoxColumn.Width = 50;
            // 
            // desAsignar
            // 
            this.desAsignar.HeaderText = "Accion";
            this.desAsignar.Name = "desAsignar";
            this.desAsignar.ReadOnly = true;
            this.desAsignar.Text = "Eliminar";
            this.desAsignar.ToolTipText = "Des-Asignar el Role Seleccionado";
            this.desAsignar.UseColumnTextForButtonValue = true;
            this.desAsignar.Width = 50;
            // 
            // roleAssignBs
            // 
            this.roleAssignBs.DataSource = typeof(TecserEF.Entity.TSecRoleAssignment);
            // 
            // btnNewTCode
            // 
            this.btnNewTCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTCode.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTCode.Image")));
            this.btnNewTCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewTCode.Location = new System.Drawing.Point(985, 110);
            this.btnNewTCode.Name = "btnNewTCode";
            this.btnNewTCode.Size = new System.Drawing.Size(110, 44);
            this.btnNewTCode.TabIndex = 13;
            this.btnNewTCode.Text = "Crear\r\nTCode";
            this.btnNewTCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewTCode.UseVisualStyleBackColor = true;
            this.btnNewTCode.Click += new System.EventHandler(this.btnNewTCode_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SpringGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "LISTADO DE USUARIO-ROLES ASIGNADOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Pink;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(368, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "ROLES NO ASIGNADOS PARA EL USUARIO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvSinAsignar
            // 
            this.dgvSinAsignar.AllowUserToAddRows = false;
            this.dgvSinAsignar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSinAsignar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSinAsignar.AutoGenerateColumns = false;
            this.dgvSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinAsignar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleSinasignarDgv,
            this.roleDescriptionDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn,
            this.Accion});
            this.dgvSinAsignar.DataSource = this.roleSinAssignBs;
            this.dgvSinAsignar.Location = new System.Drawing.Point(368, 23);
            this.dgvSinAsignar.MultiSelect = false;
            this.dgvSinAsignar.Name = "dgvSinAsignar";
            this.dgvSinAsignar.ReadOnly = true;
            this.dgvSinAsignar.RowHeadersWidth = 20;
            this.dgvSinAsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinAsignar.Size = new System.Drawing.Size(360, 477);
            this.dgvSinAsignar.TabIndex = 15;
            this.dgvSinAsignar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellContentClick);
            this.dgvSinAsignar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellEnter);
            // 
            // roleSinasignarDgv
            // 
            this.roleSinasignarDgv.DataPropertyName = "RoleName";
            this.roleSinasignarDgv.HeaderText = "RoleName";
            this.roleSinasignarDgv.Name = "roleSinasignarDgv";
            this.roleSinasignarDgv.ReadOnly = true;
            // 
            // roleDescriptionDataGridViewTextBoxColumn
            // 
            this.roleDescriptionDataGridViewTextBoxColumn.DataPropertyName = "RoleDescription";
            this.roleDescriptionDataGridViewTextBoxColumn.HeaderText = "RoleDescription";
            this.roleDescriptionDataGridViewTextBoxColumn.Name = "roleDescriptionDataGridViewTextBoxColumn";
            this.roleDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activoDataGridViewCheckBoxColumn.Width = 50;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Text = "Asignar";
            this.Accion.ToolTipText = "Asignar el Role Seleccionado";
            this.Accion.UseColumnTextForButtonValue = true;
            this.Accion.Width = 50;
            // 
            // roleSinAssignBs
            // 
            this.roleSinAssignBs.DataSource = typeof(TecserEF.Entity.TSecRole);
            // 
            // txtUserSelected
            // 
            this.txtUserSelected.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserSelected.Location = new System.Drawing.Point(448, 11);
            this.txtUserSelected.Name = "txtUserSelected";
            this.txtUserSelected.ReadOnly = true;
            this.txtUserSelected.Size = new System.Drawing.Size(126, 22);
            this.txtUserSelected.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Usuario Seleccionado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(332, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Role Seleccionado";
            // 
            // txtRoleSelected
            // 
            this.txtRoleSelected.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleSelected.Location = new System.Drawing.Point(448, 35);
            this.txtRoleSelected.Name = "txtRoleSelected";
            this.txtRoleSelected.ReadOnly = true;
            this.txtRoleSelected.Size = new System.Drawing.Size(126, 22);
            this.txtRoleSelected.TabIndex = 18;
            // 
            // dgvUsuariosSinElRoleAsignado
            // 
            this.dgvUsuariosSinElRoleAsignado.AllowUserToAddRows = false;
            this.dgvUsuariosSinElRoleAsignado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvUsuariosSinElRoleAsignado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuariosSinElRoleAsignado.AutoGenerateColumns = false;
            this.dgvUsuariosSinElRoleAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosSinElRoleAsignado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn1});
            this.dgvUsuariosSinElRoleAsignado.DataSource = this.UsuariosSinElRoleAsignadoBs;
            this.dgvUsuariosSinElRoleAsignado.Location = new System.Drawing.Point(731, 23);
            this.dgvUsuariosSinElRoleAsignado.MultiSelect = false;
            this.dgvUsuariosSinElRoleAsignado.Name = "dgvUsuariosSinElRoleAsignado";
            this.dgvUsuariosSinElRoleAsignado.ReadOnly = true;
            this.dgvUsuariosSinElRoleAsignado.RowHeadersWidth = 20;
            this.dgvUsuariosSinElRoleAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosSinElRoleAsignado.Size = new System.Drawing.Size(239, 263);
            this.dgvUsuariosSinElRoleAsignado.TabIndex = 19;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usernameDataGridViewTextBoxColumn.Width = 150;
            // 
            // activoDataGridViewCheckBoxColumn1
            // 
            this.activoDataGridViewCheckBoxColumn1.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn1.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn1.Name = "activoDataGridViewCheckBoxColumn1";
            this.activoDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.activoDataGridViewCheckBoxColumn1.Width = 50;
            // 
            // UsuariosSinElRoleAsignadoBs
            // 
            this.UsuariosSinElRoleAsignadoBs.DataSource = typeof(TecserEF.Entity.TSecUsr);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Khaki;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(730, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "USUARIOS SIN ROLE SELECCIONADO";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvAsignacion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dgvSinAsignar);
            this.panel2.Controls.Add(this.dgvUsuariosSinElRoleAsignado);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(8, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 519);
            this.panel2.TabIndex = 22;
            // 
            // btnEditTcode
            // 
            this.btnEditTcode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTcode.Image = ((System.Drawing.Image)(resources.GetObject("btnEditTcode.Image")));
            this.btnEditTcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditTcode.Location = new System.Drawing.Point(1095, 110);
            this.btnEditTcode.Name = "btnEditTcode";
            this.btnEditTcode.Size = new System.Drawing.Size(110, 44);
            this.btnEditTcode.TabIndex = 25;
            this.btnEditTcode.Text = "Editar\r\nTCode";
            this.btnEditTcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditTcode.UseVisualStyleBackColor = true;
            this.btnEditTcode.Click += new System.EventHandler(this.btnEditTcode_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRole.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRole.Image")));
            this.btnEditRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditRole.Location = new System.Drawing.Point(1095, 66);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(110, 44);
            this.btnEditRole.TabIndex = 23;
            this.btnEditRole.Text = "Editar\r\nRole";
            this.btnEditRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ckTcode
            // 
            this.ckTcode.AutoSize = true;
            this.ckTcode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTcode.Location = new System.Drawing.Point(591, 13);
            this.ckTcode.Name = "ckTcode";
            this.ckTcode.Size = new System.Drawing.Size(60, 18);
            this.ckTcode.TabIndex = 31;
            this.ckTcode.Text = "TCODE";
            this.ckTcode.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1095, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 44);
            this.btnExit.TabIndex = 72;
            this.btnExit.Text = "Volver";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.IndianRed;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1208, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 584);
            this.label8.TabIndex = 177;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.IndianRed;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 587);
            this.LineaIzq.TabIndex = 176;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.IndianRed;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(1209, 3);
            this.lineaArriba.TabIndex = 175;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.IndianRed;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 588);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1209, 3);
            this.label9.TabIndex = 178;
            // 
            // FrmSE02SecurityModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 594);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.btnNewRole);
            this.Controls.Add(this.btnNewTCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEditTcode);
            this.Controls.Add(this.ckTcode);
            this.Controls.Add(this.btnEditRole);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRoleSelected);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserSelected);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSe02SecurityModule";
            this.Text = "SE02 - Security Module [Main]";
            this.Load += new System.EventHandler(this.FrmSecurityModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleAssignBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleSinAssignBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosSinElRoleAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosSinElRoleAsignadoBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.BindingSource userBs;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.BindingSource roleBs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAsignacion;
        private System.Windows.Forms.BindingSource roleAssignBs;
        private System.Windows.Forms.Button btnNewTCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSinAsignar;
        private System.Windows.Forms.BindingSource roleSinAssignBs;
        private System.Windows.Forms.TextBox txtUserSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoleSelected;
        private System.Windows.Forms.DataGridView dgvUsuariosSinElRoleAsignado;
        private System.Windows.Forms.BindingSource UsuariosSinElRoleAsignadoBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleSinasignarDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUserConRoleDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRoleConRoleDgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn idActivoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn desAsignar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEditTcode;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox ckTcode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label9;
    }
}