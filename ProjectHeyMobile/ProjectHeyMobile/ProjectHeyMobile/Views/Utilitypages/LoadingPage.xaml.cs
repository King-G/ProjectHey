using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Utilitypages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();

            var loadingImageUrl = "http://www.mutatemundum.com/LoadingPage.html";

            var webView = new WebView
            {
                Source = loadingImageUrl,
                HeightRequest = 1
            };
            Content = webView;
        }
    }
}