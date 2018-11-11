using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApiDbContext _contexto;
        public ReservaRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }
        void IReservaRepository.Add(Reserva reserva)
        {
            _contexto.Reserva.Add(reserva);
            _contexto.SaveChanges();
        }

        Reserva IReservaRepository.Find(long id)
        {
            var reserva = _contexto.Reserva.FirstOrDefault(r => r.ReservaId == id);
            reserva.quarto = _contexto.Quarto.Find(reserva.QuartoId);
            return reserva;
        }

        IEnumerable<Reserva> IReservaRepository.GetAll()
        {
            return _contexto.Reserva.ToList();
        }

        void IReservaRepository.Remove(long id)
        {
            var entity = _contexto.Reserva.First(r => r.ReservaId == id);
            _contexto.Reserva.Remove(entity);
            _contexto.SaveChanges();
        }

        void IReservaRepository.Update(Reserva reserva)
        {
            _contexto.Reserva.Update(reserva);
            _contexto.SaveChanges();
        }
    }
}