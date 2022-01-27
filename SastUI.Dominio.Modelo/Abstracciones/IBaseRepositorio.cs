using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Dominio.Modelo.Abstracciones
{
    public interface IBaseRepositorio <TEntity> where TEntity : class
    {
        void Guardar (TEntity entity);

        void Borrar (int id);

        void Modificar(TEntity entity);

        IEnumerable<TEntity> Listar();

        TEntity Obtener (int id);
    }
}
