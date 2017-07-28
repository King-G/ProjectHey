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

        public event EventHandler<SignalRMessage> OnMessageReceived;
        public event EventHandler<int> OnRequestToReconnect;

        public ChatServices()
        {
            _connection = new HubConnection(ProjectHeyAuthentication.ProjectHeyChatEndpoint);
            _proxy = _connection.CreateHubProxy(ProjectHeyAuthentication.ProjectHeyChatHub);
        }

        #region IChatServices implementation

        public async Task ConnectHeyUser(SignalRUser signalRUser)
        {
            try
            {
                await _connection.Start();
                await _proxy.Invoke("ConnectHeyUser", signalRUser);
                _proxy.On("OnMessageReceived", (SignalRMessage signalRMessage) =>
                {
                    if (OnMessageReceived != null)
                        OnMessageReceived(this, signalRMessage);

                });
                _proxy.On("OnRequestToReconnect", (int userId) =>
                {
                    if (OnRequestToReconnect != null)
                        OnRequestToReconnect(this, userId);

                });
            }
            catch (Exception exception)
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
                await App.Current.MainPage.Navigation.PushModalAsync(new ErrorPage(exception));
            }

        }

        public async Task Send(SignalRMessage signalRMessage)
        {
            await _proxy.Invoke("Send", signalRMessage);
        }

        public async Task JoinRoom(int userid, int roomid)
        {
            await _proxy.Invoke("JoinRoom", userid, roomid);
        }
        public async Task LeaveRoom(int userid, int roomid)
        {
            await _proxy.Invoke("LeaveRoom", userid, roomid);
        }

        #endregion
    }

}
