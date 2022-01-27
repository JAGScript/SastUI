using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface ITelefonoRepositorio : IBaseRepositorio<TBL_TELEFONO>
    {
        IEnumerable<TBL_TELEFONO> ListarTelefonosCliente(int idCliente);

        bool DesactivarTelefono(int idTelefono);
    }
}
