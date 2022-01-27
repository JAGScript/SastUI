using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class EquipoVistaModelo
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public string Serie { get; set; }
        public string SistemaOperativo { get; set; }
        public string Caracteristicas { get; set; }
        public string Observaciones { get; set; }
        public int Estado { get; set; }
    }
}
