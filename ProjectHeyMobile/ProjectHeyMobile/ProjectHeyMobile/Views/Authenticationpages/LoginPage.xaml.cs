using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Authenticationpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Facebook_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new MainPage())
            //{
            //    Style = (Style)Application.Current.Resources["navigationpageStyle"]
            //};
        }
    }
}