using Club.Desktop.Infraestructura;
using Club.Negocio.Interfaces;
using Club.Negocio.Modelos;
using Club.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Club.Desktop.ViewModels.Cuentas
{
    public class CuentaTabViewModel : BaseViewModel
    {
        #region CAMPOS
        
        private string _nombreConn;
        private ICuentaService service;
        private ObservableCollection<CuentaViewModel> cuentas;
        public ObservableCollection<CuentaViewModel> Cuentas
        {
            get { return cuentas; }
            set
            {
                cuentas = value;
                OnPropertyChanged();
            }
        }


        private CuentaViewModel cuentaSeleccionado = null;
        public CuentaViewModel CuentaSeleccionado
        {
            get { return cuentaSeleccionado; }
            set { cuentaSeleccionado = value; }
        }

        private string _textoBusqueda;

        public string TextoBusqueda
        {
            get { return _textoBusqueda; }
            set
            {
                _textoBusqueda = value;
                OnPropertyChanged(nameof(TextoBusqueda));
            }
        }



        #endregion

        #region CONSTRUCTOR
        public CuentaTabViewModel(string nombreConn)
        {
            _nombreConn = nombreConn;
            service = new CuentaService(nombreConn);
            Cuentas = service.BuscarTodos();
        }

        #endregion
        #region COMANDOS
        private ICommand searchCommand = null;

        public ICommand SearchCommand => searchCommand ?? (searchCommand = new RelayCommand(Buscar));
        

        private void Buscar(Object param)
        {
            Cuentas = service.BuscarCuentasPorDescripcion(TextoBusqueda);
        }

        #endregion

        #region METODOS
        

        #endregion
    }
}
