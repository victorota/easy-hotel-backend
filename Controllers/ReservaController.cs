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

        public ReservaController(IReservaRepository reservaRepo)
        {
            _reservaRepositorio = reservaRepo;
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

    }
}