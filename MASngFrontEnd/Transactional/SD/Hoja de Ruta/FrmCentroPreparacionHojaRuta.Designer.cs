namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    partial class FrmCentroPreparacionHojaRuta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEntregas = new System.Windows.Forms.DataGridView();
            this.idEntregasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRutaAsignadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0059ENTREGASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNumeroRemito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckRetiraCliente = new System.Windows.Forms.CheckBox();
            this.ckEntregaACliente = new System.Windows.Forms.CheckBox();
            this.ckSinAsignar = new System.Windows.Forms.CheckBox();
            this.dgvHojaRuta = new System.Windows.Forms.DataGridView();
            this.t0059HOJARUTAHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewHRuta = new System.Windows.Forms.Button();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckSinRutaAsignada = new System.Windows.Forms.CheckBox();
            this.idRutaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaFleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaFleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDespachoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusRutaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choferDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaSalidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaLlegadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoFleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059ENTREGASBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHojaRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059HOJARUTAHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntregas
            // 
            this.dgvEntregas.AllowUserToAddRows = false;
            this.dgvEntregas.AllowUserToDeleteRows = false;
            this.dgvEntregas.AutoGenerateColumns = false;
            this.dgvEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntregas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEntregasDataGridViewTextBoxColumn,
            this.idRemitoDataGridViewTextBoxColumn,
            this.numeroRemitoDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.tipoEntregaDataGridViewTextBoxColumn,
            this.statusEntregaDataGridViewTextBoxColumn,
            this.fechaEntregaDataGridViewTextBoxColumn,
            this.clienteIdDataGridViewTextBoxColumn,
            this.idRutaAsignadaDataGridViewTextBoxColumn});
            this.dgvEntregas.DataSource = this.t0059ENTREGASBindingSource;
            this.dgvEntregas.Location = new System.Drawing.Point(13, 106);
            this.dgvEntregas.Name = "dgvEntregas";
            this.dgvEntregas.ReadOnly = true;
            this.dgvEntregas.Size = new System.Drawing.Size(727, 224);
            this.dgvEntregas.TabIndex = 0;
            this.dgvEntregas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntregas_CellContentClick);
            // 
            // idEntregasDataGridViewTextBoxColumn
            // 
            this.idEntregasDataGridViewTextBoxColumn.DataPropertyName = "IdEntregas";
            this.idEntregasDataGridViewTextBoxColumn.FillWeight = 80F;
            this.idEntregasDataGridViewTextBoxColumn.HeaderText = "ENTREGA#";
            this.idEntregasDataGridViewTextBoxColumn.Name = "idEntregasDataGridViewTextBoxColumn";
            this.idEntregasDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEntregasDataGridViewTextBoxColumn.Width = 80;
            // 
            // idRemitoDataGridViewTextBoxColumn
            // 
            this.idRemitoDataGridViewTextBoxColumn.DataPropertyName = "idRemito";
            this.idRemitoDataGridViewTextBoxColumn.HeaderText = "idRemito";
            this.idRemitoDataGridViewTextBoxColumn.Name = "idRemitoDataGridViewTextBoxColumn";
            this.idRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRemitoDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroRemitoDataGridViewTextBoxColumn
            // 
            this.numeroRemitoDataGridViewTextBoxColumn.DataPropertyName = "NumeroRemito";
            this.numeroRemitoDataGridViewTextBoxColumn.HeaderText = "REMITO #";
            this.numeroRemitoDataGridViewTextBoxColumn.Name = "numeroRemitoDataGridViewTextBoxColumn";
            this.numeroRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroRemitoDataGridViewTextBoxColumn.Width = 70;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clienteRazonSocialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "RAZON SOCIAL";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 160;
            // 
            // tipoEntregaDataGridViewTextBoxColumn
            // 
            this.tipoEntregaDataGridViewTextBoxColumn.DataPropertyName = "TipoEntrega";
            this.tipoEntregaDataGridViewTextBoxColumn.HeaderText = "TIPO ENTREGA";
            this.tipoEntregaDataGridViewTextBoxColumn.Name = "tipoEntregaDataGridViewTextBoxColumn";
            this.tipoEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoEntregaDataGridViewTextBoxColumn.Width = 120;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusEntregaDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaEntregaDataGridViewTextBoxColumn
            // 
            this.fechaEntregaDataGridViewTextBoxColumn.DataPropertyName = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.HeaderText = "FECHA ENT";
            this.fechaEntregaDataGridViewTextBoxColumn.Name = "fechaEntregaDataGridViewTextBoxColumn";
            this.fechaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaEntregaDataGridViewTextBoxColumn.Width = 90;
            // 
            // clienteIdDataGridViewTextBoxColumn
            // 
            this.clienteIdDataGridViewTextBoxColumn.DataPropertyName = "ClienteId";
            this.clienteIdDataGridViewTextBoxColumn.HeaderText = "ClienteId";
            this.clienteIdDataGridViewTextBoxColumn.Name = "clienteIdDataGridViewTextBoxColumn";
            this.clienteIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // idRutaAsignadaDataGridViewTextBoxColumn
            // 
            this.idRutaAsignadaDataGridViewTextBoxColumn.DataPropertyName = "IdRutaAsignada";
            this.idRutaAsignadaDataGridViewTextBoxColumn.HeaderText = "RUTA ID";
            this.idRutaAsignadaDataGridViewTextBoxColumn.Name = "idRutaAsignadaDataGridViewTextBoxColumn";
            this.idRutaAsignadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRutaAsignadaDataGridViewTextBoxColumn.Width = 80;
            // 
            // t0059ENTREGASBindingSource
            // 
            this.t0059ENTREGASBindingSource.DataSource = typeof(TecserEF.Entity.T0059_ENTREGAS);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1117, 14);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 42);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNumeroRemito
            // 
            this.txtNumeroRemito.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroRemito.Location = new System.Drawing.Point(118, 32);
            this.txtNumeroRemito.Name = "txtNumeroRemito";
            this.txtNumeroRemito.Size = new System.Drawing.Size(98, 22);
            this.txtNumeroRemito.TabIndex = 4;
            this.txtNumeroRemito.Leave += new System.EventHandler(this.txtNumeroRemito_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "NUMERO REMITO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckRetiraCliente);
            this.groupBox1.Controls.Add(this.ckEntregaACliente);
            this.groupBox1.Controls.Add(this.ckSinAsignar);
            this.groupBox1.Location = new System.Drawing.Point(415, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO ENTREGA";
            // 
            // ckRetiraCliente
            // 
            this.ckRetiraCliente.AutoSize = true;
            this.ckRetiraCliente.Location = new System.Drawing.Point(7, 59);
            this.ckRetiraCliente.Name = "ckRetiraCliente";
            this.ckRetiraCliente.Size = new System.Drawing.Size(108, 19);
            this.ckRetiraCliente.TabIndex = 2;
            this.ckRetiraCliente.Text = "RETIRA CLIENTE";
            this.ckRetiraCliente.UseVisualStyleBackColor = true;
            this.ckRetiraCliente.CheckedChanged += new System.EventHandler(this.ckSinAsignar_CheckedChanged);
            // 
            // ckEntregaACliente
            // 
            this.ckEntregaACliente.AutoSize = true;
            this.ckEntregaACliente.Location = new System.Drawing.Point(7, 40);
            this.ckEntregaACliente.Name = "ckEntregaACliente";
            this.ckEntregaACliente.Size = new System.Drawing.Size(129, 19);
            this.ckEntregaACliente.TabIndex = 1;
            this.ckEntregaACliente.Text = "ENTREGA A CLIENTE";
            this.ckEntregaACliente.UseVisualStyleBackColor = true;
            this.ckEntregaACliente.CheckedChanged += new System.EventHandler(this.ckSinAsignar_CheckedChanged);
            // 
            // ckSinAsignar
            // 
            this.ckSinAsignar.AutoSize = true;
            this.ckSinAsignar.Location = new System.Drawing.Point(7, 21);
            this.ckSinAsignar.Name = "ckSinAsignar";
            this.ckSinAsignar.Size = new System.Drawing.Size(94, 19);
            this.ckSinAsignar.TabIndex = 0;
            this.ckSinAsignar.Text = "SIN ASIGNAR";
            this.ckSinAsignar.UseVisualStyleBackColor = true;
            this.ckSinAsignar.CheckedChanged += new System.EventHandler(this.ckSinAsignar_CheckedChanged);
            // 
            // dgvHojaRuta
            // 
            this.dgvHojaRuta.AllowUserToAddRows = false;
            this.dgvHojaRuta.AllowUserToDeleteRows = false;
            this.dgvHojaRuta.AutoGenerateColumns = false;
            this.dgvHojaRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHojaRuta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRutaDataGridViewTextBoxColumn,
            this.idEmpresaFleteDataGridViewTextBoxColumn,
            this.empresaFleteDataGridViewTextBoxColumn,
            this.fechaDespachoDataGridViewTextBoxColumn,
            this.statusRutaDataGridViewTextBoxColumn,
            this.choferDataGridViewTextBoxColumn,
            this.descripcionFleteDataGridViewTextBoxColumn,
            this.horaSalidaDataGridViewTextBoxColumn,
            this.horaLlegadaDataGridViewTextBoxColumn,
            this.costoFleteDataGridViewTextBoxColumn,
            this.Edit});
            this.dgvHojaRuta.DataSource = this.t0059HOJARUTAHBindingSource;
            this.dgvHojaRuta.Location = new System.Drawing.Point(13, 336);
            this.dgvHojaRuta.Name = "dgvHojaRuta";
            this.dgvHojaRuta.ReadOnly = true;
            this.dgvHojaRuta.Size = new System.Drawing.Size(1102, 300);
            this.dgvHojaRuta.TabIndex = 8;
            this.dgvHojaRuta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHojaRuta_CellContentClick);
            // 
            // t0059HOJARUTAHBindingSource
            // 
            this.t0059HOJARUTAHBindingSource.DataSource = typeof(TecserEF.Entity.T0059_HOJARUTA_H);
            // 
            // btnNewHRuta
            // 
            this.btnNewHRuta.Location = new System.Drawing.Point(1117, 58);
            this.btnNewHRuta.Name = "btnNewHRuta";
            this.btnNewHRuta.Size = new System.Drawing.Size(109, 42);
            this.btnNewHRuta.TabIndex = 9;
            this.btnNewHRuta.Text = "CREAR HOJA RUTA";
            this.btnNewHRuta.UseVisualStyleBackColor = true;
            this.btnNewHRuta.Click += new System.EventHandler(this.btnNewHRuta_Click);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(333, 6);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(48, 22);
            this.txtIdCliente.TabIndex = 6;
            // 
            // cmbCliente
            // 
            this.cmbCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(118, 6);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(209, 22);
            this.cmbCliente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "CLIENTE RAZ.SOC";
            // 
            // ckSinRutaAsignada
            // 
            this.ckSinRutaAsignada.AutoSize = true;
            this.ckSinRutaAsignada.ForeColor = System.Drawing.Color.Crimson;
            this.ckSinRutaAsignada.Location = new System.Drawing.Point(597, 27);
            this.ckSinRutaAsignada.Name = "ckSinRutaAsignada";
            this.ckSinRutaAsignada.Size = new System.Drawing.Size(132, 19);
            this.ckSinRutaAsignada.TabIndex = 3;
            this.ckSinRutaAsignada.Text = "SIN RUTA ASIGNADA";
            this.ckSinRutaAsignada.UseVisualStyleBackColor = true;
            this.ckSinRutaAsignada.CheckedChanged += new System.EventHandler(this.ckSinRutaAsignada_CheckedChanged);
            // 
            // idRutaDataGridViewTextBoxColumn
            // 
            this.idRutaDataGridViewTextBoxColumn.DataPropertyName = "IdRuta";
            this.idRutaDataGridViewTextBoxColumn.HeaderText = "Ruta #";
            this.idRutaDataGridViewTextBoxColumn.Name = "idRutaDataGridViewTextBoxColumn";
            this.idRutaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRutaDataGridViewTextBoxColumn.Width = 50;
            // 
            // idEmpresaFleteDataGridViewTextBoxColumn
            // 
            this.idEmpresaFleteDataGridViewTextBoxColumn.DataPropertyName = "IdEmpresaFlete";
            this.idEmpresaFleteDataGridViewTextBoxColumn.HeaderText = "IdEmpresaFlete";
            this.idEmpresaFleteDataGridViewTextBoxColumn.Name = "idEmpresaFleteDataGridViewTextBoxColumn";
            this.idEmpresaFleteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaFleteDataGridViewTextBoxColumn.Visible = false;
            // 
            // empresaFleteDataGridViewTextBoxColumn
            // 
            this.empresaFleteDataGridViewTextBoxColumn.DataPropertyName = "EmpresaFlete";
            this.empresaFleteDataGridViewTextBoxColumn.HeaderText = "Empresa Flete";
            this.empresaFleteDataGridViewTextBoxColumn.Name = "empresaFleteDataGridViewTextBoxColumn";
            this.empresaFleteDataGridViewTextBoxColumn.ReadOnly = true;
            this.empresaFleteDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechaDespachoDataGridViewTextBoxColumn
            // 
            this.fechaDespachoDataGridViewTextBoxColumn.DataPropertyName = "FechaDespacho";
            this.fechaDespachoDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDespachoDataGridViewTextBoxColumn.Name = "fechaDespachoDataGridViewTextBoxColumn";
            this.fechaDespachoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDespachoDataGridViewTextBoxColumn.Width = 80;
            // 
            // statusRutaDataGridViewTextBoxColumn
            // 
            this.statusRutaDataGridViewTextBoxColumn.DataPropertyName = "StatusRuta";
            this.statusRutaDataGridViewTextBoxColumn.HeaderText = "StatusRuta";
            this.statusRutaDataGridViewTextBoxColumn.Name = "statusRutaDataGridViewTextBoxColumn";
            this.statusRutaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // choferDataGridViewTextBoxColumn
            // 
            this.choferDataGridViewTextBoxColumn.DataPropertyName = "Chofer";
            this.choferDataGridViewTextBoxColumn.HeaderText = "Chofer";
            this.choferDataGridViewTextBoxColumn.Name = "choferDataGridViewTextBoxColumn";
            this.choferDataGridViewTextBoxColumn.ReadOnly = true;
            this.choferDataGridViewTextBoxColumn.Width = 130;
            // 
            // descripcionFleteDataGridViewTextBoxColumn
            // 
            this.descripcionFleteDataGridViewTextBoxColumn.DataPropertyName = "DescripcionFlete";
            this.descripcionFleteDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.descripcionFleteDataGridViewTextBoxColumn.Name = "descripcionFleteDataGridViewTextBoxColumn";
            this.descripcionFleteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // horaSalidaDataGridViewTextBoxColumn
            // 
            this.horaSalidaDataGridViewTextBoxColumn.DataPropertyName = "HoraSalida";
            this.horaSalidaDataGridViewTextBoxColumn.HeaderText = "Salida";
            this.horaSalidaDataGridViewTextBoxColumn.Name = "horaSalidaDataGridViewTextBoxColumn";
            this.horaSalidaDataGridViewTextBoxColumn.ReadOnly = true;
            this.horaSalidaDataGridViewTextBoxColumn.Width = 120;
            // 
            // horaLlegadaDataGridViewTextBoxColumn
            // 
            this.horaLlegadaDataGridViewTextBoxColumn.DataPropertyName = "HoraLlegada";
            this.horaLlegadaDataGridViewTextBoxColumn.HeaderText = "Llegada";
            this.horaLlegadaDataGridViewTextBoxColumn.Name = "horaLlegadaDataGridViewTextBoxColumn";
            this.horaLlegadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.horaLlegadaDataGridViewTextBoxColumn.Width = 120;
            // 
            // costoFleteDataGridViewTextBoxColumn
            // 
            this.costoFleteDataGridViewTextBoxColumn.DataPropertyName = "CostoFlete";
            this.costoFleteDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoFleteDataGridViewTextBoxColumn.Name = "costoFleteDataGridViewTextBoxColumn";
            this.costoFleteDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoFleteDataGridViewTextBoxColumn.Width = 80;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "VER";
            this.Edit.ToolTipText = "Ver/Editar Detalles";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 60;
            // 
            // FrmCentroPreparacionHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 808);
            this.Controls.Add(this.ckSinRutaAsignada);
            this.Controls.Add(this.btnNewHRuta);
            this.Controls.Add(this.dgvHojaRuta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroRemito);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvEntregas);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCentroPreparacionHojaRuta";
            this.Text = "CONSOLIDACION DE ENVIOS - CENTRO DE ENVIOS";
            this.Load += new System.EventHandler(this.FrmHojaRutaPreparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059ENTREGASBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHojaRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059HOJARUTAHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEntregas;
        private System.Windows.Forms.BindingSource t0059ENTREGASBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNumeroRemito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckRetiraCliente;
        private System.Windows.Forms.CheckBox ckEntregaACliente;
        private System.Windows.Forms.CheckBox ckSinAsignar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEntregasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRutaAsignadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvHojaRuta;
        private System.Windows.Forms.BindingSource t0059HOJARUTAHBindingSource;
        private System.Windows.Forms.Button btnNewHRuta;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckSinRutaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRutaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaFleteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaFleteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDespachoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusRutaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn choferDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFleteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaSalidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaLlegadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoFleteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}