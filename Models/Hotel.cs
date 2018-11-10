namespace easy_hotel_backend.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Avaliacao { get; set; }
    }
}