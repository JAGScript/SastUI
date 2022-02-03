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
    public class EquipoServicio
    {
        readonly IEquipoRepositorio equipoRepositorio;

        public EquipoServicio()
        {
            equipoRepositorio = new EquipoRepositorio();
        }

        public void InsertarEquipo(TBL_EQUIPO datosEquipo)
        {
            try
            {
                equipoRepositorio.Guardar(datosEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarEquipo(TBL_EQUIPO datosEquipo)
        {
            try
            {
                equipoRepositorio.Modificar(datosEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_EQUIPO> ListarEquipos()
        {
            try
            {
                return equipoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarEquipo(int idEquipo)
        {
            try
            {
                equipoRepositorio.Borrar(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_EQUIPO ObtenerEquipo(int idEquipo)
        {
            try
            {
                return equipoRepositorio.Obtener(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarEquipo(int idEquipo)
        {
            try
            {
                return equipoRepositorio.DesactivarEquipo(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_EQUIPO> ListarEquiposActivos()
        {
            try
            {
                return equipoRepositorio.ListarEquiposActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public int GuardarConId(TBL_EQUIPO equipo)
        {
            try
            {
                return equipoRepositorio.GuardarConId(equipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
