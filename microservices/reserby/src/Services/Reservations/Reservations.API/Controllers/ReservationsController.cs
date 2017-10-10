using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reserby.Reservations.API.Application.Dtos;
using reserby.Reservations.API.Application.Services;

namespace reserby.Reservations.API.Controllers
{
    [Route("api/reservations")]
    public class ReservationsController : Controller
    {
        private const string GetReservationActionName = "GetReservation";

        private readonly IReservationAppService _reservationAppService;

        public ReservationsController(IReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        [HttpGet("{id}", Name = GetReservationActionName)]
        public async Task<IActionResult> Get(int id)
        {
            var reservationDto = await _reservationAppService.Get(id);

            if (reservationDto.HasValue)
                return Ok(reservationDto.Value);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservationForCreationDto reservationForCreationDto)
        {
            if (reservationForCreationDto == null)
                return BadRequest();

            var reservationDto = await _reservationAppService.Create(reservationForCreationDto);

            return CreatedAtRoute(GetReservationActionName, new {id = reservationDto.Id}, reservationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReservationForUpdateDto reservationForUpdateDto)
        {
            if (reservationForUpdateDto == null)
                return BadRequest();

            var reservationDto = await _reservationAppService.Update(id, reservationForUpdateDto);

            return CreatedAtRoute(GetReservationActionName, new {id = reservationDto.Id}, reservationDto);
        }
    }
}