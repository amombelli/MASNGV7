namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCO13Conciliacion203204
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO13Conciliacion203204));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.structureConcil203BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conciliacionSaldoVendor203Vs204BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rb203 = new System.Windows.Forms.RadioButton();
            this.rb204 = new System.Windows.Forms.RadioButton();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo203DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo204DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoLXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckSoloDiferencia = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.structureConcil203BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conciliacionSaldoVendor203Vs204BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(635, 8);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 163;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorIdDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.vendorTypeDataGridViewTextBoxColumn,
            this.saldo203DataGridViewTextBoxColumn,
            this.saldo204DataGridViewTextBoxColumn,
            this.diferenciaDataGridViewTextBoxColumn,
            this.tipoLXDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.structureConcil203BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(729, 688);
            this.dataGridView1.TabIndex = 164;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.ckSoloDiferencia);
            this.panel1.Controls.Add(this.rb204);
            this.panel1.Controls.Add(this.rb203);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 49);
            this.panel1.TabIndex = 165;
            // 
            // structureConcil203BindingSource
            // 
            this.structureConcil203BindingSource.DataSource = typeof(Tecser.Business.Transactional.Cierre.StructureConcil203);
            // 
            // conciliacionSaldoVendor203Vs204BindingSource
            // 
            this.conciliacionSaldoVendor203Vs204BindingSource.DataSource = typeof(Tecser.Business.Transactional.Cierre.ConciliacionSaldoVendor203Vs204);
            // 
            // rb203
            // 
            this.rb203.AutoSize = true;
            this.rb203.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb203.ForeColor = System.Drawing.Color.Navy;
            this.rb203.Location = new System.Drawing.Point(9, 6);
            this.rb203.Name = "rb203";
            this.rb203.Size = new System.Drawing.Size(103, 19);
            this.rb203.TabIndex = 2;
            this.rb203.TabStop = true;
            this.rb203.Text = "T203 ---> T204";
            this.rb203.UseVisualStyleBackColor = true;
            this.rb203.CheckedChanged += new System.EventHandler(this.rb203_CheckedChanged);
            // 
            // rb204
            // 
            this.rb204.AutoSize = true;
            this.rb204.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb204.ForeColor = System.Drawing.Color.Navy;
            this.rb204.Location = new System.Drawing.Point(9, 26);
            this.rb204.Name = "rb204";
            this.rb204.Size = new System.Drawing.Size(103, 19);
            this.rb204.TabIndex = 3;
            this.rb204.TabStop = true;
            this.rb204.Text = "T204 ---> T203";
            this.rb204.UseVisualStyleBackColor = true;
            this.rb204.CheckedChanged += new System.EventHandler(this.rb203_CheckedChanged);
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "IDProv";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // vendorTypeDataGridViewTextBoxColumn
            // 
            this.vendorTypeDataGridViewTextBoxColumn.DataPropertyName = "VendorType";
            this.vendorTypeDataGridViewTextBoxColumn.HeaderText = "Tipo ";
            this.vendorTypeDataGridViewTextBoxColumn.Name = "vendorTypeDataGridViewTextBoxColumn";
            this.vendorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldo203DataGridViewTextBoxColumn
            // 
            this.saldo203DataGridViewTextBoxColumn.DataPropertyName = "Saldo203";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.saldo203DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.saldo203DataGridViewTextBoxColumn.HeaderText = "Saldo [203]";
            this.saldo203DataGridViewTextBoxColumn.Name = "saldo203DataGridViewTextBoxColumn";
            this.saldo203DataGridViewTextBoxColumn.ReadOnly = true;
            this.saldo203DataGridViewTextBoxColumn.Width = 90;
            // 
            // saldo204DataGridViewTextBoxColumn
            // 
            this.saldo204DataGridViewTextBoxColumn.DataPropertyName = "Saldo204";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.saldo204DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.saldo204DataGridViewTextBoxColumn.HeaderText = "Saldo [204]";
            this.saldo204DataGridViewTextBoxColumn.Name = "saldo204DataGridViewTextBoxColumn";
            this.saldo204DataGridViewTextBoxColumn.ReadOnly = true;
            this.saldo204DataGridViewTextBoxColumn.Width = 90;
            // 
            // diferenciaDataGridViewTextBoxColumn
            // 
            this.diferenciaDataGridViewTextBoxColumn.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.diferenciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.diferenciaDataGridViewTextBoxColumn.HeaderText = "Diferencia";
            this.diferenciaDataGridViewTextBoxColumn.Name = "diferenciaDataGridViewTextBoxColumn";
            this.diferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.diferenciaDataGridViewTextBoxColumn.Width = 90;
            // 
            // tipoLXDataGridViewTextBoxColumn
            // 
            this.tipoLXDataGridViewTextBoxColumn.DataPropertyName = "TipoLX";
            this.tipoLXDataGridViewTextBoxColumn.HeaderText = "LX";
            this.tipoLXDataGridViewTextBoxColumn.Name = "tipoLXDataGridViewTextBoxColumn";
            this.tipoLXDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoLXDataGridViewTextBoxColumn.Width = 30;
            // 
            // ckSoloDiferencia
            // 
            this.ckSoloDiferencia.AutoSize = true;
            this.ckSoloDiferencia.ForeColor = System.Drawing.Color.OrangeRed;
            this.ckSoloDiferencia.Location = new System.Drawing.Point(202, 6);
            this.ckSoloDiferencia.Name = "ckSoloDiferencia";
            this.ckSoloDiferencia.Size = new System.Drawing.Size(132, 18);
            this.ckSoloDiferencia.TabIndex = 166;
            this.ckSoloDiferencia.Text = "Solo con Diferencia";
            this.ckSoloDiferencia.UseVisualStyleBackColor = true;
            this.ckSoloDiferencia.CheckedChanged += new System.EventHandler(this.ckSoloDiferencia_CheckedChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label15.Location = new System.Drawing.Point(10, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(732, 2);
            this.label15.TabIndex = 167;
            // 
            // FrmCO13Conciliacion203204
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 775);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmCO13Conciliacion203204";
            this.Text = "CO13 - Conciliacion 203 vs 204";
            this.Load += new System.EventHandler(this.FrmCO13Conciliacion203204_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.structureConcil203BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conciliacionSaldoVendor203Vs204BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource conciliacionSaldoVendor203Vs204BindingSource;
        private System.Windows.Forms.BindingSource structureConcil203BindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb204;
        private System.Windows.Forms.RadioButton rb203;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo203DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo204DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoLXDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox ckSoloDiferencia;
        private System.Windows.Forms.Label label15;
    }
}