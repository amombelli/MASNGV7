namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    partial class FrmHojaRuta
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNumeroRuta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstadoRuta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.dtpFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirmarHRuta = new System.Windows.Forms.Button();
            this.btnAddRemitosToRuta = new System.Windows.Forms.Button();
            this.cmbTipoEnvio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreChofer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKmRecorridos = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCostoArs = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvRemitosHRuta = new System.Windows.Forms.DataGridView();
            this.t0059HOJARUTAIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraLlegada = new System.Windows.Forms.DateTimePicker();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idRutaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionCompletaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgEntregadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entregaMuestraDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.retiraPagoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.observacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadBultosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prorrateoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arriba = new System.Windows.Forms.DataGridViewButtonColumn();
            this.abajo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnImprimirHojaRuta = new System.Windows.Forms.Button();
            this.btnCerrarHojaRuta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosHRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059HOJARUTAIBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1098, 20);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(119, 41);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNumeroRuta
            // 
            this.txtNumeroRuta.Location = new System.Drawing.Point(172, 10);
            this.txtNumeroRuta.Name = "txtNumeroRuta";
            this.txtNumeroRuta.ReadOnly = true;
            this.txtNumeroRuta.Size = new System.Drawing.Size(64, 22);
            this.txtNumeroRuta.TabIndex = 1;
            this.txtNumeroRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "NUMERO DE HOJA DE RUTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "ESTADO HOJA RUTA";
            // 
            // txtEstadoRuta
            // 
            this.txtEstadoRuta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoRuta.Location = new System.Drawing.Point(172, 33);
            this.txtEstadoRuta.Name = "txtEstadoRuta";
            this.txtEstadoRuta.Size = new System.Drawing.Size(132, 22);
            this.txtEstadoRuta.TabIndex = 3;
            this.txtEstadoRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "NOMBRE EMPRESA";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(172, 114);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(154, 22);
            this.txtNombreEmpresa.TabIndex = 5;
            // 
            // dtpFechaEnvio
            // 
            this.dtpFechaEnvio.Location = new System.Drawing.Point(172, 66);
            this.dtpFechaEnvio.Name = "dtpFechaEnvio";
            this.dtpFechaEnvio.Size = new System.Drawing.Size(258, 22);
            this.dtpFechaEnvio.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "FECHA DE ENVIO";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(12, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(785, 2);
            this.label5.TabIndex = 9;
            // 
            // btnConfirmarHRuta
            // 
            this.btnConfirmarHRuta.Location = new System.Drawing.Point(1098, 102);
            this.btnConfirmarHRuta.Name = "btnConfirmarHRuta";
            this.btnConfirmarHRuta.Size = new System.Drawing.Size(119, 41);
            this.btnConfirmarHRuta.TabIndex = 10;
            this.btnConfirmarHRuta.Text = "CONFIRMAR\r\nHOJA RUTA";
            this.btnConfirmarHRuta.UseVisualStyleBackColor = true;
            this.btnConfirmarHRuta.Click += new System.EventHandler(this.btnConfirmarHRuta_Click);
            // 
            // btnAddRemitosToRuta
            // 
            this.btnAddRemitosToRuta.Location = new System.Drawing.Point(1098, 61);
            this.btnAddRemitosToRuta.Name = "btnAddRemitosToRuta";
            this.btnAddRemitosToRuta.Size = new System.Drawing.Size(119, 41);
            this.btnAddRemitosToRuta.TabIndex = 11;
            this.btnAddRemitosToRuta.Text = "AGREGAR\r\nREMITOS";
            this.btnAddRemitosToRuta.UseVisualStyleBackColor = true;
            this.btnAddRemitosToRuta.Click += new System.EventHandler(this.btnAddRemitosToRuta_Click);
            // 
            // cmbTipoEnvio
            // 
            this.cmbTipoEnvio.FormattingEnabled = true;
            this.cmbTipoEnvio.Items.AddRange(new object[] {
            "FLETE PROPIO",
            "FLETE CONTRATADO",
            "MOTO",
            "OTRO PROPIO",
            "CLIENTE"});
            this.cmbTipoEnvio.Location = new System.Drawing.Point(172, 90);
            this.cmbTipoEnvio.Name = "cmbTipoEnvio";
            this.cmbTipoEnvio.Size = new System.Drawing.Size(154, 22);
            this.cmbTipoEnvio.TabIndex = 13;
            this.cmbTipoEnvio.SelectedIndexChanged += new System.EventHandler(this.cmbTipoEnvio_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "TIPO ENVIO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "NOMBRE CHOFER";
            // 
            // txtNombreChofer
            // 
            this.txtNombreChofer.Location = new System.Drawing.Point(478, 114);
            this.txtNombreChofer.Name = "txtNombreChofer";
            this.txtNombreChofer.Size = new System.Drawing.Size(305, 22);
            this.txtNombreChofer.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(371, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "MATRICULA ";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(478, 139);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(99, 22);
            this.txtMatricula.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = "HORA SALIDA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 14);
            this.label12.TabIndex = 26;
            this.label12.Text = "HORA LLEGADA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(627, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "KM RECORRIDO";
            // 
            // txtKmRecorridos
            // 
            this.txtKmRecorridos.Location = new System.Drawing.Point(720, 177);
            this.txtKmRecorridos.Name = "txtKmRecorridos";
            this.txtKmRecorridos.Size = new System.Drawing.Size(62, 22);
            this.txtKmRecorridos.TabIndex = 27;
            this.txtKmRecorridos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKmRecorridos_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(636, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 14);
            this.label14.TabIndex = 30;
            this.label14.Text = "COSTO [ARS]";
            // 
            // txtCostoArs
            // 
            this.txtCostoArs.Location = new System.Drawing.Point(720, 201);
            this.txtCostoArs.Name = "txtCostoArs";
            this.txtCostoArs.Size = new System.Drawing.Size(62, 22);
            this.txtCostoArs.TabIndex = 29;
            this.txtCostoArs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKmRecorridos_KeyPress);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(12, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(785, 2);
            this.label15.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(12, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(785, 2);
            this.label7.TabIndex = 32;
            // 
            // dgvRemitosHRuta
            // 
            this.dgvRemitosHRuta.AllowUserToAddRows = false;
            this.dgvRemitosHRuta.AllowUserToDeleteRows = false;
            this.dgvRemitosHRuta.AutoGenerateColumns = false;
            this.dgvRemitosHRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitosHRuta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalle,
            this.idRutaDataGridViewTextBoxColumn1,
            this.idItemDataGridViewTextBoxColumn,
            this.idRemitoDataGridViewTextBoxColumn,
            this.numeroRemitoDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.direccionCompletaDataGridViewTextBoxColumn,
            this.kgEntregadosDataGridViewTextBoxColumn,
            this.entregaMuestraDataGridViewCheckBoxColumn,
            this.retiraPagoDataGridViewCheckBoxColumn,
            this.observacionDataGridViewTextBoxColumn,
            this.cantidadBultosDataGridViewTextBoxColumn,
            this.cargoClienteDataGridViewTextBoxColumn,
            this.prorrateoDataGridViewTextBoxColumn,
            this.statusEntregaDataGridViewTextBoxColumn,
            this.ordenEntregaDataGridViewTextBoxColumn,
            this.arriba,
            this.abajo});
            this.dgvRemitosHRuta.DataSource = this.t0059HOJARUTAIBindingSource;
            this.dgvRemitosHRuta.Location = new System.Drawing.Point(12, 251);
            this.dgvRemitosHRuta.Name = "dgvRemitosHRuta";
            this.dgvRemitosHRuta.ReadOnly = true;
            this.dgvRemitosHRuta.Size = new System.Drawing.Size(1205, 375);
            this.dgvRemitosHRuta.TabIndex = 33;
            this.dgvRemitosHRuta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitosHRuta_CellContentClick);
            // 
            // t0059HOJARUTAIBindingSource
            // 
            this.t0059HOJARUTAIBindingSource.DataSource = typeof(TecserEF.Entity.T0059_HOJARUTA_I);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(371, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 14);
            this.label9.TabIndex = 36;
            this.label9.Text = "DESCRIPCION/OBS";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(478, 90);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(305, 22);
            this.txtObservaciones.TabIndex = 35;
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalida.Location = new System.Drawing.Point(172, 177);
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.Size = new System.Drawing.Size(122, 22);
            this.dtpHoraSalida.TabIndex = 37;
            // 
            // dtpHoraLlegada
            // 
            this.dtpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraLlegada.Location = new System.Drawing.Point(172, 201);
            this.dtpHoraLlegada.Name = "dtpHoraLlegada";
            this.dtpHoraLlegada.Size = new System.Drawing.Size(122, 22);
            this.dtpHoraLlegada.TabIndex = 38;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Detalle.Text = "Detalle";
            this.Detalle.ToolTipText = "Ver Detalle Entrega";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 55;
            // 
            // idRutaDataGridViewTextBoxColumn1
            // 
            this.idRutaDataGridViewTextBoxColumn1.DataPropertyName = "IdRuta";
            this.idRutaDataGridViewTextBoxColumn1.HeaderText = "IdRuta";
            this.idRutaDataGridViewTextBoxColumn1.Name = "idRutaDataGridViewTextBoxColumn1";
            this.idRutaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idRutaDataGridViewTextBoxColumn1.Visible = false;
            // 
            // idItemDataGridViewTextBoxColumn
            // 
            this.idItemDataGridViewTextBoxColumn.DataPropertyName = "IdItem";
            this.idItemDataGridViewTextBoxColumn.HeaderText = "#";
            this.idItemDataGridViewTextBoxColumn.Name = "idItemDataGridViewTextBoxColumn";
            this.idItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemDataGridViewTextBoxColumn.Width = 20;
            // 
            // idRemitoDataGridViewTextBoxColumn
            // 
            this.idRemitoDataGridViewTextBoxColumn.DataPropertyName = "IdRemito";
            this.idRemitoDataGridViewTextBoxColumn.HeaderText = "IdRemito";
            this.idRemitoDataGridViewTextBoxColumn.Name = "idRemitoDataGridViewTextBoxColumn";
            this.idRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRemitoDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroRemitoDataGridViewTextBoxColumn
            // 
            this.numeroRemitoDataGridViewTextBoxColumn.DataPropertyName = "NumeroRemito";
            this.numeroRemitoDataGridViewTextBoxColumn.HeaderText = "Remito";
            this.numeroRemitoDataGridViewTextBoxColumn.Name = "numeroRemitoDataGridViewTextBoxColumn";
            this.numeroRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroRemitoDataGridViewTextBoxColumn.Width = 75;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 130;
            // 
            // direccionCompletaDataGridViewTextBoxColumn
            // 
            this.direccionCompletaDataGridViewTextBoxColumn.DataPropertyName = "DireccionCompleta";
            this.direccionCompletaDataGridViewTextBoxColumn.HeaderText = "Direccion Entrega";
            this.direccionCompletaDataGridViewTextBoxColumn.Name = "direccionCompletaDataGridViewTextBoxColumn";
            this.direccionCompletaDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionCompletaDataGridViewTextBoxColumn.Width = 180;
            // 
            // kgEntregadosDataGridViewTextBoxColumn
            // 
            this.kgEntregadosDataGridViewTextBoxColumn.DataPropertyName = "KgEntregados";
            this.kgEntregadosDataGridViewTextBoxColumn.HeaderText = "Kg";
            this.kgEntregadosDataGridViewTextBoxColumn.Name = "kgEntregadosDataGridViewTextBoxColumn";
            this.kgEntregadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgEntregadosDataGridViewTextBoxColumn.Width = 50;
            // 
            // entregaMuestraDataGridViewCheckBoxColumn
            // 
            this.entregaMuestraDataGridViewCheckBoxColumn.DataPropertyName = "EntregaMuestra";
            this.entregaMuestraDataGridViewCheckBoxColumn.HeaderText = "Muestra";
            this.entregaMuestraDataGridViewCheckBoxColumn.Name = "entregaMuestraDataGridViewCheckBoxColumn";
            this.entregaMuestraDataGridViewCheckBoxColumn.ReadOnly = true;
            this.entregaMuestraDataGridViewCheckBoxColumn.Width = 60;
            // 
            // retiraPagoDataGridViewCheckBoxColumn
            // 
            this.retiraPagoDataGridViewCheckBoxColumn.DataPropertyName = "RetiraPago";
            this.retiraPagoDataGridViewCheckBoxColumn.HeaderText = "Pago";
            this.retiraPagoDataGridViewCheckBoxColumn.Name = "retiraPagoDataGridViewCheckBoxColumn";
            this.retiraPagoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.retiraPagoDataGridViewCheckBoxColumn.Width = 50;
            // 
            // observacionDataGridViewTextBoxColumn
            // 
            this.observacionDataGridViewTextBoxColumn.DataPropertyName = "Observacion";
            this.observacionDataGridViewTextBoxColumn.HeaderText = "Observacion";
            this.observacionDataGridViewTextBoxColumn.Name = "observacionDataGridViewTextBoxColumn";
            this.observacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // cantidadBultosDataGridViewTextBoxColumn
            // 
            this.cantidadBultosDataGridViewTextBoxColumn.DataPropertyName = "CantidadBultos";
            this.cantidadBultosDataGridViewTextBoxColumn.HeaderText = "Bultos";
            this.cantidadBultosDataGridViewTextBoxColumn.Name = "cantidadBultosDataGridViewTextBoxColumn";
            this.cantidadBultosDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadBultosDataGridViewTextBoxColumn.Width = 50;
            // 
            // cargoClienteDataGridViewTextBoxColumn
            // 
            this.cargoClienteDataGridViewTextBoxColumn.DataPropertyName = "CargoCliente";
            this.cargoClienteDataGridViewTextBoxColumn.HeaderText = "C/Cargo";
            this.cargoClienteDataGridViewTextBoxColumn.Name = "cargoClienteDataGridViewTextBoxColumn";
            this.cargoClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cargoClienteDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cargoClienteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cargoClienteDataGridViewTextBoxColumn.Width = 70;
            // 
            // prorrateoDataGridViewTextBoxColumn
            // 
            this.prorrateoDataGridViewTextBoxColumn.DataPropertyName = "Prorrateo";
            this.prorrateoDataGridViewTextBoxColumn.HeaderText = "Prorrateo";
            this.prorrateoDataGridViewTextBoxColumn.Name = "prorrateoDataGridViewTextBoxColumn";
            this.prorrateoDataGridViewTextBoxColumn.ReadOnly = true;
            this.prorrateoDataGridViewTextBoxColumn.Width = 70;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "Status Entrega";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusEntregaDataGridViewTextBoxColumn.Width = 120;
            // 
            // ordenEntregaDataGridViewTextBoxColumn
            // 
            this.ordenEntregaDataGridViewTextBoxColumn.DataPropertyName = "OrdenEntrega";
            this.ordenEntregaDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenEntregaDataGridViewTextBoxColumn.Name = "ordenEntregaDataGridViewTextBoxColumn";
            this.ordenEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenEntregaDataGridViewTextBoxColumn.Width = 50;
            // 
            // arriba
            // 
            this.arriba.HeaderText = "+";
            this.arriba.Name = "arriba";
            this.arriba.ReadOnly = true;
            this.arriba.Text = "+";
            this.arriba.ToolTipText = "Mas Prioridad";
            this.arriba.UseColumnTextForButtonValue = true;
            this.arriba.Width = 30;
            // 
            // abajo
            // 
            this.abajo.HeaderText = "-";
            this.abajo.Name = "abajo";
            this.abajo.ReadOnly = true;
            this.abajo.Text = "-";
            this.abajo.ToolTipText = "Menos Prioridad";
            this.abajo.UseColumnTextForButtonValue = true;
            this.abajo.Width = 30;
            // 
            // btnImprimirHojaRuta
            // 
            this.btnImprimirHojaRuta.Location = new System.Drawing.Point(1098, 144);
            this.btnImprimirHojaRuta.Name = "btnImprimirHojaRuta";
            this.btnImprimirHojaRuta.Size = new System.Drawing.Size(119, 41);
            this.btnImprimirHojaRuta.TabIndex = 39;
            this.btnImprimirHojaRuta.Text = "IMPRIMIR\r\nHOJA RUTA";
            this.btnImprimirHojaRuta.UseVisualStyleBackColor = true;
            this.btnImprimirHojaRuta.Click += new System.EventHandler(this.btnImprimirHojaRuta_Click);
            // 
            // btnCerrarHojaRuta
            // 
            this.btnCerrarHojaRuta.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnCerrarHojaRuta.Location = new System.Drawing.Point(1098, 186);
            this.btnCerrarHojaRuta.Name = "btnCerrarHojaRuta";
            this.btnCerrarHojaRuta.Size = new System.Drawing.Size(119, 41);
            this.btnCerrarHojaRuta.TabIndex = 40;
            this.btnCerrarHojaRuta.Text = "CERRAR OK\r\nHOJA RUTA";
            this.btnCerrarHojaRuta.UseVisualStyleBackColor = true;
            this.btnCerrarHojaRuta.Click += new System.EventHandler(this.btnCerrarHojaRuta_Click);
            // 
            // FrmHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 776);
            this.Controls.Add(this.btnCerrarHojaRuta);
            this.Controls.Add(this.btnImprimirHojaRuta);
            this.Controls.Add(this.dtpHoraLlegada);
            this.Controls.Add(this.dtpHoraSalida);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.dgvRemitosHRuta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCostoArs);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtKmRecorridos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreChofer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTipoEnvio);
            this.Controls.Add(this.btnAddRemitosToRuta);
            this.Controls.Add(this.btnConfirmarHRuta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaEnvio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstadoRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroRuta);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHojaRuta";
            this.Text = "DETALLE DE HOJA DE RUTA";
            this.Load += new System.EventHandler(this.FrmHojaRuta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosHRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059HOJARUTAIBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNumeroRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstadoRuta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.DateTimePicker dtpFechaEnvio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmarHRuta;
        private System.Windows.Forms.Button btnAddRemitosToRuta;
        private System.Windows.Forms.ComboBox cmbTipoEnvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreChofer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtKmRecorridos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCostoArs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvRemitosHRuta;
        private System.Windows.Forms.BindingSource t0059HOJARUTAIBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.DateTimePicker dtpHoraLlegada;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRutaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionCompletaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgEntregadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn entregaMuestraDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn retiraPagoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadBultosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cargoClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prorrateoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn arriba;
        private System.Windows.Forms.DataGridViewButtonColumn abajo;
        private System.Windows.Forms.Button btnImprimirHojaRuta;
        private System.Windows.Forms.Button btnCerrarHojaRuta;
    }
}