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
    public partial class FormEquipo : Form
    {
        public FormEquipo(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void CargarTipoEquipo()
        {
            var tiposActivos = new TipoEquipoControlador().ListarTiposActivos();
            cmbTipoEquipo.DataSource = tiposActivos;
            cmbTipoEquipo.ValueMember = "Id";
            cmbTipoEquipo.DisplayMember = "Descripcion";
        }

        public void CargarMarcas()
        {
            var tiposActivos = new MarcaControlador().ListarMarcasActivas();
            cmbMarcas.DataSource = tiposActivos;
            cmbMarcas.ValueMember = "Id";
            cmbMarcas.DisplayMember = "Descripcion";
        }

        public void CargarModelos(int idMarcas)
        {
            var tiposActivos = new ModeloControlador().ListarModelosActivos(idMarcas);
            cmbModelos.DataSource = tiposActivos;
            cmbModelos.ValueMember = "Id";
            cmbModelos.DisplayMember = "Descripcion";
        }

        public void ListarEquipos()
        {
            dgvEquipos.DataSource = new EquipoControlador().ObtenerEquipos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            cmbTipoEquipo.SelectedIndex = 0;
            cmbMarcas.SelectedIndex = 0;
            txtSerie.Text = "";
            txtSO.Text = "";
            txtCaracteristicas.Text = "";
            txtObservaciones.Text = "";
            cmbEstado.SelectedIndex = 1;
            cmbEstado.Enabled = false;
            cmbModelos.DataSource = null;
            cmbModelos.Items.Clear();
        }

        private void FormEquipo_Load(object sender, EventArgs e)
        {
            CargarTipoEquipo();
            CargarMarcas();

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

            ListarEquipos();

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
            dtBusqueda.Rows.Add(1, "Serie");

            cmbTipoBusqueda.Items.Clear();
            cmbTipoBusqueda.DataSource = dtBusqueda;
            cmbTipoBusqueda.ValueMember = "Id";
            cmbTipoBusqueda.DisplayMember = "Nombre";
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            pnlTipoEquipo.Visible = true;
            pnlTipoEquipo.BringToFront();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = true;
            pnlMarca.BringToFront();
        }

        private void btnAgregarModelo_Click(object sender, EventArgs e)
        {
            pnlModelo.Visible = true;
            pnlModelo.BringToFront();
        }

        private void btnCancelarTipo_Click(object sender, EventArgs e)
        {
            pnlTipoEquipo.Visible = false;
            txtNuevoTipo.Text = "";
            pnlTipoEquipo.SendToBack();
        }

        private void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = false;
            txtNuevaMarca.Text = "";
            pnlMarca.SendToBack();
        }

        private void btnCancelarModelo_Click(object sender, EventArgs e)
        {
            pnlModelo.Visible = false;
            txtNuevoModelo.Text = "";
            pnlModelo.SendToBack();
        }

        private void btnGuardarTipo_Click(object sender, EventArgs e)
        {
            var tipoEquipo = new TipoEquipoVistaModelo();
            tipoEquipo.Descripcion = txtNuevoTipo.Text.ToUpper().Trim();
            tipoEquipo.Estado = 1;

            if (!string.IsNullOrEmpty(tipoEquipo.Descripcion))
            {
                if (new TipoEquipoControlador().ValidarDuplicado(tipoEquipo.Descripcion))
                    MessageBox.Show("Ya existe un registro con la misma descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (new TipoEquipoControlador().InsertarTipoEquipo(tipoEquipo))
                    {
                        CargarTipoEquipo();
                        pnlTipoEquipo.Visible = false;
                        txtNuevoTipo.Text = "";
                        pnlTipoEquipo.SendToBack();

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "EQUIPOS - TIPOEQUIPO";
                        auditoria.Accion = "GUARDAR";
                        auditoria.Valor = "NUEVO";
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);
                    }
                    else
                        MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Existen campos vacíos! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            var marca = new MarcaVistaModelo();
            marca.Descripcion = txtNuevaMarca.Text.ToUpper().Trim();
            marca.Estado = 1;

            if (!string.IsNullOrEmpty(marca.Descripcion))
            {
                if (new MarcaControlador().ValidarDuplicado(marca.Descripcion))
                    MessageBox.Show("Ya existe un registro con la misma descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (new MarcaControlador().InsertarMarca(marca))
                    {
                        CargarMarcas();
                        pnlMarca.Visible = false;
                        txtNuevaMarca.Text = "";
                        pnlMarca.SendToBack();

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "EQUIPOS - MARCA";
                        auditoria.Accion = "GUARDAR";
                        auditoria.Valor = "NUEVO";
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);
                    }
                    else
                        MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Existen campos vacíos! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuardarModelo_Click(object sender, EventArgs e)
        {
            var modelo = new ModeloVistaModelo();
            modelo.MarcaId = int.Parse(cmbMarcas.SelectedValue.ToString());
            modelo.Descripcion = txtNuevoModelo.Text.ToUpper().Trim();
            modelo.Estado = 1;

            if (modelo.MarcaId > 0 && !string.IsNullOrEmpty(modelo.Descripcion))
            {
                if (new ModeloControlador().ValidarDuplicado(modelo.Descripcion, modelo.MarcaId.GetValueOrDefault()))
                    MessageBox.Show("Ya existe un registro con la misma descripción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (new ModeloControlador().InsertarModelo(modelo))
                    {
                        CargarModelos(modelo.MarcaId.GetValueOrDefault());
                        pnlModelo.Visible = false;
                        txtNuevoModelo.Text = "";
                        pnlModelo.SendToBack();

                        AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                        auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                        auditoria.Modulo = "EQUIPOS - MODELO";
                        auditoria.Accion = "GUARDAR";
                        auditoria.Valor = "NUEVO";
                        auditoria.Fecha = DateTime.Now;
                        new AuditoriaControlador().InsertarAuditoria(auditoria);
                    }
                    else
                        MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Existen campos vacíos! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EquipoVistaModelo equipoView = new EquipoVistaModelo();
            equipoView.TipoId = int.Parse(cmbTipoEquipo.SelectedValue.ToString());
            equipoView.MarcaId = int.Parse(cmbMarcas.SelectedValue.ToString());
            if (cmbModelos.DataSource == null)
                equipoView.MarcaId = 0;
            else
                equipoView.ModeloId = int.Parse(cmbModelos.SelectedValue.ToString());
            equipoView.Serie = txtSerie.Text.ToUpper().Trim();
            equipoView.SistemaOperativo = txtSO.Text.ToUpper().Trim();
            equipoView.Observaciones = txtObservaciones.Text.ToUpper().Trim();
            equipoView.Caracteristicas = txtCaracteristicas.Text.ToUpper().Trim();
            equipoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (equipoView.TipoId <= 0 || equipoView.MarcaId <= 0 || equipoView.ModeloId <= 0 ||
                string.IsNullOrEmpty(equipoView.Serie) || string.IsNullOrEmpty(equipoView.SistemaOperativo) ||
                string.IsNullOrEmpty(equipoView.Observaciones) || string.IsNullOrEmpty(equipoView.Caracteristicas))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    equipoView.Id = int.Parse(txtId.Text);
                    DataGridViewRow rowSlt = new DataGridViewRow();

                    foreach (DataGridViewRow row in dgvEquipos.Rows)
                    {
                        if (int.Parse(row.Cells["Id"].Value.ToString()) == equipoView.Id)
                            rowSlt = row;
                    }

                    bool validarDuplicado = false;

                    if (rowSlt.Cells["Serie"].Value.ToString().Trim() != equipoView.Serie)
                    {
                        validarDuplicado = new MarcaControlador().ValidarDuplicado(equipoView.Serie);
                        if (validarDuplicado)
                        {
                            MessageBox.Show("Ya existe un registro con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSerie.Text = "";
                        }
                    }

                    if (!validarDuplicado)
                    {
                        if (new EquipoControlador().ActualizarEquipo(equipoView))
                        {
                            MessageBox.Show("Equipo Actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "EQUIPO";
                            auditoria.Accion = "ACTUALIZAR";
                            auditoria.Valor = rowSlt.Cells["Id"].Value.ToString() + "|" + rowSlt.Cells["TipoId"].Value.ToString() + "|" + rowSlt.Cells["MarcaId"].Value.ToString() + "|" + rowSlt.Cells["ModeloId"].Value.ToString() + "|" + rowSlt.Cells["Serie"].Value.ToString() + "|" + rowSlt.Cells["SistemaOperativo"].Value.ToString() + "|" + rowSlt.Cells["Observaciones"].Value.ToString() + "|" + rowSlt.Cells["Estado"].Value.ToString();
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);
                        }
                        else
                            MessageBox.Show("No es posible actualizar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarEquipos();
                    Limpiar();
                }
                else
                {
                    if (new EquipoControlador().ValidarDuplicado(equipoView.Serie))
                    {
                        MessageBox.Show("Ya existe un equipo registrado con este número de serie", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSerie.Text = "";
                    }
                    else
                    {
                        if (new EquipoControlador().InsertarEquipo(equipoView))
                        {
                            MessageBox.Show("Equipo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                            auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                            auditoria.Modulo = "EQUIPO";
                            auditoria.Accion = "INGRESAR";
                            auditoria.Valor = "NUEVO | " + equipoView.Serie;
                            auditoria.Fecha = DateTime.Now;
                            new AuditoriaControlador().InsertarAuditoria(auditoria);
                        }
                        else
                            MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ListarEquipos();
                        Limpiar();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idEquipo = int.Parse(txtId.Text.ToString());
                if (new EquipoControlador().DesactivarEquipo(idEquipo))
                {
                    MessageBox.Show("Equipo Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                    auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                    auditoria.Modulo = "EQUIPO";
                    auditoria.Accion = "ELIMINAR";
                    auditoria.Valor = "INACTIVO | " + idEquipo.ToString();
                    auditoria.Fecha = DateTime.Now;
                    new AuditoriaControlador().InsertarAuditoria(auditoria);
                }
                else
                    MessageBox.Show("Error al desactivar equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ListarEquipos();
                Limpiar();
            }
            else
                MessageBox.Show("No ha seleccionado ningún equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvEquipos.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            cmbTipoEquipo.SelectedValue = int.Parse(seleccionado.Cells[1].Value.ToString());
            cmbMarcas.SelectedValue = int.Parse(seleccionado.Cells[3].Value.ToString());
            txtSerie.Text = seleccionado.Cells[7].Value.ToString();
            txtSO.Text = seleccionado.Cells[8].Value.ToString();
            txtCaracteristicas.Text = seleccionado.Cells[9].Value.ToString();
            txtObservaciones.Text = seleccionado.Cells[10].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[11].Value.ToString());
            cmbEstado.SelectedValue = estado;

            int idMarca = int.Parse(seleccionado.Cells[3].Value.ToString());
            CargarModelos(idMarca);
            cmbModelos.SelectedValue = int.Parse(seleccionado.Cells[5].Value.ToString());

            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 1)
                cmbEstado.Enabled = true;
        }

        private void cmbMarcas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idMarca = int.Parse(cmbMarcas.SelectedValue.ToString());
            if (idMarca > 0)
                CargarModelos(idMarca);
            else
            {
                cmbModelos.DataSource = null;
                cmbModelos.Items.Clear();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbTipoBusqueda.SelectedValue.ToString();
            var info = txtInformacion.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                var cliente = new EquipoControlador().BuscarEquipoPorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null)
                {
                    dgvEquipos.DataSource = cliente;
                }
                else
                {
                    MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTipoBusqueda.SelectedIndex = 0;
                    txtInformacion.Text = "";
                }
            }
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

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            txtInformacion.Visible = false;
            btnBuscar.Visible = false;
            btnCancelarBusqueda.Visible = false;
            cmbTipoBusqueda.SelectedIndex = 0;
            ListarEquipos();
        }
    }
}
