using ProjectHey.DOMAIN;
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
	public partial class CategoriesPage : ContentPage
	{
        private CategoriesViewModel CategoriesViewModel
        {
            get { return (BindingContext as CategoriesViewModel); }
            set { BindingContext = value; }
        }
        public CategoriesPage()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (UserCategory usercategory in App.Main.User.UserCategory)
            {
                categories.Add(new CategoryViewModel(usercategory.Category));
            }
            CategoriesViewModel = new CategoriesViewModel(categories);
            InitializeComponent();

        }
        //public ConnectionPage(ConnectionsViewModel connections)
        //{
        //    ConnectionsViewModel = connections;
        //    InitializeComponent();
        //}
        protected override void OnAppearing()
        {
            if (CategoriesViewModel.Categories.Count == 0)
                CategoriesListView_Refreshing(this, new System.EventArgs());

            base.OnAppearing();
        }

        private async void CategoriesListView_Refreshing(object sender, System.EventArgs e)
        {
            CategoriesListView.IsRefreshing = true;
            //try
            //{
            //    var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
            //    var response = await projectHeyAPI.GetConnectionsViewModelsByUserId(2);

            //    IEnumerable<ConnectionViewModel> connectionresponse = JsonConvert.DeserializeObject<ProjectHeyAPIMultiResponse<ConnectionViewModel>>(response).Value;

            //    ConnectionsViewModel.Connections = new ObservableCollection<ConnectionViewModel>(connectionresponse);

            //    BlockedListView.IsRefreshing = false;
            //}
            //catch (System.Exception exception)
            //{
            //    await DisplayAlert("Oops", exception.Message, "OK");
            //}
            //finally
            //{
            //}

            CategoriesListView.EndRefresh();

        }

        private void CategoriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CategoriesViewModel.SelectCategoryCommand.Execute(e.SelectedItem as CategoryViewModel);
        }
    }
}