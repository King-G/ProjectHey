
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectHeyMobile.ViewModels
{
    public class MessagesViewModel
    {
        public ObservableCollection<MessageViewModel> Messages { get; set; }

        public MessagesViewModel(): this(new List<MessageViewModel>())
        {

        }
        public MessagesViewModel(List<MessageViewModel> messages)
        {
            Messages = new ObservableCollection<MessageViewModel>(messages);
        }

        public void AddMessage(MessageViewModel message)
        {
            Messages.Add(message);
        }
    }
}
