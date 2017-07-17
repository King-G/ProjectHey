using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Chatpages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChannelSearchPage : ContentPage
	{
        private CategoriesViewModel CategoriesViewModel
        {
            get { return (BindingContext as CategoriesViewModel); }
            set { BindingContext = value; }
        }
        public ChannelSearchPage()
        {
            //Replace with online TOP 10 categories
            List<CategoryViewModel> categories = GetCategories();
            CategoriesViewModel = new CategoriesViewModel(categories);
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CategoryViewModel> categories = GetCategories();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                CategoriesViewModel = new CategoriesViewModel(categories);
            }
            else
            {
                categories = categories.Where(x => x.Category.Name.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
                categories = categories.OrderBy(x => x.Category.Name.ToLower().StartsWith(e.NewTextValue.ToLower())).ToList();
                CategoriesViewModel = new CategoriesViewModel(categories);
            }
        }
        private List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (UserCategory usercategory in App.Main.User.UserCategory) //Category cat in GetCategories()
            {
                categories.Add(new CategoryViewModel(usercategory.Category));
            }
            categories.Add(new CategoryViewModel(new Category() { Name = "Bazinka" }));
            categories.Add(new CategoryViewModel(new Category() { Name = "Whoppaa" }));
            categories.Add(new CategoryViewModel(new Category() { Name = "Shazaaaam" }));

            return categories;
        }
        private void CategoriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CategoriesViewModel.SelectChannelCommand.Execute(e.SelectedItem as CategoryViewModel);
        }
    }
}