using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helper
{
    public class Mapping : Profile
    {

        public Mapping() {

            CreateMap<Reservation, ReservationDto>().
                ForMember(x => x.TableName, r => r.MapFrom(x => x.Table.TableName));

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
