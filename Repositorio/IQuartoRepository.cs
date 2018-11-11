using System.Collections.Generic;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public interface IQuartoRepository
    {
        void Add(Quarto quarto);
        IEnumerable<Quarto> GetAll();
        IEnumerable<Quarto> GetAllByHotelId(long HotelId);
        Quarto Find(long id);
        void Remove(long id);
        void Update(Quarto quarto);
    }
}