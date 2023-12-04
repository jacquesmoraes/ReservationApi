using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Table> Tables { get; set; }
    }
}
