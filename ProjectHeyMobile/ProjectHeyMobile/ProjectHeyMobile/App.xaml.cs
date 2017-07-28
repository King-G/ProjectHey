using Plugin.Connectivity;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ChatCommunication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Rootpages;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectHeyMobile
{
    public partial class App : Application
    {
        public static MainViewModel Main = new MainViewModel();
        public static FacebookModel FacebookModel = new FacebookModel();

        public static ProjectHeyAuthentication ProjectHeyAuthentication = new ProjectHeyAuthentication();
        public static IChatServices ChatServices = DependencyService.Get<IChatServices>();
        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                ChatServices.OnMessageReceived += ChatServices_OnMessageReceived;
                ChatServices.OnRequestToReconnect += ChatServices_OnRequestToReconnect;
                MainPage = new NavigationPage(new StartPage());
            }
            else
            {
                Exception exception = new Exception("No internet connection..");
                MainPage = new NavigationPage(new ErrorPage(exception));
            }
        }

        private void ChatServices_OnRequestToReconnect(object sender, int e)
        {
            if (e == App.Main.User.Id)
            {
                ChatServices.ConnectHeyUser(App.Main.User.SignalRUser);
            }
        }

        private void ChatServices_OnMessageReceived(object sender, SignalRMessage e)
        {
            App.Current.MainPage.DisplayAlert(e.SignalRUser.User.Username, e.Body, "Reply");
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
                
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                if (position == null)
                {
                    position = await locator.GetLastKnownLocationAsync();
                }
                return position;
            }
            catch (Exception ex)
            {
                 await App.Current.MainPage.DisplayAlert("Something went wrong getting your position", ex.Message, "I'll check if my location is turned on");
                 return null;
            }
        }
    }
}
