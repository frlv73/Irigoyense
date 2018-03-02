using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Modelos
{
    [Serializable]
    public partial class CuotaViewModel : ModelBase
    {
        public int ID { get; set; }
        public DateTime FechaValor { get; set; }
        public double Valor { get; set; }
    }
}
