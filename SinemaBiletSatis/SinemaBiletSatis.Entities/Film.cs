namespace SinemaBiletSatis.Entities
{
    public class Film:IEntity
    {
        public int Id { get; set; }
        public string? FilmAdi { get; set; }
        public TimeSpan? Sure { get; set; }
        public string? Yonetmen { get; set; }
        public string? Aciklama { get; set; }
        public bool AltyaziVarMi { get; set; }=false;
        public string? Dil { get; set; }
        public string?  Image { get; set; }
        public ICollection<FilmKategori>? FilmKategoriler { get; set; }
        public ICollection<Gosterim>? Gosterimler { get; set; }

    }
}
