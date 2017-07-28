using ProjectHeyMobile.Views.Chatpages;
using ProjectHeyMobile.Views.Utilitypages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using Refit;
using ProjectHeyMobile.APICommunication;
using System.Net.Http;
using ProjectHeyMobile.Authentication;
using Newtonsoft.Json;
using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionsViewModel : BaseViewModel
    {
        public ObservableCollection<Connection> Connections { get; set; }
        private ConnectionViewModel _SelectedConnection;

        public ConnectionViewModel SelectedConnection
        {
            get { return _SelectedConnection; }
            set { SetValue(ref _SelectedConnection, value); }
        }

        public ICommand SelectConnectionCommand { get; private set; }
        public ICommand AddConnectionCommand { get; private set; }
        public ICommand BlockConnectionCommand { get; private set; }
        public ICommand ReportConnectionCommand { get; private set; }
        public ICommand ShowHeyFeaturesCommand { get; private set; }
        public ICommand RefreshConnectionsCommand { get; private set; }
        public ConnectionsViewModel(): this(new List<Connection>())
        {

        }
        public ConnectionsViewModel(List<Connection> connections)
        {
            Connections = new ObservableCollection<Connection>(connections);

            SelectConnectionCommand = new Command<Connection>(x => SelectConnection(x));
            AddConnectionCommand = new Command<Connection>(x => AddConnection(x));
            BlockConnectionCommand = new Command<Connection>(x => BlockConnection(x));
            ReportConnectionCommand = new Command<Connection>(async x => await ReportConnection(x));
            ShowHeyFeaturesCommand = new Command<Connection>(async x => await ShowHeyFeatures(x));
            RefreshConnectionsCommand = new Command<Connection>(async x => await RefreshConnections());
        }

        private async Task RefreshConnections()
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPIConnections>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(ProjectHeyAuthentication.ProjectHeyAPIEndpoint) });
            var response = await projectHeyAPI.GetAllByUserId(App.Main.User.Id);

            IEnumerable<Connection> connectionresponse = JsonConvert.DeserializeObject<APIMultiResponse<Connection>>(response).Value;

            Connections = new ObservableCollection<Connection>(connectionresponse);
        }

        private void AddConnection(Connection connection)
        {
            Connections.Add(connection);
        }
        private void BlockConnection(Connection connection)
        {
            //API (BlockUser) add blocked to users.blocked
            Connections.Remove(connection);
        }
        private async Task ReportConnection(Connection connection)
        {
            //Connections.Remove(connection);
            await App.Main.PageService.PushAsync(new ReportPage());
   
        }
        private async Task ShowHeyFeatures(Connection connection)
        {
            //Get Messages from connection & pass it in ChatPage ctor
            await App.Main.PageService.PushAsync(new HeyFeaturesPage(new HeyFeaturesViewModel(connection)));

    
        }
        private void SelectConnection(Connection connection)
        {
            if (connection == null)
                return;

            SelectedConnection = null;

            //Get Messages
            App.Main.PageService.PushAsync(new ChatPage());

        }
    }
}
