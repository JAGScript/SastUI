using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class CabeceraFichaVistaModelo
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }
    }
}
