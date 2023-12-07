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

      

        

        
    }
}
