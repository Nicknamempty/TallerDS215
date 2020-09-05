using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerDS215.Models;

namespace TallerDS215.Data
{
    public class Dbinit
    {
        public static void Ini(TallerDS215Context context)
        {
            context.Database.EnsureCreated();

            if(context.Automovil.Any())
            {
                return;
            }else
            {
                

            }

            if (context.Cliente.Any())
            {
                return;
            }
            else
            {
                var cli = new Cliente[]
                {
                    new Cliente{DUI="123345-345",nombre="Jose",apellido="pedriño",telefono="2222-22222",correo="123445@gmail.com"},
                    new Cliente{DUI="123345-342",nombre="Jose",apellido="pedriño",telefono="2222-22222",correo="123445@gmail.com"}
                };
                foreach (Cliente c in cli)
                {
                    context.Add(c);
                }
            }
            if (context.Empleado.Any())
            {
                return;
            }
            if (context.Area.Any())
            {
                return;
            }
            if (context.ModoPago.Any())
            {
                return;
            }
            context.SaveChanges();
        }
    }
}
