using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IPerfilRepositorio : IBaseRepositorio<TBL_PERFIL>
    {
        IEnumerable<TBL_PERFIL> ListarPerfilesActivos();

        bool DesactivarPerfil(int idPerfil);

        bool ValidarDuplicado(string perfil);

        IEnumerable<TBL_PERFIL> BuscarPerfilPorCriterio(int tipoBusqueda, string info);
    }
}
