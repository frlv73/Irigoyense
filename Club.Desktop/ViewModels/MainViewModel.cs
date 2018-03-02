using Club.Data;
using Club.Desktop.ViewModels.Cuentas;
using Club.Desktop.ViewModels.Cuotas;
using Club.Desktop.ViewModels.Socios;
using Club.Desktop.Views.Cuentas;
using Club.Desktop.Views.Cuotas;
using Club.Desktop.Views.Socios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Club.Desktop.ViewModels
{
    class MainViewModel
    {
        private readonly string _nombreConn = "Default";

        #region DECLARACION DE TABVIEWMODELS
        private SocioTabViewModel socioTabVM;
        public SocioTabViewModel SocioVM => socioTabVM;
        private CuentaTabViewModel cuentaTabVM;
        public CuentaTabViewModel CuentaVM => cuentaTabVM;
        private CuotaTabViewModel cuotaTabVM;
        public CuotaTabViewModel CuotaVM => cuotaTabVM;
        #endregion

        public UserControl SocioUC { get; set; }
        public UserControl CuentaUC { get; set; }
        public UserControl CuotaUC { get; set; }

        public MainViewModel()
        {
            socioTabVM = new SocioTabViewModel(_nombreConn);
            cuentaTabVM = new CuentaTabViewModel(_nombreConn);
            cuotaTabVM = new CuotaTabViewModel(_nombreConn);
            SocioUC = new SocioTabUC();
            CuentaUC = new CuentaTabUC();
            CuotaUC = new CuotaTabUC();
            
        }

    }
}
