using Club.Desktop.Infraestructura;
using Club.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Club.Desktop.ViewModels.Socios
{
    public class AgregarSocioDialogViewModel : BaseViewModel
    {
        private string _nombreConn;
        private SocioViewModel socio = new SocioViewModel();
        
        public SocioViewModel Socio
        {
            get { return socio; }
            set { socio = value; }
        }

        public AgregarSocioDialogViewModel(string nombreConn)
        {
            _nombreConn = nombreConn;
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, u => !Socio.HasErrors));

        private void Ok(object parameter)
        {
            if (parameter is Window dialogWindow)
            {
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }
    }
}
