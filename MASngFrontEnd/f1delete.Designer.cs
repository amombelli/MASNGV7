namespace MASngFE
{
    partial class f1delete
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ctlAddress1 = new MASngFE.NewUserControls.CtlAddress();
            this.ctlFechaTs1 = new TSControls.CtlFechaTs();
            this.ctlAlarmClock1 = new TSControls.CtlAlarmClock();
            this.ctlPeriodo1 = new TSControls.CtlPeriodo();
            this.ctlPeriodo2 = new TSControls.CtlPeriodo();
            this.ctlIconos1 = new TSControls.CtlIconos();
            this.ctlSemaforo1 = new TSControls.CtlSemaforo();
            this.ctlTextBox1 = new TSControls.CtlTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ctlAddress1
            // 
            this.ctlAddress1.AllowEditSources = false;
            this.ctlAddress1.AllowFreeText = true;
            this.ctlAddress1.AllowLocalidadProvincia = true;
            this.ctlAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAddress1.Location = new System.Drawing.Point(392, 104);
            this.ctlAddress1.Modo = 0;
            this.ctlAddress1.Name = "ctlAddress1";
            this.ctlAddress1.Size = new System.Drawing.Size(318, 122);
            this.ctlAddress1.TabIndex = 13;
            // 
            // ctlFechaTs1
            // 
            this.ctlFechaTs1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFechaTs1.BackColor = System.Drawing.Color.PaleGreen;
            this.ctlFechaTs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlFechaTs1.CheckPeriodoFIAuto = false;
            this.ctlFechaTs1.ColorFondoFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.ColorForeFecha = System.Drawing.Color.Empty;
            this.ctlFechaTs1.FechaMaxima = null;
            this.ctlFechaTs1.FechaMinima = null;
            this.ctlFechaTs1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFechaTs1.Location = new System.Drawing.Point(9, 200);
            this.ctlFechaTs1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlFechaTs1.Name = "ctlFechaTs1";
            this.ctlFechaTs1.ObtieneTCAuto = false;
            this.ctlFechaTs1.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Yellow;
            this.ctlFechaTs1.Size = new System.Drawing.Size(116, 30);
            this.ctlFechaTs1.TabIndex = 12;
            this.ctlFechaTs1.ValidarRangoFecha = false;
            this.ctlFechaTs1.Value = null;
            // 
            // ctlAlarmClock1
            // 
            this.ctlAlarmClock1.AlarmSet = false;
            this.ctlAlarmClock1.AlarmTime = new System.DateTime(((long)(0)));
            this.ctlAlarmClock1.ClockBackColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.ClockForeColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.Location = new System.Drawing.Point(106, 298);
            this.ctlAlarmClock1.Name = "ctlAlarmClock1";
            this.ctlAlarmClock1.Size = new System.Drawing.Size(8, 8);
            this.ctlAlarmClock1.TabIndex = 11;
            // 
            // ctlPeriodo1
            // 
            this.ctlPeriodo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPeriodo1.Location = new System.Drawing.Point(28, 147);
            this.ctlPeriodo1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlPeriodo1.Name = "ctlPeriodo1";
            this.ctlPeriodo1.Periodo = null;
            this.ctlPeriodo1.Size = new System.Drawing.Size(62, 21);
            this.ctlPeriodo1.TabIndex = 10;
            this.ctlPeriodo1.YearMaximo = 2023;
            this.ctlPeriodo1.YearMinimo = 2019;
            // 
            // ctlPeriodo2
            // 
            this.ctlPeriodo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPeriodo2.Location = new System.Drawing.Point(162, 205);
            this.ctlPeriodo2.Margin = new System.Windows.Forms.Padding(0);
            this.ctlPeriodo2.Name = "ctlPeriodo2";
            this.ctlPeriodo2.Periodo = null;
            this.ctlPeriodo2.Size = new System.Drawing.Size(62, 21);
            this.ctlPeriodo2.TabIndex = 9;
            this.ctlPeriodo2.YearMaximo = 0;
            this.ctlPeriodo2.YearMinimo = 0;
            // 
            // ctlIconos1
            // 
            this.ctlIconos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlIconos1.IconLocation = TSControls.UbicacionIcono.Center;
            this.ctlIconos1.IconSize = TSControls.TamañoIcono.Grande;
            this.ctlIconos1.Location = new System.Drawing.Point(114, 337);
            this.ctlIconos1.Name = "ctlIconos1";
            this.ctlIconos1.Set = TSControls.CIconos.ExclamacionYellow;
            this.ctlIconos1.Size = new System.Drawing.Size(30, 30);
            this.ctlIconos1.TabIndex = 7;
            // 
            // ctlSemaforo1
            // 
            this.ctlSemaforo1.Location = new System.Drawing.Point(334, 200);
            this.ctlSemaforo1.Name = "ctlSemaforo1";
            this.ctlSemaforo1.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.ctlSemaforo1.Size = new System.Drawing.Size(23, 23);
            this.ctlSemaforo1.TabIndex = 6;
            // 
            // ctlTextBox1
            // 
            this.ctlTextBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox1.Location = new System.Drawing.Point(147, 57);
            this.ctlTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlTextBox1.Name = "ctlTextBox1";
            this.ctlTextBox1.SetAlineacion = TSControls.CtlTextBox.Alineacion.Izquierda;
            this.ctlTextBox1.SetDecimales = 0;
            this.ctlTextBox1.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.ctlTextBox1.Size = new System.Drawing.Size(107, 21);
            this.ctlTextBox1.TabIndex = 4;
            this.ctlTextBox1.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ctlTextBox1.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.ctlTextBox1.XReadOnly = false;
            // 
            // f1delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ctlAddress1);
            this.Controls.Add(this.ctlFechaTs1);
            this.Controls.Add(this.ctlAlarmClock1);
            this.Controls.Add(this.ctlPeriodo1);
            this.Controls.Add(this.ctlPeriodo2);
            this.Controls.Add(this.ctlIconos1);
            this.Controls.Add(this.ctlSemaforo1);
            this.Controls.Add(this.ctlTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "f1delete";
            this.Text = "f1delete";
            this.Load += new System.EventHandler(this.f1delete_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private TSControls.CtlTextBox ctlTextBox1;
        private TSControls.CtlSemaforo ctlSemaforo1;
        private TSControls.CtlIconos ctlIconos1;
        private TSControls.CtlPeriodo ctlPeriodo2;
        private TSControls.CtlPeriodo ctlPeriodo1;
        private TSControls.CtlAlarmClock ctlAlarmClock1;
        private TSControls.CtlFechaTs ctlFechaTs1;
        private NewUserControls.CtlAddress ctlAddress1;
        private System.Windows.Forms.Button button2;
    }
}