using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinemaBiletSatis.Entities
{
    public class Kullanici:IEntity 
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        [Required(ErrorMessage ="{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
        [Display(Name = "Soy Adı")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Eposta { get; set; }
        [Display(Name = "Kullanıcı Adı")]
       
        public string? KullaniciAdi { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Sifre { get; set; }
        public bool? AktifMi { get; set; }
        [Display(Name="Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        public int? RolId { get; set; }
        public virtual Rol? Rol { get; set; }
        public ICollection<Bilet>? Biletler { get; set; } // Kullanıcı-Bilet 
    }
}
