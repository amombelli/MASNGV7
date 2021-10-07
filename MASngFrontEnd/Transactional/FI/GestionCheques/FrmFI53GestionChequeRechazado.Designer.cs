namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmFI53GestionChequeRechazado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI53GestionChequeRechazado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevaContabilizacion = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bsChequesRech = new System.Windows.Forms.BindingSource(this.components);
            this.ctlCheckBox1 = new TSControls.CtlCheckBox();
            this.idchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAcreditacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRechazoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bancoShortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoRechazoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroNdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idT400DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCtaCte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoNdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EntregadoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoLxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChequesRech)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1167, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 39);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevaContabilizacion
            // 
            this.btnNuevaContabilizacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaContabilizacion.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaContabilizacion.Image")));
            this.btnNuevaContabilizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaContabilizacion.Location = new System.Drawing.Point(1167, 51);
            this.btnNuevaContabilizacion.Name = "btnNuevaContabilizacion";
            this.btnNuevaContabilizacion.Size = new System.Drawing.Size(100, 39);
            this.btnNuevaContabilizacion.TabIndex = 9;
            this.btnNuevaContabilizacion.Text = "Nueva\r\nCONTA";
            this.btnNuevaContabilizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaContabilizacion.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idchequeDataGridViewTextBoxColumn,
            this.clienteRsDataGridViewTextBoxColumn,
            this.fechaAcreditacionDataGridViewTextBoxColumn,
            this.fechaRechazoDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.bancoShortDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn,
            this.motivoRechazoDataGridViewTextBoxColumn,
            this.numeroNdDataGridViewTextBoxColumn,
            this.idT400DataGridViewTextBoxColumn,
            this.IdCtaCte,
            this.saldoNdDataGridViewTextBoxColumn,
            this.Entregado,
            this.EntregadoPor,
            this.FechaEntregado,
            this.tipoLxDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsChequesRech;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(1142, 467);
            this.dataGridView1.TabIndex = 11;
            // 
            // bsChequesRech
            // 
            this.bsChequesRech.DataSource = typeof(TecserEF.Entity.DataStructure.TsChequesRechazados);
            // 
            // ctlCheckBox1
            // 
            this.ctlCheckBox1.ColorChecked = System.Drawing.Color.LimeGreen;
            this.ctlCheckBox1.ColorUnChecked = System.Drawing.Color.IndianRed;
            this.ctlCheckBox1.LabelText = "Visualizar No Entregados";
            this.ctlCheckBox1.Location = new System.Drawing.Point(13, 24);
            this.ctlCheckBox1.Name = "ctlCheckBox1";
            this.ctlCheckBox1.Size = new System.Drawing.Size(176, 16);
            this.ctlCheckBox1.TabIndex = 10;
            this.ctlCheckBox1.Value = false;
            // 
            // idchequeDataGridViewTextBoxColumn
            // 
            this.idchequeDataGridViewTextBoxColumn.DataPropertyName = "Idcheque";
            this.idchequeDataGridViewTextBoxColumn.HeaderText = "Idcheque";
            this.idchequeDataGridViewTextBoxColumn.Name = "idchequeDataGridViewTextBoxColumn";
            this.idchequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idchequeDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteRsDataGridViewTextBoxColumn
            // 
            this.clienteRsDataGridViewTextBoxColumn.DataPropertyName = "ClienteRs";
            this.clienteRsDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteRsDataGridViewTextBoxColumn.Name = "clienteRsDataGridViewTextBoxColumn";
            this.clienteRsDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRsDataGridViewTextBoxColumn.Width = 180;
            // 
            // fechaAcreditacionDataGridViewTextBoxColumn
            // 
            this.fechaAcreditacionDataGridViewTextBoxColumn.DataPropertyName = "FechaAcreditacion";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaAcreditacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaAcreditacionDataGridViewTextBoxColumn.HeaderText = "Fecha Cheque";
            this.fechaAcreditacionDataGridViewTextBoxColumn.Name = "fechaAcreditacionDataGridViewTextBoxColumn";
            this.fechaAcreditacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRechazoDataGridViewTextBoxColumn
            // 
            this.fechaRechazoDataGridViewTextBoxColumn.DataPropertyName = "FechaRechazo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "d";
            this.fechaRechazoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaRechazoDataGridViewTextBoxColumn.HeaderText = "Fecha Rech";
            this.fechaRechazoDataGridViewTextBoxColumn.Name = "fechaRechazoDataGridViewTextBoxColumn";
            this.fechaRechazoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Che #";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroDataGridViewTextBoxColumn.Width = 60;
            // 
            // bancoShortDataGridViewTextBoxColumn
            // 
            this.bancoShortDataGridViewTextBoxColumn.DataPropertyName = "BancoShort";
            this.bancoShortDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoShortDataGridViewTextBoxColumn.Name = "bancoShortDataGridViewTextBoxColumn";
            this.bancoShortDataGridViewTextBoxColumn.ReadOnly = true;
            this.bancoShortDataGridViewTextBoxColumn.Width = 150;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            this.importeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeDataGridViewTextBoxColumn.Width = 80;
            // 
            // motivoRechazoDataGridViewTextBoxColumn
            // 
            this.motivoRechazoDataGridViewTextBoxColumn.DataPropertyName = "MotivoRechazo";
            this.motivoRechazoDataGridViewTextBoxColumn.HeaderText = "MotivoRechazo";
            this.motivoRechazoDataGridViewTextBoxColumn.Name = "motivoRechazoDataGridViewTextBoxColumn";
            this.motivoRechazoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroNdDataGridViewTextBoxColumn
            // 
            this.numeroNdDataGridViewTextBoxColumn.DataPropertyName = "NumeroNd";
            this.numeroNdDataGridViewTextBoxColumn.HeaderText = "NumeroNd";
            this.numeroNdDataGridViewTextBoxColumn.Name = "numeroNdDataGridViewTextBoxColumn";
            this.numeroNdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idT400DataGridViewTextBoxColumn
            // 
            this.idT400DataGridViewTextBoxColumn.DataPropertyName = "IdT400";
            this.idT400DataGridViewTextBoxColumn.HeaderText = "IdT400";
            this.idT400DataGridViewTextBoxColumn.Name = "idT400DataGridViewTextBoxColumn";
            this.idT400DataGridViewTextBoxColumn.ReadOnly = true;
            this.idT400DataGridViewTextBoxColumn.Width = 50;
            // 
            // IdCtaCte
            // 
            this.IdCtaCte.DataPropertyName = "IdCtaCte";
            this.IdCtaCte.HeaderText = "IdCtaCte";
            this.IdCtaCte.Name = "IdCtaCte";
            this.IdCtaCte.ReadOnly = true;
            this.IdCtaCte.Width = 50;
            // 
            // saldoNdDataGridViewTextBoxColumn
            // 
            this.saldoNdDataGridViewTextBoxColumn.DataPropertyName = "SaldoNd";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.saldoNdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.saldoNdDataGridViewTextBoxColumn.HeaderText = "SaldoNd";
            this.saldoNdDataGridViewTextBoxColumn.Name = "saldoNdDataGridViewTextBoxColumn";
            this.saldoNdDataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoNdDataGridViewTextBoxColumn.Width = 80;
            // 
            // Entregado
            // 
            this.Entregado.DataPropertyName = "Entregado";
            this.Entregado.HeaderText = "Entreg";
            this.Entregado.Name = "Entregado";
            this.Entregado.ReadOnly = true;
            this.Entregado.Width = 50;
            // 
            // EntregadoPor
            // 
            this.EntregadoPor.DataPropertyName = "EntregadoPor";
            this.EntregadoPor.HeaderText = "EntrePor";
            this.EntregadoPor.Name = "EntregadoPor";
            this.EntregadoPor.ReadOnly = true;
            // 
            // FechaEntregado
            // 
            this.FechaEntregado.DataPropertyName = "FechaEntregado";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.FechaEntregado.DefaultCellStyle = dataGridViewCellStyle5;
            this.FechaEntregado.HeaderText = "FechaEntre";
            this.FechaEntregado.Name = "FechaEntregado";
            this.FechaEntregado.ReadOnly = true;
            this.FechaEntregado.Width = 80;
            // 
            // tipoLxDataGridViewTextBoxColumn
            // 
            this.tipoLxDataGridViewTextBoxColumn.DataPropertyName = "TipoLx";
            this.tipoLxDataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tipoLxDataGridViewTextBoxColumn.Name = "tipoLxDataGridViewTextBoxColumn";
            this.tipoLxDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoLxDataGridViewTextBoxColumn.Width = 30;
            // 
            // FrmFI53GestionChequeRechazado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 608);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ctlCheckBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevaContabilizacion);
            this.Name = "FrmFI53GestionChequeRechazado";
            this.Text = "FI53 - Gestion de Cheques Rechazados";
            this.Load += new System.EventHandler(this.FrmFI53GestionChequeRechazado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChequesRech)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevaContabilizacion;
        private TSControls.CtlCheckBox ctlCheckBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsChequesRech;
        private System.Windows.Forms.DataGridViewTextBoxColumn idchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAcreditacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRechazoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoShortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoRechazoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroNdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idT400DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCtaCte;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoNdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregadoPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoLxDataGridViewTextBoxColumn;
    }
}