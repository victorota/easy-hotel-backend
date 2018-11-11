namespace easy_hotel_backend.Models
{
    public class Quarto
    {
        public int QuartoId { get; set; }
        public int HotelId { get; set; }
        public string TipoQuarto { get; set; }
        public string Descricao { get; set; }
        public string AvaliacaoQuarto { get; set; }
        public double Valor { get; set; }
        public Imagem[] Imagens { get; set; }
        public Hotel Hotel { get; set; }

    }
}