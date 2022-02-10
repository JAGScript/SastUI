using SastUI.Dominio.Modelo.Abstracciones;
using SastUI.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class AuditoriaRepositorio : BaseRepositorio<TBL_AUDITORIA>, IAuditoriaRepositorio
    {
        public IEnumerable<TBL_AUDITORIA> BuscarAuditoriaPorCriterio(int tipoBusqueda, string info)
        {
            IEnumerable<TBL_AUDITORIA> lista = new List<TBL_AUDITORIA>();
            if (tipoBusqueda == 1)//Por usuario
            {
                lista = BuscarPorUsuario(info);
            }

            return lista;
        }

        private IEnumerable<TBL_AUDITORIA> BuscarPorUsuario(string info)
        {
            try
            {
                int idUsuario = int.Parse(info);
                using (var contexto = new SASTEntities())
                {
                    var query = from auditoria in contexto.TBL_AUDITORIA
                                where auditoria.us_id == idUsuario
                                select auditoria;

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar auditoria, ", ex);
            }
        }
    }
}
