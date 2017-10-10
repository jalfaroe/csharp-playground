using System.Threading.Tasks;
using AutoMapper;
using reserby.buildingBlocks.maybe;
using reserby.Reservations.API.Application.Dtos;
using reserby.Reservations.API.Domain.Entities;
using reserby.Reservations.API.Domain.Repositories;

namespace reserby.Reservations.API.Application.Services
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _repository;

        public ReservationAppService(IMapper mapper, IReservationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Maybe<ReservationDto>> Get(int id)
        {
            var reservation = await _repository.Get(id);

            return reservation.HasValue
                ? _mapper.Map<ReservationDto>(reservation.Value).ToMaybe()
                : Maybe<ReservationDto>.None;
        }

        public async Task<ReservationDto> Create(ReservationForCreationDto input)
        {
            var reservation = _mapper.Map<Reservation>(input);
            await _repository.Add(reservation);
            var output = _mapper.Map<ReservationDto>(reservation);

            return output;
        }

        public async Task<ReservationDto> Update(int id, ReservationForUpdateDto input)
        {
            var reservation = _mapper.Map<Reservation>(input);
            reservation.Id = id;

            await _repository.Update(reservation);

            var output = _mapper.Map<ReservationDto>(reservation);

            return output;
        }
    }
}