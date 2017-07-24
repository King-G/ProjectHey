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
        Task ConnectHeyUser(int id);
        Task Send(ChatMessage message, string roomName);
        Task JoinRoom(string roomName);
        Task LeaveRoom(string roomName);
        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
