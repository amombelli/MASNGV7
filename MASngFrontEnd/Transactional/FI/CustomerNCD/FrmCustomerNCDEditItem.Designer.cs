namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmCustomerNcdEditItem
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
            this.txtIdItem = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtDescripcionItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckIVA = new System.Windows.Forms.CheckBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrecioIva = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtGLDescription = new System.Windows.Forms.TextBox();
            this.txtGL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdCheque = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdItem
            // 
            this.txtIdItem.BackColor = System.Drawing.Color.LightGray;
            this.txtIdItem.Location = new System.Drawing.Point(92, 3);
            this.txtIdItem.Name = "txtIdItem";
            this.txtIdItem.ReadOnly = true;
            this.txtIdItem.Size = new System.Drawing.Size(30, 21);
            this.txtIdItem.TabIndex = 1;
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.Color.LightGray;
            this.txtItem.Location = new System.Drawing.Point(92, 25);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(116, 21);
            this.txtItem.TabIndex = 3;
            // 
            // txtDescripcionItem
            // 
            this.txtDescripcionItem.Location = new System.Drawing.Point(92, 47);
            this.txtDescripcionItem.Name = "txtDescripcionItem";
            this.txtDescripcionItem.Size = new System.Drawing.Size(433, 21);
            this.txtDescripcionItem.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Pink;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripcion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckIVA
            // 
            this.ckIVA.AutoSize = true;
            this.ckIVA.Location = new System.Drawing.Point(108, 7);
            this.ckIVA.Name = "ckIVA";
            this.ckIVA.Size = new System.Drawing.Size(71, 19);
            this.ckIVA.TabIndex = 6;
            this.ckIVA.Text = "IVA 21%";
            this.ckIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckIVA.UseVisualStyleBackColor = true;
            this.ckIVA.CheckedChanged += new System.EventHandler(this.ckIVA_CheckedChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(106, 28);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(64, 21);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Pink;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(106, 50);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(87, 21);
            this.txtPrecioUnitario.TabIndex = 10;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtPrecioUnitario.Leave += new System.EventHandler(this.txtPrecioUnitario_Leave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Pink;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Precio Unit";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.BackColor = System.Drawing.Color.LightGray;
            this.txtPrecioTotal.Location = new System.Drawing.Point(106, 72);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(87, 21);
            this.txtPrecioTotal.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Precio Total";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPrecioIva);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPrecioTotal);
            this.panel1.Controls.Add(this.ckIVA);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.txtPrecioUnitario);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(4, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 122);
            this.panel1.TabIndex = 13;
            // 
            // txtPrecioIva
            // 
            this.txtPrecioIva.BackColor = System.Drawing.Color.LightGray;
            this.txtPrecioIva.Location = new System.Drawing.Point(106, 94);
            this.txtPrecioIva.Name = "txtPrecioIva";
            this.txtPrecioIva.Size = new System.Drawing.Size(87, 21);
            this.txtPrecioIva.TabIndex = 14;
            this.txtPrecioIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtPrecioIva.Leave += new System.EventHandler(this.txtPrecioIva_Leave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Importe IVA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtIdItem);
            this.panel2.Controls.Add(this.txtDescripcionItem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtItem);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 90);
            this.panel2.TabIndex = 14;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 8);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 37);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 43);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 37);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtGLDescription
            // 
            this.txtGLDescription.BackColor = System.Drawing.Color.LightGray;
            this.txtGLDescription.Location = new System.Drawing.Point(171, 9);
            this.txtGLDescription.Name = "txtGLDescription";
            this.txtGLDescription.ReadOnly = true;
            this.txtGLDescription.Size = new System.Drawing.Size(238, 21);
            this.txtGLDescription.TabIndex = 3;
            // 
            // txtGL
            // 
            this.txtGL.Location = new System.Drawing.Point(96, 9);
            this.txtGL.Name = "txtGL";
            this.txtGL.ReadOnly = true;
            this.txtGL.Size = new System.Drawing.Size(74, 21);
            this.txtGL.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "GL";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.GhostWhite;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtGL);
            this.panel3.Controls.Add(this.txtGLDescription);
            this.panel3.Location = new System.Drawing.Point(4, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(414, 40);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtIdCheque);
            this.panel4.Location = new System.Drawing.Point(4, 261);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(414, 37);
            this.panel4.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "IDCHEQUE";
            // 
            // txtIdCheque
            // 
            this.txtIdCheque.BackColor = System.Drawing.Color.LightGray;
            this.txtIdCheque.Location = new System.Drawing.Point(96, 9);
            this.txtIdCheque.Name = "txtIdCheque";
            this.txtIdCheque.ReadOnly = true;
            this.txtIdCheque.Size = new System.Drawing.Size(74, 21);
            this.txtIdCheque.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.btnAceptar);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Location = new System.Drawing.Point(547, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 90);
            this.panel5.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cod.Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item #";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmCustomerNcdEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(681, 301);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCustomerNcdEditItem";
            this.Text = "EDICION DE ITEM [NCD] CLIENTES";
            this.Load += new System.EventHandler(this.FrmCustomerNcdEditItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtIdItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtDescripcionItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckIVA;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrecioIva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtGLDescription;
        private System.Windows.Forms.TextBox txtGL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdCheque;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}