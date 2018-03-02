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
    public class EFUnitOfWork : IUnitOfWork
    {
        private ClubContext appContext;
        private SocioRepositorio socioRepositorio;
        private CuentaRepositorio cuentaRepositorio;
        private CuotaRepositorio cuotaRepositorio;

        public EFUnitOfWork(string nombre)
        {
            appContext = new ClubContext(nombre);
        }


        public IRepositorio<Socio> Socios
        {
            get
            {
                if( null == socioRepositorio)
                {
                    socioRepositorio = new SocioRepositorio(appContext);
                }
                return socioRepositorio;
            }
        }

        public IRepositorio<Cuenta> Cuentas
        {
            get
            {
                if (null == cuentaRepositorio)
                {
                    cuentaRepositorio = new CuentaRepositorio(appContext);
                }
                return cuentaRepositorio;
            }
        }


        public IRepositorioExtended<Cuota> Cuotas
        {
            get
            {
                if(null == cuotaRepositorio)
                {
                    cuotaRepositorio = new CuotaRepositorio(appContext);
                }
                return cuotaRepositorio;
            }
        }


        public void GuardarCambios()
        {
            appContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    appContext.Dispose();
                }
                this.disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
