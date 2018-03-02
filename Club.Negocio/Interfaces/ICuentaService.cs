using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Interfaces
{
    public interface ICuentaService : IBaseService<CuentaViewModel>
    {
        ObservableCollection<CuentaViewModel> GetCuentasActivas();
        ObservableCollection<CuentaViewModel> BuscarCuentasPorDescripcion(string textoBusqueda);
    }
}
