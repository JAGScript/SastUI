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
    public partial class FormFicha : Form
    {
        bool equipoNuevo = false;

        public FormFicha(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        public void CargarTiposTelefono()
        {
            var tiposActivos = new TipoTelefonoControlador().ListarTiposActivos();
            cmbNuevoTipo.DataSource = tiposActivos;
            cmbNuevoTipo.ValueMember = "Id";
            cmbNuevoTipo.DisplayMember = "Descripcion";
        }

        public void ListarEquipos()
        {
            dgvEquiposExistentes.DataSource = new EquipoControlador().ListarEquiposActivos();
            dgvEquiposExistentes.Columns["TipoId"].Visible = false;
            dgvEquiposExistentes.Columns["MarcaId"].Visible = false;
            dgvEquiposExistentes.Columns["ModeloId"].Visible = false;
            dgvEquiposExistentes.Columns["Observaciones"].Visible = false;
            dgvEquiposExistentes.Columns["Estado"].Visible = false;
            dgvEquiposExistentes.Columns["DescripcionEstado"].Visible = false;
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

        public void Limpiar()
        {
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtFecha.Text = "";
            txtSecuencial.Text = "";

            dgvEquiposDetalle.Rows.Clear();

            pnlEquiposExistentes.Visible = false;
            pnlEquiposExistentes.SendToBack();
            btnAbrirEquiposExistentes.Enabled = true;
            btnAbrirEquipoNuevo.Enabled = true;

            pnlNuevoEquipo.Visible = false;
            pnlNuevoEquipo.SendToBack();
            btnAbrirEquiposExistentes.Enabled = true;
            btnAbrirEquipoNuevo.Enabled = true;
            equipoNuevo = false;

            ListarEquipos();
            int numeroFichas = 0;

            numeroFichas = new CabeceraFichaControlador().ObtenerCabeceraFichas().ToList().Count + 1;
            txtSecuencial.Text = string.Format("{0:000000}", numeroFichas);
        }

        private void txtFecha_Click(object sender, EventArgs e)
        {
            dtpFecha.Visible = true;
            dtpFecha.Focus();
            SendKeys.Send("{F4}");
        }

        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            txtFecha.Text = dtpFecha.Value.ToShortDateString();
            dtpFecha.Visible = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            pnlBusquedaCliente.Visible = true;
            pnlBusquedaCliente.BringToFront();
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

        public void CerrarNuevoCliente()
        {
            pnlNuevoCliente.Visible = false;
            cmbNuevoTipo.SelectedIndex = 0;
            txtNuevaIdentificacion.Text = "";
            txtNuevoNombre.Text = "";
            txtNuevoCorreo.Text = "";
            txtNuevoNumero.Text = "";
            pnlBusquedaCliente.SendToBack();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            pnlNuevoCliente.Visible = true;
            pnlNuevoCliente.BringToFront();
        }

        private void btnGuardarNuevoCliente_Click(object sender, EventArgs e)
        {
            int? idCliente = 0;
            ClienteVistaModelo cliente = new ClienteVistaModelo();
            cliente.Identificacion = txtNuevaIdentificacion.Text;
            cliente.Nombre = txtNuevoNombre.Text.ToUpper().Trim();
            cliente.Correo = txtNuevoCorreo.Text.ToLower().Trim();
            cliente.Estado = 1;

            idCliente = new ClienteControlador().GuardarConId(cliente);

            if(idCliente == null && idCliente <= 0)
                MessageBox.Show("Error al guardar cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TelefonoVistaModelo telefono = new TelefonoVistaModelo();
                telefono.ClienteId = idCliente.GetValueOrDefault();
                telefono.Numero = txtNuevoNumero.Text.Trim();
                telefono.IdTipoTelefono = int.Parse(cmbNuevoTipo.SelectedValue.ToString());
                telefono.Estado = 1;
                if (!new TelefonoControlador().InsertarTelefono(telefono))
                    MessageBox.Show("No es posible guardar el registro!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtIdCliente.Text = idCliente.ToString();
            txtNombreCliente.Text = cliente.Nombre;
            MessageBox.Show("Cliente Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            CerrarNuevoCliente();
        }

        private void btnCancelarNuevoCliente_Click(object sender, EventArgs e)
        {
            CerrarNuevoCliente();
        }

        private void FormFicha_Load(object sender, EventArgs e)
        {
            CargarTiposTelefono();
            ListarEquipos();
            CargarTipoEquipo();
            CargarMarcas();
            CargarModelos();

            int numeroFichas = 0;

            numeroFichas = new CabeceraFichaControlador().ObtenerCabeceraFichas().ToList().Count + 1;
            txtSecuencial.Text = string.Format("{0:000000}", numeroFichas);

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

            int equiposRegistrados = new EquipoControlador().ListarEquiposActivos().ToList().Count;
            if (equiposRegistrados <= 0)
                btnAbrirEquiposExistentes.Enabled = false;

            dgvEquiposDetalle.Columns.Add("EquipoId", "EquipoId");
            dgvEquiposDetalle.Columns.Add("TipoId", "TipoId");
            dgvEquiposDetalle.Columns.Add("DescripcionTipo", "DescripcionTipo");
            dgvEquiposDetalle.Columns.Add("MarcaId", "MarcaId");
            dgvEquiposDetalle.Columns.Add("DescripcionMarca", "DescripcionMarca");
            dgvEquiposDetalle.Columns.Add("ModeloId", "ModeloId");
            dgvEquiposDetalle.Columns.Add("DescripcionModelo", "DescripcionModelo");
            dgvEquiposDetalle.Columns.Add("Serie", "Serie");
            dgvEquiposDetalle.Columns.Add("SistemaOperativo", "SistemaOperativo");
            dgvEquiposDetalle.Columns.Add("Caracteristicas", "Caracteristicas");
            dgvEquiposDetalle.Columns.Add("Observaciones", "Observaciones");
        }

        private void txtNuevoNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarNumeros(e);
        }

        private void txtNuevaIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarNumeros(e);
        }

        private void txtNuevaIdentificacion_Leave(object sender, EventArgs e)
        {
            string cedula = txtNuevaIdentificacion.Text.ToString();
            if (!new SeguridadRepositorio().ValidarCedula(cedula))
            {
                MessageBox.Show("La cédula ingresada es incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNuevaIdentificacion.Text = "";
            }
        }

        private void txtNuevoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new SeguridadRepositorio().ValidarLetras(e);
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

        private void btnAbrirEquiposExistentes_Click(object sender, EventArgs e)
        {
            pnlEquiposExistentes.Visible = true;
            pnlEquiposExistentes.BringToFront();
            btnAbrirEquiposExistentes.Enabled = false;
            btnAbrirEquipoNuevo.Enabled = false;
            equipoNuevo = false;
        }

        private void btnAbrirEquipoNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoEquipo.Visible = true;
            pnlNuevoEquipo.BringToFront();
            btnAbrirEquiposExistentes.Enabled = false;
            btnAbrirEquipoNuevo.Enabled = false;
            equipoNuevo = true;
        }

        private void pctCerrarEquiposExistentes_Click(object sender, EventArgs e)
        {
            pnlEquiposExistentes.Visible = false;
            pnlEquiposExistentes.SendToBack();
            btnAbrirEquiposExistentes.Enabled = true;
            btnAbrirEquipoNuevo.Enabled = true;
            equipoNuevo = false;
        }

        private void pctCerrarNuevoEquipo_Click(object sender, EventArgs e)
        {
            pnlNuevoEquipo.Visible = false;
            pnlNuevoEquipo.SendToBack();
            btnAbrirEquiposExistentes.Enabled = true;
            btnAbrirEquipoNuevo.Enabled = true;
            equipoNuevo = false;
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

        private void btnGuardarTipo_Click_1(object sender, EventArgs e)
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

        private void btnCancelarTipo_Click_1(object sender, EventArgs e)
        {
            pnlTipoEquipo.Visible = false;
            txtNuevoTipo.Text = "";
            pnlTipoEquipo.SendToBack();
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

        private void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = false;
            txtNuevaMarca.Text = "";
            pnlMarca.SendToBack();
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

        private void btnCancelarModelo_Click(object sender, EventArgs e)
        {
            pnlModelo.Visible = false;
            txtNuevoModelo.Text = "";
            pnlModelo.SendToBack();
        }

        private void btnAddFila_Click(object sender, EventArgs e)
        {
            if (equipoNuevo)
            {
                int idTipo = int.Parse(cmbTipoEquipo.SelectedValue.ToString());
                string nombreTipo = cmbTipoEquipo.Text.ToString();
                int idMarca = int.Parse(cmbMarcas.SelectedValue.ToString());
                string nombreMarca = cmbMarcas.Text.ToString();
                int idModelo = int.Parse(cmbModelos.SelectedValue.ToString());
                string nombreModelo = cmbModelos.Text.ToString();
                string serie = txtSerie.Text.ToUpper().Trim();
                string so = txtSO.Text.ToUpper().Trim();
                string caracteristicas = txtCaracteristicas.Text.ToUpper().Trim();
                string observaciones = txtObservaciones.Text.ToUpper().Trim();

                if (idTipo <= 0 || idMarca <= 0 || idModelo <= 0 || string.IsNullOrEmpty(serie) || string.IsNullOrEmpty(so)
                    || string.IsNullOrEmpty(caracteristicas) || string.IsNullOrEmpty(observaciones))
                    MessageBox.Show("Existen campos vacios!, llenelos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgvEquiposDetalle.Rows.Add(false, 0, idTipo, nombreTipo, idMarca, nombreMarca, idModelo, nombreModelo,
                        serie, so, caracteristicas, observaciones);

                    cmbTipoEquipo.SelectedIndex = 0;
                    cmbMarcas.SelectedIndex = 0;
                    cmbModelos.SelectedIndex = 0;
                    txtSerie.Text = "";
                    txtSO.Text = "";
                    txtCaracteristicas.Text = "";
                    txtObservaciones.Text = "";
                }
            }
            else
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvEquiposExistentes.Rows)
                {
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["chkExistente"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(cellSelecion.Value))
                    {
                        rowSelected.Add(row);
                    }
                }

                foreach (DataGridViewRow row in rowSelected)
                {
                    dgvEquiposDetalle.Rows.Add(new object[] {false,
                                            row.Cells["Id"].Value,
                                            row.Cells["TipoId"].Value,
                                            row.Cells["DescripcionTipo"].Value,
                                            row.Cells["MarcaId"].Value,
                                            row.Cells["DescripcionMarca"].Value,
                                            row.Cells["ModeloId"].Value,
                                            row.Cells["DescripcionModelo"].Value,
                                            row.Cells["Serie"].Value,
                                            row.Cells["SistemaOperativo"].Value,
                                            row.Cells["Caracteristicas"].Value,
                                            row.Cells["Observaciones"].Value});
                    //dgvEquiposExistentes.Rows.Remove(row);
                }
            }
        }

        private void btnRemoveFila_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgvEquiposDetalle.Rows)
            {
                DataGridViewCheckBoxCell cellSelecion = row.Cells["chkDetalle"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }
            }

            if (rowSelected.Count > 0)
            {
                foreach (DataGridViewRow row in rowSelected)
                {
                    dgvEquiposDetalle.Rows.Remove(row);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var idCliente = int.Parse(txtIdCliente.Text);
            var fecha = txtFecha.Text;
            var secuencial = txtSecuencial.Text;
            int idUsuario = int.Parse(txtIdUsuario.Text);
            List<DataGridViewRow> rowInsertada = new List<DataGridViewRow>();
            int idCabecera = 0;

            foreach (DataGridViewRow row in dgvEquiposDetalle.Rows)
            {
                if (row.Cells["EquipoId"].Value != null)
                    rowInsertada.Add(row);
            }

            if (idCliente <= 0 || string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(secuencial) || rowInsertada.Count <= 0)
                MessageBox.Show("Existen campos vacios!, llenelos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                CabeceraFichaVistaModelo cabecera = new CabeceraFichaVistaModelo();
                cabecera.IdCliente = idCliente;
                cabecera.IdUsuario = idUsuario;
                cabecera.Fecha = Convert.ToDateTime(fecha);
                cabecera.Codigo = secuencial;
                cabecera.Estado = 1;

                idCabecera = new CabeceraFichaControlador().GuardarConId(cabecera);

                foreach (DataGridViewRow row in rowInsertada)
                {
                    int idEquipoRegistrado = 0;
                    int idEquipo = int.Parse(row.Cells["EquipoId"].Value.ToString());

                    if (idEquipo == 0)
                    {
                        EquipoVistaModelo equipo = new EquipoVistaModelo();
                        equipo.TipoId = int.Parse(row.Cells["TipoId"].Value.ToString());
                        equipo.MarcaId = int.Parse(row.Cells["MarcaId"].Value.ToString());
                        equipo.ModeloId = int.Parse(row.Cells["ModeloId"].Value.ToString());
                        equipo.Serie = row.Cells["Serie"].Value.ToString();
                        equipo.SistemaOperativo = row.Cells["SistemaOperativo"].Value.ToString();
                        equipo.Caracteristicas = row.Cells["Caracteristicas"].Value.ToString();
                        equipo.Observaciones = row.Cells["Observaciones"].Value.ToString();
                        equipo.Estado = 1;

                        idEquipoRegistrado = new EquipoControlador().GuardarConId(equipo);
                    }
                    else
                        idEquipoRegistrado = idEquipo;

                    DetalleFichaVistaModelo detalle = new DetalleFichaVistaModelo();
                    detalle.CabeceraFichaId = idCabecera;
                    detalle.EquipoId = idEquipoRegistrado;
                    detalle.Observaciones = "SN";
                    detalle.Proceso = "INGRESADO";
                    detalle.Estado = "INGRESADO";

                    new DetalleFichaControlador().InsertarDetalleFicha(detalle);
                }

                MessageBox.Show("Ficha ingresada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNuevoCorreo_Leave(object sender, EventArgs e)
        {
            string correo = txtNuevoCorreo.Text.ToString();
            if (!new SeguridadRepositorio().ValidarEmail(correo))
            {
                MessageBox.Show("El correo ingresado es incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNuevoCorreo.Text = "";
            }
        }
    }
}
