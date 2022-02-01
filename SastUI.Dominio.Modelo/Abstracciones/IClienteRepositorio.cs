using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IClienteRepositorio : IBaseRepositorio<TBL_CLIENTE>
    {
        bool DesactivarCliente(int idCliente);

        TBL_CLIENTE BuscarClientePorCriterio(int tipoBusqueda, string info);

        int GuardarConId(TBL_CLIENTE cliente);
    }
}
