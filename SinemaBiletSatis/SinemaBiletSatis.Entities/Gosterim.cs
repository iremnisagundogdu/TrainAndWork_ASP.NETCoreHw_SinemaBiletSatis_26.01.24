namespace SinemaBiletSatis.Entities
{
    public class Gosterim : IEntity
    {
        public int Id { get; set; }
        public int FilmID { get; set; }
        public int SalonID { get; set; }
        public DateTime GosterimTarihi { get; set; }
        public DateTime GosterimSaati { get; set; }

        public Film? Film { get; set; }
        public Salon? Salon { get; set; }
        public ICollection<Bilet>? Biletler { get; set; }
    }
}
