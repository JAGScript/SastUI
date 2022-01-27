using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class TelefonoRepositorio : BaseRepositorio<TBL_TELEFONO>, ITelefonoRepositorio
    {
        public IEnumerable<TBL_TELEFONO> ListarTelefonosCliente(int idCliente)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from telefono in contexto.TBL_TELEFONO
                                where telefono.cl_id == idCliente
                                select telefono;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar perfil, ", ex);
            }
        }

        public bool DesactivarTelefono(int idTelefono)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from telefono in contexto.TBL_TELEFONO
                                 where telefono.te_id == idTelefono
                                 select telefono).FirstOrDefault();

                    query.te_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar teléfono, ", ex);
            }
        }
    }
}
