using System;

using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Refit;
using ProjectHey.Web.ProjectHeyAPI;
using Newtonsoft.Json;
using ProjectHey.DOMAIN;
using System.Net.Http;

namespace ProjectHey.Web.signalR
{
    public class ChatHub : Hub
    {
        public void Send(SignalRMessage signalRMessage)
        {
            Clients.Group(signalRMessage.SignalRRoomId.ToString()).OnMessageReceived(signalRMessage);
        }
        public void RequestToReconnectToUserId(int userId)
        {
            Clients.Group("ChatNotifications").OnRequestToReconnect(userId);
        }
        public async Task ConnectHeyUser(SignalRUser signalRUser)
        {
            // If user does not exist in database, disconnect user.
            if (signalRUser == null)
            {
                await base.OnDisconnected(true);
            }
            else
            {
                await Groups.Add(Context.ConnectionId, "ChatNotifications");
                // Add to each assigned group.
                foreach (var item in signalRUser.Rooms)
                {
                    await Groups.Add(Context.ConnectionId, item.SignalRRoomId.ToString());
                }
            }
        }
        
        public async Task JoinRoom(int userid, int roomid)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPISignalR>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(ProjectHeyAuthentication.ProjectHeyAPIEndpoint) });

            var responseUserRoom = projectHeyAPI.GetByUserAndRoomId(userid, roomid).Result;
            SignalRUserRoom signalRUserRoom = JsonConvert.DeserializeObject<APISingleResponse<SignalRUserRoom>>(responseUserRoom).Value;

            if (signalRUserRoom == null)
            {
                signalRUserRoom = new SignalRUserRoom()
                {
                    SignalRUserId = userid,
                    SignalRRoomId = roomid
                };
                var responseCreateUserRoom = projectHeyAPI.CreateSignalRUserRoom(signalRUserRoom).Result;
                signalRUserRoom = JsonConvert.DeserializeObject<APISingleResponse<SignalRUserRoom>>(responseCreateUserRoom).Value;
            }
            
            await Groups.Add(Context.ConnectionId, signalRUserRoom.SignalRRoomId.ToString());

        }
        public async Task LeaveRoom(int userid, int roomid)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPISignalR>(new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(ProjectHeyAuthentication.ProjectHeyAPIEndpoint) });

            var responseUserRoom = projectHeyAPI.GetByUserAndRoomId(userid, roomid).Result;
            SignalRUserRoom signalRUserRoom = JsonConvert.DeserializeObject<APISingleResponse<SignalRUserRoom>>(responseUserRoom).Value;

            if (signalRUserRoom != null)
            {
                var deletion = projectHeyAPI.DeleteSignalRUserRoom(signalRUserRoom).Result;
                await Groups.Remove(Context.ConnectionId, signalRUserRoom.SignalRRoomId.ToString());
            }
        }



    }
}