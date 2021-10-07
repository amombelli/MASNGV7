namespace MASngFE.Transactional.PP
{
    partial class FrmPP17CambiarOF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP17CambiarOF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.t0070PLANPRODUCCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.@__numeroOF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDPLANSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGFABRICARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPLANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kGFabricadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0070PLANPRODUCCIONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.Location = new System.Drawing.Point(3, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 438);
            this.LineaIzq.TabIndex = 184;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DimGray;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaArriba.Location = new System.Drawing.Point(3, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(786, 3);
            this.lineaArriba.TabIndex = 183;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__numeroOF,
            this.iDPLANSDataGridViewTextBoxColumn,
            this.mATERIALDataGridViewTextBoxColumn,
            this.kGFABRICARDataGridViewTextBoxColumn,
            this.sTATUSDataGridViewTextBoxColumn,
            this.fPLANDataGridViewTextBoxColumn,
            this.kGFabricadosDataGridViewTextBoxColumn,
            this.Close});
            this.dgv.DataSource = this.t0070PLANPRODUCCIONBindingSource;
            this.dgv.GridColor = System.Drawing.Color.Black;
            this.dgv.Location = new System.Drawing.Point(12, 55);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersWidth = 20;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(660, 378);
            this.dgv.TabIndex = 185;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // t0070PLANPRODUCCIONBindingSource
            // 
            this.t0070PLANPRODUCCIONBindingSource.DataSource = typeof(TecserEF.Entity.T0070_PLANPRODUCCION);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 20);
            this.label1.TabIndex = 186;
            this.label1.Text = "Listado de Orden de Fabricacion Pendientes de Cierre";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(3, 438);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(786, 3);
            this.label2.TabIndex = 187;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(786, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 438);
            this.label3.TabIndex = 188;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCerrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(681, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 44);
            this.btnCerrar.TabIndex = 189;
            this.btnCerrar.Text = "Cancelar\r\nSeleccion";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // __numeroOF
            // 
            this.@__numeroOF.DataPropertyName = "IDPLAN";
            this.@__numeroOF.HeaderText = "OF#";
            this.@__numeroOF.Name = "__numeroOF";
            this.@__numeroOF.ReadOnly = true;
            this.@__numeroOF.Width = 70;
            // 
            // iDPLANSDataGridViewTextBoxColumn
            // 
            this.iDPLANSDataGridViewTextBoxColumn.DataPropertyName = "IDPLAN_S";
            this.iDPLANSDataGridViewTextBoxColumn.HeaderText = "OF/S";
            this.iDPLANSDataGridViewTextBoxColumn.Name = "iDPLANSDataGridViewTextBoxColumn";
            this.iDPLANSDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPLANSDataGridViewTextBoxColumn.Width = 45;
            // 
            // mATERIALDataGridViewTextBoxColumn
            // 
            this.mATERIALDataGridViewTextBoxColumn.DataPropertyName = "MATERIAL";
            this.mATERIALDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.mATERIALDataGridViewTextBoxColumn.Name = "mATERIALDataGridViewTextBoxColumn";
            this.mATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kGFABRICARDataGridViewTextBoxColumn
            // 
            this.kGFABRICARDataGridViewTextBoxColumn.DataPropertyName = "KG_FABRICAR";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.kGFABRICARDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.kGFABRICARDataGridViewTextBoxColumn.HeaderText = "KG Plan";
            this.kGFABRICARDataGridViewTextBoxColumn.Name = "kGFABRICARDataGridViewTextBoxColumn";
            this.kGFABRICARDataGridViewTextBoxColumn.ReadOnly = true;
            this.kGFABRICARDataGridViewTextBoxColumn.Width = 80;
            // 
            // sTATUSDataGridViewTextBoxColumn
            // 
            this.sTATUSDataGridViewTextBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.Name = "sTATUSDataGridViewTextBoxColumn";
            this.sTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fPLANDataGridViewTextBoxColumn
            // 
            this.fPLANDataGridViewTextBoxColumn.DataPropertyName = "FPLAN";
            this.fPLANDataGridViewTextBoxColumn.HeaderText = "Fecha Plan";
            this.fPLANDataGridViewTextBoxColumn.Name = "fPLANDataGridViewTextBoxColumn";
            this.fPLANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kGFabricadosDataGridViewTextBoxColumn
            // 
            this.kGFabricadosDataGridViewTextBoxColumn.DataPropertyName = "KG_Fabricados";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "N2";
            this.kGFabricadosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.kGFabricadosDataGridViewTextBoxColumn.HeaderText = "KG Temp";
            this.kGFabricadosDataGridViewTextBoxColumn.Name = "kGFabricadosDataGridViewTextBoxColumn";
            this.kGFabricadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kGFabricadosDataGridViewTextBoxColumn.ToolTipText = "Kg Ingresados Temporales";
            this.kGFabricadosDataGridViewTextBoxColumn.Width = 80;
            // 
            // Close
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Close.DefaultCellStyle = dataGridViewCellStyle3;
            this.Close.HeaderText = "Cerrar";
            this.Close.Name = "Close";
            this.Close.ReadOnly = true;
            this.Close.Text = "Cerrar";
            this.Close.ToolTipText = "Cerrar Orden de Fabricacion";
            this.Close.UseColumnTextForButtonValue = true;
            this.Close.Width = 50;
            // 
            // FrmPP17CambiarOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 445);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Name = "FrmPP17CambiarOF";
            this.Text = "PP17 - Cambiar OF";
            this.Load += new System.EventHandler(this.FrmPP17CambiarOF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0070PLANPRODUCCIONBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource t0070PLANPRODUCCIONBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn __numeroOF;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPLANSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGFABRICARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPLANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kGFabricadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Close;
    }
}