using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESAERCHMENTOR.NET.Models.Entities
{
    public class UserProfile
    {
        public string UniqueId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public string ResearcherType { get; set; }
    }
    public class Follower
    {
        public string UniqueId { get; set; }
        public string FollowerId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}