using Club.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Servicios
{
    public abstract class BaseService
    {
        protected IUnitOfWork database;
        protected string conexion;
        public BaseService(string nombre)
        {
            conexion = nombre;
        }
    }
}
