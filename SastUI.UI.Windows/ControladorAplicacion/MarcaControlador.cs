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
    public class MarcaControlador
    {
        public bool InsertarMarca(MarcaVistaModelo marcaView)
        {
            TBL_MARCA nuevaMarca = new TBL_MARCA();
            try
            {
                nuevaMarca.ma_descripcion = marcaView.Descripcion;
                nuevaMarca.ma_estado = marcaView.Estado;
                new MarcaServicio().InsertarMarca(nuevaMarca);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarMarca(MarcaVistaModelo marcaView)
        {
            TBL_MARCA marca = new TBL_MARCA();
            try
            {
                marca.ma_id = marcaView.Id;
                marca.ma_descripcion = marcaView.Descripcion;
                marca.ma_estado = marcaView.Estado;
                new MarcaServicio().ModificarMarca(marca);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<MarcaVistaModelo> ObtenerMarcas()
        {
            var lista = new MarcaServicio().ListarMarcas();
            List<MarcaVistaModelo> marcaView = new List<MarcaVistaModelo>();

            foreach (TBL_MARCA item in lista)
            {
                marcaView.Add(new MarcaVistaModelo
                {
                    Id = item.ma_id,
                    Descripcion = item.ma_descripcion,
                    Estado = item.ma_estado,
                    DescripcionEstado = item.ma_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return marcaView;
        }

        public IEnumerable<MarcaVistaModelo> ListarMarcasActivas()
        {
            var lista = new MarcaServicio().ListarMarcasActivas();
            List<MarcaVistaModelo> marcaView = new List<MarcaVistaModelo>();

            marcaView.Add(new MarcaVistaModelo
            {
                Id = 0,
                Descripcion = "Marcas",
                Estado = 1
            });

            foreach (TBL_MARCA item in lista)
            {
                marcaView.Add(new MarcaVistaModelo
                {
                    Id = item.ma_id,
                    Descripcion = item.ma_descripcion,
                    Estado = item.ma_estado
                });
            }
            return marcaView;
        }

        public bool DesactivarMarca(int idMarca)
        {
            try
            {
                return new MarcaServicio().DesactivarMarca(idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarDuplicado(string marca)
        {
            try
            {
                return new MarcaServicio().ValidarDuplicado(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MarcaVistaModelo> BuscarMarcaPorCriterio(int tipoBusqueda, string info)
        {
            var lista = new MarcaServicio().BuscarMarcaPorCriterio(tipoBusqueda, info);
            List<MarcaVistaModelo> marcaView = new List<MarcaVistaModelo>();

            foreach (TBL_MARCA item in lista)
            {
                marcaView.Add(new MarcaVistaModelo
                {
                    Id = item.ma_id,
                    Descripcion = item.ma_descripcion,
                    Estado = item.ma_estado,
                    DescripcionEstado = item.ma_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return marcaView;
        }
    }
}
