using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Settingspages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettingPage : ContentPage
    {
        private AppSettingViewModel AppSettingViewModel
        {
            get { return (BindingContext as AppSettingViewModel); }
            set { BindingContext = value; }
        }
        public AppSettingPage()
        {
            AppSettingViewModel = new AppSettingViewModel(App.Main.User.Appsetting);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            AppSettingViewModel.SaveChangesCommand.Execute(null);
            base.OnDisappearing();
        }

        private void sliderMaximumConnections_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderMaximumConnections.Value = sliderStepByValue(e.NewValue, 1.0);
        }
        private void sliderRadius_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderRadius.Value = sliderStepByValue(e.NewValue, 100.0);

        }
        private double sliderStepByValue(double value, double stepvalue)
        {
            var newStep = Math.Round(value / stepvalue);
            return (newStep * stepvalue);
        }


    }
}