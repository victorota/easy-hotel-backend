using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easy_hotel_backend.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public int QuartoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}