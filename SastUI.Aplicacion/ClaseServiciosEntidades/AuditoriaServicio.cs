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
    public class AuditoriaServicio
    {
        readonly IAuditoriaRepositorio auditoriaRepositorio;

        public AuditoriaServicio()
        {
            auditoriaRepositorio = new AuditoriaRepositorio();
        }

        public void InsertarAuditoria(TBL_AUDITORIA datosAuditoria)
        {
            try
            {
                auditoriaRepositorio.Guardar(datosAuditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void ModificarAuditoria(TBL_AUDITORIA datosAuditoria)
        {
            try
            {
                auditoriaRepositorio.Modificar(datosAuditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public IEnumerable<TBL_AUDITORIA> ListarAuditorias()
        {
            try
            {
                return auditoriaRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void EliminarAuditoria(int idAuditoria)
        {
            try
            {
                auditoriaRepositorio.Borrar(idAuditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public TBL_AUDITORIA ObtenerAuditoria(int idAuditoria)
        {
            try
            {
                return auditoriaRepositorio.Obtener(idAuditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
