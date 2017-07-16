using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels.Enums;
using System.Collections.ObjectModel;

namespace ProjectHeyMobile.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private Message _Message;
        private int _MessagePosition;
        private string _ColorHex;

        public MessageViewModel(Message Message)
        {
            _Message = Message;
            _ColorHex = "#A0522D";
            if (Message.UserReceiverId == App.Main.User.Id)
            {
                _MessagePosition = 1;
            }
            else
            {
                _MessagePosition = 0;
            }
        }
        public Message Message
        {
            get { return _Message; }
            set { SetValue(ref _Message, value); }
        }
        public int MessagePosition
        {
            get { return _MessagePosition; }
            set { SetValue(ref _MessagePosition, value); }
        }
        public string ColorHex
        {
            get { return _ColorHex; }
            set { SetValue(ref _ColorHex, value); }
        }
    }
}