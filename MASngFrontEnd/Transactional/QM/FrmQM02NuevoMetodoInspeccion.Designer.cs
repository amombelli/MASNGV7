namespace MASngFE.Transactional.QM
{
    partial class FrmQm02NuevoMetodoInspeccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm02NuevoMetodoInspeccion));
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uckActivo = new MASngFE._UserControls.UCheckbox1();
            this.txtMetodoDescription = new System.Windows.Forms.TextBox();
            this.txtMetodoId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddMetodo = new System.Windows.Forms.Button();
            this.btnUpdateMetodo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.txtDocumentacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(513, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 61;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.uckActivo);
            this.panel1.Controls.Add(this.txtMetodoDescription);
            this.panel1.Controls.Add(this.txtMetodoId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 53);
            this.panel1.TabIndex = 63;
            // 
            // uckActivo
            // 
            this.uckActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uckActivo.Location = new System.Drawing.Point(358, 27);
            this.uckActivo.Name = "uckActivo";
            this.uckActivo.Size = new System.Drawing.Size(127, 19);
            this.uckActivo.TabIndex = 5;
            // 
            // txtMetodoDescription
            // 
            this.txtMetodoDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetodoDescription.Location = new System.Drawing.Point(88, 26);
            this.txtMetodoDescription.Name = "txtMetodoDescription";
            this.txtMetodoDescription.Size = new System.Drawing.Size(263, 21);
            this.txtMetodoDescription.TabIndex = 4;
            // 
            // txtMetodoId
            // 
            this.txtMetodoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetodoId.ForeColor = System.Drawing.Color.Crimson;
            this.txtMetodoId.Location = new System.Drawing.Point(88, 4);
            this.txtMetodoId.Name = "txtMetodoId";
            this.txtMetodoId.Size = new System.Drawing.Size(70, 21);
            this.txtMetodoId.TabIndex = 2;
            this.txtMetodoId.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMetodoId_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Metodo";
            // 
            // btnAddMetodo
            // 
            this.btnAddMetodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMetodo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMetodo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMetodo.Image")));
            this.btnAddMetodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMetodo.Location = new System.Drawing.Point(389, 66);
            this.btnAddMetodo.Name = "btnAddMetodo";
            this.btnAddMetodo.Size = new System.Drawing.Size(100, 40);
            this.btnAddMetodo.TabIndex = 68;
            this.btnAddMetodo.Text = "Agregar\r\nMetodo";
            this.btnAddMetodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMetodo.UseVisualStyleBackColor = true;
            this.btnAddMetodo.Click += new System.EventHandler(this.BtnAddMetodo_Click);
            // 
            // btnUpdateMetodo
            // 
            this.btnUpdateMetodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdateMetodo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMetodo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMetodo.Image")));
            this.btnUpdateMetodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateMetodo.Location = new System.Drawing.Point(389, 107);
            this.btnUpdateMetodo.Name = "btnUpdateMetodo";
            this.btnUpdateMetodo.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateMetodo.TabIndex = 69;
            this.btnUpdateMetodo.Text = "Actualizar\r\nMetodo";
            this.btnUpdateMetodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateMetodo.UseVisualStyleBackColor = true;
            this.btnUpdateMetodo.Click += new System.EventHandler(this.BtnUpdateMetodo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Khaki;
            this.panel2.Controls.Add(this.cmbDataType);
            this.panel2.Controls.Add(this.txtDocumentacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtUnit);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(4, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 146);
            this.panel2.TabIndex = 64;
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Items.AddRange(new object[] {
            "Decimal",
            "Entero",
            "Si_No",
            "Ok_Incorrecto",
            "Aprobado_Rechazado",
            "TextoLibre",
            "True_False"});
            this.cmbDataType.Location = new System.Drawing.Point(123, 29);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(121, 21);
            this.cmbDataType.TabIndex = 7;
            // 
            // txtDocumentacion
            // 
            this.txtDocumentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentacion.Location = new System.Drawing.Point(122, 56);
            this.txtDocumentacion.Multiline = true;
            this.txtDocumentacion.Name = "txtDocumentacion";
            this.txtDocumentacion.Size = new System.Drawing.Size(229, 80);
            this.txtDocumentacion.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Documentacion";
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(122, 4);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(52, 21);
            this.txtUnit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo de Dato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Unidad de Medida";
            // 
            // FrmQm02NuevoMetodoInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 215);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnUpdateMetodo);
            this.Controls.Add(this.btnAddMetodo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmQm02NuevoMetodoInspeccion";
            this.Text = "QM02 - Nuevo Metodo Inspeccion";
            this.Load += new System.EventHandler(this.FrmQM02NuevoMetodoInspeccion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMetodoDescription;
        private System.Windows.Forms.TextBox txtMetodoId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddMetodo;
        private System.Windows.Forms.Button btnUpdateMetodo;
        private _UserControls.UCheckbox1 uckActivo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TextBox txtDocumentacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}