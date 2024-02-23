namespace SinemaBiletSatis.Entities
{
    public class Salon:IEntity
    {
        public int Id { get; set; }
        public int SinemaID { get; set; }
        public string SalonAdi { get; set; }
        public int KoltukSayisi { get; set; }
        public Sinema? Sinema { get; set; }
        public ICollection<Gosterim>? Gosterimler { get; set; }
    }
}
