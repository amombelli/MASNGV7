namespace MASngFE.Transactional.WM
{
    partial class FrmWm05UpdateLoteNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWm05UpdateLoteNumber));
            this.label5 = new System.Windows.Forms.Label();
            this.txtKgAMover = new System.Windows.Forms.TextBox();
            this.txtIdStock = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLogMovimiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroLoteOriginal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstadoOriginal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtSlocOriginal = new System.Windows.Forms.TextBox();
            this.txtSeleccionKg = new System.Windows.Forms.TextBox();
            this.txtDescripcionSlocOriginal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoteNuevo = new System.Windows.Forms.TextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdateLote = new System.Windows.Forms.Button();
            this.t0028SLOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // txtIdStock
            // 
            this.txtIdStock.Location = new System.Drawing.Point(429, 6);
            this.txtIdStock.Name = "txtIdStock";
            this.txtIdStock.ReadOnly = true;
            this.txtIdStock.Size = new System.Drawing.Size(67, 20);
            this.txtIdStock.TabIndex = 14;
            this.txtIdStock.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SlateGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(501, 19);
            this.label12.TabIndex = 93;
            this.label12.Text = "DATOS DE STOCK SELECCIONADO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLogMovimiento
            // 
            this.txtLogMovimiento.Location = new System.Drawing.Point(56, 220);
            this.txtLogMovimiento.Name = "txtLogMovimiento";
            this.txtLogMovimiento.ReadOnly = true;
            this.txtLogMovimiento.Size = new System.Drawing.Size(75, 20);
            this.txtLogMovimiento.TabIndex = 92;
            this.txtLogMovimiento.TabStop = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stock Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 94;
            this.label8.Text = "ID Log";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(2, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(683, 5);
            this.label10.TabIndex = 95;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Nuevo LOTE #";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtObservacion);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtLoteNuevo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnUpdateLote);
            this.panel2.Controls.Add(this.txtKgAMover);
            this.panel2.Location = new System.Drawing.Point(2, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 71);
            this.panel2.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "KG a Mover";
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
            this.panel1.Location = new System.Drawing.Point(2, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 119);
            this.panel1.TabIndex = 91;
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
            // txtLoteNuevo
            // 
            this.txtLoteNuevo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtLoteNuevo.Location = new System.Drawing.Point(117, 25);
            this.txtLoteNuevo.Name = "txtLoteNuevo";
            this.txtLoteNuevo.Size = new System.Drawing.Size(104, 20);
            this.txtLoteNuevo.TabIndex = 87;
            this.txtLoteNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLoteNuevo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLoteNuevo_Validating);
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Menu;
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(117, 47);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(383, 20);
            this.txtObservacion.TabIndex = 89;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 88;
            this.label11.Text = "Motivo Modificacion";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(563, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnUpdateLote
            // 
            this.btnUpdateLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLote.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateLote.Image")));
            this.btnUpdateLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateLote.Location = new System.Drawing.Point(560, 15);
            this.btnUpdateLote.Name = "btnUpdateLote";
            this.btnUpdateLote.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateLote.TabIndex = 2;
            this.btnUpdateLote.Text = "Modificar\r\nLOTE#";
            this.btnUpdateLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateLote.UseVisualStyleBackColor = true;
            this.btnUpdateLote.Click += new System.EventHandler(this.BtnUpdateLote_Click);
            // 
            // t0028SLOCBindingSource
            // 
            this.t0028SLOCBindingSource.DataSource = typeof(TecserEF.Entity.T0028_SLOC);
            // 
            // FrmWm05UpdateLoteNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 253);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLogMovimiento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWm05UpdateLoteNumber";
            this.Text = "WM05 - Modificar Numero de Lote";
            this.Load += new System.EventHandler(this.FrmWm05UpdateLoteNumber_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateLote;
        private System.Windows.Forms.BindingSource t0028SLOCBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKgAMover;
        private System.Windows.Forms.TextBox txtIdStock;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLogMovimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroLoteOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstadoOriginal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtSlocOriginal;
        private System.Windows.Forms.TextBox txtSeleccionKg;
        private System.Windows.Forms.TextBox txtDescripcionSlocOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoteNuevo;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label11;
    }
}