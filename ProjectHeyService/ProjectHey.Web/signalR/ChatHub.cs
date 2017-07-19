using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ProjectHey.Web.signalR
{
    public class ChatHub : Hub
    {
        public async Task Subscribe(IEnumerable<string> rooms)
        {
            foreach (var room in rooms)
            {
                await Groups.Add(Context.ConnectionId, room);
            }
        }
        public async Task UnSubscribe(IEnumerable<string> rooms)
        {
            foreach (var room in rooms)
            {
                await Groups.Remove(Context.ConnectionId, room);
            }
        }
        public void Send(string name, string message, string roomname)
        {
            Clients.Group(roomname).OnMessageReceived(name, message);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
        }

        public async Task LeaveRoom(string roomName)
        {
            await Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}