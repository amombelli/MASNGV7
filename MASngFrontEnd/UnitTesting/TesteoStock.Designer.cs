namespace MASngFE.UnitTesting
{
    partial class TesteoStock
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
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.btnOptimiza = new System.Windows.Forms.Button();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKG = new System.Windows.Forms.TextBox();
            this.dgvTablaStock = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdStock = new System.Windows.Forms.TextBox();
            this.btnSplitStock = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewKG = new System.Windows.Forms.TextBox();
            this.txtKGStockDisponibleDespacho = new System.Windows.Forms.TextBox();
            this.txtKGStockTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(24, 91);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(424, 311);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(24, 13);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(182, 21);
            this.cmbMaterial.TabIndex = 1;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // btnOptimiza
            // 
            this.btnOptimiza.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptimiza.Location = new System.Drawing.Point(373, 13);
            this.btnOptimiza.Name = "btnOptimiza";
            this.btnOptimiza.Size = new System.Drawing.Size(75, 23);
            this.btnOptimiza.TabIndex = 2;
            this.btnOptimiza.Text = "Optimiza";
            this.btnOptimiza.UseVisualStyleBackColor = true;
            this.btnOptimiza.Click += new System.EventHandler(this.btnOptimiza_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(691, 9);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(100, 20);
            this.txtMaterial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(624, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MATERIAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(806, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ESTADO";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(863, 10);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(96, 20);
            this.txtEstado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(806, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "KG";
            // 
            // txtKG
            // 
            this.txtKG.Location = new System.Drawing.Point(863, 35);
            this.txtKG.Name = "txtKG";
            this.txtKG.Size = new System.Drawing.Size(96, 20);
            this.txtKG.TabIndex = 7;
            // 
            // dgvTablaStock
            // 
            this.dgvTablaStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaStock.Location = new System.Drawing.Point(466, 91);
            this.dgvTablaStock.MultiSelect = false;
            this.dgvTablaStock.Name = "dgvTablaStock";
            this.dgvTablaStock.Size = new System.Drawing.Size(473, 311);
            this.dgvTablaStock.TabIndex = 9;
            this.dgvTablaStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaStock_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "IDMATERIAL";
            // 
            // txtIdStock
            // 
            this.txtIdStock.Location = new System.Drawing.Point(702, 35);
            this.txtIdStock.Name = "txtIdStock";
            this.txtIdStock.Size = new System.Drawing.Size(89, 20);
            this.txtIdStock.TabIndex = 10;
            // 
            // btnSplitStock
            // 
            this.btnSplitStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplitStock.Location = new System.Drawing.Point(965, 59);
            this.btnSplitStock.Name = "btnSplitStock";
            this.btnSplitStock.Size = new System.Drawing.Size(75, 23);
            this.btnSplitStock.TabIndex = 12;
            this.btnSplitStock.Text = "Split";
            this.btnSplitStock.UseVisualStyleBackColor = true;
            this.btnSplitStock.Click += new System.EventHandler(this.btnSplitStock_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "NEW KG";
            // 
            // txtNewKG
            // 
            this.txtNewKG.Location = new System.Drawing.Point(863, 61);
            this.txtNewKG.Name = "txtNewKG";
            this.txtNewKG.Size = new System.Drawing.Size(96, 20);
            this.txtNewKG.TabIndex = 13;
            // 
            // txtKGStockDisponibleDespacho
            // 
            this.txtKGStockDisponibleDespacho.Location = new System.Drawing.Point(445, 57);
            this.txtKGStockDisponibleDespacho.Name = "txtKGStockDisponibleDespacho";
            this.txtKGStockDisponibleDespacho.Size = new System.Drawing.Size(89, 20);
            this.txtKGStockDisponibleDespacho.TabIndex = 15;
            // 
            // txtKGStockTotal
            // 
            this.txtKGStockTotal.Location = new System.Drawing.Point(282, 57);
            this.txtKGStockTotal.Name = "txtKGStockTotal";
            this.txtKGStockTotal.Size = new System.Drawing.Size(100, 20);
            this.txtKGStockTotal.TabIndex = 16;
            // 
            // TesteoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 414);
            this.Controls.Add(this.txtKGStockTotal);
            this.Controls.Add(this.txtKGStockDisponibleDespacho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNewKG);
            this.Controls.Add(this.btnSplitStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdStock);
            this.Controls.Add(this.dgvTablaStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.btnOptimiza);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.dgvStock);
            this.Name = "TesteoStock";
            this.Text = "TesteoStock";
            this.Load += new System.EventHandler(this.TesteoStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Button btnOptimiza;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKG;
        private System.Windows.Forms.DataGridView dgvTablaStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdStock;
        private System.Windows.Forms.Button btnSplitStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewKG;
        private System.Windows.Forms.TextBox txtKGStockDisponibleDespacho;
        private System.Windows.Forms.TextBox txtKGStockTotal;
    }
}