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
    public class DetalleFichaControlador
    {
        public bool InsertarDetalleFicha(DetalleFichaVistaModelo detalleFichaView)
        {
            TBL_DETALLE_FICHA nuevo = new TBL_DETALLE_FICHA();
            try
            {
                nuevo.df_id = detalleFichaView.Id;
                nuevo.cf_id = detalleFichaView.CabeceraFichaId;
                nuevo.eq_id = detalleFichaView.EquipoId;
                nuevo.df_observaciones = detalleFichaView.Observaciones;
                nuevo.df_proceso = detalleFichaView.Proceso;
                nuevo.df_estado = detalleFichaView.Estado;
                new DetalleFichaServicio().InsertarDetalleFicha(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarDetalleFicha(DetalleFichaVistaModelo detalleFichaView)
        {
            TBL_DETALLE_FICHA detalleFicha = new TBL_DETALLE_FICHA();
            try
            {
                detalleFicha.df_id = detalleFichaView.Id;
                detalleFicha.cf_id = detalleFichaView.CabeceraFichaId;
                detalleFicha.eq_id = detalleFichaView.EquipoId;
                detalleFicha.df_observaciones = detalleFichaView.Observaciones;
                detalleFicha.df_proceso = detalleFichaView.Proceso;
                detalleFicha.df_estado = detalleFichaView.Estado;
                new DetalleFichaServicio().ModificarDetalleFicha(detalleFicha);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<DetalleFichaVistaModelo> ObtenerDetalleFichas()
        {
            var lista = new DetalleFichaServicio().ListarDetalleFichas();
            List<DetalleFichaVistaModelo> detalleFichaView = new List<DetalleFichaVistaModelo>();

            foreach (TBL_DETALLE_FICHA item in lista)
            {
                detalleFichaView.Add(new DetalleFichaVistaModelo
                {
                    Id = item.df_id,
                    CabeceraFichaId = item.cf_id,
                    EquipoId = item.eq_id,
                    Observaciones = item.df_observaciones,
                    Proceso = item.df_proceso,
                    Estado = item.df_estado
                });
            }
            return detalleFichaView;
        }

        public IEnumerable<DetalleFichaVistaModelo> BuscarDetallePorIdCabecera(int idCabecera)
        {
            var lista = new DetalleFichaServicio().BuscarDetallePorIdCabecera(idCabecera);
            List<DetalleFichaVistaModelo> detalleFichaView = new List<DetalleFichaVistaModelo>();

            var equipos = new EquipoServicio().ListarEquipos().ToList();
            var tipoEquipos = new TipoEquipoServicio().ListarTipoEquipos().ToList();
            var marcas = new MarcaServicio().ListarMarcas().ToList();
            var modelos = new ModeloServicio().ListarModelos().ToList();

            foreach (TBL_DETALLE_FICHA item in lista)
            {
                var equipo = equipos.Find(e => e.eq_id == item.eq_id);
                var tipoEquipo = tipoEquipos.Find(t => t.tp_id == equipo.tp_id);
                var marca = marcas.Find(m => m.ma_id == equipo.ma_id);
                var modelo = modelos.Find(mo => mo.mo_id == equipo.mo_id);

                string desEstado = "";
                if (int.Parse(item.df_estado) == 1)
                    desEstado = "INGRESADO";
                else if (int.Parse(item.df_estado) == 2)
                    desEstado = "EN PROCESO";
                else if (int.Parse(item.df_estado) == 3)
                    desEstado = "ESPERANDO REPUESTO";
                else if (int.Parse(item.df_estado) == 4)
                    desEstado = "FINALIZADO";
                else if (int.Parse(item.df_estado) == 5)
                    desEstado = "ENTREGADO AL CLIENTE";

                detalleFichaView.Add(new DetalleFichaVistaModelo
                {
                    Id = item.df_id,
                    CabeceraFichaId = item.cf_id,
                    EquipoId = item.eq_id,
                    DescripcionEquipo = tipoEquipo.tp_descripcion + "|" + marca.ma_descripcion + "|" + modelo.mo_descripcion,
                    Observaciones = item.df_observaciones,
                    Proceso = item.df_proceso,
                    Estado = item.df_estado,
                    DescripcionEstado = desEstado
                });
            }
            return detalleFichaView;
        }
    }
}
