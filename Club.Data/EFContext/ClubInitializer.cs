using Club.Data.Enums;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.EFContext
{
    internal class ClubInitializer : DropCreateDatabaseIfModelChanges<ClubContext>
    {
        protected override void Seed(ClubContext context)
        {
            //Agregamos un socio de prueba
            context.Socios.Add(new Socio
            {
                Nombre = "Leonel",
                DNI = 35288996,
                Direccion = "Dorrego 441",
                Localidad ="Irigoyen, Santa Fe",
                Estado = EstadoSocio.Activo,
                FechaIngreso = new System.DateTime(2017,01,01)
                
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "01",
                Descripcion = "Disponibilidades",
                Estado = EstadoCuenta.Activa,
                /*
                Cuentas = new HashSet<Cuenta>
                {
                    new Cuenta{ Descripcion="CAJA (Fútbol Infantil)", Estado = EstadoCuenta.Activa},
                    new Cuenta{ Descripcion="CAJA (Fútbol Mayor)", Estado = EstadoCuenta.Activa},
                    new Cuenta{ Descripcion="CAJA (Valores a depositar)", Estado = EstadoCuenta.Activa},
                    new Cuenta{ Descripcion="CAMIL (CTA.CTE.-No.4220)", Estado = EstadoCuenta.Activa},
                    new Cuenta{ Descripcion="CAMIL (CTA.CTE.-No.3023)", Estado = EstadoCuenta.Activa}
                },
                */
                CuentaPadre = null

            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "02",
                Descripcion = "Ingresos Club",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "03",
                Descripcion = "Ingresos Fútbol Infantil",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "04",
                Descripcion = "Egresos Fútbol Infantil",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "05",
                Descripcion = "Egresos Club",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "06",
                Descripcion = "Egresos Torneo Comercial",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });

            context.Cuentas.Add(new Cuenta
            {
                ID = "07",
                Descripcion = "Ingresos Torneo Comercial",
                Estado = EstadoCuenta.Activa,
                CuentaPadre = null
            });
            context.SaveChanges();
        }
        
    }
}
