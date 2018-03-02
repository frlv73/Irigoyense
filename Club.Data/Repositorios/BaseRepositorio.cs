using Club.Data.EFContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Repositorios
{
    public abstract class BaseRepositorio<T> where T:class
    {
        protected ClubContext context;
        protected DbSet<T> tabla;

        protected BaseRepositorio(ClubContext context)
        {
            this.context = context;
        }

        public virtual void Crear(T t)
        {
            tabla.Add(t);
        }

        public virtual void Borrar(int id)
        {
            var entidad = tabla.Find(id);
            if(entidad != null)
            {
                tabla.Remove(entidad);
            }
        }

        public virtual IEnumerable<T> Buscar(Func<T, bool> predicate)
        {
            return tabla.Where(predicate);
        }

        public virtual T BuscarEntidad(int id)
        {
            return tabla.Find(id);
        }

        public virtual IEnumerable<T> BuscarTodos()
        {
            return tabla;
        }

        public virtual void Actualizar(T t)
        {
            context.Entry(t).State = EntityState.Modified;
        }

    }
}
