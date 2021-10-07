namespace MASngFE.SuperMD
{
    partial class FrmMdz01ZtermStructure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdz01ZtermStructure));
            this.cmbZterm = new System.Windows.Forms.ComboBox();
            this.t0019ZTERMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtDiasCobranza = new System.Windows.Forms.TextBox();
            this.txtDiasValores = new System.Windows.Forms.TextBox();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtZtermId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiasTotalesPagoDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdateSave = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t0019ZTERMBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbZterm
            // 
            this.cmbZterm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbZterm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZterm.BackColor = System.Drawing.Color.White;
            this.cmbZterm.DataSource = this.t0019ZTERMBindingSource;
            this.cmbZterm.DisplayMember = "ZTERM";
            this.cmbZterm.DropDownHeight = 50;
            this.cmbZterm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZterm.FormattingEnabled = true;
            this.cmbZterm.IntegralHeight = false;
            this.cmbZterm.Location = new System.Drawing.Point(111, 8);
            this.cmbZterm.Name = "cmbZterm";
            this.cmbZterm.Size = new System.Drawing.Size(109, 21);
            this.cmbZterm.TabIndex = 1;
            this.cmbZterm.ValueMember = "ZTERM";
            this.cmbZterm.SelectedIndexChanged += new System.EventHandler(this.cmbZterm_SelectedIndexChanged);
            // 
            // t0019ZTERMBindingSource
            // 
            this.t0019ZTERMBindingSource.DataSource = typeof(TecserEF.Entity.T0019_ZTERM);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Termino de Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(32, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dias Promedio Valores";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(111, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(283, 20);
            this.txtDescripcion.TabIndex = 21;
            // 
            // txtDiasCobranza
            // 
            this.txtDiasCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasCobranza.Location = new System.Drawing.Point(172, 6);
            this.txtDiasCobranza.Name = "txtDiasCobranza";
            this.txtDiasCobranza.Size = new System.Drawing.Size(47, 20);
            this.txtDiasCobranza.TabIndex = 22;
            this.txtDiasCobranza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasCobranza_KeyPress);
            this.txtDiasCobranza.Validated += new System.EventHandler(this.txtDiasCobranza_Validated);
            // 
            // txtDiasValores
            // 
            this.txtDiasValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasValores.Location = new System.Drawing.Point(172, 28);
            this.txtDiasValores.Name = "txtDiasValores";
            this.txtDiasValores.Size = new System.Drawing.Size(47, 20);
            this.txtDiasValores.TabIndex = 23;
            this.txtDiasValores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasCobranza_KeyPress);
            this.txtDiasValores.Validated += new System.EventHandler(this.txtDiasCobranza_Validated);
            // 
            // ckActivo
            // 
            this.ckActivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckActivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckActivo.Location = new System.Drawing.Point(11, 84);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckActivo.Size = new System.Drawing.Size(208, 18);
            this.ckActivo.TabIndex = 24;
            this.ckActivo.Text = "Condicion de Pago ACTIVA";
            this.ckActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ckActivo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtZtermId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbZterm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 56);
            this.panel1.TabIndex = 25;
            // 
            // txtZtermId
            // 
            this.txtZtermId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZtermId.Location = new System.Drawing.Point(111, 8);
            this.txtZtermId.Name = "txtZtermId";
            this.txtZtermId.Size = new System.Drawing.Size(109, 20);
            this.txtZtermId.TabIndex = 22;
            this.txtZtermId.Validating += new System.ComponentModel.CancelEventHandler(this.txtZtermId_Validating);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDiasTotalesPagoDocumento);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDiasCobranza);
            this.panel2.Controls.Add(this.ckActivo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDiasValores);
            this.panel2.Location = new System.Drawing.Point(4, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 109);
            this.panel2.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(223, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Desde Pago hasta Acreditacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Location = new System.Drawing.Point(223, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Desde Factura a Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Dias Promedio de Pago Doc";
            // 
            // txtDiasTotalesPagoDocumento
            // 
            this.txtDiasTotalesPagoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasTotalesPagoDocumento.Location = new System.Drawing.Point(172, 50);
            this.txtDiasTotalesPagoDocumento.Name = "txtDiasTotalesPagoDocumento";
            this.txtDiasTotalesPagoDocumento.ReadOnly = true;
            this.txtDiasTotalesPagoDocumento.Size = new System.Drawing.Size(47, 20);
            this.txtDiasTotalesPagoDocumento.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Dias Entrega de Valores";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(408, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(408, 45);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(107, 42);
            this.btnNew.TabIndex = 28;
            this.btnNew.Text = "Nueva\r\nCondicion";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdateSave
            // 
            this.btnUpdateSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSave.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSave.Image")));
            this.btnUpdateSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSave.Location = new System.Drawing.Point(408, 87);
            this.btnUpdateSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateSave.Name = "btnUpdateSave";
            this.btnUpdateSave.Size = new System.Drawing.Size(107, 42);
            this.btnUpdateSave.TabIndex = 29;
            this.btnUpdateSave.Text = "Guardar\r\nCondicion";
            this.btnUpdateSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateSave.UseVisualStyleBackColor = true;
            this.btnUpdateSave.Click += new System.EventHandler(this.btnUpdateSave_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(408, 129);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(107, 42);
            this.btnSelect.TabIndex = 30;
            this.btnSelect.Text = "Usar\r\nCondicion";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FrmMdz01ZtermStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 174);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnUpdateSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMdz01ZtermStructure";
            this.Text = "MDZ01 - Estructura de Terminos de Pago (ZTERM)";
            this.Load += new System.EventHandler(this.FrmAddressStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0019ZTERMBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbZterm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtDiasCobranza;
        private System.Windows.Forms.TextBox txtDiasValores;
        private System.Windows.Forms.CheckBox ckActivo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiasTotalesPagoDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdateSave;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.BindingSource t0019ZTERMBindingSource;
        private System.Windows.Forms.TextBox txtZtermId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}