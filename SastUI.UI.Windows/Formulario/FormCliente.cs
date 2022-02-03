using SastUI.Infraestructura.CrossCutting;
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
        public FormCliente(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
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

            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;

            ListarClientes();

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 0)
            {
                btn_eliminar.Visible = false;
            }
            else
            {
                btn_eliminar.Visible = true;
            }

            //Llenar combo busqueda
            DataTable dtBusqueda = new DataTable();
            dtBusqueda.Columns.Add("Id");
            dtBusqueda.Columns.Add("Nombre");

            dtBusqueda.Rows.Add(0, "Busar");
            dtBusqueda.Rows.Add(1, "Cédula");
            dtBusqueda.Rows.Add(2, "Nombre");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";
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
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
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
            var permisos = int.Parse(txtPermisos.Text.ToString());
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
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

            cmbEstado.Enabled = true;
            ConsultarTelefonosCliente(idCliente);
        }

        public void ConsultarTelefonosCliente(int idCliente)
        {
            dgvTelefonos.DataSource = new TelefonoControlador().ListarTelefonosCliente(idCliente);
            dgvTelefonos.Columns["IdTipoTelefono"].Visible = false;
            dgvTelefonos.Columns["DescripcionTipo"].Visible = false;
            dgvTelefonos.Columns["ClienteId"].Visible = false;
            dgvTelefonos.Columns["NombreCliente"].Visible = false;
            dgvTelefonos.Columns["Estado"].Visible = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            var identificacion = txtIdentificacion.Text;
            var nombre = txtNombre.Text.ToUpper();
            var correo = txtCorreo.Text.ToLower();
            int estado = 0;

            if (!string.IsNullOrEmpty(txtId.Text))
                estado = int.Parse(cmbEstado.SelectedValue.ToString());
            else
                estado = 1;

            if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ClienteVistaModelo clienteView = new ClienteVistaModelo();
                clienteView.Identificacion = identificacion;
                clienteView.Nombre = nombre;
                clienteView.Correo = correo;
                clienteView.Estado = estado;

                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    clienteView.Id = int.Parse(txtId.Text);
                    new ClienteControlador().ActualizarCliente(clienteView);

                    DataGridViewRow rowSlt = new DataGridViewRow();

                    foreach (DataGridViewRow row in dgv_clientes.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == clienteView.Id)
                            rowSlt = row;
                    }

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "CLIENTE";
                    auditoria.Accion = "ACTUALIZAR";
                    auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + "|" + rowSlt.Cells["Identificacion"].Value.ToString() + "|" + rowSlt.Cells["Nombre"].Value.ToString() + "|" + rowSlt.Cells["Correo"].Value.ToString() + "|" + rowSlt.Cells["Estado"].Value.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);

                    ListarClientes();
                    Limpiar();
                }
                else
                {
                    if (new ClienteControlador().ValidarDuplicados(identificacion))
                    {
                        if (new ClienteControlador().InsertarCliente(clienteView))
                            MessageBox.Show("Cliente Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "CLIENTE";
                        auditoria.Accion = "INGRESAR";
                        auditoria.Valor = "NUEVO";
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);

                        ListarClientes();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un cliente registrado con esta cédula", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtIdentificacion.Text = "";
                    }
                }
            }
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarLetras(e);
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarNumeros(e);
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            string cedula = txtIdentificacion.Text.ToString();
            if (!new SeguridadRepositorio().ValidarCedula(cedula))
            {
                MessageBox.Show("La cédula ingresada es incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdentificacion.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.ToString();
            if (!new SeguridadRepositorio().ValidarEmail(correo))
            {
                MessageBox.Show("El correo ingresado es incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarNumeros(e);
        }

        private void cmbTipoBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idBusqueda = int.Parse(cmbTipoBusqueda.SelectedValue.ToString());
            if (idBusqueda > 0)
            {
                txtInformacion.Visible = true;
                btnBuscar.Visible = true;
                btnCancelarBusqueda.Visible = true;
            }
            else
            {
                txtInformacion.Visible = false;
                btnBuscar.Visible = false;
                btnCancelarBusqueda.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbTipoBusqueda.SelectedValue.ToString();
            var info = txtInformacion.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                var cliente = new ClienteControlador().BuscarClientePorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null)
                {
                    dgv_clientes.DataSource = cliente;
                }
                else
                {
                    MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTipoBusqueda.SelectedIndex = 0;
                    txtInformacion.Text = "";
                }
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            txtInformacion.Visible = false;
            btnBuscar.Visible = false;
            btnCancelarBusqueda.Visible = false;
            cmbTipoBusqueda.SelectedIndex = 0;
            ListarClientes();
        }
    }
}
