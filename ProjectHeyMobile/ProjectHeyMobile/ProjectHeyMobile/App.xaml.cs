using Amazon;
using Amazon.CognitoIdentity;

using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Rootpages;
using ProjectHeyMobile.Views.Utilitypages;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectHeyMobile
{
    public partial class App : Application
    {
        public static MainViewModel Main = new MainViewModel();
        public static FacebookModel FacebookModel = new FacebookModel();

        public static ProjectHeyAuthentication ProjectHeyAuthentication = new ProjectHeyAuthentication();
        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NavigationPage(new StartPage());
            }
            else
            {
                Exception exception = new Exception("No internet connection..");
                MainPage = new NavigationPage(new ErrorPage(exception));
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

        public static async Task<Position> GetPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                return await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            }
            catch (Exception ex)
            {
                 await App.Current.MainPage.DisplayAlert("Something went wrong getting your position", ex.Message, "I'll check if my location is turned on");
                 return null;
            }
        }
    }
}
