using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class MarcaRepositorio : BaseRepositorio<TBL_MARCA>, IMarcaRepositorio
    {
        public IEnumerable<TBL_MARCA> ListarMarcasActivas()
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from marca in contexto.TBL_MARCA
                                where marca.ma_estado == 1
                                select marca;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar marca, ", ex);
            }
        }

        public bool DesactivarMarca(int idMarca)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from marca in contexto.TBL_MARCA
                                 where marca.ma_id == idMarca
                                 select marca).FirstOrDefault();

                    query.ma_estado = 2;
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
