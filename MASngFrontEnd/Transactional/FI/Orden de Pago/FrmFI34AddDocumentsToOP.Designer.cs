namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI34AddDocumentsToOP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stxVendorDocPPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvListadoDocumentos = new System.Windows.Forms.DataGridView();
            this.@__idVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__tdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__ndoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__fechaDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__fechaVenci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDeudaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalirOP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stxVendorDocPPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(3, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 418);
            this.LineaIzq.TabIndex = 192;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(3, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(968, 3);
            this.lineaArriba.TabIndex = 191;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtFantasia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 72);
            this.groupBox1.TabIndex = 193;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado de Orden de Pago";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.ckL2);
            this.panel1.Controls.Add(this.ckL1);
            this.panel1.Location = new System.Drawing.Point(431, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 45);
            this.panel1.TabIndex = 197;
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(9, 23);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 19);
            this.ckL2.TabIndex = 197;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(9, 5);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 19);
            this.ckL1.TabIndex = 196;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // txtFantasia
            // 
            this.txtFantasia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFantasia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(115, 44);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(312, 22);
            this.txtFantasia.TabIndex = 194;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 195;
            this.label4.Text = "Nombre Fantasia";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRazonSocial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(115, 21);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(312, 22);
            this.txtRazonSocial.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Razón Social";
            // 
            // stxVendorDocPPBindingSource
            // 
            this.stxVendorDocPPBindingSource.DataSource = typeof(Tecser.Business.Transactional.FI.ContabilizacionProveedores.StxVendorDocPP);
            // 
            // dgvListadoDocumentos
            // 
            this.dgvListadoDocumentos.AllowUserToAddRows = false;
            this.dgvListadoDocumentos.AllowUserToDeleteRows = false;
            this.dgvListadoDocumentos.AutoGenerateColumns = false;
            this.dgvListadoDocumentos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvListadoDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idVendor,
            this.@__tdoc,
            this.@__ndoc,
            this.@__fechaDoc,
            this.@__fechaVenci,
            this.monedaDataGridViewTextBoxColumn,
            this.importeDocDataGridViewTextBoxColumn,
            this.importeDeudaDataGridViewTextBoxColumn,
            this.lxDataGridViewTextBoxColumn,
            this.btn1});
            this.dgvListadoDocumentos.DataSource = this.stxVendorDocPPBindingSource;
            this.dgvListadoDocumentos.Location = new System.Drawing.Point(11, 86);
            this.dgvListadoDocumentos.Name = "dgvListadoDocumentos";
            this.dgvListadoDocumentos.ReadOnly = true;
            this.dgvListadoDocumentos.RowHeadersWidth = 20;
            this.dgvListadoDocumentos.Size = new System.Drawing.Size(648, 324);
            this.dgvListadoDocumentos.TabIndex = 200;
            // 
            // __idVendor
            // 
            this.@__idVendor.DataPropertyName = "IdVendor";
            this.@__idVendor.HeaderText = "IdVendor";
            this.@__idVendor.Name = "__idVendor";
            this.@__idVendor.ReadOnly = true;
            this.@__idVendor.Visible = false;
            // 
            // __tdoc
            // 
            this.@__tdoc.DataPropertyName = "TDoc";
            this.@__tdoc.HeaderText = "TD";
            this.@__tdoc.Name = "__tdoc";
            this.@__tdoc.ReadOnly = true;
            this.@__tdoc.Width = 35;
            // 
            // __ndoc
            // 
            this.@__ndoc.DataPropertyName = "NDoc";
            this.@__ndoc.HeaderText = "Docu #";
            this.@__ndoc.Name = "__ndoc";
            this.@__ndoc.ReadOnly = true;
            this.@__ndoc.Width = 90;
            // 
            // __fechaDoc
            // 
            this.@__fechaDoc.DataPropertyName = "FechaDoc";
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.@__fechaDoc.DefaultCellStyle = dataGridViewCellStyle13;
            this.@__fechaDoc.HeaderText = "Fecha";
            this.@__fechaDoc.Name = "__fechaDoc";
            this.@__fechaDoc.ReadOnly = true;
            this.@__fechaDoc.Width = 80;
            // 
            // __fechaVenci
            // 
            this.@__fechaVenci.DataPropertyName = "FechaVencimiento";
            dataGridViewCellStyle14.Format = "d";
            this.@__fechaVenci.DefaultCellStyle = dataGridViewCellStyle14;
            this.@__fechaVenci.HeaderText = "F.Venc";
            this.@__fechaVenci.Name = "__fechaVenci";
            this.@__fechaVenci.ReadOnly = true;
            this.@__fechaVenci.Width = 80;
            // 
            // monedaDataGridViewTextBoxColumn
            // 
            this.monedaDataGridViewTextBoxColumn.DataPropertyName = "Moneda";
            this.monedaDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.monedaDataGridViewTextBoxColumn.Name = "monedaDataGridViewTextBoxColumn";
            this.monedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.monedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // importeDocDataGridViewTextBoxColumn
            // 
            this.importeDocDataGridViewTextBoxColumn.DataPropertyName = "ImporteDoc";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.Format = "C2";
            this.importeDocDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.importeDocDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDocDataGridViewTextBoxColumn.Name = "importeDocDataGridViewTextBoxColumn";
            this.importeDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeDeudaDataGridViewTextBoxColumn
            // 
            this.importeDeudaDataGridViewTextBoxColumn.DataPropertyName = "ImporteDeuda";
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle16.Format = "C2";
            this.importeDeudaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.importeDeudaDataGridViewTextBoxColumn.HeaderText = "Saldo Pend";
            this.importeDeudaDataGridViewTextBoxColumn.Name = "importeDeudaDataGridViewTextBoxColumn";
            this.importeDeudaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lxDataGridViewTextBoxColumn
            // 
            this.lxDataGridViewTextBoxColumn.DataPropertyName = "Lx";
            this.lxDataGridViewTextBoxColumn.HeaderText = "Lx";
            this.lxDataGridViewTextBoxColumn.Name = "lxDataGridViewTextBoxColumn";
            this.lxDataGridViewTextBoxColumn.ReadOnly = true;
            this.lxDataGridViewTextBoxColumn.Width = 30;
            // 
            // btn1
            // 
            this.btn1.HeaderText = "Accion";
            this.btn1.Name = "btn1";
            this.btn1.ReadOnly = true;
            this.btn1.Text = "Agregar";
            this.btn1.ToolTipText = "Agregar documento a Orden de Pago";
            this.btn1.UseColumnTextForButtonValue = true;
            this.btn1.Width = 50;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(968, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 418);
            this.label2.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkBlue;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(3, 418);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(968, 3);
            this.label3.TabIndex = 202;
            // 
            // btnSalirOP
            // 
            this.btnSalirOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalirOP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirOP.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalirOP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirOP.Location = new System.Drawing.Point(837, 86);
            this.btnSalirOP.Name = "btnSalirOP";
            this.btnSalirOP.Size = new System.Drawing.Size(117, 46);
            this.btnSalirOP.TabIndex = 203;
            this.btnSalirOP.Text = "Salir";
            this.btnSalirOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalirOP.UseVisualStyleBackColor = true;
            this.btnSalirOP.Click += new System.EventHandler(this.btnSalirOP_Click);
            // 
            // FrmFI34AddDocumentsToOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 424);
            this.Controls.Add(this.btnSalirOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListadoDocumentos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFI34AddDocumentsToOP";
            this.Text = "FI34 - Add Documents to OP";
            this.Load += new System.EventHandler(this.FrmFI34AddDocumentsToOP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stxVendorDocPPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource stxVendorDocPPBindingSource;
        private System.Windows.Forms.DataGridView dgvListadoDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn __tdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn __ndoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn __fechaDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn __fechaVenci;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDeudaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalirOP;
    }
}