using ProjectHeyMobile.ViewModels;
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
    public partial class HeyFeaturesPage : ContentPage
    {
        private HeyFeaturesViewModel HeyFeaturesViewModel
        {
            get { return (BindingContext as HeyFeaturesViewModel); }
            set { BindingContext = value; }
        }
        public HeyFeaturesPage(HeyFeaturesViewModel heyfeaturesviewmodel)
        {
            HeyFeaturesViewModel = heyfeaturesviewmodel;
            InitializeComponent();
        }
    }
}