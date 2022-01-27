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
    public class MarcaServicio
    {
        readonly IMarcaRepositorio marcaRepositorio;

        public MarcaServicio()
        {
            marcaRepositorio = new MarcaRepositorio();
        }

        public void InsertarMarca(TBL_MARCA datosMarca)
        {
            try
            {
                marcaRepositorio.Guardar(datosMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarMarca(TBL_MARCA datosMarca)
        {
            try
            {
                marcaRepositorio.Modificar(datosMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_MARCA> ListarMarcas()
        {
            try
            {
                return marcaRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarMarca(int idMarca)
        {
            try
            {
                marcaRepositorio.Borrar(idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_MARCA ObtenerMarca(int idMarca)
        {
            try
            {
                return marcaRepositorio.Obtener(idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
