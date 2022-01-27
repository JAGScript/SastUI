using SastUI.UI.Windows.ControladorAplicacion;
using SastUI.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SastUI.Infraestructura.CrossCutting.SeguridadRepositorio;

namespace SastUI.UI.Windows.Formulario
{
    public partial class FormUsuario : Form
    {
        private UsuarioVistaModelo usuarioView;

        public FormUsuario(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarPerfiles();

            //Llenar combo estados
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");

            dt.Rows.Add(0, "Estados");
            dt.Rows.Add(1, "Activo");
            dt.Rows.Add(2, "Inactivo");

            cmbEstado.Items.Clear();
            cmbEstado.DataSource = dt;
            cmbEstado.ValueMember = "Id";
            cmbEstado.DisplayMember = "Nombre";

            ListarUsuarios();
        }

        public void ListarUsuarios()
        {
            dgv_usuarios.DataSource = new UsuarioControlador().ObtenerUsuarios();
        }

        public void CargarPerfiles()
        {
            var perfilesActivos = new PerfilControlador().ListarPerfilesActivos();
            cmbPerfiles.DataSource = perfilesActivos;
            cmbPerfiles.ValueMember = "Id";
            cmbPerfiles.DisplayMember = "Nombre";
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            cmbPerfiles.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void dgv_usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgv_usuarios.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtIdentificacion.Text = seleccionado.Cells[7].Value.ToString();
            txtNombre.Text = seleccionado.Cells[5].Value.ToString();
            txtCorreo.Text = seleccionado.Cells[6].Value.ToString();
            txtUsuario.Text = seleccionado.Cells[3].Value.ToString();
            cmbPerfiles.SelectedValue = int.Parse(seleccionado.Cells[1].Value.ToString());
            int estado = int.Parse(seleccionado.Cells[8].Value.ToString());
            cmbEstado.SelectedValue = estado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            usuarioView = new UsuarioVistaModelo();
            usuarioView.Identificacion = txtIdentificacion.Text;
            usuarioView.Nombre = txtNombre.Text.ToUpper();
            usuarioView.Correo = txtCorreo.Text.ToLower();
            usuarioView.Login = txtUsuario.Text.Trim();
            usuarioView.Pass = txtPass.Text.Trim();
            usuarioView.Pass = Encrypt.Encriptar(usuarioView.Pass);
            usuarioView.PerfilId = int.Parse(cmbPerfiles.SelectedValue.ToString());
            usuarioView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                usuarioView.Id = int.Parse(txtId.Text);
                new UsuarioControlador().ActualizarUsuario(usuarioView);
            }
            else 
            {
                if (new UsuarioControlador().InsertarUsuario(usuarioView))
                    MessageBox.Show("Usuario Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarUsuarios();
            Limpiar();
        }

        private void bntAgregarPerfil_Click(object sender, EventArgs e)
        {
            pnlNuevoPerfil.Visible = true;
            pnlNuevoPerfil.BringToFront();
        }

        private void btnCancelarNuevoPerfil_Click(object sender, EventArgs e)
        {
            pnlNuevoPerfil.Visible = false;
            txtNuevoPerfil.Text = "";
            pnlNuevoPerfil.SendToBack();
        }

        private void btnGuardarNuevoPerfil_Click(object sender, EventArgs e)
        {
            var perfil = new PerfilVistaModelo();
            perfil.Nombre = txtNuevoPerfil.Text.ToUpper().Trim();
            perfil.Estado = 1;
            if(new PerfilControlador().InsertarPerfil(perfil))
            {
                CargarPerfiles();
                pnlNuevoPerfil.Visible = false;
                txtNuevoPerfil.Text = "";
                pnlNuevoPerfil.SendToBack();
            }
            else
                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idUsuario = int.Parse(txtId.Text.ToString());
                if (new UsuarioControlador().DesactivarUsuario(idUsuario))
                    MessageBox.Show("Usuario Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarUsuarios();
            Limpiar();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            cmbPerfiles.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
            menu.Show();
        }
    }
}
