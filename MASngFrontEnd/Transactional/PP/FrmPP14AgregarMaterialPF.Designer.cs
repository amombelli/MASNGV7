namespace MASngFE.Transactional.PP
{
    partial class FrmPP14AgregarMaterialPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP14AgregarMaterialPF));
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCantidadKgIngresados = new System.Windows.Forms.TextBox();
            this.labelKGFAB = new System.Windows.Forms.Label();
            this.txtEstadoOF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialFabricado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbContainer = new System.Windows.Forms.RadioButton();
            this.rbFusion = new System.Windows.Forms.RadioButton();
            this.rbProporcion = new System.Windows.Forms.RadioButton();
            this.rbFijo = new System.Windows.Forms.RadioButton();
            this.txtContainerCantidad = new System.Windows.Forms.TextBox();
            this.txtDescripcionMaterialAdd = new System.Windows.Forms.TextBox();
            this.txtContainerDescription = new System.Windows.Forms.TextBox();
            this.txtAddedKg = new System.Windows.Forms.TextBox();
            this.txtAddedProp = new System.Windows.Forms.TextBox();
            this.cmbPrimarioAdd = new System.Windows.Forms.ComboBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbContainer = new System.Windows.Forms.ComboBox();
            this.t0010ContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregarItemAdicional = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(710, 88);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.txtCantidadKgIngresados);
            this.panel1.Controls.Add(this.labelKGFAB);
            this.panel1.Controls.Add(this.txtEstadoOF);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaterialFabricado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNumeroOF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Navy;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 82);
            this.panel1.TabIndex = 36;
            // 
            // txtCantidadKgIngresados
            // 
            this.txtCantidadKgIngresados.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCantidadKgIngresados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadKgIngresados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadKgIngresados.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtCantidadKgIngresados.Location = new System.Drawing.Point(537, 6);
            this.txtCantidadKgIngresados.Name = "txtCantidadKgIngresados";
            this.txtCantidadKgIngresados.ReadOnly = true;
            this.txtCantidadKgIngresados.Size = new System.Drawing.Size(87, 22);
            this.txtCantidadKgIngresados.TabIndex = 7;
            this.txtCantidadKgIngresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelKGFAB
            // 
            this.labelKGFAB.AutoSize = true;
            this.labelKGFAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKGFAB.Location = new System.Drawing.Point(402, 9);
            this.labelKGFAB.Name = "labelKGFAB";
            this.labelKGFAB.Size = new System.Drawing.Size(130, 16);
            this.labelKGFAB.TabIndex = 6;
            this.labelKGFAB.Text = "Kg Total Fabricados";
            // 
            // txtEstadoOF
            // 
            this.txtEstadoOF.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtEstadoOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoOF.Location = new System.Drawing.Point(154, 54);
            this.txtEstadoOF.Name = "txtEstadoOF";
            this.txtEstadoOF.ReadOnly = true;
            this.txtEstadoOF.Size = new System.Drawing.Size(158, 22);
            this.txtEstadoOF.TabIndex = 5;
            this.txtEstadoOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado OF";
            // 
            // txtMaterialFabricado
            // 
            this.txtMaterialFabricado.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtMaterialFabricado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialFabricado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialFabricado.Location = new System.Drawing.Point(154, 30);
            this.txtMaterialFabricado.Name = "txtMaterialFabricado";
            this.txtMaterialFabricado.ReadOnly = true;
            this.txtMaterialFabricado.Size = new System.Drawing.Size(158, 22);
            this.txtMaterialFabricado.TabIndex = 3;
            this.txtMaterialFabricado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Fabricado";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.Location = new System.Drawing.Point(154, 6);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.ReadOnly = true;
            this.txtNumeroOF.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroOF.TabIndex = 1;
            this.txtNumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden Fabricacion #";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.rbContainer);
            this.groupBox1.Controls.Add(this.rbFusion);
            this.groupBox1.Controls.Add(this.rbProporcion);
            this.groupBox1.Controls.Add(this.rbFijo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 120);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modo";
            // 
            // rbContainer
            // 
            this.rbContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rbContainer.Location = new System.Drawing.Point(7, 92);
            this.rbContainer.Name = "rbContainer";
            this.rbContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbContainer.Size = new System.Drawing.Size(234, 21);
            this.rbContainer.TabIndex = 3;
            this.rbContainer.TabStop = true;
            this.rbContainer.Text = "Contenedores / Bolsas / Insumos";
            this.rbContainer.UseVisualStyleBackColor = false;
            this.rbContainer.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // rbFusion
            // 
            this.rbFusion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rbFusion.Location = new System.Drawing.Point(7, 67);
            this.rbFusion.Name = "rbFusion";
            this.rbFusion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbFusion.Size = new System.Drawing.Size(234, 21);
            this.rbFusion.TabIndex = 2;
            this.rbFusion.TabStop = true;
            this.rbFusion.Text = "Fusion / Reproceso Material";
            this.rbFusion.UseVisualStyleBackColor = false;
            this.rbFusion.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // rbProporcion
            // 
            this.rbProporcion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rbProporcion.Location = new System.Drawing.Point(7, 42);
            this.rbProporcion.Name = "rbProporcion";
            this.rbProporcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbProporcion.Size = new System.Drawing.Size(234, 21);
            this.rbProporcion.TabIndex = 1;
            this.rbProporcion.TabStop = true;
            this.rbProporcion.Text = "Valor Porcentual [%] - Con Recalculo";
            this.rbProporcion.UseVisualStyleBackColor = false;
            this.rbProporcion.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // rbFijo
            // 
            this.rbFijo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rbFijo.Location = new System.Drawing.Point(7, 17);
            this.rbFijo.Name = "rbFijo";
            this.rbFijo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbFijo.Size = new System.Drawing.Size(234, 21);
            this.rbFijo.TabIndex = 0;
            this.rbFijo.TabStop = true;
            this.rbFijo.Text = "Valor Fijo - Sin Recalculo";
            this.rbFijo.UseVisualStyleBackColor = false;
            this.rbFijo.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // txtContainerCantidad
            // 
            this.txtContainerCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContainerCantidad.ForeColor = System.Drawing.Color.Crimson;
            this.txtContainerCantidad.Location = new System.Drawing.Point(187, 52);
            this.txtContainerCantidad.Name = "txtContainerCantidad";
            this.txtContainerCantidad.ReadOnly = true;
            this.txtContainerCantidad.Size = new System.Drawing.Size(60, 21);
            this.txtContainerCantidad.TabIndex = 30;
            this.txtContainerCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContainerCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            this.txtContainerCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtContainerCantidad_Validating);
            // 
            // txtDescripcionMaterialAdd
            // 
            this.txtDescripcionMaterialAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescripcionMaterialAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionMaterialAdd.Location = new System.Drawing.Point(264, 95);
            this.txtDescripcionMaterialAdd.Name = "txtDescripcionMaterialAdd";
            this.txtDescripcionMaterialAdd.ReadOnly = true;
            this.txtDescripcionMaterialAdd.Size = new System.Drawing.Size(363, 21);
            this.txtDescripcionMaterialAdd.TabIndex = 4;
            // 
            // txtContainerDescription
            // 
            this.txtContainerDescription.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContainerDescription.ForeColor = System.Drawing.Color.Crimson;
            this.txtContainerDescription.Location = new System.Drawing.Point(264, 95);
            this.txtContainerDescription.Name = "txtContainerDescription";
            this.txtContainerDescription.ReadOnly = true;
            this.txtContainerDescription.Size = new System.Drawing.Size(363, 21);
            this.txtContainerDescription.TabIndex = 29;
            this.txtContainerDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAddedKg
            // 
            this.txtAddedKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedKg.ForeColor = System.Drawing.Color.Black;
            this.txtAddedKg.Location = new System.Drawing.Point(187, 6);
            this.txtAddedKg.Name = "txtAddedKg";
            this.txtAddedKg.Size = new System.Drawing.Size(60, 21);
            this.txtAddedKg.TabIndex = 80;
            this.txtAddedKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddedKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            this.txtAddedKg.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddedKg_Validating);
            // 
            // txtAddedProp
            // 
            this.txtAddedProp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedProp.ForeColor = System.Drawing.Color.Black;
            this.txtAddedProp.Location = new System.Drawing.Point(187, 29);
            this.txtAddedProp.Name = "txtAddedProp";
            this.txtAddedProp.Size = new System.Drawing.Size(60, 21);
            this.txtAddedProp.TabIndex = 83;
            this.txtAddedProp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddedProp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            this.txtAddedProp.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddedProp_Validating);
            // 
            // cmbPrimarioAdd
            // 
            this.cmbPrimarioAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPrimarioAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPrimarioAdd.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbPrimarioAdd.DisplayMember = "IDMATERIAL";
            this.cmbPrimarioAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrimarioAdd.FormattingEnabled = true;
            this.cmbPrimarioAdd.Location = new System.Drawing.Point(82, 95);
            this.cmbPrimarioAdd.Name = "cmbPrimarioAdd";
            this.cmbPrimarioAdd.Size = new System.Drawing.Size(176, 21);
            this.cmbPrimarioAdd.TabIndex = 0;
            this.cmbPrimarioAdd.ValueMember = "IDMATERIAL";
            this.cmbPrimarioAdd.SelectedIndexChanged += new System.EventHandler(this.cmbPrimarioAdd_SelectedIndexChanged);
            this.cmbPrimarioAdd.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPrimarioAdd_Validating);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // cmbContainer
            // 
            this.cmbContainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbContainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbContainer.BackColor = System.Drawing.Color.White;
            this.cmbContainer.DataSource = this.t0010ContainerBindingSource;
            this.cmbContainer.DisplayMember = "ContainerId";
            this.cmbContainer.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContainer.FormattingEnabled = true;
            this.cmbContainer.Location = new System.Drawing.Point(82, 95);
            this.cmbContainer.Name = "cmbContainer";
            this.cmbContainer.Size = new System.Drawing.Size(176, 21);
            this.cmbContainer.TabIndex = 2;
            this.cmbContainer.ValueMember = "ContainerId";
            this.cmbContainer.SelectedIndexChanged += new System.EventHandler(this.cmbContainer_SelectedIndexChanged);
            this.cmbContainer.Validating += new System.ComponentModel.CancelEventHandler(this.cmbContainer_Validating);
            // 
            // t0010ContainerBindingSource
            // 
            this.t0010ContainerBindingSource.DataSource = typeof(TecserEF.Entity.T0010_Container);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "ITEM >>>>>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(161, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 85;
            this.label6.Text = "KG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(118, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 14);
            this.label7.TabIndex = 86;
            this.label7.Text = "% Formula";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 14);
            this.label8.TabIndex = 87;
            this.label8.Text = "Unidades";
            // 
            // btnAgregarItemAdicional
            // 
            this.btnAgregarItemAdicional.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItemAdicional.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarItemAdicional.Image")));
            this.btnAgregarItemAdicional.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarItemAdicional.Location = new System.Drawing.Point(710, 130);
            this.btnAgregarItemAdicional.Name = "btnAgregarItemAdicional";
            this.btnAgregarItemAdicional.Size = new System.Drawing.Size(100, 40);
            this.btnAgregarItemAdicional.TabIndex = 88;
            this.btnAgregarItemAdicional.Text = "Agregar\r\nITEM";
            this.btnAgregarItemAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarItemAdicional.UseVisualStyleBackColor = true;
            this.btnAgregarItemAdicional.Click += new System.EventHandler(this.btnAgregarItemAdicional_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtAddedKg);
            this.panel2.Controls.Add(this.txtAddedProp);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtContainerCantidad);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(264, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 78);
            this.panel2.TabIndex = 89;
            // 
            // FrmPP14AgregarMaterialPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 249);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAgregarItemAdicional);
            this.Controls.Add(this.txtContainerDescription);
            this.Controls.Add(this.txtDescripcionMaterialAdd);
            this.Controls.Add(this.cmbContainer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbPrimarioAdd);
            this.Name = "FrmPP14AgregarMaterialPF";
            this.Text = "PP14 Agregar Material a Orden Fabricacion";
            this.Load += new System.EventHandler(this.FrmPP14AgregarMaterialPF_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCantidadKgIngresados;
        private System.Windows.Forms.Label labelKGFAB;
        private System.Windows.Forms.TextBox txtEstadoOF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaterialFabricado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbContainer;
        private System.Windows.Forms.RadioButton rbFusion;
        private System.Windows.Forms.RadioButton rbProporcion;
        private System.Windows.Forms.RadioButton rbFijo;
        private System.Windows.Forms.TextBox txtContainerCantidad;
        private System.Windows.Forms.TextBox txtDescripcionMaterialAdd;
        private System.Windows.Forms.TextBox txtContainerDescription;
        private System.Windows.Forms.TextBox txtAddedKg;
        private System.Windows.Forms.TextBox txtAddedProp;
        private System.Windows.Forms.ComboBox cmbPrimarioAdd;
        private System.Windows.Forms.ComboBox cmbContainer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarItemAdicional;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.BindingSource t0010ContainerBindingSource;
    }
}