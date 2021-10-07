namespace MASngFE.Transactional.PP
{
    partial class FrmPP17AddUpdateDetalleRecursosProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP17AddUpdateDetalleRecursosProduccion));
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtHoraFin = new System.Windows.Forms.MaskedTextBox();
            this.txtHoraInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtObservacionesIngreso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKgIngresados = new System.Windows.Forms.TextBox();
            this.dtpFechaFabricacion = new System.Windows.Forms.DateTimePicker();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.cmbRecursoProduccion = new System.Windows.Forms.ComboBox();
            this.t0032RECURSOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtResponsableIngreso = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDuracionMinutos = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumeroStops = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDuracionStops = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCantidadPasadas = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtObservacionesStop = new System.Windows.Forms.TextBox();
            this.ckLimpiezaCompleta = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ckLimpiezaCabezal = new System.Windows.Forms.CheckBox();
            this.btnModificarDetalle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtId40 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstadoOF = new System.Windows.Forms.TextBox();
            this.txtMaterialFabricado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0032RECURSOSBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(4, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(574, 21);
            this.label9.TabIndex = 102;
            this.label9.Text = "--- DETALLE DEL MOVIMIENTO DE INGRESO ---";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.txtHoraFin);
            this.panel4.Controls.Add(this.txtHoraInicio);
            this.panel4.Controls.Add(this.txtObservacionesIngreso);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txtKgIngresados);
            this.panel4.Controls.Add(this.dtpFechaFabricacion);
            this.panel4.Controls.Add(this.cmbOperador);
            this.panel4.Controls.Add(this.cmbRecursoProduccion);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.txtResponsableIngreso);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.txtFechaIngreso);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtDuracionMinutos);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txtNumeroStops);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.txtDuracionStops);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txtCantidadPasadas);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.txtObservacionesStop);
            this.panel4.Controls.Add(this.ckLimpiezaCompleta);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.ckLimpiezaCabezal);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(4, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(574, 269);
            this.panel4.TabIndex = 101;
            // 
            // txtHoraFin
            // 
            this.txtHoraFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraFin.Location = new System.Drawing.Point(137, 183);
            this.txtHoraFin.Mask = "00:00";
            this.txtHoraFin.Name = "txtHoraFin";
            this.txtHoraFin.Size = new System.Drawing.Size(62, 21);
            this.txtHoraFin.TabIndex = 108;
            this.txtHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraFin.ValidatingType = typeof(System.DateTime);
            this.txtHoraFin.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtHoraInicio_MaskInputRejected);
            this.txtHoraFin.Validating += new System.ComponentModel.CancelEventHandler(this.txtHoraFin_Validating);
            this.txtHoraFin.Validated += new System.EventHandler(this.txtHoraInicio_Validated);
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraInicio.Location = new System.Drawing.Point(137, 160);
            this.txtHoraInicio.Mask = "00:00";
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(62, 21);
            this.txtHoraInicio.TabIndex = 107;
            this.txtHoraInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraInicio.ValidatingType = typeof(System.DateTime);
            this.txtHoraInicio.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtHoraInicio_MaskInputRejected);
            this.txtHoraInicio.Validating += new System.ComponentModel.CancelEventHandler(this.txtHoraInicio_Validating);
            this.txtHoraInicio.Validated += new System.EventHandler(this.txtHoraInicio_Validated);
            // 
            // txtObservacionesIngreso
            // 
            this.txtObservacionesIngreso.BackColor = System.Drawing.Color.White;
            this.txtObservacionesIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesIngreso.Location = new System.Drawing.Point(162, 121);
            this.txtObservacionesIngreso.Name = "txtObservacionesIngreso";
            this.txtObservacionesIngreso.Size = new System.Drawing.Size(403, 21);
            this.txtObservacionesIngreso.TabIndex = 73;
            this.txtObservacionesIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 15);
            this.label6.TabIndex = 74;
            this.label6.Text = "Observaciones Ingreso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 72;
            this.label5.Text = "KG Ingresados";
            // 
            // txtKgIngresados
            // 
            this.txtKgIngresados.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKgIngresados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgIngresados.Location = new System.Drawing.Point(478, 6);
            this.txtKgIngresados.Name = "txtKgIngresados";
            this.txtKgIngresados.ReadOnly = true;
            this.txtKgIngresados.Size = new System.Drawing.Size(74, 21);
            this.txtKgIngresados.TabIndex = 71;
            this.txtKgIngresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaFabricacion
            // 
            this.dtpFechaFabricacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFabricacion.Location = new System.Drawing.Point(162, 52);
            this.dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            this.dtpFechaFabricacion.Size = new System.Drawing.Size(237, 22);
            this.dtpFechaFabricacion.TabIndex = 70;
            // 
            // cmbOperador
            // 
            this.cmbOperador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOperador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOperador.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(162, 6);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(160, 22);
            this.cmbOperador.TabIndex = 69;
            // 
            // cmbRecursoProduccion
            // 
            this.cmbRecursoProduccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecursoProduccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecursoProduccion.DataSource = this.t0032RECURSOSBindingSource;
            this.cmbRecursoProduccion.DisplayMember = "DescRecurso";
            this.cmbRecursoProduccion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecursoProduccion.FormattingEnabled = true;
            this.cmbRecursoProduccion.Location = new System.Drawing.Point(162, 29);
            this.cmbRecursoProduccion.Name = "cmbRecursoProduccion";
            this.cmbRecursoProduccion.Size = new System.Drawing.Size(160, 22);
            this.cmbRecursoProduccion.TabIndex = 68;
            this.cmbRecursoProduccion.ValueMember = "IdRecurso";
            // 
            // t0032RECURSOSBindingSource
            // 
            this.t0032RECURSOSBindingSource.DataSource = typeof(TecserEF.Entity.T0032_RECURSOS);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(205, 157);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(3, 70);
            this.label29.TabIndex = 67;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 147);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(557, 3);
            this.label27.TabIndex = 66;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(13, 101);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(124, 15);
            this.label26.TabIndex = 65;
            this.label26.Text = "Responsable Ingreso";
            // 
            // txtResponsableIngreso
            // 
            this.txtResponsableIngreso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResponsableIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponsableIngreso.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtResponsableIngreso.Location = new System.Drawing.Point(162, 98);
            this.txtResponsableIngreso.Name = "txtResponsableIngreso";
            this.txtResponsableIngreso.ReadOnly = true;
            this.txtResponsableIngreso.Size = new System.Drawing.Size(130, 21);
            this.txtResponsableIngreso.TabIndex = 64;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(13, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(121, 15);
            this.label25.TabIndex = 63;
            this.label25.Text = "Fecha Ingreso/Cierre";
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaIngreso.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtFechaIngreso.Location = new System.Drawing.Point(162, 75);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(237, 21);
            this.txtFechaIngreso.TabIndex = 62;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(13, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(145, 15);
            this.label24.TabIndex = 61;
            this.label24.Text = "Fecha Fabricacion (Real)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Hora Inicio [HH:MM]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 15);
            this.label13.TabIndex = 34;
            this.label13.Text = "Hora Fin [HH:MM]";
            // 
            // txtDuracionMinutos
            // 
            this.txtDuracionMinutos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDuracionMinutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuracionMinutos.Location = new System.Drawing.Point(150, 206);
            this.txtDuracionMinutos.Name = "txtDuracionMinutos";
            this.txtDuracionMinutos.ReadOnly = true;
            this.txtDuracionMinutos.Size = new System.Drawing.Size(49, 21);
            this.txtDuracionMinutos.TabIndex = 35;
            this.txtDuracionMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuracionMinutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracionMinutos_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 15);
            this.label14.TabIndex = 36;
            this.label14.Text = "Duracion (Minutos)";
            // 
            // txtNumeroStops
            // 
            this.txtNumeroStops.BackColor = System.Drawing.Color.White;
            this.txtNumeroStops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroStops.Location = new System.Drawing.Point(346, 160);
            this.txtNumeroStops.Name = "txtNumeroStops";
            this.txtNumeroStops.Size = new System.Drawing.Size(49, 21);
            this.txtNumeroStops.TabIndex = 45;
            this.txtNumeroStops.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroStops.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracionMinutos_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(222, 163);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 15);
            this.label19.TabIndex = 46;
            this.label19.Text = "Cantidad de Stops";
            // 
            // txtDuracionStops
            // 
            this.txtDuracionStops.BackColor = System.Drawing.Color.White;
            this.txtDuracionStops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuracionStops.Location = new System.Drawing.Point(346, 183);
            this.txtDuracionStops.Name = "txtDuracionStops";
            this.txtDuracionStops.Size = new System.Drawing.Size(49, 21);
            this.txtDuracionStops.TabIndex = 47;
            this.txtDuracionStops.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuracionStops.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracionMinutos_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(135, 15);
            this.label17.TabIndex = 58;
            this.label17.Text = "Operador Responsable";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(222, 186);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 15);
            this.label20.TabIndex = 48;
            this.label20.Text = "Duracion Stops (Min)";
            // 
            // txtCantidadPasadas
            // 
            this.txtCantidadPasadas.BackColor = System.Drawing.Color.White;
            this.txtCantidadPasadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPasadas.Location = new System.Drawing.Point(346, 206);
            this.txtCantidadPasadas.Name = "txtCantidadPasadas";
            this.txtCantidadPasadas.Size = new System.Drawing.Size(22, 21);
            this.txtCantidadPasadas.TabIndex = 49;
            this.txtCantidadPasadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadPasadas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracionMinutos_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 15);
            this.label16.TabIndex = 56;
            this.label16.Text = "Recurso Productivo";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(222, 209);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 15);
            this.label18.TabIndex = 50;
            this.label18.Text = "Cantidad Pasadas";
            // 
            // txtObservacionesStop
            // 
            this.txtObservacionesStop.BackColor = System.Drawing.Color.White;
            this.txtObservacionesStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesStop.Location = new System.Drawing.Point(107, 244);
            this.txtObservacionesStop.Name = "txtObservacionesStop";
            this.txtObservacionesStop.Size = new System.Drawing.Size(458, 21);
            this.txtObservacionesStop.TabIndex = 51;
            this.txtObservacionesStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckLimpiezaCompleta
            // 
            this.ckLimpiezaCompleta.AutoSize = true;
            this.ckLimpiezaCompleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLimpiezaCompleta.Location = new System.Drawing.Point(416, 191);
            this.ckLimpiezaCompleta.Name = "ckLimpiezaCompleta";
            this.ckLimpiezaCompleta.Size = new System.Drawing.Size(133, 19);
            this.ckLimpiezaCompleta.TabIndex = 54;
            this.ckLimpiezaCompleta.Text = "Limpieza Completa";
            this.ckLimpiezaCompleta.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 52;
            this.label15.Text = "Observ. Stops";
            // 
            // ckLimpiezaCabezal
            // 
            this.ckLimpiezaCabezal.AutoSize = true;
            this.ckLimpiezaCabezal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLimpiezaCabezal.Location = new System.Drawing.Point(416, 171);
            this.ckLimpiezaCabezal.Name = "ckLimpiezaCabezal";
            this.ckLimpiezaCabezal.Size = new System.Drawing.Size(142, 19);
            this.ckLimpiezaCabezal.TabIndex = 53;
            this.ckLimpiezaCabezal.Text = "Limpieza de Cabezal";
            this.ckLimpiezaCabezal.UseVisualStyleBackColor = true;
            // 
            // btnModificarDetalle
            // 
            this.btnModificarDetalle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarDetalle.Image")));
            this.btnModificarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarDetalle.Location = new System.Drawing.Point(584, 48);
            this.btnModificarDetalle.Name = "btnModificarDetalle";
            this.btnModificarDetalle.Size = new System.Drawing.Size(100, 44);
            this.btnModificarDetalle.TabIndex = 92;
            this.btnModificarDetalle.Text = "Grabar\r\nCambios";
            this.btnModificarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarDetalle.UseVisualStyleBackColor = true;
            this.btnModificarDetalle.Click += new System.EventHandler(this.btnModificarDetalle_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.txtId40);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtNumeroOF);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtEstadoOF);
            this.panel3.Controls.Add(this.txtMaterialFabricado);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 53);
            this.panel3.TabIndex = 103;
            // 
            // txtId40
            // 
            this.txtId40.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId40.Location = new System.Drawing.Point(451, 26);
            this.txtId40.Name = "txtId40";
            this.txtId40.ReadOnly = true;
            this.txtId40.Size = new System.Drawing.Size(56, 21);
            this.txtId40.TabIndex = 20;
            this.txtId40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(378, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "ID Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Estado OF";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.Location = new System.Drawing.Point(114, 3);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.ReadOnly = true;
            this.txtNumeroOF.Size = new System.Drawing.Size(74, 22);
            this.txtNumeroOF.TabIndex = 14;
            this.txtNumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Numero OF";
            // 
            // txtEstadoOF
            // 
            this.txtEstadoOF.BackColor = System.Drawing.Color.White;
            this.txtEstadoOF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoOF.Location = new System.Drawing.Point(114, 26);
            this.txtEstadoOF.Name = "txtEstadoOF";
            this.txtEstadoOF.ReadOnly = true;
            this.txtEstadoOF.Size = new System.Drawing.Size(103, 22);
            this.txtEstadoOF.TabIndex = 16;
            this.txtEstadoOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterialFabricado
            // 
            this.txtMaterialFabricado.BackColor = System.Drawing.Color.MintCream;
            this.txtMaterialFabricado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialFabricado.ForeColor = System.Drawing.Color.Crimson;
            this.txtMaterialFabricado.Location = new System.Drawing.Point(451, 3);
            this.txtMaterialFabricado.Name = "txtMaterialFabricado";
            this.txtMaterialFabricado.ReadOnly = true;
            this.txtMaterialFabricado.Size = new System.Drawing.Size(117, 22);
            this.txtMaterialFabricado.TabIndex = 5;
            this.txtMaterialFabricado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(325, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "MATERIAL FABRICADO";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(584, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 44);
            this.btnExit.TabIndex = 106;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmPP17AddUpdateDetalleRecursosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 358);
            this.ControlBox = false;
            this.Controls.Add(this.btnModificarDetalle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel4);
            this.Name = "FrmPP17AddUpdateDetalleRecursosProduccion";
            this.Text = "PP17 - Detalle de Produccion";
            this.Load += new System.EventHandler(this.FrmPP17AddUpdateDetalleRecursosProduccion_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0032RECURSOSBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnModificarDetalle;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtResponsableIngreso;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDuracionMinutos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNumeroStops;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDuracionStops;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCantidadPasadas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtObservacionesStop;
        private System.Windows.Forms.CheckBox ckLimpiezaCompleta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckLimpiezaCabezal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstadoOF;
        private System.Windows.Forms.TextBox txtMaterialFabricado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtId40;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKgIngresados;
        private System.Windows.Forms.DateTimePicker dtpFechaFabricacion;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.ComboBox cmbRecursoProduccion;
        private System.Windows.Forms.BindingSource t0032RECURSOSBindingSource;
        private System.Windows.Forms.TextBox txtObservacionesIngreso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtHoraFin;
        private System.Windows.Forms.MaskedTextBox txtHoraInicio;
    }
}