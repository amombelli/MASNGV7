namespace MASngFE.MasterData
{
    partial class FrmCustomerShipToSelection
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
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.dgvShiptoList = new System.Windows.Forms.DataGridView();
            this.iDCLIENTREGADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteEntregaDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANSPORTEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0007CLIENTREGABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtSeleccion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiptoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0007CLIENTREGABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(118, 11);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(300, 22);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAZON SOCIAL";
            // 
            // txtId6
            // 
            this.txtId6.Location = new System.Drawing.Point(424, 11);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(56, 22);
            this.txtId6.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "FANTASIA";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(118, 35);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(300, 22);
            this.txtFantasia.TabIndex = 3;
            // 
            // dgvShiptoList
            // 
            this.dgvShiptoList.AllowUserToAddRows = false;
            this.dgvShiptoList.AllowUserToDeleteRows = false;
            this.dgvShiptoList.AutoGenerateColumns = false;
            this.dgvShiptoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiptoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTREGADataGridViewTextBoxColumn,
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clienteEntregaDescDataGridViewTextBoxColumn,
            this.direccionEntregaDataGridViewTextBoxColumn,
            this.tRANSPORTEIDDataGridViewTextBoxColumn});
            this.dgvShiptoList.DataSource = this.t0007CLIENTREGABindingSource;
            this.dgvShiptoList.Location = new System.Drawing.Point(16, 83);
            this.dgvShiptoList.MultiSelect = false;
            this.dgvShiptoList.Name = "dgvShiptoList";
            this.dgvShiptoList.ReadOnly = true;
            this.dgvShiptoList.RowHeadersWidth = 20;
            this.dgvShiptoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShiptoList.Size = new System.Drawing.Size(464, 150);
            this.dgvShiptoList.TabIndex = 5;
            this.dgvShiptoList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShiptoList_CellEnter);
            // 
            // iDCLIENTREGADataGridViewTextBoxColumn
            // 
            this.iDCLIENTREGADataGridViewTextBoxColumn.DataPropertyName = "ID_CLI_ENTREGA";
            this.iDCLIENTREGADataGridViewTextBoxColumn.HeaderText = "ID7";
            this.iDCLIENTREGADataGridViewTextBoxColumn.Name = "iDCLIENTREGADataGridViewTextBoxColumn";
            this.iDCLIENTREGADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTREGADataGridViewTextBoxColumn.Width = 50;
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteEntregaDescDataGridViewTextBoxColumn
            // 
            this.clienteEntregaDescDataGridViewTextBoxColumn.DataPropertyName = "ClienteEntregaDesc";
            this.clienteEntregaDescDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION ENTREGA";
            this.clienteEntregaDescDataGridViewTextBoxColumn.Name = "clienteEntregaDescDataGridViewTextBoxColumn";
            this.clienteEntregaDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteEntregaDescDataGridViewTextBoxColumn.Width = 150;
            // 
            // direccionEntregaDataGridViewTextBoxColumn
            // 
            this.direccionEntregaDataGridViewTextBoxColumn.DataPropertyName = "Direccion_Entrega";
            this.direccionEntregaDataGridViewTextBoxColumn.HeaderText = "DIRECCION ENTREGA";
            this.direccionEntregaDataGridViewTextBoxColumn.Name = "direccionEntregaDataGridViewTextBoxColumn";
            this.direccionEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionEntregaDataGridViewTextBoxColumn.Width = 150;
            // 
            // tRANSPORTEIDDataGridViewTextBoxColumn
            // 
            this.tRANSPORTEIDDataGridViewTextBoxColumn.DataPropertyName = "TRANSPORTE_ID";
            this.tRANSPORTEIDDataGridViewTextBoxColumn.HeaderText = "TRANSP";
            this.tRANSPORTEIDDataGridViewTextBoxColumn.Name = "tRANSPORTEIDDataGridViewTextBoxColumn";
            this.tRANSPORTEIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRANSPORTEIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // t0007CLIENTREGABindingSource
            // 
            this.t0007CLIENTREGABindingSource.DataSource = typeof(TecserEF.Entity.T0007_CLI_ENTREGA);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.Navy;
            this.btnAceptar.Location = new System.Drawing.Point(486, 84);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 34);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "SELECCIONAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.Purple;
            this.btnSalir.Location = new System.Drawing.Point(486, 124);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 34);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "CANCELAR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtSeleccion
            // 
            this.txtSeleccion.Location = new System.Drawing.Point(486, 211);
            this.txtSeleccion.Name = "txtSeleccion";
            this.txtSeleccion.ReadOnly = true;
            this.txtSeleccion.Size = new System.Drawing.Size(56, 22);
            this.txtSeleccion.TabIndex = 8;
            // 
            // FrmCustomerShipToSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 242);
            this.Controls.Add(this.txtSeleccion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvShiptoList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFantasia);
            this.Controls.Add(this.txtId6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazonSocial);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCustomerShipToSelection";
            this.Text = "SELECCION DE SHIPTO";
            this.Load += new System.EventHandler(this.FrmCustomerShipToSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiptoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0007CLIENTREGABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.DataGridView dgvShiptoList;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTREGADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteEntregaDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANSPORTEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0007CLIENTREGABindingSource;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtSeleccion;
    }
}