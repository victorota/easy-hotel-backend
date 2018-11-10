using Microsoft.EntityFrameworkCore;

namespace easy_hotel_backend.Models
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        { }
        public DbSet<Hotel> Hotels { get; set; }
    }
}