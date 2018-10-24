using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string AttachedFileName { get; set; }
        public string MessageDateCreated { get; set; }
        public bool Read { get; set; }
        public string FromImage { get; set; }
    }
}