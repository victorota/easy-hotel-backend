using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class HotelController : Controller
    {
        private ApiDbContext _hotelDbContext;
        private readonly IHotelRepository _hotelRepositorio;

        public HotelController(IHotelRepository hotelRepo)
        {
            _hotelRepositorio = hotelRepo;

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
