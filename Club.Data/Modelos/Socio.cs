using Club.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Modelos
{
    public partial class Socio
    {
        [Key]
        public int ID { get; set; }
        [Required, EnumDataType(typeof(EstadoSocio))]
        public EstadoSocio Estado { get; set; }
        [Required]
        public int DNI { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Localidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

    }
}
