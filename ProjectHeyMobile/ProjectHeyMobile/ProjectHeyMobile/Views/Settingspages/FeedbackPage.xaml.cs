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
	public partial class FeedbackPage : ContentPage
	{
        private FeedbackViewModel FeedbackViewModel
        {
            get { return (BindingContext as FeedbackViewModel); }
            set { BindingContext = value; }
        }
        public FeedbackPage ()
		{
            FeedbackViewModel = new FeedbackViewModel();
            InitializeComponent();
		}
	}
}