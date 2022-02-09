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
    public class TipoTelefonoServicio
    {
        readonly ITipoTelefonoRepositorio tipoTelefonoRepositorio;

        public TipoTelefonoServicio()
        {
            tipoTelefonoRepositorio = new TipoTelefonoRepositorio();
        }

        public void InsertarTipoTelefono(TBL_TIPO_TELEFONO datosTipoTelefono)
        {
            try
            {
                tipoTelefonoRepositorio.Guardar(datosTipoTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarTipoTelefono(TBL_TIPO_TELEFONO datosTipoTelefono)
        {
            try
            {
                tipoTelefonoRepositorio.Modificar(datosTipoTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TIPO_TELEFONO> ListarTipoTelefonos()
        {
            try
            {
                return tipoTelefonoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarTipoTelefono(int idTipoTelefono)
        {
            try
            {
                tipoTelefonoRepositorio.Borrar(idTipoTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_TIPO_TELEFONO ObtenerTipoTelefono(int idTipoTelefono)
        {
            try
            {
                return tipoTelefonoRepositorio.Obtener(idTipoTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TIPO_TELEFONO> ListarTiposActivos()
        {
            try
            {
                return tipoTelefonoRepositorio.ListarTiposActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarTipoTelefono(int idTipo)
        {
            try
            {
                return tipoTelefonoRepositorio.DesactivarTipoTelefono(idTipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool ValidarDuplicado(string descripcion)
        {
            try
            {
                return tipoTelefonoRepositorio.ValidarDuplicado(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TIPO_TELEFONO> BuscarTipoTelefonoPorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return tipoTelefonoRepositorio.BuscarTipoTelefonoPorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
