using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class Activities
    {
        [Key]
        public int Id { get; set; }

        public string ActivityName { get; set; }
        public int ActivityParentID { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDateCreated { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string Activityowner { get; set; }

    }
}