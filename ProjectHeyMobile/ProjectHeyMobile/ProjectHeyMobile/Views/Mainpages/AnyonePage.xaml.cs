using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels;
using ProjectHeyMobile.Views.Chatpages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeyMobile.Views.Mainpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnyonePage : ContentPage
    {
        public AnyonePage()
        {
            InitializeComponent();
        }

        private async void Anyone_Clicked(object sender, EventArgs e)
        {
            List<MessageViewModel> messages = new List<MessageViewModel>()
            {
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "Hello there, how are you?"
                    }, 0),
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "Good, you?"
                    }, 1),
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "Not much, not much.. Just chillin"
                    }, 0),
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "Did you hear about that new app called 'Hey.'?"
                    }, 0),
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "You should check it out!"
                    }, 0),
                new MessageViewModel(
                    new Message()
                    {
                        CreationDate = DateTime.Now,
                        UserSenderId = 1,
                        UserReceiverId = 2,
                        Body = "Hold on, let me download that"
                    }, 1)
            };

            MessagesViewModel messagesViewModel = new MessagesViewModel(messages);
            await App.Main.PageService.PushAsync(new ChatPage(messagesViewModel));
        }
    }
}