using System.Collections.Generic;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);

        IEnumerable<Hotel> GetAll();

        Hotel Find(long id);

        void Remove(long id);

        void Update(Hotel user);
    }
}