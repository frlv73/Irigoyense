using Club.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Modelos
{
    [Serializable]
    public partial class SocioViewModel
    {
        public int ID { get; set; }
        [Required, EnumDataType(typeof(EstadoSocio))]
        public EstadoSocio Estado { get; set; }
        public int DNI { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Localidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        
    }
}
