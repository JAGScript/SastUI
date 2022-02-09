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

        public int GuardarConId(TBL_EQUIPO equipo)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    context.Set<TBL_EQUIPO>().Add(equipo);
                    context.SaveChanges();

                    return equipo.eq_id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar el equipo" + ex.Message);
            }
        }

        public bool ValidarDuplicado(string serie)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from equipo in contexto.TBL_EQUIPO
                                where equipo.eq_serie == serie
                                select equipo;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar equipo, ", ex);
            }
        }

        public IEnumerable<TBL_EQUIPO> BuscarEquipoPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_EQUIPO> equipo = new List<TBL_EQUIPO>();
            if (tipoBusqueda == 1)//Por serie
            {
                equipo = BuscarPorSerie(info);
            }

            return equipo;
        }

        private IEnumerable<TBL_EQUIPO> BuscarPorSerie(string info)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from equipo in contexto.TBL_EQUIPO
                                where equipo.eq_serie == info
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
