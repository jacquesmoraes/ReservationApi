using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SeedingService
    {
        public static async Task SeedAsync(ReservationDbContext context)
        {
            if (!context.Tables.Any())
            {
                var tablesData = File.ReadAllText("../Infrastructure/SeedingData/Table.json");
                var table = JsonSerializer.Deserialize<List<Table>>(tablesData);
                context.Tables.AddRange(table);
            }
            if (!context.Reservations.Any())
            {
                var reservationData = File.ReadAllText("../Infrastructure/SeedingData/reservation.json");
                var reservations = JsonSerializer.Deserialize<List<Reservation>>(reservationData);
                context.Reservations.AddRange(reservations);
            }
           
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
