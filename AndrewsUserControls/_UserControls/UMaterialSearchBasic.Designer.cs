namespace MASngFE._UserControls
{
    partial class UMaterialSearchBasic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrimario = new System.Windows.Forms.ComboBox();
            this.T0010MatBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtPrimarioDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.T0012TipoBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtTipoDescription = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.cmbAka = new System.Windows.Forms.ComboBox();
            this.T0011AKABs = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtAkaDescription = new System.Windows.Forms.TextBox();
            this.T0010Dgv = new System.Windows.Forms.BindingSource(this.components);
            this.txtTipoAka = new System.Windows.Forms.TextBox();
            this.txtTipoPrimario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.T0010MatBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0012TipoBs)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0011AKABs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0010Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Primario";
            // 
            // cmbPrimario
            // 
            this.cmbPrimario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPrimario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPrimario.DataSource = this.T0010MatBs;
            this.cmbPrimario.DisplayMember = "IDMATERIAL";
            this.cmbPrimario.FormattingEnabled = true;
            this.cmbPrimario.Location = new System.Drawing.Point(66, 2);
            this.cmbPrimario.Name = "cmbPrimario";
            this.cmbPrimario.Size = new System.Drawing.Size(135, 21);
            this.cmbPrimario.TabIndex = 4;
            this.cmbPrimario.ValueMember = "IDMATERIAL";
            this.cmbPrimario.SelectedIndexChanged += new System.EventHandler(this.cmbPrimario_SelectedIndexChanged);
            this.cmbPrimario.TextUpdate += new System.EventHandler(this.cmbPrimario_TextUpdate);
            this.cmbPrimario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbPrimario_KeyUp);
            // 
            // T0010MatBs
            // 
            this.T0010MatBs.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // txtPrimarioDesc
            // 
            this.txtPrimarioDesc.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPrimarioDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtPrimarioDesc.Location = new System.Drawing.Point(203, 3);
            this.txtPrimarioDesc.Name = "txtPrimarioDesc";
            this.txtPrimarioDesc.ReadOnly = true;
            this.txtPrimarioDesc.Size = new System.Drawing.Size(245, 20);
            this.txtPrimarioDesc.TabIndex = 19;
            this.txtPrimarioDesc.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tipo Prim";
            // 
            // cmbTipo
            // 
            this.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipo.DataSource = this.T0012TipoBs;
            this.cmbTipo.DisplayMember = "TIPO_MATERIAL";
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(66, 48);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(135, 21);
            this.cmbTipo.TabIndex = 20;
            this.cmbTipo.ValueMember = "TIPO_MATERIAL";
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // T0012TipoBs
            // 
            this.T0012TipoBs.DataSource = typeof(TecserEF.Entity.T0012_TIPO_MATERIAL);
            // 
            // txtTipoDescription
            // 
            this.txtTipoDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoDescription.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.T0012TipoBs, "DESCRIPCION", true));
            this.txtTipoDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTipoDescription.Location = new System.Drawing.Point(203, 49);
            this.txtTipoDescription.Name = "txtTipoDescription";
            this.txtTipoDescription.ReadOnly = true;
            this.txtTipoDescription.Size = new System.Drawing.Size(309, 20);
            this.txtTipoDescription.TabIndex = 22;
            this.txtTipoDescription.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(4, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 24);
            this.panel2.TabIndex = 100;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(14, 3);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(153, 18);
            this.ckSoloActivos.TabIndex = 94;
            this.ckSoloActivos.Text = "Solo Materiales Activos";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
            // 
            // cmbAka
            // 
            this.cmbAka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAka.DataSource = this.T0011AKABs;
            this.cmbAka.DisplayMember = "CODVENTA";
            this.cmbAka.FormattingEnabled = true;
            this.cmbAka.Location = new System.Drawing.Point(66, 25);
            this.cmbAka.Name = "cmbAka";
            this.cmbAka.Size = new System.Drawing.Size(135, 21);
            this.cmbAka.TabIndex = 6;
            this.cmbAka.ValueMember = "CODVENTA";
            this.cmbAka.SelectedIndexChanged += new System.EventHandler(this.cmbAka_SelectedIndexChanged);
            this.cmbAka.TextUpdate += new System.EventHandler(this.cmbAka_TextUpdate);
            this.cmbAka.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbAka_KeyUp);
            // 
            // T0011AKABs
            // 
            this.T0011AKABs.DataSource = typeof(TecserEF.Entity.T0011_MATERIALES_AKA);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cod Venta";
            // 
            // txtAkaDescription
            // 
            this.txtAkaDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAkaDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtAkaDescription.Location = new System.Drawing.Point(203, 26);
            this.txtAkaDescription.Name = "txtAkaDescription";
            this.txtAkaDescription.ReadOnly = true;
            this.txtAkaDescription.Size = new System.Drawing.Size(245, 20);
            this.txtAkaDescription.TabIndex = 101;
            this.txtAkaDescription.TabStop = false;
            // 
            // T0010Dgv
            // 
            this.T0010Dgv.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // txtTipoAka
            // 
            this.txtTipoAka.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoAka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTipoAka.Location = new System.Drawing.Point(450, 26);
            this.txtTipoAka.Name = "txtTipoAka";
            this.txtTipoAka.ReadOnly = true;
            this.txtTipoAka.Size = new System.Drawing.Size(62, 20);
            this.txtTipoAka.TabIndex = 103;
            this.txtTipoAka.TabStop = false;
            this.txtTipoAka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipoPrimario
            // 
            this.txtTipoPrimario.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoPrimario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTipoPrimario.Location = new System.Drawing.Point(450, 3);
            this.txtTipoPrimario.Name = "txtTipoPrimario";
            this.txtTipoPrimario.ReadOnly = true;
            this.txtTipoPrimario.Size = new System.Drawing.Size(62, 20);
            this.txtTipoPrimario.TabIndex = 102;
            this.txtTipoPrimario.TabStop = false;
            this.txtTipoPrimario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UMaterialSearchBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTipoAka);
            this.Controls.Add(this.cmbAka);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTipoPrimario);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTipoDescription);
            this.Controls.Add(this.txtAkaDescription);
            this.Controls.Add(this.txtPrimarioDesc);
            this.Controls.Add(this.cmbPrimario);
            this.Controls.Add(this.panel2);
            this.Name = "UMaterialSearchBasic";
            this.Size = new System.Drawing.Size(515, 98);
            ((System.ComponentModel.ISupportInitialize)(this.T0010MatBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0012TipoBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0011AKABs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0010Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPrimario;
        private System.Windows.Forms.TextBox txtPrimarioDesc;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtTipoDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        protected System.Windows.Forms.ComboBox cmbAka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAkaDescription;
        private System.Windows.Forms.BindingSource T0010MatBs;
        private System.Windows.Forms.BindingSource T0012TipoBs;
        private System.Windows.Forms.BindingSource T0011AKABs;
        public System.Windows.Forms.BindingSource T0010Dgv;
        private System.Windows.Forms.TextBox txtTipoAka;
        private System.Windows.Forms.TextBox txtTipoPrimario;
    }
}
