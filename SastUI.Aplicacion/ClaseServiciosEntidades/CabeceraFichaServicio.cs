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
    public class CabeceraFichaServicio
    {
        readonly ICabeceraFichaRepositorio cabeceraFichaRepositorio;

        public CabeceraFichaServicio()
        {
            cabeceraFichaRepositorio = new CabeceraFichaRepositorio();
        }

        public void InsertarCabeceraFicha(TBL_CABECERA_FICHA datosCabeceraFicha)
        {
            try
            {
                cabeceraFichaRepositorio.Guardar(datosCabeceraFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarCabeceraFicha(TBL_CABECERA_FICHA datosCabeceraFicha)
        {
            try
            {
                cabeceraFichaRepositorio.Modificar(datosCabeceraFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_CABECERA_FICHA> ListarCabeceraFichas()
        {
            try
            {
                return cabeceraFichaRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarCabeceraFicha(int idCabeceraFicha)
        {
            try
            {
                cabeceraFichaRepositorio.Borrar(idCabeceraFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_CABECERA_FICHA ObtenerCabeceraFicha(int idCabeceraFicha)
        {
            try
            {
                return cabeceraFichaRepositorio.Obtener(idCabeceraFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
