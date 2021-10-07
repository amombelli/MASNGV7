namespace MASngFE.Transactional.FI.TaxModule
{
    partial class FrmFI13TaxConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI13TaxConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label15 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.ckCliente = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdTax = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAutoComplete = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.t0016TaxModuleDefinitionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.cAlicuota = new TSControls.CtlTextBox();
            this.ckProveedor = new System.Windows.Forms.CheckBox();
            this.@__idtax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__alicuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0016TaxModuleDefinitionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.DarkOrchid;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkBlue;
            this.label15.Location = new System.Drawing.Point(3, 3);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(788, 3);
            this.label15.TabIndex = 194;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkOrchid;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(3, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 582);
            this.LineaIzq.TabIndex = 193;
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelData.Controls.Add(this.ckProveedor);
            this.panelData.Controls.Add(this.cAlicuota);
            this.panelData.Controls.Add(this.ckCliente);
            this.panelData.Controls.Add(this.label13);
            this.panelData.Controls.Add(this.txtIdTax);
            this.panelData.Controls.Add(this.label17);
            this.panelData.Controls.Add(this.txtDescripcion);
            this.panelData.Controls.Add(this.label3);
            this.panelData.Location = new System.Drawing.Point(10, 279);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(407, 131);
            this.panelData.TabIndex = 198;
            // 
            // ckCliente
            // 
            this.ckCliente.AutoSize = true;
            this.ckCliente.Location = new System.Drawing.Point(108, 77);
            this.ckCliente.Name = "ckCliente";
            this.ckCliente.Size = new System.Drawing.Size(109, 19);
            this.ckCliente.TabIndex = 204;
            this.ckCliente.Text = "Modulo Cliente";
            this.ckCliente.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 15);
            this.label13.TabIndex = 91;
            this.label13.Text = "Alicuota Calculo";
            // 
            // txtIdTax
            // 
            this.txtIdTax.BackColor = System.Drawing.Color.White;
            this.txtIdTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdTax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTax.Location = new System.Drawing.Point(108, 4);
            this.txtIdTax.MaxLength = 20;
            this.txtIdTax.Name = "txtIdTax";
            this.txtIdTax.Size = new System.Drawing.Size(104, 22);
            this.txtIdTax.TabIndex = 89;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(59, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 15);
            this.label17.TabIndex = 11;
            this.label17.Text = "TAX ID";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(108, 28);
            this.txtDescripcion.MaxLength = 40;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(225, 21);
            this.txtDescripcion.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Descripcion";
            // 
            // btnAutoComplete
            // 
            this.btnAutoComplete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoComplete.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoComplete.Image")));
            this.btnAutoComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoComplete.Location = new System.Drawing.Point(761, 244);
            this.btnAutoComplete.Name = "btnAutoComplete";
            this.btnAutoComplete.Size = new System.Drawing.Size(100, 40);
            this.btnAutoComplete.TabIndex = 201;
            this.btnAutoComplete.Text = "AUTO\r\nPadron";
            this.btnAutoComplete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAutoComplete.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(423, 50);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevo.TabIndex = 200;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(423, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 199;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idtax,
            this.@__descripcion,
            this.@__alicuota,
            this.@__modulo});
            this.dgv1.DataSource = this.t0016TaxModuleDefinitionBindingSource;
            this.dgv1.GridColor = System.Drawing.Color.DarkSeaGreen;
            this.dgv1.Location = new System.Drawing.Point(10, 34);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 20;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(407, 235);
            this.dgv1.TabIndex = 202;
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkOrchid;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(10, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 3);
            this.label1.TabIndex = 203;
            // 
            // t0016TaxModuleDefinitionBindingSource
            // 
            this.t0016TaxModuleDefinitionBindingSource.DataSource = typeof(TecserEF.Entity.T0016_TaxModuleDefinition);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.LavenderBlush;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(10, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(407, 20);
            this.label16.TabIndex = 204;
            this.label16.Text = "Modulo Impuestos - Configuracion I";
            // 
            // cAlicuota
            // 
            this.cAlicuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cAlicuota.BackColor = System.Drawing.SystemColors.Control;
            this.cAlicuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cAlicuota.Location = new System.Drawing.Point(108, 51);
            this.cAlicuota.Margin = new System.Windows.Forms.Padding(0);
            this.cAlicuota.Name = "cAlicuota";
            this.cAlicuota.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cAlicuota.SetDecimales = 5;
            this.cAlicuota.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cAlicuota.Size = new System.Drawing.Size(87, 21);
            this.cAlicuota.TabIndex = 208;
            this.cAlicuota.ValorMaximo = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.cAlicuota.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cAlicuota.XReadOnly = false;
            // 
            // ckProveedor
            // 
            this.ckProveedor.AutoSize = true;
            this.ckProveedor.Location = new System.Drawing.Point(108, 100);
            this.ckProveedor.Name = "ckProveedor";
            this.ckProveedor.Size = new System.Drawing.Size(127, 19);
            this.ckProveedor.TabIndex = 209;
            this.ckProveedor.Text = "Modulo Proveedor";
            this.ckProveedor.UseVisualStyleBackColor = true;
            // 
            // __idtax
            // 
            this.@__idtax.DataPropertyName = "IdTax";
            this.@__idtax.HeaderText = "TaxID";
            this.@__idtax.Name = "__idtax";
            this.@__idtax.ReadOnly = true;
            this.@__idtax.ToolTipText = "Nombre del Impuesto";
            this.@__idtax.Width = 50;
            // 
            // __descripcion
            // 
            this.@__descripcion.DataPropertyName = "TaxDescription";
            this.@__descripcion.HeaderText = "Descripcion";
            this.@__descripcion.Name = "__descripcion";
            this.@__descripcion.ReadOnly = true;
            this.@__descripcion.ToolTipText = "Descripcion del Impuesto";
            this.@__descripcion.Width = 200;
            // 
            // __alicuota
            // 
            this.@__alicuota.DataPropertyName = "Alicuota";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            this.@__alicuota.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__alicuota.HeaderText = "Alicuota";
            this.@__alicuota.Name = "__alicuota";
            this.@__alicuota.ReadOnly = true;
            this.@__alicuota.ToolTipText = "Alicuota a Aplicar/Calcular";
            this.@__alicuota.Width = 60;
            // 
            // __modulo
            // 
            this.@__modulo.DataPropertyName = "ModuloAplica";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.@__modulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.@__modulo.HeaderText = "Modulo";
            this.@__modulo.Name = "__modulo";
            this.@__modulo.ReadOnly = true;
            this.@__modulo.ToolTipText = "Modulo en el que Aplica C/V";
            this.@__modulo.Width = 60;
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(423, 90);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 205;
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(423, 130);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 40);
            this.btnGrabar.TabIndex = 206;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // FrmFI13TaxConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btnAutoComplete);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.LineaIzq);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI13TaxConfig";
            this.Text = "FI13 - Tax Config";
            this.Load += new System.EventHandler(this.FrmFI13TaxConfig_Load);
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0016TaxModuleDefinitionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.CheckBox ckCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdTax;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAutoComplete;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource t0016TaxModuleDefinitionBindingSource;
        private System.Windows.Forms.CheckBox ckProveedor;
        private TSControls.CtlTextBox cAlicuota;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idtax;
        private System.Windows.Forms.DataGridViewTextBoxColumn __descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn __alicuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn __modulo;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ErrorProvider ep;
    }
}