using Club.Data.EFContext;
using Club.Data.Interfaces;
using Club.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Repositorios
{
    class CuotaRepositorio : BaseRepositorio<Cuota>, IRepositorioExtended<Cuota>
    {
        public CuotaRepositorio(ClubContext context) : base(context)
        {
            tabla = context.Cuotas;
            
        }

        /*

        public Cuota BuscarObjetoConFechaMasCercana(DateTime fechaHoy)
        {
            var cuotas = context.Cuotas; //Busca todas las cuotas de la base de datos
            var cuotaConFechaMasCercana = new Cuota(); //Cuota que vamos a retornar
            int diferenciaMinima = int.MaxValue; //Variable auxiliar con un valor muy grande

            //Recorre todas las cuotas y compara diferencias de fechas hasta obtener la menor de todas
            foreach (Cuota c in cuotas)
            {
                int diferenciaActual = Math.Abs((fechaHoy - c.FechaValor).Days); //Diferencia en dias con la fecha de hoy

                
                 //Si la diferencia es menor que la mínima, asignamos un nuevo valor y
                  //la cuota a retornar será la que tenga esta diferencia mínima en días
                 
                if (diferenciaActual < diferenciaMinima)
                {
                    diferenciaMinima = diferenciaActual;
                    cuotaConFechaMasCercana = c;

                }
            }

            return cuotaConFechaMasCercana;
        }

        */
    }
}
