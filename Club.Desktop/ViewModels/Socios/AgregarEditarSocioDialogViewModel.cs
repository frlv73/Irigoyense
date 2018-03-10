using Club.Desktop.Infraestructura;
using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Club.Data.Modelos;

namespace Club.Desktop.ViewModels.Socios
{
    public class AgregarEditarSocioDialogViewModel : BaseViewModel
    {
        private string _nombreConn;
        private SocioViewModel _socio = new SocioViewModel();
        
        public SocioViewModel Socio
        {
            get => _socio ?? (_socio = new SocioViewModel());
            set => _socio = value;
        }

        public AgregarEditarSocioDialogViewModel(SocioViewModel socio, string nombreConn)
        {
            _socio = socio;
            _nombreConn = nombreConn;
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, u => !Socio.HasErrors));

        private static void Ok(object parameter)
        {
            if (!(parameter is Window dialogWindow)) return;
            dialogWindow.DialogResult = true;
            dialogWindow.Close();
        }
    }
}
