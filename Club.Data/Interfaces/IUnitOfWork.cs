using Club.Data.Repositorios;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Agregar todos los repositorios de las entidades que voy a recuperar
        IRepositorio<Socio> Socios { get; }
        IRepositorio<Cuenta> Cuentas { get; }
        IRepositorioExtended<Cuota> Cuotas { get; }

        void GuardarCambios();

    }
}
