using ProjectHey.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ChatCommunication
{
    public interface IChatServices
    {
        Task ConnectHeyUser(SignalRUser signalRUser);
        Task Send(SignalRMessage signalRMessage);
        Task JoinRoom(int userid, int roomid);
        Task LeaveRoom(int userid, int roomid);
        event EventHandler<SignalRMessage> OnMessageReceived;
        event EventHandler<int> OnRequestToReconnect;
    }
}
