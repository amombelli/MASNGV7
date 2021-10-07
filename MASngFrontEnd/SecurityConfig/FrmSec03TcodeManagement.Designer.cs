namespace MASngFE.SecurityConfig
{
    partial class FrmSec03TcodeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSec03TcodeManagement));
            this.ckVisible = new System.Windows.Forms.CheckBox();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTcodeDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreFormulario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckPermisos = new System.Windows.Forms.CheckBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckIsTcode = new System.Windows.Forms.CheckBox();
            this.ctlCantidadParametros = new TSControls.CtlTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFunctionToCall = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtArg3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtArg2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtArg1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnVerFormsInProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckVisible
            // 
            this.ckVisible.AutoSize = true;
            this.ckVisible.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVisible.Location = new System.Drawing.Point(15, 194);
            this.ckVisible.Name = "ckVisible";
            this.ckVisible.Size = new System.Drawing.Size(65, 18);
            this.ckVisible.TabIndex = 6;
            this.ckVisible.Text = "VISIBLE";
            this.ckVisible.UseVisualStyleBackColor = true;
            // 
            // txtModulo
            // 
            this.txtModulo.Location = new System.Drawing.Point(171, 50);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(133, 22);
            this.txtModulo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "Modulo";
            // 
            // txtTcodeDescription
            // 
            this.txtTcodeDescription.Location = new System.Drawing.Point(171, 27);
            this.txtTcodeDescription.Name = "txtTcodeDescription";
            this.txtTcodeDescription.Size = new System.Drawing.Size(355, 22);
            this.txtTcodeDescription.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Descripcion";
            // 
            // txtTcode
            // 
            this.txtTcode.Location = new System.Drawing.Point(171, 3);
            this.txtTcode.Name = "txtTcode";
            this.txtTcode.Size = new System.Drawing.Size(133, 22);
            this.txtTcode.TabIndex = 0;
            this.txtTcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtTcode_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Transaction Code [TCode]";
            // 
            // txtNombreFormulario
            // 
            this.txtNombreFormulario.Location = new System.Drawing.Point(171, 96);
            this.txtNombreFormulario.Name = "txtNombreFormulario";
            this.txtNombreFormulario.Size = new System.Drawing.Size(246, 22);
            this.txtNombreFormulario.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nombre Formulario [Open]";
            // 
            // ckPermisos
            // 
            this.ckPermisos.AutoSize = true;
            this.ckPermisos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPermisos.Location = new System.Drawing.Point(15, 212);
            this.ckPermisos.Name = "ckPermisos";
            this.ckPermisos.Size = new System.Drawing.Size(138, 18);
            this.ckPermisos.TabIndex = 7;
            this.ckPermisos.Text = "CHEQUEAR PERMISOS";
            this.ckPermisos.UseVisualStyleBackColor = true;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(171, 119);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(355, 22);
            this.txtNamespace.TabIndex = 4;
            this.txtNamespace.Leave += new System.EventHandler(this.txtNamespace_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 42;
            this.label5.Text = "Namespace";
            // 
            // txtModo
            // 
            this.txtModo.Location = new System.Drawing.Point(171, 142);
            this.txtModo.Name = "txtModo";
            this.txtModo.Size = new System.Drawing.Size(29, 22);
            this.txtModo.TabIndex = 5;
            this.txtModo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 44;
            this.label6.Text = "Modo";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(547, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 44);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "Guardar\r\nCambios";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(547, 57);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(110, 44);
            this.btnRegresar.TabIndex = 74;
            this.btnRegresar.Text = "Volver";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.ckIsTcode);
            this.panel1.Controls.Add(this.ctlCantidadParametros);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtFunctionToCall);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Controls.Add(this.txtArg3);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtArg2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtArg1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtModo);
            this.panel1.Controls.Add(this.txtTcodeDescription);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNamespace);
            this.panel1.Controls.Add(this.txtModulo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ckVisible);
            this.panel1.Controls.Add(this.ckPermisos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNombreFormulario);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 239);
            this.panel1.TabIndex = 73;
            // 
            // ckIsTcode
            // 
            this.ckIsTcode.AutoCheck = false;
            this.ckIsTcode.AutoSize = true;
            this.ckIsTcode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsTcode.Location = new System.Drawing.Point(310, 5);
            this.ckIsTcode.Name = "ckIsTcode";
            this.ckIsTcode.Size = new System.Drawing.Size(72, 18);
            this.ckIsTcode.TabIndex = 58;
            this.ckIsTcode.Text = "Is TCode";
            this.ckIsTcode.UseVisualStyleBackColor = true;
            // 
            // ctlCantidadParametros
            // 
            this.ctlCantidadParametros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlCantidadParametros.BackColor = System.Drawing.Color.Gainsboro;
            this.ctlCantidadParametros.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCantidadParametros.Location = new System.Drawing.Point(172, 166);
            this.ctlCantidadParametros.Margin = new System.Windows.Forms.Padding(0);
            this.ctlCantidadParametros.Name = "ctlCantidadParametros";
            this.ctlCantidadParametros.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlCantidadParametros.SetDecimales = 0;
            this.ctlCantidadParametros.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlCantidadParametros.Size = new System.Drawing.Size(28, 22);
            this.ctlCantidadParametros.TabIndex = 57;
            this.ctlCantidadParametros.ValorMaximo = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ctlCantidadParametros.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.ctlCantidadParametros.XReadOnly = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 14);
            this.label16.TabIndex = 56;
            this.label16.Text = "Nombre Function CALL";
            // 
            // txtFunctionToCall
            // 
            this.txtFunctionToCall.Location = new System.Drawing.Point(171, 73);
            this.txtFunctionToCall.Name = "txtFunctionToCall";
            this.txtFunctionToCall.Size = new System.Drawing.Size(246, 22);
            this.txtFunctionToCall.TabIndex = 55;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(310, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 14);
            this.label15.TabIndex = 54;
            this.label15.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(347, 50);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(70, 22);
            this.txtType.TabIndex = 53;
            // 
            // txtArg3
            // 
            this.txtArg3.Location = new System.Drawing.Point(472, 166);
            this.txtArg3.Name = "txtArg3";
            this.txtArg3.Size = new System.Drawing.Size(54, 22);
            this.txtArg3.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(436, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 14);
            this.label14.TabIndex = 52;
            this.label14.Text = "Arg3";
            // 
            // txtArg2
            // 
            this.txtArg2.Location = new System.Drawing.Point(363, 166);
            this.txtArg2.Name = "txtArg2";
            this.txtArg2.Size = new System.Drawing.Size(54, 22);
            this.txtArg2.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(327, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 14);
            this.label13.TabIndex = 50;
            this.label13.Text = "Arg2";
            // 
            // txtArg1
            // 
            this.txtArg1.Location = new System.Drawing.Point(254, 166);
            this.txtArg1.Name = "txtArg1";
            this.txtArg1.Size = new System.Drawing.Size(54, 22);
            this.txtArg1.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(218, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 14);
            this.label12.TabIndex = 48;
            this.label12.Text = "Arg1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 14);
            this.label11.TabIndex = 46;
            this.label11.Text = "# Parametros";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.OliveDrab;
            this.label7.Location = new System.Drawing.Point(2, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(662, 3);
            this.label7.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.OliveDrab;
            this.label8.Location = new System.Drawing.Point(2, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 251);
            this.label8.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.OliveDrab;
            this.label9.Location = new System.Drawing.Point(4, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(662, 3);
            this.label9.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.OliveDrab;
            this.label10.Location = new System.Drawing.Point(663, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 251);
            this.label10.TabIndex = 78;
            // 
            // btnVerFormsInProject
            // 
            this.btnVerFormsInProject.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerFormsInProject.Image = ((System.Drawing.Image)(resources.GetObject("btnVerFormsInProject.Image")));
            this.btnVerFormsInProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerFormsInProject.Location = new System.Drawing.Point(547, 203);
            this.btnVerFormsInProject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnVerFormsInProject.Name = "btnVerFormsInProject";
            this.btnVerFormsInProject.Size = new System.Drawing.Size(110, 44);
            this.btnVerFormsInProject.TabIndex = 79;
            this.btnVerFormsInProject.Text = "Ver\r\nForms";
            this.btnVerFormsInProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerFormsInProject.UseVisualStyleBackColor = true;
            this.btnVerFormsInProject.Click += new System.EventHandler(this.btnVerFormsInProject_Click);
            // 
            // FrmSec03TcodeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 256);
            this.ControlBox = false;
            this.Controls.Add(this.btnVerFormsInProject);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSec03TcodeManagement";
            this.Text = "SEC03 - TCODE Management";
            this.Load += new System.EventHandler(this.FrmNewTcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ckVisible;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTcodeDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreFormulario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckPermisos;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtArg3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtArg2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtArg1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFunctionToCall;
        private TSControls.CtlTextBox ctlCantidadParametros;
        private System.Windows.Forms.CheckBox ckIsTcode;
        private System.Windows.Forms.Button btnVerFormsInProject;
    }
}