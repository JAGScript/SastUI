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
        public IEnumerable<TBL_MODELO> ListarModelosActivos()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from modelo in contexto.TBL_MODELO
                                where modelo.mo_estado == 1
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
    }
}
