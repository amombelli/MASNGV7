namespace MASngFE.MasterData.Customer_Master
{
    partial class FrmMdc05CreditLimitMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdc05CreditLimitMaintain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.uLimiteCredito = new MASngFE._UserControls.UCurrencyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtZtermL2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZtermL1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckAutoCredit = new System.Windows.Forms.CheckBox();
            this.ctlDaysCreditLimit = new TSControls.CtlTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEditDatosCliente = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uLimiteCredito);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(2, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 58);
            this.panel2.TabIndex = 159;
            // 
            // uLimiteCredito
            // 
            this.uLimiteCredito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uLimiteCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uLimiteCredito.Location = new System.Drawing.Point(12, 28);
            this.uLimiteCredito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uLimiteCredito.Name = "uLimiteCredito";
            this.uLimiteCredito.ReadOnly = false;
            this.uLimiteCredito.Size = new System.Drawing.Size(110, 21);
            this.uLimiteCredito.TabIndex = 8;
            this.uLimiteCredito.ValueD = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uLimiteCredito.Validated += new System.EventHandler(this.uLimiteCredito_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Limite de Credito Manual (Max)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtZtermL2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtZtermL1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.txtFantasia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 105);
            this.panel1.TabIndex = 158;
            // 
            // txtZtermL2
            // 
            this.txtZtermL2.BackColor = System.Drawing.Color.Gainsboro;
            this.txtZtermL2.Location = new System.Drawing.Point(116, 77);
            this.txtZtermL2.Name = "txtZtermL2";
            this.txtZtermL2.ReadOnly = true;
            this.txtZtermL2.Size = new System.Drawing.Size(71, 22);
            this.txtZtermL2.TabIndex = 24;
            this.txtZtermL2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "Condicion L2";
            // 
            // txtZtermL1
            // 
            this.txtZtermL1.BackColor = System.Drawing.Color.Gainsboro;
            this.txtZtermL1.Location = new System.Drawing.Point(116, 53);
            this.txtZtermL1.Name = "txtZtermL1";
            this.txtZtermL1.ReadOnly = true;
            this.txtZtermL1.Size = new System.Drawing.Size(71, 22);
            this.txtZtermL1.TabIndex = 22;
            this.txtZtermL1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Condicion L1";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRazonSocial.Location = new System.Drawing.Point(116, 5);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(248, 22);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.TabStop = false;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFantasia.Location = new System.Drawing.Point(116, 29);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(248, 22);
            this.txtFantasia.TabIndex = 19;
            this.txtFantasia.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fantasia";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdCliente.Location = new System.Drawing.Point(366, 5);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(55, 22);
            this.txtIdCliente.TabIndex = 3;
            this.txtIdCliente.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ckAutoCredit);
            this.panel3.Controls.Add(this.ctlDaysCreditLimit);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(2, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 51);
            this.panel3.TabIndex = 160;
            // 
            // ckAutoCredit
            // 
            this.ckAutoCredit.AutoSize = true;
            this.ckAutoCredit.Location = new System.Drawing.Point(9, 3);
            this.ckAutoCredit.Name = "ckAutoCredit";
            this.ckAutoCredit.Size = new System.Drawing.Size(183, 18);
            this.ckAutoCredit.TabIndex = 6;
            this.ckAutoCredit.Text = "Limite de Credito Automatico";
            this.ckAutoCredit.UseVisualStyleBackColor = true;
            this.ckAutoCredit.CheckedChanged += new System.EventHandler(this.ckAutoCredit_CheckedChanged);
            // 
            // ctlDaysCreditLimit
            // 
            this.ctlDaysCreditLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlDaysCreditLimit.BackColor = System.Drawing.Color.Wheat;
            this.ctlDaysCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDaysCreditLimit.Location = new System.Drawing.Point(116, 23);
            this.ctlDaysCreditLimit.Margin = new System.Windows.Forms.Padding(0);
            this.ctlDaysCreditLimit.Name = "ctlDaysCreditLimit";
            this.ctlDaysCreditLimit.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlDaysCreditLimit.SetDecimales = 0;
            this.ctlDaysCreditLimit.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.ctlDaysCreditLimit.Size = new System.Drawing.Size(51, 20);
            this.ctlDaysCreditLimit.TabIndex = 5;
             this.ctlDaysCreditLimit.ValorMaximo = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.ctlDaysCreditLimit.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlDaysCreditLimit.XReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dias de Credito";
            // 
            // cmbEditDatosCliente
            // 
            this.cmbEditDatosCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEditDatosCliente.Image = ((System.Drawing.Image)(resources.GetObject("cmbEditDatosCliente.Image")));
            this.cmbEditDatosCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbEditDatosCliente.Location = new System.Drawing.Point(434, 48);
            this.cmbEditDatosCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEditDatosCliente.Name = "cmbEditDatosCliente";
            this.cmbEditDatosCliente.Size = new System.Drawing.Size(107, 40);
            this.cmbEditDatosCliente.TabIndex = 157;
            this.cmbEditDatosCliente.Text = "Modificar\r\nDatos";
            this.cmbEditDatosCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmbEditDatosCliente.UseVisualStyleBackColor = true;
            this.cmbEditDatosCliente.Click += new System.EventHandler(this.cmbEditDatosCliente_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(434, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 40);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmMdc05CreditLimitMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 362);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbEditDatosCliente);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMdc05CreditLimitMaintain";
            this.Text = "MDC05 - Administracion de Limite de Credito";
            this.Load += new System.EventHandler(this.FrmMdc05CreditLimitMaintain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Button cmbEditDatosCliente;
        private System.Windows.Forms.Button btnClose;
        private _UserControls.UCurrencyTextBox uLimiteCredito;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckAutoCredit;
        private TSControls.CtlTextBox ctlDaysCreditLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZtermL2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtZtermL1;
        private System.Windows.Forms.Label label6;
    }
}