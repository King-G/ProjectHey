using Newtonsoft.Json;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProjectHeyMobile
{
    public partial class App : Application
    {
        public static UserViewModel UserViewModel;

        private bool _isValidStartUp = true;
        private Exception _startUpException = new Exception();

        public App()
        {
            InitializeComponent();

            try
            {
                Current.Properties["HeyUserId"] = 2;
                Current.SavePropertiesAsync();

                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = projectHeyAPI.UserGetById((int)Current.Properties["HeyUserId"]).Result;

                UserViewModel = JsonConvert.DeserializeObject<ProjectHeyAPISingleResponse<UserViewModel>>(response).Value;
            }
            catch (Exception exception)
            {
                _isValidStartUp = false;
                _startUpException = exception;
            }

            if (_isValidStartUp)
            {
                if (UserViewModel == null)
                {
                    MainPage = new NavigationPage(new LoginPage())
                    {
                        Style = (Style)Current.Resources["navigationpageStyle"]
                    };
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage())
                    {
                        Style = (Style)Current.Resources["navigationpageStyle"]
                    };
                   
                }
            }
            else
            {
                MainPage = new NavigationPage(new ErrorPage(_startUpException))
                {
                    Style = (Style)Current.Resources["navigationpageStyle"]
                };
            }     
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
