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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            buttonFacebook.IsEnabled = true;
            buttonHey.IsEnabled = false;

            //buttonHey.Clicked += ButtenHey_Clicked;
            buttonFacebook.Clicked += ButtonFacebook_Clicked;
        }

        private void ButtonFacebook_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

        //private void ButtenHey_Clicked(object sender, EventArgs e)
        //{

        //    //FacebookModel facebooModel = GetProfile().Result;
        //    //App.LoadUser(facebooModel);
        //    //App.Current.MainPage = new NavigationPage(new RootPage()); ;
        //}
    }
}