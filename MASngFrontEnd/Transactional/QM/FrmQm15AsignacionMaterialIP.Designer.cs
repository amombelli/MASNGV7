namespace MASngFE.Transactional.QM
{
    partial class FrmQm15AsignacionMaterialIp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQm15AsignacionMaterialIp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIplanDescription = new System.Windows.Forms.TextBox();
            this.txtIPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListaMaterialesPlan = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMaterialesPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.txtIplanDescription);
            this.panel1.Controls.Add(this.txtIPName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 31);
            this.panel1.TabIndex = 65;
            // 
            // txtIplanDescription
            // 
            this.txtIplanDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIplanDescription.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtIplanDescription.Location = new System.Drawing.Point(152, 4);
            this.txtIplanDescription.Name = "txtIplanDescription";
            this.txtIplanDescription.ReadOnly = true;
            this.txtIplanDescription.Size = new System.Drawing.Size(264, 21);
            this.txtIplanDescription.TabIndex = 14;
            this.txtIplanDescription.TabStop = false;
            // 
            // txtIPName
            // 
            this.txtIPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtIPName.Location = new System.Drawing.Point(71, 4);
            this.txtIPName.Name = "txtIPName";
            this.txtIPName.ReadOnly = true;
            this.txtIPName.Size = new System.Drawing.Size(78, 21);
            this.txtIPName.TabIndex = 2;
            this.txtIPName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plan Insp";
            // 
            // dgvListaMaterialesPlan
            // 
            this.dgvListaMaterialesPlan.AllowUserToAddRows = false;
            this.dgvListaMaterialesPlan.AllowUserToDeleteRows = false;
            this.dgvListaMaterialesPlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListaMaterialesPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMaterialesPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvListaMaterialesPlan.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvListaMaterialesPlan.Location = new System.Drawing.Point(2, 40);
            this.dgvListaMaterialesPlan.MultiSelect = false;
            this.dgvListaMaterialesPlan.Name = "dgvListaMaterialesPlan";
            this.dgvListaMaterialesPlan.ReadOnly = true;
            this.dgvListaMaterialesPlan.RowHeadersWidth = 30;
            this.dgvListaMaterialesPlan.Size = new System.Drawing.Size(258, 657);
            this.dgvListaMaterialesPlan.TabIndex = 66;
            this.dgvListaMaterialesPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaMaterialesPlan_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Eliminar el Material del Plan";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 70;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(266, 80);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 72;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMaterial.Image")));
            this.btnAddMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMaterial.Location = new System.Drawing.Point(266, 40);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(100, 40);
            this.btnAddMaterial.TabIndex = 71;
            this.btnAddMaterial.Text = "Agregar\r\nMaterial\r\n";
            this.btnAddMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.BtnAddMaterial_Click);
            // 
            // FrmQm15AsignacionMaterialIp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 700);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.dgvListaMaterialesPlan);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQm15AsignacionMaterialIp";
            this.Text = "QM15 - Asignacion de Material a Inspection Plan";
            this.Load += new System.EventHandler(this.FrmQm15AsignacionMaterialIP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMaterialesPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIplanDescription;
        private System.Windows.Forms.TextBox txtIPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaMaterialesPlan;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}