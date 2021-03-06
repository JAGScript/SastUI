using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IAuditoriaRepositorio : IBaseRepositorio<TBL_AUDITORIA>
    {
        IEnumerable<TBL_AUDITORIA> BuscarAuditoriaPorCriterio(int tipoBusqueda, string info);
    }
}
