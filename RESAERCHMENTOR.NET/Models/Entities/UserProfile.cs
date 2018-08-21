using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESAERCHMENTOR.NET.Models.Entities
{
    public class UserProfile
    {
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
        #region Following
        public string Following { get; set; }
        public string Follower { get; set; }
        public string FollowDate { get; set; }
        #endregion
    }
    public class Follower
    {
        public string UniqueId { get; set; }
        public string FollowerId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}