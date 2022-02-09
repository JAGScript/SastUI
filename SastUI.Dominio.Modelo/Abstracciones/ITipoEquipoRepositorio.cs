using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface ITipoEquipoRepositorio : IBaseRepositorio<TBL_TIPO_EQUIPO>
    {
        IEnumerable<TBL_TIPO_EQUIPO> ListarTiposActivos();

        bool DesactivarTipoEquipo(int idTipo);

        bool ValidarDuplicado(string tipoEquipo);

        public IEnumerable<TBL_TIPO_EQUIPO> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info);
    }
}
