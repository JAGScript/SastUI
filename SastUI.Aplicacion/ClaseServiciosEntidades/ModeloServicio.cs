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
    public class ModeloServicio
    {
        readonly IModeloRepositorio modeloRepositorio;

        public ModeloServicio()
        {
            modeloRepositorio = new ModeloRepositorio();
        }

        public void InsertarModelo(TBL_MODELO datosModelo)
        {
            try
            {
                modeloRepositorio.Guardar(datosModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarModelo(TBL_MODELO datosModelo)
        {
            try
            {
                modeloRepositorio.Modificar(datosModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_MODELO> ListarModelos()
        {
            try
            {
                return modeloRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarModelo(int idModelo)
        {
            try
            {
                modeloRepositorio.Borrar(idModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_MODELO ObtenerModelo(int idModelo)
        {
            try
            {
                return modeloRepositorio.Obtener(idModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_MODELO> ListarModelosActivos(int idMarca)
        {
            try
            {
                return modeloRepositorio.ListarModelosActivos(idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarModelo(int idModelo)
        {
            try
            {
                return modeloRepositorio.DesactivarModelo(idModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool ValidarDuplicado(string modelo, int idMarca)
        {
            try
            {
                return modeloRepositorio.ValidarDuplicado(modelo, idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_MODELO> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return modeloRepositorio.BuscarTipoEquipoPorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
