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
    public class PerfilServicio
    {
        readonly IPerfilRepositorio perfilRepositorio;

        public PerfilServicio()
        {
            perfilRepositorio = new PerfilRepositorio();
        }

        public void InsertarPerfil(TBL_PERFIL datosPerfil)
        {
            try
            {
                perfilRepositorio.Guardar(datosPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarPerfil(TBL_PERFIL datosPerfil)
        {
            try
            {
                perfilRepositorio.Modificar(datosPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_PERFIL> ListarPerfil()
        {
            try
            {
                return perfilRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                perfilRepositorio.Borrar(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_PERFIL ObtenerCliente(int idCliente)
        {
            try
            {
                return perfilRepositorio.Obtener(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_PERFIL> ListarPerfilesActivos()
        {
            try
            {
                return perfilRepositorio.ListarPerfilesActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool DesactivarPerfil(int idPerfil)
        {
            try
            {
                return perfilRepositorio.DesactivarPerfil(idPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public bool ValidarDuplicado(string perfil)
        {
            try
            {
                return perfilRepositorio.ValidarDuplicado(perfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_PERFIL> BuscarPerfilPorCriterio(int tipoBusqueda, string info)
        {
            try
            {
                return perfilRepositorio.BuscarPerfilPorCriterio(tipoBusqueda, info);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
