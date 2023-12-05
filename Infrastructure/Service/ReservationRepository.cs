using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Table> GetTables()
        {
            var table = _context.Tables.Where(x => !x.IsBooked).ToList();
            return table;
        }

       

        public async Task<bool> Reservation(Reservation reservation)
        {
            if(reservation == null)
            {
                return false;
            }

            var table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == reservation.TableId && !x.IsBooked);

            if(table != null)
            {
                table.IsBooked = true;
                await  _context.Reservations.AddAsync(reservation); 
                _context.SaveChanges();
                return true;
            }
            return false;


        }

       
    }
}
