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
    public partial class Cuenta
    {
        //Recuperar las cuentas hijas en el contructor
        public Cuenta()
        {
            CuentasHijas = new HashSet<Cuenta>();
            Movimientos = new HashSet<Movimiento>();
        }

        [Key, StringLength(100)]
        public string ID { get; set; }
        [Required, StringLength(100)]
        public string Descripcion { get; set; }
        [EnumDataType(typeof(EstadoCuenta))]
        public EstadoCuenta Estado { get; set; }
        

        //Guardamos el ID de la cuenta padre, si la tiene.
        public virtual Cuenta CuentaPadre { get; set; }
        
        //Probablemente la coleccion de cuentas hijas no sea necesaria porque podría navegarse hacia las cuentas hijas. Estudiar
        public virtual ICollection<Cuenta> CuentasHijas { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
