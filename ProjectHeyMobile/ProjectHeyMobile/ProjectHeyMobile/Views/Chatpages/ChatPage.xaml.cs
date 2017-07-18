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
        public ChatPage() : this(new ChatViewModel())
        {
         
        }
        public ChatPage(ChatViewModel chatVM)
        {
            ChatViewModel = chatVM;
            InitializeComponent();

            ScrollToBottom();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            Message message = new Message()
            {
                CreationDate = DateTime.Now,
                UserSenderId = App.Main.User.Id,
                UserReceiverId = 2,
                Body = ((Entry)sender).Text
            };

            ChatViewModel.SendMessageCommand.Execute(new MessageViewModel(message));

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