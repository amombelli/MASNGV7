namespace MASngFE.Transactional.QM
{
    partial class FrmQm16MaterialesSinAsignacionPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMaterialesSinPlan = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIplanDescription = new System.Windows.Forms.TextBox();
            this.txtIPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialesSinPlan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMaterialesSinPlan
            // 
            this.dgvMaterialesSinPlan.AllowUserToAddRows = false;
            this.dgvMaterialesSinPlan.AllowUserToDeleteRows = false;
            this.dgvMaterialesSinPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialesSinPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Add});
            this.dgvMaterialesSinPlan.Location = new System.Drawing.Point(3, 56);
            this.dgvMaterialesSinPlan.MultiSelect = false;
            this.dgvMaterialesSinPlan.Name = "dgvMaterialesSinPlan";
            this.dgvMaterialesSinPlan.ReadOnly = true;
            this.dgvMaterialesSinPlan.RowHeadersWidth = 30;
            this.dgvMaterialesSinPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterialesSinPlan.Size = new System.Drawing.Size(253, 540);
            this.dgvMaterialesSinPlan.TabIndex = 67;
            this.dgvMaterialesSinPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMaterialesSinPlan_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(333, 40);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 73;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "MATERIALES SIN PLAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Add.DefaultCellStyle = dataGridViewCellStyle5;
            this.Add.HeaderText = "Agregar";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            this.Add.Text = "Agregar";
            this.Add.ToolTipText = "Agrega el Material Seleccionado al Plan de Inspeccion";
            this.Add.UseColumnTextForButtonValue = true;
            this.Add.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.txtIplanDescription);
            this.panel1.Controls.Add(this.txtIPName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 31);
            this.panel1.TabIndex = 75;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plan Insp";
            // 
            // FrmQm16MaterialesSinAsignacionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvMaterialesSinPlan);
            this.Name = "FrmQm16MaterialesSinAsignacionPlan";
            this.Text = "QM16 - Materiales sin Plan Asociado";
            this.Load += new System.EventHandler(this.FrmQm16MaterialesSinAsignacionPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialesSinPlan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaterialesSinPlan;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIplanDescription;
        private System.Windows.Forms.TextBox txtIPName;
        private System.Windows.Forms.Label label2;
    }
}