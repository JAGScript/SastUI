using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class CabeceraFichaRepositorio : BaseRepositorio<TBL_CABECERA_FICHA>, ICabeceraFichaRepositorio
    {
        public int GuardarConId(TBL_CABECERA_FICHA cabecera)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    context.Set<TBL_CABECERA_FICHA>().Add(cabecera);
                    context.SaveChanges();

                    return cabecera.cf_id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar la cabecera" + ex.Message);
            }
        }

        public IEnumerable<TBL_CABECERA_FICHA> ListarFichasActivas()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from ficha in contexto.TBL_CABECERA_FICHA
                                where ficha.cf_estado == 1
                                select ficha;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar fichas, ", ex);
            }
        }

        public IEnumerable<TBL_CABECERA_FICHA> BuscarFichasPorCliente(int idCliente)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from ficha in contexto.TBL_CABECERA_FICHA
                                where ficha.cl_id == idCliente
                                select ficha;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar fichas, ", ex);
            }
        }

        public IEnumerable<TBL_CABECERA_FICHA> ListarFichasActivasPorUsuario(int idUsuario)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from ficha in contexto.TBL_CABECERA_FICHA
                                where ficha.cf_estado == 1
                                && ficha.us_id == idUsuario
                                select ficha;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar fichas, ", ex);
            }
        }

        public IEnumerable<TBL_CABECERA_FICHA> BuscarFichasPorCliente(int idCliente, int idUsuario)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from ficha in contexto.TBL_CABECERA_FICHA
                                where ficha.cl_id == idCliente
                                && ficha.us_id == idUsuario
                                select ficha;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar fichas, ", ex);
            }
        }
    }
}
