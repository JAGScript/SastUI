using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<TBL_USUARIO>, IUsuarioRepositorio
    {
        public TBL_USUARIO ValidarUsuario(string strUsuario, string strPass)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from usuario in contexto.TBL_USUARIO
                                where usuario.us_login == strUsuario
                                && usuario.us_pass == strPass
                                && usuario.us_estado == 1
                                select usuario;

                    if (query.Count() > 0)
                        return query.FirstOrDefault();
                    else
                        return new TBL_USUARIO();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario, ", ex);
            }
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from usuario in contexto.TBL_USUARIO
                                 where usuario.us_id == idUsuario
                                 select usuario).FirstOrDefault();

                    query.us_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar usuario, ", ex);
            }
        }
    }
}
