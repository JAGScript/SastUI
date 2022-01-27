namespace SastUI.UI.Windows.Formulario
{
    partial class FormTelefono
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
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAbrirBusqueda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTelefonos = new System.Windows.Forms.DataGridView();
            this.pnlBusquedaCliente = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtInformacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregarTipo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.pnlNuevoTipo = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNuevoTipo = new System.Windows.Forms.TextBox();
            this.btnGuardarNuevoTipo = new System.Windows.Forms.Button();
            this.btnCancelarNuevoTipo = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelarBusqueda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).BeginInit();
            this.pnlBusquedaCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.pnlNuevoTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Teléfonos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(90, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "ID:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(124, 58);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(358, 27);
            this.txtId.TabIndex = 23;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(124, 100);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(62, 27);
            this.txtIdCliente.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(192, 100);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(290, 27);
            this.txtNombreCliente.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tipo Teléfono:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(124, 138);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(358, 27);
            this.cmbTipo.TabIndex = 28;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(124, 177);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(358, 27);
            this.txtNumero.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Número:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(124, 216);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(358, 27);
            this.cmbEstado.TabIndex = 32;
            this.cmbEstado.Text = "Estados";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 31;
            this.label9.Text = "Estado:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbrirBusqueda
            // 
            this.btnAbrirBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirBusqueda.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirBusqueda.Image = global::SastUI.UI.Windows.Properties.Resources.Buscar;
            this.btnAbrirBusqueda.Location = new System.Drawing.Point(488, 94);
            this.btnAbrirBusqueda.Name = "btnAbrirBusqueda";
            this.btnAbrirBusqueda.Size = new System.Drawing.Size(40, 39);
            this.btnAbrirBusqueda.TabIndex = 33;
            this.btnAbrirBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirBusqueda.UseVisualStyleBackColor = true;
            this.btnAbrirBusqueda.Click += new System.EventHandler(this.btnAbrirBusqueda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 34;
            this.label5.Text = "Lista de Teléfonos";
            // 
            // dgvTelefonos
            // 
            this.dgvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonos.Location = new System.Drawing.Point(41, 345);
            this.dgvTelefonos.Name = "dgvTelefonos";
            this.dgvTelefonos.Size = new System.Drawing.Size(941, 296);
            this.dgvTelefonos.TabIndex = 35;
            this.dgvTelefonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTelefonos_CellClick);
            // 
            // pnlBusquedaCliente
            // 
            this.pnlBusquedaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusquedaCliente.Controls.Add(this.btnCancelarBusqueda);
            this.pnlBusquedaCliente.Controls.Add(this.btnBuscar);
            this.pnlBusquedaCliente.Controls.Add(this.txtInformacion);
            this.pnlBusquedaCliente.Controls.Add(this.label7);
            this.pnlBusquedaCliente.Controls.Add(this.cmbTipoBusqueda);
            this.pnlBusquedaCliente.Controls.Add(this.label6);
            this.pnlBusquedaCliente.Location = new System.Drawing.Point(245, 91);
            this.pnlBusquedaCliente.Name = "pnlBusquedaCliente";
            this.pnlBusquedaCliente.Size = new System.Drawing.Size(320, 223);
            this.pnlBusquedaCliente.TabIndex = 36;
            this.pnlBusquedaCliente.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::SastUI.UI.Windows.Properties.Resources.Buscar;
            this.btnBuscar.Location = new System.Drawing.Point(29, 157);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(132, 44);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtInformacion
            // 
            this.txtInformacion.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformacion.Location = new System.Drawing.Point(29, 118);
            this.txtInformacion.Name = "txtInformacion";
            this.txtInformacion.Size = new System.Drawing.Size(266, 27);
            this.txtInformacion.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "Información:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipoBusqueda
            // 
            this.cmbTipoBusqueda.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoBusqueda.FormattingEnabled = true;
            this.cmbTipoBusqueda.Location = new System.Drawing.Point(29, 50);
            this.cmbTipoBusqueda.Name = "cmbTipoBusqueda";
            this.cmbTipoBusqueda.Size = new System.Drawing.Size(266, 27);
            this.cmbTipoBusqueda.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Buscar por:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SastUI.UI.Windows.Properties.Resources.Guardar;
            this.btnGuardar.Location = new System.Drawing.Point(558, 40);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 60);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarTipo
            // 
            this.btnAgregarTipo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipo.Image = global::SastUI.UI.Windows.Properties.Resources.Agregar;
            this.btnAgregarTipo.Location = new System.Drawing.Point(558, 106);
            this.btnAgregarTipo.Name = "btnAgregarTipo";
            this.btnAgregarTipo.Size = new System.Drawing.Size(114, 60);
            this.btnAgregarTipo.TabIndex = 38;
            this.btnAgregarTipo.Text = "Agregar Tipo";
            this.btnAgregarTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarTipo.UseVisualStyleBackColor = true;
            this.btnAgregarTipo.Click += new System.EventHandler(this.btnAgregarTipo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::SastUI.UI.Windows.Properties.Resources.Limpiar;
            this.btnLimpiar.Location = new System.Drawing.Point(558, 172);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(114, 60);
            this.btnLimpiar.TabIndex = 39;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::SastUI.UI.Windows.Properties.Resources.Eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(558, 238);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 60);
            this.btnEliminar.TabIndex = 40;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::SastUI.UI.Windows.Properties.Resources.Cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(917, 12);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(35, 30);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCerrar.TabIndex = 41;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(990, 16);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.ReadOnly = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(29, 27);
            this.txtNombreUsuario.TabIndex = 43;
            this.txtNombreUsuario.Visible = false;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(956, 16);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.Size = new System.Drawing.Size(28, 27);
            this.txtIdUsuario.TabIndex = 42;
            this.txtIdUsuario.Visible = false;
            // 
            // pnlNuevoTipo
            // 
            this.pnlNuevoTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNuevoTipo.Controls.Add(this.label11);
            this.pnlNuevoTipo.Controls.Add(this.btnCancelarNuevoTipo);
            this.pnlNuevoTipo.Controls.Add(this.btnGuardarNuevoTipo);
            this.pnlNuevoTipo.Controls.Add(this.txtNuevoTipo);
            this.pnlNuevoTipo.Controls.Add(this.label8);
            this.pnlNuevoTipo.Location = new System.Drawing.Point(571, 91);
            this.pnlNuevoTipo.Name = "pnlNuevoTipo";
            this.pnlNuevoTipo.Size = new System.Drawing.Size(320, 223);
            this.pnlNuevoTipo.TabIndex = 44;
            this.pnlNuevoTipo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "Descripción:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNuevoTipo
            // 
            this.txtNuevoTipo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevoTipo.Location = new System.Drawing.Point(25, 90);
            this.txtNuevoTipo.Name = "txtNuevoTipo";
            this.txtNuevoTipo.Size = new System.Drawing.Size(266, 27);
            this.txtNuevoTipo.TabIndex = 32;
            // 
            // btnGuardarNuevoTipo
            // 
            this.btnGuardarNuevoTipo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNuevoTipo.Image = global::SastUI.UI.Windows.Properties.Resources.Guardar;
            this.btnGuardarNuevoTipo.Location = new System.Drawing.Point(25, 146);
            this.btnGuardarNuevoTipo.Name = "btnGuardarNuevoTipo";
            this.btnGuardarNuevoTipo.Size = new System.Drawing.Size(132, 44);
            this.btnGuardarNuevoTipo.TabIndex = 35;
            this.btnGuardarNuevoTipo.Text = "Guardar";
            this.btnGuardarNuevoTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarNuevoTipo.UseVisualStyleBackColor = true;
            this.btnGuardarNuevoTipo.Click += new System.EventHandler(this.btnGuardarNuevoTipo_Click);
            // 
            // btnCancelarNuevoTipo
            // 
            this.btnCancelarNuevoTipo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarNuevoTipo.Image = global::SastUI.UI.Windows.Properties.Resources.Cancelar;
            this.btnCancelarNuevoTipo.Location = new System.Drawing.Point(163, 146);
            this.btnCancelarNuevoTipo.Name = "btnCancelarNuevoTipo";
            this.btnCancelarNuevoTipo.Size = new System.Drawing.Size(132, 44);
            this.btnCancelarNuevoTipo.TabIndex = 36;
            this.btnCancelarNuevoTipo.Text = "Cancelar";
            this.btnCancelarNuevoTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarNuevoTipo.UseVisualStyleBackColor = true;
            this.btnCancelarNuevoTipo.Click += new System.EventHandler(this.btnCancelarNuevoTipo_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 19);
            this.label11.TabIndex = 37;
            this.label11.Text = "Nuevo Tipo Teléfono";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelarBusqueda
            // 
            this.btnCancelarBusqueda.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarBusqueda.Image = global::SastUI.UI.Windows.Properties.Resources.Cancelar;
            this.btnCancelarBusqueda.Location = new System.Drawing.Point(167, 157);
            this.btnCancelarBusqueda.Name = "btnCancelarBusqueda";
            this.btnCancelarBusqueda.Size = new System.Drawing.Size(132, 44);
            this.btnCancelarBusqueda.TabIndex = 37;
            this.btnCancelarBusqueda.Text = "Cancelar";
            this.btnCancelarBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarBusqueda.UseVisualStyleBackColor = true;
            this.btnCancelarBusqueda.Click += new System.EventHandler(this.btnCancelarBusqueda_Click);
            // 
            // FormTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1031, 699);
            this.ControlBox = false;
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregarTipo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvTelefonos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAbrirBusqueda);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBusquedaCliente);
            this.Controls.Add(this.pnlNuevoTipo);
            this.Name = "FormTelefono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTelefono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).EndInit();
            this.pnlBusquedaCliente.ResumeLayout(false);
            this.pnlBusquedaCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.pnlNuevoTipo.ResumeLayout(false);
            this.pnlNuevoTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label10;
        private TextBox txtId;
        private TextBox txtIdCliente;
        private Label label2;
        private TextBox txtNombreCliente;
        private Label label3;
        private ComboBox cmbTipo;
        private TextBox txtNumero;
        private Label label4;
        private ComboBox cmbEstado;
        private Label label9;
        private Button btnAbrirBusqueda;
        private Label label5;
        private DataGridView dgvTelefonos;
        private Panel pnlBusquedaCliente;
        private Label label6;
        private ComboBox cmbTipoBusqueda;
        private TextBox txtInformacion;
        private Label label7;
        private Button btnBuscar;
        private Button btnGuardar;
        private Button btnAgregarTipo;
        private Button btnLimpiar;
        private Button btnEliminar;
        private PictureBox pctCerrar;
        private TextBox txtNombreUsuario;
        private TextBox txtIdUsuario;
        private Panel pnlNuevoTipo;
        private TextBox txtNuevoTipo;
        private Label label8;
        private Label label11;
        private Button btnCancelarNuevoTipo;
        private Button btnGuardarNuevoTipo;
        private Button btnCancelarBusqueda;
    }
}