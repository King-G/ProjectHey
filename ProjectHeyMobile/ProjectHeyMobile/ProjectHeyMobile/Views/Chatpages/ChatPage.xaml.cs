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
        public ChatPage() : this(new MessagesViewModel())
        {
         
        }
        public ChatPage(MessagesViewModel messages)
        {
            
            BindingContext = new MessagesViewModel();
            (BindingContext as MessagesViewModel).Messages = messages.Messages;

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
            
            MessageViewModel messageViewModel = new MessageViewModel(message);
            (BindingContext as MessagesViewModel).AddMessage(messageViewModel);

            ((Entry)sender).Text = string.Empty;
            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            messagesListView.ScrollTo(messagesListView.ItemsSource.Cast<MessageViewModel>().LastOrDefault(), ScrollToPosition.End, false);
        }

    }
}