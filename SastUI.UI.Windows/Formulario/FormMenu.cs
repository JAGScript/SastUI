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
        public FormMenu(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = "";
            txtNombreUsuario.Text = "";
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void btnAbrirUsuarios_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormUsuario usuario = new FormUsuario(idUsuario, nombreUsuario);
            usuario.TopLevel = false;
            pnlContenido.Controls.Add(usuario);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            usuario.Show();
        }

        private void btnAbrirPerfiles_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormPerfil perfil = new FormPerfil(idUsuario, nombreUsuario);
            perfil.TopLevel = false;
            pnlContenido.Controls.Add(perfil);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            perfil.Show();
        }

        private void btnAbrirClientes_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormCliente cliente = new FormCliente(idUsuario, nombreUsuario);
            cliente.TopLevel = false;
            pnlContenido.Controls.Add(cliente);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            cliente.Show();
        }

        private void btnAbrirTiposTelefonos_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormTipoTelefono tipo = new FormTipoTelefono(idUsuario, nombreUsuario);
            tipo.TopLevel = false;
            pnlContenido.Controls.Add(tipo);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            tipo.Show();
        }

        private void btnAbrirTelefonos_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormTelefono telefono = new FormTelefono(idUsuario, nombreUsuario);
            telefono.TopLevel = false;
            pnlContenido.Controls.Add(telefono);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            telefono.Show();
        }

        private void btnAbrirFicha_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormConstruccion constr = new FormConstruccion(idUsuario, nombreUsuario);
            constr.TopLevel = false;
            pnlContenido.Controls.Add(constr);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            constr.Show();
        }

        private void btnAbrirEquipos_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormConstruccion constr = new FormConstruccion(idUsuario, nombreUsuario);
            constr.TopLevel = false;
            pnlContenido.Controls.Add(constr);
            pnlContenido.Visible = true;
            pnlContenido.BringToFront();
            constr.Show();
        }
    }
}
