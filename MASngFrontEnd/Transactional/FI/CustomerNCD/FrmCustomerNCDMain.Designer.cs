namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmCustomerNcdMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerNcdMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpTipoLx = new System.Windows.Forms.GroupBox();
            this.rbTipoL2 = new System.Windows.Forms.RadioButton();
            this.rbTipoL1 = new System.Windows.Forms.RadioButton();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTipoDocumento = new System.Windows.Forms.GroupBox();
            this.rbAI = new System.Windows.Forms.RadioButton();
            this.rbND = new System.Windows.Forms.RadioButton();
            this.rbNC = new System.Windows.Forms.RadioButton();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpMotivoNotaDebito = new System.Windows.Forms.GroupBox();
            this.rbndotro = new System.Windows.Forms.RadioButton();
            this.rbkgfactu = new System.Windows.Forms.RadioButton();
            this.rbdifprecio = new System.Windows.Forms.RadioButton();
            this.rbdifcambio = new System.Windows.Forms.RadioButton();
            this.rbchr = new System.Windows.Forms.RadioButton();
            this.grpMotivoNotaCredito = new System.Windows.Forms.GroupBox();
            this.rbncDtoGralVta = new System.Windows.Forms.RadioButton();
            this.rbncdifkg = new System.Windows.Forms.RadioButton();
            this.rbncdifprecio = new System.Windows.Forms.RadioButton();
            this.rbncdifcambio = new System.Windows.Forms.RadioButton();
            this.rbncanulafactu = new System.Windows.Forms.RadioButton();
            this.btnNewDocument = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpMotivoAjuste = new System.Windows.Forms.GroupBox();
            this.rbTraspaso = new System.Windows.Forms.RadioButton();
            this.rbAjusteIncobrablesConCobranza = new System.Windows.Forms.RadioButton();
            this.rbAjusteDeudasPerdidas = new System.Windows.Forms.RadioButton();
            this.rbAjusteRedondeo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.grpTipoLx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            this.grpTipoDocumento.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpMotivoNotaDebito.SuspendLayout();
            this.grpMotivoNotaCredito.SuspendLayout();
            this.grpMotivoAjuste.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.grpTipoLx);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.txtCuit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 86);
            this.panel1.TabIndex = 0;
            // 
            // grpTipoLx
            // 
            this.grpTipoLx.Controls.Add(this.rbTipoL2);
            this.grpTipoLx.Controls.Add(this.rbTipoL1);
            this.grpTipoLx.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpTipoLx.Location = new System.Drawing.Point(501, 8);
            this.grpTipoLx.Name = "grpTipoLx";
            this.grpTipoLx.Size = new System.Drawing.Size(98, 70);
            this.grpTipoLx.TabIndex = 16;
            this.grpTipoLx.TabStop = false;
            this.grpTipoLx.Text = "TIPO LX";
            // 
            // rbTipoL2
            // 
            this.rbTipoL2.AutoSize = true;
            this.rbTipoL2.Location = new System.Drawing.Point(16, 43);
            this.rbTipoL2.Name = "rbTipoL2";
            this.rbTipoL2.Size = new System.Drawing.Size(69, 19);
            this.rbTipoL2.TabIndex = 4;
            this.rbTipoL2.TabStop = true;
            this.rbTipoL2.Text = "TIPO L2";
            this.rbTipoL2.UseVisualStyleBackColor = true;
            this.rbTipoL2.CheckedChanged += new System.EventHandler(this.rbTipoL1_CheckedChanged);
            // 
            // rbTipoL1
            // 
            this.rbTipoL1.AutoSize = true;
            this.rbTipoL1.Location = new System.Drawing.Point(16, 20);
            this.rbTipoL1.Name = "rbTipoL1";
            this.rbTipoL1.Size = new System.Drawing.Size(69, 19);
            this.rbTipoL1.TabIndex = 3;
            this.rbTipoL1.TabStop = true;
            this.rbTipoL1.Text = "TIPO L1";
            this.rbTipoL1.UseVisualStyleBackColor = true;
            this.rbTipoL1.CheckedChanged += new System.EventHandler(this.rbTipoL1_CheckedChanged);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(105, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(307, 23);
            this.cmbFantasia.TabIndex = 1;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.Leave += new System.EventHandler(this.cmbRazonSocial_Leave);
            this.cmbFantasia.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFantasia_Validating);
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(105, 7);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(307, 23);
            this.cmbRazonSocial.TabIndex = 0;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.Leave += new System.EventHandler(this.cmbRazonSocial_Leave);
            this.cmbRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRazonSocial_Validating);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCliente.Location = new System.Drawing.Point(415, 7);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(57, 21);
            this.txtIdCliente.TabIndex = 7;
            this.txtIdCliente.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(231, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(28, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.TabStop = false;
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCuit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0006MCLIENTESBindingSource, "CUIT", true));
            this.txtCuit.Location = new System.Drawing.Point(105, 56);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(125, 21);
            this.txtCuit.TabIndex = 2;
            this.txtCuit.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "CUIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fantasia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social";
            // 
            // grpTipoDocumento
            // 
            this.grpTipoDocumento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpTipoDocumento.Controls.Add(this.rbAI);
            this.grpTipoDocumento.Controls.Add(this.rbND);
            this.grpTipoDocumento.Controls.Add(this.rbNC);
            this.grpTipoDocumento.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTipoDocumento.Location = new System.Drawing.Point(3, 105);
            this.grpTipoDocumento.Name = "grpTipoDocumento";
            this.grpTipoDocumento.Size = new System.Drawing.Size(159, 96);
            this.grpTipoDocumento.TabIndex = 5;
            this.grpTipoDocumento.TabStop = false;
            this.grpTipoDocumento.Text = "Tipo Documento";
            // 
            // rbAI
            // 
            this.rbAI.BackColor = System.Drawing.Color.SkyBlue;
            this.rbAI.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbAI.FlatAppearance.BorderSize = 3;
            this.rbAI.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAI.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAI.ForeColor = System.Drawing.Color.OliveDrab;
            this.rbAI.Location = new System.Drawing.Point(11, 63);
            this.rbAI.Name = "rbAI";
            this.rbAI.Size = new System.Drawing.Size(144, 18);
            this.rbAI.TabIndex = 2;
            this.rbAI.TabStop = true;
            this.rbAI.Text = "Ajustes Contables";
            this.rbAI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAI.UseVisualStyleBackColor = false;
            this.rbAI.CheckedChanged += new System.EventHandler(this.rbNC_CheckedChanged);
            // 
            // rbND
            // 
            this.rbND.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.rbND.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbND.FlatAppearance.BorderSize = 3;
            this.rbND.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbND.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbND.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbND.Location = new System.Drawing.Point(11, 43);
            this.rbND.Name = "rbND";
            this.rbND.Size = new System.Drawing.Size(144, 18);
            this.rbND.TabIndex = 1;
            this.rbND.TabStop = true;
            this.rbND.Text = "Nota Debito";
            this.rbND.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbND.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbND.UseVisualStyleBackColor = false;
            this.rbND.CheckedChanged += new System.EventHandler(this.rbNC_CheckedChanged);
            // 
            // rbNC
            // 
            this.rbNC.BackColor = System.Drawing.Color.Orange;
            this.rbNC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbNC.FlatAppearance.BorderSize = 3;
            this.rbNC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rbNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNC.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbNC.Location = new System.Drawing.Point(11, 23);
            this.rbNC.Name = "rbNC";
            this.rbNC.Size = new System.Drawing.Size(144, 18);
            this.rbNC.TabIndex = 0;
            this.rbNC.TabStop = true;
            this.rbNC.Text = "Nota Credito";
            this.rbNC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbNC.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbNC.UseVisualStyleBackColor = false;
            this.rbNC.CheckedChanged += new System.EventHandler(this.rbNC_CheckedChanged);
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Location = new System.Drawing.Point(97, 6);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoL1.TabIndex = 9;
            this.txtSaldoL1.TabStop = false;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Location = new System.Drawing.Point(97, 29);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoL2.TabIndex = 11;
            this.txtSaldoL2.TabStop = false;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saldo L2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(615, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 86);
            this.panel2.TabIndex = 12;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(97, 52);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(100, 21);
            this.txtSaldoTotal.TabIndex = 13;
            this.txtSaldoTotal.TabStop = false;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Deduda Total";
            // 
            // grpMotivoNotaDebito
            // 
            this.grpMotivoNotaDebito.Controls.Add(this.rbndotro);
            this.grpMotivoNotaDebito.Controls.Add(this.rbkgfactu);
            this.grpMotivoNotaDebito.Controls.Add(this.rbdifprecio);
            this.grpMotivoNotaDebito.Controls.Add(this.rbdifcambio);
            this.grpMotivoNotaDebito.Controls.Add(this.rbchr);
            this.grpMotivoNotaDebito.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpMotivoNotaDebito.Location = new System.Drawing.Point(239, 105);
            this.grpMotivoNotaDebito.Name = "grpMotivoNotaDebito";
            this.grpMotivoNotaDebito.Size = new System.Drawing.Size(276, 168);
            this.grpMotivoNotaDebito.TabIndex = 6;
            this.grpMotivoNotaDebito.TabStop = false;
            this.grpMotivoNotaDebito.Text = "MOTIVO NOTA DEBITO";
            // 
            // rbndotro
            // 
            this.rbndotro.AutoSize = true;
            this.rbndotro.ForeColor = System.Drawing.Color.Gray;
            this.rbndotro.Location = new System.Drawing.Point(16, 136);
            this.rbndotro.Name = "rbndotro";
            this.rbndotro.Size = new System.Drawing.Size(59, 19);
            this.rbndotro.TabIndex = 14;
            this.rbndotro.TabStop = true;
            this.rbndotro.Text = "OTRO";
            this.rbndotro.UseVisualStyleBackColor = true;
            this.rbndotro.CheckedChanged += new System.EventHandler(this.rbchr_CheckedChanged);
            // 
            // rbkgfactu
            // 
            this.rbkgfactu.AutoSize = true;
            this.rbkgfactu.ForeColor = System.Drawing.Color.Gray;
            this.rbkgfactu.Location = new System.Drawing.Point(16, 108);
            this.rbkgfactu.Name = "rbkgfactu";
            this.rbkgfactu.Size = new System.Drawing.Size(219, 19);
            this.rbkgfactu.TabIndex = 3;
            this.rbkgfactu.TabStop = true;
            this.rbkgfactu.Text = "DIFERENCIA DE KG FACTURADOS";
            this.rbkgfactu.UseVisualStyleBackColor = true;
            this.rbkgfactu.CheckedChanged += new System.EventHandler(this.rbchr_CheckedChanged);
            // 
            // rbdifprecio
            // 
            this.rbdifprecio.AutoSize = true;
            this.rbdifprecio.ForeColor = System.Drawing.Color.Gray;
            this.rbdifprecio.Location = new System.Drawing.Point(16, 80);
            this.rbdifprecio.Name = "rbdifprecio";
            this.rbdifprecio.Size = new System.Drawing.Size(250, 19);
            this.rbdifprecio.TabIndex = 2;
            this.rbdifprecio.TabStop = true;
            this.rbdifprecio.Text = "DIFERENCIA DE PRECIO FACTURACION";
            this.rbdifprecio.UseVisualStyleBackColor = true;
            this.rbdifprecio.CheckedChanged += new System.EventHandler(this.rbchr_CheckedChanged);
            // 
            // rbdifcambio
            // 
            this.rbdifcambio.AutoSize = true;
            this.rbdifcambio.Location = new System.Drawing.Point(16, 52);
            this.rbdifcambio.Name = "rbdifcambio";
            this.rbdifcambio.Size = new System.Drawing.Size(144, 19);
            this.rbdifcambio.TabIndex = 1;
            this.rbdifcambio.TabStop = true;
            this.rbdifcambio.Text = "Diferencia de Cambio";
            this.rbdifcambio.UseVisualStyleBackColor = true;
            this.rbdifcambio.CheckedChanged += new System.EventHandler(this.rbchr_CheckedChanged);
            // 
            // rbchr
            // 
            this.rbchr.AutoSize = true;
            this.rbchr.Location = new System.Drawing.Point(16, 24);
            this.rbchr.Name = "rbchr";
            this.rbchr.Size = new System.Drawing.Size(134, 19);
            this.rbchr.TabIndex = 0;
            this.rbchr.TabStop = true;
            this.rbchr.Text = "Cheque Rechazado";
            this.rbchr.UseVisualStyleBackColor = true;
            this.rbchr.CheckedChanged += new System.EventHandler(this.rbchr_CheckedChanged);
            // 
            // grpMotivoNotaCredito
            // 
            this.grpMotivoNotaCredito.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grpMotivoNotaCredito.Controls.Add(this.rbncDtoGralVta);
            this.grpMotivoNotaCredito.Controls.Add(this.rbncdifkg);
            this.grpMotivoNotaCredito.Controls.Add(this.rbncdifprecio);
            this.grpMotivoNotaCredito.Controls.Add(this.rbncdifcambio);
            this.grpMotivoNotaCredito.Controls.Add(this.rbncanulafactu);
            this.grpMotivoNotaCredito.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.grpMotivoNotaCredito.Location = new System.Drawing.Point(168, 105);
            this.grpMotivoNotaCredito.Name = "grpMotivoNotaCredito";
            this.grpMotivoNotaCredito.Size = new System.Drawing.Size(354, 168);
            this.grpMotivoNotaCredito.TabIndex = 7;
            this.grpMotivoNotaCredito.TabStop = false;
            this.grpMotivoNotaCredito.Text = "MOTIVO NOTA DE CREDITO";
            // 
            // rbncDtoGralVta
            // 
            this.rbncDtoGralVta.AutoSize = true;
            this.rbncDtoGralVta.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rbncDtoGralVta.Location = new System.Drawing.Point(16, 136);
            this.rbncDtoGralVta.Name = "rbncDtoGralVta";
            this.rbncDtoGralVta.Size = new System.Drawing.Size(188, 19);
            this.rbncDtoGralVta.TabIndex = 15;
            this.rbncDtoGralVta.TabStop = true;
            this.rbncDtoGralVta.Text = "Descuento General en Ventas";
            this.rbncDtoGralVta.UseVisualStyleBackColor = true;
            this.rbncDtoGralVta.CheckedChanged += new System.EventHandler(this.rbncotro_CheckedChanged);
            // 
            // rbncdifkg
            // 
            this.rbncdifkg.AutoSize = true;
            this.rbncdifkg.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rbncdifkg.Location = new System.Drawing.Point(16, 108);
            this.rbncdifkg.Name = "rbncdifkg";
            this.rbncdifkg.Size = new System.Drawing.Size(316, 19);
            this.rbncdifkg.TabIndex = 3;
            this.rbncdifkg.TabStop = true;
            this.rbncdifkg.Text = "Diferencia de Kg Facturados / Devolucion Mercaderia";
            this.rbncdifkg.UseVisualStyleBackColor = true;
            this.rbncdifkg.CheckedChanged += new System.EventHandler(this.rbncotro_CheckedChanged);
            // 
            // rbncdifprecio
            // 
            this.rbncdifprecio.AutoSize = true;
            this.rbncdifprecio.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rbncdifprecio.Location = new System.Drawing.Point(16, 80);
            this.rbncdifprecio.Name = "rbncdifprecio";
            this.rbncdifprecio.Size = new System.Drawing.Size(136, 19);
            this.rbncdifprecio.TabIndex = 2;
            this.rbncdifprecio.TabStop = true;
            this.rbncdifprecio.Text = "Diferencia de Precio";
            this.rbncdifprecio.UseVisualStyleBackColor = true;
            this.rbncdifprecio.CheckedChanged += new System.EventHandler(this.rbncotro_CheckedChanged);
            // 
            // rbncdifcambio
            // 
            this.rbncdifcambio.AutoSize = true;
            this.rbncdifcambio.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rbncdifcambio.Location = new System.Drawing.Point(16, 52);
            this.rbncdifcambio.Name = "rbncdifcambio";
            this.rbncdifcambio.Size = new System.Drawing.Size(144, 19);
            this.rbncdifcambio.TabIndex = 1;
            this.rbncdifcambio.TabStop = true;
            this.rbncdifcambio.Text = "Diferencia de Cambio";
            this.rbncdifcambio.UseVisualStyleBackColor = true;
            this.rbncdifcambio.CheckedChanged += new System.EventHandler(this.rbncotro_CheckedChanged);
            // 
            // rbncanulafactu
            // 
            this.rbncanulafactu.AutoSize = true;
            this.rbncanulafactu.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rbncanulafactu.Location = new System.Drawing.Point(16, 24);
            this.rbncanulafactu.Name = "rbncanulafactu";
            this.rbncanulafactu.Size = new System.Drawing.Size(227, 19);
            this.rbncanulafactu.TabIndex = 0;
            this.rbncanulafactu.TabStop = true;
            this.rbncanulafactu.Text = "Anulacion de Documento (Completo)";
            this.rbncanulafactu.UseVisualStyleBackColor = true;
            this.rbncanulafactu.CheckedChanged += new System.EventHandler(this.rbncotro_CheckedChanged);
            // 
            // btnNewDocument
            // 
            this.btnNewDocument.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDocument.Image")));
            this.btnNewDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDocument.Location = new System.Drawing.Point(830, 46);
            this.btnNewDocument.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewDocument.Name = "btnNewDocument";
            this.btnNewDocument.Size = new System.Drawing.Size(107, 42);
            this.btnNewDocument.TabIndex = 65;
            this.btnNewDocument.Text = "Crear\r\nNC-ND";
            this.btnNewDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDocument.UseVisualStyleBackColor = true;
            this.btnNewDocument.Click += new System.EventHandler(this.btnNewDocument_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(830, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpMotivoAjuste
            // 
            this.grpMotivoAjuste.BackColor = System.Drawing.SystemColors.HighlightText;
            this.grpMotivoAjuste.Controls.Add(this.rbTraspaso);
            this.grpMotivoAjuste.Controls.Add(this.rbAjusteIncobrablesConCobranza);
            this.grpMotivoAjuste.Controls.Add(this.rbAjusteDeudasPerdidas);
            this.grpMotivoAjuste.Controls.Add(this.rbAjusteRedondeo);
            this.grpMotivoAjuste.ForeColor = System.Drawing.Color.LightCoral;
            this.grpMotivoAjuste.Location = new System.Drawing.Point(528, 105);
            this.grpMotivoAjuste.Name = "grpMotivoAjuste";
            this.grpMotivoAjuste.Size = new System.Drawing.Size(354, 168);
            this.grpMotivoAjuste.TabIndex = 16;
            this.grpMotivoAjuste.TabStop = false;
            this.grpMotivoAjuste.Text = "MOTIVO AJUSTE CUENTA";
            // 
            // rbTraspaso
            // 
            this.rbTraspaso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbTraspaso.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbTraspaso.Location = new System.Drawing.Point(16, 101);
            this.rbTraspaso.Name = "rbTraspaso";
            this.rbTraspaso.Size = new System.Drawing.Size(289, 19);
            this.rbTraspaso.TabIndex = 4;
            this.rbTraspaso.TabStop = true;
            this.rbTraspaso.Text = "Traspaso de Saldos  E/C - E/T";
            this.rbTraspaso.UseVisualStyleBackColor = false;
            this.rbTraspaso.CheckedChanged += new System.EventHandler(this.rbAjusteMas_CheckedChanged);
            // 
            // rbAjusteIncobrablesConCobranza
            // 
            this.rbAjusteIncobrablesConCobranza.BackColor = System.Drawing.Color.PowderBlue;
            this.rbAjusteIncobrablesConCobranza.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbAjusteIncobrablesConCobranza.Location = new System.Drawing.Point(16, 76);
            this.rbAjusteIncobrablesConCobranza.Name = "rbAjusteIncobrablesConCobranza";
            this.rbAjusteIncobrablesConCobranza.Size = new System.Drawing.Size(289, 19);
            this.rbAjusteIncobrablesConCobranza.TabIndex = 3;
            this.rbAjusteIncobrablesConCobranza.TabStop = true;
            this.rbAjusteIncobrablesConCobranza.Text = "Incobrables - Cobranza";
            this.rbAjusteIncobrablesConCobranza.UseVisualStyleBackColor = false;
            this.rbAjusteIncobrablesConCobranza.CheckedChanged += new System.EventHandler(this.rbAjusteMas_CheckedChanged);
            // 
            // rbAjusteDeudasPerdidas
            // 
            this.rbAjusteDeudasPerdidas.BackColor = System.Drawing.Color.AntiqueWhite;
            this.rbAjusteDeudasPerdidas.ForeColor = System.Drawing.Color.DeepPink;
            this.rbAjusteDeudasPerdidas.Location = new System.Drawing.Point(16, 50);
            this.rbAjusteDeudasPerdidas.Name = "rbAjusteDeudasPerdidas";
            this.rbAjusteDeudasPerdidas.Size = new System.Drawing.Size(289, 19);
            this.rbAjusteDeudasPerdidas.TabIndex = 2;
            this.rbAjusteDeudasPerdidas.TabStop = true;
            this.rbAjusteDeudasPerdidas.Text = "Deudas NO Reclamables (Perdidas x Gestion)";
            this.rbAjusteDeudasPerdidas.UseVisualStyleBackColor = false;
            this.rbAjusteDeudasPerdidas.CheckedChanged += new System.EventHandler(this.rbAjusteMas_CheckedChanged);
            // 
            // rbAjusteRedondeo
            // 
            this.rbAjusteRedondeo.BackColor = System.Drawing.Color.MintCream;
            this.rbAjusteRedondeo.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.rbAjusteRedondeo.Location = new System.Drawing.Point(16, 24);
            this.rbAjusteRedondeo.Name = "rbAjusteRedondeo";
            this.rbAjusteRedondeo.Size = new System.Drawing.Size(289, 19);
            this.rbAjusteRedondeo.TabIndex = 0;
            this.rbAjusteRedondeo.TabStop = true;
            this.rbAjusteRedondeo.Text = "Ajuste Por Redondeo";
            this.rbAjusteRedondeo.UseVisualStyleBackColor = false;
            this.rbAjusteRedondeo.CheckedChanged += new System.EventHandler(this.rbAjusteMas_CheckedChanged);
            // 
            // FrmCustomerNcdMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 284);
            this.Controls.Add(this.grpMotivoAjuste);
            this.Controls.Add(this.btnNewDocument);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpMotivoNotaCredito);
            this.Controls.Add(this.grpMotivoNotaDebito);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grpTipoDocumento);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCustomerNcdMain";
            this.Text = "FrmCustomerNCDMain";
            this.Load += new System.EventHandler(this.FrmCustomerNCDMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpTipoLx.ResumeLayout(false);
            this.grpTipoLx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            this.grpTipoDocumento.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpMotivoNotaDebito.ResumeLayout(false);
            this.grpMotivoNotaDebito.PerformLayout();
            this.grpMotivoNotaCredito.ResumeLayout(false);
            this.grpMotivoNotaCredito.PerformLayout();
            this.grpMotivoAjuste.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTipoDocumento;
        private System.Windows.Forms.RadioButton rbAI;
        private System.Windows.Forms.RadioButton rbND;
        private System.Windows.Forms.RadioButton rbNC;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpMotivoNotaDebito;
        private System.Windows.Forms.RadioButton rbndotro;
        private System.Windows.Forms.RadioButton rbkgfactu;
        private System.Windows.Forms.RadioButton rbdifprecio;
        private System.Windows.Forms.RadioButton rbdifcambio;
        private System.Windows.Forms.RadioButton rbchr;
        private System.Windows.Forms.GroupBox grpMotivoNotaCredito;
        private System.Windows.Forms.RadioButton rbncDtoGralVta;
        private System.Windows.Forms.RadioButton rbncdifkg;
        private System.Windows.Forms.RadioButton rbncdifprecio;
        private System.Windows.Forms.RadioButton rbncdifcambio;
        private System.Windows.Forms.RadioButton rbncanulafactu;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.GroupBox grpTipoLx;
        private System.Windows.Forms.RadioButton rbTipoL2;
        private System.Windows.Forms.RadioButton rbTipoL1;
        private System.Windows.Forms.Button btnNewDocument;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpMotivoAjuste;
        private System.Windows.Forms.RadioButton rbAjusteIncobrablesConCobranza;
        private System.Windows.Forms.RadioButton rbAjusteDeudasPerdidas;
        private System.Windows.Forms.RadioButton rbAjusteRedondeo;
        private System.Windows.Forms.RadioButton rbTraspaso;
    }
}