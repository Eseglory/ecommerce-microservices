using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
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
        public bool Gender1 { get; set; }
        public bool Gender2 { get; set; }
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
        #region Activities
        public string ActivityName { get; set; }
        public int ActivityParentID { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDateCreated { get; set; }
        public string OwnerName { get; set; }
        public string ActivityDescription { get; set; }
        public string Activityowner { get; set; }
        #endregion
        #region Message
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string AttachedFileName { get; set; }
        public string MessageDateCreated { get; set; }
        public bool Read { get; set; }
        #endregion
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
        #region Following
        public string Following { get; set; }
        public string Follower { get; set; }
        public string FollowDate { get; set; }
        #endregion
        #region MenTors_Mentees
        public string Mentor { get; set; }
        public string Mentee { get; set; }
        public string MenTors_MenteesCreated { get; set; }
        #endregion
    }
    public class Follower
    {
        public string UniqueId { get; set; }
        public string FollowerId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class MyModelObjects
    {
        public int FollowCount { get; set; }
        public int FollowingCount { get; set; }
        public string MyFullName { get; set; }
        public UserProfile MyProfile { get; set; }
        public List<UserProfile> MyResearch { get; set; }
        public List<UserProfile> FollowList { get; set; }
        public List<UserProfile> FollowingList { get; set; }
        public List<UserProfile> GetAllUsers { get; set; }
        public List<UserProfile> MyMessages { get; set; }
        public List<UserProfile> MyMessageInbox { get; set; }
        public List<UserProfile> MyActivities { get; set; }
        public List<UserProfile> GetOtherUsersResearch { get; set; }
    }
    public class Messages
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string AttachedFileName { get; set; }
        public string MessageDateCreated { get; set; }
        public bool Read { get; set; }
    }
    public class Activities
    {
        public string ActivityName { get; set; }
        public int ActivityParentID { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDateCreated { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string Activityowner { get; set; }

    }
    public class MenTors_Mentees
    {
        public int Id { get; set; }
        public string Mentor { get; set; }
        public string Mentee { get; set; }
        public string MenTors_MenteesCreated { get; set; }
    }
}