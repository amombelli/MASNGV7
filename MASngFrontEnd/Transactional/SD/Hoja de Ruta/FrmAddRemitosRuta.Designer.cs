namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    partial class FrmAddRemitosRuta
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddRemito = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.ckRetirarPago = new System.Windows.Forms.CheckBox();
            this.ckEntregarMuestra = new System.Windows.Forms.CheckBox();
            this.txtOrdenEntrega = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemitoSeleccionado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvRemitos = new System.Windows.Forms.DataGridView();
            this.idEntregasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroRemitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRutaAsignadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0059ENTREGASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarNumeroRemito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdEntrega = new System.Windows.Forms.TextBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminarRemito = new System.Windows.Forms.Button();
            this.btnNoEntregado = new System.Windows.Forms.Button();
            this.btnEntregadoOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059ENTREGASBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(837, 41);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(108, 43);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAddRemito
            // 
            this.btnAddRemito.Location = new System.Drawing.Point(837, 85);
            this.btnAddRemito.Name = "btnAddRemito";
            this.btnAddRemito.Size = new System.Drawing.Size(108, 43);
            this.btnAddRemito.TabIndex = 1;
            this.btnAddRemito.Text = "AGREGAR REMITO";
            this.btnAddRemito.UseVisualStyleBackColor = true;
            this.btnAddRemito.Click += new System.EventHandler(this.btnAddRemito_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "OBSERVACIONES:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(147, 393);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(447, 22);
            this.txtObservaciones.TabIndex = 4;
            // 
            // ckRetirarPago
            // 
            this.ckRetirarPago.AutoSize = true;
            this.ckRetirarPago.Location = new System.Drawing.Point(147, 421);
            this.ckRetirarPago.Name = "ckRetirarPago";
            this.ckRetirarPago.Size = new System.Drawing.Size(107, 18);
            this.ckRetirarPago.TabIndex = 5;
            this.ckRetirarPago.Text = "RETIRAR PAGO?";
            this.ckRetirarPago.UseVisualStyleBackColor = true;
            // 
            // ckEntregarMuestra
            // 
            this.ckEntregarMuestra.AutoSize = true;
            this.ckEntregarMuestra.Location = new System.Drawing.Point(147, 445);
            this.ckEntregarMuestra.Name = "ckEntregarMuestra";
            this.ckEntregarMuestra.Size = new System.Drawing.Size(140, 18);
            this.ckEntregarMuestra.TabIndex = 6;
            this.ckEntregarMuestra.Text = "ENTREGAR MUESTRA?";
            this.ckEntregarMuestra.UseVisualStyleBackColor = true;
            // 
            // txtOrdenEntrega
            // 
            this.txtOrdenEntrega.Location = new System.Drawing.Point(147, 369);
            this.txtOrdenEntrega.Name = "txtOrdenEntrega";
            this.txtOrdenEntrega.Size = new System.Drawing.Size(31, 22);
            this.txtOrdenEntrega.TabIndex = 8;
            this.txtOrdenEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrdenEntrega_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "ORDEN ENTREGA";
            // 
            // txtRemitoSeleccionado
            // 
            this.txtRemitoSeleccionado.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRemitoSeleccionado.Location = new System.Drawing.Point(147, 345);
            this.txtRemitoSeleccionado.Name = "txtRemitoSeleccionado";
            this.txtRemitoSeleccionado.ReadOnly = true;
            this.txtRemitoSeleccionado.Size = new System.Drawing.Size(113, 22);
            this.txtRemitoSeleccionado.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "REMITO SELECCIONADO";
            // 
            // dgvRemitos
            // 
            this.dgvRemitos.AllowUserToAddRows = false;
            this.dgvRemitos.AllowUserToDeleteRows = false;
            this.dgvRemitos.AutoGenerateColumns = false;
            this.dgvRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEntregasDataGridViewTextBoxColumn,
            this.idRemitoDataGridViewTextBoxColumn,
            this.numeroRemitoDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.tipoEntregaDataGridViewTextBoxColumn,
            this.statusEntregaDataGridViewTextBoxColumn,
            this.fechaEntregaDataGridViewTextBoxColumn,
            this.clienteEntregaDataGridViewTextBoxColumn,
            this.clienteIdDataGridViewTextBoxColumn,
            this.idRutaAsignadaDataGridViewTextBoxColumn});
            this.dgvRemitos.DataSource = this.t0059ENTREGASBindingSource;
            this.dgvRemitos.Location = new System.Drawing.Point(13, 37);
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.ReadOnly = true;
            this.dgvRemitos.Size = new System.Drawing.Size(774, 276);
            this.dgvRemitos.TabIndex = 11;
            this.dgvRemitos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitos_CellEnter);
            // 
            // idEntregasDataGridViewTextBoxColumn
            // 
            this.idEntregasDataGridViewTextBoxColumn.DataPropertyName = "IdEntregas";
            this.idEntregasDataGridViewTextBoxColumn.HeaderText = "ID#";
            this.idEntregasDataGridViewTextBoxColumn.Name = "idEntregasDataGridViewTextBoxColumn";
            this.idEntregasDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEntregasDataGridViewTextBoxColumn.Width = 40;
            // 
            // idRemitoDataGridViewTextBoxColumn
            // 
            this.idRemitoDataGridViewTextBoxColumn.DataPropertyName = "idRemito";
            this.idRemitoDataGridViewTextBoxColumn.HeaderText = "idRemito";
            this.idRemitoDataGridViewTextBoxColumn.Name = "idRemitoDataGridViewTextBoxColumn";
            this.idRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRemitoDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroRemitoDataGridViewTextBoxColumn
            // 
            this.numeroRemitoDataGridViewTextBoxColumn.DataPropertyName = "NumeroRemito";
            this.numeroRemitoDataGridViewTextBoxColumn.HeaderText = "REMITO #";
            this.numeroRemitoDataGridViewTextBoxColumn.Name = "numeroRemitoDataGridViewTextBoxColumn";
            this.numeroRemitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroRemitoDataGridViewTextBoxColumn.Width = 70;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "NOMBRE CLIENTE";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 160;
            // 
            // tipoEntregaDataGridViewTextBoxColumn
            // 
            this.tipoEntregaDataGridViewTextBoxColumn.DataPropertyName = "TipoEntrega";
            this.tipoEntregaDataGridViewTextBoxColumn.HeaderText = "TipoEntrega";
            this.tipoEntregaDataGridViewTextBoxColumn.Name = "tipoEntregaDataGridViewTextBoxColumn";
            this.tipoEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaEntregaDataGridViewTextBoxColumn
            // 
            this.fechaEntregaDataGridViewTextBoxColumn.DataPropertyName = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.HeaderText = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.Name = "fechaEntregaDataGridViewTextBoxColumn";
            this.fechaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteEntregaDataGridViewTextBoxColumn
            // 
            this.clienteEntregaDataGridViewTextBoxColumn.DataPropertyName = "ClienteEntrega";
            this.clienteEntregaDataGridViewTextBoxColumn.HeaderText = "ClienteEntrega";
            this.clienteEntregaDataGridViewTextBoxColumn.Name = "clienteEntregaDataGridViewTextBoxColumn";
            this.clienteEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteIdDataGridViewTextBoxColumn
            // 
            this.clienteIdDataGridViewTextBoxColumn.DataPropertyName = "ClienteId";
            this.clienteIdDataGridViewTextBoxColumn.HeaderText = "ClienteId";
            this.clienteIdDataGridViewTextBoxColumn.Name = "clienteIdDataGridViewTextBoxColumn";
            this.clienteIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // idRutaAsignadaDataGridViewTextBoxColumn
            // 
            this.idRutaAsignadaDataGridViewTextBoxColumn.DataPropertyName = "IdRutaAsignada";
            this.idRutaAsignadaDataGridViewTextBoxColumn.HeaderText = "RUTA#";
            this.idRutaAsignadaDataGridViewTextBoxColumn.Name = "idRutaAsignadaDataGridViewTextBoxColumn";
            this.idRutaAsignadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRutaAsignadaDataGridViewTextBoxColumn.Width = 60;
            // 
            // t0059ENTREGASBindingSource
            // 
            this.t0059ENTREGASBindingSource.DataSource = typeof(TecserEF.Entity.T0059_ENTREGAS);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(13, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(774, 2);
            this.label4.TabIndex = 12;
            // 
            // txtBuscarNumeroRemito
            // 
            this.txtBuscarNumeroRemito.Location = new System.Drawing.Point(113, 6);
            this.txtBuscarNumeroRemito.Name = "txtBuscarNumeroRemito";
            this.txtBuscarNumeroRemito.Size = new System.Drawing.Size(87, 22);
            this.txtBuscarNumeroRemito.TabIndex = 14;
            this.txtBuscarNumeroRemito.Leave += new System.EventHandler(this.txtBuscarNumeroRemito_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "NUMERO REMITO";
            // 
            // txtIdEntrega
            // 
            this.txtIdEntrega.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtIdEntrega.Location = new System.Drawing.Point(722, 345);
            this.txtIdEntrega.Name = "txtIdEntrega";
            this.txtIdEntrega.ReadOnly = true;
            this.txtIdEntrega.Size = new System.Drawing.Size(65, 22);
            this.txtIdEntrega.TabIndex = 15;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(837, 174);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(108, 43);
            this.btnGuardarCambios.TabIndex = 16;
            this.btnGuardarCambios.Text = "GUARDAR\r\nCAMBIOS";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnEliminarRemito
            // 
            this.btnEliminarRemito.Location = new System.Drawing.Point(837, 129);
            this.btnEliminarRemito.Name = "btnEliminarRemito";
            this.btnEliminarRemito.Size = new System.Drawing.Size(108, 43);
            this.btnEliminarRemito.TabIndex = 17;
            this.btnEliminarRemito.Text = "ELIMINAR\r\nREMITO";
            this.btnEliminarRemito.UseVisualStyleBackColor = true;
            this.btnEliminarRemito.Click += new System.EventHandler(this.btnEliminarRemito_Click);
            // 
            // btnNoEntregado
            // 
            this.btnNoEntregado.ForeColor = System.Drawing.Color.Crimson;
            this.btnNoEntregado.Location = new System.Drawing.Point(837, 270);
            this.btnNoEntregado.Name = "btnNoEntregado";
            this.btnNoEntregado.Size = new System.Drawing.Size(108, 43);
            this.btnNoEntregado.TabIndex = 18;
            this.btnNoEntregado.Text = "NO ENTREGADO";
            this.btnNoEntregado.UseVisualStyleBackColor = true;
            this.btnNoEntregado.Click += new System.EventHandler(this.btnNoEntregado_Click);
            // 
            // btnEntregadoOK
            // 
            this.btnEntregadoOK.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEntregadoOK.Location = new System.Drawing.Point(837, 317);
            this.btnEntregadoOK.Name = "btnEntregadoOK";
            this.btnEntregadoOK.Size = new System.Drawing.Size(108, 43);
            this.btnEntregadoOK.TabIndex = 19;
            this.btnEntregadoOK.Text = "ENTREGADO OK";
            this.btnEntregadoOK.UseVisualStyleBackColor = true;
            this.btnEntregadoOK.Click += new System.EventHandler(this.btnEntregadoOK_Click);
            // 
            // FrmAddRemitosRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 478);
            this.Controls.Add(this.btnEntregadoOK);
            this.Controls.Add(this.btnNoEntregado);
            this.Controls.Add(this.btnEliminarRemito);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.txtIdEntrega);
            this.Controls.Add(this.txtBuscarNumeroRemito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvRemitos);
            this.Controls.Add(this.txtRemitoSeleccionado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrdenEntrega);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckEntregarMuestra);
            this.Controls.Add(this.ckRetirarPago);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddRemito);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmAddRemitosRuta";
            this.Text = "AGREGAR REMITOS A HOJA DE RUTA";
            this.Load += new System.EventHandler(this.FrmAddRemitosRuta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0059ENTREGASBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddRemito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.CheckBox ckRetirarPago;
        private System.Windows.Forms.CheckBox ckEntregarMuestra;
        private System.Windows.Forms.TextBox txtOrdenEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemitoSeleccionado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRemitos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEntregasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroRemitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRutaAsignadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0059ENTREGASBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarNumeroRemito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdEntrega;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminarRemito;
        private System.Windows.Forms.Button btnNoEntregado;
        private System.Windows.Forms.Button btnEntregadoOK;
    }
}