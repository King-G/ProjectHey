using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private async void Profile_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.PushAsync(new ProfilePage());
        }
        private async void AppSetting_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.PushAsync(new AppSettingPage());
        }
        private async void Categories_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.DisplayAlert("Categories", "Coming soon...", "Can't Wait!");
        }
        private async void Blocked_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.DisplayAlert("Blocked users", "Coming soon...", "Can't Wait!");
        }
        private async void About_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.DisplayAlert("About", "www.epicness.com", "Awesome!");
        }
        private async void Feedback_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.DisplayAlert("Feedback", "Give us some feedback", "Will do!");
        }
        private async void Share_Clicked(object sender, System.EventArgs e)
        {
            await App.User.PageService.DisplayAlert("Share", "Sharing is caring", "Aight Captain!");
        }
    }
}