namespace MASngFE.SuperMD
{
    partial class FrmMaterialTypeManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMaterialType = new System.Windows.Forms.ComboBox();
            this.MaterialTypeBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevoTipo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.ckStockManagement = new System.Windows.Forms.CheckBox();
            this.ckDisponibleNotaPedido = new System.Windows.Forms.CheckBox();
            this.ckDisponibleRemito = new System.Windows.Forms.CheckBox();
            this.ckDisponibleFactura = new System.Windows.Forms.CheckBox();
            this.ckDisponibleRemitoL2 = new System.Windows.Forms.CheckBox();
            this.ckColor = new System.Windows.Forms.CheckBox();
            this.ckBase = new System.Windows.Forms.CheckBox();
            this.ckBatchManagementDefault = new System.Windows.Forms.CheckBox();
            this.ckPermiteAKA = new System.Windows.Forms.CheckBox();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.txtMaterialTypeDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGLVenta = new System.Windows.Forms.TextBox();
            this.t0135GLVBs = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtGLInventario = new System.Windows.Forms.TextBox();
            this.t0135GLIBs = new System.Windows.Forms.BindingSource(this.components);
            this.ckDisponibleBOM = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDefaultUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMRPGeneraDocumento = new System.Windows.Forms.TextBox();
            this.ckDisponibleOF = new System.Windows.Forms.CheckBox();
            this.ckDisponibleOC = new System.Windows.Forms.CheckBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSlocDefault = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtControlCostoMultiplicador = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtControlCostoAdded = new System.Windows.Forms.TextBox();
            this.panPropiedades = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panComportamiento = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbGLI = new System.Windows.Forms.ComboBox();
            this.cmbGLV = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialTypeBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLVBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLIBs)).BeginInit();
            this.panPropiedades.SuspendLayout();
            this.panComportamiento.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbMaterialType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 47);
            this.panel1.TabIndex = 1;
            // 
            // cmbMaterialType
            // 
            this.cmbMaterialType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterialType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterialType.DataSource = this.MaterialTypeBs;
            this.cmbMaterialType.DisplayMember = "TIPO_MATERIAL";
            this.cmbMaterialType.FormattingEnabled = true;
            this.cmbMaterialType.Location = new System.Drawing.Point(96, 4);
            this.cmbMaterialType.Name = "cmbMaterialType";
            this.cmbMaterialType.Size = new System.Drawing.Size(121, 22);
            this.cmbMaterialType.TabIndex = 0;
            this.cmbMaterialType.ValueMember = "TIPO_MATERIAL";
            this.cmbMaterialType.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialType_SelectedIndexChanged);
            // 
            // MaterialTypeBs
            // 
            this.MaterialTypeBs.DataSource = typeof(TecserEF.Entity.T0011_MaterialType);
            // 
            // btnNuevoTipo
            // 
            this.btnNuevoTipo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoTipo.Location = new System.Drawing.Point(888, 96);
            this.btnNuevoTipo.Name = "btnNuevoTipo";
            this.btnNuevoTipo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevoTipo.TabIndex = 83;
            this.btnNuevoTipo.Text = "Add\r\nNew";
            this.btnNuevoTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoTipo.UseVisualStyleBackColor = true;
            this.btnNuevoTipo.Click += new System.EventHandler(this.btnNuevoTipo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(888, 181);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(888, 139);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 40);
            this.btnGrabar.TabIndex = 29;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // ckStockManagement
            // 
            this.ckStockManagement.AutoSize = true;
            this.ckStockManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckStockManagement.Location = new System.Drawing.Point(454, 13);
            this.ckStockManagement.Name = "ckStockManagement";
            this.ckStockManagement.Size = new System.Drawing.Size(157, 17);
            this.ckStockManagement.TabIndex = 84;
            this.ckStockManagement.Text = "Control de Stock/Inventario";
            this.ckStockManagement.UseVisualStyleBackColor = true;
            // 
            // ckDisponibleNotaPedido
            // 
            this.ckDisponibleNotaPedido.AutoSize = true;
            this.ckDisponibleNotaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleNotaPedido.Location = new System.Drawing.Point(12, 7);
            this.ckDisponibleNotaPedido.Name = "ckDisponibleNotaPedido";
            this.ckDisponibleNotaPedido.Size = new System.Drawing.Size(137, 17);
            this.ckDisponibleNotaPedido.TabIndex = 85;
            this.ckDisponibleNotaPedido.Text = "Disponible Nota Pedido";
            this.ckDisponibleNotaPedido.UseVisualStyleBackColor = true;
            // 
            // ckDisponibleRemito
            // 
            this.ckDisponibleRemito.AutoSize = true;
            this.ckDisponibleRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleRemito.Location = new System.Drawing.Point(12, 30);
            this.ckDisponibleRemito.Name = "ckDisponibleRemito";
            this.ckDisponibleRemito.Size = new System.Drawing.Size(266, 17);
            this.ckDisponibleRemito.TabIndex = 86;
            this.ckDisponibleRemito.Text = "Disponible en Remitos (Para Agregado de Material)";
            this.ckDisponibleRemito.UseVisualStyleBackColor = true;
            // 
            // ckDisponibleFactura
            // 
            this.ckDisponibleFactura.AutoSize = true;
            this.ckDisponibleFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleFactura.Location = new System.Drawing.Point(12, 76);
            this.ckDisponibleFactura.Name = "ckDisponibleFactura";
            this.ckDisponibleFactura.Size = new System.Drawing.Size(264, 17);
            this.ckDisponibleFactura.TabIndex = 87;
            this.ckDisponibleFactura.Text = "Disponible en Factura (Para Agregado de Material)";
            this.ckDisponibleFactura.UseVisualStyleBackColor = true;
            // 
            // ckDisponibleRemitoL2
            // 
            this.ckDisponibleRemitoL2.AutoSize = true;
            this.ckDisponibleRemitoL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleRemitoL2.Location = new System.Drawing.Point(12, 53);
            this.ckDisponibleRemitoL2.Name = "ckDisponibleRemitoL2";
            this.ckDisponibleRemitoL2.Size = new System.Drawing.Size(141, 17);
            this.ckDisponibleRemitoL2.TabIndex = 88;
            this.ckDisponibleRemitoL2.Text = "Disponible en Remito L2";
            this.ckDisponibleRemitoL2.UseVisualStyleBackColor = true;
            // 
            // ckColor
            // 
            this.ckColor.AutoSize = true;
            this.ckColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckColor.Location = new System.Drawing.Point(20, 12);
            this.ckColor.Name = "ckColor";
            this.ckColor.Size = new System.Drawing.Size(50, 17);
            this.ckColor.TabIndex = 89;
            this.ckColor.Text = "Color";
            this.ckColor.UseVisualStyleBackColor = true;
            // 
            // ckBase
            // 
            this.ckBase.AutoSize = true;
            this.ckBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBase.Location = new System.Drawing.Point(20, 32);
            this.ckBase.Name = "ckBase";
            this.ckBase.Size = new System.Drawing.Size(50, 17);
            this.ckBase.TabIndex = 90;
            this.ckBase.Text = "Base";
            this.ckBase.UseVisualStyleBackColor = true;
            // 
            // ckBatchManagementDefault
            // 
            this.ckBatchManagementDefault.AutoSize = true;
            this.ckBatchManagementDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBatchManagementDefault.Location = new System.Drawing.Point(20, 52);
            this.ckBatchManagementDefault.Name = "ckBatchManagementDefault";
            this.ckBatchManagementDefault.Size = new System.Drawing.Size(138, 17);
            this.ckBatchManagementDefault.TabIndex = 91;
            this.ckBatchManagementDefault.Text = "Control por Lote Default";
            this.ckBatchManagementDefault.UseVisualStyleBackColor = true;
            // 
            // ckPermiteAKA
            // 
            this.ckPermiteAKA.AutoSize = true;
            this.ckPermiteAKA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPermiteAKA.Location = new System.Drawing.Point(20, 72);
            this.ckPermiteAKA.Name = "ckPermiteAKA";
            this.ckPermiteAKA.Size = new System.Drawing.Size(85, 17);
            this.ckPermiteAKA.TabIndex = 92;
            this.ckPermiteAKA.Text = "Permite AKA";
            this.ckPermiteAKA.UseVisualStyleBackColor = true;
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialType.Location = new System.Drawing.Point(83, 11);
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.Size = new System.Drawing.Size(64, 20);
            this.txtMaterialType.TabIndex = 2;
            // 
            // txtMaterialTypeDescription
            // 
            this.txtMaterialTypeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialTypeDescription.Location = new System.Drawing.Point(150, 11);
            this.txtMaterialTypeDescription.Name = "txtMaterialTypeDescription";
            this.txtMaterialTypeDescription.Size = new System.Drawing.Size(298, 20);
            this.txtMaterialTypeDescription.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo Material";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "GL Venta";
            // 
            // txtGLVenta
            // 
            this.txtGLVenta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGLVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLVenta.Location = new System.Drawing.Point(380, 59);
            this.txtGLVenta.Name = "txtGLVenta";
            this.txtGLVenta.ReadOnly = true;
            this.txtGLVenta.Size = new System.Drawing.Size(68, 20);
            this.txtGLVenta.TabIndex = 95;
            this.txtGLVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t0135GLVBs
            // 
            this.t0135GLVBs.DataSource = typeof(TecserEF.Entity.T0135_GLX);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "GL Inventario";
            // 
            // txtGLInventario
            // 
            this.txtGLInventario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGLInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLInventario.Location = new System.Drawing.Point(380, 81);
            this.txtGLInventario.Name = "txtGLInventario";
            this.txtGLInventario.ReadOnly = true;
            this.txtGLInventario.Size = new System.Drawing.Size(68, 20);
            this.txtGLInventario.TabIndex = 98;
            this.txtGLInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t0135GLIBs
            // 
            this.t0135GLIBs.DataSource = typeof(TecserEF.Entity.T0135_GLX);
            // 
            // ckDisponibleBOM
            // 
            this.ckDisponibleBOM.AutoSize = true;
            this.ckDisponibleBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleBOM.Location = new System.Drawing.Point(12, 99);
            this.ckDisponibleBOM.Name = "ckDisponibleBOM";
            this.ckDisponibleBOM.Size = new System.Drawing.Size(148, 17);
            this.ckDisponibleBOM.TabIndex = 100;
            this.ckDisponibleBOM.Text = "Disponible BOM (Formula)";
            this.ckDisponibleBOM.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(678, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Default UNIT";
            // 
            // txtDefaultUnit
            // 
            this.txtDefaultUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultUnit.Location = new System.Drawing.Point(755, 100);
            this.txtDefaultUnit.Name = "txtDefaultUnit";
            this.txtDefaultUnit.Size = new System.Drawing.Size(64, 20);
            this.txtDefaultUnit.TabIndex = 102;
            this.txtDefaultUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "MRP Genera";
            // 
            // txtMRPGeneraDocumento
            // 
            this.txtMRPGeneraDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRPGeneraDocumento.Location = new System.Drawing.Point(94, 95);
            this.txtMRPGeneraDocumento.Name = "txtMRPGeneraDocumento";
            this.txtMRPGeneraDocumento.Size = new System.Drawing.Size(32, 20);
            this.txtMRPGeneraDocumento.TabIndex = 104;
            this.txtMRPGeneraDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckDisponibleOF
            // 
            this.ckDisponibleOF.AutoSize = true;
            this.ckDisponibleOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleOF.Location = new System.Drawing.Point(12, 122);
            this.ckDisponibleOF.Name = "ckDisponibleOF";
            this.ckDisponibleOF.Size = new System.Drawing.Size(92, 17);
            this.ckDisponibleOF.TabIndex = 105;
            this.ckDisponibleOF.Text = "Disponible OF";
            this.ckDisponibleOF.UseVisualStyleBackColor = true;
            // 
            // ckDisponibleOC
            // 
            this.ckDisponibleOC.AutoSize = true;
            this.ckDisponibleOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDisponibleOC.Location = new System.Drawing.Point(12, 145);
            this.ckDisponibleOC.Name = "ckDisponibleOC";
            this.ckDisponibleOC.Size = new System.Drawing.Size(93, 17);
            this.ckDisponibleOC.TabIndex = 106;
            this.ckDisponibleOC.Text = "Disponible OC";
            this.ckDisponibleOC.UseVisualStyleBackColor = true;
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(357, 336);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(379, 88);
            this.txtComentario.TabIndex = 107;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(354, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Documentacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(678, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 109;
            this.label8.Text = "SLOC Default";
            // 
            // txtSlocDefault
            // 
            this.txtSlocDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlocDefault.Location = new System.Drawing.Point(755, 77);
            this.txtSlocDefault.Name = "txtSlocDefault";
            this.txtSlocDefault.Size = new System.Drawing.Size(64, 20);
            this.txtSlocDefault.TabIndex = 110;
            this.txtSlocDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "MG-MULT";
            // 
            // txtControlCostoMultiplicador
            // 
            this.txtControlCostoMultiplicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlCostoMultiplicador.Location = new System.Drawing.Point(80, 7);
            this.txtControlCostoMultiplicador.Name = "txtControlCostoMultiplicador";
            this.txtControlCostoMultiplicador.Size = new System.Drawing.Size(64, 20);
            this.txtControlCostoMultiplicador.TabIndex = 112;
            this.txtControlCostoMultiplicador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtControlCostoMultiplicador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControlCostoMultiplicador_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 113;
            this.label10.Text = "MG-ADD";
            // 
            // txtControlCostoAdded
            // 
            this.txtControlCostoAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlCostoAdded.Location = new System.Drawing.Point(80, 30);
            this.txtControlCostoAdded.Name = "txtControlCostoAdded";
            this.txtControlCostoAdded.Size = new System.Drawing.Size(64, 20);
            this.txtControlCostoAdded.TabIndex = 114;
            this.txtControlCostoAdded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtControlCostoAdded.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControlCostoMultiplicador_KeyPress);
            // 
            // panPropiedades
            // 
            this.panPropiedades.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panPropiedades.Controls.Add(this.ckColor);
            this.panPropiedades.Controls.Add(this.ckBase);
            this.panPropiedades.Controls.Add(this.ckBatchManagementDefault);
            this.panPropiedades.Controls.Add(this.ckPermiteAKA);
            this.panPropiedades.Controls.Add(this.label6);
            this.panPropiedades.Controls.Add(this.txtMRPGeneraDocumento);
            this.panPropiedades.Location = new System.Drawing.Point(12, 160);
            this.panPropiedades.Name = "panPropiedades";
            this.panPropiedades.Size = new System.Drawing.Size(237, 140);
            this.panPropiedades.TabIndex = 115;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 19);
            this.label11.TabIndex = 116;
            this.label11.Text = "PROPIEDADES MATERIAL [MM]";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(290, 19);
            this.label12.TabIndex = 117;
            this.label12.Text = "COMPORTAMIENTO DEL MATERIAL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panComportamiento
            // 
            this.panComportamiento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panComportamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panComportamiento.Controls.Add(this.ckDisponibleNotaPedido);
            this.panComportamiento.Controls.Add(this.ckDisponibleRemito);
            this.panComportamiento.Controls.Add(this.ckDisponibleFactura);
            this.panComportamiento.Controls.Add(this.ckDisponibleRemitoL2);
            this.panComportamiento.Controls.Add(this.ckDisponibleBOM);
            this.panComportamiento.Controls.Add(this.ckDisponibleOF);
            this.panComportamiento.Controls.Add(this.ckDisponibleOC);
            this.panComportamiento.Location = new System.Drawing.Point(12, 337);
            this.panComportamiento.Name = "panComportamiento";
            this.panComportamiento.Size = new System.Drawing.Size(290, 172);
            this.panComportamiento.TabIndex = 116;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(357, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(462, 19);
            this.label13.TabIndex = 119;
            this.label13.Text = "CONTROL DE COSTOS";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmbGLI);
            this.panel4.Controls.Add(this.txtControlCostoMultiplicador);
            this.panel4.Controls.Add(this.cmbGLV);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtControlCostoAdded);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtGLVenta);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtGLInventario);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(357, 160);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 113);
            this.panel4.TabIndex = 118;
            // 
            // cmbGLI
            // 
            this.cmbGLI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGLI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLI.DataSource = this.t0135GLIBs;
            this.cmbGLI.DisplayMember = "GLDESC";
            this.cmbGLI.FormattingEnabled = true;
            this.cmbGLI.Location = new System.Drawing.Point(80, 81);
            this.cmbGLI.Name = "cmbGLI";
            this.cmbGLI.Size = new System.Drawing.Size(298, 21);
            this.cmbGLI.TabIndex = 120;
            this.cmbGLI.ValueMember = "GL";
            this.cmbGLI.SelectedIndexChanged += new System.EventHandler(this.cmbGLI_SelectedIndexChanged);
            // 
            // cmbGLV
            // 
            this.cmbGLV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGLV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLV.DataSource = this.t0135GLVBs;
            this.cmbGLV.DisplayMember = "GLDESC";
            this.cmbGLV.FormattingEnabled = true;
            this.cmbGLV.Location = new System.Drawing.Point(80, 58);
            this.cmbGLV.Name = "cmbGLV";
            this.cmbGLV.Size = new System.Drawing.Size(298, 21);
            this.cmbGLV.TabIndex = 84;
            this.cmbGLV.ValueMember = "GL";
            this.cmbGLV.SelectedIndexChanged += new System.EventHandler(this.cmbGLV_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ckStockManagement);
            this.panel5.Controls.Add(this.txtMaterialType);
            this.panel5.Controls.Add(this.txtMaterialTypeDescription);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(12, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(647, 40);
            this.panel5.TabIndex = 119;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.MediumBlue;
            this.label14.Location = new System.Drawing.Point(991, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(3, 392);
            this.label14.TabIndex = 202;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.MediumBlue;
            this.label15.Location = new System.Drawing.Point(2, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(635, 3);
            this.label15.TabIndex = 201;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.MediumBlue;
            this.label16.Location = new System.Drawing.Point(2, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(3, 392);
            this.label16.TabIndex = 203;
            // 
            // FrmMaterialTypeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 515);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnNuevoTipo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panComportamiento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panPropiedades);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSlocDefault);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDefaultUnit);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMaterialTypeManager";
            this.Text = "MM  - Tipo de Material";
            this.Load += new System.EventHandler(this.FrmMaterialTypeManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialTypeBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLVBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0135GLIBs)).EndInit();
            this.panPropiedades.ResumeLayout(false);
            this.panPropiedades.PerformLayout();
            this.panComportamiento.ResumeLayout(false);
            this.panComportamiento.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMaterialType;
        private System.Windows.Forms.BindingSource MaterialTypeBs;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevoTipo;
        private System.Windows.Forms.CheckBox ckStockManagement;
        private System.Windows.Forms.CheckBox ckDisponibleNotaPedido;
        private System.Windows.Forms.CheckBox ckDisponibleRemito;
        private System.Windows.Forms.CheckBox ckDisponibleFactura;
        private System.Windows.Forms.CheckBox ckDisponibleRemitoL2;
        private System.Windows.Forms.CheckBox ckColor;
        private System.Windows.Forms.CheckBox ckBase;
        private System.Windows.Forms.CheckBox ckBatchManagementDefault;
        private System.Windows.Forms.CheckBox ckPermiteAKA;
        private System.Windows.Forms.TextBox txtMaterialType;
        private System.Windows.Forms.TextBox txtMaterialTypeDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGLVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGLInventario;
        private System.Windows.Forms.CheckBox ckDisponibleBOM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDefaultUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMRPGeneraDocumento;
        private System.Windows.Forms.CheckBox ckDisponibleOF;
        private System.Windows.Forms.CheckBox ckDisponibleOC;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSlocDefault;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtControlCostoMultiplicador;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtControlCostoAdded;
        private System.Windows.Forms.Panel panPropiedades;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panComportamiento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbGLI;
        private System.Windows.Forms.BindingSource t0135GLIBs;
        private System.Windows.Forms.ComboBox cmbGLV;
        private System.Windows.Forms.BindingSource t0135GLVBs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}