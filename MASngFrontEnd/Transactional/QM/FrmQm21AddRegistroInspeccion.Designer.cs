namespace MASngFE.Transactional.QM
{
    partial class FrmQm21AddRegistroInspeccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm21AddRegistroInspeccion));
            this.btnCrearIRecord = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPlanInspeccionDesc = new System.Windows.Forms.TextBox();
            this.cmbPlanInspeccion = new System.Windows.Forms.ComboBox();
            this.t0801QMMasterIPHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.txtMaterialDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtOrigenDesc = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtId63Pf = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFechaLote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSystemId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVendorDescripcion = new System.Windows.Forms.TextBox();
            this.utxtKg = new MASngFE._UserControls.DecimalTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtComentarioH1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0801QMMasterIPHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrearIRecord
            // 
            this.btnCrearIRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrearIRecord.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearIRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearIRecord.Image")));
            this.btnCrearIRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearIRecord.Location = new System.Drawing.Point(511, 50);
            this.btnCrearIRecord.Name = "btnCrearIRecord";
            this.btnCrearIRecord.Size = new System.Drawing.Size(102, 42);
            this.btnCrearIRecord.TabIndex = 67;
            this.btnCrearIRecord.Text = "Crear\r\nIRecord";
            this.btnCrearIRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearIRecord.UseVisualStyleBackColor = true;
            this.btnCrearIRecord.Click += new System.EventHandler(this.BtnCrearIRecord_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(511, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.TabIndex = 66;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.txtPlanInspeccionDesc);
            this.panel1.Controls.Add(this.cmbPlanInspeccion);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtMaterialDesc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.txtOrigenDesc);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 109);
            this.panel1.TabIndex = 68;
            // 
            // txtPlanInspeccionDesc
            // 
            this.txtPlanInspeccionDesc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanInspeccionDesc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtPlanInspeccionDesc.Location = new System.Drawing.Point(243, 77);
            this.txtPlanInspeccionDesc.Name = "txtPlanInspeccionDesc";
            this.txtPlanInspeccionDesc.ReadOnly = true;
            this.txtPlanInspeccionDesc.Size = new System.Drawing.Size(250, 22);
            this.txtPlanInspeccionDesc.TabIndex = 73;
            // 
            // cmbPlanInspeccion
            // 
            this.cmbPlanInspeccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPlanInspeccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPlanInspeccion.BackColor = System.Drawing.Color.Lavender;
            this.cmbPlanInspeccion.DataSource = this.t0801QMMasterIPHeaderBindingSource;
            this.cmbPlanInspeccion.DisplayMember = "IDPLAN";
            this.cmbPlanInspeccion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanInspeccion.FormattingEnabled = true;
            this.cmbPlanInspeccion.Location = new System.Drawing.Point(115, 77);
            this.cmbPlanInspeccion.Name = "cmbPlanInspeccion";
            this.cmbPlanInspeccion.Size = new System.Drawing.Size(127, 22);
            this.cmbPlanInspeccion.TabIndex = 72;
            this.cmbPlanInspeccion.ValueMember = "IDPLAN";
            this.cmbPlanInspeccion.SelectedIndexChanged += new System.EventHandler(this.CmbPlanInspeccion_SelectedIndexChanged);
            // 
            // t0801QMMasterIPHeaderBindingSource
            // 
            this.t0801QMMasterIPHeaderBindingSource.DataSource = typeof(TecserEF.Entity.T0801_QMMasterIPHeader);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 15);
            this.label14.TabIndex = 71;
            this.label14.Text = "PLAN Inspeccion";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.t0010MATERIALESBindingSource, "IDMATERIAL", true));
            this.cmbMaterial.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbMaterial.DisplayMember = "IDMATERIAL";
            this.cmbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(115, 7);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(200, 23);
            this.cmbMaterial.TabIndex = 70;
            this.cmbMaterial.ValueMember = "IDMATERIAL";
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 15);
            this.label18.TabIndex = 15;
            this.label18.Text = "Descripcion";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.Location = new System.Drawing.Point(115, 32);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.ReadOnly = true;
            this.txtMaterialDesc.Size = new System.Drawing.Size(378, 21);
            this.txtMaterialDesc.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Material";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Origen";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(115, 54);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(37, 21);
            this.txtOrigen.TabIndex = 10;
            // 
            // txtOrigenDesc
            // 
            this.txtOrigenDesc.Location = new System.Drawing.Point(153, 54);
            this.txtOrigenDesc.Name = "txtOrigenDesc";
            this.txtOrigenDesc.ReadOnly = true;
            this.txtOrigenDesc.Size = new System.Drawing.Size(89, 21);
            this.txtOrigenDesc.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBox9);
            this.panel2.Controls.Add(this.textBox10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(2, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 123);
            this.panel2.TabIndex = 69;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Source";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(356, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(137, 20);
            this.textBox2.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha FINISH";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(356, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(137, 20);
            this.textBox3.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Fecha START";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(63, 48);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(97, 20);
            this.textBox5.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lote #";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(312, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(181, 20);
            this.textBox6.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Plan Description";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(356, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(137, 20);
            this.textBox7.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fecha IN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Origen";
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(63, 26);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(143, 20);
            this.textBox9.TabIndex = 4;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(63, 3);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(53, 20);
            this.textBox10.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Material";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "IP#";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel3.Controls.Add(this.txtId63Pf);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtFechaLote);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtSystemId);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtVendorDescripcion);
            this.panel3.Controls.Add(this.utxtKg);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtLote);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Location = new System.Drawing.Point(2, 257);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 77);
            this.panel3.TabIndex = 70;
            // 
            // txtId63Pf
            // 
            this.txtId63Pf.Location = new System.Drawing.Point(441, 50);
            this.txtId63Pf.Name = "txtId63Pf";
            this.txtId63Pf.ReadOnly = true;
            this.txtId63Pf.Size = new System.Drawing.Size(52, 20);
            this.txtId63Pf.TabIndex = 75;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(380, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 76;
            this.label16.Text = "System ID";
            // 
            // txtFechaLote
            // 
            this.txtFechaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaLote.Location = new System.Drawing.Point(115, 28);
            this.txtFechaLote.Name = "txtFechaLote";
            this.txtFechaLote.Size = new System.Drawing.Size(115, 20);
            this.txtFechaLote.TabIndex = 74;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 73;
            this.label15.Text = "Fecha Lote";
            // 
            // txtSystemId
            // 
            this.txtSystemId.Location = new System.Drawing.Point(441, 28);
            this.txtSystemId.Name = "txtSystemId";
            this.txtSystemId.ReadOnly = true;
            this.txtSystemId.Size = new System.Drawing.Size(52, 20);
            this.txtSystemId.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "System ID";
            // 
            // txtVendorDescripcion
            // 
            this.txtVendorDescripcion.Location = new System.Drawing.Point(232, 6);
            this.txtVendorDescripcion.Name = "txtVendorDescripcion";
            this.txtVendorDescripcion.ReadOnly = true;
            this.txtVendorDescripcion.Size = new System.Drawing.Size(261, 20);
            this.txtVendorDescripcion.TabIndex = 71;
            // 
            // utxtKg
            // 
            this.utxtKg.Location = new System.Drawing.Point(115, 50);
            this.utxtKg.Name = "utxtKg";
            this.utxtKg.Size = new System.Drawing.Size(77, 20);
            this.utxtKg.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cantidad [Kg]";
            // 
            // txtLote
            // 
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(115, 6);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(115, 20);
            this.txtLote.TabIndex = 4;
            this.txtLote.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLote_Validating);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 13);
            this.label24.TabIndex = 3;
            this.label24.Text = "LOTE #";
            // 
            // txtComentarioH1
            // 
            this.txtComentarioH1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarioH1.Location = new System.Drawing.Point(117, 340);
            this.txtComentarioH1.Name = "txtComentarioH1";
            this.txtComentarioH1.Size = new System.Drawing.Size(382, 20);
            this.txtComentarioH1.TabIndex = 78;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 343);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 77;
            this.label17.Text = "Comentario [H1]";
            // 
            // FrmQm21AddRegistroInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 368);
            this.Controls.Add(this.txtComentarioH1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCrearIRecord);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmQm21AddRegistroInspeccion";
            this.Text = "QM21 - Agrega Registro Inspeccion Manual";
            this.Load += new System.EventHandler(this.FrmQm21AddRegistroInspeccion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0801QMMasterIPHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearIRecord;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMaterialDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.TextBox txtOrigenDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private _UserControls.DecimalTextBox utxtKg;
        private System.Windows.Forms.TextBox txtVendorDescripcion;
        private System.Windows.Forms.TextBox txtSystemId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPlanInspeccionDesc;
        private System.Windows.Forms.ComboBox cmbPlanInspeccion;
        private System.Windows.Forms.BindingSource t0801QMMasterIPHeaderBindingSource;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFechaLote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtId63Pf;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtComentarioH1;
        private System.Windows.Forms.Label label17;
    }
}