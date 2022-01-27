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
    }
}
