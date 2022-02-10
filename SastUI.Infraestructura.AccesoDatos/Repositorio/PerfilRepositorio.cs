using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class PerfilRepositorio : BaseRepositorio<TBL_PERFIL>, IPerfilRepositorio
    {
        public IEnumerable<TBL_PERFIL> ListarPerfilesActivos()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from perfil in contexto.TBL_PERFIL
                                where perfil.pe_estado == 1
                                select perfil;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar perfil, ", ex);
            }
        }

        public bool DesactivarPerfil(int idPerfil)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from perfil in contexto.TBL_PERFIL
                                 where perfil.pe_id == idPerfil
                                 select perfil).FirstOrDefault();

                    query.pe_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar perfil, ", ex);
            }
        }

        public bool ValidarDuplicado(string perfilDes)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from perfil in contexto.TBL_PERFIL
                                where perfil.pe_nombre == perfilDes
                                select perfil;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar perfil, ", ex);
            }
        }

        public IEnumerable<TBL_PERFIL> BuscarPerfilPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_PERFIL> perfil = new List<TBL_PERFIL>();
            if (tipoBusqueda == 1)//Por descripcion
            {
                perfil = BuscarPorDescripcion(info);
            }

            return perfil;
        }

        private IEnumerable<TBL_PERFIL> BuscarPorDescripcion(string descripcion)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from perfil in contexto.TBL_PERFIL
                                where perfil.pe_nombre == descripcion
                                select perfil;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar perfil, ", ex);
            }
        }
    }
}
