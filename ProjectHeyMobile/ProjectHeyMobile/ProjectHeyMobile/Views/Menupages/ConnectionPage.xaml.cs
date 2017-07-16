
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private ObservableCollection<ConnectionViewModel> connections = new ObservableCollection<ConnectionViewModel>();
        public ConnectionPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if(connections.Count == 0)
                listviewConnections_Refreshing(this, new System.EventArgs());

            base.OnAppearing();
        }

        private async void listviewConnections_Refreshing(object sender, System.EventArgs e)
        {
            listviewConnections.IsRefreshing = true;
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = await projectHeyAPI.GetConnectionsViewModelsByUserId(2);

                IEnumerable<ConnectionViewModel> connectionresponse = JsonConvert.DeserializeObject<ProjectHeyAPIMultiResponse<ConnectionViewModel>>(response).Value;

                connections = new ObservableCollection<ConnectionViewModel>(connectionresponse);

                listviewConnections.ItemsSource = connections;
                listviewConnections.IsRefreshing = false;
            }
            catch (System.Exception exception)
            {
                await DisplayAlert("Oops", exception.Message, "OK");
            }
            finally
            {
                listviewConnections.EndRefresh();
            }

        }

        private async void listviewConnections_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                ConnectionViewModel connectionVM = e.SelectedItem as ConnectionViewModel;
                ChatPage chatPage = new ChatPage(new MessagesViewModel());
                await Navigation.PushAsync(chatPage);
            }
            catch (System.Exception exception)
            {
                await DisplayAlert("Oops", exception.Message, "OK");

            }

        }
    }
}