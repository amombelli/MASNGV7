namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmFI54GestionEntregaRechazos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChequesRech = new System.Windows.Forms.DataGridView();
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
            this.btnDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bsChequesRech = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.bsClientes = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tsUcCustomerSearch11 = new MASngFE._0TSUserControls.TsUcCustomerSearch1();
            this.ckNoEntregados = new TSControls.CtlCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequesRech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChequesRech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChequesRech
            // 
            this.dgvChequesRech.AllowUserToAddRows = false;
            this.dgvChequesRech.AllowUserToDeleteRows = false;
            this.dgvChequesRech.AutoGenerateColumns = false;
            this.dgvChequesRech.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChequesRech.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.tipoLxDataGridViewTextBoxColumn,
            this.btnDetalle});
            this.dgvChequesRech.DataSource = this.bsChequesRech;
            this.dgvChequesRech.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvChequesRech.Location = new System.Drawing.Point(4, 92);
            this.dgvChequesRech.MultiSelect = false;
            this.dgvChequesRech.Name = "dgvChequesRech";
            this.dgvChequesRech.ReadOnly = true;
            this.dgvChequesRech.RowHeadersWidth = 20;
            this.dgvChequesRech.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChequesRech.Size = new System.Drawing.Size(1300, 435);
            this.dgvChequesRech.TabIndex = 12;
            this.dgvChequesRech.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequesRech_CellContentClick);
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
            this.idT400DataGridViewTextBoxColumn.Visible = false;
            this.idT400DataGridViewTextBoxColumn.Width = 50;
            // 
            // IdCtaCte
            // 
            this.IdCtaCte.DataPropertyName = "IdCtaCte";
            this.IdCtaCte.HeaderText = "IdCtaCte";
            this.IdCtaCte.Name = "IdCtaCte";
            this.IdCtaCte.ReadOnly = true;
            this.IdCtaCte.Visible = false;
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
            // btnDetalle
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDetalle.DefaultCellStyle = dataGridViewCellStyle6;
            this.btnDetalle.HeaderText = "Detalle";
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.ReadOnly = true;
            this.btnDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnDetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.ToolTipText = "Ver detalle de Cheque Rechazado";
            this.btnDetalle.UseColumnTextForButtonValue = true;
            this.btnDetalle.Width = 60;
            // 
            // bsChequesRech
            // 
            this.bsChequesRech.DataSource = typeof(TecserEF.Entity.DataStructure.TsChequesRechazados);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1204, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 39);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // bsClientes
            // 
            this.bsClientes.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewButtonColumn1.HeaderText = "Detalle";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "Detalle";
            this.dataGridViewButtonColumn1.ToolTipText = "Ver detalle de Cheque Rechazado";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // tsUcCustomerSearch11
            // 
            this.tsUcCustomerSearch11.ClienteId = null;
            this.tsUcCustomerSearch11.Location = new System.Drawing.Point(4, 3);
            this.tsUcCustomerSearch11.Name = "tsUcCustomerSearch11";
            this.tsUcCustomerSearch11.Size = new System.Drawing.Size(537, 89);
            this.tsUcCustomerSearch11.TabIndex = 14;
            this.tsUcCustomerSearch11.ClienteModificado += new MASngFE._0TSUserControls.TsUcCustomerSearch1.ClienteModificadoEventHandler(this.tsUcCustomerSearch11_ClienteModificado);
            // 
            // ckNoEntregados
            // 
            this.ckNoEntregados.ColorChecked = System.Drawing.Color.LimeGreen;
            this.ckNoEntregados.ColorUnChecked = System.Drawing.Color.IndianRed;
            this.ckNoEntregados.LabelText = "Visualizar SOLO No Entregados";
            this.ckNoEntregados.Location = new System.Drawing.Point(544, 68);
            this.ckNoEntregados.Name = "ckNoEntregados";
            this.ckNoEntregados.Size = new System.Drawing.Size(194, 16);
            this.ckNoEntregados.TabIndex = 13;
            this.ckNoEntregados.Value = false;
            this.ckNoEntregados.CheckedChanged += new System.EventHandler(this.ckNoEntregados_CheckedChanged);
            // 
            // FrmFI54GestionEntregaRechazos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1308, 529);
            this.Controls.Add(this.tsUcCustomerSearch11);
            this.Controls.Add(this.ckNoEntregados);
            this.Controls.Add(this.dgvChequesRech);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmFI54GestionEntregaRechazos";
            this.Text = "FI54 - Gestion de Entrega de Cheques";
            this.Load += new System.EventHandler(this.FrmFI54GestionEntregaRechazos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequesRech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChequesRech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.BindingSource bsChequesRech;
        private System.Windows.Forms.DataGridView dgvChequesRech;
        private TSControls.CtlCheckBox ckNoEntregados;
        private System.Windows.Forms.BindingSource bsClientes;
        private _0TSUserControls.TsUcCustomerSearch1 tsUcCustomerSearch11;
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
        private System.Windows.Forms.DataGridViewButtonColumn btnDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}