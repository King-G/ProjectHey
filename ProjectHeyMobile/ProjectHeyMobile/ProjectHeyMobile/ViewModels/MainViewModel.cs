using Newtonsoft.Json;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ViewModels.Service;
using ProjectHeyMobile.Views.Utilitypages;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public readonly IPageService PageService = new PageService();

        private User _user;

        public User User
        {
            get { return _user; }
            set { SetValue(ref _user,  value); }
        }

        #region Methods

        public async Task LoadUser(FacebookModel FacebookModel)
        {
            try
            {
                User user = await GetUserByFacebookId(FacebookModel.user_id);
                if (user == null)
                {
                    //First time user
                    user = await CreateUser(FacebookModel);
                }
                else
                {
                    //Sync user
                    user = await SyncUser(user, FacebookModel);
                }

                this.User = user;

            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }

        private async Task<User> CreateUser(FacebookModel facebookModel)
        {

            try
            {
                User user = await FacebookModelToUser(facebookModel);
                var projectHeyAPI = RestService.For<IProjectHeyAPI>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api") });
                var response = await projectHeyAPI.CreateUser(user);
                //var response = await projectHeyAPI.UserGetById(2);

                if (response == null)
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }


        }
        private async Task<User> GetUserByFacebookId(string user_id)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPI>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api") });
            var response = await projectHeyAPI.UserGetByFacebookId(user_id);

            if (response == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
            }
        }

        private async Task<User> SyncUser(User user, FacebookModel facebookModel)
        {
            user = await FacebookModelToUser(facebookModel, user);
            var projectHeyAPI = RestService.For<IProjectHeyAPI>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api") });
            var response = await projectHeyAPI.SyncUser(user);

            if (response == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
            }
        }

        private async Task<User> FacebookModelToUser(FacebookModel facebookModel, User user = null)
        {
            if (user == null)
            {
                user = new User();
            }

            //TO DO -> User properties in DB
            user.FacebookId = facebookModel.user_id;
            user.FacebookToken = ProjectHeyAuthentication.FacebookToken;

            if (facebookModel.location != null)
            {
                user.CityID = facebookModel.location.id;
                user.CityID = facebookModel.location.name;
            }

            user.Email = facebookModel.email;
            user.Firstname = facebookModel.given_name;
            user.Lastname = facebookModel.family_name;
            user.ProfilePictureURL = facebookModel.picture;

            var myPostion = await App.GetPosition();
            if (myPostion != null)
            {
                ProjectHey.DOMAIN.Structs.Location myLocation = new ProjectHey.DOMAIN.Structs.Location()
                {
                    Latitude = myPostion.Latitude,
                    Longitude = myPostion.Longitude
                };
                user.Location = myLocation;
            }

            switch (facebookModel.gender)
            {
                case "male":
                    user.Gender = ProjectHey.DOMAIN.Enums.Gender.Male;
                    break;
                case "female":
                    user.Gender = ProjectHey.DOMAIN.Enums.Gender.Female;
                    break;
                default:
                    user.Gender = ProjectHey.DOMAIN.Enums.Gender.Unknown;
                    break;
            }

            return user;
        }
        #endregion

    }
}
