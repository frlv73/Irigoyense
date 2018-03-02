using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.EFContext
{
    public partial class ClubContext : DbContext
    {
        public ClubContext(string nombre) : base(nombre)
        {
            Database.SetInitializer(new ClubInitializer());
        }


        public DbSet<Socio> Socios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>()
                .HasOptional(c => c.CuentaPadre)
                .WithMany()
                .HasForeignKey(m => m.CuentaPadreID);

            base.OnModelCreating(modelBuilder);

        }*/
    }

    

    
}
