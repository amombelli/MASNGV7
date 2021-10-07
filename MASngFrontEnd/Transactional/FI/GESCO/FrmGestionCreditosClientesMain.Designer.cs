namespace MASngFE.Transactional.FI.GESCO
{
    partial class FrmGestionCreditosClientesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionCreditosClientesMain));
            this.panIdentificacion = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoTax = new System.Windows.Forms.ComboBox();
            this.txtNumeroTax = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.txtTaxValido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoTax = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.panBloqueo = new System.Windows.Forms.Panel();
            this.ckBloqueoPedido = new System.Windows.Forms.CheckBox();
            this.ckBloqueoEntrega = new System.Windows.Forms.CheckBox();
            this.panLimiteCredito = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.txtMotivoDescuento = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ztermL2Descripcion = new System.Windows.Forms.TextBox();
            this.cmbZtermL2 = new System.Windows.Forms.ComboBox();
            this.ckL5 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.txtZtermL1Descripcion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentaje = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLimiteCreditoMaximo = new System.Windows.Forms.TextBox();
            this.cmbZtermL1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.ZTermL1 = new System.Windows.Forms.BindingSource(this.components);
            this.ZtermL2 = new System.Windows.Forms.BindingSource(this.components);
            this.panIdentificacion.SuspendLayout();
            this.panBloqueo.SuspendLayout();
            this.panLimiteCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZTermL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZtermL2)).BeginInit();
            this.SuspendLayout();
            // 
            // panIdentificacion
            // 
            this.panIdentificacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panIdentificacion.Controls.Add(this.label7);
            this.panIdentificacion.Controls.Add(this.cmbTipoTax);
            this.panIdentificacion.Controls.Add(this.txtNumeroTax);
            this.panIdentificacion.Controls.Add(this.label4);
            this.panIdentificacion.Controls.Add(this.txtFantasia);
            this.panIdentificacion.Controls.Add(this.txtTaxValido);
            this.panIdentificacion.Controls.Add(this.label3);
            this.panIdentificacion.Controls.Add(this.txtCodigoTax);
            this.panIdentificacion.Controls.Add(this.txtRazonSocial);
            this.panIdentificacion.Controls.Add(this.label2);
            this.panIdentificacion.Controls.Add(this.txtEstado);
            this.panIdentificacion.Controls.Add(this.label1);
            this.panIdentificacion.Controls.Add(this.txtId6);
            this.panIdentificacion.Location = new System.Drawing.Point(1, 2);
            this.panIdentificacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panIdentificacion.Name = "panIdentificacion";
            this.panIdentificacion.Size = new System.Drawing.Size(583, 93);
            this.panIdentificacion.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(10, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Identificacion Fiscal";
            this.label7.UseWaitCursor = true;
            // 
            // cmbTipoTax
            // 
            this.cmbTipoTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoTax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbTipoTax.FormattingEnabled = true;
            this.cmbTipoTax.Items.AddRange(new object[] {
            "CUIT",
            "NI"});
            this.cmbTipoTax.Location = new System.Drawing.Point(116, 68);
            this.cmbTipoTax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbTipoTax.Name = "cmbTipoTax";
            this.cmbTipoTax.Size = new System.Drawing.Size(71, 21);
            this.cmbTipoTax.TabIndex = 19;
            this.cmbTipoTax.UseWaitCursor = true;
            // 
            // txtNumeroTax
            // 
            this.txtNumeroTax.BeepOnError = true;
            this.txtNumeroTax.Location = new System.Drawing.Point(229, 68);
            this.txtNumeroTax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNumeroTax.Mask = "00-00000000-0";
            this.txtNumeroTax.Name = "txtNumeroTax";
            this.txtNumeroTax.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroTax.TabIndex = 18;
            this.txtNumeroTax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumeroTax.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre Fantasia";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(116, 46);
            this.txtFantasia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(201, 20);
            this.txtFantasia.TabIndex = 7;
            // 
            // txtTaxValido
            // 
            this.txtTaxValido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTaxValido.Location = new System.Drawing.Point(319, 68);
            this.txtTaxValido.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTaxValido.Name = "txtTaxValido";
            this.txtTaxValido.ReadOnly = true;
            this.txtTaxValido.Size = new System.Drawing.Size(111, 20);
            this.txtTaxValido.TabIndex = 17;
            this.txtTaxValido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxValido.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razon Social";
            // 
            // txtCodigoTax
            // 
            this.txtCodigoTax.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCodigoTax.Location = new System.Drawing.Point(192, 68);
            this.txtCodigoTax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCodigoTax.Name = "txtCodigoTax";
            this.txtCodigoTax.ReadOnly = true;
            this.txtCodigoTax.Size = new System.Drawing.Size(34, 20);
            this.txtCodigoTax.TabIndex = 16;
            this.txtCodigoTax.UseWaitCursor = true;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(116, 25);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(314, 20);
            this.txtRazonSocial.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ESTADO";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtEstado.Location = new System.Drawing.Point(352, 4);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(78, 20);
            this.txtEstado.TabIndex = 3;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente ID";
            // 
            // txtId6
            // 
            this.txtId6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtId6.Enabled = false;
            this.txtId6.Location = new System.Drawing.Point(116, 4);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(51, 20);
            this.txtId6.TabIndex = 1;
            // 
            // panBloqueo
            // 
            this.panBloqueo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panBloqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBloqueo.Controls.Add(this.ckBloqueoPedido);
            this.panBloqueo.Controls.Add(this.ckBloqueoEntrega);
            this.panBloqueo.Location = new System.Drawing.Point(1, 123);
            this.panBloqueo.Name = "panBloqueo";
            this.panBloqueo.Size = new System.Drawing.Size(318, 54);
            this.panBloqueo.TabIndex = 36;
            // 
            // ckBloqueoPedido
            // 
            this.ckBloqueoPedido.AutoSize = true;
            this.ckBloqueoPedido.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBloqueoPedido.Location = new System.Drawing.Point(11, 7);
            this.ckBloqueoPedido.Name = "ckBloqueoPedido";
            this.ckBloqueoPedido.Size = new System.Drawing.Size(118, 19);
            this.ckBloqueoPedido.TabIndex = 33;
            this.ckBloqueoPedido.Text = "Bloqueo Pedidos";
            this.ckBloqueoPedido.UseVisualStyleBackColor = true;
            // 
            // ckBloqueoEntrega
            // 
            this.ckBloqueoEntrega.AutoSize = true;
            this.ckBloqueoEntrega.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBloqueoEntrega.Location = new System.Drawing.Point(11, 27);
            this.ckBloqueoEntrega.Name = "ckBloqueoEntrega";
            this.ckBloqueoEntrega.Size = new System.Drawing.Size(121, 19);
            this.ckBloqueoEntrega.TabIndex = 34;
            this.ckBloqueoEntrega.Text = "Bloqueo Entregas";
            this.ckBloqueoEntrega.UseVisualStyleBackColor = true;
            // 
            // panLimiteCredito
            // 
            this.panLimiteCredito.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panLimiteCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLimiteCredito.Controls.Add(this.label45);
            this.panLimiteCredito.Controls.Add(this.txtMotivoDescuento);
            this.panLimiteCredito.Controls.Add(this.label22);
            this.panLimiteCredito.Controls.Add(this.ztermL2Descripcion);
            this.panLimiteCredito.Controls.Add(this.cmbZtermL2);
            this.panLimiteCredito.Controls.Add(this.ckL5);
            this.panLimiteCredito.Controls.Add(this.label21);
            this.panLimiteCredito.Controls.Add(this.ckL2);
            this.panLimiteCredito.Controls.Add(this.label18);
            this.panLimiteCredito.Controls.Add(this.ckL1);
            this.panLimiteCredito.Controls.Add(this.txtZtermL1Descripcion);
            this.panLimiteCredito.Controls.Add(this.label15);
            this.panLimiteCredito.Controls.Add(this.txtDescuentoPorcentaje);
            this.panLimiteCredito.Controls.Add(this.label16);
            this.panLimiteCredito.Controls.Add(this.label17);
            this.panLimiteCredito.Controls.Add(this.label19);
            this.panLimiteCredito.Controls.Add(this.txtLimiteCreditoMaximo);
            this.panLimiteCredito.Controls.Add(this.cmbZtermL1);
            this.panLimiteCredito.Location = new System.Drawing.Point(1, 209);
            this.panLimiteCredito.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panLimiteCredito.Name = "panLimiteCredito";
            this.panLimiteCredito.Size = new System.Drawing.Size(583, 138);
            this.panLimiteCredito.TabIndex = 38;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.SystemColors.Info;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Crimson;
            this.label45.Location = new System.Drawing.Point(265, 70);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(311, 15);
            this.label45.TabIndex = 39;
            this.label45.Text = "Limite (-1) Para solicitar adelanto antes de tomar el pedido";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label45.UseWaitCursor = true;
            // 
            // txtMotivoDescuento
            // 
            this.txtMotivoDescuento.Location = new System.Drawing.Point(175, 110);
            this.txtMotivoDescuento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMotivoDescuento.Name = "txtMotivoDescuento";
            this.txtMotivoDescuento.Size = new System.Drawing.Size(402, 20);
            this.txtMotivoDescuento.TabIndex = 38;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 112);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(137, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Motivo Especial Descuento";
            // 
            // ztermL2Descripcion
            // 
            this.ztermL2Descripcion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ztermL2Descripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ZtermL2, "ZTERMDESC", true));
            this.ztermL2Descripcion.Location = new System.Drawing.Point(262, 46);
            this.ztermL2Descripcion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ztermL2Descripcion.Name = "ztermL2Descripcion";
            this.ztermL2Descripcion.ReadOnly = true;
            this.ztermL2Descripcion.Size = new System.Drawing.Size(315, 20);
            this.ztermL2Descripcion.TabIndex = 36;
            // 
            // cmbZtermL2
            // 
            this.cmbZtermL2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZtermL2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZtermL2.DataSource = this.ZtermL2;
            this.cmbZtermL2.DisplayMember = "ZTERM";
            this.cmbZtermL2.FormattingEnabled = true;
            this.cmbZtermL2.Location = new System.Drawing.Point(175, 46);
            this.cmbZtermL2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbZtermL2.Name = "cmbZtermL2";
            this.cmbZtermL2.Size = new System.Drawing.Size(84, 21);
            this.cmbZtermL2.TabIndex = 35;
            this.cmbZtermL2.ValueMember = "ZTERM";
            // 
            // ckL5
            // 
            this.ckL5.AutoSize = true;
            this.ckL5.Location = new System.Drawing.Point(266, 7);
            this.ckL5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckL5.Name = "ckL5";
            this.ckL5.Size = new System.Drawing.Size(38, 17);
            this.ckL5.TabIndex = 34;
            this.ckL5.Text = "L5";
            this.ckL5.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 7);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Condicion de Venta Autorizada";
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(221, 7);
            this.ckL2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 17);
            this.ckL2.TabIndex = 33;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Termino de Pago L1";
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(175, 7);
            this.ckL1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 17);
            this.ckL1.TabIndex = 32;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            // 
            // txtZtermL1Descripcion
            // 
            this.txtZtermL1Descripcion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtZtermL1Descripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ZTermL1, "ZTERMDESC", true));
            this.txtZtermL1Descripcion.Location = new System.Drawing.Point(262, 24);
            this.txtZtermL1Descripcion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtZtermL1Descripcion.Name = "txtZtermL1Descripcion";
            this.txtZtermL1Descripcion.ReadOnly = true;
            this.txtZtermL1Descripcion.Size = new System.Drawing.Size(315, 20);
            this.txtZtermL1Descripcion.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 92);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Descuento Acordado [%]";
            this.label15.UseWaitCursor = true;
            // 
            // txtDescuentoPorcentaje
            // 
            this.txtDescuentoPorcentaje.Location = new System.Drawing.Point(175, 89);
            this.txtDescuentoPorcentaje.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescuentoPorcentaje.Name = "txtDescuentoPorcentaje";
            this.txtDescuentoPorcentaje.Size = new System.Drawing.Size(51, 20);
            this.txtDescuentoPorcentaje.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Limite de Credito Asignado";
            this.label16.UseWaitCursor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 49);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Termino de Pago L2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 7);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 2;
            this.label19.UseMnemonic = false;
            // 
            // txtLimiteCreditoMaximo
            // 
            this.txtLimiteCreditoMaximo.Location = new System.Drawing.Point(175, 68);
            this.txtLimiteCreditoMaximo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLimiteCreditoMaximo.Name = "txtLimiteCreditoMaximo";
            this.txtLimiteCreditoMaximo.Size = new System.Drawing.Size(84, 20);
            this.txtLimiteCreditoMaximo.TabIndex = 7;
            // 
            // cmbZtermL1
            // 
            this.cmbZtermL1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZtermL1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZtermL1.DataSource = this.ZTermL1;
            this.cmbZtermL1.DisplayMember = "ZTERM";
            this.cmbZtermL1.FormattingEnabled = true;
            this.cmbZtermL1.Location = new System.Drawing.Point(175, 24);
            this.cmbZtermL1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbZtermL1.Name = "cmbZtermL1";
            this.cmbZtermL1.Size = new System.Drawing.Size(84, 21);
            this.cmbZtermL1.TabIndex = 18;
            this.cmbZtermL1.ValueMember = "ZTERM";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Navy;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(1, 189);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(583, 19);
            this.label20.TabIndex = 37;
            this.label20.Text = "CONDICIONES DE VENTA (LIMITE Y TERMINOS)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "ADMINISTRACION DE BLOQUEOS MANUALES";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(707, 45);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 41;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(707, 5);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 40);
            this.btnGrabar.TabIndex = 40;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // ZTermL1
            // 
            this.ZTermL1.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // ZtermL2
            // 
            this.ZtermL2.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // FrmGestionCreditosClientesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 351);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panLimiteCredito);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panBloqueo);
            this.Controls.Add(this.panIdentificacion);
            this.Name = "FrmGestionCreditosClientesMain";
            this.Text = "CONTROL DE LIMIETES Y DE RIESGOS DE CLIENTES";
            this.Load += new System.EventHandler(this.FrmGestionCreditosClientesMain_Load);
            this.panIdentificacion.ResumeLayout(false);
            this.panIdentificacion.PerformLayout();
            this.panBloqueo.ResumeLayout(false);
            this.panBloqueo.PerformLayout();
            this.panLimiteCredito.ResumeLayout(false);
            this.panLimiteCredito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZTermL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZtermL2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panIdentificacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoTax;
        private System.Windows.Forms.MaskedTextBox txtNumeroTax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.TextBox txtTaxValido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoTax;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.Panel panBloqueo;
        private System.Windows.Forms.CheckBox ckBloqueoPedido;
        private System.Windows.Forms.CheckBox ckBloqueoEntrega;
        private System.Windows.Forms.Panel panLimiteCredito;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtMotivoDescuento;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox ztermL2Descripcion;
        private System.Windows.Forms.ComboBox cmbZtermL2;
        private System.Windows.Forms.CheckBox ckL5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.TextBox txtZtermL1Descripcion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDescuentoPorcentaje;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtLimiteCreditoMaximo;
        private System.Windows.Forms.ComboBox cmbZtermL1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.BindingSource ZtermL2;
        private System.Windows.Forms.BindingSource ZTermL1;
    }
}