using ProjectHeyMobile.Views.Settingspages;
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
            await App.Main.PageService.PushAsync(new ProfilePage());
        }
        private async void AppSetting_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new AppSettingPage());
        }
        private async void Categories_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new CategoriesPage());
        }
        private async void Blocked_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new BlockedPage());
        }
        private async void About_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new AboutPage());
        }
        private async void Feedback_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new FeedbackPage());
        }
        private async void Share_Clicked(object sender, EventArgs e)
        {
            await App.Main.PageService.PushAsync(new SharePage());
        }
    }
}