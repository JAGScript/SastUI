using SastUI.Aplicacion.ClaseServiciosEntidades;
using SastUI.Dominio.Modelo.Entidades;
using SastUI.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.ControladorAplicacion
{
    public class ModeloControlador
    {
        public bool InsertarModelo(ModeloVistaModelo modeloView)
        {
            TBL_MODELO nuevoModelo = new TBL_MODELO();
            try
            {
                nuevoModelo.mo_descripcion = modeloView.Descripcion;
                nuevoModelo.mo_estado = modeloView.Estado;
                nuevoModelo.ma_id = modeloView.MarcaId;
                new ModeloServicio().InsertarModelo(nuevoModelo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarModelo(ModeloVistaModelo modeloView)
        {
            TBL_MODELO modelo = new TBL_MODELO();
            try
            {
                modelo.mo_id = modeloView.Id;
                modelo.mo_descripcion = modeloView.Descripcion;
                modelo.mo_estado = modeloView.Estado;
                modelo.ma_id = modeloView.MarcaId;
                new ModeloServicio().ModificarModelo(modelo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<ModeloVistaModelo> ObtenerModelos()
        {
            var lista = new ModeloServicio().ListarModelos();
            List<ModeloVistaModelo> modeloView = new List<ModeloVistaModelo>();

            var marcas = new MarcaControlador().ObtenerMarcas().ToList();

            foreach (TBL_MODELO item in lista)
            {
                modeloView.Add(new ModeloVistaModelo
                {
                    Id = item.mo_id,
                    Descripcion = item.mo_descripcion,
                    Estado = item.mo_estado,
                    DescripcionEstado = item.mo_estado == 1 ? "Activo" : "Inactivo",
                    MarcaId = item.ma_id,
                    MarcaDescripcion = marcas.Find(m => m.Id == item.ma_id).Descripcion
                });
            }
            return modeloView;
        }

        public IEnumerable<ModeloVistaModelo> ListarModelosActivos(int idMarca)
        {
            var lista = new ModeloServicio().ListarModelosActivos(idMarca);
            List<ModeloVistaModelo> modeloView = new List<ModeloVistaModelo>();

            modeloView.Add(new ModeloVistaModelo
            {
                Id = 0,
                Descripcion = "Modelos",
                Estado = 1
            });

            foreach (TBL_MODELO item in lista)
            {
                modeloView.Add(new ModeloVistaModelo
                {
                    Id = item.mo_id,
                    Descripcion = item.mo_descripcion,
                    Estado = item.mo_estado
                });
            }
            return modeloView;
        }

        public bool DesactivarModelo(int idModelo)
        {
            try
            {
                return new ModeloServicio().DesactivarModelo(idModelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarDuplicado(string modelo, int idMarca)
        {
            try
            {
                return new ModeloServicio().ValidarDuplicado(modelo, idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ModeloVistaModelo> BuscarTipoEquipoPorCriterio(int tipoBusqueda, string info)
        {
            var lista = new ModeloServicio().BuscarTipoEquipoPorCriterio(tipoBusqueda, info);
            List<ModeloVistaModelo> modeloView = new List<ModeloVistaModelo>();

            var marcas = new MarcaControlador().ObtenerMarcas().ToList();

            foreach (TBL_MODELO item in lista)
            {
                modeloView.Add(new ModeloVistaModelo
                {
                    Id = item.mo_id,
                    Descripcion = item.mo_descripcion,
                    Estado = item.mo_estado,
                    DescripcionEstado = item.mo_estado == 1 ? "Activo" : "Inactivo",
                    MarcaId = item.ma_id,
                    MarcaDescripcion = marcas.Find(m => m.Id == item.ma_id).Descripcion
                });
            }
            return modeloView;
        }
    }
}
