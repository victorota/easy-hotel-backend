using easy_hotel_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace easy_hotel_backend
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Quarto> Quarto { get; set; }

    }
}