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
    public partial class FormConstruccion : Form
    {
        public FormConstruccion(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            txtIdUsuario.Text = idUsuario.ToString();
            txtNombreUsuario.Text = nombreUsuario.ToString();
        }

        private void FormConstruccion_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var idUsuario = int.Parse(txtIdUsuario.Text);
            var nombreUsuario = txtNombreUsuario.Text.ToString();
            FormMenu menu = new FormMenu(idUsuario, nombreUsuario);
            menu.Show();
        }
    }
}
