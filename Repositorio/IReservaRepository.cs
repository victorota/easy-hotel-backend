using System;
using System.Collections.Generic;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public interface IReservaRepository
    {
        void Add(Reserva reserva);
        IEnumerable<Reserva> GetAll();
        Reserva Find(long id);
        void Remove(long id);
        void Update(Reserva reserva);
        Boolean Disponivel(Reserva reserva);
    }
}