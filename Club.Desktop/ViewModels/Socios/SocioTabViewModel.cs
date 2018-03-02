using Club.Desktop.Infraestructura;
using Club.Negocio.Interfaces;
using Club.Negocio.Modelos;
using Club.Negocio.Servicios;
using Club.Desktop.Views.Socios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Club.Desktop.ViewModels.Socios
{
    public class SocioTabViewModel : BaseViewModel
    {
        #region CAMPOS
        private string _nombreConn;
        private ISocioService service;
        private ObservableCollection<SocioViewModel> socios;

        public ObservableCollection<SocioViewModel> Socios
        {
            get { return socios; }
            set
            {
                socios = value;
                OnPropertyChanged();
            }
        }

        private SocioViewModel socioSeleccionado = null;
        public SocioViewModel SocioSeleccionado
        {
            get { return socioSeleccionado; }
            set { socioSeleccionado = value; }
        }
        #endregion

        #region CONSTRUCTORES
        public SocioTabViewModel(string nombreConexion)
        {
            _nombreConn = nombreConexion;
            this.service = new SocioService(nombreConexion);
            Socios = service.BuscarTodos();
        }
        #endregion

        #region COMANDOS
        private ICommand addCommand = null;
        public ICommand AddCommand => addCommand ?? (new RelayCommand(Agregar));

        private void Agregar(Object obj)
        {
            var dialogVM = new AgregarSocioDialogViewModel(_nombreConn);
            var dialogWindow = new AgregarSocioDialog(dialogVM);
            dialogWindow.ShowDialog();
            if(dialogWindow.DialogResult == true)
            {
                try
                {
                    service.Crear(dialogVM.Socio);
                }
                catch(Exception e)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Se produjo un error");
                }

            }
            ActualizarSocios();
        }


        private ICommand deleteCommand = null;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(Borrar, s => SocioSeleccionado != null));

        private void Borrar(Object obj)
        {
            try
            {
                service.Borrar(SocioSeleccionado.ID);

            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Se produjo un error");
            }

            ActualizarSocios();

        }
        #endregion


        #region METODOS
        private void ActualizarSocios()
        {
            Socios.Clear();
            foreach(var soc in service.BuscarSociosActivos())
            {
                Socios.Add(soc);
            }
        }
        #endregion
    }
}
