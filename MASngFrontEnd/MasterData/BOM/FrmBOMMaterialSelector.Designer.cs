namespace MASngFE.MasterData.BOM
{
    partial class FrmBOMMaterialSelector
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
            this.txtDescripcionMaterial = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.txtMaterialTypeDescripccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtUoM = new System.Windows.Forms.TextBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcionMaterial
            // 
            this.txtDescripcionMaterial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0010MATERIALESBindingSource, "MAT_DESC", true));
            this.txtDescripcionMaterial.Location = new System.Drawing.Point(307, 10);
            this.txtDescripcionMaterial.Name = "txtDescripcionMaterial";
            this.txtDescripcionMaterial.ReadOnly = true;
            this.txtDescripcionMaterial.Size = new System.Drawing.Size(316, 23);
            this.txtDescripcionMaterial.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(648, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "MATERIAL (COMPONENTE)";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbMaterial.DisplayMember = "IDMATERIAL";
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(166, 10);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(135, 23);
            this.cmbMaterial.TabIndex = 3;
            this.cmbMaterial.ValueMember = "IDMATERIAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "TIPO MAT";
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0010MATERIALESBindingSource, "TIPO_MATERIAL", true));
            this.txtMaterialType.Location = new System.Drawing.Point(83, 60);
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.ReadOnly = true;
            this.txtMaterialType.Size = new System.Drawing.Size(77, 23);
            this.txtMaterialType.TabIndex = 4;
            // 
            // txtMaterialTypeDescripccion
            // 
            this.txtMaterialTypeDescripccion.Location = new System.Drawing.Point(166, 60);
            this.txtMaterialTypeDescripccion.Name = "txtMaterialTypeDescripccion";
            this.txtMaterialTypeDescripccion.ReadOnly = true;
            this.txtMaterialTypeDescripccion.Size = new System.Drawing.Size(457, 23);
            this.txtMaterialTypeDescripccion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "CANTIDAD";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(83, 99);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 23);
            this.txtCantidad.TabIndex = 7;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.Green;
            this.btnAceptar.Location = new System.Drawing.Point(648, 49);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 38);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtUoM
            // 
            this.txtUoM.Location = new System.Drawing.Point(166, 99);
            this.txtUoM.Name = "txtUoM";
            this.txtUoM.ReadOnly = true;
            this.txtUoM.Size = new System.Drawing.Size(77, 23);
            this.txtUoM.TabIndex = 10;
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0010MATERIALESBindingSource, "MAT_DESC2", true));
            this.textBox1.Location = new System.Drawing.Point(307, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(316, 23);
            this.textBox1.TabIndex = 11;
            // 
            // FrmBOMMaterialSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 133);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtUoM);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMaterialTypeDescripccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaterialType);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtDescripcionMaterial);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBOMMaterialSelector";
            this.Text = "BOM - SELECCION DE MATERIA PRIMA";
            this.Load += new System.EventHandler(this.FrmBOMMaterialSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcionMaterial;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaterialType;
        private System.Windows.Forms.TextBox txtMaterialTypeDescripccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtUoM;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.TextBox textBox1;
    }
}