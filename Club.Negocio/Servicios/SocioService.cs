using Club.Data.Modelos;
using Club.Data.Repositorios;
using Club.Negocio.Infraestructura;
using Club.Negocio.Interfaces;
using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Servicios
{
    public class SocioService : BaseService, ISocioService  
    {
        private string _nombreConexion;
        public SocioService(string nombreConexion) : base(nombreConexion)
        {
            _nombreConexion = nombreConexion;
        }

        public ObservableCollection<SocioViewModel> BuscarSociosActivos()
        {
            var mapeador = AutoMapperConfig.SocioToSocioVM.CreateMapper();
            using(database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<ObservableCollection<SocioViewModel>>(database.Socios.
                    Buscar(s => s.Estado != Data.Enums.EstadoSocio.Eliminado));
            }
        }

        public void Crear(SocioViewModel t)
        {
            t.FechaIngreso = DateTime.Now;
            var mapeador = AutoMapperConfig.SocioToSocioVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Socios.Crear(mapeador.Map<Socio>(t));
                database.GuardarCambios();
            }
        }

        public void Borrar(int id)
        {
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Socios.Borrar(id);
                database.GuardarCambios();
            }
        }

        public SocioViewModel Buscar(int id)
        {
            var mapeador = AutoMapperConfig.SocioToSocioVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<SocioViewModel>(database.Socios.BuscarEntidad(id));
            }
            }

        public ObservableCollection<SocioViewModel> BuscarTodos()
        {
            var mapeador = AutoMapperConfig.SocioToSocioVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<ObservableCollection<SocioViewModel>>(database.Socios.BuscarTodos());
            }
        }

        public void Actualizar(SocioViewModel t)
        {
            var mapeador = AutoMapperConfig.SocioToSocioVM.CreateMapper();
            var socio = mapeador.Map<Socio>(t);
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Socios.Actualizar(socio);
                database.GuardarCambios();
            }
        }
    }
}
