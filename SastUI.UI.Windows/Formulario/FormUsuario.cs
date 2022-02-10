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
using static SastUI.Infraestructura.CrossCutting.SeguridadRepositorio;

namespace SastUI.UI.Windows.Formulario
{
    public partial class FormUsuario : Form
    {
        public FormUsuario(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
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

            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;

            ListarUsuarios();

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
            DataTable dtBusqueda = new DataTable();
            dtBusqueda.Columns.Add("Id");
            dtBusqueda.Columns.Add("Nombre");

            dtBusqueda.Rows.Add(0, "Buscar");
            dtBusqueda.Rows.Add(1, "Login");
            dtBusqueda.Rows.Add(2, "Cédula");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";
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
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
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

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 1)
                cmbEstado.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioVistaModelo usuarioView = new UsuarioVistaModelo();
            usuarioView.Identificacion = txtIdentificacion.Text;
            usuarioView.Nombre = txtNombre.Text.ToUpper();
            usuarioView.Correo = txtCorreo.Text.ToLower();
            usuarioView.Login = txtUsuario.Text.Trim();
            usuarioView.Pass = txtPass.Text.Trim();
            usuarioView.PerfilId = int.Parse(cmbPerfiles.SelectedValue.ToString());
            usuarioView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (string.IsNullOrEmpty(usuarioView.Identificacion) || string.IsNullOrEmpty(usuarioView.Nombre) ||
                string.IsNullOrEmpty(usuarioView.Correo) || string.IsNullOrEmpty(usuarioView.Login) || usuarioView.PerfilId <= 0)
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    usuarioView.Id = int.Parse(txtId.Text);
                    DataGridViewRow rowSlt = new DataGridViewRow();

                    foreach (DataGridViewRow row in dgv_usuarios.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == usuarioView.Id)
                            rowSlt = row;
                    }

                    if (!string.IsNullOrEmpty(usuarioView.Pass))
                        usuarioView.Pass = Encrypt.Encriptar(usuarioView.Pass);
                    else
                        usuarioView.Pass = rowSlt.Cells["Pass"].Value.ToString().Trim();

                    bool validarDuplicado = false;

                    if (rowSlt.Cells["Login"].Value.ToString().Trim() != usuarioView.Login)
                    {
                        validarDuplicado = new UsuarioControlador().ValidarDuplicado(usuarioView.Login);
                        if (validarDuplicado)
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsuario.Text = "";
                        }
                    }

                    if (!validarDuplicado)
                    {
                        if (new UsuarioControlador().ActualizarUsuario(usuarioView))
                        {
                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "USUARIO";
                            auditoria.Accion = "ACTUALIZAR";
                            auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + " | " + rowSlt.Cells["PerfilId"].Value.ToString() + " | " + rowSlt.Cells["Login"].Value.ToString() + " | " + rowSlt.Cells["Pass"].Value.ToString() + " | " + rowSlt.Cells["Nombre"].Value.ToString() + " | " + rowSlt.Cells["Correo"].Value.ToString() + " | " + rowSlt.Cells["Identificacion"].Value.ToString() + " | " + rowSlt.Cells["Permisos"].Value.ToString();
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);

                            MessageBox.Show("Usuario Actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarUsuarios();
                        Limpiar();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(usuarioView.Pass))
                    {
                        usuarioView.Pass = Encrypt.Encriptar(usuarioView.Pass);
                        if (new UsuarioControlador().ValidarDuplicado(usuarioView.Login))
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsuario.Text = "";
                        }
                        else
                        {
                            if (new UsuarioControlador().InsertarUsuario(usuarioView))
                            {
                                MessageBox.Show("Usuario Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                                auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                                auditoria.Modulo = "USUARIO";
                                auditoria.Accion = "INGRESAR";
                                auditoria.Valor = "NUEVO | " + usuarioView.Login + " | " + usuarioView.Identificacion + " | " + usuarioView.Correo;
                                auditoria.Fecha = DateTime.Now;
                                new AuditoriaControlador().InsertarAuditoria(auditoria);
                            }
                            else
                                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            ListarUsuarios();
                            Limpiar();
                        }
                    }
                    else
                        MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            var nombre = txtNuevoPerfil.Text.ToUpper().Trim();

            if (string.IsNullOrEmpty(nombre))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (new PerfilControlador().ValidarDuplicado(nombre))
                {
                    MessageBox.Show("Ya existe un registro con esta descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNuevoPerfil.Text = "";
                }
                else
                {
                    PerfilVistaModelo perfil = new PerfilVistaModelo();
                    perfil.Nombre = nombre.ToUpper().Trim();
                    perfil.Estado = 1;
                    if (chkPermisos.Checked)
                        perfil.Permisos = 1;
                    else
                        perfil.Permisos = 0;

                    if (new PerfilControlador().InsertarPerfil(perfil))
                    {
                        CargarPerfiles();
                        pnlNuevoPerfil.Visible = false;
                        txtNuevoPerfil.Text = "";
                        pnlNuevoPerfil.SendToBack();

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "USUARIO - PERFIL";
                        auditoria.Accion = "INGRESAR";
                        auditoria.Valor = "NUEVO | " + perfil.Nombre + " | " + perfil.Permisos.ToString();
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);
                    }
                    else
                        MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                {
                    MessageBox.Show("Usuario Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "USUARIO";
                    auditoria.Accion = "ELIMINAR";
                    auditoria.Valor = "INACTIVO | " + idUsuario.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);
                }
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
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
            menu.Show();
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
                var cliente = new UsuarioControlador().BuscarUsuarioPorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null)
                {
                    dgv_usuarios.DataSource = cliente;
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
            txtInformacion.Text = "";
            btnBuscar.Visible = false;
            btnCancelarBusqueda.Visible = false;
            cmbTipoBusqueda.SelectedIndex = 0;
            ListarUsuarios();
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text.ToString();
            if (!string.IsNullOrEmpty(identificacion))
            {
                if (!new SeguridadRepositorio().VerificarIdentificacion(identificacion))
                {
                    MessageBox.Show("La identificación ingresada es incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdentificacion.Text = "";
                }
            }
        }
    }
}
