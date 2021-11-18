namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCo37ConciliaEgresos
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
            this.dgvConcilia = new System.Windows.Forms.DataGridView();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Register = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CtaCte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeCtaCteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeAcredDiferidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importePendAcredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusOk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.conciliaEgresos2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStatusConciliacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cIconoStatus = new TSControls.CtlIconos();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conciliaEgresos2BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConcilia
            // 
            this.dgvConcilia.AllowUserToAddRows = false;
            this.dgvConcilia.AllowUserToDeleteRows = false;
            this.dgvConcilia.AllowUserToOrderColumns = true;
            this.dgvConcilia.AutoGenerateColumns = false;
            this.dgvConcilia.BackgroundColor = System.Drawing.Color.White;
            this.dgvConcilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcilia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.Documento,
            this.RazonSocial,
            this.Register,
            this.CtaCte,
            this.Lx,
            this.importeRegDataGridViewTextBoxColumn,
            this.importeCtaCteDataGridViewTextBoxColumn,
            this.importeAcredDiferidoDataGridViewTextBoxColumn,
            this.importePendAcredDataGridViewTextBoxColumn,
            this.StatusOk});
            this.dgvConcilia.DataSource = this.conciliaEgresos2BindingSource;
            this.dgvConcilia.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvConcilia.Location = new System.Drawing.Point(8, 70);
            this.dgvConcilia.Name = "dgvConcilia";
            this.dgvConcilia.ReadOnly = true;
            this.dgvConcilia.RowHeadersWidth = 20;
            this.dgvConcilia.Size = new System.Drawing.Size(922, 794);
            this.dgvConcilia.TabIndex = 0;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.ToolTipText = "Fecha del Documento";
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Docu #";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.ToolTipText = "Numero Documento";
            this.Documento.Width = 90;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 200;
            // 
            // Register
            // 
            this.Register.DataPropertyName = "Register";
            this.Register.HeaderText = "ER";
            this.Register.Name = "Register";
            this.Register.ReadOnly = true;
            this.Register.ToolTipText = "Egreso Real";
            this.Register.Width = 30;
            // 
            // CtaCte
            // 
            this.CtaCte.DataPropertyName = "CtaCte";
            this.CtaCte.HeaderText = "ED";
            this.CtaCte.Name = "CtaCte";
            this.CtaCte.ReadOnly = true;
            this.CtaCte.ToolTipText = "Emision de Documento en este Periodo";
            this.CtaCte.Width = 30;
            // 
            // Lx
            // 
            this.Lx.DataPropertyName = "Lx";
            this.Lx.HeaderText = "Lx";
            this.Lx.Name = "Lx";
            this.Lx.ReadOnly = true;
            this.Lx.Width = 30;
            // 
            // importeRegDataGridViewTextBoxColumn
            // 
            this.importeRegDataGridViewTextBoxColumn.DataPropertyName = "importeReg";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle2.Format = "C2";
            this.importeRegDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.importeRegDataGridViewTextBoxColumn.HeaderText = "Importe [R]";
            this.importeRegDataGridViewTextBoxColumn.Name = "importeRegDataGridViewTextBoxColumn";
            this.importeRegDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeCtaCteDataGridViewTextBoxColumn
            // 
            this.importeCtaCteDataGridViewTextBoxColumn.DataPropertyName = "importeCtaCte";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            this.importeCtaCteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.importeCtaCteDataGridViewTextBoxColumn.HeaderText = "Importe [C]";
            this.importeCtaCteDataGridViewTextBoxColumn.Name = "importeCtaCteDataGridViewTextBoxColumn";
            this.importeCtaCteDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeCtaCteDataGridViewTextBoxColumn.ToolTipText = "Importe en CtaCte";
            // 
            // importeAcredDiferidoDataGridViewTextBoxColumn
            // 
            this.importeAcredDiferidoDataGridViewTextBoxColumn.DataPropertyName = "importeAcredDiferido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "C2";
            this.importeAcredDiferidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.importeAcredDiferidoDataGridViewTextBoxColumn.HeaderText = "OtrosPeriodos";
            this.importeAcredDiferidoDataGridViewTextBoxColumn.Name = "importeAcredDiferidoDataGridViewTextBoxColumn";
            this.importeAcredDiferidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeAcredDiferidoDataGridViewTextBoxColumn.ToolTipText = "Acreditacion Cheques emitidos en otros periodos";
            this.importeAcredDiferidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // importePendAcredDataGridViewTextBoxColumn
            // 
            this.importePendAcredDataGridViewTextBoxColumn.DataPropertyName = "importePendAcred";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Format = "C2";
            this.importePendAcredDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.importePendAcredDataGridViewTextBoxColumn.HeaderText = "PendAcred";
            this.importePendAcredDataGridViewTextBoxColumn.Name = "importePendAcredDataGridViewTextBoxColumn";
            this.importePendAcredDataGridViewTextBoxColumn.ReadOnly = true;
            this.importePendAcredDataGridViewTextBoxColumn.ToolTipText = "Pendiente por Acreditar";
            this.importePendAcredDataGridViewTextBoxColumn.Width = 80;
            // 
            // StatusOk
            // 
            this.StatusOk.DataPropertyName = "StatusOk";
            this.StatusOk.HeaderText = "OK";
            this.StatusOk.Name = "StatusOk";
            this.StatusOk.ReadOnly = true;
            this.StatusOk.ToolTipText = "Conciliacion OK";
            this.StatusOk.Width = 30;
            // 
            // conciliaEgresos2BindingSource
            // 
            this.conciliaEgresos2BindingSource.DataSource = typeof(Tecser.Business.Transactional.Cierre.ConciliaEgresos2);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(2, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 868);
            this.label17.TabIndex = 273;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(937, 3);
            this.label18.TabIndex = 272;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(936, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 867);
            this.label1.TabIndex = 274;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(813, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 275;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(69, 6);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(73, 23);
            this.txtPeriodo.TabIndex = 276;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 277;
            this.label2.Text = "Periodo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtLx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPeriodo);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 59);
            this.panel1.TabIndex = 278;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 279;
            this.label3.Text = "Tipo";
            // 
            // txtLx
            // 
            this.txtLx.Location = new System.Drawing.Point(69, 31);
            this.txtLx.Name = "txtLx";
            this.txtLx.Size = new System.Drawing.Size(30, 23);
            this.txtLx.TabIndex = 278;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cIconoStatus);
            this.panel2.Controls.Add(this.txtStatusConciliacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(537, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 59);
            this.panel2.TabIndex = 280;
            // 
            // txtStatusConciliacion
            // 
            this.txtStatusConciliacion.Location = new System.Drawing.Point(129, 6);
            this.txtStatusConciliacion.Name = "txtStatusConciliacion";
            this.txtStatusConciliacion.Size = new System.Drawing.Size(30, 23);
            this.txtStatusConciliacion.TabIndex = 278;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 277;
            this.label5.Text = "Status Conciliacion";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(2, 867);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(937, 3);
            this.label4.TabIndex = 281;
            // 
            // cIconoStatus
            // 
            this.cIconoStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIconoStatus.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cIconoStatus.IconSize = TSControls.TamañoIcono.Chico;
            this.cIconoStatus.Location = new System.Drawing.Point(169, 9);
            this.cIconoStatus.Name = "cIconoStatus";
            this.cIconoStatus.Set = TSControls.CIconos.ExclamacionYellow;
            this.cIconoStatus.Size = new System.Drawing.Size(19, 18);
            this.cIconoStatus.TabIndex = 282;
            // 
            // FrmCo37ConciliaEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 874);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvConcilia);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCo37ConciliaEgresos";
            this.Text = "CO37 - Conciliacion de Egresos";
            this.Load += new System.EventHandler(this.FrmCo37ConciliaEgresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conciliaEgresos2BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConcilia;
        private System.Windows.Forms.BindingSource conciliaEgresos2BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Register;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CtaCte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeCtaCteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeAcredDiferidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importePendAcredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StatusOk;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtStatusConciliacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private TSControls.CtlIconos cIconoStatus;
    }
}