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
    }
}
