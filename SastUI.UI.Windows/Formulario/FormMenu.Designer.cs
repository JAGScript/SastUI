namespace SastUI.UI.Windows.Formulario
{
    partial class FormMenu
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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.btnAbrirEquipos = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAbrirTiposTelefonos = new System.Windows.Forms.Button();
            this.btnAbrirClientes = new System.Windows.Forms.Button();
            this.btnAbrirFicha = new System.Windows.Forms.Button();
            this.btnAbrirTelefonos = new System.Windows.Forms.Button();
            this.btnAbrirPerfiles = new System.Windows.Forms.Button();
            this.btnAbrirUsuarios = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCabecera.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.AutoSize = true;
            this.pnlCabecera.Controls.Add(this.txtIdUsuario);
            this.pnlCabecera.Controls.Add(this.button1);
            this.pnlCabecera.Controls.Add(this.txtNombreUsuario);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Controls.Add(this.pictureBox1);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1187, 91);
            this.pnlCabecera.TabIndex = 11;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(874, 38);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtIdUsuario.TabIndex = 11;
            this.txtIdUsuario.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1113, 59);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(874, 59);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.ReadOnly = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(235, 30);
            this.txtNombreUsuario.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(790, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario:";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Location = new System.Drawing.Point(219, 93);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(968, 665);
            this.pnlContenido.TabIndex = 12;
            // 
            // btnAbrirEquipos
            // 
            this.btnAbrirEquipos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirEquipos.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirEquipos.Location = new System.Drawing.Point(27, 266);
            this.btnAbrirEquipos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirEquipos.Name = "btnAbrirEquipos";
            this.btnAbrirEquipos.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirEquipos.TabIndex = 13;
            this.btnAbrirEquipos.Text = "Equipos";
            this.btnAbrirEquipos.UseVisualStyleBackColor = true;
            this.btnAbrirEquipos.Click += new System.EventHandler(this.btnAbrirEquipos_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnAbrirTiposTelefonos);
            this.pnlMenu.Controls.Add(this.btnAbrirClientes);
            this.pnlMenu.Controls.Add(this.btnAbrirEquipos);
            this.pnlMenu.Controls.Add(this.btnAbrirFicha);
            this.pnlMenu.Controls.Add(this.btnAbrirTelefonos);
            this.pnlMenu.Controls.Add(this.btnAbrirPerfiles);
            this.pnlMenu.Controls.Add(this.btnAbrirUsuarios);
            this.pnlMenu.Location = new System.Drawing.Point(3, 93);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(218, 665);
            this.pnlMenu.TabIndex = 14;
            // 
            // btnAbrirTiposTelefonos
            // 
            this.btnAbrirTiposTelefonos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirTiposTelefonos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirTiposTelefonos.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirTiposTelefonos.Location = new System.Drawing.Point(27, 148);
            this.btnAbrirTiposTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirTiposTelefonos.Name = "btnAbrirTiposTelefonos";
            this.btnAbrirTiposTelefonos.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirTiposTelefonos.TabIndex = 17;
            this.btnAbrirTiposTelefonos.Text = "Tipos de Teléfonos";
            this.btnAbrirTiposTelefonos.UseVisualStyleBackColor = true;
            this.btnAbrirTiposTelefonos.Click += new System.EventHandler(this.btnAbrirTiposTelefonos_Click);
            // 
            // btnAbrirClientes
            // 
            this.btnAbrirClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirClientes.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirClientes.Location = new System.Drawing.Point(27, 30);
            this.btnAbrirClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirClientes.Name = "btnAbrirClientes";
            this.btnAbrirClientes.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirClientes.TabIndex = 16;
            this.btnAbrirClientes.Text = "Clientes";
            this.btnAbrirClientes.UseVisualStyleBackColor = true;
            this.btnAbrirClientes.Click += new System.EventHandler(this.btnAbrirClientes_Click);
            // 
            // btnAbrirFicha
            // 
            this.btnAbrirFicha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirFicha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirFicha.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirFicha.Location = new System.Drawing.Point(27, 207);
            this.btnAbrirFicha.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirFicha.Name = "btnAbrirFicha";
            this.btnAbrirFicha.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirFicha.TabIndex = 15;
            this.btnAbrirFicha.Text = "Ficha Técnica";
            this.btnAbrirFicha.UseVisualStyleBackColor = true;
            this.btnAbrirFicha.Click += new System.EventHandler(this.btnAbrirFicha_Click);
            // 
            // btnAbrirTelefonos
            // 
            this.btnAbrirTelefonos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirTelefonos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirTelefonos.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirTelefonos.Location = new System.Drawing.Point(27, 89);
            this.btnAbrirTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirTelefonos.Name = "btnAbrirTelefonos";
            this.btnAbrirTelefonos.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirTelefonos.TabIndex = 14;
            this.btnAbrirTelefonos.Text = "Teléfonos";
            this.btnAbrirTelefonos.UseVisualStyleBackColor = true;
            this.btnAbrirTelefonos.Click += new System.EventHandler(this.btnAbrirTelefonos_Click);
            // 
            // btnAbrirPerfiles
            // 
            this.btnAbrirPerfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirPerfiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirPerfiles.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPerfiles.Location = new System.Drawing.Point(27, 384);
            this.btnAbrirPerfiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirPerfiles.Name = "btnAbrirPerfiles";
            this.btnAbrirPerfiles.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirPerfiles.TabIndex = 13;
            this.btnAbrirPerfiles.Text = "Perfiles";
            this.btnAbrirPerfiles.UseVisualStyleBackColor = true;
            this.btnAbrirPerfiles.Click += new System.EventHandler(this.btnAbrirPerfiles_Click);
            // 
            // btnAbrirUsuarios
            // 
            this.btnAbrirUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirUsuarios.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirUsuarios.Location = new System.Drawing.Point(27, 325);
            this.btnAbrirUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirUsuarios.Name = "btnAbrirUsuarios";
            this.btnAbrirUsuarios.Size = new System.Drawing.Size(165, 55);
            this.btnAbrirUsuarios.TabIndex = 12;
            this.btnAbrirUsuarios.Text = "Usuarios";
            this.btnAbrirUsuarios.UseVisualStyleBackColor = true;
            this.btnAbrirUsuarios.Click += new System.EventHandler(this.btnAbrirUsuarios_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SastUI.UI.Windows.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1187, 759);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.pnlContenido);
            this.Name = "FormMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel pnlCabecera;
        private Button button1;
        private TextBox txtNombreUsuario;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtIdUsuario;
        private Panel pnlContenido;
        private Button btnAbrirEquipos;
        private Panel pnlMenu;
        private Button btnAbrirFicha;
        private Button btnAbrirTelefonos;
        private Button btnAbrirPerfiles;
        private Button btnAbrirUsuarios;
        private Button btnAbrirClientes;
        private Button btnAbrirTiposTelefonos;
    }
}