using SastUI.Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SastUI.Infraestructura.AccesoDatos.Repositorio
{
    public class BaseRepositorio<TEntity> : IDisposable, IBaseRepositorio<TEntity> where TEntity : class
    {
        public void Borrar(int id)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro" + ex.Message);
            }
        }

        public void Guardar(TEntity entity)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede guardar el registro" + ex.Message);
            }
        }

        public IEnumerable<TEntity> Listar()
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    return context.Set<TEntity>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede recuperar los registros" + ex.Message);
            }
        }

        public void Modificar(TEntity entity)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede actualizar el registro" + ex.Message);
            }
        }

        public TEntity Obtener(int id)
        {
            try
            {
                using (var context = new SASTEntities())
                {
                    return context.Set<TEntity>().Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede recuperar el registro" + ex.Message);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
