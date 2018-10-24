using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class Research
    {
        [Key]
        public int Id { get; set; }

        #region Research
        public string FileName { get; set; }
        public string AuthorName { get; set; }
        public string ResearchId { get; set; }
        public string RDateCreated { get; set; }
        public string Description { get; set; }
        public string RType { get; set; }
        public string Status { get; set; }
        public bool RStatus1 { get; set; }
        public bool RStatus2 { get; set; }
        public string RTitle { get; set; }
        public string SubTitle { get; set; }


        #endregion
    }
}