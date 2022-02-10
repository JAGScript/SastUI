namespace SastUI.UI.Windows.Formulario
{
    partial class FormAuditoria
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
            this.txtPermisos = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.pct_cerrar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pct_cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPermisos
            // 
            this.txtPermisos.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermisos.Location = new System.Drawing.Point(1280, 20);
            this.txtPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.txtPermisos.Name = "txtPermisos";
            this.txtPermisos.ReadOnly = true;
            this.txtPermisos.Size = new System.Drawing.Size(36, 32);
            this.txtPermisos.TabIndex = 76;
            this.txtPermisos.Visible = false;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(1370, 20);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.ReadOnly = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(37, 32);
            this.txtNombreUsuario.TabIndex = 75;
            this.txtNombreUsuario.Visible = false;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(1324, 20);
            this.txtIdUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.Size = new System.Drawing.Size(36, 32);
            this.txtIdUsuario.TabIndex = 74;
            this.txtIdUsuario.Visible = false;
            // 
            // pct_cerrar
            // 
            this.pct_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pct_cerrar.Image = global::SastUI.UI.Windows.Properties.Resources.Cerrar;
            this.pct_cerrar.Location = new System.Drawing.Point(1415, 15);
            this.pct_cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.pct_cerrar.Name = "pct_cerrar";
            this.pct_cerrar.Size = new System.Drawing.Size(47, 37);
            this.pct_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_cerrar.TabIndex = 73;
            this.pct_cerrar.TabStop = false;
            this.pct_cerrar.Click += new System.EventHandler(this.pct_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 33);
            this.label1.TabIndex = 77;
            this.label1.Text = "Auditoria";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::SastUI.UI.Windows.Properties.Resources.Cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(1006, 57);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 44);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::SastUI.UI.Windows.Properties.Resources.Buscar;
            this.btnBuscar.Location = new System.Drawing.Point(854, 57);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 44);
            this.btnBuscar.TabIndex = 101;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(540, 63);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(306, 32);
            this.txtInfo.TabIndex = 100;
            this.txtInfo.Visible = false;
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(346, 63);
            this.cmbBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(186, 32);
            this.cmbBusqueda.TabIndex = 99;
            this.cmbBusqueda.SelectionChangeCommitted += new System.EventHandler(this.cmbBusqueda_SelectionChangeCommitted);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(230, 66);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(114, 24);
            this.label31.TabIndex = 98;
            this.label31.Text = "Buscar por:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(54, 108);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.RowHeadersWidth = 51;
            this.dgvAuditoria.RowTemplate.Height = 24;
            this.dgvAuditoria.Size = new System.Drawing.Size(1369, 603);
            this.dgvAuditoria.TabIndex = 103;
            // 
            // FormAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1475, 723);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAuditoria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.cmbBusqueda);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPermisos);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.pct_cerrar);
            this.Name = "FormAuditoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAuditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pct_cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtPermisos;
        private TextBox txtNombreUsuario;
        private TextBox txtIdUsuario;
        private PictureBox pct_cerrar;
        private Label label1;
        private Button btnCancelar;
        private Button btnBuscar;
        private TextBox txtInfo;
        private ComboBox cmbBusqueda;
        private Label label31;
        private DataGridView dgvAuditoria;
    }
}