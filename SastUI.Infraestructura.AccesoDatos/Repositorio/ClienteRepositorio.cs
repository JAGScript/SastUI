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

        public TBL_CLIENTE BuscarClientePorCriterio(int tipoBusqueda, string info)
        {
            TBL_CLIENTE cliente = new TBL_CLIENTE();
            if (tipoBusqueda == 1)//Por cedula
            {
                cliente = BuscarPorCedula(info);
            }
            else if (tipoBusqueda == 2)//Por Nombre
            {
                cliente =  BuscarPorNombre(info);
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

        #region Métodos privados

        private TBL_CLIENTE BuscarPorCedula(string cedula)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from cliente1 in contexto.TBL_CLIENTE
                                 where cliente1.cl_identificacion == cedula
                                 select cliente1).FirstOrDefault();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cliente, ", ex);
            }
        }

        private TBL_CLIENTE BuscarPorNombre(string nombre)
        {
            try
            {
                using (var contexto = new SASTEntities())
                {
                    var query = (from cliente2 in contexto.TBL_CLIENTE
                                where SqlMethods.Like(cliente2.cl_nombre, "%" + nombre + "%")
                                select cliente2).FirstOrDefault();

                    return query;
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
