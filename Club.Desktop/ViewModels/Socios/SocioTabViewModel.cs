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
using System.Windows;
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
            Socios = service.BuscarSociosActivos();
        }
        #endregion

        #region COMANDOS
        private ICommand addCommand = null;
        public ICommand AddCommand => addCommand ?? (new RelayCommand(Agregar));

        private void Agregar(Object obj)
        {
            var dialogVM = new AgregarEditarSocioDialogViewModel(null, _nombreConn);
            var dialogWindow = new AgregarEditarSocioDialog(dialogVM);
            dialogWindow.ShowDialog();
            if(dialogWindow.DialogResult == true)
            {
                try
                {
                    service.Crear(dialogVM.Socio);
                }
                catch(Exception e)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Se produjo un error al insertar el socio");
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
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Se produjo un error al borrar el socio");
            }

            ActualizarSocios();

        }

        private ICommand editCommand = null;

        public ICommand EditCommand =>
            editCommand ?? (editCommand = new RelayCommand(Actualizar, s => null != SocioSeleccionado && !SocioSeleccionado.HasErrors));

        private void Actualizar(Object obj)
        {
            var dialogVM = new AgregarEditarSocioDialogViewModel(SocioSeleccionado, _nombreConn);
            var dialogWindow = new AgregarEditarSocioDialog(dialogVM);
            dialogWindow.ShowDialog();
            if(dialogWindow.DialogResult == true) { 

            try
            {
                service.Actualizar(SocioSeleccionado);
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Se produjo un error al actualizar el socio");
            }

                ActualizarSocios();
            }
        }

        private ICommand printCommand = null;
        public ICommand PrintCommand => printCommand ?? (printCommand = new RelayCommand(ExportarExcel));

        private void ExportarExcel(Object obj)
        {
            try
            {
                service.GuardarExcel();
                MessageBox.Show("Se ha exportado con éxito la lista de socios activos.","Club Irigoyense", MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
