using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Service;
using ProjectHeyMobile.ViewModels.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class UserViewModel
    {
        public readonly IPageService PageService = new PageService();
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ProfilePictureURL { get; set; }
        public Gender Gender { get; set; }
        public Location Location { get; set; }
        public AppSettingViewModel Appsetting { get; set; }
        public string Email { get; set; }
        public bool IsHidden { get; set; }
        public bool IsBanned { get; set; }
        //User can have multiple feedbacks
        public ICollection<FeedbackViewModel> Feedback { get; set; }

        //User can have multiple reported users
        public ICollection<ReportedViewModel> ReportedUsers { get; set; }

        //User can have multiple blocked users
        public ICollection<BlockedViewModel> BlockedUsers { get; set; }

        //User can have multiple connections
        public ICollection<ConnectionViewModel> Connections { get; set; }

        //User can have multiple categories
        public ICollection<UserCategoryViewModel> UserCategory { get; set; }

        //User can have multiple roles
        public ICollection<UserRoleViewModel> UserRole { get; set; }

        //User can have multiple messages
        public ICollection<MessageViewModel> Messages { get; set; }

        //User can watch multiple advertisements
        public ICollection<AdvertisementViewModel> Advertisement { get; set; }

        //User can watch multiple advertisements
        public ICollection<UserAdvertisementViewModel> WatchedAdvertisement { get; set; }

        //User can have multiple providers
        public ICollection<UserProviderViewModel> UserProvider { get; set; }

        
    }
}
