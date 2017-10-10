using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using reserby.buildingBlocks.maybe;
using reserby.Reservations.API.Domain.Entities;
using reserby.Reservations.API.Domain.Repositories;
using reserby.Reservations.API.Infrastructure.Data.Context;

namespace reserby.Reservations.API.Infrastructure.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationsContext _context;
        private readonly IMapper _mapper;

        public ReservationRepository(ReservationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Maybe<Reservation>> Get(int id)
        {
            var model = await _context.Reservations.FindAsync(id);
            var entity = _mapper.Map<Reservation>(model);

            return entity.ToMaybe();
        }

        public async Task Add(Reservation entity)
        {
            var model = _mapper.Map<Models.Reservation>(entity);
            _context.Reservations.Add(model);
            await _context.SaveChangesAsync();
            entity.Id = model.Id;
        }

        public async Task Update(Reservation entity)
        {
            var model = _mapper.Map<Models.Reservation>(entity);
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}