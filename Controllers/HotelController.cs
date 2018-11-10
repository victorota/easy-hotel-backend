using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class HotelController : Controller
    {
        private HotelDbContext _usuarioDbContext;
        private readonly IHotelRepository _hotelRepositorio;

        public HotelController(IHotelRepository usuarioRepo)
        {
            _hotelRepositorio = usuarioRepo;

        }

        [HttpGet]
        public IEnumerable<Hotel> GetAll()
        {
            return _hotelRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetHotel")]
        public IActionResult getById(long id)
        {
            var hotel = _hotelRepositorio.Find(id);
            if (hotel == null)
                return NotFound();

            return new ObjectResult(hotel);
        }
    }
}
