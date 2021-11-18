namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCo36ConciliaDiferenciasEgresos
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvListaConcilia1 = new System.Windows.Forms.DataGridView();
            this.stx1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeCcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldosOkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.docEncnontradoCcDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaConcilia1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stx1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(1208, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 813);
            this.label4.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 813);
            this.label2.TabIndex = 97;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1207, 2);
            this.label8.TabIndex = 96;
            // 
            // dgvListaConcilia1
            // 
            this.dgvListaConcilia1.AllowUserToAddRows = false;
            this.dgvListaConcilia1.AllowUserToDeleteRows = false;
            this.dgvListaConcilia1.AutoGenerateColumns = false;
            this.dgvListaConcilia1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaConcilia1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdDataGridViewTextBoxColumn,
            this.numeroDocDataGridViewTextBoxColumn,
            this.importeRegDataGridViewTextBoxColumn,
            this.importeCcDataGridViewTextBoxColumn,
            this.saldosOkDataGridViewCheckBoxColumn,
            this.docEncnontradoCcDataGridViewCheckBoxColumn});
            this.dgvListaConcilia1.DataSource = this.stx1BindingSource;
            this.dgvListaConcilia1.Location = new System.Drawing.Point(21, 63);
            this.dgvListaConcilia1.Name = "dgvListaConcilia1";
            this.dgvListaConcilia1.ReadOnly = true;
            this.dgvListaConcilia1.Size = new System.Drawing.Size(790, 648);
            this.dgvListaConcilia1.TabIndex = 99;
            // 
            // stx1BindingSource
            // 
            this.stx1BindingSource.DataSource = typeof(Tecser.Business.Transactional.Cierre.Stx1);
            // 
            // tdDataGridViewTextBoxColumn
            // 
            this.tdDataGridViewTextBoxColumn.DataPropertyName = "Td";
            this.tdDataGridViewTextBoxColumn.HeaderText = "Td";
            this.tdDataGridViewTextBoxColumn.Name = "tdDataGridViewTextBoxColumn";
            this.tdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroDocDataGridViewTextBoxColumn
            // 
            this.numeroDocDataGridViewTextBoxColumn.DataPropertyName = "NumeroDoc";
            this.numeroDocDataGridViewTextBoxColumn.HeaderText = "NumeroDoc";
            this.numeroDocDataGridViewTextBoxColumn.Name = "numeroDocDataGridViewTextBoxColumn";
            this.numeroDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeRegDataGridViewTextBoxColumn
            // 
            this.importeRegDataGridViewTextBoxColumn.DataPropertyName = "ImporteReg";
            this.importeRegDataGridViewTextBoxColumn.HeaderText = "ImporteReg";
            this.importeRegDataGridViewTextBoxColumn.Name = "importeRegDataGridViewTextBoxColumn";
            this.importeRegDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeCcDataGridViewTextBoxColumn
            // 
            this.importeCcDataGridViewTextBoxColumn.DataPropertyName = "ImporteCc";
            this.importeCcDataGridViewTextBoxColumn.HeaderText = "ImporteCc";
            this.importeCcDataGridViewTextBoxColumn.Name = "importeCcDataGridViewTextBoxColumn";
            this.importeCcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldosOkDataGridViewCheckBoxColumn
            // 
            this.saldosOkDataGridViewCheckBoxColumn.DataPropertyName = "SaldosOk";
            this.saldosOkDataGridViewCheckBoxColumn.HeaderText = "SaldosOk";
            this.saldosOkDataGridViewCheckBoxColumn.Name = "saldosOkDataGridViewCheckBoxColumn";
            this.saldosOkDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // docEncnontradoCcDataGridViewCheckBoxColumn
            // 
            this.docEncnontradoCcDataGridViewCheckBoxColumn.DataPropertyName = "DocEncnontradoCc";
            this.docEncnontradoCcDataGridViewCheckBoxColumn.HeaderText = "DocEncnontradoCc";
            this.docEncnontradoCcDataGridViewCheckBoxColumn.Name = "docEncnontradoCcDataGridViewCheckBoxColumn";
            this.docEncnontradoCcDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // FrmCo36ConciliaDiferenciasEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1214, 821);
            this.Controls.Add(this.dgvListaConcilia1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCo36ConciliaDiferenciasEgresos";
            this.Text = "CO36 - Concilia Diferencias Egresos";
            this.Load += new System.EventHandler(this.FrmCo36ConciliaDiferenciasEgresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaConcilia1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stx1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvListaConcilia1;
        private System.Windows.Forms.BindingSource stx1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeCcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn saldosOkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn docEncnontradoCcDataGridViewCheckBoxColumn;
    }
}