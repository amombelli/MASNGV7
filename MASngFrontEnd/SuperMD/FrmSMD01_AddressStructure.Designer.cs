namespace MASngFE.SuperMD
{
    partial class FrmSMD01_AddressStructure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSMD01_AddressStructure));
            this.btnUtilizar = new System.Windows.Forms.Button();
            this.LocalidadBs = new System.Windows.Forms.BindingSource(this.components);
            this.partidoBs = new System.Windows.Forms.BindingSource(this.components);
            this.provinciaBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.semPais = new TSControls.CtlSemaforo();
            this.semPartido = new TSControls.CtlSemaforo();
            this.semLocalidad = new TSControls.CtlSemaforo();
            this.semProvincia = new TSControls.CtlSemaforo();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFPaisDescripcion = new System.Windows.Forms.TextBox();
            this.txtFProvinciaId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFPartidoId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFZip = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtFLocalidadId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFLocalidad = new System.Windows.Forms.ComboBox();
            this.txtZona = new System.Windows.Forms.TextBox();
            this.cmbFPartido = new System.Windows.Forms.ComboBox();
            this.txtFPais = new System.Windows.Forms.TextBox();
            this.cmbFProvincia = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewStruct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckSoloEstructuraValida = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LocalidadBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUtilizar
            // 
            this.btnUtilizar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilizar.ForeColor = System.Drawing.Color.Black;
            this.btnUtilizar.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilizar.Image")));
            this.btnUtilizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilizar.Location = new System.Drawing.Point(503, 16);
            this.btnUtilizar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUtilizar.Name = "btnUtilizar";
            this.btnUtilizar.Size = new System.Drawing.Size(107, 41);
            this.btnUtilizar.TabIndex = 45;
            this.btnUtilizar.Text = "Utilizar\r\nEstructura";
            this.btnUtilizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilizar.UseVisualStyleBackColor = true;
            this.btnUtilizar.Click += new System.EventHandler(this.btnUtilizar_Click);
            // 
            // LocalidadBs
            // 
            this.LocalidadBs.DataSource = typeof(TecserEF.Entity.T0010_LOCALIDAD);
            // 
            // partidoBs
            // 
            this.partidoBs.DataSource = typeof(TecserEF.Entity.T0010_PARTIDO);
            // 
            // provinciaBs
            // 
            this.provinciaBs.DataSource = typeof(TecserEF.Entity.T0008_REGION);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.semPais);
            this.panel3.Controls.Add(this.semPartido);
            this.panel3.Controls.Add(this.semLocalidad);
            this.panel3.Controls.Add(this.semProvincia);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtFPaisDescripcion);
            this.panel3.Controls.Add(this.txtFProvinciaId);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtFPartidoId);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtFZip);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.txtFLocalidadId);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbFLocalidad);
            this.panel3.Controls.Add(this.txtZona);
            this.panel3.Controls.Add(this.cmbFPartido);
            this.panel3.Controls.Add(this.txtFPais);
            this.panel3.Controls.Add(this.cmbFProvincia);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(14, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 125);
            this.panel3.TabIndex = 46;
            // 
            // semPais
            // 
            this.semPais.Location = new System.Drawing.Point(443, 5);
            this.semPais.Name = "semPais";
            this.semPais.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.semPais.Size = new System.Drawing.Size(23, 25);
            this.semPais.TabIndex = 42;
            // 
            // semPartido
            // 
            this.semPartido.Location = new System.Drawing.Point(443, 52);
            this.semPartido.Name = "semPartido";
            this.semPartido.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.semPartido.Size = new System.Drawing.Size(23, 25);
            this.semPartido.TabIndex = 41;
            // 
            // semLocalidad
            // 
            this.semLocalidad.Location = new System.Drawing.Point(443, 76);
            this.semLocalidad.Name = "semLocalidad";
            this.semLocalidad.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.semLocalidad.Size = new System.Drawing.Size(23, 25);
            this.semLocalidad.TabIndex = 40;
            // 
            // semProvincia
            // 
            this.semProvincia.Location = new System.Drawing.Point(443, 29);
            this.semProvincia.Name = "semProvincia";
            this.semProvincia.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.semProvincia.Size = new System.Drawing.Size(23, 23);
            this.semProvincia.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(11, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pais";
            // 
            // txtFPaisDescripcion
            // 
            this.txtFPaisDescripcion.Location = new System.Drawing.Point(153, 6);
            this.txtFPaisDescripcion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFPaisDescripcion.Name = "txtFPaisDescripcion";
            this.txtFPaisDescripcion.ReadOnly = true;
            this.txtFPaisDescripcion.Size = new System.Drawing.Size(131, 22);
            this.txtFPaisDescripcion.TabIndex = 23;
            // 
            // txtFProvinciaId
            // 
            this.txtFProvinciaId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFProvinciaId.Location = new System.Drawing.Point(395, 29);
            this.txtFProvinciaId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFProvinciaId.Name = "txtFProvinciaId";
            this.txtFProvinciaId.ReadOnly = true;
            this.txtFProvinciaId.Size = new System.Drawing.Size(42, 22);
            this.txtFProvinciaId.TabIndex = 24;
            this.txtFProvinciaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Purple;
            this.label12.Location = new System.Drawing.Point(11, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "Codigo Postal";
            // 
            // txtFPartidoId
            // 
            this.txtFPartidoId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFPartidoId.Location = new System.Drawing.Point(395, 53);
            this.txtFPartidoId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFPartidoId.Name = "txtFPartidoId";
            this.txtFPartidoId.ReadOnly = true;
            this.txtFPartidoId.Size = new System.Drawing.Size(42, 22);
            this.txtFPartidoId.TabIndex = 25;
            this.txtFPartidoId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(11, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Provincia";
            // 
            // txtFZip
            // 
            this.txtFZip.Location = new System.Drawing.Point(117, 100);
            this.txtFZip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFZip.Name = "txtFZip";
            this.txtFZip.Size = new System.Drawing.Size(54, 22);
            this.txtFZip.TabIndex = 22;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Purple;
            this.label40.Location = new System.Drawing.Point(357, 104);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(34, 14);
            this.label40.TabIndex = 37;
            this.label40.Text = "Zona";
            // 
            // txtFLocalidadId
            // 
            this.txtFLocalidadId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFLocalidadId.Location = new System.Drawing.Point(395, 77);
            this.txtFLocalidadId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFLocalidadId.Name = "txtFLocalidadId";
            this.txtFLocalidadId.ReadOnly = true;
            this.txtFLocalidadId.Size = new System.Drawing.Size(42, 22);
            this.txtFLocalidadId.TabIndex = 26;
            this.txtFLocalidadId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(11, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Partido/Comuna";
            this.label5.UseWaitCursor = true;
            // 
            // cmbFLocalidad
            // 
            this.cmbFLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFLocalidad.DataSource = this.LocalidadBs;
            this.cmbFLocalidad.DisplayMember = "Localidad";
            this.cmbFLocalidad.FormattingEnabled = true;
            this.cmbFLocalidad.Location = new System.Drawing.Point(117, 77);
            this.cmbFLocalidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbFLocalidad.Name = "cmbFLocalidad";
            this.cmbFLocalidad.Size = new System.Drawing.Size(277, 22);
            this.cmbFLocalidad.TabIndex = 20;
            this.cmbFLocalidad.ValueMember = "Id";
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(395, 100);
            this.txtZona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(42, 22);
            this.txtZona.TabIndex = 38;
            // 
            // cmbFPartido
            // 
            this.cmbFPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFPartido.DataSource = this.partidoBs;
            this.cmbFPartido.DisplayMember = "Partido";
            this.cmbFPartido.FormattingEnabled = true;
            this.cmbFPartido.Location = new System.Drawing.Point(117, 53);
            this.cmbFPartido.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbFPartido.Name = "cmbFPartido";
            this.cmbFPartido.Size = new System.Drawing.Size(277, 22);
            this.cmbFPartido.TabIndex = 19;
            this.cmbFPartido.ValueMember = "Id";
            // 
            // txtFPais
            // 
            this.txtFPais.Location = new System.Drawing.Point(117, 6);
            this.txtFPais.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFPais.Name = "txtFPais";
            this.txtFPais.Size = new System.Drawing.Size(36, 22);
            this.txtFPais.TabIndex = 16;
            this.txtFPais.Text = "AR";
            this.txtFPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbFProvincia
            // 
            this.cmbFProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFProvincia.DataSource = this.provinciaBs;
            this.cmbFProvincia.DisplayMember = "Region";
            this.cmbFProvincia.FormattingEnabled = true;
            this.cmbFProvincia.Location = new System.Drawing.Point(117, 29);
            this.cmbFProvincia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbFProvincia.Name = "cmbFProvincia";
            this.cmbFProvincia.Size = new System.Drawing.Size(277, 22);
            this.cmbFProvincia.TabIndex = 18;
            this.cmbFProvincia.ValueMember = "Id";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(11, 81);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "Localidad/Barrio";
            this.label11.UseWaitCursor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(503, 57);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 41);
            this.btnExit.TabIndex = 69;
            this.btnExit.Text = "Cancelar";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewStruct
            // 
            this.btnNewStruct.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewStruct.ForeColor = System.Drawing.Color.Black;
            this.btnNewStruct.Image = ((System.Drawing.Image)(resources.GetObject("btnNewStruct.Image")));
            this.btnNewStruct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewStruct.Location = new System.Drawing.Point(14, 144);
            this.btnNewStruct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNewStruct.Name = "btnNewStruct";
            this.btnNewStruct.Size = new System.Drawing.Size(113, 41);
            this.btnNewStruct.TabIndex = 70;
            this.btnNewStruct.Text = "Nueva\r\nEstructura\r\n";
            this.btnNewStruct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewStruct.UseVisualStyleBackColor = true;
            this.btnNewStruct.Click += new System.EventHandler(this.btnNewStruct_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(8, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 2);
            this.label1.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(8, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(610, 2);
            this.label3.TabIndex = 164;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(618, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 186);
            this.label4.TabIndex = 165;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(2, 186);
            this.label7.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(610, 2);
            this.label2.TabIndex = 168;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(610, 2);
            this.label9.TabIndex = 167;
            // 
            // ckSoloEstructuraValida
            // 
            this.ckSoloEstructuraValida.AutoSize = true;
            this.ckSoloEstructuraValida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloEstructuraValida.Location = new System.Drawing.Point(133, 149);
            this.ckSoloEstructuraValida.Name = "ckSoloEstructuraValida";
            this.ckSoloEstructuraValida.Size = new System.Drawing.Size(187, 19);
            this.ckSoloEstructuraValida.TabIndex = 169;
            this.ckSoloEstructuraValida.Text = "Utilizar Solo Estructura Valida";
            this.ckSoloEstructuraValida.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ckSoloEstructuraValida);
            this.panel1.Controls.Add(this.btnUtilizar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnNewStruct);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 199);
            this.panel1.TabIndex = 170;
            // 
            // FrmSMD01_AddressStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(638, 211);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FrmSMD01_AddressStructure";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "SMD01 - Estructura de Direcciones";
            this.Load += new System.EventHandler(this.FrmSMD01_AddressStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LocalidadBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUtilizar;
        private System.Windows.Forms.BindingSource LocalidadBs;
        private System.Windows.Forms.BindingSource partidoBs;
        private System.Windows.Forms.BindingSource provinciaBs;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFPaisDescripcion;
        private System.Windows.Forms.TextBox txtFProvinciaId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFPartidoId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFZip;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtFLocalidadId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFLocalidad;
        private System.Windows.Forms.TextBox txtZona;
        private System.Windows.Forms.ComboBox cmbFPartido;
        private System.Windows.Forms.TextBox txtFPais;
        private System.Windows.Forms.ComboBox cmbFProvincia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewStruct;
        private TSControls.CtlSemaforo semPais;
        private TSControls.CtlSemaforo semPartido;
        private TSControls.CtlSemaforo semLocalidad;
        private TSControls.CtlSemaforo semProvincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckSoloEstructuraValida;
        private System.Windows.Forms.Panel panel1;
    }
}