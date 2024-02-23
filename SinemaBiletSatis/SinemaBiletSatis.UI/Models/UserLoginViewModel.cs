using System.ComponentModel.DataAnnotations;

namespace SinemaBiletSatis.UI.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Eposta { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Sifre { get; set; }
    }
}
