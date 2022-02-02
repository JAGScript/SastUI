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
    public partial class FormModelo : Form
    {
        public FormModelo(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void ListarModelos()
        {
            dgvModelos.DataSource = new ModeloControlador().ObtenerModelos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void FormModelo_Load(object sender, EventArgs e)
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

            ListarModelos();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            Limpiar();
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
            menu.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ModeloVistaModelo modeloView = new ModeloVistaModelo();
            modeloView.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            modeloView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                modeloView.Id = int.Parse(txtId.Text);
                new ModeloControlador().ActualizarModelo(modeloView);
            }
            else
            {
                if (new ModeloControlador().InsertarModelo(modeloView))
                    MessageBox.Show("Modelo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarModelos();
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
                var idModelo = int.Parse(txtId.Text.ToString());
                if (new ModeloControlador().DesactivarModelo(idModelo))
                    MessageBox.Show("Modelo Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar modelo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ninguna modelo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarModelos();
            Limpiar();
        }
    }
}
