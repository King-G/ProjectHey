using Amazon;
using Amazon.CognitoIdentity;

using Newtonsoft.Json;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Mainpages;
using Refit;
using System;
using Xamarin.Forms;

namespace ProjectHeyMobile
{
    public partial class App : Application
    {
        public static MainViewModel Main;

        public static HeyAuthentication HeyAuthentication = new HeyAuthentication();

        public static bool IsValidStartup = true;
        public static Exception StartUpException = new Exception();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public static void LoadUser()
        {
            try
            {
                Current.Properties["HeyUserId"] = 2;
                Current.SavePropertiesAsync();

                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = projectHeyAPI.UserGetById((int)Current.Properties["HeyUserId"]).Result;

                Main.User = JsonConvert.DeserializeObject<APISingleResponse<User>>(response).Value;

            }
            catch (Exception exception)
            {
                IsValidStartup = false;
                StartUpException = exception;
            }
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
