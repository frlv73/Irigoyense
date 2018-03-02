using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Interfaces
{
    public interface IRepositorioExtended<T> : IRepositorio<T>
    {
        // T BuscarObjetoConFechaMasCercana(DateTime fechaEnDias);
    }
}
