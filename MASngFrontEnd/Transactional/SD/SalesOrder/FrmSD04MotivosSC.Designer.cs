namespace MASngFE.Transactional.SD.SalesOrder
{
    partial class FrmSD04MotivosSc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD04MotivosSc));
            this.t0085PERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Line = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbCambioMaterial = new System.Windows.Forms.RadioButton();
            this.rbBonificacionEspecial = new System.Windows.Forms.RadioButton();
            this.rbReproceso = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMuestraSinCargo = new System.Windows.Forms.RadioButton();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtSalesOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.cmbAutorizo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t0085PERSONALBindingSource
            // 
            this.t0085PERSONALBindingSource.DataSource = typeof(TecserEF.Entity.T0085_PERSONAL);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(473, 48);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(101, 40);
            this.btnGrabar.TabIndex = 201;
            this.btnGrabar.Text = "Aceptar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Olive;
            this.label7.Location = new System.Drawing.Point(580, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 239);
            this.label7.TabIndex = 199;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Olive;
            this.label6.Location = new System.Drawing.Point(2, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(581, 3);
            this.label6.TabIndex = 198;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Olive;
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 239);
            this.label5.TabIndex = 197;
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.Olive;
            this.Line.Location = new System.Drawing.Point(2, 3);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(581, 3);
            this.Line.TabIndex = 196;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 194;
            this.label4.Text = "Autorizado Por";
            // 
            // rbCambioMaterial
            // 
            this.rbCambioMaterial.AutoSize = true;
            this.rbCambioMaterial.Location = new System.Drawing.Point(13, 91);
            this.rbCambioMaterial.Name = "rbCambioMaterial";
            this.rbCambioMaterial.Size = new System.Drawing.Size(221, 19);
            this.rbCambioMaterial.TabIndex = 4;
            this.rbCambioMaterial.TabStop = true;
            this.rbCambioMaterial.Text = "CAMBIO DE MATERIAL SIN CARGO";
            this.rbCambioMaterial.UseVisualStyleBackColor = true;
            // 
            // rbBonificacionEspecial
            // 
            this.rbBonificacionEspecial.AutoSize = true;
            this.rbBonificacionEspecial.Location = new System.Drawing.Point(13, 65);
            this.rbBonificacionEspecial.Name = "rbBonificacionEspecial";
            this.rbBonificacionEspecial.Size = new System.Drawing.Size(168, 19);
            this.rbBonificacionEspecial.TabIndex = 3;
            this.rbBonificacionEspecial.TabStop = true;
            this.rbBonificacionEspecial.Text = "BONIFICACION ESPECIAL";
            this.rbBonificacionEspecial.UseVisualStyleBackColor = true;
            // 
            // rbReproceso
            // 
            this.rbReproceso.AutoSize = true;
            this.rbReproceso.Location = new System.Drawing.Point(13, 38);
            this.rbReproceso.Name = "rbReproceso";
            this.rbReproceso.Size = new System.Drawing.Size(169, 19);
            this.rbReproceso.TabIndex = 2;
            this.rbReproceso.TabStop = true;
            this.rbReproceso.Text = "REPROCESO SIN CARGO";
            this.rbReproceso.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.icons8_eliminar_32;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(473, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 40);
            this.btnExit.TabIndex = 200;
            this.btnExit.Text = "Cancelar";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.rbCambioMaterial);
            this.panel2.Controls.Add(this.rbBonificacionEspecial);
            this.panel2.Controls.Add(this.rbReproceso);
            this.panel2.Controls.Add(this.rbMuestraSinCargo);
            this.panel2.Location = new System.Drawing.Point(9, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 125);
            this.panel2.TabIndex = 195;
            // 
            // rbMuestraSinCargo
            // 
            this.rbMuestraSinCargo.AutoSize = true;
            this.rbMuestraSinCargo.Location = new System.Drawing.Point(13, 12);
            this.rbMuestraSinCargo.Name = "rbMuestraSinCargo";
            this.rbMuestraSinCargo.Size = new System.Drawing.Size(152, 19);
            this.rbMuestraSinCargo.TabIndex = 1;
            this.rbMuestraSinCargo.TabStop = true;
            this.rbMuestraSinCargo.Text = "MUESTRA SIN CARGO";
            this.rbMuestraSinCargo.UseVisualStyleBackColor = true;
            // 
            // txtItem
            // 
            this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItem.Location = new System.Drawing.Point(161, 49);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(53, 21);
            this.txtItem.TabIndex = 11;
            // 
            // txtSalesOrder
            // 
            this.txtSalesOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesOrder.Location = new System.Drawing.Point(87, 49);
            this.txtSalesOrder.Name = "txtSalesOrder";
            this.txtSalesOrder.Size = new System.Drawing.Size(75, 21);
            this.txtSalesOrder.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Orden #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Material S/C";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.txtItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSalesOrder);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 77);
            this.panel1.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(87, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(341, 21);
            this.txtCliente.TabIndex = 4;
            // 
            // txtMaterial
            // 
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.Location = new System.Drawing.Point(87, 27);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(127, 21);
            this.txtMaterial.TabIndex = 8;
            // 
            // cmbAutorizo
            // 
            this.cmbAutorizo.FormattingEnabled = true;
            this.cmbAutorizo.Location = new System.Drawing.Point(123, 218);
            this.cmbAutorizo.Name = "cmbAutorizo";
            this.cmbAutorizo.Size = new System.Drawing.Size(207, 23);
            this.cmbAutorizo.TabIndex = 192;
            this.cmbAutorizo.SelectedIndexChanged += new System.EventHandler(this.cmbAutorizo_SelectedIndexChanged);
            // 
            // FrmSD04MotivosSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 251);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbAutorizo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmSD04MotivosSc";
            this.Text = "SD04 - Seleccion de Motivo Entrega Sin Cargo";
            this.Load += new System.EventHandler(this.FrmSD04MotivosSC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource t0085PERSONALBindingSource;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Line;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbCambioMaterial;
        private System.Windows.Forms.RadioButton rbBonificacionEspecial;
        private System.Windows.Forms.RadioButton rbReproceso;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbMuestraSinCargo;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtSalesOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.ComboBox cmbAutorizo;
    }
}