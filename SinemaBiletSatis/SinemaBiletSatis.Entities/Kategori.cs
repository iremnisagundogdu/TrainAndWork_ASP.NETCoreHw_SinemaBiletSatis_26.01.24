namespace SinemaBiletSatis.Entities
{
    public class Kategori:IEntity
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<FilmKategori>? FilmKategoriler { get; set; }
      
    }
}
