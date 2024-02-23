namespace SinemaBiletSatis.Entities
{
    public class Sinema:IEntity
    {
        public int Id { get; set; }
        public string SinemaAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public ICollection<Salon>? Salonlar { get; set; }
    }
}
