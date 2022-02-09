using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class ModeloRepositorio : BaseRepositorio<TBL_MODELO>, IModeloRepositorio
    {
        public IEnumerable<TBL_MODELO> ListarModelosActivos(int idMarca)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from modelo in contexto.TBL_MODELO
                                where modelo.mo_estado == 1
                                && modelo.ma_id == idMarca
                                select modelo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar modelo, ", ex);
            }
        }

        public bool DesactivarModelo(int idModelo)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from modelo in contexto.TBL_MODELO
                                 where modelo.mo_id == idModelo
                                 select modelo).FirstOrDefault();

                    query.mo_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar marca, ", ex);
            }
        }

        public bool ValidarDuplicado(string modeloDes, int idMarca)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from modelo in contexto.TBL_MODELO
                                where modelo.mo_descripcion == modeloDes
                                && modelo.ma_id == idMarca
                                select modelo;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar modelo, ", ex);
            }
        }

        public IEnumerable<TBL_MODELO> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_MODELO> marca = new List<TBL_MODELO>();
            if (tipoBusqueda == 1)//Por descripcion
            {
                marca = BuscarPorDescripcion(info);
            }

            return marca;
        }

        private IEnumerable<TBL_MODELO> BuscarPorDescripcion(string info)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from modelo in contexto.TBL_MODELO
                                where modelo.mo_descripcion == info
                                select modelo;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar marca, ", ex);
            }
        }
    }
}
