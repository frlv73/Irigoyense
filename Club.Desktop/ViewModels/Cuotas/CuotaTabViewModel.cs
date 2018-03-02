using Club.Negocio.Interfaces;
using Club.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Desktop.ViewModels.Cuotas
{
    public class CuotaTabViewModel : BaseViewModel
    {

        private string _nombreConn;
        private ICuotaService service;
        private ObservableCollection<CuotaTabViewModel> cuotas;

        public ObservableCollection<CuotaTabViewModel> Cuotas
        {
            get { return cuotas; }
            set
            {
                cuotas = value;
                OnPropertyChanged();
            }
        }


        public CuotaTabViewModel(string nombreConn)
        {
            _nombreConn = nombreConn;
            service = new CuotaService(nombreConn);
        }
    }
}
