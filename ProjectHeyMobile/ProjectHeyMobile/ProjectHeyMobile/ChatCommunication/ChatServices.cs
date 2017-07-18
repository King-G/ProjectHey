using Microsoft.AspNet.SignalR.Client;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.ChatCommunication;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatServices))]
namespace ProjectHeyMobile.ChatCommunication
{
    public class ChatServices : IChatServices
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public event EventHandler<ChatMessage> OnMessageReceived;

        public ChatServices()
        {
            _connection = new HubConnection("http://projecthey.eu-west-2.elasticbeanstalk.com/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        #region IChatServices implementation

        public async Task Connect()
        {
            await _connection.Start();
            _proxy.On("OnMessageReceived", (string name, string message) =>
            {
                if (OnMessageReceived != null)
                     OnMessageReceived(this, new ChatMessage(){ Name = name, Message = message});
               
            });
        }

        public async Task Send(ChatMessage message, string roomName)
        {
            await _proxy.Invoke("Send", message.Name, message.Message, roomName);
        }

        public async Task JoinRoom(string roomName)
        {
            await _proxy.Invoke("JoinRoom", roomName);
        }

        #endregion
    }

}
