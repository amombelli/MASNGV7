namespace MASngFE.Transactional.SD.Remito
{
    partial class FrmSD22RefactuRemito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD22RefactuRemito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.cFechaRemitoNew = new TSControls.CtlFechaTs();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLxOri = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumRemitoOri = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumRemitoNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLxNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlSemaforoValidado = new TSControls.CtlSemaforo();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStatusRemitoNew = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatusRemitoOri = new System.Windows.Forms.TextBox();
            this.t0057REMITOIPRINTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvItemRemitos = new System.Windows.Forms.DataGridView();
            this.xiditem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDMATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xkgdespachados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xlote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vISIBLEREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vISIBLEFADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtObservacionRemito = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0057REMITOIPRINTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemRemitos)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(723, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 40);
            this.btnExit.TabIndex = 57;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(723, 42);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(112, 40);
            this.btnImprimir.TabIndex = 53;
            this.btnImprimir.Text = "Imprimir\r\nREMITO";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cFechaRemitoNew
            // 
            this.cFechaRemitoNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cFechaRemitoNew.CheckPeriodoFIAuto = false;
            this.cFechaRemitoNew.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cFechaRemitoNew.ColorForeFecha = System.Drawing.Color.Empty;
            this.cFechaRemitoNew.FechaMaxima = null;
            this.cFechaRemitoNew.FechaMinima = null;
            this.cFechaRemitoNew.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cFechaRemitoNew.Location = new System.Drawing.Point(153, 50);
            this.cFechaRemitoNew.Name = "cFechaRemitoNew";
            this.cFechaRemitoNew.ObtieneTCAuto = false;
            this.cFechaRemitoNew.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cFechaRemitoNew.Size = new System.Drawing.Size(117, 26);
            this.cFechaRemitoNew.TabIndex = 131;
            this.cFechaRemitoNew.ValidarRangoFecha = false;
            this.cFechaRemitoNew.Value = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 14);
            this.label10.TabIndex = 130;
            this.label10.Text = "Numero Validado";
            // 
            // txtLxOri
            // 
            this.txtLxOri.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLxOri.ForeColor = System.Drawing.Color.Navy;
            this.txtLxOri.Location = new System.Drawing.Point(252, 5);
            this.txtLxOri.Name = "txtLxOri";
            this.txtLxOri.ReadOnly = true;
            this.txtLxOri.Size = new System.Drawing.Size(35, 22);
            this.txtLxOri.TabIndex = 126;
            this.txtLxOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtStatusRemitoOri);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ctlSemaforoValidado);
            this.panel1.Controls.Add(this.txtStatusRemitoNew);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLxNew);
            this.panel1.Controls.Add(this.txtNumRemitoNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNumRemitoOri);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtLxOri);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cFechaRemitoNew);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 77);
            this.panel1.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(716, 3);
            this.label3.TabIndex = 145;
            // 
            // txtNumRemitoOri
            // 
            this.txtNumRemitoOri.Location = new System.Drawing.Point(153, 5);
            this.txtNumRemitoOri.Name = "txtNumRemitoOri";
            this.txtNumRemitoOri.ReadOnly = true;
            this.txtNumRemitoOri.Size = new System.Drawing.Size(97, 22);
            this.txtNumRemitoOri.TabIndex = 145;
            this.txtNumRemitoOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 14);
            this.label8.TabIndex = 130;
            this.label8.Text = "Numero Remito Original";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(-172, 50);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(70, 22);
            this.textBox9.TabIndex = 93;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-250, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 14);
            this.label12.TabIndex = 44;
            this.label12.Text = "Numero RC";
            // 
            // txtNumRemitoNew
            // 
            this.txtNumRemitoNew.Location = new System.Drawing.Point(153, 28);
            this.txtNumRemitoNew.Name = "txtNumRemitoNew";
            this.txtNumRemitoNew.Size = new System.Drawing.Size(97, 22);
            this.txtNumRemitoNew.TabIndex = 147;
            this.txtNumRemitoNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumRemitoNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumRemitoNew_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 14);
            this.label1.TabIndex = 146;
            this.label1.Text = "Numero Remito NUEVO";
            // 
            // txtLxNew
            // 
            this.txtLxNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLxNew.ForeColor = System.Drawing.Color.Navy;
            this.txtLxNew.Location = new System.Drawing.Point(252, 28);
            this.txtLxNew.Name = "txtLxNew";
            this.txtLxNew.ReadOnly = true;
            this.txtLxNew.Size = new System.Drawing.Size(35, 22);
            this.txtLxNew.TabIndex = 148;
            this.txtLxNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 149;
            this.label4.Text = "Fecha Remito";
            // 
            // ctlSemaforoValidado
            // 
            this.ctlSemaforoValidado.Location = new System.Drawing.Point(404, 27);
            this.ctlSemaforoValidado.Name = "ctlSemaforoValidado";
            this.ctlSemaforoValidado.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.ctlSemaforoValidado.Size = new System.Drawing.Size(23, 23);
            this.ctlSemaforoValidado.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(437, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 148;
            this.label6.Text = "Status Remito";
            // 
            // txtStatusRemitoNew
            // 
            this.txtStatusRemitoNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtStatusRemitoNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStatusRemitoNew.Location = new System.Drawing.Point(526, 28);
            this.txtStatusRemitoNew.Name = "txtStatusRemitoNew";
            this.txtStatusRemitoNew.ReadOnly = true;
            this.txtStatusRemitoNew.Size = new System.Drawing.Size(109, 22);
            this.txtStatusRemitoNew.TabIndex = 147;
            this.txtStatusRemitoNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(437, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 14);
            this.label7.TabIndex = 152;
            this.label7.Text = "Status Remito";
            // 
            // txtStatusRemitoOri
            // 
            this.txtStatusRemitoOri.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtStatusRemitoOri.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStatusRemitoOri.Location = new System.Drawing.Point(526, 4);
            this.txtStatusRemitoOri.Name = "txtStatusRemitoOri";
            this.txtStatusRemitoOri.ReadOnly = true;
            this.txtStatusRemitoOri.Size = new System.Drawing.Size(109, 22);
            this.txtStatusRemitoOri.TabIndex = 151;
            this.txtStatusRemitoOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t0057REMITOIPRINTBindingSource
            // 
            this.t0057REMITOIPRINTBindingSource.DataSource = typeof(TecserEF.Entity.T0057_REMITO_I_PRINT);
            // 
            // dgvItemRemitos
            // 
            this.dgvItemRemitos.AllowUserToAddRows = false;
            this.dgvItemRemitos.AllowUserToDeleteRows = false;
            this.dgvItemRemitos.AutoGenerateColumns = false;
            this.dgvItemRemitos.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xiditem,
            this.iDMATERIALDataGridViewTextBoxColumn,
            this.xdescripcion,
            this.xkgdespachados,
            this.xlote,
            this.vISIBLEREDataGridViewTextBoxColumn,
            this.vISIBLEFADataGridViewTextBoxColumn});
            this.dgvItemRemitos.DataSource = this.t0057REMITOIPRINTBindingSource;
            this.dgvItemRemitos.GridColor = System.Drawing.Color.MediumBlue;
            this.dgvItemRemitos.Location = new System.Drawing.Point(3, 122);
            this.dgvItemRemitos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItemRemitos.Name = "dgvItemRemitos";
            this.dgvItemRemitos.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemRemitos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItemRemitos.RowTemplate.Height = 24;
            this.dgvItemRemitos.Size = new System.Drawing.Size(716, 314);
            this.dgvItemRemitos.TabIndex = 155;
            // 
            // xiditem
            // 
            this.xiditem.DataPropertyName = "IDITEM";
            this.xiditem.HeaderText = "#IT";
            this.xiditem.Name = "xiditem";
            this.xiditem.ReadOnly = true;
            this.xiditem.Width = 65;
            // 
            // iDMATERIALDataGridViewTextBoxColumn
            // 
            this.iDMATERIALDataGridViewTextBoxColumn.DataPropertyName = "IDMATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.Name = "iDMATERIALDataGridViewTextBoxColumn";
            this.iDMATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xdescripcion
            // 
            this.xdescripcion.DataPropertyName = "DESC_REMITO";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            this.xdescripcion.DefaultCellStyle = dataGridViewCellStyle5;
            this.xdescripcion.HeaderText = "DESCRIPCION";
            this.xdescripcion.Name = "xdescripcion";
            this.xdescripcion.Width = 280;
            // 
            // xkgdespachados
            // 
            this.xkgdespachados.DataPropertyName = "KGDESPACHADOS_R";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.xkgdespachados.DefaultCellStyle = dataGridViewCellStyle6;
            this.xkgdespachados.HeaderText = "KG";
            this.xkgdespachados.Name = "xkgdespachados";
            this.xkgdespachados.Width = 60;
            // 
            // xlote
            // 
            this.xlote.DataPropertyName = "BATCH_REMITO";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            this.xlote.DefaultCellStyle = dataGridViewCellStyle7;
            this.xlote.HeaderText = "LOTE";
            this.xlote.Name = "xlote";
            // 
            // vISIBLEREDataGridViewTextBoxColumn
            // 
            this.vISIBLEREDataGridViewTextBoxColumn.DataPropertyName = "VISIBLE_RE";
            this.vISIBLEREDataGridViewTextBoxColumn.HeaderText = "V.RE";
            this.vISIBLEREDataGridViewTextBoxColumn.Name = "vISIBLEREDataGridViewTextBoxColumn";
            this.vISIBLEREDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vISIBLEREDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.vISIBLEREDataGridViewTextBoxColumn.Width = 40;
            // 
            // vISIBLEFADataGridViewTextBoxColumn
            // 
            this.vISIBLEFADataGridViewTextBoxColumn.DataPropertyName = "VISIBLE_FA";
            this.vISIBLEFADataGridViewTextBoxColumn.HeaderText = "V.FA";
            this.vISIBLEFADataGridViewTextBoxColumn.Name = "vISIBLEFADataGridViewTextBoxColumn";
            this.vISIBLEFADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vISIBLEFADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.vISIBLEFADataGridViewTextBoxColumn.Width = 40;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.txtObservacionRemito);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.textBox14);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 32);
            this.panel3.TabIndex = 153;
            // 
            // txtObservacionRemito
            // 
            this.txtObservacionRemito.Location = new System.Drawing.Point(153, 5);
            this.txtObservacionRemito.Name = "txtObservacionRemito";
            this.txtObservacionRemito.Size = new System.Drawing.Size(560, 22);
            this.txtObservacionRemito.TabIndex = 145;
            this.txtObservacionRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 14);
            this.label21.TabIndex = 130;
            this.label21.Text = "Observacion Remito";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(-172, 50);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(70, 22);
            this.textBox14.TabIndex = 93;
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(-250, 54);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 14);
            this.label23.TabIndex = 44;
            this.label23.Text = "Numero RC";
            // 
            // FrmSD22RefactuRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 439);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvItemRemitos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImprimir);
            this.Name = "FrmSD22RefactuRemito";
            this.Text = "SD22 - Refacturacion de Remitos [AUTO]";
            this.Load += new System.EventHandler(this.FrmSD22RefactuRemito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0057REMITOIPRINTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemRemitos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnImprimir;
        private TSControls.CtlFechaTs cFechaRemitoNew;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLxOri;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatusRemitoOri;
        private System.Windows.Forms.Label label6;
        private TSControls.CtlSemaforo ctlSemaforoValidado;
        private System.Windows.Forms.TextBox txtStatusRemitoNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLxNew;
        private System.Windows.Forms.TextBox txtNumRemitoNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumRemitoOri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource t0057REMITOIPRINTBindingSource;
        private System.Windows.Forms.DataGridView dgvItemRemitos;
        private System.Windows.Forms.DataGridViewTextBoxColumn xiditem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDMATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn xkgdespachados;
        private System.Windows.Forms.DataGridViewTextBoxColumn xlote;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vISIBLEREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vISIBLEFADataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtObservacionRemito;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label23;
    }
}