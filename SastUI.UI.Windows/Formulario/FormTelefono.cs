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
    public partial class FormTelefono : Form
    {
        public FormTelefono(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void CargarTiposTelefono()
        {
            var tiposActivos = new TipoTelefonoControlador().ListarTiposActivos();
            cmbTipo.DataSource = tiposActivos;
            cmbTipo.ValueMember = "Id";
            cmbTipo.DisplayMember = "Descripcion";
        }

        public void ListarTelefonos()
        {
            dgvTelefonos.DataSource = new TelefonoControlador().ObtenerTelefonos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtNumero.Text = "";
            cmbTipo.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
        }

        private void FormTelefono_Load(object sender, EventArgs e)
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

            //Llenar combo busqueda
            DataTable dtBusqueda = new DataTable();
            dtBusqueda.Columns.Add("Id");
            dtBusqueda.Columns.Add("Nombre");

            dtBusqueda.Rows.Add(0, "Busar");
            dtBusqueda.Rows.Add(1, "Cédula");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";

            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;

            ListarTelefonos();

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 0)
            {
                btnEliminar.Visible = false;
            }
            else
            {
                btnEliminar.Visible = true;
            }

            //Llenar combo busqueda
            DataTable dtBusqueda2 = new DataTable();
            dtBusqueda2.Columns.Add("Id");
            dtBusqueda2.Columns.Add("Nombre");

            dtBusqueda2.Rows.Add(0, "Buscar");
            dtBusqueda2.Rows.Add(1, "Cédula");
            dtBusqueda2.Rows.Add(2, "Número");

            cmbBusquedaTelefono.Items.Clear();
            cmbBusquedaTelefono.DataSource = dtBusqueda2;
            cmbBusquedaTelefono.ValueMember = "Id";
            cmbBusquedaTelefono.DisplayMember = "Nombre";
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtNumero.Text = "";
            cmbTipo.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
            menu.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvTelefonos.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            cmbTipo.SelectedValue = int.Parse(seleccionado.Cells[1].Value.ToString());
            txtIdCliente.Text = seleccionado.Cells[3].Value.ToString();
            txtNombreCliente.Text = seleccionado.Cells[4].Value.ToString();
            txtNumero.Text = seleccionado.Cells[5].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[6].Value.ToString());
            cmbEstado.SelectedValue = estado;

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 1)
                cmbEstado.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TelefonoVistaModelo telefonoView = new TelefonoVistaModelo();
            telefonoView.IdTipoTelefono = int.Parse(cmbTipo.SelectedValue.ToString());
            if (string.IsNullOrEmpty(txtIdCliente.Text))
                telefonoView.ClienteId = 0;
            else
                telefonoView.ClienteId = int.Parse(txtIdCliente.Text);
            telefonoView.Numero = txtNumero.Text.Trim();
            telefonoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (telefonoView.IdTipoTelefono <= 0 || telefonoView.ClienteId <= 0 || string.IsNullOrEmpty(telefonoView.Numero))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    telefonoView.Id = int.Parse(txtId.Text);
                    DataGridViewRow rowSlt = new DataGridViewRow();

                    foreach (DataGridViewRow row in dgvTelefonos.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == telefonoView.Id)
                            rowSlt = row;
                    }

                    bool validarDuplicado = false;

                    if (rowSlt.Cells["Numero"].Value.ToString().Trim() != telefonoView.Numero && rowSlt.Cells["ClienteId"].Value.ToString().Trim() != telefonoView.ClienteId.ToString())
                    {
                        validarDuplicado = new TelefonoControlador().ValidarDuplicados(telefonoView.Numero, telefonoView.ClienteId);
                        if (validarDuplicado)
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNumero.Text = "";
                        }
                    }

                    if (!validarDuplicado)
                    {
                        if (new TelefonoControlador().ActualizarTelefono(telefonoView))
                        {
                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "TELEFONO";
                            auditoria.Accion = "ACTUALIZAR";
                            auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + "|" + rowSlt.Cells["IdTipoTelefono"].Value.ToString() + "|" + rowSlt.Cells["ClienteId"].Value.ToString() + "|" + rowSlt.Cells["Numero"].Value.ToString();
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);

                            MessageBox.Show("Teléfono Actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("No es posible actualizar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarTelefonos();
                    Limpiar();
                }
                else
                {
                    if (new TelefonoControlador().ValidarDuplicados(telefonoView.Numero, telefonoView.ClienteId))
                        MessageBox.Show("El número ingresado ya esta registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (new TelefonoControlador().InsertarTelefono(telefonoView))
                        {
                            MessageBox.Show("Teléfono Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "TELEFONO";
                            auditoria.Accion = "INGRESAR";
                            auditoria.Valor = "NUEVO | " + telefonoView.Numero;
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);
                        }
                        else
                            MessageBox.Show("No es posible actualizar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarTelefonos();
                        Limpiar();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idTelefono = int.Parse(txtId.Text.ToString());
                if (new TelefonoControlador().DesactivarTelefono(idTelefono))
                {
                    MessageBox.Show("Teléfono Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "TELEFONO";
                    auditoria.Accion = "ELIMINAR";
                    auditoria.Valor = "INACTIVO | " + idTelefono.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);
                }
                else
                    MessageBox.Show("Error al desactivar teléfono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún teléfono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarTelefonos();
            Limpiar();
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            pnlNuevoTipo.Visible = true;
            pnlNuevoTipo.BringToFront();
        }

        private void btnCancelarNuevoTipo_Click(object sender, EventArgs e)
        {
            pnlNuevoTipo.Visible = false;
            txtNuevoTipo.Text = "";
            pnlNuevoTipo.SendToBack();
        }

        private void btnGuardarNuevoTipo_Click(object sender, EventArgs e)
        {
            var tipo = new TipoTelefonoVistaModelo();
            tipo.Descripcion = txtNuevoTipo.Text.ToUpper().Trim();
            tipo.Estado = 1;

            if (!string.IsNullOrEmpty(tipo.Descripcion))
            {
                if (new TipoTelefonoControlador().ValidarDuplicado(tipo.Descripcion))
                    MessageBox.Show("Ya existe un tipo de teléfono con esta descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (new TipoTelefonoControlador().InsertarTipoTelefono(tipo))
                    {
                        CargarTiposTelefono();
                        pnlNuevoTipo.Visible = false;
                        txtNuevoTipo.Text = "";
                        pnlNuevoTipo.SendToBack();

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "TELEFONO - TIPOTELEFONO";
                        auditoria.Accion = "INGRESAR";
                        auditoria.Valor = "NUEVO | " + tipo.Descripcion;
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);
                    }
                    else
                        MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAbrirBusqueda_Click(object sender, EventArgs e)
        {
            pnlBusquedaCliente.Visible = true;
            pnlBusquedaCliente.BringToFront();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbTipoBusqueda.SelectedValue.ToString();
            var info = txtInformacion.Text.Trim();

            if(!string.IsNullOrEmpty(tipoBusqueda) && !string.IsNullOrEmpty(info))
            {
                var cliente = new ClienteControlador().BuscarClientePorCriterio(int.Parse(tipoBusqueda), info);
                if(cliente != null && cliente.ToList().Count > 0)
                {
                    txtIdCliente.Text = cliente.ToList()[0].Id.ToString();
                    txtNombreCliente.Text = cliente.ToList()[0].Nombre.ToString();
                    pnlBusquedaCliente.Visible = false;
                    cmbTipoBusqueda.SelectedIndex = 0;
                    txtInformacion.Text = "";
                    pnlBusquedaCliente.SendToBack();
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
            pnlBusquedaCliente.Visible = false;
            cmbTipoBusqueda.SelectedIndex = 0;
            txtInformacion.Text = "";
            pnlBusquedaCliente.SendToBack();
        }

        private void btnBuscarTelefono_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbBusquedaTelefono.SelectedValue.ToString();
            var info = txtInfoBusquedaTel.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                if (int.Parse(tipoBusqueda) == 1)
                {
                    var cliente = new ClienteControlador().BuscarClientePorCriterio(1, info).FirstOrDefault();
                    if (cliente != null && !string.IsNullOrEmpty(cliente.Identificacion))
                        info = cliente.Id.ToString();
                    else
                        info = "";
                }

                if (string.IsNullOrEmpty(info))
                    MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var telefono = new TelefonoControlador().BuscarTelefonoPorCriterio(int.Parse(tipoBusqueda), info);
                    if (telefono != null)
                    {
                        dgvTelefonos.DataSource = telefono;
                    }
                    else
                    {
                        MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbTipoBusqueda.SelectedIndex = 0;
                        txtInformacion.Text = "";
                    }
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarNumeros(e);
        }

        private void txtNuevoTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarLetras(e);
        }

        private void cmbBusquedaTelefono_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idBusqueda = int.Parse(cmbBusquedaTelefono.SelectedValue.ToString());
            if (idBusqueda > 0)
            {
                txtInfoBusquedaTel.Visible = true;
                btnBuscarTelefono.Visible = true;
                btnCancelarBusqTelefono.Visible = true;
            }
            else
            {
                txtInfoBusquedaTel.Visible = false;
                btnBuscarTelefono.Visible = false;
                btnCancelarBusqTelefono.Visible = false;
            }
        }

        private void btnCancelarBusqTelefono_Click(object sender, EventArgs e)
        {
            txtInfoBusquedaTel.Visible = false;
            txtInfoBusquedaTel.Text = "";
            btnBuscarTelefono.Visible = false;
            btnCancelarBusqTelefono.Visible = false;
            cmbBusquedaTelefono.SelectedIndex = 0;
            ListarTelefonos();
        }
    }
}
