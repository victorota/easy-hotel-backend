using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _contexto;
        public HotelRepository(HotelDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Hotel hotel)
        {
            _contexto.Hotels.Add(hotel);
            _contexto.SaveChanges();
        }

        Hotel IHotelRepository.Find(long id)
        {
            return _contexto.Hotels.FirstOrDefault(h => h.HotelId == id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _contexto.Hotels.ToList();
        }

        public void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Hotel user)
        {
            throw new System.NotImplementedException();
        }
    }

}