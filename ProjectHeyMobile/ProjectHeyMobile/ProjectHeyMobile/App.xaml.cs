using Amazon;
using Amazon.CognitoIdentity;

using Newtonsoft.Json;
using Plugin.Connectivity;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Rootpages;
using ProjectHeyMobile.Views.Utilitypages;
using Refit;
using System;
using Xamarin.Forms;

namespace ProjectHeyMobile
{
    public partial class App : Application
    {
        public static MainViewModel Main = new MainViewModel();

        public static ProjectHeyAuthentication ProjectHeyAuthentication = new ProjectHeyAuthentication();
       
        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                if (ProjectHeyAuthentication.IsAuthenticated)
                {
                    try
                    {
                        LoadUser();
                        MainPage = new NavigationPage(new RootPage());
                    }
                    catch (Exception ex)
                    {
                        MainPage = new NavigationPage(new ErrorPage(ex));
                    }
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                Exception exception = new Exception("No internet connection..");
                MainPage = new NavigationPage(new ErrorPage(exception));
            }
        }

        public static void LoadUser(FacebookModel FacebookModel = null)
        {
            FacebookModel savedFacebookModel = null;
            if (Current.Properties.ContainsKey("FacebookModel"))
            {
                savedFacebookModel = Current.Properties["FacebookModel"] as FacebookModel;
            }

            if (FacebookModel != null)
            {
                if (savedFacebookModel == null)
                {
                    //First time user
                    Main.User = CreateUser(FacebookModel);
                    Current.Properties["FacebookModel"] = FacebookModel;
                    Current.SavePropertiesAsync();
                }
                else if (!savedFacebookModel.Equals(FacebookModel))
                {
                    //user's facebook is out of sync
                    Main.User = GetSyncedUser(FacebookModel);
                    
                }
                else
                {
                    //user's facebook didn't change.
                    Main.User = GetUserByFacebookId(FacebookModel.user_id);
                }
            }
            else if (savedFacebookModel != null)
            {
                Main.User = GetUserByFacebookId(FacebookModel.user_id);
            }
            else
            {
                Exception exception = new Exception("Trying to load a user that doesn't exist");
                if (App.Current.MainPage == null)
                {
                    Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new ErrorPage(exception));
                }
            }


        }

        private static User GetUserByFacebookId(string user_id)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
            var response = projectHeyAPI.UserGetByFacebookId(Convert.ToInt32(user_id)).Result;

            return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
        }

        private static User GetSyncedUser(FacebookModel facebookModel)
        {
            Current.Properties["FacebookModel"] = facebookModel;
            Current.SavePropertiesAsync();

            User user = GetUserByFacebookId(facebookModel.user_id);

            user = FacebookModelToUser(facebookModel, user);

            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
            var response = projectHeyAPI.SyncUser(user).Result;

            return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
        }

        private static User CreateUser(FacebookModel facebookModel)
        {
            Current.Properties["FacebookModel"] = facebookModel;
            Current.SavePropertiesAsync();

            User user = FacebookModelToUser(facebookModel);

            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
            var response = projectHeyAPI.CreateUser(user).Result;

            return JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
        }

        private static User FacebookModelToUser(FacebookModel facebookModel, User user = null)
        {
            if (user == null)
            {
                user = new User();
            }

            //TO DO -> User properties in DB
            //user.FacebookId = facebookModel.user_id;
            user.Email = facebookModel.email;

            return user;
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //private void backupcode()
        //{
        //    try
        //    {
        //        Current.Properties["HeyUserId"] = 0;
        //        Current.SavePropertiesAsync();

        //        if ((int)Current.Properties["HeyUserId"] == 2)
        //        {
        //            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
        //            var response = projectHeyAPI.UserGetById((int)Current.Properties["HeyUserId"]).Result;

        //            Main.User = JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;
        //        }

        //    }
        //    catch (Exception exception)
        //    {
        //        _isValidStartUp = false;
        //        _startUpException = exception;
        //    }

        //    if (_isValidStartUp)
        //    {
        //        if (Main == null)
        //        {
        //            MainPage = new NavigationPage(new LoginPage());
        //        }
        //        else
        //        {
        //            MainPage = new NavigationPage(new RootPage());
        //        }
        //    }
        //    else
        //    {
        //        MainPage = new NavigationPage(new ErrorPage(_startUpException));
        //    }
        //}
    }
}
