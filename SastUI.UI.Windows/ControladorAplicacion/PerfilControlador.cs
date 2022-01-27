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
    public class PerfilControlador
    {
        public bool InsertarPerfil(PerfilVistaModelo perfilView)
        {
            TBL_PERFIL nuevoPerfil = new TBL_PERFIL();
            try
            {
                nuevoPerfil.pe_nombre = perfilView.Nombre;
                nuevoPerfil.pe_estado = perfilView.Estado;
                new PerfilServicio().InsertarPerfil(nuevoPerfil);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarPerfil(PerfilVistaModelo perfilView)
        {
            TBL_PERFIL perfil = new TBL_PERFIL();
            try
            {
                perfil.pe_id = perfilView.Id;
                perfil.pe_nombre = perfilView.Nombre;
                perfil.pe_estado = perfilView.Estado;
                new PerfilServicio().ModificarPerfil(perfil);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<PerfilVistaModelo> ObtenerPerfiles()
        {
            var lista = new PerfilServicio().ListarPerfil();
            List<PerfilVistaModelo> perfilView = new List<PerfilVistaModelo>();

            foreach (TBL_PERFIL item in lista)
            {
                perfilView.Add(new PerfilVistaModelo
                {
                    Id = item.pe_id,
                    Nombre = item.pe_nombre,
                    Estado = item.pe_estado,
                    EstadoDescripcion = item.pe_estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return perfilView;
        }

        public IEnumerable<PerfilVistaModelo> ListarPerfilesActivos()
        {
            var lista = new PerfilServicio().ListarPerfilesActivos();
            List<PerfilVistaModelo> perfilView = new List<PerfilVistaModelo>();

            perfilView.Add(new PerfilVistaModelo
            {
                Id = 0,
                Nombre = "Perfiles",
                Estado = 1
            });

            foreach (TBL_PERFIL item in lista)
            {
                perfilView.Add(new PerfilVistaModelo
                {
                    Id = item.pe_id,
                    Nombre = item.pe_nombre,
                    Estado = item.pe_estado
                });
            }
            return perfilView;
        }

        public bool DesactivarPerfil(int idPerfil)
        {
            try
            {
                return new PerfilServicio().DesactivarPerfil(idPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
