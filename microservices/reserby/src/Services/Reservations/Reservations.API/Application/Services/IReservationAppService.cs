using System.Threading.Tasks;
using reserby.buildingBlocks.maybe;
using reserby.Reservations.API.Application.Dtos;

namespace reserby.Reservations.API.Application.Services
{
    public interface IReservationAppService
    {
        Task<Maybe<ReservationDto>> Get(int id);

        Task<ReservationDto> Create(ReservationForCreationDto input);

        Task<ReservationDto> Update(int id, ReservationForUpdateDto input);
    }
}