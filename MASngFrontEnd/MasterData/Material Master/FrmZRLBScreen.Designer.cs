namespace MASngFE.MasterData.Material_Master
{
    partial class FrmZRLBScreen
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
            this.cmbMateriaPrimaOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionL1 = new System.Windows.Forms.TextBox();
            this.txtDescripcionL5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "MATERIAL PRIMARIO (MATERIA PRIMA / PREMASTER)";
            // 
            // cmbMateriaPrimaOrigen
            // 
            this.cmbMateriaPrimaOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMateriaPrimaOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMateriaPrimaOrigen.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbMateriaPrimaOrigen.DisplayMember = "IDMATERIAL";
            this.cmbMateriaPrimaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateriaPrimaOrigen.FormattingEnabled = true;
            this.cmbMateriaPrimaOrigen.Location = new System.Drawing.Point(309, 34);
            this.cmbMateriaPrimaOrigen.Name = "cmbMateriaPrimaOrigen";
            this.cmbMateriaPrimaOrigen.Size = new System.Drawing.Size(173, 23);
            this.cmbMateriaPrimaOrigen.TabIndex = 1;
            this.cmbMateriaPrimaOrigen.ValueMember = "IDMATERIAL";
            this.cmbMateriaPrimaOrigen.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(528, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "El material ZRLB es un reembolsado + reetiquetado automatico de una materia prima" +
    "";
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(565, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(96, 36);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "CANCELAR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(565, 47);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "SELECCIONAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0010MATERIALESBindingSource, "MAT_DESC", true));
            this.textBox1.Location = new System.Drawing.Point(15, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(467, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 54);
            this.label3.TabIndex = 6;
            this.label3.Text = "Se creara solamente la informacion de AKA (material de venta) \r\n\r\nDebe proveer AH" +
    "ORA la descripcion de Venta para el REMITO y para la FACTURA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "DESCRIPCION REMITO/FACTURA L1.L2 ";
            // 
            // txtDescripcionL1
            // 
            this.txtDescripcionL1.BackColor = System.Drawing.Color.Thistle;
            this.txtDescripcionL1.Location = new System.Drawing.Point(229, 190);
            this.txtDescripcionL1.Name = "txtDescripcionL1";
            this.txtDescripcionL1.Size = new System.Drawing.Size(432, 23);
            this.txtDescripcionL1.TabIndex = 8;
            this.txtDescripcionL1.Leave += new System.EventHandler(this.txtDescripcionL1_Leave);
            // 
            // txtDescripcionL5
            // 
            this.txtDescripcionL5.BackColor = System.Drawing.Color.Thistle;
            this.txtDescripcionL5.Location = new System.Drawing.Point(229, 215);
            this.txtDescripcionL5.Name = "txtDescripcionL5";
            this.txtDescripcionL5.Size = new System.Drawing.Size(432, 23);
            this.txtDescripcionL5.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "DESCRIPCION REMITO/FACTURA L1 (L5)";
            // 
            // FrmZRLBScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 314);
            this.Controls.Add(this.txtDescripcionL5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcionL1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMateriaPrimaOrigen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmZRLBScreen";
            this.Text = "** ZRLB MATERIAL >> REEMBOLSADO + REETIQUETADO";
            this.Load += new System.EventHandler(this.FrmZRLBScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMateriaPrimaOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionL1;
        private System.Windows.Forms.TextBox txtDescripcionL5;
        private System.Windows.Forms.Label label5;
    }
}