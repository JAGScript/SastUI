﻿using SastUI.Aplicacion.ClaseServiciosEntidades;
using SastUI.Dominio.Modelo.Entidades;
using SastUI.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.ControladorAplicacion
{
    public class ClienteControlador
    {
        public bool InsertarCliente(ClienteVistaModelo clienteView)
        {
            TBL_CLIENTE nuevo = new TBL_CLIENTE();
            try
            {
                nuevo.cl_id = clienteView.Id;
                nuevo.cl_identificacion = clienteView.Identificacion;
                nuevo.cl_nombre = clienteView.Nombre;
                nuevo.cl_correo = clienteView.Correo;
                nuevo.cl_estado = clienteView.Estado;
                new ClienteServicio().InsertarCliente(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarCliente(ClienteVistaModelo clienteView)
        {
            TBL_CLIENTE cliente = new TBL_CLIENTE();
            try
            {
                cliente.cl_id = clienteView.Id;
                cliente.cl_identificacion = clienteView.Identificacion;
                cliente.cl_nombre = clienteView.Nombre;
                cliente.cl_correo = clienteView.Correo;
                cliente.cl_estado = clienteView.Estado;
                new ClienteServicio().ModificarCliente(cliente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<ClienteVistaModelo> ObtenerClientes()
        {
            var lista = new ClienteServicio().ListarClientes();
            List<ClienteVistaModelo> clienteView = new List<ClienteVistaModelo>();

            foreach (TBL_CLIENTE item in lista)
            {
                clienteView.Add(new ClienteVistaModelo
                {
                    Id = item.cl_id,
                    Identificacion = item.cl_identificacion,
                    Nombre = item.cl_nombre,
                    Correo = item.cl_correo,
                    Estado = item.cl_estado,
                    EstadoDescripcion = item.cl_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return clienteView;
        }

        public bool DesactivarCliente(int idCliente)
        {
            try
            {
                return new ClienteServicio().DesactivarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TBL_CLIENTE BuscarClientePorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return new ClienteServicio().BuscarClientePorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}