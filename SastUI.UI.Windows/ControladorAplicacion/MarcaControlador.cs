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
    public class MarcaControlador
    {
        public bool InsertarMarca(MarcaVistaModelo marcaView)
        {
            TBL_MARCA nuevaMarca = new TBL_MARCA();
            try
            {
                nuevaMarca.ma_descripcion = marcaView.Descripcion;
                nuevaMarca.ma_estado = marcaView.Estado;
                new MarcaServicio().InsertarMarca(nuevaMarca);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool ActualizarMarca(MarcaVistaModelo marcaView)
        {
            TBL_MARCA marca = new TBL_MARCA();
            try
            {
                marca.ma_id = marcaView.Id;
                marca.ma_descripcion = marcaView.Descripcion;
                marca.ma_estado = marcaView.Estado;
                new MarcaServicio().ModificarMarca(marca);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<MarcaVistaModelo> ObtenerMarcas()
        {
            var lista = new MarcaServicio().ListarMarcas();
            List<MarcaVistaModelo> marcaView = new List<MarcaVistaModelo>();

            foreach (TBL_MARCA item in lista)
            {
                marcaView.Add(new MarcaVistaModelo
                {
                    Id = item.ma_id,
                    Descripcion = item.ma_descripcion,
                    Estado = item.ma_estado
                });
            }
            return marcaView;
        }
    }
}
