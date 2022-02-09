using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IModeloRepositorio : IBaseRepositorio<TBL_MODELO>
    {
        IEnumerable<TBL_MODELO> ListarModelosActivos(int idMarca);

        bool DesactivarModelo(int idModelo);

        bool ValidarDuplicado(string modelo, int idMarca);

        IEnumerable<TBL_MODELO> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info);
    }
}
