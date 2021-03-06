using System;
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

        IQueryable<Reserva> IReservaRepository.GetAll()
        {
            var reservas = _contexto.Reserva.GroupJoin(_contexto.Quarto.ToList(),
             r => r.QuartoId, q => q.QuartoId, (reserva, quarto) => reserva)
             .GroupJoin(_contexto.Hotels.ToList(), r => r.quarto.HotelId, h => h.HotelId, (reserva, hotel) => reserva);
            return reservas;
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

        Boolean IReservaRepository.Disponivel(Reserva reserva)
        {
            var reservas = _contexto.Reserva.Where(r => r.QuartoId == reserva.QuartoId).ToList();
            var disponivel = reservas.Any(r => (r.DataFim >= reserva.DataInicio && r.DataInicio <= reserva.DataInicio) || (r.DataFim <= reserva.DataFim && r.DataInicio <= reserva.DataFim));
            return !disponivel;
        }
    }
}