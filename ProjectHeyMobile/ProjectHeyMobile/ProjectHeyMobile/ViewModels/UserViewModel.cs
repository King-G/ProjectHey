using Newtonsoft.Json;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Service;
using ProjectHeyMobile.ViewModels.Structs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public readonly IPageService PageService = new PageService();

        #region Properties
        public int Id { get; set; }

        public string Username { get; private set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ActivityDate { get; set; }

        public string ProfilePictureURL { get; set; }

        public Gender Gender { get; set; }
        public Location Location { get; set; }

        public AppSettingViewModel Appsetting { get; set; }

        public string Email { get; set; }

        public bool IsHidden { get; set; } = false;

        public bool IsBanned { get; set; } = false;

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
        #endregion

        #region Methods
        public async Task SaveChangesAsync()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = await projectHeyAPI.SyncUser(this);
                UserViewModel userSynced = JsonConvert.DeserializeObject<ProjectHeyAPISingleResponse<UserViewModel>>(response).Value;
                if (userSynced != null)
                {
                    App.User = userSynced;
                    await PageService.DisplayAlert("Done", "Changes were saved", "OK");
                }
                else
                {
                    await PageService.DisplayAlert("Oops", "Something went wrong trying to sync", "OK");
                }
            }
            catch (Exception exception)
            {
                await PageService.DisplayAlert("Oops", exception.Message, "OK");
            }
        } 
        #endregion

    }
}
