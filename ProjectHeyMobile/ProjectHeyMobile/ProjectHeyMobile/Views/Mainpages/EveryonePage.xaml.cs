using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Mainpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EveryonePage : ContentPage
    {
        private CategoriesViewModel CategoriesViewModel
        {
            get { return (BindingContext as CategoriesViewModel); }
            set { BindingContext = value; }
        }
        public EveryonePage()
        {
            //List<CategoryViewModel> categories = new List<CategoryViewModel>();
            //foreach (UserCategory usercategory in App.Main.User.UserCategory)
            //{
            //    categories.Add(new CategoryViewModel(usercategory.Category));
            //}
            CategoriesViewModel = new CategoriesViewModel();
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void CategoriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CategoriesViewModel.SelectChannelCommand.Execute(e.SelectedItem as CategoryViewModel);
        }
    }
}