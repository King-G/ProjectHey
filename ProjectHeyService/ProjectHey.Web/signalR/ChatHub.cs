using System;

using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Refit;
using ProjectHey.Web.ProjectHeyAPI;
using Newtonsoft.Json;
using ProjectHey.DOMAIN;

namespace ProjectHey.Web.signalR
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string roomName)
        {
            Clients.Group(roomName).OnMessageReceived(name, message);
        }

        public async Task ConnectHeyUser(int id)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");
            var response = await projectHeyAPI.GetSignalRUserById(id);

            //RetreiveUser
            SignalRUser signalRUser = JsonConvert.DeserializeObject<APISingleResponse<SignalRUser>>(response).Value;

            // If user does not exist in database, disconnect user.
            if (signalRUser == null)
            {
                await base.OnDisconnected(true);
            }
            else
            {
                // Add to each assigned group.
                foreach (var item in signalRUser.Rooms)
                {
                    await Groups.Add(Context.ConnectionId, item.SignalRConversationRoom.RoomName);
                }
            }
        }
        
        public async Task JoinRoom(string roomName)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");

            var responseUser = projectHeyAPI.GetSignalRUserById(Convert.ToInt32(Context.User.Identity.Name)).Result;
            var responseRoom = projectHeyAPI.GetSignalRRoomByName(roomName).Result;

            SignalRUser signalRUser = JsonConvert.DeserializeObject<APISingleResponse<SignalRUser>>(responseUser).Value;
            SignalRConversationRoom room = JsonConvert.DeserializeObject<APISingleResponse<SignalRConversationRoom>>(responseRoom).Value;

            if (room == null)
            {
                room = new SignalRConversationRoom()
                {
                    RoomName = roomName,
                };
            }
            room.Users.Add(new SignalRUserConversationRoom()
            {
                SignalRUser = signalRUser,
                SignalRConversationRoom = room
            });

            var creationresponse = projectHeyAPI.CreateSignalRConversationRoom(room).Result;
            await Groups.Add(Context.ConnectionId, roomName);

        }
        public async Task LeaveRoom(string roomName)
        {
            var projectHeyAPI = RestService.For<IProjectHeyAPI>("https://qg2v8wkg9k.execute-api.eu-west-2.amazonaws.com/Prod/api");

            var responseUser = projectHeyAPI.GetSignalRUserById(Convert.ToInt32(Context.User.Identity.Name)).Result;
            var responseRoom = projectHeyAPI.GetSignalRRoomByName(roomName).Result;

            SignalRUser signalRUser = JsonConvert.DeserializeObject<APISingleResponse<SignalRUser>>(responseUser).Value;
            SignalRConversationRoom room = JsonConvert.DeserializeObject<APISingleResponse<SignalRConversationRoom>>(responseRoom).Value;

            if (room != null)
            {
                SignalRUserConversationRoom userroom = new SignalRUserConversationRoom();
                userroom.SignalRConversationRoom = room;
                userroom.SignalRUser = signalRUser;

                var deletion = projectHeyAPI.DeleteSignalRUserConversationRoom(userroom).Result;
                await Groups.Remove(Context.ConnectionId, roomName);
            }
        }

    }
}