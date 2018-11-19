using RESAERCHMENTOR.NET_V2.ViewModels;
using System.Collections.Generic;

namespace RESAERCHMENTOR.NET_V2.Models
{
    public class MyModelObjects
    {
        public int FollowCount { get; set; }
        public int FollowingCount { get; set; }
        public string MyFullName { get; set; }
        public UserProfileViewModel MyProfile { get; set; }
        public Messages MyMessageDetailInbox { get; set; }
        public DashBoard DashBoardDetail { get; set; }
        public List<UserProfileViewModel> MyResearch { get; set; }
        public List<UserProfileViewModel> FollowList { get; set; }
        public List<UserProfileViewModel> FollowingList { get; set; }
        public List<UserProfileViewModel> GetAllUsers { get; set; }
        public List<UserProfileViewModel> MyMessages { get; set; }
        public List<UserProfileViewModel> MyMessageInbox { get; set; }
        public List<UserProfileViewModel> MyActivities { get; set; }
        public List<UserProfileViewModel> GetOtherUsersResearch { get; set; }


        public List<UserProfileViewModel> GetAllUsersForUserPro { get; set; }
    }
}