using easy_hotel_backend.Repositorio;
using System.Collections.Generic;
using easy_hotel_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class QuartoController : Controller
    {
        private ApiDbContext _quartoDbContext;
        private readonly IHotelRepository _hotelRepositorio;
        private readonly IQuartoRepository _quartoRepositorio;

        public QuartoController(IHotelRepository hotelRepo, IQuartoRepository quartoRepo)
        {
            _hotelRepositorio = hotelRepo;
            _quartoRepositorio = quartoRepo;
        }

        [HttpGet]
        public IEnumerable<Quarto> GetAll()
        {
            return _quartoRepositorio.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var quarto = _quartoRepositorio.Find(id);
            if (quarto == null)
            {
                return NotFound();
            }
            return new ObjectResult(quarto);
        }

    }
}