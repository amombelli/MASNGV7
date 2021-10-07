namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCo08CostManageControlCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCo08CostManageControlCenter));
            this.panIdentificacionCliente = new System.Windows.Forms.Panel();
            this.ctlRevisionStandard = new TSControls.CtlSemaforo();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSetAsStandard = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.ctlRevisionPT = new TSControls.CtlSemaforo();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ctlRevisionMP = new TSControls.CtlSemaforo();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCostRollDescripcion = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtGuidActivo = new System.Windows.Forms.TextBox();
            this.btnRepoMP = new System.Windows.Forms.Button();
            this.btnRepoMfg = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCreateNewCostRoll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnVerStandard = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panIdentificacionCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panIdentificacionCliente
            // 
            this.panIdentificacionCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.panIdentificacionCliente.Controls.Add(this.ctlRevisionStandard);
            this.panIdentificacionCliente.Controls.Add(this.label23);
            this.panIdentificacionCliente.Controls.Add(this.btnSetAsStandard);
            this.panIdentificacionCliente.Controls.Add(this.label22);
            this.panIdentificacionCliente.Controls.Add(this.label21);
            this.panIdentificacionCliente.Controls.Add(this.ctlRevisionPT);
            this.panIdentificacionCliente.Controls.Add(this.txtUser);
            this.panIdentificacionCliente.Controls.Add(this.label18);
            this.panIdentificacionCliente.Controls.Add(this.label17);
            this.panIdentificacionCliente.Controls.Add(this.ctlRevisionMP);
            this.panIdentificacionCliente.Controls.Add(this.label1);
            this.panIdentificacionCliente.Controls.Add(this.txtCostRollDescripcion);
            this.panIdentificacionCliente.Controls.Add(this.label19);
            this.panIdentificacionCliente.Controls.Add(this.txtFecha);
            this.panIdentificacionCliente.Controls.Add(this.label20);
            this.panIdentificacionCliente.Controls.Add(this.txtGuidActivo);
            this.panIdentificacionCliente.Controls.Add(this.btnRepoMP);
            this.panIdentificacionCliente.Controls.Add(this.btnRepoMfg);
            this.panIdentificacionCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panIdentificacionCliente.Location = new System.Drawing.Point(8, 25);
            this.panIdentificacionCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panIdentificacionCliente.Name = "panIdentificacionCliente";
            this.panIdentificacionCliente.Size = new System.Drawing.Size(511, 162);
            this.panIdentificacionCliente.TabIndex = 133;
            // 
            // ctlRevisionStandard
            // 
            this.ctlRevisionStandard.Location = new System.Drawing.Point(153, 133);
            this.ctlRevisionStandard.Name = "ctlRevisionStandard";
            this.ctlRevisionStandard.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Azul;
            this.ctlRevisionStandard.Size = new System.Drawing.Size(21, 27);
            this.ctlRevisionStandard.TabIndex = 156;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Navy;
            this.label23.Location = new System.Drawing.Point(40, 139);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 14);
            this.label23.TabIndex = 155;
            this.label23.Text = "STD Cost - Seteado";
            // 
            // btnSetAsStandard
            // 
            this.btnSetAsStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetAsStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetAsStandard.Image = ((System.Drawing.Image)(resources.GetObject("btnSetAsStandard.Image")));
            this.btnSetAsStandard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetAsStandard.Location = new System.Drawing.Point(401, 99);
            this.btnSetAsStandard.Name = "btnSetAsStandard";
            this.btnSetAsStandard.Size = new System.Drawing.Size(100, 40);
            this.btnSetAsStandard.TabIndex = 154;
            this.btnSetAsStandard.Text = "Set\r\nStandard";
            this.btnSetAsStandard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetAsStandard.UseVisualStyleBackColor = true;
            this.btnSetAsStandard.Click += new System.EventHandler(this.btnSetAsStandard_Click);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(10, 79);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(492, 4);
            this.label22.TabIndex = 151;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkBlue;
            this.label21.Location = new System.Drawing.Point(305, 32);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 14);
            this.label21.TabIndex = 153;
            this.label21.Text = "Usuario";
            // 
            // ctlRevisionPT
            // 
            this.ctlRevisionPT.Location = new System.Drawing.Point(153, 109);
            this.ctlRevisionPT.Name = "ctlRevisionPT";
            this.ctlRevisionPT.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Azul;
            this.ctlRevisionPT.Size = new System.Drawing.Size(21, 25);
            this.ctlRevisionPT.TabIndex = 96;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUser.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtUser.Location = new System.Drawing.Point(360, 28);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(142, 22);
            this.txtUser.TabIndex = 152;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(11, 114);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(137, 14);
            this.label18.TabIndex = 95;
            this.label18.Text = "PT - Revision Finalizada";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(7, 89);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(141, 14);
            this.label17.TabIndex = 94;
            this.label17.Text = "MP - Revision Finalizada";
            // 
            // ctlRevisionMP
            // 
            this.ctlRevisionMP.Location = new System.Drawing.Point(153, 85);
            this.ctlRevisionMP.Name = "ctlRevisionMP";
            this.ctlRevisionMP.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Azul;
            this.ctlRevisionMP.Size = new System.Drawing.Size(21, 23);
            this.ctlRevisionMP.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 88;
            this.label1.Text = "Descripcion CR";
            // 
            // txtCostRollDescripcion
            // 
            this.txtCostRollDescripcion.BackColor = System.Drawing.Color.White;
            this.txtCostRollDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostRollDescripcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCostRollDescripcion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostRollDescripcion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCostRollDescripcion.Location = new System.Drawing.Point(103, 52);
            this.txtCostRollDescripcion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCostRollDescripcion.Name = "txtCostRollDescripcion";
            this.txtCostRollDescripcion.Size = new System.Drawing.Size(399, 22);
            this.txtCostRollDescripcion.TabIndex = 87;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(4, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 14);
            this.label19.TabIndex = 8;
            this.label19.Text = "Fecha Ejecucion";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtFecha.Location = new System.Drawing.Point(103, 28);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(131, 22);
            this.txtFecha.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkBlue;
            this.label20.Location = new System.Drawing.Point(28, 8);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 14);
            this.label20.TabIndex = 6;
            this.label20.Text = "GUID Activo";
            // 
            // txtGuidActivo
            // 
            this.txtGuidActivo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGuidActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuidActivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGuidActivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuidActivo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtGuidActivo.Location = new System.Drawing.Point(103, 4);
            this.txtGuidActivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGuidActivo.Name = "txtGuidActivo";
            this.txtGuidActivo.ReadOnly = true;
            this.txtGuidActivo.Size = new System.Drawing.Size(244, 22);
            this.txtGuidActivo.TabIndex = 5;
            // 
            // btnRepoMP
            // 
            this.btnRepoMP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRepoMP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepoMP.Image = ((System.Drawing.Image)(resources.GetObject("btnRepoMP.Image")));
            this.btnRepoMP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepoMP.Location = new System.Drawing.Point(193, 99);
            this.btnRepoMP.Name = "btnRepoMP";
            this.btnRepoMP.Size = new System.Drawing.Size(100, 40);
            this.btnRepoMP.TabIndex = 131;
            this.btnRepoMP.Text = "Revision\r\nMP";
            this.btnRepoMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepoMP.UseVisualStyleBackColor = true;
            this.btnRepoMP.Click += new System.EventHandler(this.btnCostoRepoMP_Click);
            // 
            // btnRepoMfg
            // 
            this.btnRepoMfg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRepoMfg.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepoMfg.Image = ((System.Drawing.Image)(resources.GetObject("btnRepoMfg.Image")));
            this.btnRepoMfg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepoMfg.Location = new System.Drawing.Point(297, 99);
            this.btnRepoMfg.Name = "btnRepoMfg";
            this.btnRepoMfg.Size = new System.Drawing.Size(100, 40);
            this.btnRepoMfg.TabIndex = 132;
            this.btnRepoMfg.Text = "Revision\r\nPT";
            this.btnRepoMfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepoMfg.UseVisualStyleBackColor = true;
            this.btnRepoMfg.Click += new System.EventHandler(this.btnRepoMfg_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SpringGreen;
            this.label9.Location = new System.Drawing.Point(8, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(616, 19);
            this.label9.TabIndex = 134;
            this.label9.Text = "Informacion ULTIMO COST ROLL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateNewCostRoll
            // 
            this.btnCreateNewCostRoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreateNewCostRoll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewCostRoll.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNewCostRoll.Image")));
            this.btnCreateNewCostRoll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewCostRoll.Location = new System.Drawing.Point(524, 66);
            this.btnCreateNewCostRoll.Name = "btnCreateNewCostRoll";
            this.btnCreateNewCostRoll.Size = new System.Drawing.Size(100, 40);
            this.btnCreateNewCostRoll.TabIndex = 130;
            this.btnCreateNewCostRoll.Text = "Nuevo\r\nCR\r\n";
            this.btnCreateNewCostRoll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewCostRoll.UseVisualStyleBackColor = true;
            this.btnCreateNewCostRoll.Click += new System.EventHandler(this.btnCreateNewCostRoll_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(524, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 119;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightCoral;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 606);
            this.label8.TabIndex = 148;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.LightCoral;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(2, 1);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(629, 3);
            this.label58.TabIndex = 147;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightCoral;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(628, 3);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(3, 606);
            this.label15.TabIndex = 146;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.LightCoral;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 606);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(629, 3);
            this.label16.TabIndex = 149;
            // 
            // btnVerStandard
            // 
            this.btnVerStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVerStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerStandard.Image = ((System.Drawing.Image)(resources.GetObject("btnVerStandard.Image")));
            this.btnVerStandard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerStandard.Location = new System.Drawing.Point(524, 147);
            this.btnVerStandard.Name = "btnVerStandard";
            this.btnVerStandard.Size = new System.Drawing.Size(100, 40);
            this.btnVerStandard.TabIndex = 157;
            this.btnVerStandard.Text = "Visualizar\r\nStandard";
            this.btnVerStandard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerStandard.UseVisualStyleBackColor = true;
            this.btnVerStandard.Click += new System.EventHandler(this.btnVerStandard_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(533, 131);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 13);
            this.linkLabel1.TabIndex = 158;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "No hecho aun";
            // 
            // FrmCo08CostManageControlCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 611);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnVerStandard);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panIdentificacionCliente);
            this.Controls.Add(this.btnCreateNewCostRoll);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmCo08CostManageControlCenter";
            this.Text = "CO08 - Centro de Control de Costos";
            this.Load += new System.EventHandler(this.FrmCO08_CostManageControlCenter_Load);
            this.panIdentificacionCliente.ResumeLayout(false);
            this.panIdentificacionCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateNewCostRoll;
        private System.Windows.Forms.Button btnRepoMP;
        private System.Windows.Forms.Button btnRepoMfg;
        private System.Windows.Forms.Panel panIdentificacionCliente;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtGuidActivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCostRollDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private TSControls.CtlSemaforo ctlRevisionPT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private TSControls.CtlSemaforo ctlRevisionMP;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label22;
        private TSControls.CtlSemaforo ctlRevisionStandard;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSetAsStandard;
        private System.Windows.Forms.Button btnVerStandard;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}