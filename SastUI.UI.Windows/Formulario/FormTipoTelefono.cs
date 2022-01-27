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
    public partial class FormTipoTelefono : Form
    {
        public FormTipoTelefono(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        public void ListarTipos()
        {
            dgvTipos.DataSource = new TipoTelefonoControlador().ObtenerTipoTelefonos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void FormTipoTelefono_Load(object sender, EventArgs e)
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

            ListarTipos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoTelefonoVistaModelo tipoTelefonoView = new TipoTelefonoVistaModelo();
            tipoTelefonoView.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            tipoTelefonoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                tipoTelefonoView.Id = int.Parse(txtId.Text);
                new TipoTelefonoControlador().ActualizarTipoTelefono(tipoTelefonoView);
            }
            else
            {
                if (new TipoTelefonoControlador().InsertarTipoTelefono(tipoTelefonoView))
                    MessageBox.Show("Tipo Teléfono Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarTipos();
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
                var idTipo = int.Parse(txtId.Text.ToString());
                if (new TipoTelefonoControlador().DesactivarTipoTelefono(idTipo))
                    MessageBox.Show("Tipo Teléfono Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar tipo teléfono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún tipo de teléfono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarTipos();
            Limpiar();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
            menu.Show();
        }

        private void dgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvTipos.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtDescripcion.Text = seleccionado.Cells[1].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[2].Value.ToString());
            cmbEstado.SelectedValue = estado;
        }
    }
}
