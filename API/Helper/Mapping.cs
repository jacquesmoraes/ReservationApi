using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class Mapping : Profile
    {

        public Mapping() {

            CreateMap< Reservation, ReservationDto>().
                ForMember(x => x.TableName, r => r.MapFrom(x => x.Table.TableName)).
                ForMember(x => x.Capacity, r => r.MapFrom(x => x.Table.Capacity));
        }
    }
}
