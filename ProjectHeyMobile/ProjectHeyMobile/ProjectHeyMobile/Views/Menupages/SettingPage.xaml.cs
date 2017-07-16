using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private async void Profile_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.PushAsync(new ProfilePage());
        }
        private async void AppSetting_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.PushAsync(new AppSettingPage());
        }
        private async void Categories_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.DisplayAlert("Categories", "Coming soon...", "Can't Wait!");
        }
        private async void Blocked_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.DisplayAlert("Blocked users", "Coming soon...", "Can't Wait!");
        }
        private async void About_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.DisplayAlert("About", "www.epicness.com", "Awesome!");
        }
        private async void Feedback_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.DisplayAlert("Feedback", "Give us some feedback", "Will do!");
        }
        private async void Share_Clicked(object sender, System.EventArgs e)
        {
            await App.Main.PageService.DisplayAlert("Share", "Sharing is caring", "Aight Captain!");
        }
    }
}