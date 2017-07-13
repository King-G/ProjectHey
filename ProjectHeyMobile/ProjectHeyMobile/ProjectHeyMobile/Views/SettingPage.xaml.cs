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

        private async void AppSetting_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AppSettingPage());
            }
            catch (Exception exception)
            {
                await Navigation.PushAsync(new ErrorPage(exception));
            }
        }
    }
}