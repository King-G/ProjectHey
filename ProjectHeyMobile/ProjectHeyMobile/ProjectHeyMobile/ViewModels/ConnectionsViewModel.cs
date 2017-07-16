
using ProjectHeyMobile.Views.Chatpages;
using ProjectHeyMobile.Views.Utilitypages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionsViewModel : BaseViewModel
    {
        public ObservableCollection<ConnectionViewModel> Connections { get; set; }
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
        public ConnectionsViewModel(): this(new List<ConnectionViewModel>())
        {

        }
        public ConnectionsViewModel(List<ConnectionViewModel> connections)
        {
            Connections = new ObservableCollection<ConnectionViewModel>(connections);

            SelectConnectionCommand = new Command<ConnectionViewModel>(x => SelectConnection(x));
            AddConnectionCommand = new Command<ConnectionViewModel>(x => AddConnection(x));
            BlockConnectionCommand = new Command<ConnectionViewModel>(x => BlockConnection(x));
            ReportConnectionCommand = new Command<ConnectionViewModel>(async x => await ReportConnection(x));
            ShowHeyFeaturesCommand = new Command<ConnectionViewModel>(async x => await ShowHeyFeatures(x));

        }

        private void AddConnection(ConnectionViewModel connection)
        {
            Connections.Add(connection);
        }
        private void BlockConnection(ConnectionViewModel connection)
        {
            //API (BlockUser) add blocked to users.blocked
            Connections.Remove(connection);
        }
        private async Task ReportConnection(ConnectionViewModel connection)
        {
            //Connections.Remove(connection);
            await App.Main.PageService.PushAsync(new ReportPage());
   
        }
        private async Task ShowHeyFeatures(ConnectionViewModel connection)
        {
            //Get Messages from connection & pass it in ChatPage ctor
            await App.Main.PageService.PushAsync(new HeyFeaturesPage(new HeyFeaturesViewModel(connection)));
    
        }
        private void SelectConnection(ConnectionViewModel connection)
        {
            if (connection == null)
                return;

            SelectedConnection = null;

            //Get Messages
            App.Main.PageService.PushAsync(new ChatPage());

        }
    }
}
