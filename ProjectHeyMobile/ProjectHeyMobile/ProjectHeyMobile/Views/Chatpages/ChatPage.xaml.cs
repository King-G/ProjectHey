using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.ViewModels.Enums;
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

        private ChatViewModel ChatViewModel
        {
            get { return (BindingContext as ChatViewModel); }
            set { BindingContext = value; }
        }
        public ChatPage(ChatViewModel chatVM)
        {
            ChatViewModel = chatVM;
            InitializeComponent();

            ScrollToBottom();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            SignalRMessage signalRMessage = new SignalRMessage()
            {
                CreationDate = DateTime.Now,
                SignalRUserId = App.Main.User.SignalRUser.Id,
                SignalRRoomId = ChatViewModel.SignalRRoom.Id,
                Body = ((Entry)sender).Text
            };

            ChatViewModel.SendMessageCommand.Execute(new MessageViewModel(signalRMessage));

            ((Entry)sender).Text = string.Empty;
        }

        private void ScrollToBottom()
        {
            MessagesListView.ScrollTo(MessagesListView.ItemsSource.Cast<MessageViewModel>().LastOrDefault(), ScrollToPosition.End, true);
        }

        private void MessagesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ChatViewModel.SelectMessageCommand.Execute(e.SelectedItem as MessageViewModel);
        }

        private void MessagesListView_ChildAdded(object sender, ElementEventArgs e)
        {
            ScrollToBottom();
        }
    }
}