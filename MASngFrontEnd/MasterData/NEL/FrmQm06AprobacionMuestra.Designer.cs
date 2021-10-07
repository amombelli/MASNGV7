namespace MASngFE.MasterData.NEL
{
    partial class FrmQm06AprobacionMuestra
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
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaAprobacion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAprobadoPor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(369, 13);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 40);
            this.btnGrabar.TabIndex = 82;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(369, 53);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 83;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNel
            // 
            this.txtNel.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNel.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNel.Location = new System.Drawing.Point(126, 3);
            this.txtNel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNel.Name = "txtNel";
            this.txtNel.ReadOnly = true;
            this.txtNel.Size = new System.Drawing.Size(62, 22);
            this.txtNel.TabIndex = 78;
            this.txtNel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(15, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 79;
            this.label3.Text = "Numero NEL ";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Navy;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(2, 34);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(351, 19);
            this.label32.TabIndex = 81;
            this.label32.Text = "APROBACION DE MUESTRA";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaAprobacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAprobadoPor);
            this.panel1.Location = new System.Drawing.Point(2, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 53);
            this.panel1.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 77;
            this.label2.Text = "FECHA APROBACION";
            // 
            // dtpFechaAprobacion
            // 
            this.dtpFechaAprobacion.Location = new System.Drawing.Point(137, 24);
            this.dtpFechaAprobacion.Name = "dtpFechaAprobacion";
            this.dtpFechaAprobacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaAprobacion.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 75;
            this.label1.Text = "APROBADO POR";
            // 
            // txtAprobadoPor
            // 
            this.txtAprobadoPor.BackColor = System.Drawing.Color.White;
            this.txtAprobadoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAprobadoPor.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtAprobadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAprobadoPor.Location = new System.Drawing.Point(137, 2);
            this.txtAprobadoPor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAprobadoPor.Name = "txtAprobadoPor";
            this.txtAprobadoPor.Size = new System.Drawing.Size(167, 21);
            this.txtAprobadoPor.TabIndex = 74;
            this.txtAprobadoPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmQm06AprobacionMuestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(478, 116);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQm06AprobacionMuestra";
            this.Text = "QM06 - NEL [Aprobacion de Muestra]";
            this.Load += new System.EventHandler(this.FrmAprobacionMuestra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaAprobacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAprobadoPor;
    }
}