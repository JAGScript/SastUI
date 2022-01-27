namespace SastUI.UI.Windows.Formulario
{
    partial class FormCliente
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
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_clientes = new System.Windows.Forms.DataGridView();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.pnlTelefono = new System.Windows.Forms.Panel();
            this.cmbTipoTelefono = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvTelefonos = new System.Windows.Forms.DataGridView();
            this.pct_cerrar = new System.Windows.Forms.PictureBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btnAgregarTelefono = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btnCancelarTelefono = new System.Windows.Forms.Button();
            this.btnGuardarTelefono = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).BeginInit();
            this.pnlTelefono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(119, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 19);
            this.label10.TabIndex = 21;
            this.label10.Text = "ID:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Clientes";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(153, 58);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(312, 27);
            this.txtId.TabIndex = 22;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(153, 96);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(312, 27);
            this.txtIdentificacion.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Identificación:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(153, 135);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(312, 27);
            this.txtNombre.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nombre:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(153, 175);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(312, 27);
            this.txtCorreo.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(83, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Correo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(153, 214);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(312, 27);
            this.cmbEstado.TabIndex = 30;
            this.cmbEstado.Text = "Estados";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(84, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "Estado:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "Listado de Clientes";
            // 
            // dgv_clientes
            // 
            this.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientes.Location = new System.Drawing.Point(41, 343);
            this.dgv_clientes.Name = "dgv_clientes";
            this.dgv_clientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_clientes.Size = new System.Drawing.Size(956, 147);
            this.dgv_clientes.TabIndex = 32;
            this.dgv_clientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_clientes_CellClick);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(992, 12);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.ReadOnly = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(29, 27);
            this.txtNombreUsuario.TabIndex = 39;
            this.txtNombreUsuario.Visible = false;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(958, 12);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.Size = new System.Drawing.Size(28, 27);
            this.txtIdUsuario.TabIndex = 38;
            this.txtIdUsuario.Visible = false;
            // 
            // pnlTelefono
            // 
            this.pnlTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTelefono.Controls.Add(this.btnCancelarTelefono);
            this.pnlTelefono.Controls.Add(this.btnGuardarTelefono);
            this.pnlTelefono.Controls.Add(this.cmbTipoTelefono);
            this.pnlTelefono.Controls.Add(this.label7);
            this.pnlTelefono.Controls.Add(this.txtNumero);
            this.pnlTelefono.Controls.Add(this.label6);
            this.pnlTelefono.Location = new System.Drawing.Point(356, 40);
            this.pnlTelefono.Name = "pnlTelefono";
            this.pnlTelefono.Size = new System.Drawing.Size(373, 271);
            this.pnlTelefono.TabIndex = 40;
            this.pnlTelefono.Visible = false;
            // 
            // cmbTipoTelefono
            // 
            this.cmbTipoTelefono.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoTelefono.FormattingEnabled = true;
            this.cmbTipoTelefono.Location = new System.Drawing.Point(22, 127);
            this.cmbTipoTelefono.Name = "cmbTipoTelefono";
            this.cmbTipoTelefono.Size = new System.Drawing.Size(328, 27);
            this.cmbTipoTelefono.TabIndex = 29;
            this.cmbTipoTelefono.Text = "Tipos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tipo Teléfono:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(22, 58);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(328, 27);
            this.txtNumero.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Número:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 502);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 25);
            this.label8.TabIndex = 41;
            this.label8.Text = "Teléfonos del Cliente";
            // 
            // dgvTelefonos
            // 
            this.dgvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonos.Location = new System.Drawing.Point(42, 541);
            this.dgvTelefonos.Name = "dgvTelefonos";
            this.dgvTelefonos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTelefonos.Size = new System.Drawing.Size(955, 161);
            this.dgvTelefonos.TabIndex = 42;
            // 
            // pct_cerrar
            // 
            this.pct_cerrar.Image = global::SastUI.UI.Windows.Properties.Resources.Cerrar;
            this.pct_cerrar.Location = new System.Drawing.Point(917, 12);
            this.pct_cerrar.Name = "pct_cerrar";
            this.pct_cerrar.Size = new System.Drawing.Size(35, 30);
            this.pct_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_cerrar.TabIndex = 37;
            this.pct_cerrar.TabStop = false;
            this.pct_cerrar.Click += new System.EventHandler(this.pct_cerrar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Image = global::SastUI.UI.Windows.Properties.Resources.Eliminar;
            this.btn_eliminar.Location = new System.Drawing.Point(507, 238);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(114, 60);
            this.btn_eliminar.TabIndex = 36;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpiar.Image = global::SastUI.UI.Windows.Properties.Resources.Limpiar;
            this.btn_limpiar.Location = new System.Drawing.Point(507, 172);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(114, 60);
            this.btn_limpiar.TabIndex = 35;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btnAgregarTelefono
            // 
            this.btnAgregarTelefono.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTelefono.Image = global::SastUI.UI.Windows.Properties.Resources.Agregar;
            this.btnAgregarTelefono.Location = new System.Drawing.Point(507, 106);
            this.btnAgregarTelefono.Name = "btnAgregarTelefono";
            this.btnAgregarTelefono.Size = new System.Drawing.Size(114, 60);
            this.btnAgregarTelefono.TabIndex = 34;
            this.btnAgregarTelefono.Text = "Agregar Teléfono";
            this.btnAgregarTelefono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarTelefono.UseVisualStyleBackColor = true;
            this.btnAgregarTelefono.Click += new System.EventHandler(this.btnAgregarTelefono_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Image = global::SastUI.UI.Windows.Properties.Resources.Guardar;
            this.btn_guardar.Location = new System.Drawing.Point(507, 40);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(114, 60);
            this.btn_guardar.TabIndex = 33;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btnCancelarTelefono
            // 
            this.btnCancelarTelefono.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTelefono.Image = global::SastUI.UI.Windows.Properties.Resources.Cancelar;
            this.btnCancelarTelefono.Location = new System.Drawing.Point(203, 193);
            this.btnCancelarTelefono.Name = "btnCancelarTelefono";
            this.btnCancelarTelefono.Size = new System.Drawing.Size(115, 42);
            this.btnCancelarTelefono.TabIndex = 31;
            this.btnCancelarTelefono.Text = "Cancelar";
            this.btnCancelarTelefono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarTelefono.UseVisualStyleBackColor = true;
            this.btnCancelarTelefono.Click += new System.EventHandler(this.btnCancelarTelefono_Click);
            // 
            // btnGuardarTelefono
            // 
            this.btnGuardarTelefono.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTelefono.Image = global::SastUI.UI.Windows.Properties.Resources.Guardar;
            this.btnGuardarTelefono.Location = new System.Drawing.Point(62, 193);
            this.btnGuardarTelefono.Name = "btnGuardarTelefono";
            this.btnGuardarTelefono.Size = new System.Drawing.Size(115, 42);
            this.btnGuardarTelefono.TabIndex = 30;
            this.btnGuardarTelefono.Text = "Guardar";
            this.btnGuardarTelefono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarTelefono.UseVisualStyleBackColor = true;
            this.btnGuardarTelefono.Click += new System.EventHandler(this.btnGuardarTelefono_Click);
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1031, 722);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTelefonos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.pct_cerrar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btnAgregarTelefono);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.dgv_clientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlTelefono);
            this.Name = "FormCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).EndInit();
            this.pnlTelefono.ResumeLayout(false);
            this.pnlTelefono.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label10;
        private Label label1;
        private TextBox txtId;
        private TextBox txtIdentificacion;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtCorreo;
        private Label label4;
        private ComboBox cmbEstado;
        private Label label9;
        private Label label5;
        private DataGridView dgv_clientes;
        private Button btn_guardar;
        private Button btnAgregarTelefono;
        private Button btn_limpiar;
        private Button btn_eliminar;
        private PictureBox pct_cerrar;
        private TextBox txtNombreUsuario;
        private TextBox txtIdUsuario;
        private Panel pnlTelefono;
        private Label label6;
        private Label label7;
        private TextBox txtNumero;
        private ComboBox cmbTipoTelefono;
        private Button btnGuardarTelefono;
        private Button btnCancelarTelefono;
        private Label label8;
        private DataGridView dgvTelefonos;
    }
}