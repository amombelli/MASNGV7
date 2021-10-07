namespace MASngFE.Transactional.FI.Factura
{
    partial class FrmLeyendasFactura
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
            this.ckImprimirMensajeMora = new System.Windows.Forms.CheckBox();
            this.ckPreimpreso = new System.Windows.Forms.CheckBox();
            this.txtObservacionesAdicionalesImprimir = new System.Windows.Forms.TextBox();
            this.ckSaldoTotalAdeudadoL2 = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAbandonar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckImprimirMensajeMora
            // 
            this.ckImprimirMensajeMora.AutoSize = true;
            this.ckImprimirMensajeMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckImprimirMensajeMora.Location = new System.Drawing.Point(11, 20);
            this.ckImprimirMensajeMora.Margin = new System.Windows.Forms.Padding(2);
            this.ckImprimirMensajeMora.Name = "ckImprimirMensajeMora";
            this.ckImprimirMensajeMora.Size = new System.Drawing.Size(199, 17);
            this.ckImprimirMensajeMora.TabIndex = 55;
            this.ckImprimirMensajeMora.Text = "IMPRIMIR MENSAJE DE MORA 4%";
            this.ckImprimirMensajeMora.UseVisualStyleBackColor = true;
            // 
            // ckPreimpreso
            // 
            this.ckPreimpreso.AutoSize = true;
            this.ckPreimpreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPreimpreso.Location = new System.Drawing.Point(11, 41);
            this.ckPreimpreso.Margin = new System.Windows.Forms.Padding(2);
            this.ckPreimpreso.Name = "ckPreimpreso";
            this.ckPreimpreso.Size = new System.Drawing.Size(257, 17);
            this.ckPreimpreso.TabIndex = 57;
            this.ckPreimpreso.Text = "UTILIZAR FACTURA PRE-IMPRESA [SOLO L1]";
            this.ckPreimpreso.UseVisualStyleBackColor = true;
            // 
            // txtObservacionesAdicionalesImprimir
            // 
            this.txtObservacionesAdicionalesImprimir.BackColor = System.Drawing.Color.Cornsilk;
            this.txtObservacionesAdicionalesImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesAdicionalesImprimir.Location = new System.Drawing.Point(8, 126);
            this.txtObservacionesAdicionalesImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacionesAdicionalesImprimir.Name = "txtObservacionesAdicionalesImprimir";
            this.txtObservacionesAdicionalesImprimir.Size = new System.Drawing.Size(460, 20);
            this.txtObservacionesAdicionalesImprimir.TabIndex = 56;
            this.txtObservacionesAdicionalesImprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckSaldoTotalAdeudadoL2
            // 
            this.ckSaldoTotalAdeudadoL2.AutoSize = true;
            this.ckSaldoTotalAdeudadoL2.BackColor = System.Drawing.Color.LightGreen;
            this.ckSaldoTotalAdeudadoL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSaldoTotalAdeudadoL2.Location = new System.Drawing.Point(11, 62);
            this.ckSaldoTotalAdeudadoL2.Margin = new System.Windows.Forms.Padding(2);
            this.ckSaldoTotalAdeudadoL2.Name = "ckSaldoTotalAdeudadoL2";
            this.ckSaldoTotalAdeudadoL2.Size = new System.Drawing.Size(271, 17);
            this.ckSaldoTotalAdeudadoL2.TabIndex = 59;
            this.ckSaldoTotalAdeudadoL2.Text = "OCULTAR SALDO TOTAL ADEUDADO [SOLO L2]";
            this.ckSaldoTotalAdeudadoL2.UseVisualStyleBackColor = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.LightBlue;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(8, 111);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(257, 13);
            this.label33.TabIndex = 58;
            this.label33.Text = "OBSERVACIONES ADICIONALES PARA IMPRIMIR";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(485, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 42);
            this.btnSalir.TabIndex = 61;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAbandonar
            // 
            this.btnAbandonar.Location = new System.Drawing.Point(485, 54);
            this.btnAbandonar.Name = "btnAbandonar";
            this.btnAbandonar.Size = new System.Drawing.Size(87, 42);
            this.btnAbandonar.TabIndex = 62;
            this.btnAbandonar.Text = "Abandonar";
            this.btnAbandonar.UseVisualStyleBackColor = true;
            this.btnAbandonar.Click += new System.EventHandler(this.btnAbandonar_Click);
            // 
            // FrmLeyendasFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 157);
            this.Controls.Add(this.btnAbandonar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.ckImprimirMensajeMora);
            this.Controls.Add(this.ckPreimpreso);
            this.Controls.Add(this.txtObservacionesAdicionalesImprimir);
            this.Controls.Add(this.ckSaldoTotalAdeudadoL2);
            this.Controls.Add(this.label33);
            this.Name = "FrmLeyendasFactura";
            this.Text = "IMPRESION DE LEYENDAS";
            this.Load += new System.EventHandler(this.FrmLeyendasFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckImprimirMensajeMora;
        private System.Windows.Forms.CheckBox ckPreimpreso;
        private System.Windows.Forms.TextBox txtObservacionesAdicionalesImprimir;
        private System.Windows.Forms.CheckBox ckSaldoTotalAdeudadoL2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAbandonar;
    }
}