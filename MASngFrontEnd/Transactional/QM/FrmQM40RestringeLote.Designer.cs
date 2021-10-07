﻿namespace MASngFE.Transactional.QM
{
    partial class FrmQM40RestringeLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQM40RestringeLote));
            this.btnModificarEstado = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroLoteOriginal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstadoOriginal = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtSlocOriginal = new System.Windows.Forms.TextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtKgAMover = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSeleccionKg = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescripcionSlocOriginal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarEstado
            // 
            this.btnModificarEstado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarEstado.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarEstado.Image")));
            this.btnModificarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarEstado.Location = new System.Drawing.Point(514, 46);
            this.btnModificarEstado.Name = "btnModificarEstado";
            this.btnModificarEstado.Size = new System.Drawing.Size(100, 40);
            this.btnModificarEstado.TabIndex = 99;
            this.btnModificarEstado.Text = "Modificar\r\nEstado";
            this.btnModificarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarEstado.UseVisualStyleBackColor = true;
            this.btnModificarEstado.Click += new System.EventHandler(this.BtnModificarEstado_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 88;
            this.label11.Text = "Motivo Modificacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "IdStock";
            // 
            // txtIdStock
            // 
            this.txtIdStock.Location = new System.Drawing.Point(429, 6);
            this.txtIdStock.Name = "txtIdStock";
            this.txtIdStock.ReadOnly = true;
            this.txtIdStock.Size = new System.Drawing.Size(67, 20);
            this.txtIdStock.TabIndex = 14;
            this.txtIdStock.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "KG Seleccion";
            // 
            // txtPlanta
            // 
            this.txtPlanta.Location = new System.Drawing.Point(117, 48);
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.ReadOnly = true;
            this.txtPlanta.Size = new System.Drawing.Size(37, 20);
            this.txtPlanta.TabIndex = 12;
            this.txtPlanta.TabStop = false;
            this.txtPlanta.Text = "CERR";
            this.txtPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lote Seleccionado";
            // 
            // txtNumeroLoteOriginal
            // 
            this.txtNumeroLoteOriginal.Location = new System.Drawing.Point(117, 69);
            this.txtNumeroLoteOriginal.Name = "txtNumeroLoteOriginal";
            this.txtNumeroLoteOriginal.ReadOnly = true;
            this.txtNumeroLoteOriginal.Size = new System.Drawing.Size(104, 20);
            this.txtNumeroLoteOriginal.TabIndex = 10;
            this.txtNumeroLoteOriginal.TabStop = false;
            this.txtNumeroLoteOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "KG a Restringir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stock Status";
            // 
            // txtEstadoOriginal
            // 
            this.txtEstadoOriginal.Location = new System.Drawing.Point(117, 90);
            this.txtEstadoOriginal.Name = "txtEstadoOriginal";
            this.txtEstadoOriginal.ReadOnly = true;
            this.txtEstadoOriginal.Size = new System.Drawing.Size(104, 20);
            this.txtEstadoOriginal.TabIndex = 8;
            this.txtEstadoOriginal.TabStop = false;
            this.txtEstadoOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(117, 6);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(104, 20);
            this.txtMaterial.TabIndex = 0;
            this.txtMaterial.TabStop = false;
            // 
            // txtSlocOriginal
            // 
            this.txtSlocOriginal.Location = new System.Drawing.Point(155, 48);
            this.txtSlocOriginal.Name = "txtSlocOriginal";
            this.txtSlocOriginal.ReadOnly = true;
            this.txtSlocOriginal.Size = new System.Drawing.Size(66, 20);
            this.txtSlocOriginal.TabIndex = 3;
            this.txtSlocOriginal.TabStop = false;
            this.txtSlocOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Menu;
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(117, 25);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(372, 20);
            this.txtObservacion.TabIndex = 89;
            // 
            // txtKgAMover
            // 
            this.txtKgAMover.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtKgAMover.Location = new System.Drawing.Point(117, 3);
            this.txtKgAMover.Name = "txtKgAMover";
            this.txtKgAMover.Size = new System.Drawing.Size(61, 20);
            this.txtKgAMover.TabIndex = 0;
            this.txtKgAMover.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgAMover.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKgAMover_KeyPress);
            this.txtKgAMover.Validating += new System.ComponentModel.CancelEventHandler(this.TxtKgAMover_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(2, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(620, 5);
            this.label10.TabIndex = 105;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSeleccionKg
            // 
            this.txtSeleccionKg.Location = new System.Drawing.Point(117, 27);
            this.txtSeleccionKg.Name = "txtSeleccionKg";
            this.txtSeleccionKg.ReadOnly = true;
            this.txtSeleccionKg.Size = new System.Drawing.Size(61, 20);
            this.txtSeleccionKg.TabIndex = 6;
            this.txtSeleccionKg.TabStop = false;
            this.txtSeleccionKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtObservacion);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtKgAMover);
            this.panel2.Location = new System.Drawing.Point(2, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 51);
            this.panel2.TabIndex = 103;
            // 
            // txtDescripcionSlocOriginal
            // 
            this.txtDescripcionSlocOriginal.Location = new System.Drawing.Point(222, 48);
            this.txtDescripcionSlocOriginal.Name = "txtDescripcionSlocOriginal";
            this.txtDescripcionSlocOriginal.ReadOnly = true;
            this.txtDescripcionSlocOriginal.Size = new System.Drawing.Size(274, 20);
            this.txtDescripcionSlocOriginal.TabIndex = 5;
            this.txtDescripcionSlocOriginal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ubicacion Actual";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(514, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 100;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtIdStock);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPlanta);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNumeroLoteOriginal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEstadoOriginal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Controls.Add(this.txtSlocOriginal);
            this.panel1.Controls.Add(this.txtSeleccionKg);
            this.panel1.Controls.Add(this.txtDescripcionSlocOriginal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 119);
            this.panel1.TabIndex = 101;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SlateGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(501, 19);
            this.label12.TabIndex = 102;
            this.label12.Text = "DATOS DE STOCK SELECCIONADO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmQM40RestringeLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 202);
            this.ControlBox = false;
            this.Controls.Add(this.btnModificarEstado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Name = "FrmQM40RestringeLote";
            this.Text = "QM40 - Restringe Lote";
            this.Load += new System.EventHandler(this.FrmQM40RestringeLote_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificarEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroLoteOriginal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstadoOriginal;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtSlocOriginal;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtKgAMover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSeleccionKg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDescripcionSlocOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
    }
}