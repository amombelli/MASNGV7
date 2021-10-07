namespace MASngFE.Transactional.FI.Factura
{
    partial class FrmSeleccionZTerm
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
            this.txtClienteSeleccionado = new System.Windows.Forms.TextBox();
            this.cmbZterm = new System.Windows.Forms.ComboBox();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.txtZtermDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateMaestroClientes = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.t0019ZTERMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.t0019ZTERMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClienteSeleccionado
            // 
            this.txtClienteSeleccionado.Location = new System.Drawing.Point(158, 10);
            this.txtClienteSeleccionado.Name = "txtClienteSeleccionado";
            this.txtClienteSeleccionado.Size = new System.Drawing.Size(312, 22);
            this.txtClienteSeleccionado.TabIndex = 2;
            // 
            // cmbZterm
            // 
            this.cmbZterm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZterm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZterm.DataSource = this.t0019ZTERMBindingSource;
            this.cmbZterm.DisplayMember = "ZTERM";
            this.cmbZterm.FormattingEnabled = true;
            this.cmbZterm.Location = new System.Drawing.Point(158, 91);
            this.cmbZterm.Name = "cmbZterm";
            this.cmbZterm.Size = new System.Drawing.Size(77, 22);
            this.cmbZterm.TabIndex = 3;
            this.cmbZterm.ValueMember = "ZTERM";
            this.cmbZterm.SelectedIndexChanged += new System.EventHandler(this.cmbZterm_SelectedIndexChanged);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(549, 12);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(118, 44);
            this.btnSeleccion.TabIndex = 4;
            this.btnSeleccion.Text = "SELECCIONAR\r\nCOND.PAGO";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "CLIENTE SELECCIONADO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "CONDICION VENTA";
            // 
            // txtLx
            // 
            this.txtLx.Location = new System.Drawing.Point(158, 34);
            this.txtLx.Name = "txtLx";
            this.txtLx.Size = new System.Drawing.Size(38, 22);
            this.txtLx.TabIndex = 7;
            // 
            // txtZtermDescripcion
            // 
            this.txtZtermDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0019ZTERMBindingSource, "ZTERMDESC", true));
            this.txtZtermDescripcion.Location = new System.Drawing.Point(241, 91);
            this.txtZtermDescripcion.Name = "txtZtermDescripcion";
            this.txtZtermDescripcion.Size = new System.Drawing.Size(229, 22);
            this.txtZtermDescripcion.TabIndex = 9;
            this.txtZtermDescripcion.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(507, 2);
            this.label3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "TERMINO DE PAGO";
            // 
            // btnUpdateMaestroClientes
            // 
            this.btnUpdateMaestroClientes.Location = new System.Drawing.Point(549, 61);
            this.btnUpdateMaestroClientes.Name = "btnUpdateMaestroClientes";
            this.btnUpdateMaestroClientes.Size = new System.Drawing.Size(118, 44);
            this.btnUpdateMaestroClientes.TabIndex = 12;
            this.btnUpdateMaestroClientes.Text = "MODIFICAR\r\nMAESTRO CLIENTES";
            this.btnUpdateMaestroClientes.UseVisualStyleBackColor = true;
            this.btnUpdateMaestroClientes.Click += new System.EventHandler(this.btnUpdateMaestroClientes_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(549, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 44);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // t0019ZTERMBindingSource
            // 
            this.t0019ZTERMBindingSource.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // FrmSeleccionZTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 172);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnUpdateMaestroClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtZtermDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.cmbZterm);
            this.Controls.Add(this.txtClienteSeleccionado);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmSeleccionZTerm";
            this.Text = "SELECCION DE TERMINO DE PAGO";
            this.Load += new System.EventHandler(this.FrmSeleccionZTerm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0019ZTERMBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtClienteSeleccionado;
        private System.Windows.Forms.ComboBox cmbZterm;
        private System.Windows.Forms.BindingSource t0019ZTERMBindingSource;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.TextBox txtZtermDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateMaestroClientes;
        private System.Windows.Forms.Button btnCancelar;
    }
}