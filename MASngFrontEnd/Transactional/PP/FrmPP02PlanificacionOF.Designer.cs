using System.Windows.Forms;

namespace MASngFE.Transactional.PP
{
    partial class FrmPP02PlanificacionOF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP02PlanificacionOF));
            this.txtMaterialPrimario = new System.Windows.Forms.TextBox();
            this.txtMaterialEtiqueta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroFormulaSeleccionada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFormulasTotales = new System.Windows.Forms.TextBox();
            this.txtNumeroFormulasActivas = new System.Windows.Forms.TextBox();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.txtnumeroOF = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtClienteFantasia = new System.Windows.Forms.TextBox();
            this.txtOrdenVentaNumero = new System.Windows.Forms.TextBox();
            this.txtPlanPara = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUltimaFabricacion = new System.Windows.Forms.TextBox();
            this.txtConsumoU30 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtConsumoU60 = new System.Windows.Forms.TextBox();
            this.txtNumeroClientes = new System.Windows.Forms.TextBox();
            this.txtConsumoP30 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtStockLiberado = new System.Windows.Forms.TextBox();
            this.txtStockTotal = new System.Windows.Forms.TextBox();
            this.dgvFormulaSeleccionada = new System.Windows.Forms.DataGridView();
            this.idItemFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__primario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__reproceso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__recalculo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STKLiberado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STKTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0072Bs = new System.Windows.Forms.BindingSource(this.components);
            this.txtKgFabricarOri = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObservacionPF = new System.Windows.Forms.TextBox();
            this.panelFormulacion = new System.Windows.Forms.Panel();
            this.ckAutoFormulacion = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.semFormulado = new TSControls.CtlSemaforo();
            this.btnCancelFormulacion = new System.Windows.Forms.Button();
            this.btnSeleccionarFormula1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnVerFormulas1 = new System.Windows.Forms.Button();
            this.txtFechaUltimaFormulacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionFormulaSeleccionada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPlanear = new System.Windows.Forms.Button();
            this.btnImprimirFormula = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAutoReserva = new System.Windows.Forms.Button();
            this.btnModificarTamañoBatch1 = new System.Windows.Forms.Button();
            this.btnFreeStock = new System.Windows.Forms.Button();
            this.ckReservaAutomaticaStock = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtBatchQuantity = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtKgFabricarBatch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtFechaCompromisoPlan = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtKgPlaneados = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.cmbRecursoProduccion = new System.Windows.Forms.ComboBox();
            this.dtpFechaPlan = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnStandBy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotaOrdenFabricacion = new System.Windows.Forms.TextBox();
            this.btnCancelarOF = new System.Windows.Forms.Button();
            this.lblStockNoDisponible = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtContainerId = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCantidadContainers = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbContainer = new System.Windows.Forms.ComboBox();
            this.t0010ContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckUpdateContainer = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelAprobacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStatusLab = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtKgFabricadosIngresados = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.panelMRP = new System.Windows.Forms.Panel();
            this.txtKgPendienteEntrega = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.btnDetalleIngreso = new System.Windows.Forms.Button();
            this.btnCQLab = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.lineaDerecha = new System.Windows.Forms.Label();
            this.lineaAbajo = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRefreshStock = new System.Windows.Forms.Button();
            this.semFormulacion = new TSControls.CtlSemaforo();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.semDetBatch = new TSControls.CtlSemaforo();
            this.label42 = new System.Windows.Forms.Label();
            this.semPlan = new TSControls.CtlSemaforo();
            this.label45 = new System.Windows.Forms.Label();
            this.semFabricacion = new TSControls.CtlSemaforo();
            this.label46 = new System.Windows.Forms.Label();
            this.semCierre = new TSControls.CtlSemaforo();
            this.label47 = new System.Windows.Forms.Label();
            this.semLabCq = new TSControls.CtlSemaforo();
            this.btnNoAutoriza = new System.Windows.Forms.Button();
            this.btnAutoriza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaSeleccionada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).BeginInit();
            this.panelFormulacion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelMRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaterialPrimario
            // 
            this.txtMaterialPrimario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterialPrimario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialPrimario.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialPrimario.ForeColor = System.Drawing.Color.Navy;
            this.txtMaterialPrimario.Location = new System.Drawing.Point(94, 6);
            this.txtMaterialPrimario.Name = "txtMaterialPrimario";
            this.txtMaterialPrimario.ReadOnly = true;
            this.txtMaterialPrimario.Size = new System.Drawing.Size(150, 19);
            this.txtMaterialPrimario.TabIndex = 1;
            // 
            // txtMaterialEtiqueta
            // 
            this.txtMaterialEtiqueta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterialEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialEtiqueta.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialEtiqueta.ForeColor = System.Drawing.Color.Navy;
            this.txtMaterialEtiqueta.Location = new System.Drawing.Point(94, 29);
            this.txtMaterialEtiqueta.Name = "txtMaterialEtiqueta";
            this.txtMaterialEtiqueta.ReadOnly = true;
            this.txtMaterialEtiqueta.Size = new System.Drawing.Size(150, 19);
            this.txtMaterialEtiqueta.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Formula Totales";
            // 
            // txtNumeroFormulaSeleccionada
            // 
            this.txtNumeroFormulaSeleccionada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroFormulaSeleccionada.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFormulaSeleccionada.Location = new System.Drawing.Point(81, 77);
            this.txtNumeroFormulaSeleccionada.Name = "txtNumeroFormulaSeleccionada";
            this.txtNumeroFormulaSeleccionada.ReadOnly = true;
            this.txtNumeroFormulaSeleccionada.Size = new System.Drawing.Size(48, 22);
            this.txtNumeroFormulaSeleccionada.TabIndex = 6;
            this.txtNumeroFormulaSeleccionada.TabStop = false;
            this.txtNumeroFormulaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Formula #";
            // 
            // txtNumeroFormulasTotales
            // 
            this.txtNumeroFormulasTotales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroFormulasTotales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFormulasTotales.Location = new System.Drawing.Point(137, 4);
            this.txtNumeroFormulasTotales.Name = "txtNumeroFormulasTotales";
            this.txtNumeroFormulasTotales.ReadOnly = true;
            this.txtNumeroFormulasTotales.Size = new System.Drawing.Size(34, 22);
            this.txtNumeroFormulasTotales.TabIndex = 9;
            this.txtNumeroFormulasTotales.TabStop = false;
            this.txtNumeroFormulasTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroFormulasActivas
            // 
            this.txtNumeroFormulasActivas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroFormulasActivas.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFormulasActivas.Location = new System.Drawing.Point(137, 27);
            this.txtNumeroFormulasActivas.Name = "txtNumeroFormulasActivas";
            this.txtNumeroFormulasActivas.ReadOnly = true;
            this.txtNumeroFormulasActivas.Size = new System.Drawing.Size(34, 22);
            this.txtNumeroFormulasActivas.TabIndex = 10;
            this.txtNumeroFormulasActivas.TabStop = false;
            this.txtNumeroFormulasActivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroLote.Location = new System.Drawing.Point(123, 95);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.ReadOnly = true;
            this.txtNumeroLote.Size = new System.Drawing.Size(84, 22);
            this.txtNumeroLote.TabIndex = 14;
            this.txtNumeroLote.TabStop = false;
            this.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtnumeroOF
            // 
            this.txtnumeroOF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtnumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnumeroOF.Font = new System.Drawing.Font("Calibri", 15F);
            this.txtnumeroOF.ForeColor = System.Drawing.Color.Red;
            this.txtnumeroOF.Location = new System.Drawing.Point(1147, 8);
            this.txtnumeroOF.Name = "txtnumeroOF";
            this.txtnumeroOF.ReadOnly = true;
            this.txtnumeroOF.Size = new System.Drawing.Size(79, 32);
            this.txtnumeroOF.TabIndex = 12;
            this.txtnumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(664, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(116, 15);
            this.txtStatus.TabIndex = 22;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // txtClienteFantasia
            // 
            this.txtClienteFantasia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClienteFantasia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteFantasia.Location = new System.Drawing.Point(117, 49);
            this.txtClienteFantasia.Name = "txtClienteFantasia";
            this.txtClienteFantasia.ReadOnly = true;
            this.txtClienteFantasia.Size = new System.Drawing.Size(264, 22);
            this.txtClienteFantasia.TabIndex = 20;
            // 
            // txtOrdenVentaNumero
            // 
            this.txtOrdenVentaNumero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOrdenVentaNumero.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenVentaNumero.Location = new System.Drawing.Point(46, 49);
            this.txtOrdenVentaNumero.Name = "txtOrdenVentaNumero";
            this.txtOrdenVentaNumero.ReadOnly = true;
            this.txtOrdenVentaNumero.Size = new System.Drawing.Size(70, 22);
            this.txtOrdenVentaNumero.TabIndex = 18;
            this.txtOrdenVentaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlanPara
            // 
            this.txtPlanPara.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPlanPara.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanPara.Location = new System.Drawing.Point(117, 26);
            this.txtPlanPara.Name = "txtPlanPara";
            this.txtPlanPara.ReadOnly = true;
            this.txtPlanPara.Size = new System.Drawing.Size(72, 22);
            this.txtPlanPara.TabIndex = 16;
            this.txtPlanPara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "Fabricacion Para";
            // 
            // txtUltimaFabricacion
            // 
            this.txtUltimaFabricacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtUltimaFabricacion.Location = new System.Drawing.Point(319, 49);
            this.txtUltimaFabricacion.Name = "txtUltimaFabricacion";
            this.txtUltimaFabricacion.ReadOnly = true;
            this.txtUltimaFabricacion.Size = new System.Drawing.Size(95, 21);
            this.txtUltimaFabricacion.TabIndex = 24;
            this.txtUltimaFabricacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUltimaFabricacion.TextChanged += new System.EventHandler(this.txtUltimaFabricacion_TextChanged);
            // 
            // txtConsumoU30
            // 
            this.txtConsumoU30.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoU30.Location = new System.Drawing.Point(101, 3);
            this.txtConsumoU30.Name = "txtConsumoU30";
            this.txtConsumoU30.ReadOnly = true;
            this.txtConsumoU30.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoU30.TabIndex = 12;
            this.txtConsumoU30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(253, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 14);
            this.label22.TabIndex = 21;
            this.label22.Text = "Clientes #";
            // 
            // txtConsumoU60
            // 
            this.txtConsumoU60.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoU60.Location = new System.Drawing.Point(101, 49);
            this.txtConsumoU60.Name = "txtConsumoU60";
            this.txtConsumoU60.ReadOnly = true;
            this.txtConsumoU60.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoU60.TabIndex = 18;
            this.txtConsumoU60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroClientes
            // 
            this.txtNumeroClientes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroClientes.Location = new System.Drawing.Point(319, 3);
            this.txtNumeroClientes.Name = "txtNumeroClientes";
            this.txtNumeroClientes.ReadOnly = true;
            this.txtNumeroClientes.Size = new System.Drawing.Size(27, 22);
            this.txtNumeroClientes.TabIndex = 22;
            this.txtNumeroClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtConsumoP30
            // 
            this.txtConsumoP30.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoP30.Location = new System.Drawing.Point(101, 26);
            this.txtConsumoP30.Name = "txtConsumoP30";
            this.txtConsumoP30.ReadOnly = true;
            this.txtConsumoP30.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoP30.TabIndex = 20;
            this.txtConsumoP30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(218, 29);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 14);
            this.label27.TabIndex = 36;
            this.label27.Text = "Stock Liberado";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(218, 7);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 14);
            this.label28.TabIndex = 34;
            this.label28.Text = "Stock Total";
            // 
            // txtStockLiberado
            // 
            this.txtStockLiberado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStockLiberado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockLiberado.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtStockLiberado.Location = new System.Drawing.Point(309, 26);
            this.txtStockLiberado.Name = "txtStockLiberado";
            this.txtStockLiberado.ReadOnly = true;
            this.txtStockLiberado.Size = new System.Drawing.Size(72, 22);
            this.txtStockLiberado.TabIndex = 37;
            this.txtStockLiberado.DoubleClick += new System.EventHandler(this.txtStockTotal_DoubleClick);
            // 
            // txtStockTotal
            // 
            this.txtStockTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStockTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtStockTotal.Location = new System.Drawing.Point(309, 3);
            this.txtStockTotal.Name = "txtStockTotal";
            this.txtStockTotal.ReadOnly = true;
            this.txtStockTotal.Size = new System.Drawing.Size(72, 22);
            this.txtStockTotal.TabIndex = 35;
            this.txtStockTotal.DoubleClick += new System.EventHandler(this.txtStockTotal_DoubleClick);
            // 
            // dgvFormulaSeleccionada
            // 
            this.dgvFormulaSeleccionada.AllowUserToAddRows = false;
            this.dgvFormulaSeleccionada.AllowUserToDeleteRows = false;
            this.dgvFormulaSeleccionada.AutoGenerateColumns = false;
            this.dgvFormulaSeleccionada.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormulaSeleccionada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFormulaSeleccionada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulaSeleccionada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemFormulaDataGridViewTextBoxColumn,
            this.@__primario,
            this.cantidadBaseDataGridViewTextBoxColumn,
            this.@__porcentaje,
            this.@__kg,
            this.batchNumberDataGridViewTextBoxColumn,
            this.@__reproceso,
            this.@__added,
            this.@__recalculo,
            this.STKLiberado,
            this.STKTotal});
            this.dgvFormulaSeleccionada.DataSource = this.t0072Bs;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFormulaSeleccionada.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvFormulaSeleccionada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFormulaSeleccionada.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvFormulaSeleccionada.Location = new System.Drawing.Point(400, 180);
            this.dgvFormulaSeleccionada.MultiSelect = false;
            this.dgvFormulaSeleccionada.Name = "dgvFormulaSeleccionada";
            this.dgvFormulaSeleccionada.ReadOnly = true;
            this.dgvFormulaSeleccionada.RowHeadersWidth = 10;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormulaSeleccionada.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvFormulaSeleccionada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFormulaSeleccionada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulaSeleccionada.Size = new System.Drawing.Size(538, 367);
            this.dgvFormulaSeleccionada.TabIndex = 0;
            this.dgvFormulaSeleccionada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaSeleccionada_CellDoubleClick);
            // 
            // idItemFormulaDataGridViewTextBoxColumn
            // 
            this.idItemFormulaDataGridViewTextBoxColumn.DataPropertyName = "idItemFormula";
            this.idItemFormulaDataGridViewTextBoxColumn.HeaderText = "Id#";
            this.idItemFormulaDataGridViewTextBoxColumn.Name = "idItemFormulaDataGridViewTextBoxColumn";
            this.idItemFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemFormulaDataGridViewTextBoxColumn.Width = 35;
            // 
            // __primario
            // 
            this.@__primario.DataPropertyName = "Primario";
            this.@__primario.HeaderText = "Primario";
            this.@__primario.Name = "__primario";
            this.@__primario.ReadOnly = true;
            this.@__primario.Width = 85;
            // 
            // cantidadBaseDataGridViewTextBoxColumn
            // 
            this.cantidadBaseDataGridViewTextBoxColumn.DataPropertyName = "CantidadBase";
            dataGridViewCellStyle10.Format = "N2";
            this.cantidadBaseDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.cantidadBaseDataGridViewTextBoxColumn.HeaderText = "Base";
            this.cantidadBaseDataGridViewTextBoxColumn.Name = "cantidadBaseDataGridViewTextBoxColumn";
            this.cantidadBaseDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadBaseDataGridViewTextBoxColumn.Visible = false;
            this.cantidadBaseDataGridViewTextBoxColumn.Width = 40;
            // 
            // __porcentaje
            // 
            this.@__porcentaje.DataPropertyName = "CantidadPor";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "P2";
            dataGridViewCellStyle11.NullValue = "0";
            this.@__porcentaje.DefaultCellStyle = dataGridViewCellStyle11;
            this.@__porcentaje.HeaderText = "%";
            this.@__porcentaje.Name = "__porcentaje";
            this.@__porcentaje.ReadOnly = true;
            this.@__porcentaje.Width = 50;
            // 
            // __kg
            // 
            this.@__kg.DataPropertyName = "CantidadKG";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.@__kg.DefaultCellStyle = dataGridViewCellStyle12;
            this.@__kg.HeaderText = "KG";
            this.@__kg.Name = "__kg";
            this.@__kg.ReadOnly = true;
            this.@__kg.Width = 50;
            // 
            // batchNumberDataGridViewTextBoxColumn
            // 
            this.batchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber";
            this.batchNumberDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.batchNumberDataGridViewTextBoxColumn.Name = "batchNumberDataGridViewTextBoxColumn";
            this.batchNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // __reproceso
            // 
            this.@__reproceso.DataPropertyName = "Repro";
            this.@__reproceso.HeaderText = "[R]";
            this.@__reproceso.Name = "__reproceso";
            this.@__reproceso.ReadOnly = true;
            this.@__reproceso.Width = 25;
            // 
            // __added
            // 
            this.@__added.DataPropertyName = "Added";
            this.@__added.HeaderText = "[+]";
            this.@__added.Name = "__added";
            this.@__added.ReadOnly = true;
            this.@__added.Width = 25;
            // 
            // __recalculo
            // 
            this.@__recalculo.DataPropertyName = "Recalculo";
            this.@__recalculo.HeaderText = "[!]";
            this.@__recalculo.Name = "__recalculo";
            this.@__recalculo.ReadOnly = true;
            this.@__recalculo.Width = 25;
            // 
            // STKLiberado
            // 
            this.STKLiberado.DataPropertyName = "STKLiberado";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.STKLiberado.DefaultCellStyle = dataGridViewCellStyle13;
            this.STKLiberado.HeaderText = "StkLib";
            this.STKLiberado.Name = "STKLiberado";
            this.STKLiberado.ReadOnly = true;
            this.STKLiberado.ToolTipText = "Stock Liberado";
            this.STKLiberado.Width = 60;
            // 
            // STKTotal
            // 
            this.STKTotal.DataPropertyName = "STKTotal";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.STKTotal.DefaultCellStyle = dataGridViewCellStyle14;
            this.STKTotal.HeaderText = "StkTotal";
            this.STKTotal.Name = "STKTotal";
            this.STKTotal.ReadOnly = true;
            this.STKTotal.ToolTipText = "Stock Total en Planta sin importar estado";
            this.STKTotal.Width = 60;
            // 
            // t0072Bs
            // 
            this.t0072Bs.DataSource = typeof(TecserEF.Entity.T0072_FORMULA_TEMP);
            // 
            // txtKgFabricarOri
            // 
            this.txtKgFabricarOri.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKgFabricarOri.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricarOri.Location = new System.Drawing.Point(117, 3);
            this.txtKgFabricarOri.Name = "txtKgFabricarOri";
            this.txtKgFabricarOri.ReadOnly = true;
            this.txtKgFabricarOri.Size = new System.Drawing.Size(72, 22);
            this.txtKgFabricarOri.TabIndex = 6;
            this.txtKgFabricarOri.TabStop = false;
            this.txtKgFabricarOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label19.Location = new System.Drawing.Point(9, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 14);
            this.label19.TabIndex = 5;
            this.label19.Text = "KG a Fab [ORIG]";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(403, 593);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(270, 31);
            this.label14.TabIndex = 28;
            this.label14.Text = "OBSERVACION (SE VISUALIZA EN LISTA PF)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtObservacionPF
            // 
            this.txtObservacionPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionPF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionPF.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtObservacionPF.Location = new System.Drawing.Point(676, 593);
            this.txtObservacionPF.Multiline = true;
            this.txtObservacionPF.Name = "txtObservacionPF";
            this.txtObservacionPF.Size = new System.Drawing.Size(425, 31);
            this.txtObservacionPF.TabIndex = 27;
            this.txtObservacionPF.Validating += new System.ComponentModel.CancelEventHandler(this.txtObservacionPF_Validating);
            // 
            // panelFormulacion
            // 
            this.panelFormulacion.BackColor = System.Drawing.Color.LightGray;
            this.panelFormulacion.Controls.Add(this.ckAutoFormulacion);
            this.panelFormulacion.Controls.Add(this.label7);
            this.panelFormulacion.Controls.Add(this.semFormulado);
            this.panelFormulacion.Controls.Add(this.btnCancelFormulacion);
            this.panelFormulacion.Controls.Add(this.label4);
            this.panelFormulacion.Controls.Add(this.btnSeleccionarFormula1);
            this.panelFormulacion.Controls.Add(this.label12);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulaSeleccionada);
            this.panelFormulacion.Controls.Add(this.btnVerFormulas1);
            this.panelFormulacion.Controls.Add(this.txtFechaUltimaFormulacion);
            this.panelFormulacion.Controls.Add(this.label2);
            this.panelFormulacion.Controls.Add(this.label3);
            this.panelFormulacion.Controls.Add(this.label11);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulasTotales);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulasActivas);
            this.panelFormulacion.Controls.Add(this.txtDescripcionFormulaSeleccionada);
            this.panelFormulacion.Location = new System.Drawing.Point(9, 180);
            this.panelFormulacion.Name = "panelFormulacion";
            this.panelFormulacion.Size = new System.Drawing.Size(385, 166);
            this.panelFormulacion.TabIndex = 25;
            // 
            // ckAutoFormulacion
            // 
            this.ckAutoFormulacion.AutoCheck = false;
            this.ckAutoFormulacion.AutoSize = true;
            this.ckAutoFormulacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAutoFormulacion.Location = new System.Drawing.Point(8, 146);
            this.ckAutoFormulacion.Name = "ckAutoFormulacion";
            this.ckAutoFormulacion.Size = new System.Drawing.Size(158, 18);
            this.ckAutoFormulacion.TabIndex = 188;
            this.ckAutoFormulacion.Text = "Formulacion Automatica";
            this.toolTip1.SetToolTip(this.ckAutoFormulacion, "Indicador si se ingreso a la OF en modo Auto-Formulacion");
            this.ckAutoFormulacion.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 14);
            this.label7.TabIndex = 174;
            this.label7.Text = "Formulacion Realizada";
            // 
            // semFormulado
            // 
            this.semFormulado.Location = new System.Drawing.Point(148, 54);
            this.semFormulado.Name = "semFormulado";
            this.semFormulado.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.semFormulado.Size = new System.Drawing.Size(23, 23);
            this.semFormulado.TabIndex = 173;
            // 
            // btnCancelFormulacion
            // 
            this.btnCancelFormulacion.BackColor = System.Drawing.Color.White;
            this.btnCancelFormulacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelFormulacion.ForeColor = System.Drawing.Color.Black;
            this.btnCancelFormulacion.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelFormulacion.Image")));
            this.btnCancelFormulacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelFormulacion.Location = new System.Drawing.Point(283, 122);
            this.btnCancelFormulacion.Name = "btnCancelFormulacion";
            this.btnCancelFormulacion.Size = new System.Drawing.Size(100, 40);
            this.btnCancelFormulacion.TabIndex = 172;
            this.btnCancelFormulacion.Text = "Retiro\r\nFormula";
            this.btnCancelFormulacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelFormulacion.UseVisualStyleBackColor = false;
            this.btnCancelFormulacion.Click += new System.EventHandler(this.btnCancelFormulacion_Click);
            // 
            // btnSeleccionarFormula1
            // 
            this.btnSeleccionarFormula1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFormula1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarFormula1.Location = new System.Drawing.Point(283, 41);
            this.btnSeleccionarFormula1.Name = "btnSeleccionarFormula1";
            this.btnSeleccionarFormula1.Size = new System.Drawing.Size(100, 40);
            this.btnSeleccionarFormula1.TabIndex = 166;
            this.btnSeleccionarFormula1.Text = "Seleccionar\r\nFormula";
            this.btnSeleccionarFormula1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarFormula1.UseVisualStyleBackColor = true;
            this.btnSeleccionarFormula1.Click += new System.EventHandler(this.btnSeleccionarFormula1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "Ultimo Uso";
            // 
            // btnVerFormulas1
            // 
            this.btnVerFormulas1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerFormulas1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerFormulas1.Location = new System.Drawing.Point(283, 2);
            this.btnVerFormulas1.Name = "btnVerFormulas1";
            this.btnVerFormulas1.Size = new System.Drawing.Size(100, 40);
            this.btnVerFormulas1.TabIndex = 167;
            this.btnVerFormulas1.Text = "VER\r\nFormulas";
            this.btnVerFormulas1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerFormulas1.UseVisualStyleBackColor = true;
            this.btnVerFormulas1.Click += new System.EventHandler(this.btnVerFormulas1_Click);
            // 
            // txtFechaUltimaFormulacion
            // 
            this.txtFechaUltimaFormulacion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFechaUltimaFormulacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaUltimaFormulacion.Location = new System.Drawing.Point(81, 123);
            this.txtFechaUltimaFormulacion.Name = "txtFechaUltimaFormulacion";
            this.txtFechaUltimaFormulacion.ReadOnly = true;
            this.txtFechaUltimaFormulacion.Size = new System.Drawing.Size(90, 22);
            this.txtFechaUltimaFormulacion.TabIndex = 14;
            this.txtFechaUltimaFormulacion.TabStop = false;
            this.txtFechaUltimaFormulacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Formulas Activas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "Descripcion";
            // 
            // txtDescripcionFormulaSeleccionada
            // 
            this.txtDescripcionFormulaSeleccionada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcionFormulaSeleccionada.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionFormulaSeleccionada.Location = new System.Drawing.Point(81, 100);
            this.txtDescripcionFormulaSeleccionada.Name = "txtDescripcionFormulaSeleccionada";
            this.txtDescripcionFormulaSeleccionada.ReadOnly = true;
            this.txtDescripcionFormulaSeleccionada.Size = new System.Drawing.Size(300, 22);
            this.txtDescripcionFormulaSeleccionada.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(929, 2);
            this.label6.TabIndex = 168;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(385, 19);
            this.label13.TabIndex = 26;
            this.label13.Text = "1 - Formulacion";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlanear
            // 
            this.btnPlanear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanear.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanear.Image")));
            this.btnPlanear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanear.Location = new System.Drawing.Point(263, 8);
            this.btnPlanear.Name = "btnPlanear";
            this.btnPlanear.Size = new System.Drawing.Size(112, 44);
            this.btnPlanear.TabIndex = 31;
            this.btnPlanear.Text = "Planificar";
            this.btnPlanear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanear.UseVisualStyleBackColor = true;
            this.btnPlanear.Click += new System.EventHandler(this.btnPlanear_Click);
            // 
            // btnImprimirFormula
            // 
            this.btnImprimirFormula.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirFormula.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirFormula.Image")));
            this.btnImprimirFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirFormula.Location = new System.Drawing.Point(263, 51);
            this.btnImprimirFormula.Name = "btnImprimirFormula";
            this.btnImprimirFormula.Size = new System.Drawing.Size(112, 44);
            this.btnImprimirFormula.TabIndex = 32;
            this.btnImprimirFormula.Text = "Imprimir\r\nFormula";
            this.btnImprimirFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirFormula.UseVisualStyleBackColor = true;
            this.btnImprimirFormula.Click += new System.EventHandler(this.btnImprimirFormula_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.btnAutoReserva);
            this.panel2.Controls.Add(this.btnModificarTamañoBatch1);
            this.panel2.Controls.Add(this.btnFreeStock);
            this.panel2.Controls.Add(this.ckReservaAutomaticaStock);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.txtBatchQuantity);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.txtBatchSize);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtKgFabricarBatch);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(9, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 131);
            this.panel2.TabIndex = 26;
            // 
            // btnAutoReserva
            // 
            this.btnAutoReserva.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoReserva.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoReserva.Image")));
            this.btnAutoReserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoReserva.Location = new System.Drawing.Point(283, 86);
            this.btnAutoReserva.Name = "btnAutoReserva";
            this.btnAutoReserva.Size = new System.Drawing.Size(98, 40);
            this.btnAutoReserva.TabIndex = 187;
            this.btnAutoReserva.Text = "Reserva\r\nAUTO";
            this.btnAutoReserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAutoReserva.UseVisualStyleBackColor = true;
            this.btnAutoReserva.Click += new System.EventHandler(this.btnAutoReserva_Click);
            // 
            // btnModificarTamañoBatch1
            // 
            this.btnModificarTamañoBatch1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTamañoBatch1.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarTamañoBatch1.Image")));
            this.btnModificarTamañoBatch1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarTamañoBatch1.Location = new System.Drawing.Point(283, 6);
            this.btnModificarTamañoBatch1.Name = "btnModificarTamañoBatch1";
            this.btnModificarTamañoBatch1.Size = new System.Drawing.Size(98, 40);
            this.btnModificarTamañoBatch1.TabIndex = 170;
            this.btnModificarTamañoBatch1.Text = "Modificar\r\nBatch";
            this.btnModificarTamañoBatch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarTamañoBatch1.UseVisualStyleBackColor = true;
            this.btnModificarTamañoBatch1.Click += new System.EventHandler(this.btnModificarTamañoBatch1_Click);
            // 
            // btnFreeStock
            // 
            this.btnFreeStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeStock.Image = ((System.Drawing.Image)(resources.GetObject("btnFreeStock.Image")));
            this.btnFreeStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFreeStock.Location = new System.Drawing.Point(283, 46);
            this.btnFreeStock.Name = "btnFreeStock";
            this.btnFreeStock.Size = new System.Drawing.Size(98, 40);
            this.btnFreeStock.TabIndex = 186;
            this.btnFreeStock.Text = "Liberar\r\nReserva";
            this.btnFreeStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFreeStock.UseVisualStyleBackColor = true;
            this.btnFreeStock.Click += new System.EventHandler(this.btnFreeStock_Click);
            // 
            // ckReservaAutomaticaStock
            // 
            this.ckReservaAutomaticaStock.AutoSize = true;
            this.ckReservaAutomaticaStock.Checked = true;
            this.ckReservaAutomaticaStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckReservaAutomaticaStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckReservaAutomaticaStock.Location = new System.Drawing.Point(11, 104);
            this.ckReservaAutomaticaStock.Name = "ckReservaAutomaticaStock";
            this.ckReservaAutomaticaStock.Size = new System.Drawing.Size(181, 18);
            this.ckReservaAutomaticaStock.TabIndex = 172;
            this.ckReservaAutomaticaStock.Text = "Reserva Automatica de Stock";
            this.toolTip1.SetToolTip(this.ckReservaAutomaticaStock, "El Stock se reserva en forma automatica");
            this.ckReservaAutomaticaStock.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(7, 54);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(118, 14);
            this.label31.TabIndex = 18;
            this.label31.Text = "Cantidad de Batches";
            // 
            // txtBatchQuantity
            // 
            this.txtBatchQuantity.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchQuantity.Location = new System.Drawing.Point(132, 50);
            this.txtBatchQuantity.Name = "txtBatchQuantity";
            this.txtBatchQuantity.ReadOnly = true;
            this.txtBatchQuantity.Size = new System.Drawing.Size(37, 22);
            this.txtBatchQuantity.TabIndex = 19;
            this.txtBatchQuantity.TabStop = false;
            this.txtBatchQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(7, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 14);
            this.label30.TabIndex = 16;
            this.label30.Text = "Tamaño del Batch";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSize.Location = new System.Drawing.Point(132, 27);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.ReadOnly = true;
            this.txtBatchSize.Size = new System.Drawing.Size(75, 22);
            this.txtBatchSize.TabIndex = 17;
            this.txtBatchSize.TabStop = false;
            this.txtBatchSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 14);
            this.label18.TabIndex = 13;
            this.label18.Text = "KG a Fabricar [Plan]";
            // 
            // txtKgFabricarBatch
            // 
            this.txtKgFabricarBatch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricarBatch.Location = new System.Drawing.Point(132, 4);
            this.txtKgFabricarBatch.Name = "txtKgFabricarBatch";
            this.txtKgFabricarBatch.ReadOnly = true;
            this.txtKgFabricarBatch.Size = new System.Drawing.Size(75, 22);
            this.txtKgFabricarBatch.TabIndex = 14;
            this.txtKgFabricarBatch.TabStop = false;
            this.txtKgFabricarBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.txtFechaCompromisoPlan);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.txtKgPlaneados);
            this.panel3.Controls.Add(this.cmbOperador);
            this.panel3.Controls.Add(this.txtNumeroLote);
            this.panel3.Controls.Add(this.cmbRecursoProduccion);
            this.panel3.Controls.Add(this.dtpFechaPlan);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.btnPlanear);
            this.panel3.Controls.Add(this.btnStandBy);
            this.panel3.Controls.Add(this.btnImprimirFormula);
            this.panel3.Location = new System.Drawing.Point(9, 523);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 148);
            this.panel3.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(26, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Numero de Lote";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(29, 122);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(90, 14);
            this.label44.TabIndex = 173;
            this.label44.Text = "KG Planificados";
            // 
            // txtFechaCompromisoPlan
            // 
            this.txtFechaCompromisoPlan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFechaCompromisoPlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCompromisoPlan.Location = new System.Drawing.Point(123, 3);
            this.txtFechaCompromisoPlan.Name = "txtFechaCompromisoPlan";
            this.txtFechaCompromisoPlan.ReadOnly = true;
            this.txtFechaCompromisoPlan.Size = new System.Drawing.Size(118, 22);
            this.txtFechaCompromisoPlan.TabIndex = 40;
            this.txtFechaCompromisoPlan.TabStop = false;
            this.txtFechaCompromisoPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(9, 7);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(110, 14);
            this.label33.TabIndex = 42;
            this.label33.Text = "Fecha Compromiso";
            // 
            // txtKgPlaneados
            // 
            this.txtKgPlaneados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgPlaneados.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgPlaneados.ForeColor = System.Drawing.Color.DeepPink;
            this.txtKgPlaneados.Location = new System.Drawing.Point(123, 118);
            this.txtKgPlaneados.Name = "txtKgPlaneados";
            this.txtKgPlaneados.ReadOnly = true;
            this.txtKgPlaneados.Size = new System.Drawing.Size(63, 22);
            this.txtKgPlaneados.TabIndex = 172;
            this.txtKgPlaneados.TabStop = false;
            this.txtKgPlaneados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbOperador
            // 
            this.cmbOperador.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(123, 72);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(118, 22);
            this.cmbOperador.TabIndex = 41;
            this.cmbOperador.Validating += new System.ComponentModel.CancelEventHandler(this.cmbOperador_Validating);
            // 
            // cmbRecursoProduccion
            // 
            this.cmbRecursoProduccion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecursoProduccion.FormattingEnabled = true;
            this.cmbRecursoProduccion.Location = new System.Drawing.Point(123, 49);
            this.cmbRecursoProduccion.Name = "cmbRecursoProduccion";
            this.cmbRecursoProduccion.Size = new System.Drawing.Size(118, 22);
            this.cmbRecursoProduccion.TabIndex = 40;
            // 
            // dtpFechaPlan
            // 
            this.dtpFechaPlan.CalendarFont = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaPlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPlan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPlan.Location = new System.Drawing.Point(123, 26);
            this.dtpFechaPlan.Name = "dtpFechaPlan";
            this.dtpFechaPlan.Size = new System.Drawing.Size(118, 22);
            this.dtpFechaPlan.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(61, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 14);
            this.label24.TabIndex = 18;
            this.label24.Text = "Operador";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(7, 53);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(112, 14);
            this.label25.TabIndex = 16;
            this.label25.Text = "Recurso Produccion";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 14);
            this.label26.TabIndex = 13;
            this.label26.Text = "Fecha Planificada";
            // 
            // btnStandBy
            // 
            this.btnStandBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandBy.Image = ((System.Drawing.Image)(resources.GetObject("btnStandBy.Image")));
            this.btnStandBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStandBy.Location = new System.Drawing.Point(263, 94);
            this.btnStandBy.Name = "btnStandBy";
            this.btnStandBy.Size = new System.Drawing.Size(112, 44);
            this.btnStandBy.TabIndex = 46;
            this.btnStandBy.Text = "Posponer\r\nFabricacion";
            this.btnStandBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStandBy.UseVisualStyleBackColor = true;
            this.btnStandBy.Click += new System.EventHandler(this.btnStandBy_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(403, 626);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 18);
            this.label1.TabIndex = 57;
            this.label1.Text = "OBSERVACION EN IMPRESION DE ORDEN DE FABRICACION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNotaOrdenFabricacion
            // 
            this.txtNotaOrdenFabricacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotaOrdenFabricacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNotaOrdenFabricacion.Location = new System.Drawing.Point(676, 626);
            this.txtNotaOrdenFabricacion.Multiline = true;
            this.txtNotaOrdenFabricacion.Name = "txtNotaOrdenFabricacion";
            this.txtNotaOrdenFabricacion.Size = new System.Drawing.Size(425, 18);
            this.txtNotaOrdenFabricacion.TabIndex = 40;
            this.txtNotaOrdenFabricacion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNotaOrdenFabricacion_Validating);
            // 
            // btnCancelarOF
            // 
            this.btnCancelarOF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarOF.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarOF.Image")));
            this.btnCancelarOF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarOF.Location = new System.Drawing.Point(1138, 178);
            this.btnCancelarOF.Name = "btnCancelarOF";
            this.btnCancelarOF.Size = new System.Drawing.Size(100, 40);
            this.btnCancelarOF.TabIndex = 44;
            this.btnCancelarOF.Text = "Cancelar\r\nOF";
            this.btnCancelarOF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarOF.UseVisualStyleBackColor = true;
            this.btnCancelarOF.Click += new System.EventHandler(this.btnCancelarOF_Click);
            // 
            // lblStockNoDisponible
            // 
            this.lblStockNoDisponible.BackColor = System.Drawing.Color.Crimson;
            this.lblStockNoDisponible.Cursor = System.Windows.Forms.Cursors.No;
            this.lblStockNoDisponible.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockNoDisponible.ForeColor = System.Drawing.Color.White;
            this.lblStockNoDisponible.Location = new System.Drawing.Point(9, 683);
            this.lblStockNoDisponible.Name = "lblStockNoDisponible";
            this.lblStockNoDisponible.Size = new System.Drawing.Size(1228, 34);
            this.lblStockNoDisponible.TabIndex = 47;
            this.lblStockNoDisponible.Text = "ATENCION : NO HAY STOCK DISPONIBLE SUFICIENTE PARA FABRICAR";
            this.lblStockNoDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStockNoDisponible.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(7, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 13);
            this.label34.TabIndex = 40;
            this.label34.Text = "CONTENEDOR STD";
            // 
            // txtContainerId
            // 
            this.txtContainerId.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContainerId.Location = new System.Drawing.Point(367, 2);
            this.txtContainerId.Name = "txtContainerId";
            this.txtContainerId.ReadOnly = true;
            this.txtContainerId.Size = new System.Drawing.Size(79, 21);
            this.txtContainerId.TabIndex = 48;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(466, 5);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(31, 13);
            this.label35.TabIndex = 49;
            this.label35.Text = "CANT";
            // 
            // txtCantidadContainers
            // 
            this.txtCantidadContainers.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadContainers.Location = new System.Drawing.Point(503, 2);
            this.txtCantidadContainers.Name = "txtCantidadContainers";
            this.txtCantidadContainers.Size = new System.Drawing.Size(52, 21);
            this.txtCantidadContainers.TabIndex = 50;
            this.txtCantidadContainers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadContainers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadContainers_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmbContainer);
            this.panel5.Controls.Add(this.label35);
            this.panel5.Controls.Add(this.label34);
            this.panel5.Controls.Add(this.txtCantidadContainers);
            this.panel5.Controls.Add(this.txtContainerId);
            this.panel5.Controls.Add(this.ckUpdateContainer);
            this.panel5.Location = new System.Drawing.Point(403, 646);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(834, 28);
            this.panel5.TabIndex = 51;
            // 
            // cmbContainer
            // 
            this.cmbContainer.DataSource = this.t0010ContainerBindingSource;
            this.cmbContainer.DisplayMember = "ContainerDescription";
            this.cmbContainer.FormattingEnabled = true;
            this.cmbContainer.Location = new System.Drawing.Point(101, 2);
            this.cmbContainer.Name = "cmbContainer";
            this.cmbContainer.Size = new System.Drawing.Size(264, 21);
            this.cmbContainer.TabIndex = 51;
            this.cmbContainer.ValueMember = "ContainerId";
            this.cmbContainer.SelectedIndexChanged += new System.EventHandler(this.cmbContainer_SelectedIndexChanged);
            // 
            // t0010ContainerBindingSource
            // 
            this.t0010ContainerBindingSource.DataSource = typeof(TecserEF.Entity.T0010_Container);
            // 
            // ckUpdateContainer
            // 
            this.ckUpdateContainer.AutoSize = true;
            this.ckUpdateContainer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckUpdateContainer.Location = new System.Drawing.Point(567, 4);
            this.ckUpdateContainer.Name = "ckUpdateContainer";
            this.ckUpdateContainer.Size = new System.Drawing.Size(223, 18);
            this.ckUpdateContainer.TabIndex = 52;
            this.ckUpdateContainer.Text = "Actualizar Default  Container en MM";
            this.ckUpdateContainer.UseVisualStyleBackColor = true;
            this.ckUpdateContainer.CheckedChanged += new System.EventHandler(this.ckUpdateContainer_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1138, 61);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 53;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelHeader.Controls.Add(this.labelAprobacion);
            this.panelHeader.Controls.Add(this.label8);
            this.panelHeader.Controls.Add(this.txtStatusLab);
            this.panelHeader.Controls.Add(this.label43);
            this.panelHeader.Controls.Add(this.txtKgFabricadosIngresados);
            this.panelHeader.Controls.Add(this.label37);
            this.panelHeader.Controls.Add(this.label38);
            this.panelHeader.Controls.Add(this.label39);
            this.panelHeader.Controls.Add(this.label40);
            this.panelHeader.Controls.Add(this.txtStatus);
            this.panelHeader.Controls.Add(this.txtnumeroOF);
            this.panelHeader.Controls.Add(this.txtMaterialPrimario);
            this.panelHeader.Controls.Add(this.txtMaterialEtiqueta);
            this.panelHeader.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.Location = new System.Drawing.Point(9, 7);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1228, 53);
            this.panelHeader.TabIndex = 54;
            // 
            // labelAprobacion
            // 
            this.labelAprobacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelAprobacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelAprobacion.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAprobacion.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelAprobacion.Location = new System.Drawing.Point(270, 8);
            this.labelAprobacion.Name = "labelAprobacion";
            this.labelAprobacion.ReadOnly = true;
            this.labelAprobacion.Size = new System.Drawing.Size(285, 36);
            this.labelAprobacion.TabIndex = 27;
            this.labelAprobacion.Text = "NO AUTORIZADO";
            this.labelAprobacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(577, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 25;
            this.label8.Text = "Status CQ/Lab";
            // 
            // txtStatusLab
            // 
            this.txtStatusLab.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStatusLab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatusLab.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusLab.Location = new System.Drawing.Point(664, 28);
            this.txtStatusLab.Name = "txtStatusLab";
            this.txtStatusLab.ReadOnly = true;
            this.txtStatusLab.Size = new System.Drawing.Size(116, 15);
            this.txtStatusLab.TabIndex = 26;
            this.txtStatusLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(922, 15);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(93, 18);
            this.label43.TabIndex = 23;
            this.label43.Text = "KG Fabricados";
            // 
            // txtKgFabricadosIngresados
            // 
            this.txtKgFabricadosIngresados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgFabricadosIngresados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgFabricadosIngresados.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricadosIngresados.ForeColor = System.Drawing.Color.Crimson;
            this.txtKgFabricadosIngresados.Location = new System.Drawing.Point(1025, 11);
            this.txtKgFabricadosIngresados.Name = "txtKgFabricadosIngresados";
            this.txtKgFabricadosIngresados.ReadOnly = true;
            this.txtKgFabricadosIngresados.Size = new System.Drawing.Size(68, 26);
            this.txtKgFabricadosIngresados.TabIndex = 24;
            this.txtKgFabricadosIngresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(5, 29);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(88, 18);
            this.label37.TabIndex = 12;
            this.label37.Text = "ETIQUETA:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(602, 6);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(58, 14);
            this.label38.TabIndex = 6;
            this.label38.Text = "Status OF";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(5, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 18);
            this.label39.TabIndex = 2;
            this.label39.Text = "PRIMARIO:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Calibri", 15F);
            this.label40.Location = new System.Drawing.Point(1094, 12);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(47, 24);
            this.label40.TabIndex = 1;
            this.label40.Text = "OF #";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightGray;
            this.panel7.Controls.Add(this.label27);
            this.panel7.Controls.Add(this.txtOrdenVentaNumero);
            this.panel7.Controls.Add(this.txtStockTotal);
            this.panel7.Controls.Add(this.txtStockLiberado);
            this.panel7.Controls.Add(this.label29);
            this.panel7.Controls.Add(this.label28);
            this.panel7.Controls.Add(this.txtClienteFantasia);
            this.panel7.Controls.Add(this.txtPlanPara);
            this.panel7.Controls.Add(this.txtKgFabricarOri);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(9, 81);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(385, 74);
            this.panel7.TabIndex = 55;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(9, 53);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 14);
            this.label29.TabIndex = 17;
            this.label29.Text = "OV #";
            // 
            // panelMRP
            // 
            this.panelMRP.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelMRP.Controls.Add(this.txtKgPendienteEntrega);
            this.panelMRP.Controls.Add(this.label23);
            this.panelMRP.Controls.Add(this.label17);
            this.panelMRP.Controls.Add(this.label49);
            this.panelMRP.Controls.Add(this.label36);
            this.panelMRP.Controls.Add(this.label48);
            this.panelMRP.Controls.Add(this.txtConsumoU30);
            this.panelMRP.Controls.Add(this.txtUltimaFabricacion);
            this.panelMRP.Controls.Add(this.txtConsumoU60);
            this.panelMRP.Controls.Add(this.txtConsumoP30);
            this.panelMRP.Controls.Add(this.txtNumeroClientes);
            this.panelMRP.Controls.Add(this.label22);
            this.panelMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMRP.Location = new System.Drawing.Point(400, 81);
            this.panelMRP.Name = "panelMRP";
            this.panelMRP.Size = new System.Drawing.Size(538, 74);
            this.panelMRP.TabIndex = 56;
            // 
            // txtKgPendienteEntrega
            // 
            this.txtKgPendienteEntrega.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgPendienteEntrega.Location = new System.Drawing.Point(319, 26);
            this.txtKgPendienteEntrega.Name = "txtKgPendienteEntrega";
            this.txtKgPendienteEntrega.ReadOnly = true;
            this.txtKgPendienteEntrega.Size = new System.Drawing.Size(68, 22);
            this.txtKgPendienteEntrega.TabIndex = 43;
            this.txtKgPendienteEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgPendienteEntrega.TextChanged += new System.EventHandler(this.txtKgPendienteEntrega_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(186, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 14);
            this.label23.TabIndex = 42;
            this.label23.Text = "Kg Pendientes Entrega";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(205, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 14);
            this.label17.TabIndex = 41;
            this.label17.Text = "Ultima Fabricacion";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Brown;
            this.label49.Location = new System.Drawing.Point(11, 29);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(82, 14);
            this.label49.TabIndex = 40;
            this.label49.Text = "Promedio U30";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(11, 52);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(86, 14);
            this.label36.TabIndex = 39;
            this.label36.Text = "Conusmo U180";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(11, 6);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 14);
            this.label48.TabIndex = 38;
            this.label48.Text = "Conusmo U30";
            // 
            // btnDetalleIngreso
            // 
            this.btnDetalleIngreso.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleIngreso.Location = new System.Drawing.Point(1138, 100);
            this.btnDetalleIngreso.Name = "btnDetalleIngreso";
            this.btnDetalleIngreso.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleIngreso.TabIndex = 178;
            this.btnDetalleIngreso.Text = "Detalle\r\nIngreso";
            this.btnDetalleIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleIngreso.UseVisualStyleBackColor = true;
            this.btnDetalleIngreso.Click += new System.EventHandler(this.btnDetalleIngreso_Click);
            // 
            // btnCQLab
            // 
            this.btnCQLab.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCQLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCQLab.Location = new System.Drawing.Point(1138, 139);
            this.btnCQLab.Name = "btnCQLab";
            this.btnCQLab.Size = new System.Drawing.Size(100, 40);
            this.btnCQLab.TabIndex = 179;
            this.btnCQLab.Text = "CQ\r\nLAB";
            this.btnCQLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCQLab.UseVisualStyleBackColor = true;
            this.btnCQLab.Click += new System.EventHandler(this.btnCQLab_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DimGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(9, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(385, 18);
            this.label21.TabIndex = 180;
            this.label21.Text = "ENCABEZADO ORDEN DE FABRICACION";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.Location = new System.Drawing.Point(3, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 724);
            this.LineaIzq.TabIndex = 182;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DimGray;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaArriba.Location = new System.Drawing.Point(3, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(1241, 3);
            this.lineaArriba.TabIndex = 181;
            // 
            // lineaDerecha
            // 
            this.lineaDerecha.BackColor = System.Drawing.Color.MidnightBlue;
            this.lineaDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaDerecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaDerecha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaDerecha.Location = new System.Drawing.Point(1241, 2);
            this.lineaDerecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaDerecha.Name = "lineaDerecha";
            this.lineaDerecha.Size = new System.Drawing.Size(3, 724);
            this.lineaDerecha.TabIndex = 184;
            // 
            // lineaAbajo
            // 
            this.lineaAbajo.BackColor = System.Drawing.Color.MidnightBlue;
            this.lineaAbajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaAbajo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaAbajo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaAbajo.Location = new System.Drawing.Point(3, 723);
            this.lineaAbajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaAbajo.Name = "lineaAbajo";
            this.lineaAbajo.Size = new System.Drawing.Size(1241, 3);
            this.lineaAbajo.TabIndex = 183;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 348);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(385, 19);
            this.label15.TabIndex = 186;
            this.label15.Text = "2 - Determinacion de Batch";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.DimGray;
            this.label41.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label41.Location = new System.Drawing.Point(400, 62);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(538, 18);
            this.label41.TabIndex = 188;
            this.label41.Text = "MRP-CRM Data";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(9, 502);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(385, 19);
            this.label32.TabIndex = 189;
            this.label32.Text = "3 - Planificacion de Produccion";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(400, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(538, 19);
            this.label9.TabIndex = 190;
            this.label9.Text = "Formula a Utilizar";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefreshStock
            // 
            this.btnRefreshStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshStock.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshStock.Image")));
            this.btnRefreshStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshStock.Location = new System.Drawing.Point(400, 549);
            this.btnRefreshStock.Name = "btnRefreshStock";
            this.btnRefreshStock.Size = new System.Drawing.Size(100, 40);
            this.btnRefreshStock.TabIndex = 191;
            this.btnRefreshStock.Text = "Recalc\r\nSTOCK";
            this.btnRefreshStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshStock.UseVisualStyleBackColor = true;
            this.btnRefreshStock.Click += new System.EventHandler(this.btnRefreshStock_Click);
            // 
            // semFormulacion
            // 
            this.semFormulacion.Location = new System.Drawing.Point(1088, 412);
            this.semFormulacion.Name = "semFormulacion";
            this.semFormulacion.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semFormulacion.Size = new System.Drawing.Size(23, 23);
            this.semFormulacion.TabIndex = 192;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(998, 416);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "1-Formulacion";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(949, 438);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 15);
            this.label20.TabIndex = 193;
            this.label20.Text = "2- Determinacion Batch";
            // 
            // semDetBatch
            // 
            this.semDetBatch.Location = new System.Drawing.Point(1088, 434);
            this.semDetBatch.Name = "semDetBatch";
            this.semDetBatch.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semDetBatch.Size = new System.Drawing.Size(23, 23);
            this.semDetBatch.TabIndex = 194;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(942, 460);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(144, 15);
            this.label42.TabIndex = 195;
            this.label42.Text = "3-Planificaicon Recursos";
            // 
            // semPlan
            // 
            this.semPlan.Location = new System.Drawing.Point(1088, 456);
            this.semPlan.Name = "semPlan";
            this.semPlan.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semPlan.Size = new System.Drawing.Size(23, 23);
            this.semPlan.TabIndex = 196;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(955, 482);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(131, 15);
            this.label45.TabIndex = 197;
            this.label45.Text = "4-Fabricacion-Proceso";
            // 
            // semFabricacion
            // 
            this.semFabricacion.Location = new System.Drawing.Point(1088, 478);
            this.semFabricacion.Name = "semFabricacion";
            this.semFabricacion.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semFabricacion.Size = new System.Drawing.Size(23, 23);
            this.semFabricacion.TabIndex = 198;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(975, 504);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(111, 15);
            this.label46.TabIndex = 199;
            this.label46.Text = "5-Cierre Orden Fab";
            // 
            // semCierre
            // 
            this.semCierre.Location = new System.Drawing.Point(1088, 500);
            this.semCierre.Name = "semCierre";
            this.semCierre.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semCierre.Size = new System.Drawing.Size(23, 23);
            this.semCierre.TabIndex = 200;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(960, 526);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(126, 15);
            this.label47.TabIndex = 201;
            this.label47.Text = "6-Aprobacion Calidad";
            // 
            // semLabCq
            // 
            this.semLabCq.Location = new System.Drawing.Point(1088, 522);
            this.semLabCq.Name = "semLabCq";
            this.semLabCq.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.semLabCq.Size = new System.Drawing.Size(23, 23);
            this.semLabCq.TabIndex = 202;
            // 
            // btnNoAutoriza
            // 
            this.btnNoAutoriza.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoAutoriza.Image = ((System.Drawing.Image)(resources.GetObject("btnNoAutoriza.Image")));
            this.btnNoAutoriza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNoAutoriza.Location = new System.Drawing.Point(944, 119);
            this.btnNoAutoriza.Name = "btnNoAutoriza";
            this.btnNoAutoriza.Size = new System.Drawing.Size(100, 40);
            this.btnNoAutoriza.TabIndex = 203;
            this.btnNoAutoriza.Text = "NO\r\nAutoriza";
            this.btnNoAutoriza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNoAutoriza.UseVisualStyleBackColor = true;
            this.btnNoAutoriza.Click += new System.EventHandler(this.btnNoAutoriza_Click);
            // 
            // btnAutoriza
            // 
            this.btnAutoriza.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoriza.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoriza.Image")));
            this.btnAutoriza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoriza.Location = new System.Drawing.Point(944, 79);
            this.btnAutoriza.Name = "btnAutoriza";
            this.btnAutoriza.Size = new System.Drawing.Size(100, 40);
            this.btnAutoriza.TabIndex = 204;
            this.btnAutoriza.Text = "Autoriza\r\nPLAN";
            this.btnAutoriza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAutoriza.UseVisualStyleBackColor = true;
            this.btnAutoriza.Click += new System.EventHandler(this.btnAutoriza_Click);
            // 
            // FrmPP02PlanificacionOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1246, 728);
            this.ControlBox = false;
            this.Controls.Add(this.btnAutoriza);
            this.Controls.Add(this.btnNoAutoriza);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.semLabCq);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.semCierre);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.semFabricacion);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.semPlan);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.semDetBatch);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.semFormulacion);
            this.Controls.Add(this.btnRefreshStock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.lineaDerecha);
            this.Controls.Add(this.lineaAbajo);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnCQLab);
            this.Controls.Add(this.btnDetalleIngreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotaOrdenFabricacion);
            this.Controls.Add(this.dgvFormulaSeleccionada);
            this.Controls.Add(this.panelMRP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnCancelarOF);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtObservacionPF);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panelFormulacion);
            this.Controls.Add(this.lblStockNoDisponible);
            this.MaximizeBox = false;
            this.Name = "FrmPP02PlanificacionOF";
            this.Text = "PP02 - Planificacion de Orden de Fabricacion";
            this.Load += new System.EventHandler(this.FrmPlanProduccionOF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaSeleccionada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).EndInit();
            this.panelFormulacion.ResumeLayout(false);
            this.panelFormulacion.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelMRP.ResumeLayout(false);
            this.panelMRP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaterialPrimario;
        private System.Windows.Forms.TextBox txtMaterialEtiqueta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroFormulaSeleccionada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFormulasTotales;
        private System.Windows.Forms.TextBox txtNumeroFormulasActivas;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.TextBox txtnumeroOF;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtClienteFantasia;
        private System.Windows.Forms.TextBox txtOrdenVentaNumero;
        private System.Windows.Forms.TextBox txtPlanPara;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelFormulacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFechaUltimaFormulacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionFormulaSeleccionada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUltimaFabricacion;
        private System.Windows.Forms.TextBox txtConsumoU30;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtConsumoU60;
        private System.Windows.Forms.TextBox txtNumeroClientes;
        private System.Windows.Forms.TextBox txtConsumoP30;
        private System.Windows.Forms.TextBox txtObservacionPF;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtKgFabricarOri;
        private System.Windows.Forms.Button btnPlanear;
        private System.Windows.Forms.Button btnImprimirFormula;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtStockLiberado;
        private System.Windows.Forms.TextBox txtStockTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtBatchQuantity;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtKgFabricarBatch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.ComboBox cmbRecursoProduccion;
        private System.Windows.Forms.DateTimePicker dtpFechaPlan;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnCancelarOF;
        private System.Windows.Forms.TextBox txtNotaOrdenFabricacion;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnStandBy;
        private Label lblStockNoDisponible;
        private DataGridView dgvFormulaSeleccionada;
        private BindingSource t0072Bs;
        private Label label34;
        private TextBox txtContainerId;
        private Label label35;
        private TextBox txtCantidadContainers;
        private Panel panel5;
        private ComboBox cmbContainer;
        private BindingSource t0010ContainerBindingSource;
        private CheckBox ckUpdateContainer;
        private Button btnExit;
        private ToolTip toolTip1;
        private Panel panelHeader;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Panel panel7;
        private Label label1;
        private Label label6;
        private Button btnSeleccionarFormula1;
        private Button btnVerFormulas1;
        private Label label2;
        private Button btnModificarTamañoBatch1;
        private Label label44;
        private TextBox txtKgPlaneados;
        private Label label43;
        private TextBox txtKgFabricadosIngresados;
        private Panel panelMRP;
        private TextBox txtFechaCompromisoPlan;
        private Label label5;
        private Label label8;
        private TextBox txtStatusLab;
        private Label label29;
        private Button btnDetalleIngreso;
        private Button btnCQLab;
        private Label label21;
        private Label LineaIzq;
        private Label lineaArriba;
        private Label lineaDerecha;
        private Label lineaAbajo;
        private Button btnFreeStock;
        private CheckBox ckReservaAutomaticaStock;
        private Button btnAutoReserva;
        private Button btnCancelFormulacion;
        private Label label7;
        private TSControls.CtlSemaforo semFormulado;
        private Label label15;
        private Label label41;
        private Label label32;
        private Label label9;
        private Button btnRefreshStock;
        private DataGridViewTextBoxColumn idItemFormulaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn __primario;
        private DataGridViewTextBoxColumn cantidadBaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn __porcentaje;
        private DataGridViewTextBoxColumn __kg;
        private DataGridViewTextBoxColumn batchNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn __reproceso;
        private DataGridViewCheckBoxColumn __added;
        private DataGridViewCheckBoxColumn __recalculo;
        private DataGridViewTextBoxColumn STKLiberado;
        private DataGridViewTextBoxColumn STKTotal;
        private TSControls.CtlSemaforo semFormulacion;
        private Label label16;
        private Label label20;
        private TSControls.CtlSemaforo semDetBatch;
        private Label label42;
        private TSControls.CtlSemaforo semPlan;
        private Label label45;
        private TSControls.CtlSemaforo semFabricacion;
        private Label label46;
        private TSControls.CtlSemaforo semCierre;
        private Label label47;
        private TSControls.CtlSemaforo semLabCq;
        private TextBox txtKgPendienteEntrega;
        private Label label23;
        private Label label17;
        private Label label49;
        private Label label36;
        private Label label48;
        private CheckBox ckAutoFormulacion;
        private TextBox labelAprobacion;
        private Button btnNoAutoriza;
        private Button btnAutoriza;
    }
}