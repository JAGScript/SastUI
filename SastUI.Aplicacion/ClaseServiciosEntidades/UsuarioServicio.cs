using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using SastUI.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Aplicacion.ClaseServiciosEntidades
{
    public class UsuarioServicio
    {
        readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        public void InsertarUsuario(TBL_USUARIO datosUsuario)
        {
            try
            {
                usuarioRepositorio.Guardar(datosUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarUsuario(TBL_USUARIO datosUsuario)
        {
            try
            {
                usuarioRepositorio.Modificar(datosUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_USUARIO> ListarUsuarios()
        {
            try
            {
                return usuarioRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                usuarioRepositorio.Borrar(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_USUARIO ObtenerUsuario(int idUsuario)
        {
            try
            {
                return usuarioRepositorio.Obtener(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_USUARIO ValidarUsuario(string strUsuario, string strPass)
        {
            try
            {
                return usuarioRepositorio.ValidarUsuario(strUsuario, strPass);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            try
            {
                return usuarioRepositorio.DesactivarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_USUARIO> BuscarUsuarioPorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return usuarioRepositorio.BuscarUsuarioPorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool ValidarDuplicado(string login)
        {
            try
            {
                return usuarioRepositorio.ValidarDuplicado(login);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
