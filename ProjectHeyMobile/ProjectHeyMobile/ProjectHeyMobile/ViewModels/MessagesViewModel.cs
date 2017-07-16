
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class MessagesViewModel : BaseViewModel
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
        public MessagesViewModel(): this(new List<MessageViewModel>())
        {

        }
        public MessagesViewModel(List<MessageViewModel> messages)
        {
            Messages = new ObservableCollection<MessageViewModel>(messages);
            AddMessageCommand = new Command<MessageViewModel>(x => AddMessage(x));
            SelectMessageCommand = new Command<MessageViewModel>(x => SelectMessage(x));
        }

        private void AddMessage(MessageViewModel message)
        {
            Messages.Add(message);
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
