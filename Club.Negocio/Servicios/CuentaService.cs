using Club.Data.Modelos;
using Club.Data.Repositorios;
using Club.Negocio.Infraestructura;
using Club.Negocio.Interfaces;
using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Servicios
{
    public class CuentaService : BaseService, ICuentaService
    {
        private string _nombreConexion;
        public CuentaService(string nombreConexion) : base(nombreConexion)
        {
            _nombreConexion = nombreConexion;
        }

        public void Actualizar(CuentaViewModel t)
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            var cuenta = mapeador.Map<Cuenta>(t);
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Cuentas.Actualizar(cuenta);
                database.GuardarCambios();
            }
        }

        public void Borrar(int id)
        {
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Cuentas.Borrar(id);
                database.GuardarCambios();
            }
        }

        public CuentaViewModel Buscar(int id)
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<CuentaViewModel>(database.Cuentas.BuscarEntidad(id));
            }
        }

        public ObservableCollection<CuentaViewModel> BuscarCuentasPorDescripcion(string textoBusqueda)
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<ObservableCollection<CuentaViewModel>>(database.Cuentas.Buscar(c => c.Descripcion.ToLower().Contains(textoBusqueda.ToLower())));
            }
        }

        public ObservableCollection<CuentaViewModel> BuscarTodos()
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<ObservableCollection<CuentaViewModel>>(database.Cuentas.BuscarTodos());
            }
        }

        public void Crear(CuentaViewModel t)
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                database.Cuentas.Crear(mapeador.Map<Cuenta>(t));
                database.GuardarCambios();
            }
        }

        public ObservableCollection<CuentaViewModel> GetCuentasActivas()
        {
            var mapeador = AutoMapperConfig.CuentaToCuentaVM.CreateMapper();
            using (database = new EFUnitOfWork(_nombreConexion))
            {
                return mapeador.Map<ObservableCollection<CuentaViewModel>>(database.Cuentas.Buscar(
                    s => s.Estado != Data.Enums.EstadoCuenta.Eliminada));
            }
        }


    }
}
