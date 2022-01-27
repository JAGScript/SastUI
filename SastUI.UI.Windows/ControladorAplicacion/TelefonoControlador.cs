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
    public class TelefonoControlador
    {
        public bool InsertarTelefono(TelefonoVistaModelo telefonoView)
        {
            TBL_TELEFONO nuevo = new TBL_TELEFONO();
            try
            {
                nuevo.tt_id = telefonoView.IdTipoTelefono;
                nuevo.cl_id = telefonoView.ClienteId;
                nuevo.te_numero = telefonoView.Numero;
                nuevo.te_estado = telefonoView.Estado;
                new TelefonoServicio().InsertarTelefono(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarTelefono(TelefonoVistaModelo telefonoView)
        {
            TBL_TELEFONO telefono = new TBL_TELEFONO();
            try
            {
                telefono.te_id = telefonoView.Id;
                telefono.tt_id = telefonoView.IdTipoTelefono;
                telefono.cl_id = telefonoView.ClienteId;
                telefono.te_numero = telefonoView.Numero;
                telefono.te_estado = telefonoView.Estado;
                new TelefonoServicio().ModificarTelefono(telefono);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<TelefonoVistaModelo> ObtenerTelefonos()
        {
            var lista = new TelefonoServicio().ListarTelefonos();
            List<TelefonoVistaModelo> telefonoView = new List<TelefonoVistaModelo>();

            var tiposTelefono = new TipoTelefonoServicio().ListarTipoTelefonos().ToList();
            var clientes = new ClienteServicio().ListarClientes().ToList();

            foreach (TBL_TELEFONO item in lista)
            {
                telefonoView.Add(new TelefonoVistaModelo
                {
                    Id = item.te_id,
                    IdTipoTelefono = item.tt_id,
                    DescripcionTipo = tiposTelefono.Find(t => t.tt_id == item.tt_id).tt_descripcion.ToString(),
                    ClienteId = item.cl_id,
                    NombreCliente = clientes.Find(c => c.cl_id == item.cl_id).cl_nombre.ToString(),
                    Numero = item.te_numero,
                    Estado = item.te_estado,
                    EstadoDescripcion = item.te_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return telefonoView;
        }

        public IEnumerable<TelefonoVistaModelo> ListarTelefonosCliente(int idCliente)
        {
            var lista = new TelefonoServicio().ListarTelefonosCliente(idCliente);
            List<TelefonoVistaModelo> telefonoView = new List<TelefonoVistaModelo>();

            foreach (TBL_TELEFONO item in lista)
            {
                telefonoView.Add(new TelefonoVistaModelo
                {
                    Id = item.te_id,
                    IdTipoTelefono = item.tt_id,
                    ClienteId = item.cl_id,
                    Numero = item.te_numero,
                    Estado = item.te_estado,
                    EstadoDescripcion = item.te_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return telefonoView;
        }

        public bool DesactivarTelefono(int idTelefono)
        {
            try
            {
                return new TelefonoServicio().DesactivarTelefono(idTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
