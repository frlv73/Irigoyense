using Club.Data.Modelos;
using Club.Data.Repositorios;
using Club.Negocio.Infraestructura;
using Club.Negocio.Interfaces;
using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Servicios
{
    public class CuotaService : BaseService, ICuotaService
    {
        private string _nombreConexion;

        public CuotaService(string nombreConexion) : base(nombreConexion)
        {
            _nombreConexion = nombreConexion;
        }

        public void Actualizar(CuotaViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public CuotaViewModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<CuotaViewModel> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        /*
        public CuotaViewModel BuscarUltimoValorCuota()
        {
            
            var mapeador = AutoMapperConfig.CuotaToCuotaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<CuotaViewModel>(database.Cuotas.BuscarObjetoConFechaMasCercana(DateTime.Today));
                
            }
            //return database.Cuotas.Buscar()
        }
        */
        public void Crear(CuotaViewModel t)
        {
            var mapeador = AutoMapperConfig.CuotaToCuotaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Cuotas.Crear(mapeador.Map<Cuota>(t));
                database.GuardarCambios();
            }
        }
    }
}
