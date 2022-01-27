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
    public partial class FormCliente : Form
    {
        private ClienteVistaModelo clienteView;

        public FormCliente(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            CargarTiposTelefono();

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

            ListarClientes();
        }

        public void ListarClientes()
        {
            dgv_clientes.DataSource = new ClienteControlador().ObtenerClientes();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            cmbEstado.SelectedIndex = 0;
            dgvTelefonos.DataSource = null;
            dgvTelefonos.Rows.Clear();
        }

        private void pct_cerrar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            cmbEstado.SelectedIndex = 0;
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
            menu.Show();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idCliente = int.Parse(txtId.Text.ToString());
                if (new ClienteControlador().DesactivarCliente(idCliente))
                    MessageBox.Show("Cliente Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarClientes();
            Limpiar();
        }

        private void dgv_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgv_clientes.Rows[index];
            int idCliente = int.Parse(seleccionado.Cells[0].Value.ToString());
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtIdentificacion.Text = seleccionado.Cells[1].Value.ToString();
            txtNombre.Text = seleccionado.Cells[2].Value.ToString();
            txtCorreo.Text = seleccionado.Cells[3].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[4].Value.ToString());
            cmbEstado.SelectedValue = estado;

            ConsultarTelefonosCliente(idCliente);
        }

        public void ConsultarTelefonosCliente(int idCliente)
        {
            dgvTelefonos.DataSource = new TelefonoControlador().ListarTelefonosCliente(idCliente);
            dgvTelefonos.Columns["IdTipoTelefono"].Visible = false;
            dgvTelefonos.Columns["ClienteId"].Visible = false;
            dgvTelefonos.Columns["Estado"].Visible = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            clienteView = new ClienteVistaModelo();
            clienteView.Identificacion = txtIdentificacion.Text;
            clienteView.Nombre = txtNombre.Text.ToUpper();
            clienteView.Correo = txtCorreo.Text.ToLower();
            clienteView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                clienteView.Id = int.Parse(txtId.Text);
                new ClienteControlador().ActualizarCliente(clienteView);
            }
            else
            {
                if (new ClienteControlador().InsertarCliente(clienteView))
                    MessageBox.Show("Cliente Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarClientes();
            Limpiar();
        }

        public void CargarTiposTelefono()
        {
            var tiposActivos = new TipoTelefonoControlador().ListarTiposActivos();
            cmbTipoTelefono.DataSource = tiposActivos;
            cmbTipoTelefono.ValueMember = "Id";
            cmbTipoTelefono.DisplayMember = "Descripcion";
        }

        private void btnGuardarTelefono_Click(object sender, EventArgs e)
        {
            var telefono  = new TelefonoVistaModelo();
            telefono.IdTipoTelefono = int.Parse(cmbTipoTelefono.SelectedValue.ToString());
            telefono.ClienteId = int.Parse(txtId.Text.ToString());
            telefono.Numero = txtNumero.Text.ToUpper().Trim();
            telefono.Estado = 1;
            if (new TelefonoControlador().InsertarTelefono(telefono))
            {
                pnlTelefono.Visible = false;
                txtNumero.Text = "";
                cmbTipoTelefono.SelectedIndex = 0;
                pnlTelefono.SendToBack();
                ConsultarTelefonosCliente(telefono.ClienteId);
            }
            else
                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                pnlTelefono.Visible = true;
                pnlTelefono.BringToFront();
            }
            else
                MessageBox.Show("No ha seleccionado ningún cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelarTelefono_Click(object sender, EventArgs e)
        {
            pnlTelefono.Visible = false;
            txtNumero.Text = "";
            cmbTipoTelefono.SelectedIndex = 0;
            pnlTelefono.SendToBack();
        }
    }
}
