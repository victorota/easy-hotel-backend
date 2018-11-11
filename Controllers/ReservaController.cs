using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class ReservaController : Controller
    {
        private ApiDbContext _reservaDbContext;
        private readonly IReservaRepository _reservaRepositorio;
        private readonly IQuartoRepository _quartoRepositorio;

        public ReservaController(IReservaRepository reservaRepo, IQuartoRepository quartoRepo)
        {
            _reservaRepositorio = reservaRepo;
            _quartoRepositorio = quartoRepo;
        }

        [HttpGet]
        public IEnumerable<Reserva> GetAll()
        {
            return _reservaRepositorio.GetAll();
        }
        [HttpGet("{id}", Name = "GetReserva")]
        public IActionResult getById(long id)
        {
            var reserva = _reservaRepositorio.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return new ObjectResult(reserva);
        }
        [HttpPost]
        public IActionResult Crate([FromBody] Reserva reserva)
        {
            if (reserva == null || !_reservaRepositorio.Disponivel(reserva))
            {
                return BadRequest();
            }
            _reservaRepositorio.Add(reserva);
            return CreatedAtRoute("GetReserva", new { id = reserva.ReservaId }, reserva);
        }
        [HttpDelete("{id}")]
        public IActionResult remove(long id)
        {
            var reserva = _reservaRepositorio.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }
            _reservaRepositorio.Remove(id);
            return new ContentResult();
        }

    }
}