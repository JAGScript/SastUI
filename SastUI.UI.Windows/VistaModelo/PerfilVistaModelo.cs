using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class PerfilVistaModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public int Permisos { get; set; }
    }
}
