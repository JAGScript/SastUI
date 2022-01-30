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
    public class TipoEquipoControlador
    {
        public bool InsertarTipoEquipo(TipoEquipoVistaModelo tipoEquipoView)
        {
            TBL_TIPO_EQUIPO nuevo = new TBL_TIPO_EQUIPO();
            try
            {
                nuevo.tp_id = tipoEquipoView.Id;
                nuevo.tp_descripcion = tipoEquipoView.Descripcion;
                nuevo.tp_estado = tipoEquipoView.Estado;
                new TipoEquipoServicio().InsertarTipoEquipo(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarTipoEquipo(TipoEquipoVistaModelo tipoEquipoView)
        {
            TBL_TIPO_EQUIPO tipoEquipo = new TBL_TIPO_EQUIPO();
            try
            {
                tipoEquipo.tp_id = tipoEquipoView.Id;
                tipoEquipo.tp_descripcion = tipoEquipoView.Descripcion;
                tipoEquipo.tp_estado = tipoEquipoView.Estado;
                new TipoEquipoServicio().ModificarTipoEquipo(tipoEquipo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<TipoEquipoVistaModelo> ObtenertipoEquipos()
        {
            var lista = new TipoEquipoServicio().ListarTipoEquipos();
            List<TipoEquipoVistaModelo> tipoEquipoView = new List<TipoEquipoVistaModelo>();

            foreach (TBL_TIPO_EQUIPO item in lista)
            {
                tipoEquipoView.Add(new TipoEquipoVistaModelo
                {
                    Id = item.tp_id,
                    Descripcion = item.tp_descripcion,
                    Estado = item.tp_estado,
                    EstadoDescripcion = item.tp_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return tipoEquipoView;
        }

        public IEnumerable<TipoEquipoVistaModelo> ListarTiposActivos()
        {
            var lista = new TipoEquipoServicio().ListarTiposActivos();
            List<TipoEquipoVistaModelo> tipoView = new List<TipoEquipoVistaModelo>();

            tipoView.Add(new TipoEquipoVistaModelo
            {
                Id = 0,
                Descripcion = "Tipos",
                Estado = 1
            });

            foreach (TBL_TIPO_EQUIPO item in lista)
            {
                tipoView.Add(new TipoEquipoVistaModelo
                {
                    Id = item.tp_id,
                    Descripcion = item.tp_descripcion,
                    Estado = item.tp_estado
                });
            }
            return tipoView;
        }

        public bool DesactivarTipoEquipo(int idTipo)
        {
            try
            {
                return new TipoEquipoServicio().DesactivarTipoEquipo(idTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
