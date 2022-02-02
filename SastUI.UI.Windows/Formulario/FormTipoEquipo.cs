﻿using SastUI.UI.Windows.ControladorAplicacion;
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
    public partial class FormTipoEquipo : Form
    {
        public FormTipoEquipo(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void ListarTipos()
        {
            dgvTiposEquipos.DataSource = new TipoEquipoControlador().ObtenertipoEquipos();
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void FormTipoEquipo_Load(object sender, EventArgs e)
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
            TipoEquipoVistaModelo tipoView = new TipoEquipoVistaModelo();
            tipoView.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            tipoView.Estado = int.Parse(cmbEstado.SelectedValue.ToString());

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                tipoView.Id = int.Parse(txtId.Text);
                new TipoEquipoControlador().ActualizarTipoEquipo(tipoView);
            }
            else
            {
                if (new TipoEquipoControlador().InsertarTipoEquipo(tipoView))
                    MessageBox.Show("Tipo Equipo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListarTipos();
            Limpiar();
        }

        private void dgvTiposEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvTiposEquipos.Rows[index];
            txtId.Text = seleccionado.Cells[0].Value.ToString();
            txtDescripcion.Text = seleccionado.Cells[1].Value.ToString();
            int estado = int.Parse(seleccionado.Cells[2].Value.ToString());
            cmbEstado.SelectedValue = estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text.ToString()))
            {
                var idTipo = int.Parse(txtId.Text.ToString());
                if (new TipoEquipoControlador().DesactivarTipoEquipo(idTipo))
                    MessageBox.Show("Tipo Equipo Desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Error al desactivar tipo equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado ningún tipo de equipo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ListarTipos();
            Limpiar();
        }
    }
}
