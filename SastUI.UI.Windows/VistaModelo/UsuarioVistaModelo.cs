using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.VistaModelo
{
    public class UsuarioVistaModelo
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public string DescripcionPerfil { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Identificacion { get; set; }
        public int Estado { get; set; }
        public string EstadoDescripcion { get; set; }
    }
}
