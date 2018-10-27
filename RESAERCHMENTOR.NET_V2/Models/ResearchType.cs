using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class ResearchType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}