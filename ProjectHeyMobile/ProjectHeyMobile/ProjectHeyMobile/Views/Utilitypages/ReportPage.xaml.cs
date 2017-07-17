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
    public partial class ReportPage : ContentPage
    {
        private ReportViewModel ReportViewModel
        {
            get { return (BindingContext as ReportViewModel); }
            set { BindingContext = value; }
        }
        public ReportPage()
        {
            ReportViewModel = new ReportViewModel(4);
            InitializeComponent();
        }
    }
}