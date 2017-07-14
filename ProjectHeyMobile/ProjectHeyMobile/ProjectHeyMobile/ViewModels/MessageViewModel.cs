using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private Message _Message;

        public MessageViewModel(Message Message)
        {
            _Message = Message;
        }
        public Message Message
        {
            get { return _Message; }
            set { SetValue(ref _Message, value); }
        }
    }
}