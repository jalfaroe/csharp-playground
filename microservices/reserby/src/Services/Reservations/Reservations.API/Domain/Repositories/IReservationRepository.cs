using System.Threading.Tasks;
using reserby.buildingBlocks.maybe;
using reserby.Reservations.API.Domain.Entities;

namespace reserby.Reservations.API.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Maybe<Reservation>> Get(int id);

        Task Add(Reservation entity);

        Task Update(Reservation entity);
    }
}