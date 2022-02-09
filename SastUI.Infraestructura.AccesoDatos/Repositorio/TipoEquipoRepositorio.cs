using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class TipoEquipoRepositorio : BaseRepositorio<TBL_TIPO_EQUIPO>, ITipoEquipoRepositorio
    {
        public IEnumerable<TBL_TIPO_EQUIPO> ListarTiposActivos()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_EQUIPO
                                where tipo.tp_estado == 1
                                select tipo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo equipo, ", ex);
            }
        }

        public bool DesactivarTipoEquipo(int idTipo)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from tipo in contexto.TBL_TIPO_EQUIPO
                                 where tipo.tp_id == idTipo
                                 select tipo).FirstOrDefault();

                    query.tp_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar tipo equipo, ", ex);
            }
        }

        public bool ValidarDuplicado(string tipoEquipo)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_EQUIPO
                                where tipo.tp_descripcion == tipoEquipo
                                select tipo;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo equipo, ", ex);
            }
        }

        public IEnumerable<TBL_TIPO_EQUIPO> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_TIPO_EQUIPO> tipo = new List<TBL_TIPO_EQUIPO>();
            if (tipoBusqueda == 1)//Por cedula
            {
                tipo = BuscarPorDescripcion(info);
            }

            return tipo;
        }

        private IEnumerable<TBL_TIPO_EQUIPO> BuscarPorDescripcion(string info)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_EQUIPO
                                where tipo.tp_descripcion == info
                                select tipo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo equipo, ", ex);
            }
        }
    }
}
