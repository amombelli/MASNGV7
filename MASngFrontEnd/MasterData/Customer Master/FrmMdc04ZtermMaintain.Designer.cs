namespace MASngFE.MasterData.Customer_Master
{
    partial class FrmMdc04ZtermMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdc04ZtermMaintain));
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbEditDatosCliente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbZtermL2 = new System.Windows.Forms.ComboBox();
            this.zTermL2Bs = new System.Windows.Forms.BindingSource(this.components);
            this.txtZtermL2 = new System.Windows.Forms.TextBox();
            this.cmbZtermL1 = new System.Windows.Forms.ComboBox();
            this.zTermL1Bs = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZtermL1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTermL2Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTermL1Bs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(432, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 40);
            this.btnClose.TabIndex = 151;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbEditDatosCliente
            // 
            this.cmbEditDatosCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEditDatosCliente.Image = ((System.Drawing.Image)(resources.GetObject("cmbEditDatosCliente.Image")));
            this.cmbEditDatosCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbEditDatosCliente.Location = new System.Drawing.Point(432, 43);
            this.cmbEditDatosCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEditDatosCliente.Name = "cmbEditDatosCliente";
            this.cmbEditDatosCliente.Size = new System.Drawing.Size(107, 40);
            this.cmbEditDatosCliente.TabIndex = 153;
            this.cmbEditDatosCliente.Text = "Modificar\r\nDatos";
            this.cmbEditDatosCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmbEditDatosCliente.UseVisualStyleBackColor = true;
            this.cmbEditDatosCliente.Click += new System.EventHandler(this.cmbEditDatosCliente_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.txtFantasia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 56);
            this.panel1.TabIndex = 154;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRazonSocial.Location = new System.Drawing.Point(89, 5);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(275, 22);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.TabStop = false;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFantasia.Location = new System.Drawing.Point(89, 29);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(275, 22);
            this.txtFantasia.TabIndex = 19;
            this.txtFantasia.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 32);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbZtermL2);
            this.panel2.Controls.Add(this.txtZtermL2);
            this.panel2.Controls.Add(this.cmbZtermL1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtZtermL1);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 58);
            this.panel2.TabIndex = 155;
            // 
            // cmbZtermL2
            // 
            this.cmbZtermL2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZtermL2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZtermL2.DataSource = this.zTermL2Bs;
            this.cmbZtermL2.DisplayMember = "ZTERMDESC";
            this.cmbZtermL2.FormattingEnabled = true;
            this.cmbZtermL2.Location = new System.Drawing.Point(89, 29);
            this.cmbZtermL2.Name = "cmbZtermL2";
            this.cmbZtermL2.Size = new System.Drawing.Size(275, 22);
            this.cmbZtermL2.TabIndex = 10;
            this.cmbZtermL2.ValueMember = "ZTERM";
            this.cmbZtermL2.SelectedIndexChanged += new System.EventHandler(this.cmbZtermL2_SelectedIndexChanged);
            // 
            // zTermL2Bs
            // 
            this.zTermL2Bs.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // txtZtermL2
            // 
            this.txtZtermL2.BackColor = System.Drawing.Color.Gainsboro;
            this.txtZtermL2.Location = new System.Drawing.Point(366, 29);
            this.txtZtermL2.Name = "txtZtermL2";
            this.txtZtermL2.ReadOnly = true;
            this.txtZtermL2.Size = new System.Drawing.Size(55, 22);
            this.txtZtermL2.TabIndex = 9;
            this.txtZtermL2.TabStop = false;
            // 
            // cmbZtermL1
            // 
            this.cmbZtermL1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZtermL1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZtermL1.DataSource = this.zTermL1Bs;
            this.cmbZtermL1.DisplayMember = "ZTERMDESC";
            this.cmbZtermL1.FormattingEnabled = true;
            this.cmbZtermL1.Location = new System.Drawing.Point(89, 5);
            this.cmbZtermL1.Name = "cmbZtermL1";
            this.cmbZtermL1.Size = new System.Drawing.Size(275, 22);
            this.cmbZtermL1.TabIndex = 8;
            this.cmbZtermL1.ValueMember = "ZTERM";
            this.cmbZtermL1.SelectedIndexChanged += new System.EventHandler(this.cmbZtermL1_SelectedIndexChanged);
            // 
            // zTermL1Bs
            // 
            this.zTermL1Bs.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "ZTerm L1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "ZTerm L2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtZtermL1
            // 
            this.txtZtermL1.BackColor = System.Drawing.Color.Gainsboro;
            this.txtZtermL1.Location = new System.Drawing.Point(366, 5);
            this.txtZtermL1.Name = "txtZtermL1";
            this.txtZtermL1.ReadOnly = true;
            this.txtZtermL1.Size = new System.Drawing.Size(55, 22);
            this.txtZtermL1.TabIndex = 3;
            this.txtZtermL1.TabStop = false;
            // 
            // FrmMdc04ZtermMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 122);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbEditDatosCliente);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMdc04ZtermMaintain";
            this.Text = "MDC04 - Mantenimiento de Terminos de Pago [ZTERM] en Clientes";
            this.Load += new System.EventHandler(this.FrmMdc04ZtermMaintain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTermL2Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTermL1Bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button cmbEditDatosCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZtermL1;
        private System.Windows.Forms.ComboBox cmbZtermL2;
        private System.Windows.Forms.TextBox txtZtermL2;
        private System.Windows.Forms.ComboBox cmbZtermL1;
        private System.Windows.Forms.BindingSource zTermL2Bs;
        private System.Windows.Forms.BindingSource zTermL1Bs;
    }
}