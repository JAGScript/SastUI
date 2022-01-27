using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class TelefonoVistaModelo
    {
        public int Id { get; set; }
        public int IdTipoTelefono { get; set; }
        public string DescripcionTipo { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string Numero { get; set; }
        public int Estado { get; set; }
        public string EstadoDescripcion { get; set; }
    }
}
