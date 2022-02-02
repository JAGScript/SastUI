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
    public class UsuarioControlador
    {
        public bool InsertarUsuario(UsuarioVistaModelo usuarioView)
        {
            TBL_USUARIO nuevo = new TBL_USUARIO();
            try
            {
                nuevo.pe_id = usuarioView.PerfilId;
                nuevo.us_login = usuarioView.Login;
                nuevo.us_pass = usuarioView.Pass;
                nuevo.us_nombre = usuarioView.Nombre;
                nuevo.us_correo = usuarioView.Correo;
                nuevo.us_identificacion = usuarioView.Identificacion;
                nuevo.us_estado = usuarioView.Estado;
                new UsuarioServicio().InsertarUsuario(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarUsuario(UsuarioVistaModelo usuarioView)
        {
            TBL_USUARIO usuario = new TBL_USUARIO();
            try
            {
                usuario.us_id = usuarioView.Id;
                usuario.pe_id = usuarioView.PerfilId;
                usuario.us_login = usuarioView.Login;
                usuario.us_pass = usuarioView.Pass;
                usuario.us_nombre = usuarioView.Nombre;
                usuario.us_correo = usuarioView.Correo;
                usuario.us_identificacion = usuarioView.Identificacion;
                usuario.us_estado = usuarioView.Estado;
                new UsuarioServicio().ModificarUsuario(usuario);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<UsuarioVistaModelo> ObtenerUsuarios()
        {
            var lista = new UsuarioServicio().ListarUsuarios();
            List<UsuarioVistaModelo> usuarioView = new List<UsuarioVistaModelo>();

            var perfiles = new PerfilServicio().ListarPerfil().ToList();

            foreach (TBL_USUARIO item in lista)
            {
                usuarioView.Add(new UsuarioVistaModelo
                {
                    Id = item.us_id,
                    PerfilId = item.pe_id,
                    DescripcionPerfil = perfiles.Find(p => p.pe_id == item.pe_id).pe_nombre.ToString(),
                    Login = item.us_login,
                    Pass = item.us_pass,
                    Nombre = item.us_nombre,
                    Correo = item.us_correo,
                    Identificacion = item.us_identificacion,
                    Estado = item.us_estado,
                    EstadoDescripcion = item.us_estado == 1 ? "Activo" : "Inactivo",
                    Permisos = perfiles.Find(p => p.pe_id == item.pe_id).pe_permisos
                });
            }
            return usuarioView;
        }

        public UsuarioVistaModelo ValidarUsuario(string strUsuario, string strPass)
        {
            try
            {
                var respuesta = new UsuarioServicio().ValidarUsuario(strUsuario, strPass);

                UsuarioVistaModelo usuario = new UsuarioVistaModelo();

                var perfiles = new PerfilServicio().ListarPerfil().ToList();

                if (!string.IsNullOrEmpty(respuesta.us_login))
                {
                    usuario.Id = respuesta.us_id;
                    usuario.PerfilId = respuesta.pe_id;
                    usuario.DescripcionPerfil = perfiles.Find(p => p.pe_id == respuesta.pe_id).pe_nombre.ToString();
                    usuario.Login = respuesta.us_login;
                    usuario.Pass = respuesta.us_pass;
                    usuario.Nombre = respuesta.us_nombre;
                    usuario.Correo = respuesta.us_correo;
                    usuario.Identificacion = respuesta.us_identificacion;
                    usuario.Estado = respuesta.us_estado;
                    usuario.EstadoDescripcion = respuesta.us_estado == 1 ? "Activo" : "Inactivo";
                    usuario.Permisos = perfiles.Find(p => p.pe_id == respuesta.pe_id).pe_permisos;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            try
            {
                return new UsuarioServicio().DesactivarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
