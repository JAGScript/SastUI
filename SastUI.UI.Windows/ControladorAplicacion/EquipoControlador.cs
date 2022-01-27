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
                nuevoEquipo.TBL_TIPO_EQUIPO.tp_id = equipoView.TipoId;
                nuevoEquipo.TBL_MARCA.ma_id = equipoView.MarcaId;
                nuevoEquipo.TBL_MODELO.mo_id = equipoView.ModeloId;
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
                equipo.TBL_TIPO_EQUIPO.tp_id = equipoView.TipoId;
                equipo.TBL_MARCA.ma_id = equipoView.MarcaId;
                equipo.TBL_MODELO.mo_id = equipoView.ModeloId;
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

            foreach (TBL_EQUIPO item in lista)
            {
                equipoView.Add(new EquipoVistaModelo
                {
                    TipoId = item.tp_id,
                    MarcaId = item.ma_id,
                    ModeloId = item.mo_id,
                    Serie = item.eq_serie,
                    SistemaOperativo = item.eq_so,
                    Caracteristicas = item.eq_cartacteristicas,
                    Observaciones = item.eq_observaciones,
                    Estado = item.eq_estado
                });
            }
            return equipoView;
        }
    }
}
