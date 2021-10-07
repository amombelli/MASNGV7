namespace MASngFE.Transactional.HR
{
    partial class FrmHR07AnticiposLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHR07AnticiposLoad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.t0518ConceptosHRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.estructuraAdelantoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCompromisoPago = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ctlImporte = new TSControls.CtlTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.t0085PERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConceptos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlFechaTs1 = new TSControls.CtlFechaTs();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoShortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteSolicitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compromisoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.t0518ConceptosHRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estructuraAdelantoBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(337, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 44);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(589, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 37;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // t0518ConceptosHRBindingSource
            // 
            this.t0518ConceptosHRBindingSource.DataSource = typeof(TecserEF.Entity.T0518_ConceptosHR);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.empleadoShortDataGridViewTextBoxColumn,
            this.conceptoDataGridViewTextBoxColumn,
            this.ImporteSolicitado,
            this.fechaSolicitudDataGridViewTextBoxColumn,
            this.comentarioDataGridViewTextBoxColumn,
            this.compromisoPagoDataGridViewTextBoxColumn,
            this.Del});
            this.dgvData.DataSource = this.estructuraAdelantoBindingSource;
            this.dgvData.Location = new System.Drawing.Point(4, 153);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(685, 154);
            this.dgvData.TabIndex = 46;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // estructuraAdelantoBindingSource
            // 
            this.estructuraAdelantoBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.EstructuraAdelanto);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtCompromisoPago);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ctlImporte);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbEmpleado);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(4, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 83);
            this.panel2.TabIndex = 45;
            // 
            // txtCompromisoPago
            // 
            this.txtCompromisoPago.Location = new System.Drawing.Point(127, 56);
            this.txtCompromisoPago.Name = "txtCompromisoPago";
            this.txtCompromisoPago.Size = new System.Drawing.Size(167, 22);
            this.txtCompromisoPago.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 49;
            this.label5.Text = "Compromiso Pago";
            // 
            // ctlImporte
            // 
            this.ctlImporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlImporte.BackColor = System.Drawing.Color.White;
            this.ctlImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlImporte.Location = new System.Drawing.Point(127, 33);
            this.ctlImporte.Name = "ctlImporte";
            this.ctlImporte.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlImporte.SetDecimales = 2;
            this.ctlImporte.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlImporte.Size = new System.Drawing.Size(100, 20);
            this.ctlImporte.TabIndex = 48;
            this.ctlImporte.ValorMaximo = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.ctlImporte.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlImporte.XReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "Importe Solicitado";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpleado.DataSource = this.t0085PERSONALBindingSource;
            this.cmbEmpleado.DisplayMember = "SHORTNAME";
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(127, 9);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(167, 22);
            this.cmbEmpleado.TabIndex = 44;
            this.cmbEmpleado.ValueMember = "SHORTNAME";
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // t0085PERSONALBindingSource
            // 
            this.t0085PERSONALBindingSource.DataSource = typeof(TecserEF.Entity.T0085_PERSONAL);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "Empleado";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbConceptos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ctlFechaTs1);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 61);
            this.panel1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 45;
            this.label2.Text = "Concepto";
            // 
            // cmbConceptos
            // 
            this.cmbConceptos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConceptos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConceptos.DataSource = this.t0518ConceptosHRBindingSource;
            this.cmbConceptos.DisplayMember = "Concepto";
            this.cmbConceptos.FormattingEnabled = true;
            this.cmbConceptos.Location = new System.Drawing.Point(105, 30);
            this.cmbConceptos.Name = "cmbConceptos";
            this.cmbConceptos.Size = new System.Drawing.Size(332, 23);
            this.cmbConceptos.TabIndex = 46;
            this.cmbConceptos.ValueMember = "IdConceptoHR";
            this.cmbConceptos.SelectedIndexChanged += new System.EventHandler(this.cmbConceptos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Solicitud";
            // 
            // ctlFechaTs1
            // 
            this.ctlFechaTs1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFechaTs1.CheckPeriodoFIAuto = false;
            this.ctlFechaTs1.ColorFondoFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.ColorForeFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.FechaMaxima = null;
            this.ctlFechaTs1.FechaMinima = null;
            this.ctlFechaTs1.Location = new System.Drawing.Point(105, 5);
            this.ctlFechaTs1.Name = "ctlFechaTs1";
            this.ctlFechaTs1.ObtieneTCAuto = false;
            this.ctlFechaTs1.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.ctlFechaTs1.Size = new System.Drawing.Size(126, 23);
            this.ctlFechaTs1.TabIndex = 0;
            this.ctlFechaTs1.ValidarRangoFecha = false;
            this.ctlFechaTs1.Value = null;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(589, 49);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 44);
            this.btnEnviar.TabIndex = 47;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "#";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 20;
            // 
            // empleadoShortDataGridViewTextBoxColumn
            // 
            this.empleadoShortDataGridViewTextBoxColumn.DataPropertyName = "EmpleadoShort";
            this.empleadoShortDataGridViewTextBoxColumn.HeaderText = "Empleado";
            this.empleadoShortDataGridViewTextBoxColumn.Name = "empleadoShortDataGridViewTextBoxColumn";
            this.empleadoShortDataGridViewTextBoxColumn.ReadOnly = true;
            this.empleadoShortDataGridViewTextBoxColumn.Width = 80;
            // 
            // conceptoDataGridViewTextBoxColumn
            // 
            this.conceptoDataGridViewTextBoxColumn.DataPropertyName = "Concepto";
            this.conceptoDataGridViewTextBoxColumn.HeaderText = "Concepto";
            this.conceptoDataGridViewTextBoxColumn.Name = "conceptoDataGridViewTextBoxColumn";
            this.conceptoDataGridViewTextBoxColumn.ReadOnly = true;
            this.conceptoDataGridViewTextBoxColumn.Width = 150;
            // 
            // ImporteSolicitado
            // 
            this.ImporteSolicitado.DataPropertyName = "ImporteSolicitado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.ImporteSolicitado.DefaultCellStyle = dataGridViewCellStyle1;
            this.ImporteSolicitado.HeaderText = "Importe";
            this.ImporteSolicitado.Name = "ImporteSolicitado";
            this.ImporteSolicitado.ReadOnly = true;
            this.ImporteSolicitado.Width = 80;
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            this.fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "FechaSolicitud";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaSolicitudDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            this.fechaSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaSolicitudDataGridViewTextBoxColumn.Width = 80;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compromisoPagoDataGridViewTextBoxColumn
            // 
            this.compromisoPagoDataGridViewTextBoxColumn.DataPropertyName = "CompromisoPago";
            this.compromisoPagoDataGridViewTextBoxColumn.HeaderText = "CompromisoPago";
            this.compromisoPagoDataGridViewTextBoxColumn.Name = "compromisoPagoDataGridViewTextBoxColumn";
            this.compromisoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Del
            // 
            this.Del.HeaderText = "Del";
            this.Del.Name = "Del";
            this.Del.ReadOnly = true;
            this.Del.Text = "DEL";
            this.Del.ToolTipText = "Eliminar Registro";
            this.Del.UseColumnTextForButtonValue = true;
            this.Del.Width = 50;
            // 
            // FrmHR07AnticiposLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 310);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmHR07AnticiposLoad";
            this.Text = "HR07 - Solicitud de Anticipos/Adelantos";
            this.Load += new System.EventHandler(this.FrmHR07AnticiposLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0518ConceptosHRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estructuraAdelantoBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.BindingSource t0518ConceptosHRBindingSource;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private TSControls.CtlFechaTs ctlFechaTs1;
        private System.Windows.Forms.ComboBox cmbConceptos;
        private System.Windows.Forms.Label label2;
        private TSControls.CtlTextBox ctlImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.BindingSource t0085PERSONALBindingSource;
        private System.Windows.Forms.TextBox txtCompromisoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource estructuraAdelantoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoShortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteSolicitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compromisoPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Del;
    }
}