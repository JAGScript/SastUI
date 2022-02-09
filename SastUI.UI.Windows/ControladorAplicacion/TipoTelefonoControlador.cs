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
    public class TipoTelefonoControlador
    {
        public bool InsertarTipoTelefono(TipoTelefonoVistaModelo tipoTelefonoView)
        {
            TBL_TIPO_TELEFONO nuevo = new TBL_TIPO_TELEFONO();
            try
            {
                nuevo.tt_id = tipoTelefonoView.Id;
                nuevo.tt_descripcion = tipoTelefonoView.Descripcion;
                nuevo.tt_estado = tipoTelefonoView.Estado;
                new TipoTelefonoServicio().InsertarTipoTelefono(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarTipoTelefono(TipoTelefonoVistaModelo tipoTelefonoView)
        {
            TBL_TIPO_TELEFONO tipoTelefono = new TBL_TIPO_TELEFONO();
            try
            {
                tipoTelefono.tt_id = tipoTelefonoView.Id;
                tipoTelefono.tt_descripcion = tipoTelefonoView.Descripcion;
                tipoTelefono.tt_estado = tipoTelefonoView.Estado;
                new TipoTelefonoServicio().ModificarTipoTelefono(tipoTelefono);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<TipoTelefonoVistaModelo> ObtenerTipoTelefonos()
        {
            var lista = new TipoTelefonoServicio().ListarTipoTelefonos();
            List<TipoTelefonoVistaModelo> tipoTelefonoView = new List<TipoTelefonoVistaModelo>();

            foreach (TBL_TIPO_TELEFONO item in lista)
            {
                tipoTelefonoView.Add(new TipoTelefonoVistaModelo
                {
                    Id = item.tt_id,
                    Descripcion = item.tt_descripcion,
                    Estado = item.tt_estado,
                    EstadoDescripcion = item.tt_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return tipoTelefonoView;
        }

        public IEnumerable<TipoTelefonoVistaModelo> ListarTiposActivos()
        {
            var lista = new TipoTelefonoServicio().ListarTiposActivos();
            List<TipoTelefonoVistaModelo> tipoView = new List<TipoTelefonoVistaModelo>();

            tipoView.Add(new TipoTelefonoVistaModelo
            {
                Id = 0,
                Descripcion = "Tipos",
                Estado = 1
            });

            foreach (TBL_TIPO_TELEFONO item in lista)
            {
                tipoView.Add(new TipoTelefonoVistaModelo
                {
                    Id = item.tt_id,
                    Descripcion = item.tt_descripcion,
                    Estado = item.tt_estado
                });
            }
            return tipoView;
        }

        public bool DesactivarTipoTelefono(int idTipo)
        {
            try
            {
                return new TipoTelefonoServicio().DesactivarTipoTelefono(idTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarDuplicado(string descripcion)
        {
            try
            {
                return new TipoTelefonoServicio().ValidarDuplicado(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TipoTelefonoVistaModelo> BuscarTipoTelefonoPorCriterio(int tipoBusqueda, string info)
        {
            var lista = new TipoTelefonoServicio().BuscarTipoTelefonoPorCriterio(tipoBusqueda, info);
            List<TipoTelefonoVistaModelo> tipoTelefonoView = new List<TipoTelefonoVistaModelo>();

            foreach (TBL_TIPO_TELEFONO item in lista)
            {
                tipoTelefonoView.Add(new TipoTelefonoVistaModelo
                {
                    Id = item.tt_id,
                    Descripcion = item.tt_descripcion,
                    Estado = item.tt_estado,
                    EstadoDescripcion = item.tt_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return tipoTelefonoView;
        }
    }
}
