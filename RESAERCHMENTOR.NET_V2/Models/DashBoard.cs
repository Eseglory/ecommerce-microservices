using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class DashBoard
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public string ResearchId { get; set; }
        public string RTitle { get; set; }
        public string FileName { get; set; }
        public string RType { get; set; }

    }
}