using AutoMapper;
using reserby.buildingBlocks.maybe;
using reserby.Reservations.API.Application.Dtos;
using reserby.Reservations.API.Domain.Entities;

namespace reserby.Reservations.API.Infrastructure.CrossCutting.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Dto To Domain
            CreateMap<ReservationDto, Reservation>();
            CreateMap<ReservationForCreationDto, Reservation>();
            CreateMap<ReservationForUpdateDto, Reservation>();

            // Domain To Dto
            CreateMap<Reservation, ReservationDto>();

            // Domain To Data
            CreateMap<Reservation, Data.Models.Reservation>();

            // Data To Domain
            CreateMap<Data.Models.Reservation, Reservation>();
        }
    }
}