using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IEquipoRepositorio : IBaseRepositorio<TBL_EQUIPO>
    {
        bool DesactivarEquipo(int idEquipo);

        IEnumerable<TBL_EQUIPO> ListarEquiposActivos();

        int GuardarConId(TBL_EQUIPO equipo);

        bool ValidarDuplicado(string serie);

        IEnumerable<TBL_EQUIPO> BuscarEquipoPorCriterio(int tipoBusqueda, string info);
    }
}
