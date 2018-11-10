using Microsoft.EntityFrameworkCore;

namespace easy_hotel_backend.Models
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}