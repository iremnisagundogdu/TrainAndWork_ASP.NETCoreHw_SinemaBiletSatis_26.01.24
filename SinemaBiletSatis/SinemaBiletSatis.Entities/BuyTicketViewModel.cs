using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaBiletSatis.Entities
{
    public class BuyTicketViewModel
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public int UserId { get; set; }
        public string? SeatNumber { get; set; }
        public string? UserName { get; set; }
        public decimal? Price { get; set; }
        // Diğer gerekli bilgileri ekleyebilirsiniz
    }
}
