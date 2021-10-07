namespace MASngFE.Transactional.PP
{
    partial class FrmPP03AltaOFManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP03AltaOFManual));
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKgFabricar = new System.Windows.Forms.TextBox();
            this.cmbMotivo = new System.Windows.Forms.ComboBox();
            this.txtNumeroOV = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.dtpFechaCompromiso = new System.Windows.Forms.DateTimePicker();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.txtFechaLog = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddOF = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckAprobado = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(280, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(284, 22);
            this.txtDescripcion.TabIndex = 1;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbMaterial.DisplayMember = "IDMATERIAL";
            this.cmbMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(124, 3);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(154, 22);
            this.cmbMaterial.TabIndex = 2;
            this.cmbMaterial.ValueMember = "IDMATERIAL";
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMaterial_Validating);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Material a Fabricar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "KG a Fabricar";
            // 
            // txtKgFabricar
            // 
            this.txtKgFabricar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricar.Location = new System.Drawing.Point(124, 51);
            this.txtKgFabricar.Name = "txtKgFabricar";
            this.txtKgFabricar.Size = new System.Drawing.Size(69, 22);
            this.txtKgFabricar.TabIndex = 5;
            this.txtKgFabricar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgFabricar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgFabricar_KeyPress);
            this.txtKgFabricar.Validating += new System.ComponentModel.CancelEventHandler(this.txtKgFabricar_Validating);
            // 
            // cmbMotivo
            // 
            this.cmbMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMotivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMotivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMotivo.FormattingEnabled = true;
            this.cmbMotivo.Items.AddRange(new object[] {
            "STOCK",
            "VENTA",
            "MUESTRA"});
            this.cmbMotivo.Location = new System.Drawing.Point(124, 3);
            this.cmbMotivo.Name = "cmbMotivo";
            this.cmbMotivo.Size = new System.Drawing.Size(135, 22);
            this.cmbMotivo.TabIndex = 6;
            this.cmbMotivo.SelectedIndexChanged += new System.EventHandler(this.cmbMotivo_SelectedIndexChanged);
            // 
            // txtNumeroOV
            // 
            this.txtNumeroOV.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOV.Location = new System.Drawing.Point(298, 3);
            this.txtNumeroOV.Name = "txtNumeroOV";
            this.txtNumeroOV.Size = new System.Drawing.Size(65, 22);
            this.txtNumeroOV.TabIndex = 9;
            this.txtNumeroOV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroOV_KeyPress);
            this.txtNumeroOV.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroOV_Validating);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(420, 3);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(278, 22);
            this.txtNombreCliente.TabIndex = 11;
            // 
            // dtpFechaCompromiso
            // 
            this.dtpFechaCompromiso.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCompromiso.Location = new System.Drawing.Point(124, 27);
            this.dtpFechaCompromiso.Name = "dtpFechaCompromiso";
            this.dtpFechaCompromiso.Size = new System.Drawing.Size(239, 22);
            this.dtpFechaCompromiso.TabIndex = 11;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(134, 177);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(186, 22);
            this.txtUsuario.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(76, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Usuario";
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(124, 51);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(574, 22);
            this.txtComentario.TabIndex = 17;
            // 
            // txtPlanta
            // 
            this.txtPlanta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanta.Location = new System.Drawing.Point(567, 3);
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.ReadOnly = true;
            this.txtPlanta.Size = new System.Drawing.Size(37, 22);
            this.txtPlanta.TabIndex = 18;
            this.txtPlanta.Text = "CERR";
            this.txtPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFechaLog
            // 
            this.txtFechaLog.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaLog.Location = new System.Drawing.Point(134, 201);
            this.txtFechaLog.Name = "txtFechaLog";
            this.txtFechaLog.ReadOnly = true;
            this.txtFechaLog.Size = new System.Drawing.Size(186, 22);
            this.txtFechaLog.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fecha LOG";
            // 
            // btnAddOF
            // 
            this.btnAddOF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOF.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOF.Image")));
            this.btnAddOF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOF.Location = new System.Drawing.Point(715, 8);
            this.btnAddOF.Name = "btnAddOF";
            this.btnAddOF.Size = new System.Drawing.Size(97, 40);
            this.btnAddOF.TabIndex = 71;
            this.btnAddOF.Text = "Agregar\r\nOF";
            this.btnAddOF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOF.UseVisualStyleBackColor = true;
            this.btnAddOF.Click += new System.EventHandler(this.btnAddOF_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(308, -137);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 70;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckAprobado);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtMtype);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtKgFabricar);
            this.panel1.Controls.Add(this.txtPlanta);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 80);
            this.panel1.TabIndex = 72;
            // 
            // ckAprobado
            // 
            this.ckAprobado.AutoSize = true;
            this.ckAprobado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAprobado.Location = new System.Drawing.Point(280, 53);
            this.ckAprobado.Name = "ckAprobado";
            this.ckAprobado.Size = new System.Drawing.Size(171, 18);
            this.ckAprobado.TabIndex = 191;
            this.ckAprobado.Text = "OF Aprobada para Fabricar";
            this.ckAprobado.UseVisualStyleBackColor = true;
            this.ckAprobado.CheckedChanged += new System.EventHandler(this.ckAprobado_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "Tipo Material";
            // 
            // txtMtype
            // 
            this.txtMtype.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMtype.Location = new System.Drawing.Point(124, 27);
            this.txtMtype.Name = "txtMtype";
            this.txtMtype.ReadOnly = true;
            this.txtMtype.Size = new System.Drawing.Size(69, 22);
            this.txtMtype.TabIndex = 20;
            this.txtMtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(715, 48);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 40);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "Cancelar\r\nAlta";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtNombreCliente);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmbMotivo);
            this.panel2.Controls.Add(this.txtNumeroOV);
            this.panel2.Controls.Add(this.txtComentario);
            this.panel2.Controls.Add(this.dtpFechaCompromiso);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(9, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(704, 77);
            this.panel2.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Comentario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(372, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "OV#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(72, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "Motivo ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 14);
            this.label11.TabIndex = 4;
            this.label11.Text = "Fecha Compromiso";
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 237);
            this.LineaIzq.TabIndex = 188;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(818, 3);
            this.lineaArriba.TabIndex = 187;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkBlue;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(2, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(818, 3);
            this.label5.TabIndex = 189;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkBlue;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SeaGreen;
            this.label8.Location = new System.Drawing.Point(817, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 237);
            this.label8.TabIndex = 190;
            // 
            // FrmPP03AltaOFManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(824, 242);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddOF);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtFechaLog);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label7);
            this.Name = "FrmPP03AltaOFManual";
            this.Text = "PP03 - Ingreso de OF Manual";
            this.Load += new System.EventHandler(this.FrmAltaOrdenFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKgFabricar;
        private System.Windows.Forms.ComboBox cmbMotivo;
        private System.Windows.Forms.TextBox txtNumeroOV;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaCompromiso;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.TextBox txtFechaLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddOF;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckAprobado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMtype;
    }
}