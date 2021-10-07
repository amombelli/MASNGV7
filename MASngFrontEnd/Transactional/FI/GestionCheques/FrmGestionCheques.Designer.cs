namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmGestionCheques
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
            this.grpModo = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnTransferirCuenta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDCHEQUEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHENUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHEBANCODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHEINTERIORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHEFECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHECUITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHETITULARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHARECIBIDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHAENTREGADODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECIBONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROVEEDORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dISPONIBLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPORECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPGNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHRECHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHIDRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cALIFICACIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSSALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPOSALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0160BANCOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0154CHEQUESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpModo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0154CHEQUESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpModo
            // 
            this.grpModo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpModo.Controls.Add(this.radioButton3);
            this.grpModo.Controls.Add(this.radioButton2);
            this.grpModo.Controls.Add(this.radioButton1);
            this.grpModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpModo.Location = new System.Drawing.Point(13, 22);
            this.grpModo.Name = "grpModo";
            this.grpModo.Size = new System.Drawing.Size(231, 91);
            this.grpModo.TabIndex = 0;
            this.grpModo.TabStop = false;
            this.grpModo.Text = "ACCION";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(169, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Devolver Cheque a Cliente";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(175, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Transferir Cheque a Cuenta";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(190, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Rechazar Cheque Depositado";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(250, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 52);
            this.panel1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1150, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(274, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 21);
            this.textBox1.TabIndex = 5;
            // 
            // btnTransferirCuenta
            // 
            this.btnTransferirCuenta.Location = new System.Drawing.Point(943, 22);
            this.btnTransferirCuenta.Name = "btnTransferirCuenta";
            this.btnTransferirCuenta.Size = new System.Drawing.Size(100, 39);
            this.btnTransferirCuenta.TabIndex = 4;
            this.btnTransferirCuenta.Text = "Transferir A Cuenta";
            this.btnTransferirCuenta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(889, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Transferir a Cuenta";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.t0150CUENTASBindingSource;
            this.comboBox2.DisplayMember = "CUENTA_DESC";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1010, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(134, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.ValueMember = "ID_CUENTA";
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta Cheque";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.t0150CUENTASBindingSource;
            this.comboBox1.DisplayMember = "CUENTA_DESC";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "ID_CUENTA";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCHEQUEDataGridViewTextBoxColumn,
            this.mONEDADataGridViewTextBoxColumn,
            this.iMPORTEDataGridViewTextBoxColumn,
            this.cHENUMERODataGridViewTextBoxColumn,
            this.cHEBANCODataGridViewTextBoxColumn,
            this.cHEINTERIORDataGridViewTextBoxColumn,
            this.cHEFECHADataGridViewTextBoxColumn,
            this.cHECUITDataGridViewTextBoxColumn,
            this.cHETITULARDataGridViewTextBoxColumn,
            this.cLIENTEDataGridViewTextBoxColumn,
            this.fECHARECIBIDODataGridViewTextBoxColumn,
            this.fECHAENTREGADODataGridViewTextBoxColumn,
            this.rECIBONDataGridViewTextBoxColumn,
            this.pROVEEDORDataGridViewTextBoxColumn,
            this.dISPONIBLEDataGridViewTextBoxColumn,
            this.oPDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.tIPORECDataGridViewTextBoxColumn,
            this.oPGNDataGridViewTextBoxColumn,
            this.cHRECHDataGridViewTextBoxColumn,
            this.cHIDRDataGridViewTextBoxColumn,
            this.cALIFICACIONDataGridViewTextBoxColumn,
            this.cOMENTARIODataGridViewTextBoxColumn,
            this.aSENTDataGridViewTextBoxColumn,
            this.aSSALDataGridViewTextBoxColumn,
            this.tIPOSALDataGridViewTextBoxColumn,
            this.t0160BANCOSDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.t0154CHEQUESBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(13, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1182, 423);
            this.dataGridView1.TabIndex = 2;
            // 
            // iDCHEQUEDataGridViewTextBoxColumn
            // 
            this.iDCHEQUEDataGridViewTextBoxColumn.DataPropertyName = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.HeaderText = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.Name = "iDCHEQUEDataGridViewTextBoxColumn";
            this.iDCHEQUEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEDataGridViewTextBoxColumn
            // 
            this.iMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE";
            this.iMPORTEDataGridViewTextBoxColumn.HeaderText = "IMPORTE";
            this.iMPORTEDataGridViewTextBoxColumn.Name = "iMPORTEDataGridViewTextBoxColumn";
            this.iMPORTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHENUMERODataGridViewTextBoxColumn
            // 
            this.cHENUMERODataGridViewTextBoxColumn.DataPropertyName = "CHE_NUMERO";
            this.cHENUMERODataGridViewTextBoxColumn.HeaderText = "CHE_NUMERO";
            this.cHENUMERODataGridViewTextBoxColumn.Name = "cHENUMERODataGridViewTextBoxColumn";
            this.cHENUMERODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHEBANCODataGridViewTextBoxColumn
            // 
            this.cHEBANCODataGridViewTextBoxColumn.DataPropertyName = "CHE_BANCO";
            this.cHEBANCODataGridViewTextBoxColumn.HeaderText = "CHE_BANCO";
            this.cHEBANCODataGridViewTextBoxColumn.Name = "cHEBANCODataGridViewTextBoxColumn";
            this.cHEBANCODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHEINTERIORDataGridViewTextBoxColumn
            // 
            this.cHEINTERIORDataGridViewTextBoxColumn.DataPropertyName = "CHE_INTERIOR";
            this.cHEINTERIORDataGridViewTextBoxColumn.HeaderText = "CHE_INTERIOR";
            this.cHEINTERIORDataGridViewTextBoxColumn.Name = "cHEINTERIORDataGridViewTextBoxColumn";
            this.cHEINTERIORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHEFECHADataGridViewTextBoxColumn
            // 
            this.cHEFECHADataGridViewTextBoxColumn.DataPropertyName = "CHE_FECHA";
            this.cHEFECHADataGridViewTextBoxColumn.HeaderText = "CHE_FECHA";
            this.cHEFECHADataGridViewTextBoxColumn.Name = "cHEFECHADataGridViewTextBoxColumn";
            this.cHEFECHADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHECUITDataGridViewTextBoxColumn
            // 
            this.cHECUITDataGridViewTextBoxColumn.DataPropertyName = "CHE_CUIT";
            this.cHECUITDataGridViewTextBoxColumn.HeaderText = "CHE_CUIT";
            this.cHECUITDataGridViewTextBoxColumn.Name = "cHECUITDataGridViewTextBoxColumn";
            this.cHECUITDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHETITULARDataGridViewTextBoxColumn
            // 
            this.cHETITULARDataGridViewTextBoxColumn.DataPropertyName = "CHE_TITULAR";
            this.cHETITULARDataGridViewTextBoxColumn.HeaderText = "CHE_TITULAR";
            this.cHETITULARDataGridViewTextBoxColumn.Name = "cHETITULARDataGridViewTextBoxColumn";
            this.cHETITULARDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cLIENTEDataGridViewTextBoxColumn
            // 
            this.cLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CLIENTE";
            this.cLIENTEDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.cLIENTEDataGridViewTextBoxColumn.Name = "cLIENTEDataGridViewTextBoxColumn";
            this.cLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fECHARECIBIDODataGridViewTextBoxColumn
            // 
            this.fECHARECIBIDODataGridViewTextBoxColumn.DataPropertyName = "FECHA_RECIBIDO";
            this.fECHARECIBIDODataGridViewTextBoxColumn.HeaderText = "FECHA_RECIBIDO";
            this.fECHARECIBIDODataGridViewTextBoxColumn.Name = "fECHARECIBIDODataGridViewTextBoxColumn";
            this.fECHARECIBIDODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fECHAENTREGADODataGridViewTextBoxColumn
            // 
            this.fECHAENTREGADODataGridViewTextBoxColumn.DataPropertyName = "FECHA_ENTREGADO";
            this.fECHAENTREGADODataGridViewTextBoxColumn.HeaderText = "FECHA_ENTREGADO";
            this.fECHAENTREGADODataGridViewTextBoxColumn.Name = "fECHAENTREGADODataGridViewTextBoxColumn";
            this.fECHAENTREGADODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rECIBONDataGridViewTextBoxColumn
            // 
            this.rECIBONDataGridViewTextBoxColumn.DataPropertyName = "RECIBON";
            this.rECIBONDataGridViewTextBoxColumn.HeaderText = "RECIBON";
            this.rECIBONDataGridViewTextBoxColumn.Name = "rECIBONDataGridViewTextBoxColumn";
            this.rECIBONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pROVEEDORDataGridViewTextBoxColumn
            // 
            this.pROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "PROVEEDOR";
            this.pROVEEDORDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR";
            this.pROVEEDORDataGridViewTextBoxColumn.Name = "pROVEEDORDataGridViewTextBoxColumn";
            this.pROVEEDORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dISPONIBLEDataGridViewTextBoxColumn
            // 
            this.dISPONIBLEDataGridViewTextBoxColumn.DataPropertyName = "DISPONIBLE";
            this.dISPONIBLEDataGridViewTextBoxColumn.HeaderText = "DISPONIBLE";
            this.dISPONIBLEDataGridViewTextBoxColumn.Name = "dISPONIBLEDataGridViewTextBoxColumn";
            this.dISPONIBLEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oPDataGridViewTextBoxColumn
            // 
            this.oPDataGridViewTextBoxColumn.DataPropertyName = "OP";
            this.oPDataGridViewTextBoxColumn.HeaderText = "OP";
            this.oPDataGridViewTextBoxColumn.Name = "oPDataGridViewTextBoxColumn";
            this.oPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPORECDataGridViewTextBoxColumn
            // 
            this.tIPORECDataGridViewTextBoxColumn.DataPropertyName = "TIPO_REC";
            this.tIPORECDataGridViewTextBoxColumn.HeaderText = "TIPO_REC";
            this.tIPORECDataGridViewTextBoxColumn.Name = "tIPORECDataGridViewTextBoxColumn";
            this.tIPORECDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oPGNDataGridViewTextBoxColumn
            // 
            this.oPGNDataGridViewTextBoxColumn.DataPropertyName = "OP_GN";
            this.oPGNDataGridViewTextBoxColumn.HeaderText = "OP_GN";
            this.oPGNDataGridViewTextBoxColumn.Name = "oPGNDataGridViewTextBoxColumn";
            this.oPGNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHRECHDataGridViewTextBoxColumn
            // 
            this.cHRECHDataGridViewTextBoxColumn.DataPropertyName = "CH_RECH";
            this.cHRECHDataGridViewTextBoxColumn.HeaderText = "CH_RECH";
            this.cHRECHDataGridViewTextBoxColumn.Name = "cHRECHDataGridViewTextBoxColumn";
            this.cHRECHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHIDRDataGridViewTextBoxColumn
            // 
            this.cHIDRDataGridViewTextBoxColumn.DataPropertyName = "CH_IDR";
            this.cHIDRDataGridViewTextBoxColumn.HeaderText = "CH_IDR";
            this.cHIDRDataGridViewTextBoxColumn.Name = "cHIDRDataGridViewTextBoxColumn";
            this.cHIDRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cALIFICACIONDataGridViewTextBoxColumn
            // 
            this.cALIFICACIONDataGridViewTextBoxColumn.DataPropertyName = "CALIFICACION";
            this.cALIFICACIONDataGridViewTextBoxColumn.HeaderText = "CALIFICACION";
            this.cALIFICACIONDataGridViewTextBoxColumn.Name = "cALIFICACIONDataGridViewTextBoxColumn";
            this.cALIFICACIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMENTARIODataGridViewTextBoxColumn
            // 
            this.cOMENTARIODataGridViewTextBoxColumn.DataPropertyName = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.HeaderText = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.Name = "cOMENTARIODataGridViewTextBoxColumn";
            this.cOMENTARIODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aSENTDataGridViewTextBoxColumn
            // 
            this.aSENTDataGridViewTextBoxColumn.DataPropertyName = "ASENT";
            this.aSENTDataGridViewTextBoxColumn.HeaderText = "ASENT";
            this.aSENTDataGridViewTextBoxColumn.Name = "aSENTDataGridViewTextBoxColumn";
            this.aSENTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aSSALDataGridViewTextBoxColumn
            // 
            this.aSSALDataGridViewTextBoxColumn.DataPropertyName = "ASSAL";
            this.aSSALDataGridViewTextBoxColumn.HeaderText = "ASSAL";
            this.aSSALDataGridViewTextBoxColumn.Name = "aSSALDataGridViewTextBoxColumn";
            this.aSSALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPOSALDataGridViewTextBoxColumn
            // 
            this.tIPOSALDataGridViewTextBoxColumn.DataPropertyName = "TIPOSAL";
            this.tIPOSALDataGridViewTextBoxColumn.HeaderText = "TIPOSAL";
            this.tIPOSALDataGridViewTextBoxColumn.Name = "tIPOSALDataGridViewTextBoxColumn";
            this.tIPOSALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // t0160BANCOSDataGridViewTextBoxColumn
            // 
            this.t0160BANCOSDataGridViewTextBoxColumn.DataPropertyName = "T0160_BANCOS";
            this.t0160BANCOSDataGridViewTextBoxColumn.HeaderText = "T0160_BANCOS";
            this.t0160BANCOSDataGridViewTextBoxColumn.Name = "t0160BANCOSDataGridViewTextBoxColumn";
            this.t0160BANCOSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // t0154CHEQUESBindingSource
            // 
            this.t0154CHEQUESBindingSource.DataSource = typeof(TecserEF.Entity.T0154_CHEQUES);
            // 
            // FrmGestionCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 788);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnTransferirCuenta);
            this.Controls.Add(this.grpModo);
            this.Name = "FrmGestionCheques";
            this.Text = "GESTION DE CHEQUES";
            this.Load += new System.EventHandler(this.FrmGestionCheques_Load);
            this.grpModo.ResumeLayout(false);
            this.grpModo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0154CHEQUESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpModo;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCHEQUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHENUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHEBANCODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHEINTERIORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHEFECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHECUITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHETITULARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHARECIBIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAENTREGADODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECIBONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROVEEDORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dISPONIBLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPORECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPGNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHRECHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHIDRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cALIFICACIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMENTARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSENTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSSALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPOSALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn t0160BANCOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t0154CHEQUESBindingSource;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTransferirCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
    }
}