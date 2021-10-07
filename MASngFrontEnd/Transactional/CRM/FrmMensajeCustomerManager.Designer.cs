namespace MASngFE.Transactional.CRM
{
    partial class FrmMensajeCustomerManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClienteFantasia = new System.Windows.Forms.ComboBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dgvHistoria = new System.Windows.Forms.DataGridView();
            this.txtCreadoPor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreadoFecha = new System.Windows.Forms.TextBox();
            this.txtRespondidoFecha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRespondidoPor = new System.Windows.Forms.TextBox();
            this.btnNuevoMensaje = new System.Windows.Forms.Button();
            this.btnNuevaRespuesta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckNotaPedido = new System.Windows.Forms.CheckBox();
            this.ckRegistroActivo = new System.Windows.Forms.CheckBox();
            this.ckCtaCte = new System.Windows.Forms.CheckBox();
            this.ckCRM = new System.Windows.Forms.CheckBox();
            this.ckFactura = new System.Windows.Forms.CheckBox();
            this.ckRemito = new System.Windows.Forms.CheckBox();
            this.ckGesco = new System.Windows.Forms.CheckBox();
            this.CustomerMsgBS = new System.Windows.Forms.BindingSource(this.components);
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeDesactivadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDesactivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerActiveMsgBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerMsgBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerActiveMsgBS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTE FANTASIA";
            // 
            // cmbClienteFantasia
            // 
            this.cmbClienteFantasia.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.cmbClienteFantasia.FormattingEnabled = true;
            this.cmbClienteFantasia.Location = new System.Drawing.Point(104, 15);
            this.cmbClienteFantasia.Name = "cmbClienteFantasia";
            this.cmbClienteFantasia.Size = new System.Drawing.Size(264, 21);
            this.cmbClienteFantasia.TabIndex = 1;
            this.cmbClienteFantasia.SelectedValueChanged += new System.EventHandler(this.cmbClienteFantasia_SelectedValueChanged);
            // 
            // txtMensaje
            // 
            this.txtMensaje.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "Mensaje", true));
            this.txtMensaje.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.Blue;
            this.txtMensaje.Location = new System.Drawing.Point(104, 38);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(264, 82);
            this.txtMensaje.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MENSAJE >>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "RESPUESTA >>";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.BackColor = System.Drawing.Color.Silver;
            this.txtRespuesta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "MensajeDesactivado", true));
            this.txtRespuesta.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRespuesta.Location = new System.Drawing.Point(104, 190);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(264, 82);
            this.txtRespuesta.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(104, 279);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "DESACTIVAR MENSAJE";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dgvHistoria
            // 
            this.dgvHistoria.AllowUserToAddRows = false;
            this.dgvHistoria.AllowUserToDeleteRows = false;
            this.dgvHistoria.AutoGenerateColumns = false;
            this.dgvHistoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClienteDataGridViewTextBoxColumn,
            this.mensajeDataGridViewTextBoxColumn,
            this.logDateDataGridViewTextBoxColumn,
            this.mensajeDesactivadoDataGridViewTextBoxColumn,
            this.logDateDesactivoDataGridViewTextBoxColumn});
            this.dgvHistoria.DataSource = this.CustomerMsgBS;
            this.dgvHistoria.Location = new System.Drawing.Point(15, 302);
            this.dgvHistoria.Name = "dgvHistoria";
            this.dgvHistoria.ReadOnly = true;
            this.dgvHistoria.Size = new System.Drawing.Size(720, 189);
            this.dgvHistoria.TabIndex = 7;
            // 
            // txtCreadoPor
            // 
            this.txtCreadoPor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "LogUser", true));
            this.txtCreadoPor.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtCreadoPor.Location = new System.Drawing.Point(467, 39);
            this.txtCreadoPor.Name = "txtCreadoPor";
            this.txtCreadoPor.ReadOnly = true;
            this.txtCreadoPor.Size = new System.Drawing.Size(143, 21);
            this.txtCreadoPor.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label4.Location = new System.Drawing.Point(374, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Creado Por";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label5.Location = new System.Drawing.Point(374, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Creado Fecha";
            // 
            // txtCreadoFecha
            // 
            this.txtCreadoFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "LogDate", true));
            this.txtCreadoFecha.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtCreadoFecha.Location = new System.Drawing.Point(467, 63);
            this.txtCreadoFecha.Name = "txtCreadoFecha";
            this.txtCreadoFecha.ReadOnly = true;
            this.txtCreadoFecha.Size = new System.Drawing.Size(108, 21);
            this.txtCreadoFecha.TabIndex = 11;
            // 
            // txtRespondidoFecha
            // 
            this.txtRespondidoFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "LogDateDesactivo", true));
            this.txtRespondidoFecha.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtRespondidoFecha.Location = new System.Drawing.Point(467, 214);
            this.txtRespondidoFecha.Name = "txtRespondidoFecha";
            this.txtRespondidoFecha.ReadOnly = true;
            this.txtRespondidoFecha.Size = new System.Drawing.Size(97, 21);
            this.txtRespondidoFecha.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label6.Location = new System.Drawing.Point(374, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Respondido Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label7.Location = new System.Drawing.Point(374, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Respondido Por";
            // 
            // txtRespondidoPor
            // 
            this.txtRespondidoPor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerActiveMsgBS, "LogUserDesactivo", true));
            this.txtRespondidoPor.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtRespondidoPor.Location = new System.Drawing.Point(467, 190);
            this.txtRespondidoPor.Name = "txtRespondidoPor";
            this.txtRespondidoPor.ReadOnly = true;
            this.txtRespondidoPor.Size = new System.Drawing.Size(143, 21);
            this.txtRespondidoPor.TabIndex = 12;
            // 
            // btnNuevoMensaje
            // 
            this.btnNuevoMensaje.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnNuevoMensaje.Location = new System.Drawing.Point(772, 30);
            this.btnNuevoMensaje.Name = "btnNuevoMensaje";
            this.btnNuevoMensaje.Size = new System.Drawing.Size(87, 34);
            this.btnNuevoMensaje.TabIndex = 16;
            this.btnNuevoMensaje.Text = "Nuevo Mensaje";
            this.btnNuevoMensaje.UseVisualStyleBackColor = true;
            this.btnNuevoMensaje.Click += new System.EventHandler(this.btnNuevoMensaje_Click);
            // 
            // btnNuevaRespuesta
            // 
            this.btnNuevaRespuesta.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnNuevaRespuesta.Location = new System.Drawing.Point(772, 66);
            this.btnNuevaRespuesta.Name = "btnNuevaRespuesta";
            this.btnNuevaRespuesta.Size = new System.Drawing.Size(87, 34);
            this.btnNuevaRespuesta.TabIndex = 17;
            this.btnNuevaRespuesta.Text = "Nueva Respuesta";
            this.btnNuevaRespuesta.UseVisualStyleBackColor = true;
            this.btnNuevaRespuesta.Click += new System.EventHandler(this.btnNuevaRespuesta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnSalir.Location = new System.Drawing.Point(772, 103);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 34);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ckNotaPedido
            // 
            this.ckNotaPedido.AutoSize = true;
            this.ckNotaPedido.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerNotaPedido", true));
            this.ckNotaPedido.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNotaPedido.Location = new System.Drawing.Point(104, 127);
            this.ckNotaPedido.Name = "ckNotaPedido";
            this.ckNotaPedido.Size = new System.Drawing.Size(83, 17);
            this.ckNotaPedido.TabIndex = 19;
            this.ckNotaPedido.Text = "Nota Pedido";
            this.ckNotaPedido.UseVisualStyleBackColor = true;
            // 
            // ckRegistroActivo
            // 
            this.ckRegistroActivo.AutoSize = true;
            this.ckRegistroActivo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "Activo", true));
            this.ckRegistroActivo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRegistroActivo.Location = new System.Drawing.Point(468, 88);
            this.ckRegistroActivo.Name = "ckRegistroActivo";
            this.ckRegistroActivo.Size = new System.Drawing.Size(107, 17);
            this.ckRegistroActivo.TabIndex = 20;
            this.ckRegistroActivo.Text = "REGISTRO ACTIVO";
            this.ckRegistroActivo.UseVisualStyleBackColor = true;
            // 
            // ckCtaCte
            // 
            this.ckCtaCte.AutoSize = true;
            this.ckCtaCte.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerCuentaCorriente", true));
            this.ckCtaCte.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCtaCte.Location = new System.Drawing.Point(312, 144);
            this.ckCtaCte.Name = "ckCtaCte";
            this.ckCtaCte.Size = new System.Drawing.Size(57, 17);
            this.ckCtaCte.TabIndex = 21;
            this.ckCtaCte.Text = "CtaCte";
            this.ckCtaCte.UseVisualStyleBackColor = true;
            // 
            // ckCRM
            // 
            this.ckCRM.AutoSize = true;
            this.ckCRM.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerCRM", true));
            this.ckCRM.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCRM.Location = new System.Drawing.Point(207, 144);
            this.ckCRM.Name = "ckCRM";
            this.ckCRM.Size = new System.Drawing.Size(48, 17);
            this.ckCRM.TabIndex = 22;
            this.ckCRM.Text = "CRM";
            this.ckCRM.UseVisualStyleBackColor = true;
            // 
            // ckFactura
            // 
            this.ckFactura.AutoSize = true;
            this.ckFactura.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerFactura", true));
            this.ckFactura.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckFactura.Location = new System.Drawing.Point(207, 127);
            this.ckFactura.Name = "ckFactura";
            this.ckFactura.Size = new System.Drawing.Size(68, 17);
            this.ckFactura.TabIndex = 23;
            this.ckFactura.Text = "FACTURA";
            this.ckFactura.UseVisualStyleBackColor = true;
            // 
            // ckRemito
            // 
            this.ckRemito.AutoSize = true;
            this.ckRemito.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerRemito", true));
            this.ckRemito.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRemito.Location = new System.Drawing.Point(104, 144);
            this.ckRemito.Name = "ckRemito";
            this.ckRemito.Size = new System.Drawing.Size(62, 17);
            this.ckRemito.TabIndex = 24;
            this.ckRemito.Text = "REMITO";
            this.ckRemito.UseVisualStyleBackColor = true;
            // 
            // ckGesco
            // 
            this.ckGesco.AutoSize = true;
            this.ckGesco.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.CustomerActiveMsgBS, "VerGesco", true));
            this.ckGesco.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGesco.Location = new System.Drawing.Point(312, 127);
            this.ckGesco.Name = "ckGesco";
            this.ckGesco.Size = new System.Drawing.Size(56, 17);
            this.ckGesco.TabIndex = 25;
            this.ckGesco.Text = "GESCO";
            this.ckGesco.UseVisualStyleBackColor = true;
            // 
            // CustomerMsgBS
            // 
            this.CustomerMsgBS.DataSource = typeof(TecserEF.Entity.CustomerMensajes);
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "idCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "idCliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // mensajeDataGridViewTextBoxColumn
            // 
            this.mensajeDataGridViewTextBoxColumn.DataPropertyName = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn.HeaderText = "MENSAJE ENVIADO";
            this.mensajeDataGridViewTextBoxColumn.Name = "mensajeDataGridViewTextBoxColumn";
            this.mensajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logDateDataGridViewTextBoxColumn
            // 
            this.logDateDataGridViewTextBoxColumn.DataPropertyName = "LogDate";
            this.logDateDataGridViewTextBoxColumn.HeaderText = "LogDate";
            this.logDateDataGridViewTextBoxColumn.Name = "logDateDataGridViewTextBoxColumn";
            this.logDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mensajeDesactivadoDataGridViewTextBoxColumn
            // 
            this.mensajeDesactivadoDataGridViewTextBoxColumn.DataPropertyName = "MensajeDesactivado";
            this.mensajeDesactivadoDataGridViewTextBoxColumn.HeaderText = "MENSAJE RECIBIDO";
            this.mensajeDesactivadoDataGridViewTextBoxColumn.Name = "mensajeDesactivadoDataGridViewTextBoxColumn";
            this.mensajeDesactivadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logDateDesactivoDataGridViewTextBoxColumn
            // 
            this.logDateDesactivoDataGridViewTextBoxColumn.DataPropertyName = "LogDateDesactivo";
            this.logDateDesactivoDataGridViewTextBoxColumn.HeaderText = "LogDateDesactivo";
            this.logDateDesactivoDataGridViewTextBoxColumn.Name = "logDateDesactivoDataGridViewTextBoxColumn";
            this.logDateDesactivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CustomerActiveMsgBS
            // 
            this.CustomerActiveMsgBS.DataSource = typeof(TecserEF.Entity.CustomerMensajes);
            // 
            // FrmMensajeCustomerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 473);
            this.Controls.Add(this.ckGesco);
            this.Controls.Add(this.ckRemito);
            this.Controls.Add(this.ckFactura);
            this.Controls.Add(this.ckCRM);
            this.Controls.Add(this.ckCtaCte);
            this.Controls.Add(this.ckRegistroActivo);
            this.Controls.Add(this.ckNotaPedido);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevaRespuesta);
            this.Controls.Add(this.btnNuevoMensaje);
            this.Controls.Add(this.txtRespondidoFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRespondidoPor);
            this.Controls.Add(this.txtCreadoFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCreadoPor);
            this.Controls.Add(this.dgvHistoria);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.cmbClienteFantasia);
            this.Controls.Add(this.label1);
            this.Name = "FrmMensajeCustomerManager";
            this.Text = "ADMINISTRADOR MENSAJE CLIENTES";
            this.Load += new System.EventHandler(this.FrmMensajeCustomerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerMsgBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerActiveMsgBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClienteFantasia;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dgvHistoria;
        private System.Windows.Forms.TextBox txtCreadoPor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreadoFecha;
        private System.Windows.Forms.TextBox txtRespondidoFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRespondidoPor;
        private System.Windows.Forms.Button btnNuevoMensaje;
        private System.Windows.Forms.Button btnNuevaRespuesta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox ckNotaPedido;
        private System.Windows.Forms.CheckBox ckRegistroActivo;
        private System.Windows.Forms.CheckBox ckCtaCte;
        private System.Windows.Forms.CheckBox ckCRM;
        private System.Windows.Forms.CheckBox ckFactura;
        private System.Windows.Forms.CheckBox ckRemito;
        private System.Windows.Forms.CheckBox ckGesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeDesactivadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDesactivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource CustomerMsgBS;
        private System.Windows.Forms.BindingSource CustomerActiveMsgBS;
    }
}