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
    public class AuditoriaControlador
    {
        public bool InsertarAuditoria(AuditoriaVistaModelo auditoriaView)
        {
            TBL_AUDITORIA nuevo = new TBL_AUDITORIA();
            try
            {
                nuevo.us_id = auditoriaView.IdUsuario;
                nuevo.au_modulo = auditoriaView.Modulo;
                nuevo.au_accion = auditoriaView.Accion;
                nuevo.au_valor = auditoriaView.Valor;
                nuevo.au_fecha = auditoriaView.Fecha;
                new AuditoriaServicio().InsertarAuditoria(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarAuditoria(AuditoriaVistaModelo auditoriaView)
        {
            TBL_AUDITORIA auditoria = new TBL_AUDITORIA();
            try
            {
                auditoria.au_id = auditoriaView.Id;
                auditoria.us_id = auditoriaView.IdUsuario;
                auditoria.au_modulo = auditoriaView.Modulo;
                auditoria.au_accion = auditoriaView.Accion;
                auditoria.au_valor = auditoriaView.Valor;
                auditoria.au_fecha = auditoriaView.Fecha;
                new AuditoriaServicio().ModificarAuditoria(auditoria);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<AuditoriaVistaModelo> ObtenerAuditorias()
        {
            var lista = new AuditoriaServicio().ListarAuditorias();
            List<AuditoriaVistaModelo> auditoriaView = new List<AuditoriaVistaModelo>();

            foreach (TBL_AUDITORIA item in lista)
            {
                auditoriaView.Add(new AuditoriaVistaModelo
                {
                    Id = item.au_id,
                    IdUsuario = item.us_id,
                    Modulo = item.au_modulo,
                    Accion = item.au_accion,
                    Valor = item.au_valor,
                    Fecha = item.au_fecha
                });
            }
            return auditoriaView;
        }
    }
}
