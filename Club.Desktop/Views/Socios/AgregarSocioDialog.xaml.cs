using Club.Desktop.ViewModels.Socios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Club.Desktop.Views.Socios
{
    /// <summary>
    /// Interaction logic for AgregarClienteDialog.xaml
    /// </summary>
    public partial class AgregarSocioDialog : Window
    {
        private AgregarSocioDialogViewModel _vm;

        public AgregarSocioDialog()
        {
            InitializeComponent();
        }

        public AgregarSocioDialog(AgregarSocioDialogViewModel vm)
        {
            _vm = vm;
            DataContext = _vm;
        }
    }
}
