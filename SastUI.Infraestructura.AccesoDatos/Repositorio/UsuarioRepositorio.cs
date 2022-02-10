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

        public IEnumerable<TBL_USUARIO> BuscarUsuarioPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_USUARIO> usuario = new List<TBL_USUARIO>();
            if (tipoBusqueda == 1)//Por login
            {
                usuario = BuscarPorLogin(info);
            }
            else if (tipoBusqueda == 2)//Por cédula
            {
                usuario = BuscarPorCedula(info);
            }

            return usuario;
        }

        public bool ValidarDuplicado(string login)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from usuario in contexto.TBL_USUARIO
                                where usuario.us_login == login
                                select usuario;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario, ", ex);
            }
        }

        private IEnumerable<TBL_USUARIO> BuscarPorLogin(string login)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from usuario in contexto.TBL_USUARIO
                                where usuario.us_login == login
                                select usuario;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario, ", ex);
            }
        }

        private IEnumerable<TBL_USUARIO> BuscarPorCedula(string cedula)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from usuario in contexto.TBL_USUARIO
                                where usuario.us_identificacion == cedula
                                select usuario;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario, ", ex);
            }
        }
    }
}
