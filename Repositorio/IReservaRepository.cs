using System;
using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public interface IReservaRepository
    {
        void Add(Reserva reserva);
        IQueryable<Reserva> GetAll();
        Reserva Find(long id);
        void Remove(long id);
        void Update(Reserva reserva);
        Boolean Disponivel(Reserva reserva);
    }
}