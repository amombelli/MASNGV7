namespace MASngFE.MasterData.Material_Master
{
    partial class FrmMaterialMasterAKA
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoPrimario = new System.Windows.Forms.TextBox();
            this.txtCodigoVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionL1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcionL5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.t0012TIPOMATERIALBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrimarioDescripcion = new System.Windows.Forms.TextBox();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            this.txtlogUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogFecha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcionTipo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0012TIPOMATERIALBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(664, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 37);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(664, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 37);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "CODIGO PRIMARIO";
            // 
            // txtCodigoPrimario
            // 
            this.txtCodigoPrimario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCodigoPrimario.Location = new System.Drawing.Point(139, 9);
            this.txtCodigoPrimario.Name = "txtCodigoPrimario";
            this.txtCodigoPrimario.ReadOnly = true;
            this.txtCodigoPrimario.Size = new System.Drawing.Size(136, 23);
            this.txtCodigoPrimario.TabIndex = 3;
            // 
            // txtCodigoVenta
            // 
            this.txtCodigoVenta.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtCodigoVenta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVenta.Location = new System.Drawing.Point(281, 85);
            this.txtCodigoVenta.Name = "txtCodigoVenta";
            this.txtCodigoVenta.Size = new System.Drawing.Size(136, 27);
            this.txtCodigoVenta.TabIndex = 5;
            this.txtCodigoVenta.Leave += new System.EventHandler(this.txtCodigoVenta_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "CODIGO VENTA";
            // 
            // txtDescripcionL1
            // 
            this.txtDescripcionL1.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtDescripcionL1.Location = new System.Drawing.Point(281, 116);
            this.txtDescripcionL1.Name = "txtDescripcionL1";
            this.txtDescripcionL1.Size = new System.Drawing.Size(371, 23);
            this.txtDescripcionL1.TabIndex = 7;
            this.txtDescripcionL1.Leave += new System.EventHandler(this.txtDescripcionL1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "DESCRIPCION REMITO Y FACTURA";
            // 
            // txtDescripcionL5
            // 
            this.txtDescripcionL5.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtDescripcionL5.Location = new System.Drawing.Point(281, 142);
            this.txtDescripcionL5.Name = "txtDescripcionL5";
            this.txtDescripcionL5.Size = new System.Drawing.Size(371, 23);
            this.txtDescripcionL5.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "DESCRIPCION REMITO Y FACTURA *L5";
            // 
            // cmbTipoMaterial
            // 
            this.cmbTipoMaterial.DataSource = this.t0012TIPOMATERIALBindingSource1;
            this.cmbTipoMaterial.DisplayMember = "TIPO_MATERIAL";
            this.cmbTipoMaterial.FormattingEnabled = true;
            this.cmbTipoMaterial.Location = new System.Drawing.Point(139, 35);
            this.cmbTipoMaterial.Name = "cmbTipoMaterial";
            this.cmbTipoMaterial.Size = new System.Drawing.Size(79, 23);
            this.cmbTipoMaterial.TabIndex = 10;
            this.cmbTipoMaterial.ValueMember = "TIPO_MATERIAL";
            // 
            // t0012TIPOMATERIALBindingSource1
            // 
            this.t0012TIPOMATERIALBindingSource1.DataSource = typeof(TecserEF.Entity.T0011_MaterialType);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "TIPO MATERIAL";
            // 
            // txtPrimarioDescripcion
            // 
            this.txtPrimarioDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPrimarioDescripcion.Location = new System.Drawing.Point(281, 9);
            this.txtPrimarioDescripcion.Name = "txtPrimarioDescripcion";
            this.txtPrimarioDescripcion.ReadOnly = true;
            this.txtPrimarioDescripcion.Size = new System.Drawing.Size(371, 23);
            this.txtPrimarioDescripcion.TabIndex = 12;
            // 
            // ckActivo
            // 
            this.ckActivo.AutoSize = true;
            this.ckActivo.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ckActivo.Location = new System.Drawing.Point(423, 88);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.Size = new System.Drawing.Size(121, 19);
            this.ckActivo.TabIndex = 13;
            this.ckActivo.Text = "MATERIAL ACTIVO";
            this.ckActivo.UseVisualStyleBackColor = false;
            this.ckActivo.CheckedChanged += new System.EventHandler(this.ckActivo_CheckedChanged);
            // 
            // txtlogUser
            // 
            this.txtlogUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtlogUser.Location = new System.Drawing.Point(139, 178);
            this.txtlogUser.Name = "txtlogUser";
            this.txtlogUser.ReadOnly = true;
            this.txtlogUser.Size = new System.Drawing.Size(136, 23);
            this.txtlogUser.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "CREADO POR";
            // 
            // txtLogFecha
            // 
            this.txtLogFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLogFecha.Location = new System.Drawing.Point(139, 203);
            this.txtLogFecha.Name = "txtLogFecha";
            this.txtLogFecha.ReadOnly = true;
            this.txtLogFecha.Size = new System.Drawing.Size(136, 23);
            this.txtLogFecha.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "FECHA CREACION";
            // 
            // txtDescripcionTipo
            // 
            this.txtDescripcionTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDescripcionTipo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0012TIPOMATERIALBindingSource1, "DESCRIPCION", true));
            this.txtDescripcionTipo.Location = new System.Drawing.Point(281, 35);
            this.txtDescripcionTipo.Name = "txtDescripcionTipo";
            this.txtDescripcionTipo.ReadOnly = true;
            this.txtDescripcionTipo.Size = new System.Drawing.Size(371, 23);
            this.txtDescripcionTipo.TabIndex = 18;
            // 
            // FrmMaterialMasterAKA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 240);
            this.Controls.Add(this.txtDescripcionTipo);
            this.Controls.Add(this.txtLogFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtlogUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckActivo);
            this.Controls.Add(this.txtPrimarioDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoMaterial);
            this.Controls.Add(this.txtDescripcionL5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescripcionL1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoPrimario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMaterialMasterAKA";
            this.Text = "INFORMACION MATERIAL - CODIGO DE VENTA";
            this.Load += new System.EventHandler(this.FrmMaterialMasterAKA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0012TIPOMATERIALBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoPrimario;
        private System.Windows.Forms.TextBox txtCodigoVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionL1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcionL5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrimarioDescripcion;
        private System.Windows.Forms.BindingSource t0012TIPOMATERIALBindingSource1;
        private System.Windows.Forms.CheckBox ckActivo;
        private System.Windows.Forms.TextBox txtlogUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcionTipo;
    }
}