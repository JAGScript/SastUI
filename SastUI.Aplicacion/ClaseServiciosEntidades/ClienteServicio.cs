using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using SastUI.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Aplicacion.ClaseServiciosEntidades
{
    public class ClienteServicio
    {
        readonly IClienteRepositorio clienteRepositorio;

        public ClienteServicio()
        {
            clienteRepositorio = new ClienteRepositorio();
        }

        public void InsertarCliente(TBL_CLIENTE datosCliente)
        {
            try
            {
                clienteRepositorio.Guardar(datosCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarCliente(TBL_CLIENTE datosCliente)
        {
            try
            {
                clienteRepositorio.Modificar(datosCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_CLIENTE> ListarClientes()
        {
            try
            {
                return clienteRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                clienteRepositorio.Borrar(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_CLIENTE ObtenerCliente(int idCliente)
        {
            try
            {
                return clienteRepositorio.Obtener(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarCliente(int idCliente)
        {
            try
            {
                return clienteRepositorio.DesactivarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_CLIENTE BuscarClientePorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return clienteRepositorio.BuscarClientePorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public int GuardarConId(TBL_CLIENTE cliente)
        {
            try
            {
                return clienteRepositorio.GuardarConId(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
