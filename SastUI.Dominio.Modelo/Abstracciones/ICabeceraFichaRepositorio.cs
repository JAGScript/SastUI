using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface ICabeceraFichaRepositorio : IBaseRepositorio<TBL_CABECERA_FICHA>
    {
        int GuardarConId(TBL_CABECERA_FICHA cabecera);

        IEnumerable<TBL_CABECERA_FICHA> ListarFichasActivas();

        IEnumerable<TBL_CABECERA_FICHA> BuscarFichasPorCliente(int idCliente);

        IEnumerable<TBL_CABECERA_FICHA> ListarFichasActivasPorUsuario(int idUsuario);

        IEnumerable<TBL_CABECERA_FICHA> BuscarFichasPorCliente(int idCliente, int idUsuario);
    }
}
