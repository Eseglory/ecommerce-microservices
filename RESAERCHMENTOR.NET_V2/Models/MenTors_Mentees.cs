using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class MenTors_Mentees
    {
        [Key]
        public int Id { get; set; }

        public string Mentor { get; set; }
        public string Mentee { get; set; }
        public string MenTors_MenteesCreated { get; set; }
    }
}