using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IMarcaRepositorio : IBaseRepositorio<TBL_MARCA>
    {
        IEnumerable<TBL_MARCA> ListarMarcasActivas();

        bool DesactivarMarca(int idMarca);
    }
}
