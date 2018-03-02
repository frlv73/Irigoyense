using Club.Data.EFContext;
using Club.Data.Enums;
using Club.Data.Interfaces;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Repositorios
{
    class SocioRepositorio : BaseRepositorio<Socio>, IRepositorio<Socio>
    {
        public SocioRepositorio(ClubContext context) : base(context)
        {
            tabla = context.Socios;
        }

        public override void Borrar(int id)
        {
            var socio = context.Socios.Find(id);
            if(null != socio)
            {
                socio.Estado = EstadoSocio.Eliminado;
            }
        }
    }
}
