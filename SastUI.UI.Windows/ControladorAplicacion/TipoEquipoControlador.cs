﻿using SastUI.Aplicacion.ClaseServiciosEntidades;
using SastUI.Dominio.Modelo.Entidades;
using SastUI.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.UI.Windows.ControladorAplicacion
{
    public class TipoEquipoControlador
    {
        public bool InsertarTipoEquipo(TipoEquipoVistaModelo tipoEquipoView)
        {
            TBL_TIPO_EQUIPO nuevo = new TBL_TIPO_EQUIPO();
            try
            {
                nuevo.tp_id = tipoEquipoView.Id;
                nuevo.tp_descripcion = tipoEquipoView.Descripcion;
                nuevo.tp_estado = tipoEquipoView.Estado;
                new TipoEquipoServicio().InsertarTipoEquipo(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarTipoEquipo(TipoEquipoVistaModelo tipoEquipoView)
        {
            TBL_TIPO_EQUIPO tipoEquipo = new TBL_TIPO_EQUIPO();
            try
            {
                tipoEquipo.tp_id = tipoEquipoView.Id;
                tipoEquipo.tp_descripcion = tipoEquipoView.Descripcion;
                tipoEquipo.tp_estado = tipoEquipoView.Estado;
                new TipoEquipoServicio().ModificarTipoEquipo(tipoEquipo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<TipoEquipoVistaModelo> ObtenertipoEquipos()
        {
            var lista = new TipoEquipoServicio().ListarTipoEquipos();
            List<TipoEquipoVistaModelo> tipoEquipoView = new List<TipoEquipoVistaModelo>();

            foreach (TBL_TIPO_EQUIPO item in lista)
            {
                tipoEquipoView.Add(new TipoEquipoVistaModelo
                {
                    Id = item.tp_id,
                    Descripcion = item.tp_descripcion,
                    Estado = item.tp_estado
                });
            }
            return tipoEquipoView;
        }
    }
}