using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ReservationsWithTablesSpecifications : BaseSpecification<Reservation>

    {
        public ReservationsWithTablesSpecifications()
        {

            {
                AddIncludes(x => x.Table);
                AddOrderByDescending(x => x.ReservationDate);
            }
        }
        public ReservationsWithTablesSpecifications(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.Table);
        }
    }
}
