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
    public class DetalleFichaServicio
    {
        readonly IDetalleFichaRepositorio detalleFichaRepositorio;

        public DetalleFichaServicio()
        {
            detalleFichaRepositorio = new DetalleFichaRepositorio();
        }

        public void InsertarDetalleFicha(TBL_DETALLE_FICHA datosDetalleFicha)
        {
            try
            {
                detalleFichaRepositorio.Guardar(datosDetalleFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarDetalleFicha(TBL_DETALLE_FICHA datosDetalleFicha)
        {
            try
            {
                detalleFichaRepositorio.Modificar(datosDetalleFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_DETALLE_FICHA> ListarDetalleFichas()
        {
            try
            {
                return detalleFichaRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarDetalleFicha(int idDetalleFicha)
        {
            try
            {
                detalleFichaRepositorio.Borrar(idDetalleFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_DETALLE_FICHA ObtenerDetalleFicha(int idDetalleFicha)
        {
            try
            {
                return detalleFichaRepositorio.Obtener(idDetalleFicha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
