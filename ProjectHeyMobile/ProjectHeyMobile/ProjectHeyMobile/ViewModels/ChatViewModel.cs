
using ProjectHey.DOMAIN;
using ProjectHeyMobile.ChatCommunication;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
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
        
        private IChatServices _chatServices;
        private string _Channel;

        public string Channel
        {
            get { return _Channel; }
            set { SetValue(ref _Channel, value); }
        }


        public ChatViewModel(): this(new List<MessageViewModel>())
        {

        }
        public ChatViewModel(List<MessageViewModel> messages)
        {
            Messages = new ObservableCollection<MessageViewModel>(messages);
            AddMessageCommand = new Command<MessageViewModel>(x => AddMessage(x));
            SelectMessageCommand = new Command<MessageViewModel>(x => SelectMessage(x));
            SendMessageCommand = new Command<MessageViewModel>(async x => await SendMessage(x));
            JoinChannelCommand = new Command<string>(async x => await JoinChannel(x));

            _chatServices = DependencyService.Get<IChatServices>();
            _Channel = "PrivateRoom";
            _chatServices.Connect();
            _chatServices.JoinRoom(_Channel);
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }

        private void _chatServices_OnMessageReceived(object sender, ChatMessage e)
        {
            Message message = new Message()
            {
                Body = e.Message
            };
            //Fill message props
            MessageViewModel messageVM = new MessageViewModel(message);
            AddMessage(messageVM);
        }

        private void AddMessage(MessageViewModel messageVM)
        {
            Messages.Add(messageVM);
        }
        private async Task SendMessage(MessageViewModel messageVM)
        {
            try
            {
                await _chatServices.Send(new ChatMessage { Name = "MobileUser", Message = messageVM.Message.Body }, _Channel);
            }
            catch (System.Exception exception)
            {
                await App.Main.PageService.DisplayAlert("Oops", exception.Message, "Dammit");
            }

        }
        private async Task JoinChannel(string channel)
        {
            _Channel = channel;
            await _chatServices.JoinRoom(channel);

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
