using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels.Enums;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private string _Message;
        private MessageType _MessageType;
        private Color _Color;
         
        public MessageViewModel(string Message)
        {
            _Message = Message;
            _Color = Color.FromHex("#A0522D");
            //if (Message.SignalRUser.UserId == App.Main.User.Id)
            //{
            //    _MessageType = MessageType.Received;
            //}
            //else
            //{
            //    _MessageType = MessageType.Send;
            //}
        }
        public string Message
        {
            get { return _Message; }
            set { SetValue(ref _Message, value); }
        }
        public MessageType MessageType
        {
            get { return _MessageType; }
            set { SetValue(ref _MessageType, value); }
        }
        public Color Color
        {
            get { return _Color; }
            set { SetValue(ref _Color, value); }
        }
    }
}