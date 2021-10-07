namespace MASngFE.MasterData.Material_Master
{
    partial class FrmMasterDataSearchScreen
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDetalleMaterial = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoMaterial = new System.Windows.Forms.TextBox();
            this.txtDescripcionTipoMaterial = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodigoPrimario = new System.Windows.Forms.TextBox();
            this.txtCodigoAka = new System.Windows.Forms.TextBox();
            this.txtTipoP = new System.Windows.Forms.TextBox();
            this.txtTipoA = new System.Windows.Forms.TextBox();
            this.lblAKA = new System.Windows.Forms.Label();
            this.lblPrimario = new System.Windows.Forms.Label();
            this.ckAKA = new System.Windows.Forms.CheckBox();
            this.ckPrimario = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTieneFormula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRequiereFormula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDispoComprar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDispoNP = new System.Windows.Forms.TextBox();
            this.txtDipoFab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetalleBom = new System.Windows.Forms.Button();
            this.btnEditMaterial = new System.Windows.Forms.Button();
            this.btnInfoRecordClientes = new System.Windows.Forms.Button();
            this.btnPlanProduccion = new System.Windows.Forms.Button();
            this.btnIrCQ = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(498, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDetalleMaterial
            // 
            this.btnDetalleMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleMaterial.Location = new System.Drawing.Point(498, 45);
            this.btnDetalleMaterial.Name = "btnDetalleMaterial";
            this.btnDetalleMaterial.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleMaterial.TabIndex = 6;
            this.btnDetalleMaterial.Text = "DETALLE\r\nMATERIAL";
            this.btnDetalleMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleMaterial.UseVisualStyleBackColor = true;
            this.btnDetalleMaterial.Click += new System.EventHandler(this.btnDetalleMaterial_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(11, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "MATERIAL";
            this.label7.UseWaitCursor = true;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(95, 4);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(146, 21);
            this.cmbMaterial.TabIndex = 16;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMaterial_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "TIPO";
            // 
            // txtTipoMaterial
            // 
            this.txtTipoMaterial.BackColor = System.Drawing.Color.LightGray;
            this.txtTipoMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoMaterial.ForeColor = System.Drawing.Color.Black;
            this.txtTipoMaterial.Location = new System.Drawing.Point(95, 27);
            this.txtTipoMaterial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTipoMaterial.Name = "txtTipoMaterial";
            this.txtTipoMaterial.ReadOnly = true;
            this.txtTipoMaterial.Size = new System.Drawing.Size(74, 20);
            this.txtTipoMaterial.TabIndex = 18;
            this.txtTipoMaterial.TabStop = false;
            // 
            // txtDescripcionTipoMaterial
            // 
            this.txtDescripcionTipoMaterial.BackColor = System.Drawing.Color.LightGray;
            this.txtDescripcionTipoMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDescripcionTipoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionTipoMaterial.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcionTipoMaterial.Location = new System.Drawing.Point(172, 27);
            this.txtDescripcionTipoMaterial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescripcionTipoMaterial.Name = "txtDescripcionTipoMaterial";
            this.txtDescripcionTipoMaterial.ReadOnly = true;
            this.txtDescripcionTipoMaterial.Size = new System.Drawing.Size(243, 20);
            this.txtDescripcionTipoMaterial.TabIndex = 20;
            this.txtDescripcionTipoMaterial.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDescripcionTipoMaterial);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTipoMaterial);
            this.panel1.Location = new System.Drawing.Point(4, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 53);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtCodigoPrimario);
            this.panel2.Controls.Add(this.txtCodigoAka);
            this.panel2.Controls.Add(this.txtTipoP);
            this.panel2.Controls.Add(this.txtTipoA);
            this.panel2.Controls.Add(this.lblAKA);
            this.panel2.Controls.Add(this.lblPrimario);
            this.panel2.Controls.Add(this.ckAKA);
            this.panel2.Controls.Add(this.ckPrimario);
            this.panel2.Location = new System.Drawing.Point(4, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 53);
            this.panel2.TabIndex = 22;
            // 
            // txtCodigoPrimario
            // 
            this.txtCodigoPrimario.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigoPrimario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoPrimario.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCodigoPrimario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPrimario.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoPrimario.Location = new System.Drawing.Point(126, 6);
            this.txtCodigoPrimario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCodigoPrimario.Name = "txtCodigoPrimario";
            this.txtCodigoPrimario.ReadOnly = true;
            this.txtCodigoPrimario.Size = new System.Drawing.Size(116, 20);
            this.txtCodigoPrimario.TabIndex = 24;
            this.txtCodigoPrimario.TabStop = false;
            // 
            // txtCodigoAka
            // 
            this.txtCodigoAka.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigoAka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoAka.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCodigoAka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoAka.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoAka.Location = new System.Drawing.Point(126, 27);
            this.txtCodigoAka.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCodigoAka.Name = "txtCodigoAka";
            this.txtCodigoAka.ReadOnly = true;
            this.txtCodigoAka.Size = new System.Drawing.Size(116, 20);
            this.txtCodigoAka.TabIndex = 25;
            this.txtCodigoAka.TabStop = false;
            // 
            // txtTipoP
            // 
            this.txtTipoP.BackColor = System.Drawing.Color.LightGray;
            this.txtTipoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoP.ForeColor = System.Drawing.Color.Black;
            this.txtTipoP.Location = new System.Drawing.Point(243, 6);
            this.txtTipoP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTipoP.Name = "txtTipoP";
            this.txtTipoP.ReadOnly = true;
            this.txtTipoP.Size = new System.Drawing.Size(77, 20);
            this.txtTipoP.TabIndex = 21;
            this.txtTipoP.TabStop = false;
            // 
            // txtTipoA
            // 
            this.txtTipoA.BackColor = System.Drawing.Color.LightGray;
            this.txtTipoA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoA.ForeColor = System.Drawing.Color.Black;
            this.txtTipoA.Location = new System.Drawing.Point(243, 27);
            this.txtTipoA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTipoA.Name = "txtTipoA";
            this.txtTipoA.ReadOnly = true;
            this.txtTipoA.Size = new System.Drawing.Size(77, 20);
            this.txtTipoA.TabIndex = 23;
            this.txtTipoA.TabStop = false;
            // 
            // lblAKA
            // 
            this.lblAKA.AutoSize = true;
            this.lblAKA.ForeColor = System.Drawing.Color.Navy;
            this.lblAKA.Location = new System.Drawing.Point(31, 29);
            this.lblAKA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAKA.Name = "lblAKA";
            this.lblAKA.Size = new System.Drawing.Size(88, 13);
            this.lblAKA.TabIndex = 22;
            this.lblAKA.Text = "CODIGO VENTA";
            this.lblAKA.UseWaitCursor = true;
            // 
            // lblPrimario
            // 
            this.lblPrimario.AutoSize = true;
            this.lblPrimario.ForeColor = System.Drawing.Color.Navy;
            this.lblPrimario.Location = new System.Drawing.Point(31, 8);
            this.lblPrimario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrimario.Name = "lblPrimario";
            this.lblPrimario.Size = new System.Drawing.Size(89, 13);
            this.lblPrimario.TabIndex = 21;
            this.lblPrimario.Text = "COD. PRIMARIO";
            this.lblPrimario.UseWaitCursor = true;
            // 
            // ckAKA
            // 
            this.ckAKA.AutoSize = true;
            this.ckAKA.Enabled = false;
            this.ckAKA.Location = new System.Drawing.Point(11, 29);
            this.ckAKA.Name = "ckAKA";
            this.ckAKA.Size = new System.Drawing.Size(15, 14);
            this.ckAKA.TabIndex = 1;
            this.ckAKA.UseVisualStyleBackColor = true;
            // 
            // ckPrimario
            // 
            this.ckPrimario.AutoSize = true;
            this.ckPrimario.Enabled = false;
            this.ckPrimario.Location = new System.Drawing.Point(11, 8);
            this.ckPrimario.Name = "ckPrimario";
            this.ckPrimario.Size = new System.Drawing.Size(15, 14);
            this.ckPrimario.TabIndex = 0;
            this.ckPrimario.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.txtTieneFormula);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtRequiereFormula);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtDispoComprar);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtDispoNP);
            this.panel3.Controls.Add(this.txtDipoFab);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(4, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 98);
            this.panel3.TabIndex = 24;
            // 
            // txtTieneFormula
            // 
            this.txtTieneFormula.BackColor = System.Drawing.Color.LightGray;
            this.txtTieneFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTieneFormula.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTieneFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieneFormula.ForeColor = System.Drawing.Color.Black;
            this.txtTieneFormula.Location = new System.Drawing.Point(285, 27);
            this.txtTieneFormula.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTieneFormula.Name = "txtTieneFormula";
            this.txtTieneFormula.ReadOnly = true;
            this.txtTieneFormula.Size = new System.Drawing.Size(35, 20);
            this.txtTieneFormula.TabIndex = 29;
            this.txtTieneFormula.TabStop = false;
            this.txtTieneFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(181, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "TIENE FORMULA?";
            this.label6.UseWaitCursor = true;
            // 
            // txtRequiereFormula
            // 
            this.txtRequiereFormula.BackColor = System.Drawing.Color.LightGray;
            this.txtRequiereFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequiereFormula.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRequiereFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequiereFormula.ForeColor = System.Drawing.Color.Black;
            this.txtRequiereFormula.Location = new System.Drawing.Point(134, 71);
            this.txtRequiereFormula.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRequiereFormula.Name = "txtRequiereFormula";
            this.txtRequiereFormula.ReadOnly = true;
            this.txtRequiereFormula.Size = new System.Drawing.Size(35, 20);
            this.txtRequiereFormula.TabIndex = 27;
            this.txtRequiereFormula.TabStop = false;
            this.txtRequiereFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "ITEM EN FORMULA";
            this.label5.UseWaitCursor = true;
            // 
            // txtDispoComprar
            // 
            this.txtDispoComprar.BackColor = System.Drawing.Color.LightGray;
            this.txtDispoComprar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDispoComprar.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDispoComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDispoComprar.ForeColor = System.Drawing.Color.Black;
            this.txtDispoComprar.Location = new System.Drawing.Point(134, 49);
            this.txtDispoComprar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDispoComprar.Name = "txtDispoComprar";
            this.txtDispoComprar.ReadOnly = true;
            this.txtDispoComprar.Size = new System.Drawing.Size(35, 20);
            this.txtDispoComprar.TabIndex = 25;
            this.txtDispoComprar.TabStop = false;
            this.txtDispoComprar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "SE PUEDE COMPRAR";
            this.label4.UseWaitCursor = true;
            // 
            // txtDispoNP
            // 
            this.txtDispoNP.BackColor = System.Drawing.Color.LightGray;
            this.txtDispoNP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDispoNP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDispoNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDispoNP.ForeColor = System.Drawing.Color.Black;
            this.txtDispoNP.Location = new System.Drawing.Point(134, 5);
            this.txtDispoNP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDispoNP.Name = "txtDispoNP";
            this.txtDispoNP.ReadOnly = true;
            this.txtDispoNP.Size = new System.Drawing.Size(35, 20);
            this.txtDispoNP.TabIndex = 21;
            this.txtDispoNP.TabStop = false;
            this.txtDispoNP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDipoFab
            // 
            this.txtDipoFab.BackColor = System.Drawing.Color.LightGray;
            this.txtDipoFab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDipoFab.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDipoFab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDipoFab.ForeColor = System.Drawing.Color.Black;
            this.txtDipoFab.Location = new System.Drawing.Point(134, 27);
            this.txtDipoFab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDipoFab.Name = "txtDipoFab";
            this.txtDipoFab.ReadOnly = true;
            this.txtDipoFab.Size = new System.Drawing.Size(35, 20);
            this.txtDipoFab.TabIndex = 23;
            this.txtDipoFab.TabStop = false;
            this.txtDipoFab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "SE PUEDE FABRICAR";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "SE PUEDE VENDER";
            this.label2.UseWaitCursor = true;
            // 
            // btnDetalleBom
            // 
            this.btnDetalleBom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleBom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleBom.Location = new System.Drawing.Point(498, 125);
            this.btnDetalleBom.Name = "btnDetalleBom";
            this.btnDetalleBom.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleBom.TabIndex = 25;
            this.btnDetalleBom.Text = "DETALLE\r\nBOM";
            this.btnDetalleBom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleBom.UseVisualStyleBackColor = true;
            this.btnDetalleBom.Click += new System.EventHandler(this.btnDetalleBom_Click);
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditMaterial.Location = new System.Drawing.Point(498, 85);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(100, 40);
            this.btnEditMaterial.TabIndex = 26;
            this.btnEditMaterial.Text = "EDITAR\r\nMATERIAL";
            this.btnEditMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditMaterial.UseVisualStyleBackColor = true;
            this.btnEditMaterial.Click += new System.EventHandler(this.btnEditMaterial_Click);
            // 
            // btnInfoRecordClientes
            // 
            this.btnInfoRecordClientes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoRecordClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoRecordClientes.Location = new System.Drawing.Point(498, 178);
            this.btnInfoRecordClientes.Name = "btnInfoRecordClientes";
            this.btnInfoRecordClientes.Size = new System.Drawing.Size(100, 40);
            this.btnInfoRecordClientes.TabIndex = 27;
            this.btnInfoRecordClientes.Text = "DETALLE\r\nCLIENTES";
            this.btnInfoRecordClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfoRecordClientes.UseVisualStyleBackColor = true;
            this.btnInfoRecordClientes.Click += new System.EventHandler(this.btnInfoRecordClientes_Click);
            // 
            // btnPlanProduccion
            // 
            this.btnPlanProduccion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanProduccion.Location = new System.Drawing.Point(498, 219);
            this.btnPlanProduccion.Name = "btnPlanProduccion";
            this.btnPlanProduccion.Size = new System.Drawing.Size(100, 40);
            this.btnPlanProduccion.TabIndex = 28;
            this.btnPlanProduccion.Text = "PLANEAR\r\nOF\r\n";
            this.btnPlanProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanProduccion.UseVisualStyleBackColor = true;
            this.btnPlanProduccion.Click += new System.EventHandler(this.btnPlanProduccion_Click);
            // 
            // btnIrCQ
            // 
            this.btnIrCQ.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrCQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIrCQ.Location = new System.Drawing.Point(498, 259);
            this.btnIrCQ.Name = "btnIrCQ";
            this.btnIrCQ.Size = new System.Drawing.Size(100, 40);
            this.btnIrCQ.TabIndex = 29;
            this.btnIrCQ.Text = "DATOS\r\nCQ";
            this.btnIrCQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIrCQ.UseVisualStyleBackColor = true;
            this.btnIrCQ.Click += new System.EventHandler(this.btnIrCQ_Click);
            // 
            // FrmMasterDataSearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 302);
            this.Controls.Add(this.btnIrCQ);
            this.Controls.Add(this.btnPlanProduccion);
            this.Controls.Add(this.btnInfoRecordClientes);
            this.Controls.Add(this.btnEditMaterial);
            this.Controls.Add(this.btnDetalleBom);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetalleMaterial);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmMasterDataSearchScreen";
            this.Text = "MATERIAL MASTER - Informacion de Materiales";
            this.Load += new System.EventHandler(this.FrmMasterDataSearchScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDetalleMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoMaterial;
        private System.Windows.Forms.TextBox txtDescripcionTipoMaterial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAKA;
        private System.Windows.Forms.Label lblPrimario;
        private System.Windows.Forms.CheckBox ckAKA;
        private System.Windows.Forms.CheckBox ckPrimario;
        private System.Windows.Forms.TextBox txtTipoP;
        private System.Windows.Forms.TextBox txtTipoA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTieneFormula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRequiereFormula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDispoComprar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDispoNP;
        private System.Windows.Forms.TextBox txtDipoFab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetalleBom;
        private System.Windows.Forms.TextBox txtCodigoPrimario;
        private System.Windows.Forms.TextBox txtCodigoAka;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnInfoRecordClientes;
        private System.Windows.Forms.Button btnPlanProduccion;
        private System.Windows.Forms.Button btnIrCQ;
    }
}