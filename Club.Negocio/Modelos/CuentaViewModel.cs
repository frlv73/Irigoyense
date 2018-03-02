using Club.Data.Enums;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Modelos
{
    [Serializable]
    public partial class CuentaViewModel
    {
        [StringLength(100)]
        public int ID { get; set; }
        [Required, StringLength(100)]
        public string Descripcion { get; set; }
        [EnumDataType(typeof(EstadoCuenta))]
        public EstadoCuenta Estado { get; set; }
        public int? CuentaPadreID { get; set; }
        
        public ObservableCollection<CuentaViewModel> CuentasHijas { get; set; }
    }
}
