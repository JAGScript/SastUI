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
        public FormTipoTelefono(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void ListarTipos()
        {
            dgvTipos.DataSource = new TipoTelefonoControlador().ObtenerTipoTelefonos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
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

            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;

            ListarTipos();

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
            dtBusqueda.Rows.Add(1, "Descripción");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoTelefonoVistaModelo tipoTelefonoView = new TipoTelefonoVistaModelo();
            tipoTelefonoView.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            tipoTelefonoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (string.IsNullOrEmpty(tipoTelefonoView.Descripcion))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    tipoTelefonoView.Id = int.Parse(txtId.Text);
                    bool validarDuplicado = false;

                    DataGridViewRow rowSlt = new DataGridViewRow();
                    foreach (DataGridViewRow row in dgvTipos.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == tipoTelefonoView.Id)
                            rowSlt = row;
                    }

                    if (rowSlt.Cells["Descripcion"].Value.ToString().Trim() != tipoTelefonoView.Descripcion)
                    {
                        validarDuplicado = new TipoTelefonoControlador().ValidarDuplicado(tipoTelefonoView.Descripcion);
                        if (validarDuplicado)
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDescripcion.Text = "";
                        }
                    }

                    if (!validarDuplicado)
                    {
                        if (new TipoTelefonoControlador().ActualizarTipoTelefono(tipoTelefonoView))
                        {
                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "TIPO TELEFONO";
                            auditoria.Accion = "ACTUALIZAR";
                            auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + "|" + rowSlt.Cells["Descripcion"].Value.ToString();
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);

                            MessageBox.Show("Tipo Teléfono Actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("No es posible actualizar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarTipos();
                        Limpiar();
                    }
                }
                else
                {
                    if (new TipoTelefonoControlador().ValidarDuplicado(tipoTelefonoView.Descripcion))
                        MessageBox.Show("Ya existe un registro con esta descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (new TipoTelefonoControlador().InsertarTipoTelefono(tipoTelefonoView))
                        {
                            MessageBox.Show("Tipo Teléfono Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "TIPO TELEFONO";
                            auditoria.Accion = "INGRESAR";
                            auditoria.Valor = "NUEVO | " + tipoTelefonoView.Descripcion;
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);
                        }
                        else
                            MessageBox.Show("No es posible actualizar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarTipos();
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
                var idTipo = int.Parse(txtId.Text.ToString());
                if (new TipoTelefonoControlador().DesactivarTipoTelefono(idTipo)) 
                {
                    MessageBox.Show("Tipo Teléfono Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "TIPO TELEFONO";
                    auditoria.Accion = "ELIMINAR";
                    auditoria.Valor = "INACTIVO | " + idTipo.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);
                }                    
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
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
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

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 1)
                cmbEstado.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbTipoBusqueda.SelectedValue.ToString();
            var info = txtInformacion.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                var cliente = new TipoTelefonoControlador().BuscarTipoTelefonoPorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null)
                {
                    dgvTipos.DataSource = cliente;
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
            ListarTipos();
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
    }
}
