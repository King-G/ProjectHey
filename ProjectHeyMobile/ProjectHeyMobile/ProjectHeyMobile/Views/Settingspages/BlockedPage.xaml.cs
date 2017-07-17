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
	public partial class BlockedPage : ContentPage
	{
        private BlockedsViewModel BlockedsViewModel
        {
            get { return (BindingContext as BlockedsViewModel); }
            set { BindingContext = value; }
        }
        public BlockedPage()
        {
            List<BlockedViewModel> blockeds = new List<BlockedViewModel>();
            foreach (Blocked block in App.Main.User.BlockedUsers)
            {
                blockeds.Add(new BlockedViewModel(block));
            }
            BlockedsViewModel = new BlockedsViewModel(blockeds);
            InitializeComponent();

        }
        //public ConnectionPage(ConnectionsViewModel connections)
        //{
        //    ConnectionsViewModel = connections;
        //    InitializeComponent();
        //}
        protected override void OnAppearing()
        {
            if (BlockedsViewModel.Blockeds.Count == 0)
                BlockedListView_Refreshing(this, new System.EventArgs());

            base.OnAppearing();
        }

        private async void BlockedListView_Refreshing(object sender, System.EventArgs e)
        {
            BlockedListView.IsRefreshing = true;
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

            BlockedListView.EndRefresh();

        }

        private void BlockedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BlockedsViewModel.SelectBlockedCommand.Execute(e.SelectedItem as ConnectionViewModel);
        }
    }
}