namespace MASngFE.Transactional.HR
{
    partial class FrmHR09DetalleRegistroAdelanto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHR09DetalleRegistroAdelanto));
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtImporteAdelantar = new MASngFE._UserControls.UDecimalTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.ctlFechaTs1 = new TSControls.CtlFechaTs();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdAdelanto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCompromisoDePago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporteSolicitado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporteAdeudado = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAbonar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(603, 163);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 44);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtImporteAdelantar);
            this.panel1.Controls.Add(this.btnAbonar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbCuenta);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 61);
            this.panel1.TabIndex = 52;
            // 
            // txtImporteAdelantar
            // 
            this.txtImporteAdelantar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtImporteAdelantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteAdelantar.Location = new System.Drawing.Point(127, 32);
            this.txtImporteAdelantar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImporteAdelantar.Name = "txtImporteAdelantar";
            this.txtImporteAdelantar.ReadOnly = false;
            this.txtImporteAdelantar.Size = new System.Drawing.Size(96, 23);
            this.txtImporteAdelantar.TabIndex = 48;
            this.txtImporteAdelantar.ValueD = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 45;
            this.label2.Text = "Pago Desde Cuenta";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCuenta.DataSource = this.t0150CUENTASBindingSource;
            this.cmbCuenta.DisplayMember = "CUENTA_DESC";
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(127, 7);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(206, 23);
            this.cmbCuenta.TabIndex = 46;
            this.cmbCuenta.ValueMember = "ID_CUENTA";
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 47;
            this.label10.Text = "Importe Adelanto";
            // 
            // ctlFechaTs1
            // 
            this.ctlFechaTs1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFechaTs1.CheckPeriodoFIAuto = false;
            this.ctlFechaTs1.ColorFondoFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.ColorForeFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.FechaMaxima = null;
            this.ctlFechaTs1.FechaMinima = null;
            this.ctlFechaTs1.Location = new System.Drawing.Point(104, 28);
            this.ctlFechaTs1.Name = "ctlFechaTs1";
            this.ctlFechaTs1.ObtieneTCAuto = false;
            this.ctlFechaTs1.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Yellow;
            this.ctlFechaTs1.Size = new System.Drawing.Size(147, 27);
            this.ctlFechaTs1.TabIndex = 0;
            this.ctlFechaTs1.ValidarRangoFecha = false;
            this.ctlFechaTs1.Value = null;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.txtIdAdelanto);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.ctlFechaTs1);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 61);
            this.panel3.TabIndex = 53;
            // 
            // txtIdAdelanto
            // 
            this.txtIdAdelanto.Location = new System.Drawing.Point(104, 5);
            this.txtIdAdelanto.Name = "txtIdAdelanto";
            this.txtIdAdelanto.ReadOnly = true;
            this.txtIdAdelanto.Size = new System.Drawing.Size(56, 23);
            this.txtIdAdelanto.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "Fecha Solicitud";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Adelanto #";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(127, 5);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(206, 22);
            this.txtEmpleado.TabIndex = 53;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtCompromisoDePago);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtImporteSolicitado);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtImporteAdeudado);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtEmpleado);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(2, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(344, 123);
            this.panel4.TabIndex = 54;
            // 
            // txtCompromisoDePago
            // 
            this.txtCompromisoDePago.Location = new System.Drawing.Point(127, 95);
            this.txtCompromisoDePago.Name = "txtCompromisoDePago";
            this.txtCompromisoDePago.ReadOnly = true;
            this.txtCompromisoDePago.Size = new System.Drawing.Size(206, 22);
            this.txtCompromisoDePago.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 14);
            this.label1.TabIndex = 59;
            this.label1.Text = "Compromiso Pago";
            // 
            // txtImporteSolicitado
            // 
            this.txtImporteSolicitado.Location = new System.Drawing.Point(127, 29);
            this.txtImporteSolicitado.Name = "txtImporteSolicitado";
            this.txtImporteSolicitado.ReadOnly = true;
            this.txtImporteSolicitado.Size = new System.Drawing.Size(88, 22);
            this.txtImporteSolicitado.TabIndex = 58;
            this.txtImporteSolicitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 14);
            this.label8.TabIndex = 57;
            this.label8.Text = "Importe Solicitado";
            // 
            // txtImporteAdeudado
            // 
            this.txtImporteAdeudado.Location = new System.Drawing.Point(127, 53);
            this.txtImporteAdeudado.Name = "txtImporteAdeudado";
            this.txtImporteAdeudado.ReadOnly = true;
            this.txtImporteAdeudado.Size = new System.Drawing.Size(88, 22);
            this.txtImporteAdeudado.TabIndex = 56;
            this.txtImporteAdeudado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 14);
            this.label12.TabIndex = 55;
            this.label12.Text = "Importe Adeudado";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 14);
            this.label11.TabIndex = 43;
            this.label11.Text = "Empleado";
            // 
            // btnAbonar
            // 
            this.btnAbonar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonar.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonar.Image")));
            this.btnAbonar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonar.Location = new System.Drawing.Point(339, 7);
            this.btnAbonar.Name = "btnAbonar";
            this.btnAbonar.Size = new System.Drawing.Size(100, 44);
            this.btnAbonar.TabIndex = 55;
            this.btnAbonar.Text = "Autorizar\r\nPAGAR";
            this.btnAbonar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbonar.UseVisualStyleBackColor = true;
            this.btnAbonar.Click += new System.EventHandler(this.btnAbonar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolver.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolver.Image")));
            this.btnDevolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevolver.Location = new System.Drawing.Point(451, 182);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(100, 44);
            this.btnDevolver.TabIndex = 38;
            this.btnDevolver.Text = "Deb Total\r\nSUELDO";
            this.btnDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(690, 57);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 44);
            this.btnEnviar.TabIndex = 51;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(690, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 50;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 15);
            this.label9.TabIndex = 47;
            this.label9.Text = "** PAGO DE ADELANTO";
            // 
            // FrmHR09DetalleRegistroAdelanto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmHR09DetalleRegistroAdelanto";
            this.Text = "HR09 - Detalle de Adelanto";
            this.Load += new System.EventHandler(this.FrmHR09DetalleRegistroAdelanto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private TSControls.CtlFechaTs ctlFechaTs1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtIdAdelanto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtImporteAdeudado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.TextBox txtImporteSolicitado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAbonar;
        private _UserControls.UDecimalTextbox txtImporteAdelantar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
        private System.Windows.Forms.TextBox txtCompromisoDePago;
        private System.Windows.Forms.Label label1;
    }
}