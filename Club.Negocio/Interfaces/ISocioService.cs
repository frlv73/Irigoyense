using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Interfaces
{
    public interface ISocioService : IBaseService<SocioViewModel>
    {
        ObservableCollection<SocioViewModel> BuscarSociosActivos();
    }
}
