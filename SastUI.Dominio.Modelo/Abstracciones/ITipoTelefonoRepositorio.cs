using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface ITipoTelefonoRepositorio : IBaseRepositorio<TBL_TIPO_TELEFONO>
    {
        IEnumerable<TBL_TIPO_TELEFONO> ListarTiposActivos();

        bool DesactivarTipoTelefono(int idTipo);
    }
}
