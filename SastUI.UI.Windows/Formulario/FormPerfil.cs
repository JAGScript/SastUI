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
        public FormPerfil(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void ListarPerfiles()
        {
            dgv_perfiles.DataSource = new PerfilControlador().ObtenerPerfiles();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text.ToUpper().Trim();
            var estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (string.IsNullOrEmpty(nombre) || estado <= 0)
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PerfilVistaModelo perfilView = new PerfilVistaModelo();
                perfilView.Nombre = nombre.ToUpper().Trim();
                perfilView.Estado = estado;
                if (chkPermisos.Checked)
                    perfilView.Permisos = 1;
                else
                    perfilView.Permisos = 0;

                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    perfilView.Id = int.Parse(txtId.Text);

                    DataGridViewRow rowSlt = new DataGridViewRow();
                    foreach (DataGridViewRow row in dgv_perfiles.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == perfilView.Id)
                            rowSlt = row;
                    }

                    bool validarDuplicado = false;

                    if (rowSlt.Cells["Nombre"].Value.ToString().Trim() != perfilView.Nombre)
                    {
                        validarDuplicado = new PerfilControlador().ValidarDuplicado(perfilView.Nombre);
                        if (validarDuplicado)
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNombre.Text = "";
                        }
                    }

                    if (!validarDuplicado)
                    {
                        if (new PerfilControlador().ActualizarPerfil(perfilView))
                        {
                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "PERFIL";
                            auditoria.Accion = "ACTUALIZAR";
                            auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + " | " + rowSlt.Cells["Nombre"].Value.ToString();
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);

                            MessageBox.Show("Perfil Actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarPerfiles();
                        Limpiar();
                    }
                }
                else
                {
                    if (new PerfilControlador().ValidarDuplicado(perfilView.Nombre))
                    {
                        MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNombre.Text = "";
                    }
                    else
                    {
                        if (new PerfilControlador().InsertarPerfil(perfilView))
                        {
                            MessageBox.Show("Perfil Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "PERFIL";
                            auditoria.Accion = "INGRESAR";
                            auditoria.Valor = "NUEVO | " + perfilView.Nombre;
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);
                        }
                        else
                            MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarPerfiles();
                        Limpiar();
                    }
                }
            }
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
                {
                    MessageBox.Show("Perfil Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "PERFIL";
                    auditoria.Accion = "ELIMINAR";
                    auditoria.Valor = "INACTIVO | " + idPerfil.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);
                }
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
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
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

            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;

            ListarPerfiles();

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
            dtBusqueda.Rows.Add(1, "Descripcion");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";
        }

        private void dgv_perfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgv_perfiles.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtNombre.Text = seleccionado.Cells[1].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[2].Value.ToString());
            cmbEstado.SelectedValue = estado;

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 1)
                cmbEstado.Enabled = true;
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
                var cliente = new PerfilControlador().BuscarPerfilPorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null)
                {
                    dgv_perfiles.DataSource = cliente;
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
            ListarPerfiles();
        }
    }
}
