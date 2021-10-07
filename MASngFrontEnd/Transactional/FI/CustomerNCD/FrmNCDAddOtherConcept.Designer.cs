namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmNcdAddOtherConcept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNcdAddOtherConcept));
            this.label20 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescripcionItem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtGlDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGLV = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.MaterialBs = new System.Windows.Forms.BindingSource(this.components);
            this.GlBs = new System.Windows.Forms.BindingSource(this.components);
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Navy;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 58);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(546, 19);
            this.label20.TabIndex = 36;
            this.label20.Text = "PROPIEDADES DEL MATERIAL";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.DataSource = this.MaterialBs;
            this.cmbItem.DisplayMember = "CODVENTA";
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmbItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(77, 7);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(128, 21);
            this.cmbItem.TabIndex = 2;
            this.cmbItem.ValueMember = "CODVENTA";
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(7, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Razon Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRazonSocial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRazonSocial.Location = new System.Drawing.Point(100, 3);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(244, 20);
            this.txtRazonSocial.TabIndex = 4;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCantidad.Location = new System.Drawing.Point(77, 52);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(51, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioTotal_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.White;
            this.txtIdCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtIdCliente.Location = new System.Drawing.Point(346, 3);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(44, 20);
            this.txtIdCliente.TabIndex = 38;
            this.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Tipo Documento";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.BackColor = System.Drawing.Color.White;
            this.txtTipoDocumento.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipoDocumento.Location = new System.Drawing.Point(100, 25);
            this.txtTipoDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(244, 20);
            this.txtTipoDocumento.TabIndex = 39;
            // 
            // txtLx
            // 
            this.txtLx.BackColor = System.Drawing.Color.White;
            this.txtLx.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLx.Location = new System.Drawing.Point(346, 25);
            this.txtLx.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(44, 20);
            this.txtLx.TabIndex = 41;
            this.txtLx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.txtLx);
            this.panel1.Controls.Add(this.txtTipoDocumento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 51);
            this.panel1.TabIndex = 36;
            // 
            // txtDescripcionItem
            // 
            this.txtDescripcionItem.BackColor = System.Drawing.Color.White;
            this.txtDescripcionItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDescripcionItem.Location = new System.Drawing.Point(77, 30);
            this.txtDescripcionItem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescripcionItem.Name = "txtDescripcionItem";
            this.txtDescripcionItem.Size = new System.Drawing.Size(314, 20);
            this.txtDescripcionItem.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Concepto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(8, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Descripcion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(8, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Cantidad";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(8, 77);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Unitario";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(77, 74);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(93, 20);
            this.txtPrecioUnitario.TabIndex = 45;
            this.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioTotal_KeyPress);
            this.txtPrecioUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrecioUnitario_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(8, 99);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Total";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPrecioTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPrecioTotal.Location = new System.Drawing.Point(77, 96);
            this.txtPrecioTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(93, 20);
            this.txtPrecioTotal.TabIndex = 47;
            this.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioTotal_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.txtGlDescripcion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbGLV);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDescripcionItem);
            this.panel2.Controls.Add(this.txtCantidad);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cmbItem);
            this.panel2.Controls.Add(this.txtPrecioTotal);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtPrecioUnitario);
            this.panel2.Location = new System.Drawing.Point(3, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 146);
            this.panel2.TabIndex = 49;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(431, 52);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 40);
            this.btnAgregar.TabIndex = 52;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtGlDescripcion
            // 
            this.txtGlDescripcion.BackColor = System.Drawing.Color.White;
            this.txtGlDescripcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGlDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.GlBs, "GLDESC", true));
            this.txtGlDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.txtGlDescripcion.Location = new System.Drawing.Point(172, 118);
            this.txtGlDescripcion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGlDescripcion.Name = "txtGlDescripcion";
            this.txtGlDescripcion.Size = new System.Drawing.Size(338, 21);
            this.txtGlDescripcion.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "GL Ventas";
            // 
            // cmbGLV
            // 
            this.cmbGLV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGLV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLV.DataSource = this.GlBs;
            this.cmbGLV.DisplayMember = "GL";
            this.cmbGLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmbGLV.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbGLV.FormattingEnabled = true;
            this.cmbGLV.Location = new System.Drawing.Point(77, 118);
            this.cmbGLV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbGLV.Name = "cmbGLV";
            this.cmbGLV.Size = new System.Drawing.Size(93, 21);
            this.cmbGLV.TabIndex = 49;
            this.cmbGLV.ValueMember = "GL";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(562, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 50;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MaterialBs
            // 
            this.MaterialBs.DataSource = typeof(TecserEF.Entity.T0011_MATERIALES_AKA);
            // 
            // GlBs
            // 
            this.GlBs.DataSource = typeof(TecserEF.Entity.T0135_GLX);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // FrmNcdAddOtherConcept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 227);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label20);
            this.Name = "FrmNcdAddOtherConcept";
            this.Text = "FrmNCDAddOtherConcept";
            this.Load += new System.EventHandler(this.FrmNCDAddOtherConcept_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescripcionItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtGlDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGLV;
        private System.Windows.Forms.BindingSource MaterialBs;
        private System.Windows.Forms.BindingSource GlBs;
        private System.Windows.Forms.ErrorProvider ep;
    }
}