namespace MASngFE.Transactional.WM
{
    partial class FrmWm01MoveStock
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
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSlocOriginal = new System.Windows.Forms.TextBox();
            this.txtDescripcionSlocOriginal = new System.Windows.Forms.TextBox();
            this.txtSeleccionKg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroLoteOriginal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstadoOriginal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNewSloc = new System.Windows.Forms.ComboBox();
            this.t0028SLOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtKgAMover = new System.Windows.Forms.TextBox();
            this.txtDescripcionNewSloc = new System.Windows.Forms.TextBox();
            this.btnMoveStockSLOC = new System.Windows.Forms.Button();
            this.txtLogMovimiento = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(117, 5);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(104, 23);
            this.txtMaterial.TabIndex = 0;
            this.txtMaterial.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ubicacion Actual";
            // 
            // txtSlocOriginal
            // 
            this.txtSlocOriginal.Location = new System.Drawing.Point(155, 53);
            this.txtSlocOriginal.Name = "txtSlocOriginal";
            this.txtSlocOriginal.ReadOnly = true;
            this.txtSlocOriginal.Size = new System.Drawing.Size(66, 23);
            this.txtSlocOriginal.TabIndex = 3;
            this.txtSlocOriginal.TabStop = false;
            this.txtSlocOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcionSlocOriginal
            // 
            this.txtDescripcionSlocOriginal.Location = new System.Drawing.Point(222, 53);
            this.txtDescripcionSlocOriginal.Name = "txtDescripcionSlocOriginal";
            this.txtDescripcionSlocOriginal.ReadOnly = true;
            this.txtDescripcionSlocOriginal.Size = new System.Drawing.Size(274, 23);
            this.txtDescripcionSlocOriginal.TabIndex = 5;
            this.txtDescripcionSlocOriginal.TabStop = false;
            // 
            // txtSeleccionKg
            // 
            this.txtSeleccionKg.Location = new System.Drawing.Point(117, 29);
            this.txtSeleccionKg.Name = "txtSeleccionKg";
            this.txtSeleccionKg.ReadOnly = true;
            this.txtSeleccionKg.Size = new System.Drawing.Size(61, 23);
            this.txtSeleccionKg.TabIndex = 6;
            this.txtSeleccionKg.TabStop = false;
            this.txtSeleccionKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtIdStock);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPlanta);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNumeroLoteOriginal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEstadoOriginal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Controls.Add(this.txtSlocOriginal);
            this.panel1.Controls.Add(this.txtSeleccionKg);
            this.panel1.Controls.Add(this.txtDescripcionSlocOriginal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 135);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "IdStock";
            // 
            // txtIdStock
            // 
            this.txtIdStock.Location = new System.Drawing.Point(429, 6);
            this.txtIdStock.Name = "txtIdStock";
            this.txtIdStock.ReadOnly = true;
            this.txtIdStock.Size = new System.Drawing.Size(67, 23);
            this.txtIdStock.TabIndex = 14;
            this.txtIdStock.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "KG Seleccion";
            // 
            // txtPlanta
            // 
            this.txtPlanta.Location = new System.Drawing.Point(117, 53);
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.ReadOnly = true;
            this.txtPlanta.Size = new System.Drawing.Size(37, 23);
            this.txtPlanta.TabIndex = 12;
            this.txtPlanta.TabStop = false;
            this.txtPlanta.Text = "CERR";
            this.txtPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lote Seleccionado";
            // 
            // txtNumeroLoteOriginal
            // 
            this.txtNumeroLoteOriginal.Location = new System.Drawing.Point(117, 77);
            this.txtNumeroLoteOriginal.Name = "txtNumeroLoteOriginal";
            this.txtNumeroLoteOriginal.ReadOnly = true;
            this.txtNumeroLoteOriginal.Size = new System.Drawing.Size(104, 23);
            this.txtNumeroLoteOriginal.TabIndex = 10;
            this.txtNumeroLoteOriginal.TabStop = false;
            this.txtNumeroLoteOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stock Status";
            // 
            // txtEstadoOriginal
            // 
            this.txtEstadoOriginal.Location = new System.Drawing.Point(117, 101);
            this.txtEstadoOriginal.Name = "txtEstadoOriginal";
            this.txtEstadoOriginal.ReadOnly = true;
            this.txtEstadoOriginal.Size = new System.Drawing.Size(104, 23);
            this.txtEstadoOriginal.TabIndex = 8;
            this.txtEstadoOriginal.TabStop = false;
            this.txtEstadoOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cmbNewSloc);
            this.panel2.Controls.Add(this.txtKgAMover);
            this.panel2.Controls.Add(this.txtDescripcionNewSloc);
            this.panel2.Location = new System.Drawing.Point(10, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 54);
            this.panel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 86;
            this.label7.Text = "Nueva Ubicacion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "KG a Mover";
            // 
            // cmbNewSloc
            // 
            this.cmbNewSloc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNewSloc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNewSloc.DataSource = this.t0028SLOCBindingSource;
            this.cmbNewSloc.DisplayMember = "SLOC";
            this.cmbNewSloc.FormattingEnabled = true;
            this.cmbNewSloc.Location = new System.Drawing.Point(140, 26);
            this.cmbNewSloc.Name = "cmbNewSloc";
            this.cmbNewSloc.Size = new System.Drawing.Size(80, 23);
            this.cmbNewSloc.TabIndex = 1;
            this.cmbNewSloc.ValueMember = "SLOC";
            this.cmbNewSloc.SelectedIndexChanged += new System.EventHandler(this.cmbNewSloc_SelectedIndexChanged);
            // 
            // t0028SLOCBindingSource
            // 
            this.t0028SLOCBindingSource.DataSource = typeof(TecserEF.Entity.T0028_SLOC);
            // 
            // txtKgAMover
            // 
            this.txtKgAMover.Location = new System.Drawing.Point(140, 2);
            this.txtKgAMover.Name = "txtKgAMover";
            this.txtKgAMover.Size = new System.Drawing.Size(80, 23);
            this.txtKgAMover.TabIndex = 0;
            this.txtKgAMover.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgAMover.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgAMover_KeyPress);
            this.txtKgAMover.Validating += new System.ComponentModel.CancelEventHandler(this.txtKgAMover_Validating);
            // 
            // txtDescripcionNewSloc
            // 
            this.txtDescripcionNewSloc.Location = new System.Drawing.Point(222, 26);
            this.txtDescripcionNewSloc.Name = "txtDescripcionNewSloc";
            this.txtDescripcionNewSloc.ReadOnly = true;
            this.txtDescripcionNewSloc.Size = new System.Drawing.Size(274, 23);
            this.txtDescripcionNewSloc.TabIndex = 5;
            this.txtDescripcionNewSloc.TabStop = false;
            // 
            // btnMoveStockSLOC
            // 
            this.btnMoveStockSLOC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveStockSLOC.Image = global::MASngFE.Properties.Resources.grua__1_;
            this.btnMoveStockSLOC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveStockSLOC.Location = new System.Drawing.Point(517, 179);
            this.btnMoveStockSLOC.Name = "btnMoveStockSLOC";
            this.btnMoveStockSLOC.Size = new System.Drawing.Size(100, 40);
            this.btnMoveStockSLOC.TabIndex = 2;
            this.btnMoveStockSLOC.Text = "Mover\r\nSTOCK";
            this.btnMoveStockSLOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoveStockSLOC.UseVisualStyleBackColor = true;
            this.btnMoveStockSLOC.Click += new System.EventHandler(this.btnMoveStockSLOC_Click);
            // 
            // txtLogMovimiento
            // 
            this.txtLogMovimiento.Location = new System.Drawing.Point(151, 221);
            this.txtLogMovimiento.Name = "txtLogMovimiento";
            this.txtLogMovimiento.ReadOnly = true;
            this.txtLogMovimiento.Size = new System.Drawing.Size(80, 23);
            this.txtLogMovimiento.TabIndex = 14;
            this.txtLogMovimiento.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SlateGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(10, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(501, 19);
            this.label12.TabIndex = 16;
            this.label12.Text = "DATOS DE STOCK SELECCIONADO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(517, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 87;
            this.label8.Text = "ID Log";
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Navy;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(2, 2);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(624, 4);
            this.label58.TabIndex = 133;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Navy;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(622, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(4, 278);
            this.label11.TabIndex = 132;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 276);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(624, 4);
            this.label13.TabIndex = 134;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Navy;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 2);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(4, 278);
            this.label14.TabIndex = 135;
            // 
            // FrmWm01MoveStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 283);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnMoveStockSLOC);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLogMovimiento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmWm01MoveStock";
            this.Text = "WM01 - Cambiar Ubicacion de Material en Planta";
            this.Load += new System.EventHandler(this.FrmChangeSloc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSlocOriginal;
        private System.Windows.Forms.TextBox txtDescripcionSlocOriginal;
        private System.Windows.Forms.TextBox txtSeleccionKg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroLoteOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstadoOriginal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbNewSloc;
        private System.Windows.Forms.TextBox txtKgAMover;
        private System.Windows.Forms.TextBox txtDescripcionNewSloc;
        private System.Windows.Forms.TextBox txtLogMovimiento;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMoveStockSLOC;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource t0028SLOCBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}