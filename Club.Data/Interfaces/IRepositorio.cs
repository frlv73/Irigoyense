using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarEntidad(int id);
        IEnumerable<T> Buscar(Func<T, bool> predicate);
        void Crear(T t);
        void Actualizar(T t);
        void Borrar(int id);
    }
}
