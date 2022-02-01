namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmCO36DetalleCobranzassPorCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListaCobranzas = new System.Windows.Forms.DataGridView();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.txtCantidadRegistros = new System.Windows.Forms.TextBox();
            this.txtTotalCobrado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LAB = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LI = new System.Windows.Forms.Label();
            this.LA = new System.Windows.Forms.Label();
            this.dtpFechaHoy = new System.Windows.Forms.DateTimePicker();
            this.txtPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadPeriodos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LD = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsCierreCobranzasxClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobradoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRegistrosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCobranzas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsCierreCobranzasxClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaCobranzas
            // 
            this.dgvListaCobranzas.AllowUserToAddRows = false;
            this.dgvListaCobranzas.AllowUserToDeleteRows = false;
            this.dgvListaCobranzas.AllowUserToOrderColumns = true;
            this.dgvListaCobranzas.AutoGenerateColumns = false;
            this.dgvListaCobranzas.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaCobranzas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCobranzas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaCobranzas.ColumnHeadersHeight = 25;
            this.dgvListaCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListaCobranzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.periodoDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.Cuit,
            this.cobradoDataGridViewTextBoxColumn,
            this.cantidadRegistrosDataGridViewTextBoxColumn,
            this.lxDataGridViewTextBoxColumn});
            this.dgvListaCobranzas.DataSource = this.dsCierreCobranzasxClienteBindingSource;
            this.dgvListaCobranzas.EnableHeadersVisualStyles = false;
            this.dgvListaCobranzas.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dgvListaCobranzas.Location = new System.Drawing.Point(12, 118);
            this.dgvListaCobranzas.Name = "dgvListaCobranzas";
            this.dgvListaCobranzas.ReadOnly = true;
            this.dgvListaCobranzas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCobranzas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaCobranzas.RowHeadersWidth = 25;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaCobranzas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaCobranzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCobranzas.Size = new System.Drawing.Size(1036, 553);
            this.dgvListaCobranzas.TabIndex = 151;
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(6, 22);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 19);
            this.ckL2.TabIndex = 1;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(6, 3);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 19);
            this.ckL1.TabIndex = 0;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCantidadRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadRegistros.ForeColor = System.Drawing.Color.Navy;
            this.txtCantidadRegistros.Location = new System.Drawing.Point(980, 6);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.ReadOnly = true;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(44, 23);
            this.txtCantidadRegistros.TabIndex = 160;
            // 
            // txtTotalCobrado
            // 
            this.txtTotalCobrado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotalCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCobrado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCobrado.ForeColor = System.Drawing.Color.Navy;
            this.txtTotalCobrado.Location = new System.Drawing.Point(867, 6);
            this.txtTotalCobrado.Name = "txtTotalCobrado";
            this.txtTotalCobrado.ReadOnly = true;
            this.txtTotalCobrado.Size = new System.Drawing.Size(111, 23);
            this.txtTotalCobrado.TabIndex = 159;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(778, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 158;
            this.label5.Text = "Total Cobrado";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(97, 75);
            this.dtpFechaFinal.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(135, 23);
            this.dtpFechaFinal.TabIndex = 157;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicial.Location = new System.Drawing.Point(97, 51);
            this.dtpFechaInicial.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(135, 23);
            this.dtpFechaInicial.TabIndex = 156;
            // 
            // txtLx
            // 
            this.txtLx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLx.Location = new System.Drawing.Point(233, 27);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(53, 23);
            this.txtLx.TabIndex = 151;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ckL2);
            this.panel3.Controls.Add(this.ckL1);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(233, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(53, 47);
            this.panel3.TabIndex = 153;
            // 
            // LAB
            // 
            this.LAB.BackColor = System.Drawing.Color.LightCoral;
            this.LAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LAB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAB.Location = new System.Drawing.Point(3, 949);
            this.LAB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LAB.Name = "LAB";
            this.LAB.Size = new System.Drawing.Size(1470, 3);
            this.LAB.TabIndex = 150;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(171, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 15);
            this.label9.TabIndex = 152;
            this.label9.Text = "#";
            // 
            // LI
            // 
            this.LI.BackColor = System.Drawing.Color.LightCoral;
            this.LI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LI.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LI.Location = new System.Drawing.Point(3, 3);
            this.LI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LI.Name = "LI";
            this.LI.Size = new System.Drawing.Size(3, 949);
            this.LI.TabIndex = 148;
            // 
            // LA
            // 
            this.LA.BackColor = System.Drawing.Color.LightCoral;
            this.LA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LA.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LA.Location = new System.Drawing.Point(3, 3);
            this.LA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LA.Name = "LA";
            this.LA.Size = new System.Drawing.Size(1470, 3);
            this.LA.TabIndex = 147;
            // 
            // dtpFechaHoy
            // 
            this.dtpFechaHoy.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaHoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHoy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHoy.Location = new System.Drawing.Point(97, 3);
            this.dtpFechaHoy.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.dtpFechaHoy.Name = "dtpFechaHoy";
            this.dtpFechaHoy.Size = new System.Drawing.Size(135, 23);
            this.dtpFechaHoy.TabIndex = 151;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AllowPromptAsInput = false;
            this.txtPeriodo.BeepOnError = true;
            this.txtPeriodo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtPeriodo.Location = new System.Drawing.Point(97, 27);
            this.txtPeriodo.Mask = "0000-00";
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(68, 23);
            this.txtPeriodo.TabIndex = 143;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriodo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 145;
            this.label2.Text = "Fecha Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 149;
            this.label4.Text = "Fecha Hoy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 147;
            this.label3.Text = "Fecha Hasta";
            // 
            // txtCantidadPeriodos
            // 
            this.txtCantidadPeriodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPeriodos.Location = new System.Drawing.Point(195, 27);
            this.txtCantidadPeriodos.Name = "txtCantidadPeriodos";
            this.txtCantidadPeriodos.Size = new System.Drawing.Size(37, 23);
            this.txtCantidadPeriodos.TabIndex = 151;
            this.txtCantidadPeriodos.Text = "1";
            this.txtCantidadPeriodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 144;
            this.label1.Text = "Periodo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCantidadRegistros);
            this.panel1.Controls.Add(this.txtTotalCobrado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpFechaFinal);
            this.panel1.Controls.Add(this.dtpFechaInicial);
            this.panel1.Controls.Add(this.txtLx);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dtpFechaHoy);
            this.panel1.Controls.Add(this.txtPeriodo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCantidadPeriodos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 103);
            this.panel1.TabIndex = 152;
            // 
            // LD
            // 
            this.LD.BackColor = System.Drawing.Color.LightCoral;
            this.LD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LD.Location = new System.Drawing.Point(1470, 3);
            this.LD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LD.Name = "LD";
            this.LD.Size = new System.Drawing.Size(3, 949);
            this.LD.TabIndex = 149;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Periodo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Periodo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn2.HeaderText = "RazonSocial";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IdCliente";
            this.dataGridViewTextBoxColumn3.HeaderText = "IdCliente";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Lx";
            this.dataGridViewTextBoxColumn4.HeaderText = "Lx";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Cobrado";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cobrado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CantidadRegistros";
            this.dataGridViewTextBoxColumn6.HeaderText = "CantidadRegistros";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dsCierreCobranzasxClienteBindingSource
            // 
            this.dsCierreCobranzasxClienteBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.DsCierreCobranzasxCliente);
            // 
            // periodoDataGridViewTextBoxColumn
            // 
            this.periodoDataGridViewTextBoxColumn.DataPropertyName = "Periodo";
            this.periodoDataGridViewTextBoxColumn.HeaderText = "Periodo";
            this.periodoDataGridViewTextBoxColumn.Name = "periodoDataGridViewTextBoxColumn";
            this.periodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.periodoDataGridViewTextBoxColumn.Width = 80;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Width = 50;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 300;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "Cuit";
            this.Cuit.HeaderText = "Cuit";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            // 
            // cobradoDataGridViewTextBoxColumn
            // 
            this.cobradoDataGridViewTextBoxColumn.DataPropertyName = "Cobrado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "C2";
            this.cobradoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cobradoDataGridViewTextBoxColumn.HeaderText = "Cobrado";
            this.cobradoDataGridViewTextBoxColumn.Name = "cobradoDataGridViewTextBoxColumn";
            this.cobradoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadRegistrosDataGridViewTextBoxColumn
            // 
            this.cantidadRegistrosDataGridViewTextBoxColumn.DataPropertyName = "CantidadRegistros";
            this.cantidadRegistrosDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.cantidadRegistrosDataGridViewTextBoxColumn.Name = "cantidadRegistrosDataGridViewTextBoxColumn";
            this.cantidadRegistrosDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadRegistrosDataGridViewTextBoxColumn.Width = 30;
            // 
            // lxDataGridViewTextBoxColumn
            // 
            this.lxDataGridViewTextBoxColumn.DataPropertyName = "Lx";
            this.lxDataGridViewTextBoxColumn.HeaderText = "Lx";
            this.lxDataGridViewTextBoxColumn.Name = "lxDataGridViewTextBoxColumn";
            this.lxDataGridViewTextBoxColumn.ReadOnly = true;
            this.lxDataGridViewTextBoxColumn.Width = 30;
            // 
            // FrmCO36DetalleCobranzassPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1731, 1061);
            this.Controls.Add(this.dgvListaCobranzas);
            this.Controls.Add(this.LAB);
            this.Controls.Add(this.LI);
            this.Controls.Add(this.LA);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LD);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCO36DetalleCobranzassPorCliente";
            this.Text = "CO36 - Detalle de Cobranzas por Cliente";
            this.Load += new System.EventHandler(this.FrmCO36DetalleCobranzassPorCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCobranzas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsCierreCobranzasxClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaCobranzas;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.TextBox txtCantidadRegistros;
        private System.Windows.Forms.TextBox txtTotalCobrado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LAB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LI;
        private System.Windows.Forms.Label LA;
        private System.Windows.Forms.DateTimePicker dtpFechaHoy;
        private System.Windows.Forms.MaskedTextBox txtPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadPeriodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LD;
        private System.Windows.Forms.BindingSource dsCierreCobranzasxClienteBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobradoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRegistrosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxDataGridViewTextBoxColumn;
    }
}