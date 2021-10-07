using TSControls;

namespace MASngFE._0TSUserControls
{
    partial class TsUcCustomerSearch1
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.T0006Bs = new System.Windows.Forms.BindingSource(this.components);
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsckSoloActivo = new TSControls.CtlCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerId6 = new System.Windows.Forms.TextBox();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tsckSoloActivo);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 25);
            this.panel2.TabIndex = 100;
            // 
            // tsckSoloActivo
            // 
            this.tsckSoloActivo.ColorChecked = System.Drawing.Color.LightGreen;
            this.tsckSoloActivo.ColorUnChecked = System.Drawing.Color.Khaki;
            this.tsckSoloActivo.LabelText = "Visualizar Solo Clientes Activos";
            this.tsckSoloActivo.Location = new System.Drawing.Point(6, 3);
            this.tsckSoloActivo.Name = "tsckSoloActivo";
            this.tsckSoloActivo.Size = new System.Drawing.Size(205, 16);
            this.tsckSoloActivo.TabIndex = 95;
            this.tsckSoloActivo.Value = false;
            this.tsckSoloActivo.CheckedChanged += new System.EventHandler(this.tsckSoloActivo_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCustomerId6);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 60);
            this.panel1.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Fantasia";
            // 
            // txtCustomerId6
            // 
            this.txtCustomerId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtCustomerId6.Location = new System.Drawing.Point(453, 9);
            this.txtCustomerId6.Name = "txtCustomerId6";
            this.txtCustomerId6.Size = new System.Drawing.Size(75, 20);
            this.txtCustomerId6.TabIndex = 2;
            this.txtCustomerId6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerId6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloEntero);
            this.txtCustomerId6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId6_KeyUp);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.T0006Bs;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(111, 9);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(340, 22);
            this.cmbFantasia.TabIndex = 0;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.ClienteTextUpdate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.T0006Bs;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(111, 32);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(340, 22);
            this.cmbRazonSocial.TabIndex = 1;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.ClienteTextUpdate);
            // 
            // TsUcCustomerSearch1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TsUcCustomerSearch1";
            this.Size = new System.Drawing.Size(537, 89);
            this.Load += new System.EventHandler(this.TsCustomerSearchSimple_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource T0006Bs;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerId6;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        public CtlCheckBox tsckSoloActivo;
    }
}
