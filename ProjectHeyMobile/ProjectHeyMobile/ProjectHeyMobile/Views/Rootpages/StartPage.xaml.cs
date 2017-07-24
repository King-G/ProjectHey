using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Rootpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            this.Title = "Hey. {Alpha 1.0.0}";
            
            buttonHey.Clicked += ButtenHey_Clicked;
            buttonFacebook.Clicked += ButtonFacebook_Clicked;
        }

        private void ButtonFacebook_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            //PopUpLogin();
        }
        protected override void OnAppearing()
        {
            if (ProjectHeyAuthentication.IsLoggedIn)
            {
                buttonHey.IsVisible = true;
                buttonFacebook.IsVisible = false;
            }
            else
            {
                buttonFacebook.IsVisible = true;
                buttonHey.IsVisible = false;
            }
            base.OnAppearing();

        }
        private void ButtenHey_Clicked(object sender, EventArgs e)
        {
            //Loading screen
            //App.Current.MainPage = new NavigationPage(new LoadingPage());

            //GET INFO | Load App
            //FacebookModel facebooModel = GetProfile().Result;
            //App.LoadUser(facebooModel);

            //SET ROOT PAGE
            App.Current.MainPage = new NavigationPage(new RootPage()); ;
        }
    }
}