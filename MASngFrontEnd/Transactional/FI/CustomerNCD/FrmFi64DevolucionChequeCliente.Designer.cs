namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmFi64DevolucionChequeCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFi64DevolucionChequeCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvChequesCartera = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pDatosChequeSeleccionado = new System.Windows.Forms.Panel();
            this.txtChNumero = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdCheque = new System.Windows.Forms.TextBox();
            this.txtChBanco = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChLxRecibido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtChCliente = new System.Windows.Forms.TextBox();
            this.txtAClientesMotivo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ckTextoStandard = new System.Windows.Forms.CheckBox();
            this.cFechaChequeRecibido = new TSControls.CtlFechaTs();
            this.cFechaChequeAcreditacion = new TSControls.CtlFechaTs();
            this.cChImporte = new TSControls.CtlTextBox();
            this.btnConfirmarRetorno = new System.Windows.Forms.Button();
            this.btnAddGastos = new System.Windows.Forms.Button();
            this._idChequeCartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ChequeCarteraBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnDevolverCheque = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequesCartera)).BeginInit();
            this.panel5.SuspendLayout();
            this.pDatosChequeSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeCarteraBs)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Crimson;
            this.label16.Location = new System.Drawing.Point(795, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(3, 679);
            this.label16.TabIndex = 186;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 679);
            this.label17.TabIndex = 185;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(792, 3);
            this.label18.TabIndex = 184;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.dgvChequesCartera);
            this.panel1.Location = new System.Drawing.Point(9, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 365);
            this.panel1.TabIndex = 197;
            // 
            // dgvChequesCartera
            // 
            this.dgvChequesCartera.AllowUserToAddRows = false;
            this.dgvChequesCartera.AllowUserToDeleteRows = false;
            this.dgvChequesCartera.AutoGenerateColumns = false;
            this.dgvChequesCartera.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvChequesCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChequesCartera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._idChequeCartera,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewCheckBoxColumn4});
            this.dgvChequesCartera.DataSource = this.ChequeCarteraBs;
            this.dgvChequesCartera.GridColor = System.Drawing.Color.Black;
            this.dgvChequesCartera.Location = new System.Drawing.Point(6, 5);
            this.dgvChequesCartera.Name = "dgvChequesCartera";
            this.dgvChequesCartera.ReadOnly = true;
            this.dgvChequesCartera.RowHeadersWidth = 20;
            this.dgvChequesCartera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChequesCartera.Size = new System.Drawing.Size(644, 354);
            this.dgvChequesCartera.TabIndex = 187;
            this.dgvChequesCartera.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequesCartera_CellEnter);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtLx);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtTipoDocumento);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtId6);
            this.panel5.Controls.Add(this.txtMotivo);
            this.panel5.Location = new System.Drawing.Point(9, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(671, 56);
            this.panel5.TabIndex = 226;
            // 
            // txtLx
            // 
            this.txtLx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLx.Location = new System.Drawing.Point(342, 24);
            this.txtLx.Margin = new System.Windows.Forms.Padding(2);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(27, 21);
            this.txtLx.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(393, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipo Documento";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDocumento.Location = new System.Drawing.Point(495, 2);
            this.txtTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(170, 21);
            this.txtTipoDocumento.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(94, 2);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(246, 21);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Motivo Debito";
            // 
            // txtId6
            // 
            this.txtId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6.Location = new System.Drawing.Point(342, 2);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(46, 21);
            this.txtId6.TabIndex = 9;
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(94, 24);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(246, 21);
            this.txtMotivo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(9, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 18);
            this.label1.TabIndex = 228;
            this.label1.Text = "Datos del Cheque Seleccionado";
            // 
            // pDatosChequeSeleccionado
            // 
            this.pDatosChequeSeleccionado.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pDatosChequeSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDatosChequeSeleccionado.Controls.Add(this.txtChNumero);
            this.pDatosChequeSeleccionado.Controls.Add(this.label14);
            this.pDatosChequeSeleccionado.Controls.Add(this.cFechaChequeRecibido);
            this.pDatosChequeSeleccionado.Controls.Add(this.cFechaChequeAcreditacion);
            this.pDatosChequeSeleccionado.Controls.Add(this.label10);
            this.pDatosChequeSeleccionado.Controls.Add(this.txtIdCheque);
            this.pDatosChequeSeleccionado.Controls.Add(this.cChImporte);
            this.pDatosChequeSeleccionado.Controls.Add(this.txtChBanco);
            this.pDatosChequeSeleccionado.Controls.Add(this.label32);
            this.pDatosChequeSeleccionado.Controls.Add(this.label5);
            this.pDatosChequeSeleccionado.Controls.Add(this.label6);
            this.pDatosChequeSeleccionado.Controls.Add(this.txtChLxRecibido);
            this.pDatosChequeSeleccionado.Controls.Add(this.label8);
            this.pDatosChequeSeleccionado.Controls.Add(this.label13);
            this.pDatosChequeSeleccionado.Controls.Add(this.label26);
            this.pDatosChequeSeleccionado.Controls.Add(this.txtChCliente);
            this.pDatosChequeSeleccionado.Location = new System.Drawing.Point(9, 494);
            this.pDatosChequeSeleccionado.Name = "pDatosChequeSeleccionado";
            this.pDatosChequeSeleccionado.Size = new System.Drawing.Size(656, 103);
            this.pDatosChequeSeleccionado.TabIndex = 227;
            // 
            // txtChNumero
            // 
            this.txtChNumero.Location = new System.Drawing.Point(294, 5);
            this.txtChNumero.Name = "txtChNumero";
            this.txtChNumero.ReadOnly = true;
            this.txtChNumero.Size = new System.Drawing.Size(60, 21);
            this.txtChNumero.TabIndex = 222;
            this.txtChNumero.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 15);
            this.label14.TabIndex = 223;
            this.label14.Text = "Numero Cheque";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Fecha Cheque";
            // 
            // txtIdCheque
            // 
            this.txtIdCheque.Location = new System.Drawing.Point(574, 74);
            this.txtIdCheque.Name = "txtIdCheque";
            this.txtIdCheque.ReadOnly = true;
            this.txtIdCheque.Size = new System.Drawing.Size(60, 21);
            this.txtIdCheque.TabIndex = 8;
            this.txtIdCheque.TabStop = false;
            // 
            // txtChBanco
            // 
            this.txtChBanco.Location = new System.Drawing.Point(107, 28);
            this.txtChBanco.Name = "txtChBanco";
            this.txtChBanco.ReadOnly = true;
            this.txtChBanco.Size = new System.Drawing.Size(247, 21);
            this.txtChBanco.TabIndex = 10;
            this.txtChBanco.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(246, 77);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 15);
            this.label32.TabIndex = 219;
            this.label32.Text = "Lx Recibido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Importe Cheque";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ch ID";
            // 
            // txtChLxRecibido
            // 
            this.txtChLxRecibido.Location = new System.Drawing.Point(324, 74);
            this.txtChLxRecibido.Name = "txtChLxRecibido";
            this.txtChLxRecibido.ReadOnly = true;
            this.txtChLxRecibido.Size = new System.Drawing.Size(30, 21);
            this.txtChLxRecibido.TabIndex = 218;
            this.txtChLxRecibido.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Banco";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 213;
            this.label13.Text = "Cliente";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 15);
            this.label26.TabIndex = 216;
            this.label26.Text = "Fecha Recibido";
            // 
            // txtChCliente
            // 
            this.txtChCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtChCliente.Location = new System.Drawing.Point(107, 51);
            this.txtChCliente.Name = "txtChCliente";
            this.txtChCliente.ReadOnly = true;
            this.txtChCliente.Size = new System.Drawing.Size(247, 21);
            this.txtChCliente.TabIndex = 214;
            this.txtChCliente.TabStop = false;
            // 
            // txtAClientesMotivo
            // 
            this.txtAClientesMotivo.BackColor = System.Drawing.Color.Azure;
            this.txtAClientesMotivo.Location = new System.Drawing.Point(129, 607);
            this.txtAClientesMotivo.MaxLength = 100;
            this.txtAClientesMotivo.Name = "txtAClientesMotivo";
            this.txtAClientesMotivo.Size = new System.Drawing.Size(536, 21);
            this.txtAClientesMotivo.TabIndex = 229;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 610);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 15);
            this.label15.TabIndex = 230;
            this.label15.Text = "Motivo Devolucion";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(8, 600);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(657, 3);
            this.label7.TabIndex = 232;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Crimson;
            this.label9.Location = new System.Drawing.Point(5, 679);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(792, 3);
            this.label9.TabIndex = 233;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Indigo;
            this.label11.Location = new System.Drawing.Point(8, 631);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(657, 3);
            this.label11.TabIndex = 234;
            // 
            // ckTextoStandard
            // 
            this.ckTextoStandard.AutoSize = true;
            this.ckTextoStandard.Location = new System.Drawing.Point(16, 643);
            this.ckTextoStandard.Name = "ckTextoStandard";
            this.ckTextoStandard.Size = new System.Drawing.Size(109, 19);
            this.ckTextoStandard.TabIndex = 235;
            this.ckTextoStandard.Text = "Texto Standard";
            this.ckTextoStandard.UseVisualStyleBackColor = true;
            this.ckTextoStandard.CheckedChanged += new System.EventHandler(this.ckTextoStandard_CheckedChanged);
            // 
            // cFechaChequeRecibido
            // 
            this.cFechaChequeRecibido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cFechaChequeRecibido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cFechaChequeRecibido.CheckPeriodoFIAuto = false;
            this.cFechaChequeRecibido.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cFechaChequeRecibido.ColorForeFecha = System.Drawing.Color.Empty;
            this.cFechaChequeRecibido.Enabled = false;
            this.cFechaChequeRecibido.FechaMaxima = null;
            this.cFechaChequeRecibido.FechaMinima = null;
            this.cFechaChequeRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFechaChequeRecibido.Location = new System.Drawing.Point(107, 74);
            this.cFechaChequeRecibido.Margin = new System.Windows.Forms.Padding(0);
            this.cFechaChequeRecibido.Name = "cFechaChequeRecibido";
            this.cFechaChequeRecibido.ObtieneTCAuto = false;
            this.cFechaChequeRecibido.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cFechaChequeRecibido.Size = new System.Drawing.Size(97, 23);
            this.cFechaChequeRecibido.TabIndex = 221;
            this.cFechaChequeRecibido.ValidarRangoFecha = false;
            this.cFechaChequeRecibido.Value = null;
            // 
            // cFechaChequeAcreditacion
            // 
            this.cFechaChequeAcreditacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cFechaChequeAcreditacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cFechaChequeAcreditacion.CheckPeriodoFIAuto = false;
            this.cFechaChequeAcreditacion.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cFechaChequeAcreditacion.ColorForeFecha = System.Drawing.Color.Empty;
            this.cFechaChequeAcreditacion.Enabled = false;
            this.cFechaChequeAcreditacion.FechaMaxima = null;
            this.cFechaChequeAcreditacion.FechaMinima = null;
            this.cFechaChequeAcreditacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFechaChequeAcreditacion.Location = new System.Drawing.Point(107, 3);
            this.cFechaChequeAcreditacion.Margin = new System.Windows.Forms.Padding(0);
            this.cFechaChequeAcreditacion.Name = "cFechaChequeAcreditacion";
            this.cFechaChequeAcreditacion.ObtieneTCAuto = false;
            this.cFechaChequeAcreditacion.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cFechaChequeAcreditacion.Size = new System.Drawing.Size(97, 23);
            this.cFechaChequeAcreditacion.TabIndex = 220;
            this.cFechaChequeAcreditacion.ValidarRangoFecha = false;
            this.cFechaChequeAcreditacion.Value = null;
            // 
            // cChImporte
            // 
            this.cChImporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cChImporte.BackColor = System.Drawing.Color.LavenderBlush;
            this.cChImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cChImporte.Location = new System.Drawing.Point(542, 5);
            this.cChImporte.Margin = new System.Windows.Forms.Padding(0);
            this.cChImporte.Name = "cChImporte";
            this.cChImporte.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.cChImporte.SetDecimales = 2;
            this.cChImporte.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cChImporte.Size = new System.Drawing.Size(92, 21);
            this.cChImporte.TabIndex = 14;
            this.cChImporte.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.cChImporte.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.cChImporte.XReadOnly = true;
            // 
            // btnConfirmarRetorno
            // 
            this.btnConfirmarRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarRetorno.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarRetorno.Image")));
            this.btnConfirmarRetorno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarRetorno.Location = new System.Drawing.Point(671, 578);
            this.btnConfirmarRetorno.Name = "btnConfirmarRetorno";
            this.btnConfirmarRetorno.Size = new System.Drawing.Size(103, 42);
            this.btnConfirmarRetorno.TabIndex = 236;
            this.btnConfirmarRetorno.Text = "Confirmar\r\nRetorno";
            this.btnConfirmarRetorno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarRetorno.UseVisualStyleBackColor = true;
            this.btnConfirmarRetorno.Click += new System.EventHandler(this.btnConfirmarRetorno_Click);
            // 
            // btnAddGastos
            // 
            this.btnAddGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGastos.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGastos.Image")));
            this.btnAddGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGastos.Location = new System.Drawing.Point(671, 535);
            this.btnAddGastos.Name = "btnAddGastos";
            this.btnAddGastos.Size = new System.Drawing.Size(103, 42);
            this.btnAddGastos.TabIndex = 231;
            this.btnAddGastos.Text = "Agregar\r\nGASTOS";
            this.btnAddGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddGastos.UseVisualStyleBackColor = true;
            this.btnAddGastos.Click += new System.EventHandler(this.btnAddGastos_Click);
            // 
            // _idChequeCartera
            // 
            this._idChequeCartera.DataPropertyName = "Idcheque";
            this._idChequeCartera.HeaderText = "Idcheque";
            this._idChequeCartera.Name = "_idChequeCartera";
            this._idChequeCartera.ReadOnly = true;
            this._idChequeCartera.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Numero";
            this.dataGridViewTextBoxColumn3.HeaderText = "CHE #";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BancoShort";
            this.dataGridViewTextBoxColumn4.HeaderText = "Banco";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Importe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaAcreditacion";
            dataGridViewCellStyle5.Format = "d";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha CH";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FechaRecibido";
            dataGridViewCellStyle6.Format = "d";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn8.HeaderText = "Fecha IN";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Fecha Recibido";
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Disponible";
            this.dataGridViewCheckBoxColumn1.HeaderText = "D";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.ToolTipText = "Cheque Disponible";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Tipo";
            this.dataGridViewTextBoxColumn6.HeaderText = "LX";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 35;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "Rechazado";
            this.dataGridViewCheckBoxColumn3.HeaderText = "CHR";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.ToolTipText = "Cheque Rechazado";
            this.dataGridViewCheckBoxColumn3.Width = 35;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "IsEcheque";
            this.dataGridViewCheckBoxColumn4.HeaderText = "ECH";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ReadOnly = true;
            this.dataGridViewCheckBoxColumn4.ToolTipText = "E-Cheque";
            this.dataGridViewCheckBoxColumn4.Width = 35;
            // 
            // ChequeCarteraBs
            // 
            this.ChequeCarteraBs.DataSource = typeof(TecserEF.Entity.DataStructure.TsCheques1);
            // 
            // btnDevolverCheque
            // 
            this.btnDevolverCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolverCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolverCheque.Image")));
            this.btnDevolverCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevolverCheque.Location = new System.Drawing.Point(671, 493);
            this.btnDevolverCheque.Name = "btnDevolverCheque";
            this.btnDevolverCheque.Size = new System.Drawing.Size(103, 42);
            this.btnDevolverCheque.TabIndex = 196;
            this.btnDevolverCheque.Text = "Devolver\r\nCheque";
            this.btnDevolverCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevolverCheque.UseVisualStyleBackColor = true;
            this.btnDevolverCheque.Click += new System.EventHandler(this.btnDevolverCheque_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(686, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 42);
            this.btnClose.TabIndex = 187;
            this.btnClose.Text = "Cancelar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmFi64DevolucionChequeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 686);
            this.Controls.Add(this.btnConfirmarRetorno);
            this.Controls.Add(this.ckTextoStandard);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAddGastos);
            this.Controls.Add(this.txtAClientesMotivo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pDatosChequeSeleccionado);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDevolverCheque);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFi64DevolucionChequeCliente";
            this.Text = "FI64 - Devolucion de Cheque a Cliente";
            this.Load += new System.EventHandler(this.FrmFi64DevolucionChequeCliente_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequesCartera)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pDatosChequeSeleccionado.ResumeLayout(false);
            this.pDatosChequeSeleccionado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeCarteraBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDevolverCheque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.BindingSource ChequeCarteraBs;
        private System.Windows.Forms.DataGridView dgvChequesCartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn _idChequeCartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pDatosChequeSeleccionado;
        private System.Windows.Forms.TextBox txtChNumero;
        private System.Windows.Forms.Label label14;
        private TSControls.CtlFechaTs cFechaChequeRecibido;
        private TSControls.CtlFechaTs cFechaChequeAcreditacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdCheque;
        private TSControls.CtlTextBox cChImporte;
        private System.Windows.Forms.TextBox txtChBanco;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChLxRecibido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtChCliente;
        private System.Windows.Forms.TextBox txtAClientesMotivo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddGastos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ckTextoStandard;
        private System.Windows.Forms.Button btnConfirmarRetorno;
    }
}