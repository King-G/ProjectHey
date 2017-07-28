using ProjectHey.DOMAIN;
using ProjectHeyMobile.ViewModels.Enums;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private SignalRMessage message;
        private MessageType _MessageType;
        private Color _Color;
         
        public MessageViewModel(SignalRMessage message)
        {
            this.message = message;
            
            if (Message.SignalRUserId == App.Main.User.SignalRUser.Id)
            {
                _Color = Color.FromHex("#FFFFFF");
                _MessageType = MessageType.Received;
            }
            else
            {
                _Color = Color.FromHex("#A0522D");
                _MessageType = MessageType.Send;
            }
        }
        public SignalRMessage Message
        {
            get { return message; }
            set { SetValue(ref message, value); }
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