using Club.Data.EFContext;
using Club.Data.Interfaces;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Repositorios
{
    class CuentaRepositorio : BaseRepositorio<Cuenta>, IRepositorio<Cuenta>
    {
        public CuentaRepositorio(ClubContext context) : base(context)
        {
            tabla = context.Cuentas;
        }

        public override void Borrar(int id)
        {
            var cuenta = context.Cuentas.Find(id);
            if(null != cuenta)
            {
                cuenta.Estado = Enums.EstadoCuenta.Eliminada;
            }
        }

    }
}
