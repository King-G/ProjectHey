using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
        private ConnectionViewModel connectionVM = new ConnectionViewModel();
        private ObservableCollection<MessageViewModel> messages = new ObservableCollection<MessageViewModel>();
        //public ChatPage()
        //{
        //    InitializeComponent();
        //}
        public ChatPage(ConnectionViewModel connectionVM)
        {
            InitializeComponent();
            this.connectionVM = connectionVM;
            Title = connectionVM.Username;
        }

        public async Task ScrollToBottom()
        {
            await messageScrollView.ScrollToAsync(0, messageScrollView.Height, false);
        }
    }
}