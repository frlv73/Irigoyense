using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Modelos
{
    public partial class Movimiento
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public double? Ingresos { get; set; }
        public double? Egresos { get; set; }
    
        [Required]
        public virtual Cuenta Cuenta { get; set; }

    }
}
