using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly ReservationDbContext _context;

        public TableRepository(ReservationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await _context.Tables.OrderBy(x => x.TableName).ToListAsync();
        }


        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Table>> GetAvailableTables(int numberOfGuests, DateTime date, TimeSpan time)
        {

            var reservations = await _context.Reservations.Where(x => 
                (x.ReservationDate == date) &&(
                (x.ReservationTime <= time && time < (x.ReservationTime + TimeSpan.FromHours(5))  ) ||
               ( time >= (x.ReservationTime - TimeSpan.FromHours(5)) && time < x.ReservationTime)
                )) .ToListAsync();
                
            if (!reservations.Any())
            {
                return await _context.Tables.Where(x => x.Capacity >=numberOfGuests).ToListAsync();
            }
            var reservedTableIds = reservations.Select(r => r.TableId);
            var availableTables = await _context.Tables
                .Where(t => !reservedTableIds.Contains(t.Id) && t.Capacity >= numberOfGuests)
                .ToListAsync();

            return availableTables;

        }

        
    }
}
