namespace SinemaBiletSatis.Entities
{
    public class Bilet:IEntity
    {
        public int Id { get; set; }
        public int GosterimID { get; set; }
        public int KullaniciID { get; set; } // Kullanıcının biletleri
        public string KoltukNumarasi { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal Fiyat { get; set; }
        public Gosterim? Gosterim { get; set; }
        public Kullanici? Kullanici { get; set; } // Bileti satın alan kullanıcı
    }
}
