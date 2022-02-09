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
    public class TelefonoServicio
    {
        readonly ITelefonoRepositorio telefonoRepositorio;

        public TelefonoServicio()
        {
            telefonoRepositorio = new TelefonoRepositorio();
        }

        public void InsertarTelefono(TBL_TELEFONO datosTelefono)
        {
            try
            {
                telefonoRepositorio.Guardar(datosTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarTelefono(TBL_TELEFONO datosTelefono)
        {
            try
            {
                telefonoRepositorio.Modificar(datosTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TELEFONO> ListarTelefonos()
        {
            try
            {
                return telefonoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarTelefono(int idTelefono)
        {
            try
            {
                telefonoRepositorio.Borrar(idTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_TELEFONO ObtenerTelefono(int idTelefono)
        {
            try
            {
                return telefonoRepositorio.Obtener(idTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TELEFONO> ListarTelefonosCliente(int idCliente)
        {
            try
            {
                return telefonoRepositorio.ListarTelefonosCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarTelefono(int idTelefono)
        {
            try
            {
                return telefonoRepositorio.DesactivarTelefono(idTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TELEFONO> BuscarTelefonoPorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return telefonoRepositorio.BuscarTelefonoPorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool ValidarDuplicados(string numero, int idCliente)
        {
            try
            {
                return telefonoRepositorio.ValidarDuplicados(numero, idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
