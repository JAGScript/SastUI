using SastUI.Dominio.Modelo.Entidades;
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
using static SastUI.Infraestructura.CrossCutting.SeguridadRepositorio;

namespace SastUI.UI.Windows.Formulario
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var user = txtUsuario.Text.ToLower();
            var pass = txtUsuario.Text.ToLower();
            pass = Encrypt.Encriptar(pass);

            var usuario = new UsuarioControlador().ValidarUsuario(user, pass);

            if (!string.IsNullOrEmpty(usuario.us_login))
            {
                DialogResult result = MessageBox.Show("Bienvenido! " + usuario.us_nombre, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    FormMenu menu = new FormMenu(usuario.us_id, usuario.us_nombre);
                    menu.TopLevel = false;
                    pnlContenido.Controls.Add(menu);
                    pnlContenido.Visible = true;
                    pnlContenido.BringToFront();
                    menu.Show();
                }
                else
                {
                    txtUsuario.Text = "";
                    txtPass.Text = "";
                }
            }
            else
            {
                txtUsuario.Text = "";
                txtPass.Text = "";
                MessageBox.Show("Datos ingresados incorrectos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
