namespace MASngFE.Transactional.HR
{
    partial class FrmHR08PagoAdelantos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHR08PagoAdelantos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0525SueldoAdelantoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idAdelantoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoSolicitadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAbonadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAdeudado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acuerdoDePagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0525SueldoAdelantoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAdelantoDataGridViewTextBoxColumn,
            this.fechaSolicitudDataGridViewTextBoxColumn,
            this.shortnameDataGridViewTextBoxColumn,
            this.montoSolicitadoDataGridViewTextBoxColumn,
            this.montoAbonadoDataGridViewTextBoxColumn,
            this.fechaPagoDataGridViewTextBoxColumn,
            this.MontoAdeudado,
            this.comentarioDataGridViewTextBoxColumn,
            this.acuerdoDePagoDataGridViewTextBoxColumn,
            this.Ver});
            this.dgvDetalle.DataSource = this.t0525SueldoAdelantoBindingSource;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 62);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(872, 376);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(1025, 57);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 44);
            this.btnEnviar.TabIndex = 49;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1025, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 44);
            this.btnSalir.TabIndex = 48;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Ver";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.ToolTipText = "Visualizar Detalles";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // t0525SueldoAdelantoBindingSource
            // 
            this.t0525SueldoAdelantoBindingSource.DataSource = typeof(TecserEF.Entity.T0525_SueldoAdelanto);
            // 
            // idAdelantoDataGridViewTextBoxColumn
            // 
            this.idAdelantoDataGridViewTextBoxColumn.DataPropertyName = "idAdelanto";
            this.idAdelantoDataGridViewTextBoxColumn.HeaderText = "#";
            this.idAdelantoDataGridViewTextBoxColumn.Name = "idAdelantoDataGridViewTextBoxColumn";
            this.idAdelantoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAdelantoDataGridViewTextBoxColumn.Width = 30;
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            this.fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "FechaSolicitud";
            this.fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            this.fechaSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaSolicitudDataGridViewTextBoxColumn.Width = 80;
            // 
            // shortnameDataGridViewTextBoxColumn
            // 
            this.shortnameDataGridViewTextBoxColumn.DataPropertyName = "Shortname";
            this.shortnameDataGridViewTextBoxColumn.HeaderText = "Empleado";
            this.shortnameDataGridViewTextBoxColumn.Name = "shortnameDataGridViewTextBoxColumn";
            this.shortnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.shortnameDataGridViewTextBoxColumn.Width = 80;
            // 
            // montoSolicitadoDataGridViewTextBoxColumn
            // 
            this.montoSolicitadoDataGridViewTextBoxColumn.DataPropertyName = "MontoSolicitado";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.montoSolicitadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.montoSolicitadoDataGridViewTextBoxColumn.HeaderText = "Pedido";
            this.montoSolicitadoDataGridViewTextBoxColumn.Name = "montoSolicitadoDataGridViewTextBoxColumn";
            this.montoSolicitadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoSolicitadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // montoAbonadoDataGridViewTextBoxColumn
            // 
            this.montoAbonadoDataGridViewTextBoxColumn.DataPropertyName = "MontoAbonado";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.montoAbonadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoAbonadoDataGridViewTextBoxColumn.HeaderText = "Abonado";
            this.montoAbonadoDataGridViewTextBoxColumn.Name = "montoAbonadoDataGridViewTextBoxColumn";
            this.montoAbonadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAbonadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaPagoDataGridViewTextBoxColumn
            // 
            this.fechaPagoDataGridViewTextBoxColumn.DataPropertyName = "FechaPago";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaPagoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaPagoDataGridViewTextBoxColumn.HeaderText = "F.Pago";
            this.fechaPagoDataGridViewTextBoxColumn.Name = "fechaPagoDataGridViewTextBoxColumn";
            this.fechaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaPagoDataGridViewTextBoxColumn.Width = 80;
            // 
            // MontoAdeudado
            // 
            this.MontoAdeudado.DataPropertyName = "MontoAdeudado";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.MontoAdeudado.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoAdeudado.HeaderText = "Adeudado";
            this.MontoAdeudado.Name = "MontoAdeudado";
            this.MontoAdeudado.ReadOnly = true;
            this.MontoAdeudado.Width = 80;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // acuerdoDePagoDataGridViewTextBoxColumn
            // 
            this.acuerdoDePagoDataGridViewTextBoxColumn.DataPropertyName = "AcuerdoDePago";
            this.acuerdoDePagoDataGridViewTextBoxColumn.HeaderText = "Acc.Pago";
            this.acuerdoDePagoDataGridViewTextBoxColumn.Name = "acuerdoDePagoDataGridViewTextBoxColumn";
            this.acuerdoDePagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.acuerdoDePagoDataGridViewTextBoxColumn.Width = 150;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Text = "VER";
            this.Ver.ToolTipText = "Visualizar Detalles";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 60;
            // 
            // FrmHR08PagoAdelantos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 450);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvDetalle);
            this.Name = "FrmHR08PagoAdelantos";
            this.Text = "HR08 - Pago de Adelantos";
            this.Load += new System.EventHandler(this.FrmHR08PagoAdelantos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0525SueldoAdelantoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource t0525SueldoAdelantoBindingSource;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAdelantoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoSolicitadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAbonadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAdeudado;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acuerdoDePagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}