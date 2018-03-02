using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Modelos
{
    public partial class Cuota
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        public string Mes { get; set; }
        [Key, Column(Order = 2)]
        public string Año { get; set; }
        public double Valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }

        public virtual Socio Socio { get; set; }


    }
}
