using Microsoft.AspNet.SignalR.Client;
using ProjectHey.DOMAIN;
using ProjectHeyMobile.Authentication;
using ProjectHeyMobile.ChatCommunication;
using ProjectHeyMobile.Views.Utilitypages;
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
            _connection = new HubConnection(ProjectHeyAuthentication.ProjectHeyChatEndpoint);
            _proxy = _connection.CreateHubProxy(ProjectHeyAuthentication.ProjectHeyChatHub);
        }

        #region IChatServices implementation

        public async Task ConnectHeyUser(int id)
        {
            try
            {
                await _connection.Start();
                await _proxy.Invoke("ConnectHeyUser", id);
                _proxy.On("OnMessageReceived", (string name, string message) =>
                {
                    if (OnMessageReceived != null)
                        OnMessageReceived(this, new ChatMessage() { Name = name, Message = message });

                });
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
                await App.Current.MainPage.Navigation.PushModalAsync(new ErrorPage(exception));
            }

        }

        public async Task Send(ChatMessage message, string roomName)
        {
            await _proxy.Invoke("Send", message.Name, message.Message, roomName);
        }

        public async Task JoinRoom(string roomName)
        {
            await _proxy.Invoke("JoinRoom", roomName);
        }
        public async Task LeaveRoom(string roomName)
        {
            await _proxy.Invoke("LeaveRoom", roomName);
        }

        #endregion
    }

}
