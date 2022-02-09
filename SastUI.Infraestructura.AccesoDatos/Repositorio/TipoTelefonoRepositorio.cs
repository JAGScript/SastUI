using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class TipoTelefonoRepositorio : BaseRepositorio<TBL_TIPO_TELEFONO>, ITipoTelefonoRepositorio
    {
        public IEnumerable<TBL_TIPO_TELEFONO> ListarTiposActivos()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_TELEFONO
                                where tipo.tt_estado == 1
                                select tipo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo telefono, ", ex);
            }
        }

        public bool DesactivarTipoTelefono(int idTipo)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from tipo in contexto.TBL_TIPO_TELEFONO
                                 where tipo.tt_id == idTipo
                                 select tipo).FirstOrDefault();

                    query.tt_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar tipo teléfono, ", ex);
            }
        }

        public bool ValidarDuplicado(string descripcion)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_TELEFONO
                                where tipo.tt_descripcion == descripcion
                                select tipo;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo telefono, ", ex);
            }
        }

        public IEnumerable<TBL_TIPO_TELEFONO> BuscarTipoTelefonoPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_TIPO_TELEFONO> tipo = new List<TBL_TIPO_TELEFONO>();
            if (tipoBusqueda == 1)//Por descripcion
            {
                tipo = BuscarPorDescripcion(info);
            }

            return tipo;
        }

        private IEnumerable<TBL_TIPO_TELEFONO> BuscarPorDescripcion(string info)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from tipo in contexto.TBL_TIPO_TELEFONO
                                where tipo.tt_descripcion == info
                                select tipo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar tipo telefono, ", ex);
            }
        }
    }
}
