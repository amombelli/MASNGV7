namespace MASngFE.NewUserControls
{
    partial class CtlAddress
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.provinciaBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPartido = new System.Windows.Forms.ComboBox();
            this.partidoBs = new System.Windows.Forms.BindingSource(this.components);
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.localidadBs = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.iconPais = new TSControls.CtlIconos();
            this.iconProvincia = new TSControls.CtlIconos();
            this.iconPartido = new TSControls.CtlIconos();
            this.iconLocalidad = new TSControls.CtlIconos();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBs)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProvincia.DataSource = this.provinciaBs;
            this.cmbProvincia.DisplayMember = "Region";
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(82, 37);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(196, 23);
            this.cmbProvincia.TabIndex = 0;
            this.cmbProvincia.ValueMember = "Id";
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbProvincia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPais_MouseDoubleClick);
            this.cmbProvincia.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProvincia_Validating);
            // 
            // provinciaBs
            // 
            this.provinciaBs.DataSource = typeof(TecserEF.Entity.T0008_REGION);
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(82, 14);
            this.txtPais.MaxLength = 2;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(30, 21);
            this.txtPais.TabIndex = 1;
            this.txtPais.Text = "AR";
            this.txtPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            this.txtPais.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPais_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Provincia";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 3);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Partido";
            // 
            // cmbPartido
            // 
            this.cmbPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartido.DataSource = this.partidoBs;
            this.cmbPartido.DisplayMember = "Partido";
            this.cmbPartido.FormattingEnabled = true;
            this.cmbPartido.Location = new System.Drawing.Point(82, 62);
            this.cmbPartido.Name = "cmbPartido";
            this.cmbPartido.Size = new System.Drawing.Size(196, 23);
            this.cmbPartido.TabIndex = 5;
            this.cmbPartido.ValueMember = "Id";
            this.cmbPartido.SelectedIndexChanged += new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbPartido.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPais_MouseDoubleClick);
            this.cmbPartido.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPartido_Validating);
            // 
            // partidoBs
            // 
            this.partidoBs.DataSource = typeof(TecserEF.Entity.T0010_PARTIDO);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.DataSource = this.localidadBs;
            this.cmbLocalidad.DisplayMember = "Localidad";
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(82, 87);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(196, 23);
            this.cmbLocalidad.TabIndex = 7;
            this.cmbLocalidad.ValueMember = "Id";
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            this.cmbLocalidad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPais_MouseDoubleClick);
            this.cmbLocalidad.Validating += new System.ComponentModel.CancelEventHandler(this.cmbLocalidad_Validating);
            // 
            // localidadBs
            // 
            this.localidadBs.DataSource = typeof(TecserEF.Entity.T0010_LOCALIDAD);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Localidad";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(2, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 117);
            this.label7.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(312, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 117);
            this.label8.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(2, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 3);
            this.label6.TabIndex = 12;
            // 
            // iconPais
            // 
            this.iconPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPais.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconPais.IconSize = TSControls.TamañoIcono.Chico;
            this.iconPais.Location = new System.Drawing.Point(119, 16);
            this.iconPais.Name = "iconPais";
            this.iconPais.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconPais.Size = new System.Drawing.Size(16, 16);
            this.iconPais.TabIndex = 13;
            // 
            // iconProvincia
            // 
            this.iconProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconProvincia.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconProvincia.IconSize = TSControls.TamañoIcono.Chico;
            this.iconProvincia.Location = new System.Drawing.Point(285, 40);
            this.iconProvincia.Name = "iconProvincia";
            this.iconProvincia.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconProvincia.Size = new System.Drawing.Size(16, 16);
            this.iconProvincia.TabIndex = 14;
            // 
            // iconPartido
            // 
            this.iconPartido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPartido.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconPartido.IconSize = TSControls.TamañoIcono.Chico;
            this.iconPartido.Location = new System.Drawing.Point(285, 65);
            this.iconPartido.Name = "iconPartido";
            this.iconPartido.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconPartido.Size = new System.Drawing.Size(16, 16);
            this.iconPartido.TabIndex = 15;
            // 
            // iconLocalidad
            // 
            this.iconLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconLocalidad.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconLocalidad.IconSize = TSControls.TamañoIcono.Chico;
            this.iconLocalidad.Location = new System.Drawing.Point(285, 90);
            this.iconLocalidad.Name = "iconLocalidad";
            this.iconLocalidad.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconLocalidad.Size = new System.Drawing.Size(16, 16);
            this.iconLocalidad.TabIndex = 16;
            // 
            // tt
            // 
            this.tt.AutoPopDelay = 1500;
            this.tt.InitialDelay = 500;
            this.tt.ReshowDelay = 100;
            this.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tt.ToolTipTitle = "Datos Incorrectos";
            // 
            // CtlAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconLocalidad);
            this.Controls.Add(this.iconPartido);
            this.Controls.Add(this.iconProvincia);
            this.Controls.Add(this.iconPais);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPartido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.cmbProvincia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtlAddress";
            this.Size = new System.Drawing.Size(318, 122);
            this.Load += new System.EventHandler(this.CtlAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPartido;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private TSControls.CtlIconos iconPais;
        private TSControls.CtlIconos iconProvincia;
        private TSControls.CtlIconos iconPartido;
        private TSControls.CtlIconos iconLocalidad;
        private System.Windows.Forms.BindingSource provinciaBs;
        private System.Windows.Forms.BindingSource partidoBs;
        private System.Windows.Forms.BindingSource localidadBs;
        private System.Windows.Forms.ToolTip tt;
    }
}
