using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class DetalleFichaVistaModelo
    {
        public int Id { get; set; }
        public int CabeceraFichaId { get; set; }
        public int EquipoId { get; set; }
        public string DescripcionEquipo { get; set; }
        public string Observaciones { get; set; }
        public string Proceso { get; set; }
        public string Estado { get; set; }
        public string DescripcionEstado { get; set; }
    }
}
