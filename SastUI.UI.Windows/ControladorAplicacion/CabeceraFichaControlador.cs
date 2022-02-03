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

        public int GuardarConId(CabeceraFichaVistaModelo cabecera)
        {
            try
            {
                TBL_CABECERA_FICHA nuevo = new TBL_CABECERA_FICHA();
                nuevo.cl_id = cabecera.IdCliente;
                nuevo.us_id = cabecera.IdUsuario;
                nuevo.cf_fecha = cabecera.Fecha;
                nuevo.cf_codigo = cabecera.Codigo;
                nuevo.cf_estado = cabecera.Estado;
                return new CabeceraFichaServicio().GuardarConId(nuevo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CabeceraFichaVistaModelo> ListarFichasActivas()
        {
            var lista = new CabeceraFichaServicio().ListarFichasActivas();
            List<CabeceraFichaVistaModelo> cabeceraView = new List<CabeceraFichaVistaModelo>();

            var clientes = new ClienteServicio().ListarClientes().ToList();
            var usuarios = new UsuarioServicio().ListarUsuarios().ToList();

            foreach (TBL_CABECERA_FICHA item in lista)
            {
                cabeceraView.Add(new CabeceraFichaVistaModelo
                {
                    Id = item.cf_id,
                    IdCliente = item.cl_id,
                    NombreCliente = clientes.Find(c => c.cl_id == item.cl_id).cl_nombre,
                    IdUsuario = item.us_id,
                    NombreUsuario = usuarios.Find(u => u.us_id == item.us_id).us_nombre,
                    Fecha = item.cf_fecha,
                    Codigo = item.cf_codigo,
                    Estado = item.cf_estado,
                    DescripcionEstado = item.us_id == 1 ? "Activo" : "Inactivo"
                });
            }
            return cabeceraView;
        }

        public IEnumerable<CabeceraFichaVistaModelo> BuscarFichasPorCliente(int idCliente)
        {
            var lista = new CabeceraFichaServicio().BuscarFichasPorCliente(idCliente);
            List<CabeceraFichaVistaModelo> cabeceraView = new List<CabeceraFichaVistaModelo>();

            var clientes = new ClienteServicio().ListarClientes().ToList();
            var usuarios = new UsuarioServicio().ListarUsuarios().ToList();

            foreach (TBL_CABECERA_FICHA item in lista)
            {
                cabeceraView.Add(new CabeceraFichaVistaModelo
                {
                    Id = item.cf_id,
                    IdCliente = item.cl_id,
                    NombreCliente = clientes.Find(c => c.cl_id == item.cl_id).cl_nombre,
                    IdUsuario = item.us_id,
                    NombreUsuario = usuarios.Find(u => u.us_id == item.us_id).us_nombre,
                    Fecha = item.cf_fecha,
                    Codigo = item.cf_codigo,
                    Estado = item.cf_estado,
                    DescripcionEstado = item.us_id == 1 ? "Activo" : "Inactivo"
                });
            }
            return cabeceraView;
        }
    }
}
