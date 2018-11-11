using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly ApiDbContext _contexto;
        private IHotelRepository _hotelRepository;
        public QuartoRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }
        void IQuartoRepository.Add(Quarto quarto)
        {
            _contexto.Quarto.Add(quarto);
            _contexto.SaveChanges();
        }

        Quarto IQuartoRepository.Find(long id)
        {
            var quarto = _contexto.Quarto.FirstOrDefault(q => q.QuartoId == id);
            quarto.Hotel = _contexto.Hotels.Find(quarto.HotelId);
            return quarto;
        }

        IEnumerable<Quarto> IQuartoRepository.GetAll()
        {
            var quartos = _contexto.Quarto.GroupJoin(_contexto.Hotels.ToList(), q => q.HotelId, h => h.HotelId, (quarto, hotel) => quarto);
            return quartos;
        }

        IEnumerable<Quarto> IQuartoRepository.GetAllByHotelId(long HotelId)
        {
            return _contexto.Quarto.ToList().FindAll(q => q.HotelId == HotelId);
        }

        void IQuartoRepository.Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        void IQuartoRepository.Update(Quarto quarto)
        {
            throw new System.NotImplementedException();
        }
    }
}