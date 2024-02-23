using System.ComponentModel.DataAnnotations;

namespace SinemaBiletSatis.Entities
{
    public class Rol:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
    }
}
