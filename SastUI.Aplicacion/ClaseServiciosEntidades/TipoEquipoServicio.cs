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
    public class TipoEquipoServicio
    {
        readonly ITipoEquipoRepositorio tipoEquipoRepositorio;

        public TipoEquipoServicio()
        {
            tipoEquipoRepositorio = new TipoEquipoRepositorio();
        }

        public void InsertarTipoEquipo(TBL_TIPO_EQUIPO datosTipoEquipo)
        {
            try
            {
                tipoEquipoRepositorio.Guardar(datosTipoEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarTipoEquipo(TBL_TIPO_EQUIPO datosTipoEquipo)
        {
            try
            {
                tipoEquipoRepositorio.Modificar(datosTipoEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TIPO_EQUIPO> ListarTipoEquipos()
        {
            try
            {
                return tipoEquipoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarTipoEquipo(int idTipoEquipo)
        {
            try
            {
                tipoEquipoRepositorio.Borrar(idTipoEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_TIPO_EQUIPO ObtenerTipoEquipo(int idTipoEquipo)
        {
            try
            {
                return tipoEquipoRepositorio.Obtener(idTipoEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_TIPO_EQUIPO> ListarTiposActivos()
        {
            try
            {
                return tipoEquipoRepositorio.ListarTiposActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarTipoEquipo(int idTipo)
        {
            try
            {
                return tipoEquipoRepositorio.DesactivarTipoEquipo(idTipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
