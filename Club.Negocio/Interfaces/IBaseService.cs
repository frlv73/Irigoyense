using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Interfaces
{
    public interface IBaseService<T>
    {
        ObservableCollection<T> BuscarTodos();
        T Buscar(int id);
        void Crear(T t);
        void Borrar(int id);
        void Actualizar(T t);
    }
}
