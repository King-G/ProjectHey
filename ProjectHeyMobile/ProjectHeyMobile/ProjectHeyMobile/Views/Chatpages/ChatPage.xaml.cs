using ProjectHeyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Chatpages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
        ObservableCollection<MessageViewModel> _messages;

        public ChatPage(ICollection<MessageViewModel> messages)
        {
            InitializeComponent();
            _messages = new ObservableCollection<MessageViewModel>(messages);
        }

        public async Task ScrollToBottom()
        {
            await messageScrollView.ScrollToAsync(0, messageScrollView.Height, false);
        }
    }
}