using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class DetalleFichaRepositorio : BaseRepositorio<TBL_DETALLE_FICHA>, IDetalleFichaRepositorio
    {
        public IEnumerable<TBL_DETALLE_FICHA> BuscarDetallePorIdCabecera(int idCabecera)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from detalle in contexto.TBL_DETALLE_FICHA
                                where detalle.cf_id == idCabecera
                                select detalle;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar detalle de ficha, ", ex);
            }
        }
    }
}
