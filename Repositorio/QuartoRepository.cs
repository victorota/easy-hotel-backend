using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly ApiDbContext _contexto;
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
            return _contexto.Quarto.FirstOrDefault(q => q.QuartoId == id);
        }

        IEnumerable<Quarto> IQuartoRepository.GetAll()
        {
            return _contexto.Quarto.ToList();
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