using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class Expertise
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}