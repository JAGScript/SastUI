using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class ClienteRepositorio : BaseRepositorio<TBL_CLIENTE>, IClienteRepositorio
    {
        public bool DesactivarCliente(int idCliente)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from cliente in contexto.TBL_CLIENTE
                                 where cliente.cl_id == idCliente
                                 select cliente).FirstOrDefault();

                    query.cl_estado = 2;
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactviar cliente, ", ex);
            }
        }

        public IEnumerable<TBL_CLIENTE> BuscarClientePorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_CLIENTE> cliente = new List<TBL_CLIENTE>();
            if (tipoBusqueda == 1)//Por cedula
            {
                cliente = BuscarPorCedula(info);
            }
            else if (tipoBusqueda == 2)//Por Nombre
            {
                cliente = BuscarPorNombre(info);
            }

            return cliente;
        }

        public int GuardarConId (TBL_CLIENTE cliente)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    context.Set<TBL_CLIENTE>().Add(cliente);
                    context.SaveChanges();

                    return cliente.cl_id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo guardar el cliente" + ex.Message);
            }
        }

        public bool ValidarDuplicados(string cedula)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from cliente1 in contexto.TBL_CLIENTE
                                 where cliente1.cl_identificacion == cedula
                                 select cliente1;

                    if (query.ToList().Count >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cliente, ", ex);
            }
        }
        #region Métodos privados

        private IEnumerable<TBL_CLIENTE> BuscarPorCedula(string cedula)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from cliente1 in contexto.TBL_CLIENTE
                                 where cliente1.cl_identificacion == cedula
                                 select cliente1;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cliente, ", ex);
            }
        }

        private IEnumerable<TBL_CLIENTE> BuscarPorNombre(string nombre)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = from cliente2 in contexto.TBL_CLIENTE
                                where cliente2.cl_nombre.Contains(nombre)
                                select cliente2;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cliente, ", ex);
            }
        }

        #endregion
    }
}
