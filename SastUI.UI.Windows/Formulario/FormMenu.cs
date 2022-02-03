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
    public partial class FormMenu : Form
    {
        public FormMenu(int idUsuario, string nombreUsuario, int permisos)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
            txtPermisos.Text = permisos.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            int permisos = int.Parse(txtPermisos.Text);
            if (permisos == 0)
            {
                pctUsuarios.Visible = false;
                btnAbrirUsuarios.Visible = false;
                pctPerfiles.Visible = false;
                btnAbrirPerfiles.Visible = false;
            }
            else
            {
                pctUsuarios.Visible = true;
                btnAbrirUsuarios.Visible = true;
                pctPerfiles.Visible = true;
                btnAbrirPerfiles.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtPermisos.Text = "";
            FormIngreso login = new FormIngreso();
            login.Show();
        }

        public void EnConstruccion()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormConstruccion constr = new FormConstruccion(idUsuario, nombreUsuario, permisos);
            constr.TopLevel = false;
            pnlContenido.Controls.Add(constr);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            constr.Show();
        }

        public void AbrirClientes()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormCliente cliente = new FormCliente(idUsuario, nombreUsuario, permisos);
            cliente.TopLevel = false;
            pnlContenido.Controls.Add(cliente);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            cliente.Show();
        }

        public void AbrirTelefonos()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormTelefono telefono = new FormTelefono(idUsuario, nombreUsuario, permisos);
            telefono.TopLevel = false;
            pnlContenido.Controls.Add(telefono);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            telefono.Show();
        }

        public void AbrirTipoTelefono()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormTipoTelefono tipo = new FormTipoTelefono(idUsuario, nombreUsuario, permisos);
            tipo.TopLevel = false;
            pnlContenido.Controls.Add(tipo);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            tipo.Show();
        }

        public void AbrirFicha()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormFicha ficha = new FormFicha(idUsuario, nombreUsuario, permisos);
            ficha.TopLevel = false;
            pnlContenido.Controls.Add(ficha);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            ficha.Show();
        }

        public void AbrirEquipos()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormEquipo equipo = new FormEquipo(idUsuario, nombreUsuario, permisos);
            equipo.TopLevel = false;
            pnlContenido.Controls.Add(equipo);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            equipo.Show();
        }

        public void AbrirTipoEquipo()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormTipoEquipo tipoEquipo = new FormTipoEquipo(idUsuario, nombreUsuario, permisos);
            tipoEquipo.TopLevel = false;
            pnlContenido.Controls.Add(tipoEquipo);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            tipoEquipo.Show();
        }

        public void AbrirMarcas()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormMarca marca = new FormMarca(idUsuario, nombreUsuario, permisos);
            marca.TopLevel = false;
            pnlContenido.Controls.Add(marca);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            marca.Show();
        }

        public void AbrirModelos()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormModelo modelo = new FormModelo(idUsuario, nombreUsuario, permisos);
            modelo.TopLevel = false;
            pnlContenido.Controls.Add(modelo);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            modelo.Show();
        }

        public void AbrirUsuarios()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormUsuario usuario = new FormUsuario(idUsuario, nombreUsuario, permisos);
            usuario.TopLevel = false;
            pnlContenido.Controls.Add(usuario);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            usuario.Show();
        }

        public void AbrirPerfiles()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormPerfil perfil = new FormPerfil(idUsuario, nombreUsuario, permisos);
            perfil.TopLevel = false;
            pnlContenido.Controls.Add(perfil);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            perfil.Show();
        }

        public void AbrirActFicha()
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            var permisos = int.Parse(txtPermisos.Text);
            FormActFicha actFicha = new FormActFicha(idUsuario, nombreUsuario, permisos);
            actFicha.TopLevel = false;
            pnlContenido.Controls.Add(actFicha);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            actFicha.Show();
        }

        private void pctClientes_Click(object sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void btnAbrirClientes_Click(object sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void pctTelefonos_Click(object sender, EventArgs e)
        {
            AbrirTelefonos();
        }

        private void btnAbrirTelefonos_Click(object sender, EventArgs e)
        {
            AbrirTelefonos();
        }

        private void pctTipoTelefono_Click(object sender, EventArgs e)
        {
            AbrirTipoTelefono();
        }

        private void btnAbrirTiposTelefonos_Click(object sender, EventArgs e)
        {
            AbrirTipoTelefono();
        }

        private void pctFicha_Click(object sender, EventArgs e)
        {
            AbrirFicha();
        }

        private void btnAbrirFicha_Click(object sender, EventArgs e)
        {
            AbrirFicha();
        }

        private void pctEquipos_Click(object sender, EventArgs e)
        {
            AbrirEquipos();
        }

        private void btnAbrirEquipos_Click(object sender, EventArgs e)
        {
            AbrirEquipos();
        }

        private void pctTipoEquipo_Click(object sender, EventArgs e)
        {
            AbrirTipoEquipo();
        }

        private void btnAbrirTipoEquipos_Click(object sender, EventArgs e)
        {
            AbrirTipoEquipo();
        }

        private void pctMarcas_Click(object sender, EventArgs e)
        {
            AbrirMarcas();
        }

        private void btnAbrirMarcas_Click(object sender, EventArgs e)
        {
            AbrirMarcas();
        }

        private void pctModelos_Click(object sender, EventArgs e)
        {
            AbrirModelos();
        }

        private void btnAbrirModelos_Click(object sender, EventArgs e)
        {
            AbrirModelos();
        }

        private void pctUsuarios_Click(object sender, EventArgs e)
        {
            AbrirUsuarios();
        }

        private void btnAbrirUsuarios_Click(object sender, EventArgs e)
        {
            AbrirUsuarios();
        }

        private void pctPerfiles_Click(object sender, EventArgs e)
        {
            AbrirPerfiles();
        }

        private void btnAbrirPerfiles_Click(object sender, EventArgs e)
        {
            AbrirPerfiles();
        }

        private void btnAbrirActualizarFicha_Click(object sender, EventArgs e)
        {
            AbrirActFicha();
        }

        private void pctAbrirActualizarFicha_Click(object sender, EventArgs e)
        {
            AbrirActFicha();
        }
    }
}
