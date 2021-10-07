namespace MASngFE.FIX
{
    partial class FrmFixCae
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoOp = new System.Windows.Forms.TextBox();
            this.txtidCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporteNeto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEstadoDocumento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCAE = new System.Windows.Forms.TextBox();
            this.btnPedirCAE = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtResultadoAFIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCAEVencimiento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIdRemito = new System.Windows.Forms.TextBox();
            this.btnFixStatus = new System.Windows.Forms.Button();
            this.ckAFIP = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNas = new System.Windows.Forms.TextBox();
            this.btnImprimirDocumento = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(613, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 40);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(122, 9);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(80, 21);
            this.txtIdFactura.TabIndex = 1;
            this.txtIdFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdFactura_KeyPress);
            this.txtIdFactura.Leave += new System.EventHandler(this.txtIdFactura_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Documento";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(117, 113);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(132, 21);
            this.dtpFecha.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Aquamarine;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Factura";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razon Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRazonSocial.Location = new System.Drawing.Point(117, 6);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(318, 21);
            this.txtRazonSocial.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo Documento";
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTipoDoc.Location = new System.Drawing.Point(117, 28);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(39, 21);
            this.txtTipoDoc.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo Operacion";
            // 
            // txtTipoOp
            // 
            this.txtTipoOp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTipoOp.Location = new System.Drawing.Point(117, 50);
            this.txtTipoOp.Name = "txtTipoOp";
            this.txtTipoOp.ReadOnly = true;
            this.txtTipoOp.Size = new System.Drawing.Size(39, 21);
            this.txtTipoOp.TabIndex = 9;
            // 
            // txtidCliente
            // 
            this.txtidCliente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtidCliente.Location = new System.Drawing.Point(437, 6);
            this.txtidCliente.Name = "txtidCliente";
            this.txtidCliente.ReadOnly = true;
            this.txtidCliente.Size = new System.Drawing.Size(47, 21);
            this.txtidCliente.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtImporteNeto);
            this.panel1.Location = new System.Drawing.Point(15, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 40);
            this.panel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "IMPORTE NETO";
            // 
            // txtImporteNeto
            // 
            this.txtImporteNeto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtImporteNeto.Location = new System.Drawing.Point(119, 8);
            this.txtImporteNeto.Name = "txtImporteNeto";
            this.txtImporteNeto.ReadOnly = true;
            this.txtImporteNeto.Size = new System.Drawing.Size(77, 21);
            this.txtImporteNeto.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado Doc";
            // 
            // txtEstadoDocumento
            // 
            this.txtEstadoDocumento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtEstadoDocumento.Location = new System.Drawing.Point(117, 72);
            this.txtEstadoDocumento.Name = "txtEstadoDocumento";
            this.txtEstadoDocumento.ReadOnly = true;
            this.txtEstadoDocumento.Size = new System.Drawing.Size(115, 21);
            this.txtEstadoDocumento.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "NUMERO CAE";
            // 
            // txtCAE
            // 
            this.txtCAE.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCAE.Location = new System.Drawing.Point(141, 33);
            this.txtCAE.Name = "txtCAE";
            this.txtCAE.ReadOnly = true;
            this.txtCAE.Size = new System.Drawing.Size(126, 21);
            this.txtCAE.TabIndex = 15;
            // 
            // btnPedirCAE
            // 
            this.btnPedirCAE.Location = new System.Drawing.Point(612, 92);
            this.btnPedirCAE.Name = "btnPedirCAE";
            this.btnPedirCAE.Size = new System.Drawing.Size(87, 40);
            this.btnPedirCAE.TabIndex = 17;
            this.btnPedirCAE.Text = "Obtener\r\nCAE";
            this.btnPedirCAE.UseVisualStyleBackColor = true;
            this.btnPedirCAE.Click += new System.EventHandler(this.btnPedirCAE_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.txtResultadoAFIP);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtNumeroDocumento);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtCAEVencimiento);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCAE);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(15, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 112);
            this.panel2.TabIndex = 15;
            // 
            // txtResultadoAFIP
            // 
            this.txtResultadoAFIP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtResultadoAFIP.Location = new System.Drawing.Point(141, 10);
            this.txtResultadoAFIP.Name = "txtResultadoAFIP";
            this.txtResultadoAFIP.ReadOnly = true;
            this.txtResultadoAFIP.Size = new System.Drawing.Size(26, 21);
            this.txtResultadoAFIP.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "RESULTADO AFIP";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(141, 79);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(126, 21);
            this.txtNumeroDocumento.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "NUMERO DOC";
            // 
            // txtCAEVencimiento
            // 
            this.txtCAEVencimiento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCAEVencimiento.Location = new System.Drawing.Point(141, 56);
            this.txtCAEVencimiento.Name = "txtCAEVencimiento";
            this.txtCAEVencimiento.ReadOnly = true;
            this.txtCAEVencimiento.Size = new System.Drawing.Size(126, 21);
            this.txtCAEVencimiento.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "VENCIMIENTO CAE";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtpFecha);
            this.panel3.Controls.Add(this.txtRazonSocial);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtEstadoDocumento);
            this.panel3.Controls.Add(this.txtidCliente);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtTipoDoc);
            this.panel3.Controls.Add(this.txtTipoOp);
            this.panel3.Location = new System.Drawing.Point(15, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 140);
            this.panel3.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Aquamarine;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(15, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 21);
            this.label12.TabIndex = 19;
            this.label12.Text = "ID Remito";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdRemito
            // 
            this.txtIdRemito.Location = new System.Drawing.Point(122, 31);
            this.txtIdRemito.Name = "txtIdRemito";
            this.txtIdRemito.Size = new System.Drawing.Size(80, 21);
            this.txtIdRemito.TabIndex = 18;
            this.txtIdRemito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdRemito_KeyPress);
            this.txtIdRemito.Leave += new System.EventHandler(this.txtIdRemito_Leave);
            // 
            // btnFixStatus
            // 
            this.btnFixStatus.Location = new System.Drawing.Point(613, 52);
            this.btnFixStatus.Name = "btnFixStatus";
            this.btnFixStatus.Size = new System.Drawing.Size(87, 40);
            this.btnFixStatus.TabIndex = 20;
            this.btnFixStatus.Text = "FIX Estado";
            this.btnFixStatus.UseVisualStyleBackColor = true;
            this.btnFixStatus.Click += new System.EventHandler(this.btnFixStatus_Click);
            // 
            // ckAFIP
            // 
            this.ckAFIP.AutoSize = true;
            this.ckAFIP.Location = new System.Drawing.Point(21, 382);
            this.ckAFIP.Name = "ckAFIP";
            this.ckAFIP.Size = new System.Drawing.Size(177, 19);
            this.ckAFIP.TabIndex = 21;
            this.ckAFIP.Text = "AFIP - MODO PRUEBA CAE";
            this.ckAFIP.UseVisualStyleBackColor = true;
            this.ckAFIP.CheckedChanged += new System.EventHandler(this.ckAFIP_CheckedChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Aquamarine;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(318, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 21);
            this.label13.TabIndex = 23;
            this.label13.Text = "Asiento #";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNas
            // 
            this.txtNas.Location = new System.Drawing.Point(425, 9);
            this.txtNas.Name = "txtNas";
            this.txtNas.Size = new System.Drawing.Size(80, 21);
            this.txtNas.TabIndex = 22;
            // 
            // btnImprimirDocumento
            // 
            this.btnImprimirDocumento.Location = new System.Drawing.Point(613, 191);
            this.btnImprimirDocumento.Name = "btnImprimirDocumento";
            this.btnImprimirDocumento.Size = new System.Drawing.Size(87, 40);
            this.btnImprimirDocumento.TabIndex = 24;
            this.btnImprimirDocumento.Text = "Imprimir";
            this.btnImprimirDocumento.UseVisualStyleBackColor = true;
            this.btnImprimirDocumento.Click += new System.EventHandler(this.btnImprimirDocumento_Click);
            // 
            // FrmFixCae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 409);
            this.Controls.Add(this.btnImprimirDocumento);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNas);
            this.Controls.Add(this.ckAFIP);
            this.Controls.Add(this.btnFixStatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtIdRemito);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPedirCAE);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdFactura);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFixCae";
            this.Text = "FrmFixCae";
            this.Load += new System.EventHandler(this.FrmFixCae_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtIdFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipoOp;
        private System.Windows.Forms.TextBox txtidCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporteNeto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEstadoDocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCAE;
        private System.Windows.Forms.Button btnPedirCAE;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCAEVencimiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtResultadoAFIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIdRemito;
        private System.Windows.Forms.Button btnFixStatus;
        private System.Windows.Forms.CheckBox ckAFIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNas;
        private System.Windows.Forms.Button btnImprimirDocumento;
    }
}