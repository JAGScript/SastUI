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
                throw new Exception("Error al consultar telefonos, ", ex);
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

        public IEnumerable<TBL_TELEFONO> BuscarTelefonoPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_TELEFONO> telefono = new List<TBL_TELEFONO>();
            if (tipoBusqueda == 1)//Por cliente
            {
                telefono = BuscarPorCliente(info);
            }
            else if (tipoBusqueda == 2)//Por Numero
            {
                telefono = BuscarPorNumero(info);
            }

            return telefono;
        }

        public bool ValidarDuplicados(string numero, int idCliente)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from telefono in contexto.TBL_TELEFONO
                                where telefono.cl_id == idCliente
                                && telefono.te_numero == numero
                                select telefono;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar telefonos, ", ex);
            }
        }

        private IEnumerable<TBL_TELEFONO> BuscarPorCliente(string id)
        {
            try
            {
                int idCliente = int.Parse(id);
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
                throw new Exception("Error al consultar telefono, ", ex);
            }
        }

        private IEnumerable<TBL_TELEFONO> BuscarPorNumero(string numero)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from telefono in contexto.TBL_TELEFONO
                                where telefono.te_numero == numero
                                select telefono;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar telefono, ", ex);
            }
        }
    }
}
