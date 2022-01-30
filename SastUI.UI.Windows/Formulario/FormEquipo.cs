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
        public FormEquipo(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
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

        public void CargarModelos()
        {
            var tiposActivos = new ModeloControlador().ListarModelosActivos();
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
            cmbModelos.SelectedIndex = 0;
            txtSerie.Text = "";
            txtSO.Text = "";
            txtCaracteristicas.Text = "";
            txtObservaciones.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void FormEquipo_Load(object sender, EventArgs e)
        {
            CargarTipoEquipo();
            CargarMarcas();
            CargarModelos();

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

            ListarEquipos();
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
            if (new TipoEquipoControlador().InsertarTipoEquipo(tipoEquipo))
            {
                CargarTipoEquipo();
                pnlTipoEquipo.Visible = false;
                txtNuevoTipo.Text = "";
                pnlTipoEquipo.SendToBack();
            }
            else
                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            var marca = new MarcaVistaModelo();
            marca.Descripcion = txtNuevaMarca.Text.ToUpper().Trim();
            marca.Estado = 1;
            if (new MarcaControlador().InsertarMarca(marca))
            {
                CargarMarcas();
                pnlMarca.Visible = false;
                txtNuevaMarca.Text = "";
                pnlMarca.SendToBack();
            }
            else
                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuardarModelo_Click(object sender, EventArgs e)
        {
            var modelo = new ModeloVistaModelo();
            modelo.Descripcion = txtNuevoModelo.Text.ToUpper().Trim();
            modelo.Estado = 1;
            if (new ModeloControlador().InsertarModelo(modelo))
            {
                CargarModelos();
                pnlModelo.Visible = false;
                txtNuevoModelo.Text = "";
                pnlModelo.SendToBack();
            }
            else
                MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            Limpiar();
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
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
            equipoView.ModeloId = int.Parse(cmbModelos.SelectedValue.ToString());
            equipoView.Serie = txtSerie.Text.ToUpper().Trim();
            equipoView.SistemaOperativo = txtSO.Text.ToUpper().Trim();
            equipoView.Observaciones = txtObservaciones.Text.ToUpper().Trim();
            equipoView.Caracteristicas = txtCaracteristicas.Text.ToUpper().Trim();
            equipoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                equipoView.Id = int.Parse(txtId.Text);
                new EquipoControlador().ActualizarEquipo(equipoView);
            }
            else
            {
                if (new EquipoControlador().InsertarEquipo(equipoView))
                    MessageBox.Show("Equipo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarEquipos();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idEquipo = int.Parse(txtId.Text.ToString());
                if (new EquipoControlador().DesactivarEquipo(idEquipo))
                    MessageBox.Show("Equipo Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarEquipos();
            Limpiar();
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvEquipos.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            cmbTipoEquipo.SelectedValue = int.Parse(seleccionado.Cells[1].Value.ToString());
            cmbMarcas.SelectedValue = int.Parse(seleccionado.Cells[3].Value.ToString());
            cmbModelos.SelectedValue = int.Parse(seleccionado.Cells[5].Value.ToString());
            txtSerie.Text = seleccionado.Cells[7].Value.ToString();
            txtSO.Text = seleccionado.Cells[8].Value.ToString();
            txtCaracteristicas.Text = seleccionado.Cells[9].Value.ToString();
            txtObservaciones.Text = seleccionado.Cells[10].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[11].Value.ToString());
            cmbEstado.SelectedValue = estado;
        }
    }
}
