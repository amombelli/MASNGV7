namespace MASngFE.SuperMD
{
    partial class FrmCo10GLStructureTree
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCo10GLStructureTree));
            this.trvGL = new System.Windows.Forms.TreeView();
            this.cmbGLBuscar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSugerencia = new System.Windows.Forms.DataGridView();
            this.GL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnNuevaContabilizacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugerencia)).BeginInit();
            this.SuspendLayout();
            // 
            // trvGL
            // 
            this.trvGL.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.trvGL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvGL.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvGL.FullRowSelect = true;
            this.trvGL.Location = new System.Drawing.Point(12, 32);
            this.trvGL.Name = "trvGL";
            this.trvGL.Size = new System.Drawing.Size(475, 540);
            this.trvGL.TabIndex = 0;
            this.trvGL.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvGL_AfterSelect);
            this.trvGL.DoubleClick += new System.EventHandler(this.trvGL_DoubleClick);
            // 
            // cmbGLBuscar
            // 
            this.cmbGLBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGLBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGLBuscar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGLBuscar.FormattingEnabled = true;
            this.cmbGLBuscar.Location = new System.Drawing.Point(94, 6);
            this.cmbGLBuscar.Name = "cmbGLBuscar";
            this.cmbGLBuscar.Size = new System.Drawing.Size(393, 23);
            this.cmbGLBuscar.TabIndex = 1;
            this.cmbGLBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbGLBuscar_SelectedIndexChanged);
            this.cmbGLBuscar.TextUpdate += new System.EventHandler(this.cmbGLBuscar_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "CUENTA GL >>";
            // 
            // dgvSugerencia
            // 
            this.dgvSugerencia.AllowUserToAddRows = false;
            this.dgvSugerencia.AllowUserToDeleteRows = false;
            this.dgvSugerencia.AllowUserToOrderColumns = true;
            this.dgvSugerencia.AllowUserToResizeColumns = false;
            this.dgvSugerencia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSugerencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSugerencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugerencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GL,
            this.Descripcion});
            this.dgvSugerencia.Location = new System.Drawing.Point(489, 32);
            this.dgvSugerencia.Name = "dgvSugerencia";
            this.dgvSugerencia.Size = new System.Drawing.Size(372, 150);
            this.dgvSugerencia.TabIndex = 4;
            this.dgvSugerencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSugerencia_CellClick);
            // 
            // GL
            // 
            this.GL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GL.DataPropertyName = "GL";
            this.GL.HeaderText = "GL Acc";
            this.GL.Name = "GL";
            this.GL.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "GLDESC";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripcion.HeaderText = "GL DESCRIPTION";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(607, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "LISTADO DE SUGERENCIAS";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(867, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Salir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNuevaContabilizacion
            // 
            this.btnNuevaContabilizacion.Enabled = false;
            this.btnNuevaContabilizacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaContabilizacion.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaContabilizacion.Image")));
            this.btnNuevaContabilizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaContabilizacion.Location = new System.Drawing.Point(867, 71);
            this.btnNuevaContabilizacion.Name = "btnNuevaContabilizacion";
            this.btnNuevaContabilizacion.Size = new System.Drawing.Size(100, 39);
            this.btnNuevaContabilizacion.TabIndex = 10;
            this.btnNuevaContabilizacion.Text = "Nueva\r\nCONTA";
            this.btnNuevaContabilizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaContabilizacion.UseVisualStyleBackColor = true;
            // 
            // FrmCo10GLStructureTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 580);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNuevaContabilizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSugerencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGLBuscar);
            this.Controls.Add(this.trvGL);
            this.Name = "FrmCo10GLStructureTree";
            this.Text = "CO10 - Estructura de Cuentas Contables [G/L Accounts]";
            this.Load += new System.EventHandler(this.FrmGLStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugerencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvGL;
        private System.Windows.Forms.ComboBox cmbGLBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSugerencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnNuevaContabilizacion;
    }
}