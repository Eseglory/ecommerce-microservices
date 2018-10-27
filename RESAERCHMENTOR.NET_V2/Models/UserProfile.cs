using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int UId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Degree { get; set; }
        public string CNumber { get; set; }
        public string BDate { get; set; }
        public string Gender { get; set; }
        public string OwnersId { get; set; }
        public string DateCreated { get; set; }
        public string ConfirmationCode { get; set; }
        public byte[] ProfilePics { get; set; }
        public string ProfilePicsName { get; set; }
        public string FollowState { get; set; }
        public bool IsConfirmed { get; set; }
        public string Country { get; set; }
        public string WhoYouAre { get; set; }
        public string Institution { get; set; }
        public string Qualification { get; set; }
        public string Expertise { get; set; }
        public string Specialty { get; set; }
        public string Interest { get; set; }
        public string fieldExpertise { get; set; }
        public string WillingToBe { get; set; }
        public string MentorCategory { get; set; }
        [Required]
        public IEnumerable<Countries> Countries { get; set; }
    }
}