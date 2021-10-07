namespace MASngFE.Application
{
    partial class FrmApp02ControlsInForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApp02ControlsInForms));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroArgs = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArg2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArg1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNombreFormulario = new System.Windows.Forms.ComboBox();
            this.txtNoManejados = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.containerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtnElmentControlManagedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIgnorados = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dgvListaTexto = new System.Windows.Forms.DataGridView();
            this.btnVerIgnorado = new System.Windows.Forms.Button();
            this.btnVerNoManejado = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTcodeDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTcode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidadParametros = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtnElmentControlManagedBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTexto)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.txtNumeroArgs);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtArg2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtArg1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbNombreFormulario);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 75);
            this.panel1.TabIndex = 0;
            // 
            // txtNumeroArgs
            // 
            this.txtNumeroArgs.Location = new System.Drawing.Point(396, 5);
            this.txtNumeroArgs.Name = "txtNumeroArgs";
            this.txtNumeroArgs.Size = new System.Drawing.Size(32, 21);
            this.txtNumeroArgs.TabIndex = 74;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(461, 4);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(110, 44);
            this.btnRun.TabIndex = 73;
            this.btnRun.Text = "RUN!";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Arg2 #";
            // 
            // txtArg2
            // 
            this.txtArg2.Location = new System.Drawing.Point(100, 50);
            this.txtArg2.Name = "txtArg2";
            this.txtArg2.Size = new System.Drawing.Size(69, 21);
            this.txtArg2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Arg1 #";
            // 
            // txtArg1
            // 
            this.txtArg1.Location = new System.Drawing.Point(100, 28);
            this.txtArg1.Name = "txtArg1";
            this.txtArg1.Size = new System.Drawing.Size(69, 21);
            this.txtArg1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Form";
            // 
            // cmbNombreFormulario
            // 
            this.cmbNombreFormulario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNombreFormulario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNombreFormulario.FormattingEnabled = true;
            this.cmbNombreFormulario.Location = new System.Drawing.Point(100, 4);
            this.cmbNombreFormulario.Name = "cmbNombreFormulario";
            this.cmbNombreFormulario.Size = new System.Drawing.Size(295, 23);
            this.cmbNombreFormulario.TabIndex = 1;
            this.cmbNombreFormulario.SelectedIndexChanged += new System.EventHandler(this.cmbNombreFormulario_SelectedIndexChanged);
            // 
            // txtNoManejados
            // 
            this.txtNoManejados.Location = new System.Drawing.Point(115, 3);
            this.txtNoManejados.Name = "txtNoManejados";
            this.txtNoManejados.Size = new System.Drawing.Size(35, 21);
            this.txtNoManejados.TabIndex = 3;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.containerDataGridViewTextBoxColumn,
            this.TabValue,
            this.typeDataGridViewTextBoxColumn,
            this.controlDataGridViewTextBoxColumn,
            this.mapActionDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.rtnElmentControlManagedBindingSource;
            this.dgvData.GridColor = System.Drawing.Color.Indigo;
            this.dgvData.Location = new System.Drawing.Point(3, 136);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(678, 801);
            this.dgvData.TabIndex = 5;
            // 
            // containerDataGridViewTextBoxColumn
            // 
            this.containerDataGridViewTextBoxColumn.DataPropertyName = "Container";
            this.containerDataGridViewTextBoxColumn.HeaderText = "Container";
            this.containerDataGridViewTextBoxColumn.Name = "containerDataGridViewTextBoxColumn";
            this.containerDataGridViewTextBoxColumn.ReadOnly = true;
            this.containerDataGridViewTextBoxColumn.Width = 150;
            // 
            // TabValue
            // 
            this.TabValue.DataPropertyName = "TabValue";
            this.TabValue.HeaderText = "Tab#";
            this.TabValue.Name = "TabValue";
            this.TabValue.ReadOnly = true;
            this.TabValue.Width = 40;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 80;
            // 
            // controlDataGridViewTextBoxColumn
            // 
            this.controlDataGridViewTextBoxColumn.DataPropertyName = "Control";
            this.controlDataGridViewTextBoxColumn.HeaderText = "Control";
            this.controlDataGridViewTextBoxColumn.Name = "controlDataGridViewTextBoxColumn";
            this.controlDataGridViewTextBoxColumn.ReadOnly = true;
            this.controlDataGridViewTextBoxColumn.Width = 120;
            // 
            // mapActionDataGridViewTextBoxColumn
            // 
            this.mapActionDataGridViewTextBoxColumn.DataPropertyName = "MapAction";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mapActionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.mapActionDataGridViewTextBoxColumn.HeaderText = "MapAction";
            this.mapActionDataGridViewTextBoxColumn.Name = "mapActionDataGridViewTextBoxColumn";
            this.mapActionDataGridViewTextBoxColumn.ReadOnly = true;
            this.mapActionDataGridViewTextBoxColumn.Width = 230;
            // 
            // rtnElmentControlManagedBindingSource
            // 
            this.rtnElmentControlManagedBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.RtnElmentControlManaged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "No Manejados #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ignorados #";
            // 
            // txtIgnorados
            // 
            this.txtIgnorados.Location = new System.Drawing.Point(115, 26);
            this.txtIgnorados.Name = "txtIgnorados";
            this.txtIgnorados.Size = new System.Drawing.Size(35, 21);
            this.txtIgnorados.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNoManejados);
            this.panel2.Controls.Add(this.txtIgnorados);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(587, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 84);
            this.panel2.TabIndex = 6;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(920, 4);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(110, 44);
            this.btnRegresar.TabIndex = 72;
            this.btnRegresar.Text = "Volver";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dgvListaTexto
            // 
            this.dgvListaTexto.AllowUserToAddRows = false;
            this.dgvListaTexto.AllowUserToDeleteRows = false;
            this.dgvListaTexto.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvListaTexto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaTexto.GridColor = System.Drawing.Color.Indigo;
            this.dgvListaTexto.Location = new System.Drawing.Point(687, 136);
            this.dgvListaTexto.Name = "dgvListaTexto";
            this.dgvListaTexto.ReadOnly = true;
            this.dgvListaTexto.Size = new System.Drawing.Size(343, 755);
            this.dgvListaTexto.TabIndex = 73;
            // 
            // btnVerIgnorado
            // 
            this.btnVerIgnorado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerIgnorado.Image = ((System.Drawing.Image)(resources.GetObject("btnVerIgnorado.Image")));
            this.btnVerIgnorado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerIgnorado.Location = new System.Drawing.Point(687, 90);
            this.btnVerIgnorado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnVerIgnorado.Name = "btnVerIgnorado";
            this.btnVerIgnorado.Size = new System.Drawing.Size(110, 40);
            this.btnVerIgnorado.TabIndex = 75;
            this.btnVerIgnorado.Text = "Ignorado";
            this.btnVerIgnorado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerIgnorado.UseVisualStyleBackColor = true;
            this.btnVerIgnorado.Click += new System.EventHandler(this.btnVerIgnorado_Click);
            // 
            // btnVerNoManejado
            // 
            this.btnVerNoManejado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNoManejado.Image = ((System.Drawing.Image)(resources.GetObject("btnVerNoManejado.Image")));
            this.btnVerNoManejado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerNoManejado.Location = new System.Drawing.Point(805, 90);
            this.btnVerNoManejado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnVerNoManejado.Name = "btnVerNoManejado";
            this.btnVerNoManejado.Size = new System.Drawing.Size(110, 40);
            this.btnVerNoManejado.TabIndex = 76;
            this.btnVerNoManejado.Text = "No\r\nManejado";
            this.btnVerNoManejado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerNoManejado.UseVisualStyleBackColor = true;
            this.btnVerNoManejado.Click += new System.EventHandler(this.btnVerNoManejado_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.txtCantidadParametros);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtTcodeDescription);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtTcode);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(578, 53);
            this.panel3.TabIndex = 75;
            // 
            // txtTcodeDescription
            // 
            this.txtTcodeDescription.Location = new System.Drawing.Point(283, 5);
            this.txtTcodeDescription.Name = "txtTcodeDescription";
            this.txtTcodeDescription.ReadOnly = true;
            this.txtTcodeDescription.Size = new System.Drawing.Size(288, 21);
            this.txtTcodeDescription.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Par #";
            // 
            // txtTcode
            // 
            this.txtTcode.Location = new System.Drawing.Point(100, 5);
            this.txtTcode.Name = "txtTcode";
            this.txtTcode.ReadOnly = true;
            this.txtTcode.Size = new System.Drawing.Size(99, 21);
            this.txtTcode.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Transaccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 75;
            this.label6.Text = "Descripcion";
            // 
            // txtCantidadParametros
            // 
            this.txtCantidadParametros.Location = new System.Drawing.Point(100, 27);
            this.txtCantidadParametros.Name = "txtCantidadParametros";
            this.txtCantidadParametros.ReadOnly = true;
            this.txtCantidadParametros.Size = new System.Drawing.Size(37, 21);
            this.txtCantidadParametros.TabIndex = 76;
            // 
            // FrmApp02ControlsInForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 895);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnVerNoManejado);
            this.Controls.Add(this.btnVerIgnorado);
            this.Controls.Add(this.dgvListaTexto);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Name = "FrmApp02ControlsInForms";
            this.Text = "APP02 - Controls In Forms";
            this.Load += new System.EventHandler(this.FrmApp02ControlsInForms_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtnElmentControlManagedBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTexto)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNombreFormulario;
        private System.Windows.Forms.TextBox txtNoManejados;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource rtnElmentControlManagedBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIgnorados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn containerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TabValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArg2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArg1;
        private System.Windows.Forms.TextBox txtNumeroArgs;
        private System.Windows.Forms.DataGridView dgvListaTexto;
        private System.Windows.Forms.Button btnVerIgnorado;
        private System.Windows.Forms.Button btnVerNoManejado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTcodeDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCantidadParametros;
    }
}