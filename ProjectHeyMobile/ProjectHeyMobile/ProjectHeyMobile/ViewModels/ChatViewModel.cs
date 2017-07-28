using ProjectHey.DOMAIN;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public SignalRRoom SignalRRoom { get; set; }
        public ObservableCollection<MessageViewModel> Messages { get; set; }
        private MessageViewModel _SelectedMessage;

        public MessageViewModel SelectedMessage
        {
            get { return _SelectedMessage; }
            set { SetValue(ref _SelectedMessage, value); }
        }

        public ICommand SelectMessageCommand { get; private set; }
        public ICommand AddMessageCommand { get; private set; }
        public ICommand SendMessageCommand { get; private set; }
        public ICommand JoinChannelCommand { get; private set; }

        public ChatViewModel(SignalRRoom signalRRoom)
        {
            SignalRRoom = signalRRoom;

            List<MessageViewModel> messages = new List<MessageViewModel>();
            foreach (SignalRMessage signalRMessage in signalRRoom.Messages)
            {
                messages.Add(new MessageViewModel(signalRMessage));
            }
            Messages = new ObservableCollection<MessageViewModel>(messages);

            AddMessageCommand = new Command<MessageViewModel>(x => AddMessage(x));
            SelectMessageCommand = new Command<MessageViewModel>(x => SelectMessage(x));
            SendMessageCommand = new Command<MessageViewModel>(async x => await SendMessage(x));
        }

        private void AddMessage(MessageViewModel messageVM)
        {
            Messages.Add(messageVM);
        }
        private async Task SendMessage(MessageViewModel messageVM)
        {
            try
            {
                AddMessage(messageVM);
                await App.ChatServices.Send(messageVM.Message);
            }
            catch (System.Exception exception)
            {
                await App.Main.PageService.DisplayAlert("Oops", exception.Message, "Dammit");
            }

        }
        private void SelectMessage(MessageViewModel message)
        {
            if (message == null)
                return;

            SelectedMessage = null;

            //App.Main.PageService.PushAsync(new ChatPage(message));
        }
    }
}
