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
    }
}
