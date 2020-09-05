using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerDS215.Models;

namespace TallerDS215.Data
{
    public class TallerDS215Context : DbContext
    {
        public TallerDS215Context (DbContextOptions<TallerDS215Context> options)
            : base(options)
        {
        }

        public DbSet<TallerDS215.Models.Cliente> Cliente { get; set; }

        public DbSet<TallerDS215.Models.Automovil> Automovil { get; set; }

        public DbSet<TallerDS215.Models.Empleado> Empleado { get; set; }

        public DbSet<TallerDS215.Models.Area> Area { get; set; }

        public DbSet<TallerDS215.Models.ModoPago> ModoPago { get; set; }
    }
}
