namespace MASngFE.Transactional.SD.Remito
{
    partial class FrmSD08ConfirmaPreparacionRemito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD08ConfirmaPreparacionRemito));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboResponsablePrep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadBultos = new System.Windows.Forms.TextBox();
            this.txtComentarioPreparacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdRemito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClienteDescripcion = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.BtnCancelarP = new System.Windows.Forms.Button();
            this.BtnConfirmarP = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(669, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 153);
            this.label7.TabIndex = 194;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(5, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(665, 3);
            this.label6.TabIndex = 193;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboResponsablePrep);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCantidadBultos);
            this.panel1.Controls.Add(this.txtComentarioPreparacion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 79);
            this.panel1.TabIndex = 190;
            // 
            // cboResponsablePrep
            // 
            this.cboResponsablePrep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboResponsablePrep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboResponsablePrep.BackColor = System.Drawing.SystemColors.Info;
            this.cboResponsablePrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResponsablePrep.FormattingEnabled = true;
            this.cboResponsablePrep.Location = new System.Drawing.Point(180, 4);
            this.cboResponsablePrep.Margin = new System.Windows.Forms.Padding(2);
            this.cboResponsablePrep.Name = "cboResponsablePrep";
            this.cboResponsablePrep.Size = new System.Drawing.Size(175, 23);
            this.cboResponsablePrep.TabIndex = 4;
            this.cboResponsablePrep.Validating += new System.ComponentModel.CancelEventHandler(this.cboResponsablePrep_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Responsable Preparacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad Bultos (Bolsas)";
            // 
            // txtCantidadBultos
            // 
            this.txtCantidadBultos.BackColor = System.Drawing.SystemColors.Info;
            this.txtCantidadBultos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadBultos.Location = new System.Drawing.Point(180, 28);
            this.txtCantidadBultos.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadBultos.Name = "txtCantidadBultos";
            this.txtCantidadBultos.Size = new System.Drawing.Size(46, 21);
            this.txtCantidadBultos.TabIndex = 8;
            this.txtCantidadBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadBultos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadBultos_KeyPress);
            // 
            // txtComentarioPreparacion
            // 
            this.txtComentarioPreparacion.BackColor = System.Drawing.SystemColors.Info;
            this.txtComentarioPreparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarioPreparacion.Location = new System.Drawing.Point(180, 50);
            this.txtComentarioPreparacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentarioPreparacion.Name = "txtComentarioPreparacion";
            this.txtComentarioPreparacion.Size = new System.Drawing.Size(351, 21);
            this.txtComentarioPreparacion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Observacions en Preparacion";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtIdRemito);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtClienteDescripcion);
            this.panel3.Location = new System.Drawing.Point(12, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 53);
            this.panel3.TabIndex = 189;
            // 
            // txtIdRemito
            // 
            this.txtIdRemito.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdRemito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdRemito.Location = new System.Drawing.Point(177, 4);
            this.txtIdRemito.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdRemito.Name = "txtIdRemito";
            this.txtIdRemito.ReadOnly = true;
            this.txtIdRemito.Size = new System.Drawing.Size(93, 21);
            this.txtIdRemito.TabIndex = 1;
            this.txtIdRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cliente [Descripcion Entrega]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Identificacion de Remito #";
            // 
            // txtClienteDescripcion
            // 
            this.txtClienteDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteDescripcion.Location = new System.Drawing.Point(177, 26);
            this.txtClienteDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteDescripcion.Name = "txtClienteDescripcion";
            this.txtClienteDescripcion.ReadOnly = true;
            this.txtClienteDescripcion.Size = new System.Drawing.Size(354, 21);
            this.txtClienteDescripcion.TabIndex = 11;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.MediumBlue;
            this.label55.Location = new System.Drawing.Point(5, 5);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(3, 153);
            this.label55.TabIndex = 188;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.MediumBlue;
            this.label22.Location = new System.Drawing.Point(7, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(665, 3);
            this.label22.TabIndex = 187;
            // 
            // BtnCancelarP
            // 
            this.BtnCancelarP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelarP.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelarP.Image")));
            this.BtnCancelarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelarP.Location = new System.Drawing.Point(554, 54);
            this.BtnCancelarP.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelarP.Name = "BtnCancelarP";
            this.BtnCancelarP.Size = new System.Drawing.Size(107, 42);
            this.BtnCancelarP.TabIndex = 192;
            this.BtnCancelarP.Text = "Cancelar";
            this.BtnCancelarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelarP.UseVisualStyleBackColor = true;
            this.BtnCancelarP.Click += new System.EventHandler(this.BtnCancelarP_Click);
            // 
            // BtnConfirmarP
            // 
            this.BtnConfirmarP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmarP.Image = ((System.Drawing.Image)(resources.GetObject("BtnConfirmarP.Image")));
            this.BtnConfirmarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirmarP.Location = new System.Drawing.Point(554, 12);
            this.BtnConfirmarP.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConfirmarP.Name = "BtnConfirmarP";
            this.BtnConfirmarP.Size = new System.Drawing.Size(107, 42);
            this.BtnConfirmarP.TabIndex = 191;
            this.BtnConfirmarP.Text = "Confirmar";
            this.BtnConfirmarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConfirmarP.UseVisualStyleBackColor = true;
            this.BtnConfirmarP.Click += new System.EventHandler(this.BtnConfirmarP_Click);
            // 
            // FrmSD08ConfirmaPreparacionRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 163);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancelarP);
            this.Controls.Add(this.BtnConfirmarP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label22);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSD08ConfirmaPreparacionRemito";
            this.Text = "SD08 - Confirma Preparacion Remito";
            this.Load += new System.EventHandler(this.FrmSD08ConfirmaPreparacionRemito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCancelarP;
        private System.Windows.Forms.Button BtnConfirmarP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboResponsablePrep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadBultos;
        private System.Windows.Forms.TextBox txtComentarioPreparacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtIdRemito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClienteDescripcion;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label22;
    }
}