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
    public partial class FormActFicha : Form
    {
        public FormActFicha(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        private void pct_cerrar_Click(object sender, EventArgs e)
        {
            Limpiar();
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario, permisos);
            menu.Show();
        }

        public void ListarFichas()
        {
            dgvListaFichas.DataSource = new CabeceraFichaControlador().ListarFichasActivas();
        }

        public void Limpiar()
        {
            txtNombreCliente.Text = "";
            txtFecha.Text = "";
            txtSecuencial.Text = "";
            txtIdDetalle.Text = "";
            txtIdCabecera.Text = "";
            txtIdEquipo.Text = "";
            txtEquipo.Text = "";
            txtObs.Text = "";
            txtProceso.Text = "";
            txtEstado.Text = "";
            dgvDetalleFicha.Columns.Clear();
        }

        public IEnumerable<DetalleFichaVistaModelo> ListarDetalle(int idCabecera)
        {
            return new DetalleFichaControlador().BuscarDetallePorIdCabecera(idCabecera);
        }

        private void FormActFicha_Load(object sender, EventArgs e)
        {
            ListarFichas();

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
        }

        private void cmbTipoBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idBusqueda = int.Parse(cmbTipoBusqueda.SelectedValue.ToString());
            if (idBusqueda > 0)
            {
                txtInformacion.Visible = true;
                btnBuscar.Visible = true;
            }
            else
            {
                txtInformacion.Visible = false;
                btnBuscar.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tipoBusqueda = cmbTipoBusqueda.SelectedValue.ToString();
            var info = txtInformacion.Text.Trim();

            if (int.Parse(tipoBusqueda) > 0 && !string.IsNullOrEmpty(info))
            {
                var cliente = new ClienteControlador().BuscarClientePorCriterio(int.Parse(tipoBusqueda), info);
                if (cliente != null && !string.IsNullOrEmpty(cliente.ToList()[0].Identificacion))
                {
                    dgvListaFichas.DataSource = new CabeceraFichaControlador().BuscarFichasPorCliente(cliente.ToList()[0].Id);
                }
                else
                {
                    MessageBox.Show("No existen coincidencias con los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTipoBusqueda.SelectedIndex = 0;
                    txtInformacion.Text = "";
                }
            }
        }

        private void dgvListaFichas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvListaFichas.Rows[index];
            txtNombreCliente.Text = seleccionado.Cells[2].Value.ToString();
            txtFecha.Text = seleccionado.Cells[5].Value.ToString();
            txtSecuencial.Text = seleccionado.Cells[6].Value.ToString();

            int idCabecera = int.Parse(seleccionado.Cells[0].Value.ToString());

            dgvDetalleFicha.DataSource = ListarDetalle(idCabecera);
        }

        private void dgvDetalleFicha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow seleccionado = dgvDetalleFicha.Rows[index];
            txtIdDetalle.Text = seleccionado.Cells[0].Value.ToString();
            txtIdCabecera.Text = seleccionado.Cells[1].Value.ToString();
            txtIdEquipo.Text = seleccionado.Cells[2].Value.ToString();
            txtEquipo.Text = seleccionado.Cells[3].Value.ToString();
            txtObs.Text = seleccionado.Cells[4].Value.ToString();
            txtProceso.Text = seleccionado.Cells[5].Value.ToString();
            txtEstado.Text = seleccionado.Cells[6].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var idDetalle = int.Parse(txtIdDetalle.Text);
            var idCabecera = int.Parse(txtIdCabecera.Text);
            var idEquipo = int.Parse(txtIdEquipo.Text);
            var obs = txtObs.Text.Trim().ToUpper();
            var proceso = txtProceso.Text.Trim().ToUpper();
            var estado = txtEstado.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(obs) || string.IsNullOrEmpty(proceso) || string.IsNullOrEmpty(estado))
                MessageBox.Show("Existen campos vacios! llenalos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DetalleFichaVistaModelo detalle = new DetalleFichaVistaModelo();
                detalle.Id = idDetalle;
                detalle.CabeceraFichaId = idCabecera;
                detalle.EquipoId = idEquipo;
                detalle.Observaciones = obs;
                detalle.Proceso = proceso;
                detalle.Estado = estado;

                new DetalleFichaControlador().ActualizarDetalleFicha(detalle);

                //Ingresar auditoria
                DataGridViewRow rowDetalle = new DataGridViewRow();

                foreach (DataGridViewRow row in dgvDetalleFicha.Rows)
                {
                    if (int.Parse(row.Cells["Id"].Value.ToString()) == idDetalle)
                        rowDetalle = row;
                }

                AuditoriaVistaModelo auditoria = new AuditoriaVistaModelo();
                auditoria.IdUsuario = int.Parse(txtIdUsuario.Text);
                auditoria.Modulo = "ACTUALIZAR FICHA";
                auditoria.Accion = "ACTUALIZAR";
                auditoria.Valor = idDetalle.ToString() + "|" + idCabecera.ToString() + "|" + idEquipo.ToString() + "|" + rowDetalle.Cells["Observaciones"].Value.ToString() + "|" + rowDetalle.Cells["Proceso"].Value.ToString() + "|" + rowDetalle.Cells["Estado"].Value.ToString();
                auditoria.Fecha = DateTime.Now;
                new AuditoriaControlador().InsertarAuditoria(auditoria);

                dgvDetalleFicha.DataSource = ListarDetalle(idCabecera);

                txtIdDetalle.Text = "";
                txtIdCabecera.Text = "";
                txtIdEquipo.Text = "";
                txtEquipo.Text = "";
                txtObs.Text = "";
                txtProceso.Text = "";
                txtEstado.Text = "";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
