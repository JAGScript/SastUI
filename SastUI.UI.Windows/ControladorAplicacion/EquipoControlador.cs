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
    public class EquipoControlador
    {
        public bool InsertarEquipo(EquipoVistaModelo equipoView)
        {
            TBL_EQUIPO nuevoEquipo = new TBL_EQUIPO();
            try
            {
                nuevoEquipo.tp_id = equipoView.TipoId;
                nuevoEquipo.ma_id = equipoView.MarcaId;
                nuevoEquipo.mo_id = equipoView.ModeloId;
                nuevoEquipo.eq_serie = equipoView.Serie;
                nuevoEquipo.eq_so = equipoView.SistemaOperativo;
                nuevoEquipo.eq_cartacteristicas = equipoView.Caracteristicas;
                nuevoEquipo.eq_observaciones = equipoView.Observaciones;
                nuevoEquipo.eq_estado = equipoView.Estado;
                new EquipoServicio().InsertarEquipo(nuevoEquipo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarEquipo(EquipoVistaModelo equipoView)
        {
            TBL_EQUIPO equipo = new TBL_EQUIPO();
            try
            {
                equipo.tp_id = equipoView.TipoId;
                equipo.ma_id = equipoView.MarcaId;
                equipo.mo_id = equipoView.ModeloId;
                equipo.eq_serie = equipoView.Serie;
                equipo.eq_so = equipoView.SistemaOperativo;
                equipo.eq_cartacteristicas = equipoView.Caracteristicas;
                equipo.eq_observaciones = equipoView.Observaciones;
                equipo.eq_estado = equipoView.Estado;
                new EquipoServicio().ModificarEquipo(equipo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<EquipoVistaModelo> ObtenerEquipos()
        {
            var lista = new EquipoServicio().ListaridEquipos();
            List<EquipoVistaModelo> equipoView = new List<EquipoVistaModelo>();

            var tiposEquipo = new TipoEquipoServicio().ListarTipoEquipos().ToList();
            var marcas = new MarcaServicio().ListarMarcas().ToList();
            var modelos = new ModeloServicio().ListarModelos().ToList();

            foreach (TBL_EQUIPO item in lista)
            {
                equipoView.Add(new EquipoVistaModelo
                {
                    Id = item.eq_id,
                    TipoId = item.tp_id,
                    DescripcionTipo = tiposEquipo.Find(t => t.tp_id == item.tp_id).tp_descripcion,
                    MarcaId = item.ma_id,
                    DescripcionMarca = marcas.Find(m => m.ma_id == item.ma_id).ma_descripcion,
                    ModeloId = item.mo_id,
                    DescripcionModelo = modelos.Find(o => o.mo_id == item.mo_id).mo_descripcion,
                    Serie = item.eq_serie,
                    SistemaOperativo = item.eq_so,
                    Caracteristicas = item.eq_cartacteristicas,
                    Observaciones = item.eq_observaciones,
                    Estado = item.eq_estado,
                    DescripcionEstado = item.eq_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return equipoView;
        }

        public bool DesactivarEquipo(int idEquipo)
        {
            try
            {
                return new EquipoServicio().DesactivarEquipo(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
