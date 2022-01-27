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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.TopLevel = false;
            pnlContenido.Controls.Add(formLogin);
            formLogin.Show();
        }
    }
}
