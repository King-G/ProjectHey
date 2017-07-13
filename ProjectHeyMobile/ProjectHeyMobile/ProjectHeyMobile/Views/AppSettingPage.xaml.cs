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
    public partial class AppSettingPage : ContentPage
    {
        public AppSettingPage()
        {
            BindingContext = App.UserViewModel.Appsetting;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            (BindingContext as AppSettingViewModel).SaveChanges();
            return base.OnBackButtonPressed();
        }
    }
}