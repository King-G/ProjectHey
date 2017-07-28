using ProjectHeyMobile.Views.Settingspages;
using ProjectHeyMobile.Views.Utilitypages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Menupages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }
        private async void Profile_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new ProfilePage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void AppSetting_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new AppSettingPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void Categories_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new CategoriesPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void Blocked_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new BlockedPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void About_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new AboutPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void Feedback_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new FeedbackPage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
        private async void Share_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Main.PageService.PushAsync(new SharePage());
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ErrorPage(exception));
            }
        }
    }
}