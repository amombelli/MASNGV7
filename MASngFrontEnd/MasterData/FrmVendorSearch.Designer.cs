namespace MASngFE.MasterData
{
    partial class FrmVendorSearch
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCuit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIdVendor = new System.Windows.Forms.ComboBox();
            this.btnVerValoresPadronAFIP = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ckActiveOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(345, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 27);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Location = new System.Drawing.Point(345, 67);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 27);
            this.btnVisualizar.TabIndex = 1;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(345, 94);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 27);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DropDownHeight = 50;
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.IntegralHeight = false;
            this.cmbRazonSocial.Location = new System.Drawing.Point(95, 10);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(189, 21);
            this.cmbRazonSocial.TabIndex = 3;
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fantasia";
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(95, 34);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(189, 21);
            this.cmbFantasia.TabIndex = 5;
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "CUIT";
            // 
            // cmbCuit
            // 
            this.cmbCuit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCuit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCuit.FormattingEnabled = true;
            this.cmbCuit.Location = new System.Drawing.Point(95, 58);
            this.cmbCuit.Name = "cmbCuit";
            this.cmbCuit.Size = new System.Drawing.Size(103, 21);
            this.cmbCuit.TabIndex = 7;
            this.cmbCuit.SelectedIndexChanged += new System.EventHandler(this.cmbCuit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "ID Vendor";
            // 
            // cmbIdVendor
            // 
            this.cmbIdVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIdVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIdVendor.FormattingEnabled = true;
            this.cmbIdVendor.Location = new System.Drawing.Point(95, 82);
            this.cmbIdVendor.Name = "cmbIdVendor";
            this.cmbIdVendor.Size = new System.Drawing.Size(103, 21);
            this.cmbIdVendor.TabIndex = 13;
            this.cmbIdVendor.SelectedIndexChanged += new System.EventHandler(this.cmbID6_SelectedIndexChanged);
            // 
            // btnVerValoresPadronAFIP
            // 
            this.btnVerValoresPadronAFIP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerValoresPadronAFIP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerValoresPadronAFIP.Location = new System.Drawing.Point(209, 59);
            this.btnVerValoresPadronAFIP.Name = "btnVerValoresPadronAFIP";
            this.btnVerValoresPadronAFIP.Size = new System.Drawing.Size(75, 40);
            this.btnVerValoresPadronAFIP.TabIndex = 19;
            this.btnVerValoresPadronAFIP.Text = "Ver Padron AFIP";
            this.btnVerValoresPadronAFIP.UseVisualStyleBackColor = true;
            this.btnVerValoresPadronAFIP.Click += new System.EventHandler(this.btnVerValoresPadronAFIP_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(345, 40);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 27);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ckActiveOnly
            // 
            this.ckActiveOnly.AutoSize = true;
            this.ckActiveOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ckActiveOnly.Checked = true;
            this.ckActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckActiveOnly.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ckActiveOnly.Location = new System.Drawing.Point(281, 179);
            this.ckActiveOnly.Name = "ckActiveOnly";
            this.ckActiveOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckActiveOnly.Size = new System.Drawing.Size(139, 19);
            this.ckActiveOnly.TabIndex = 21;
            this.ckActiveOnly.Text = "Solo Vendors Activos";
            this.ckActiveOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActiveOnly.UseVisualStyleBackColor = false;
            this.ckActiveOnly.CheckedChanged += new System.EventHandler(this.ckActiveOnly_CheckedChanged);
            // 
            // FrmVendorSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 203);
            this.Controls.Add(this.ckActiveOnly);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnVerValoresPadronAFIP);
            this.Controls.Add(this.cmbIdVendor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCuit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFantasia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRazonSocial);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "FrmVendorSearch";
            this.Text = "BUSCADOR DE VENDORS/PROVEEDORES";
            this.Load += new System.EventHandler(this.FrmVendorSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCuit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbIdVendor;
        private System.Windows.Forms.Button btnVerValoresPadronAFIP;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox ckActiveOnly;
    }
}