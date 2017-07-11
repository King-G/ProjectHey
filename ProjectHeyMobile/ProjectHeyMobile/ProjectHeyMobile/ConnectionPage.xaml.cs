
using ProjectHeyMobile.Interfaces;
using ProjectHeyMobile.ViewModels;
using Refit;

using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        private ObservableCollection<Connection> connections;
        public ConnectionPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                var projectHeyAPI = RestService.For<IProjectHeyAPI>("http://localhost:5000/api");
                var apiresponse = await projectHeyAPI.GetConnectionsByUserId(2);

                connections = new ObservableCollection<Connection>(apiresponse);

                lvConnections.ItemsSource = connections;
            }
            catch (System.Exception exception)
            {
                Debug.WriteLine(exception);
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