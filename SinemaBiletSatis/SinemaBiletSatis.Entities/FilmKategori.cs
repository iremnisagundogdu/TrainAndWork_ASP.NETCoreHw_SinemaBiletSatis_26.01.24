namespace SinemaBiletSatis.Entities
{
    public class FilmKategori:IEntity
    {
        public int Id { get; set; }
        public int FilmID { get; set; }
        public int KategoriID { get; set; }

        public Film? Film { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
