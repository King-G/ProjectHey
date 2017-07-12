
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectHeyMobile.Interfaces;
using ProjectHeyMobile.Models;
using ProjectHeyMobile.ViewModels;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        private ObservableCollection<ConnectionViewModel> connections;
        public ConnectionPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
                var response = await projectHeyAPI.GetConnectionsViewModelsByUserId(2);

                IEnumerable<ConnectionViewModel> connections = JsonConvert.DeserializeObject<ProjectHeyAPIResponse<ConnectionViewModel>>(response).Value;
                
                lvConnections.ItemsSource = connections;
            }
            catch (System.Exception exception)
            {
                Debug.WriteLine(exception);
                throw exception;
            }

            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }
    }
}