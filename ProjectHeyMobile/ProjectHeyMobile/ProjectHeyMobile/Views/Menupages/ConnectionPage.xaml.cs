
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.APICommunication;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Chatpages;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
            ConnectionsViewModel = new ConnectionsViewModel(App.Main.User.Connections.ToList());
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ConnectionsListView_Refreshing(this, new System.EventArgs());
            base.OnAppearing();
        }

        private async void ConnectionsListView_Refreshing(object sender, System.EventArgs e)
        {
            ConnectionsListView.IsRefreshing = true;
            try
            {
                ConnectionsViewModel.RefreshConnectionsCommand.Execute(null);
                ConnectionsListView.IsRefreshing = false;
            }
            catch (Exception exception)
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