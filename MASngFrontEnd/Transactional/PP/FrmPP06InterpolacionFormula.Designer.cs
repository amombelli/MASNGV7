namespace MASngFE.Transactional.PP
{
    partial class FrmPP06InterpolacionFormula
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP06InterpolacionFormula));
            this.panel6 = new System.Windows.Forms.Panel();
            this.ckSoloFormulaActiva = new System.Windows.Forms.CheckBox();
            this.txtUltimaUtilizacion = new System.Windows.Forms.TextBox();
            this.cmbFormulas = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtNumeroFormula = new System.Windows.Forms.TextBox();
            this.txtMaterialPrimario = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.t0020Bs = new System.Windows.Forms.BindingSource(this.components);
            this.t0072Bs = new System.Windows.Forms.BindingSource(this.components);
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtKgRecalculo = new System.Windows.Forms.TextBox();
            this.dgvFormula = new System.Windows.Forms.DataGridView();
            this.idItemFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__cantidadPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kgReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__porcentajeReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__Recalculo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnUtilizarReemplazo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0020Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.ckSoloFormulaActiva);
            this.panel6.Controls.Add(this.txtUltimaUtilizacion);
            this.panel6.Controls.Add(this.cmbFormulas);
            this.panel6.Controls.Add(this.label39);
            this.panel6.Controls.Add(this.txtNumeroFormula);
            this.panel6.Controls.Add(this.txtMaterialPrimario);
            this.panel6.Controls.Add(this.label38);
            this.panel6.Location = new System.Drawing.Point(2, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(635, 64);
            this.panel6.TabIndex = 57;
            // 
            // ckSoloFormulaActiva
            // 
            this.ckSoloFormulaActiva.AutoSize = true;
            this.ckSoloFormulaActiva.Location = new System.Drawing.Point(460, 8);
            this.ckSoloFormulaActiva.Name = "ckSoloFormulaActiva";
            this.ckSoloFormulaActiva.Size = new System.Drawing.Size(165, 17);
            this.ckSoloFormulaActiva.TabIndex = 24;
            this.ckSoloFormulaActiva.Text = "SOLO FORMULAS ACTIVAS";
            this.ckSoloFormulaActiva.UseVisualStyleBackColor = true;
            this.ckSoloFormulaActiva.CheckedChanged += new System.EventHandler(this.ckSoloFormulaActiva_CheckedChanged);
            // 
            // txtUltimaUtilizacion
            // 
            this.txtUltimaUtilizacion.BackColor = System.Drawing.Color.Silver;
            this.txtUltimaUtilizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUltimaUtilizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimaUtilizacion.Location = new System.Drawing.Point(450, 32);
            this.txtUltimaUtilizacion.Name = "txtUltimaUtilizacion";
            this.txtUltimaUtilizacion.ReadOnly = true;
            this.txtUltimaUtilizacion.Size = new System.Drawing.Size(175, 19);
            this.txtUltimaUtilizacion.TabIndex = 58;
            this.txtUltimaUtilizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbFormulas
            // 
            this.cmbFormulas.BackColor = System.Drawing.Color.White;
            this.cmbFormulas.DataSource = this.t0020Bs;
            this.cmbFormulas.DisplayMember = "DESC_FORMULA";
            this.cmbFormulas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFormulas.FormattingEnabled = true;
            this.cmbFormulas.Location = new System.Drawing.Point(104, 31);
            this.cmbFormulas.Name = "cmbFormulas";
            this.cmbFormulas.Size = new System.Drawing.Size(269, 21);
            this.cmbFormulas.TabIndex = 57;
            this.cmbFormulas.ValueMember = "ID_FORMULA";
            this.cmbFormulas.SelectedIndexChanged += new System.EventHandler(this.cmbFormulas_SelectedIndexChanged);
            this.cmbFormulas.SelectedValueChanged += new System.EventHandler(this.cmbFormulas_SelectedValueChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(9, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 20);
            this.label39.TabIndex = 2;
            this.label39.Text = "PRIMARIO";
            // 
            // txtNumeroFormula
            // 
            this.txtNumeroFormula.BackColor = System.Drawing.Color.Silver;
            this.txtNumeroFormula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFormula.Location = new System.Drawing.Point(376, 32);
            this.txtNumeroFormula.Name = "txtNumeroFormula";
            this.txtNumeroFormula.ReadOnly = true;
            this.txtNumeroFormula.Size = new System.Drawing.Size(70, 19);
            this.txtNumeroFormula.TabIndex = 23;
            this.txtNumeroFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterialPrimario
            // 
            this.txtMaterialPrimario.BackColor = System.Drawing.Color.Silver;
            this.txtMaterialPrimario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialPrimario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialPrimario.Location = new System.Drawing.Point(104, 7);
            this.txtMaterialPrimario.Name = "txtMaterialPrimario";
            this.txtMaterialPrimario.ReadOnly = true;
            this.txtMaterialPrimario.Size = new System.Drawing.Size(207, 19);
            this.txtMaterialPrimario.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(9, 29);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 20);
            this.label38.TabIndex = 6;
            this.label38.Text = "FORM#";
            // 
            // t0020Bs
            // 
            this.t0020Bs.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // t0072Bs
            // 
            this.t0072Bs.DataSource = typeof(TecserEF.Entity.T0072_FORMULA_TEMP);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "KG Formulacion";
            // 
            // txtKgRecalculo
            // 
            this.txtKgRecalculo.BackColor = System.Drawing.Color.White;
            this.txtKgRecalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgRecalculo.Location = new System.Drawing.Point(140, 6);
            this.txtKgRecalculo.Name = "txtKgRecalculo";
            this.txtKgRecalculo.Size = new System.Drawing.Size(75, 26);
            this.txtKgRecalculo.TabIndex = 61;
            // 
            // dgvFormula
            // 
            this.dgvFormula.AllowUserToAddRows = false;
            this.dgvFormula.AllowUserToDeleteRows = false;
            this.dgvFormula.AutoGenerateColumns = false;
            this.dgvFormula.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormula.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemFormulaDataGridViewTextBoxColumn,
            this.primarioDataGridViewTextBoxColumn,
            this.@__cantidadPor,
            this.@__kgReal,
            this.@__porcentajeReal,
            this.@__Added,
            this.@__Recalculo});
            this.dgvFormula.DataSource = this.t0072Bs;
            this.dgvFormula.Location = new System.Drawing.Point(2, 145);
            this.dgvFormula.Name = "dgvFormula";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormula.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFormula.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormula.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFormula.Size = new System.Drawing.Size(444, 327);
            this.dgvFormula.TabIndex = 62;
            // 
            // idItemFormulaDataGridViewTextBoxColumn
            // 
            this.idItemFormulaDataGridViewTextBoxColumn.DataPropertyName = "idItemFormula";
            this.idItemFormulaDataGridViewTextBoxColumn.HeaderText = "#";
            this.idItemFormulaDataGridViewTextBoxColumn.Name = "idItemFormulaDataGridViewTextBoxColumn";
            this.idItemFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemFormulaDataGridViewTextBoxColumn.Width = 30;
            // 
            // primarioDataGridViewTextBoxColumn
            // 
            this.primarioDataGridViewTextBoxColumn.DataPropertyName = "Primario";
            this.primarioDataGridViewTextBoxColumn.HeaderText = "Primario";
            this.primarioDataGridViewTextBoxColumn.Name = "primarioDataGridViewTextBoxColumn";
            this.primarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.primarioDataGridViewTextBoxColumn.Width = 120;
            // 
            // __cantidadPor
            // 
            this.@__cantidadPor.DataPropertyName = "CantidadPor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "P2";
            dataGridViewCellStyle1.NullValue = "0";
            this.@__cantidadPor.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__cantidadPor.HeaderText = "Base%";
            this.@__cantidadPor.Name = "__cantidadPor";
            this.@__cantidadPor.ReadOnly = true;
            this.@__cantidadPor.Width = 50;
            // 
            // __kgReal
            // 
            this.@__kgReal.DataPropertyName = "CantidadKGReal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.@__kgReal.DefaultCellStyle = dataGridViewCellStyle2;
            this.@__kgReal.HeaderText = "FormKg";
            this.@__kgReal.Name = "__kgReal";
            this.@__kgReal.Width = 60;
            // 
            // __porcentajeReal
            // 
            this.@__porcentajeReal.DataPropertyName = "CantidadPorReal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "P2";
            dataGridViewCellStyle3.NullValue = "0";
            this.@__porcentajeReal.DefaultCellStyle = dataGridViewCellStyle3;
            this.@__porcentajeReal.HeaderText = "%Real";
            this.@__porcentajeReal.Name = "__porcentajeReal";
            this.@__porcentajeReal.ReadOnly = true;
            this.@__porcentajeReal.Width = 60;
            // 
            // __Added
            // 
            this.@__Added.DataPropertyName = "Added";
            this.@__Added.HeaderText = "[+]";
            this.@__Added.Name = "__Added";
            this.@__Added.ReadOnly = true;
            this.@__Added.Width = 30;
            // 
            // __Recalculo
            // 
            this.@__Recalculo.DataPropertyName = "Recalculo";
            this.@__Recalculo.HeaderText = "[!]";
            this.@__Recalculo.Name = "__Recalculo";
            this.@__Recalculo.ReadOnly = true;
            this.@__Recalculo.Width = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtKgRecalculo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 42);
            this.panel1.TabIndex = 64;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(444, 19);
            this.label13.TabIndex = 65;
            this.label13.Text = "CALCULO DE BOM (FORMULACION)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUtilizarReemplazo
            // 
            this.btnUtilizarReemplazo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilizarReemplazo.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilizarReemplazo.Image")));
            this.btnUtilizarReemplazo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilizarReemplazo.Location = new System.Drawing.Point(537, 78);
            this.btnUtilizarReemplazo.Name = "btnUtilizarReemplazo";
            this.btnUtilizarReemplazo.Size = new System.Drawing.Size(100, 40);
            this.btnUtilizarReemplazo.TabIndex = 100;
            this.btnUtilizarReemplazo.Text = "Utilizar\r\nReemplazo";
            this.btnUtilizarReemplazo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilizarReemplazo.UseVisualStyleBackColor = true;
            this.btnUtilizarReemplazo.Click += new System.EventHandler(this.btnUtilizarReemplazo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(537, 119);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 101;
            this.btnExit.Text = "Cancelar";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmPP06InterpolacionFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 476);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUtilizarReemplazo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvFormula);
            this.Controls.Add(this.panel6);
            this.Name = "FrmPP06InterpolacionFormula";
            this.Text = "PP06 Interpolacion de Formula";
            this.Load += new System.EventHandler(this.FrmPP06InterpolacionFormula_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0020Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox ckSoloFormulaActiva;
        private System.Windows.Forms.TextBox txtUltimaUtilizacion;
        private System.Windows.Forms.ComboBox cmbFormulas;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtNumeroFormula;
        private System.Windows.Forms.TextBox txtMaterialPrimario;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.BindingSource t0020Bs;
        private System.Windows.Forms.BindingSource t0072Bs;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKgRecalculo;
        private System.Windows.Forms.DataGridView dgvFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn __cantidadPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn __kgReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn __porcentajeReal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __Added;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __Recalculo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnUtilizarReemplazo;
        private System.Windows.Forms.Button btnExit;
    }
}