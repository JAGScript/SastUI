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
    public class CabeceraFichaControlador
    {
        public bool InsertarCabeceraFicha(CabeceraFichaVistaModelo cabeceraFichaView)
        {
            TBL_CABECERA_FICHA nuevo = new TBL_CABECERA_FICHA();
            try
            {
                nuevo.cf_id = cabeceraFichaView.Id;
                nuevo.cl_id = cabeceraFichaView.IdCliente;
                nuevo.us_id = cabeceraFichaView.IdUsuario;
                nuevo.cf_fecha = cabeceraFichaView.Fecha;
                nuevo.cf_codigo = cabeceraFichaView.Codigo;
                nuevo.cf_estado = cabeceraFichaView.Estado;
                new CabeceraFichaServicio().InsertarCabeceraFicha(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarCabeceraFicha(CabeceraFichaVistaModelo cabeceraFichaView)
        {
            TBL_CABECERA_FICHA cabeceraFicha = new TBL_CABECERA_FICHA();
            try
            {
                cabeceraFicha.cf_id = cabeceraFichaView.Id;
                cabeceraFicha.cl_id = cabeceraFichaView.IdCliente;
                cabeceraFicha.us_id = cabeceraFichaView.IdUsuario;
                cabeceraFicha.cf_fecha = cabeceraFichaView.Fecha;
                cabeceraFicha.cf_codigo = cabeceraFichaView.Codigo;
                cabeceraFicha.cf_estado = cabeceraFichaView.Estado;
                new CabeceraFichaServicio().ModificarCabeceraFicha(cabeceraFicha);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<CabeceraFichaVistaModelo> ObtenerCabeceraFichas()
        {
            var lista = new CabeceraFichaServicio().ListarCabeceraFichas();
            List<CabeceraFichaVistaModelo> cabeceraFichaView = new List<CabeceraFichaVistaModelo>();

            foreach (TBL_CABECERA_FICHA item in lista)
            {
                cabeceraFichaView.Add(new CabeceraFichaVistaModelo
                {
                    Id = item.cf_id,
                    IdCliente = item.cl_id,
                    IdUsuario = item.us_id,
                    Fecha = item.cf_fecha,
                    Codigo = item.cf_codigo,
                    Estado = item.cf_estado
                });
            }
            return cabeceraFichaView;
        }
    }
}
