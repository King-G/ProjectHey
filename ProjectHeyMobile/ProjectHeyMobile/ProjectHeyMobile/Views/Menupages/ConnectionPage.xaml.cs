
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Chatpages;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Menupages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        private ConnectionsViewModel ConnectionsViewModel
        {
            get { return (BindingContext as ConnectionsViewModel); }
            set { BindingContext = value; }
        }
        public ConnectionPage()
        {
            List<ConnectionViewModel> connections = new List<ConnectionViewModel>();
            foreach (Connection connection in App.Main.User.Connections)
            {
                connections.Add(new ConnectionViewModel(connection));
            }
            ConnectionsViewModel = new ConnectionsViewModel(connections);
            InitializeComponent();

        }
        //public ConnectionPage(ConnectionsViewModel connections)
        //{
        //    ConnectionsViewModel = connections;
        //    InitializeComponent();
        //}
        protected override void OnAppearing()
        {
            if(ConnectionsViewModel.Connections.Count == 0)
                ConnectionsListView_Refreshing(this, new System.EventArgs());

            base.OnAppearing();
        }

        private async void ConnectionsListView_Refreshing(object sender, System.EventArgs e)
        {
            ConnectionsListView.IsRefreshing = true;
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = await projectHeyAPI.GetConnectionsViewModelsByUserId(2);

                IEnumerable<ConnectionViewModel> connectionresponse = JsonConvert.DeserializeObject<ProjectHeyAPIMultiResponse<ConnectionViewModel>>(response).Value;

                ConnectionsViewModel.Connections = new ObservableCollection<ConnectionViewModel>(connectionresponse);

                ConnectionsListView.IsRefreshing = false;
            }
            catch (System.Exception exception)
            {
                await DisplayAlert("Oops", exception.Message, "OK");
            }
            finally
            {
                ConnectionsListView.EndRefresh();
            }

        }

        private void ConnectionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ConnectionsViewModel.SelectConnectionCommand.Execute(e.SelectedItem as ConnectionViewModel);
        }
    }
}