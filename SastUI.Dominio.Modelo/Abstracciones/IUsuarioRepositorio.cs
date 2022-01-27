using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IUsuarioRepositorio : IBaseRepositorio<TBL_USUARIO>
    {
        TBL_USUARIO ValidarUsuario(string strUsuario, string strPass);

        bool DesactivarUsuario(int idUsuario);
    }
}
