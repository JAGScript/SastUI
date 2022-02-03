using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class AuditoriaVistaModelo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string Valor { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
