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

namespace SastUI.UI.Windows.Formulario
{
    public partial class FormPerfil : Form
    {
        private PerfilVistaModelo perfilView;

        public FormPerfil(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        public void ListarPerfiles()
        {
            dgv_perfiles.DataSource = new PerfilControlador().ObtenerPerfiles();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            perfilView = new PerfilVistaModelo();
            perfilView.Nombre = txtNombre.Text.ToUpper().Trim();
            perfilView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                perfilView.Id = int.Parse(txtId.Text);
                new PerfilControlador().ActualizarPerfil(perfilView);
            }
            else
            {
                if (new PerfilControlador().InsertarPerfil(perfilView))
                    MessageBox.Show("Perfil Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarPerfiles();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idPerfil = int.Parse(txtId.Text.ToString());
                if (new PerfilControlador().DesactivarPerfil(idPerfil))
                    MessageBox.Show("Perfil Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar perfil", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún perfil", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarPerfiles();
            Limpiar();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = 0;
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
            menu.Show();
        }

        private void FormPerfil_Load_1(object sender, EventArgs e)
        {
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

            ListarPerfiles();
        }

        private void dgv_perfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgv_perfiles.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtNombre.Text = seleccionado.Cells[1].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[2].Value.ToString());
            cmbEstado.SelectedValue = estado;
        }
    }
}
