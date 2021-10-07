namespace MASngFE.MasterData.NEL
{
    partial class FrmQm01NelSearch
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
            this.dgvDetalleNels = new System.Windows.Forms.DataGridView();
            this.nELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDesarrolloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDesarrolloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NelBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevoNel = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.ckFinalizado = new System.Windows.Forms.CheckBox();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.ckCancelado = new System.Windows.Forms.CheckBox();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.ckRechazado = new System.Windows.Forms.CheckBox();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.ckAprobado = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ckEsperando = new System.Windows.Forms.CheckBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.ckProvisorio = new System.Windows.Forms.CheckBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.ckProceso = new System.Windows.Forms.CheckBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.ckIngresado = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NelBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalleNels
            // 
            this.dgvDetalleNels.AllowUserToAddRows = false;
            this.dgvDetalleNels.AllowUserToDeleteRows = false;
            this.dgvDetalleNels.AutoGenerateColumns = false;
            this.dgvDetalleNels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleNels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nELDataGridViewTextBoxColumn,
            this.clienteDescripcionDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.colorDesarrolloDataGridViewTextBoxColumn,
            this.estadoDesarrolloDataGridViewTextBoxColumn,
            this.Detalle,
            this.Ver});
            this.dgvDetalleNels.DataSource = this.NelBs;
            this.dgvDetalleNels.Location = new System.Drawing.Point(6, 117);
            this.dgvDetalleNels.Name = "dgvDetalleNels";
            this.dgvDetalleNels.ReadOnly = true;
            this.dgvDetalleNels.Size = new System.Drawing.Size(592, 328);
            this.dgvDetalleNels.TabIndex = 0;
            this.dgvDetalleNels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNels_CellContentClick);
            // 
            // nELDataGridViewTextBoxColumn
            // 
            this.nELDataGridViewTextBoxColumn.DataPropertyName = "NEL";
            this.nELDataGridViewTextBoxColumn.HeaderText = "NEL";
            this.nELDataGridViewTextBoxColumn.Name = "nELDataGridViewTextBoxColumn";
            this.nELDataGridViewTextBoxColumn.ReadOnly = true;
            this.nELDataGridViewTextBoxColumn.Width = 50;
            // 
            // clienteDescripcionDataGridViewTextBoxColumn
            // 
            this.clienteDescripcionDataGridViewTextBoxColumn.DataPropertyName = "ClienteDescripcion";
            this.clienteDescripcionDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDescripcionDataGridViewTextBoxColumn.Name = "clienteDescripcionDataGridViewTextBoxColumn";
            this.clienteDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDescripcionDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechaIngresoDataGridViewTextBoxColumn
            // 
            this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "FechaIngreso";
            this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "FechaIn";
            this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
            this.fechaIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaIngresoDataGridViewTextBoxColumn.Width = 70;
            // 
            // colorDesarrolloDataGridViewTextBoxColumn
            // 
            this.colorDesarrolloDataGridViewTextBoxColumn.DataPropertyName = "ColorDesarrollo";
            this.colorDesarrolloDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDesarrolloDataGridViewTextBoxColumn.Name = "colorDesarrolloDataGridViewTextBoxColumn";
            this.colorDesarrolloDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorDesarrolloDataGridViewTextBoxColumn.Width = 50;
            // 
            // estadoDesarrolloDataGridViewTextBoxColumn
            // 
            this.estadoDesarrolloDataGridViewTextBoxColumn.DataPropertyName = "EstadoDesarrollo";
            this.estadoDesarrolloDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDesarrolloDataGridViewTextBoxColumn.Name = "estadoDesarrolloDataGridViewTextBoxColumn";
            this.estadoDesarrolloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Editar";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "Editar";
            this.Detalle.ToolTipText = "Editar";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 60;
            // 
            // Ver
            // 
            this.Ver.DataPropertyName = "NEL";
            this.Ver.HeaderText = "Ver";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Text = "Ver";
            this.Ver.ToolTipText = "Ver";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 60;
            // 
            // NelBs
            // 
            this.NelBs.DataSource = typeof(TecserEF.Entity.T0099_NELS);
            // 
            // btnNuevoNel
            // 
            this.btnNuevoNel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoNel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoNel.Location = new System.Drawing.Point(604, 157);
            this.btnNuevoNel.Name = "btnNuevoNel";
            this.btnNuevoNel.Size = new System.Drawing.Size(100, 40);
            this.btnNuevoNel.TabIndex = 26;
            this.btnNuevoNel.Text = "NUEVO\r\nNEL";
            this.btnNuevoNel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoNel.UseVisualStyleBackColor = true;
            this.btnNuevoNel.Click += new System.EventHandler(this.btnNuevoNel_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(604, 117);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabel5);
            this.panel1.Controls.Add(this.ckFinalizado);
            this.panel1.Controls.Add(this.linkLabel6);
            this.panel1.Controls.Add(this.ckCancelado);
            this.panel1.Controls.Add(this.linkLabel7);
            this.panel1.Controls.Add(this.ckRechazado);
            this.panel1.Controls.Add(this.linkLabel8);
            this.panel1.Controls.Add(this.ckAprobado);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.ckEsperando);
            this.panel1.Controls.Add(this.linkLabel4);
            this.panel1.Controls.Add(this.ckProvisorio);
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.ckProceso);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.ckIngresado);
            this.panel1.Location = new System.Drawing.Point(287, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 84);
            this.panel1.TabIndex = 28;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(187, 63);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(54, 13);
            this.linkLabel5.TabIndex = 44;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Finalizado";
            // 
            // ckFinalizado
            // 
            this.ckFinalizado.AutoSize = true;
            this.ckFinalizado.BackColor = System.Drawing.Color.Tan;
            this.ckFinalizado.Location = new System.Drawing.Point(169, 63);
            this.ckFinalizado.Name = "ckFinalizado";
            this.ckFinalizado.Size = new System.Drawing.Size(15, 14);
            this.ckFinalizado.TabIndex = 43;
            this.ckFinalizado.UseVisualStyleBackColor = false;
            this.ckFinalizado.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(187, 45);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(58, 13);
            this.linkLabel6.TabIndex = 42;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Cancelado";
            // 
            // ckCancelado
            // 
            this.ckCancelado.AutoSize = true;
            this.ckCancelado.BackColor = System.Drawing.Color.Tan;
            this.ckCancelado.Location = new System.Drawing.Point(169, 45);
            this.ckCancelado.Name = "ckCancelado";
            this.ckCancelado.Size = new System.Drawing.Size(15, 14);
            this.ckCancelado.TabIndex = 41;
            this.ckCancelado.UseVisualStyleBackColor = false;
            this.ckCancelado.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(187, 27);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(62, 13);
            this.linkLabel7.TabIndex = 40;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Rechazado";
            // 
            // ckRechazado
            // 
            this.ckRechazado.AutoSize = true;
            this.ckRechazado.BackColor = System.Drawing.Color.Tan;
            this.ckRechazado.Location = new System.Drawing.Point(169, 27);
            this.ckRechazado.Name = "ckRechazado";
            this.ckRechazado.Size = new System.Drawing.Size(15, 14);
            this.ckRechazado.TabIndex = 39;
            this.ckRechazado.UseVisualStyleBackColor = false;
            this.ckRechazado.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(187, 9);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(56, 13);
            this.linkLabel8.TabIndex = 38;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "Aprobado!";
            // 
            // ckAprobado
            // 
            this.ckAprobado.AutoSize = true;
            this.ckAprobado.BackColor = System.Drawing.Color.Tan;
            this.ckAprobado.Location = new System.Drawing.Point(169, 9);
            this.ckAprobado.Name = "ckAprobado";
            this.ckAprobado.Size = new System.Drawing.Size(15, 14);
            this.ckAprobado.TabIndex = 37;
            this.ckAprobado.UseVisualStyleBackColor = false;
            this.ckAprobado.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(23, 62);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Esperando Respuesta";
            // 
            // ckEsperando
            // 
            this.ckEsperando.AutoSize = true;
            this.ckEsperando.BackColor = System.Drawing.Color.Tan;
            this.ckEsperando.Location = new System.Drawing.Point(5, 62);
            this.ckEsperando.Name = "ckEsperando";
            this.ckEsperando.Size = new System.Drawing.Size(15, 14);
            this.ckEsperando.TabIndex = 35;
            this.ckEsperando.UseVisualStyleBackColor = false;
            this.ckEsperando.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(23, 44);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(111, 13);
            this.linkLabel4.TabIndex = 34;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Con Codigo Provisorio";
            // 
            // ckProvisorio
            // 
            this.ckProvisorio.AutoSize = true;
            this.ckProvisorio.BackColor = System.Drawing.Color.Tan;
            this.ckProvisorio.Location = new System.Drawing.Point(5, 44);
            this.ckProvisorio.Name = "ckProvisorio";
            this.ckProvisorio.Size = new System.Drawing.Size(15, 14);
            this.ckProvisorio.TabIndex = 33;
            this.ckProvisorio.UseVisualStyleBackColor = false;
            this.ckProvisorio.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(23, 26);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(62, 13);
            this.linkLabel3.TabIndex = 32;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "En Proceso";
            // 
            // ckProceso
            // 
            this.ckProceso.AutoSize = true;
            this.ckProceso.BackColor = System.Drawing.Color.Tan;
            this.ckProceso.Location = new System.Drawing.Point(5, 26);
            this.ckProceso.Name = "ckProceso";
            this.ckProceso.Size = new System.Drawing.Size(15, 14);
            this.ckProceso.TabIndex = 31;
            this.ckProceso.UseVisualStyleBackColor = false;
            this.ckProceso.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(23, 8);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(54, 13);
            this.linkLabel2.TabIndex = 30;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Ingresado";
            // 
            // ckIngresado
            // 
            this.ckIngresado.AutoSize = true;
            this.ckIngresado.BackColor = System.Drawing.Color.Tan;
            this.ckIngresado.Location = new System.Drawing.Point(5, 8);
            this.ckIngresado.Name = "ckIngresado";
            this.ckIngresado.Size = new System.Drawing.Size(15, 14);
            this.ckIngresado.TabIndex = 29;
            this.ckIngresado.UseVisualStyleBackColor = false;
            this.ckIngresado.CheckedChanged += new System.EventHandler(this.ckEsperando_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(11, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Numero NEL";
            // 
            // txtNel
            // 
            this.txtNel.BackColor = System.Drawing.Color.White;
            this.txtNel.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNel.Location = new System.Drawing.Point(100, 11);
            this.txtNel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNel.Name = "txtNel";
            this.txtNel.Size = new System.Drawing.Size(93, 20);
            this.txtNel.TabIndex = 29;
            this.txtNel.TextChanged += new System.EventHandler(this.txtNel_TextChanged);
            this.txtNel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNel_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 32;
            // 
            // FrmQM01NelSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNuevoNel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvDetalleNels);
            this.Name = "FrmQm01NelSearch";
            this.Text = "QM01 - Busqueda de NEL";
            this.Load += new System.EventHandler(this.FrmNelSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NelBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalleNels;
        private System.Windows.Forms.BindingSource NelBs;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevoNel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDesarrolloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDesarrolloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.CheckBox ckFinalizado;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.CheckBox ckCancelado;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.CheckBox ckRechazado;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.CheckBox ckAprobado;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox ckEsperando;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.CheckBox ckProvisorio;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.CheckBox ckProceso;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.CheckBox ckIngresado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNel;
        private System.Windows.Forms.Label label1;
    }
}