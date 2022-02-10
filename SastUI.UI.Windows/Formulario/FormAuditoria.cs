using SastUI.UI.Windows.ControladorAplicacion;
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
    public partial class FormAuditoria : Form
    {
        public FormAuditoria(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void ListarAuditoria()
        {
            dgvAuditoria.DataSource = new AuditoriaControlador().ObtenerAuditorias();
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            ListarAuditoria();
            //Llenar combo busqueda
            DataTable dtBusqueda = new DataTable();
            dtBusqueda.Columns.Add("Id");
            dtBusqueda.Columns.Add("Nombre");

            dtBusqueda.Rows.Add(0, "Buscar");
            dtBusqueda.Rows.Add(1, "Usuario");

            cmbBusqueda.Items.Clear();
            cmbBusqueda.DataSource = dtBusqueda;
            cmbBusqueda.ValueMember = "Id";
            cmbBusqueda.DisplayMember = "Nombre";
        }

        private void pct_cerrar_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
            menu.Show();
        }

        private void cmbBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idBusqueda = int.Parse(cmbBusqueda.SelectedValue.ToString());
            if (idBusqueda > 0)
            {
                txtInfo.Visible = true;
                btnBuscar.Visible = true;
                btnCancelar.Visible = true;
            }
            else
            {
                txtInfo.Visible = false;
                btnBuscar.Visible = false;
                btnCancelar.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbBusqueda.SelectedValue.ToString();
            var info = txtInfo.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                var usuario = new UsuarioControlador().BuscarUsuarioPorCriterio(1, info).FirstOrDefault();

                if (usuario == null)
                {
                    MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ListarAuditoria();
                    txtInfo.Text = "";
                }
                else
                {
                    info = usuario.Id.ToString();
                    var lista = new AuditoriaControlador().BuscarAuditoriaPorCriterio(int.Parse(tipoBusqueda), info);
                    if (lista != null)
                    {
                        dgvAuditoria.DataSource = lista;
                    }
                    else
                    {
                        MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbBusqueda.SelectedIndex = 0;
                        txtInfo.Text = "";
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtInfo.Visible = false;
            btnBuscar.Visible = false;
            btnBuscar.Visible = false;
            cmbBusqueda.SelectedIndex = 0;
            ListarAuditoria();
        }
    }
}
