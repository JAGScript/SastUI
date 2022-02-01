using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class EquipoRepositorio : BaseRepositorio<TBL_EQUIPO>, IEquipoRepositorio
    {
        public bool DesactivarEquipo(int idEquipo)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from equipo in contexto.TBL_EQUIPO
                                 where equipo.eq_estado == idEquipo
                                 select equipo).FirstOrDefault();

                    query.eq_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar equipo, ", ex);
            }
        }

        public IEnumerable<TBL_EQUIPO> ListarEquiposActivos()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from equipo in contexto.TBL_EQUIPO
                                where equipo.eq_estado == 1
                                select equipo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar equipo, ", ex);
            }
        }
    }
}
