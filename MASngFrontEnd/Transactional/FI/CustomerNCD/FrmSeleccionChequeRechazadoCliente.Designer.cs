namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmSeleccionChequeRechazadoCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.dgvListadoCheques = new System.Windows.Forms.DataGridView();
            this.iDCHEQUEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bANCOSNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHACHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOTIVOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0156CHEQUERECHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroCheque = new System.Windows.Forms.TextBox();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckSoloTipoSeleccionado = new System.Windows.Forms.CheckBox();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0156CHEQUERECHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtId6);
            this.panel5.Controls.Add(this.txtFantasia);
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(435, 56);
            this.panel5.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(94, 4);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(246, 21);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fantasia";
            // 
            // txtId6
            // 
            this.txtId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6.Location = new System.Drawing.Point(342, 4);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(46, 21);
            this.txtId6.TabIndex = 9;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(94, 27);
            this.txtFantasia.Margin = new System.Windows.Forms.Padding(2);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(246, 21);
            this.txtFantasia.TabIndex = 7;
            // 
            // dgvListadoCheques
            // 
            this.dgvListadoCheques.AllowUserToAddRows = false;
            this.dgvListadoCheques.AllowUserToDeleteRows = false;
            this.dgvListadoCheques.AutoGenerateColumns = false;
            this.dgvListadoCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListadoCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCHEQUEDataGridViewTextBoxColumn,
            this.nUMERODataGridViewTextBoxColumn,
            this.bANCOSNDataGridViewTextBoxColumn,
            this.fECHACHDataGridViewTextBoxColumn,
            this.iMPORTEDataGridViewTextBoxColumn,
            this.mOTIVOREDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.nCNUMDataGridViewTextBoxColumn});
            this.dgvListadoCheques.DataSource = this.t0156CHEQUERECHBindingSource;
            this.dgvListadoCheques.Location = new System.Drawing.Point(5, 104);
            this.dgvListadoCheques.MultiSelect = false;
            this.dgvListadoCheques.Name = "dgvListadoCheques";
            this.dgvListadoCheques.ReadOnly = true;
            this.dgvListadoCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoCheques.Size = new System.Drawing.Size(780, 389);
            this.dgvListadoCheques.TabIndex = 65;
            this.dgvListadoCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCheques_CellEnter);
            // 
            // iDCHEQUEDataGridViewTextBoxColumn
            // 
            this.iDCHEQUEDataGridViewTextBoxColumn.DataPropertyName = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.HeaderText = "IDCH";
            this.iDCHEQUEDataGridViewTextBoxColumn.Name = "iDCHEQUEDataGridViewTextBoxColumn";
            this.iDCHEQUEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCHEQUEDataGridViewTextBoxColumn.Width = 50;
            // 
            // nUMERODataGridViewTextBoxColumn
            // 
            this.nUMERODataGridViewTextBoxColumn.DataPropertyName = "NUMERO";
            this.nUMERODataGridViewTextBoxColumn.HeaderText = "NUM";
            this.nUMERODataGridViewTextBoxColumn.Name = "nUMERODataGridViewTextBoxColumn";
            this.nUMERODataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMERODataGridViewTextBoxColumn.Width = 60;
            // 
            // bANCOSNDataGridViewTextBoxColumn
            // 
            this.bANCOSNDataGridViewTextBoxColumn.DataPropertyName = "BANCO_SN";
            this.bANCOSNDataGridViewTextBoxColumn.HeaderText = "BANCO";
            this.bANCOSNDataGridViewTextBoxColumn.Name = "bANCOSNDataGridViewTextBoxColumn";
            this.bANCOSNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fECHACHDataGridViewTextBoxColumn
            // 
            this.fECHACHDataGridViewTextBoxColumn.DataPropertyName = "FECHA_CH";
            this.fECHACHDataGridViewTextBoxColumn.HeaderText = "FECHA CH";
            this.fECHACHDataGridViewTextBoxColumn.Name = "fECHACHDataGridViewTextBoxColumn";
            this.fECHACHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEDataGridViewTextBoxColumn
            // 
            this.iMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.Format = "C2";
            this.iMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iMPORTEDataGridViewTextBoxColumn.HeaderText = "IMPORTE";
            this.iMPORTEDataGridViewTextBoxColumn.Name = "iMPORTEDataGridViewTextBoxColumn";
            this.iMPORTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mOTIVOREDataGridViewTextBoxColumn
            // 
            this.mOTIVOREDataGridViewTextBoxColumn.DataPropertyName = "MOTIVO_RE";
            this.mOTIVOREDataGridViewTextBoxColumn.HeaderText = "MOTIVO RECHAZO";
            this.mOTIVOREDataGridViewTextBoxColumn.Name = "mOTIVOREDataGridViewTextBoxColumn";
            this.mOTIVOREDataGridViewTextBoxColumn.ReadOnly = true;
            this.mOTIVOREDataGridViewTextBoxColumn.Width = 180;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 40;
            // 
            // nCNUMDataGridViewTextBoxColumn
            // 
            this.nCNUMDataGridViewTextBoxColumn.DataPropertyName = "NC_NUM";
            this.nCNUMDataGridViewTextBoxColumn.HeaderText = "ND NUM";
            this.nCNUMDataGridViewTextBoxColumn.Name = "nCNUMDataGridViewTextBoxColumn";
            this.nCNUMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // t0156CHEQUERECHBindingSource
            // 
            this.t0156CHEQUERECHBindingSource.DataSource = typeof(TecserEF.Entity.T0156_CHEQUE_RECH);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNumeroCheque);
            this.panel1.Location = new System.Drawing.Point(5, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 36);
            this.panel1.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero CH";
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroCheque.Location = new System.Drawing.Point(94, 8);
            this.txtNumeroCheque.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.ReadOnly = true;
            this.txtNumeroCheque.Size = new System.Drawing.Size(61, 21);
            this.txtNumeroCheque.TabIndex = 0;
            this.txtNumeroCheque.TextChanged += new System.EventHandler(this.txtNumeroCheque_TextChanged);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(696, 7);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(89, 40);
            this.btnSeleccion.TabIndex = 67;
            this.btnSeleccion.Text = "SELECCION";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(696, 48);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 40);
            this.btnSalir.TabIndex = 68;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ckSoloTipoSeleccionado
            // 
            this.ckSoloTipoSeleccionado.BackColor = System.Drawing.Color.Khaki;
            this.ckSoloTipoSeleccionado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckSoloTipoSeleccionado.Checked = true;
            this.ckSoloTipoSeleccionado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloTipoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloTipoSeleccionado.Location = new System.Drawing.Point(5, 498);
            this.ckSoloTipoSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.ckSoloTipoSeleccionado.Name = "ckSoloTipoSeleccionado";
            this.ckSoloTipoSeleccionado.Size = new System.Drawing.Size(217, 18);
            this.ckSoloTipoSeleccionado.TabIndex = 72;
            this.ckSoloTipoSeleccionado.Text = "VER SOLO CHEQUES DEL TIPO LX SELEECIONADO";
            this.ckSoloTipoSeleccionado.UseVisualStyleBackColor = false;
            // 
            // FrmSeleccionChequeRechazadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 565);
            this.Controls.Add(this.ckSoloTipoSeleccionado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvListadoCheques);
            this.Controls.Add(this.panel5);
            this.Name = "FrmSeleccionChequeRechazadoCliente";
            this.Text = "FrmSeleccionChequeRechazadoCliente";
            this.Load += new System.EventHandler(this.FrmSeleccionChequeRechazado_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0156CHEQUERECHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.DataGridView dgvListadoCheques;
        private System.Windows.Forms.BindingSource t0156CHEQUERECHBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCHEQUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bANCOSNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHACHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOTIVOREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroCheque;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox ckSoloTipoSeleccionado;
    }
}