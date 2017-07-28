using ProjectHey.DOMAIN;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectHey.Web.ProjectHeyAPI
{
    public interface IProjectHeyAPISignalR
    {
        [Get("/signalr/getsignalruserbyid/{id}")]
        Task<string> GetSignalRUserById(int id);

        [Get("/signalr/getsignalrroombyid/{id}")]
        Task<string> GetSignalRRoomById(int id);

        [Get("/signalr/getbyuserandroomid/?userid={userid}&roomid={roomid}")]
        Task<string> GetByUserAndRoomId(int userid, int roomid);

        [Post("/signalr/createsignalruser")]
        Task<string> CreateSignalRUser([Body]SignalRUser signalRUser);

        [Post("/signalr/updatesignalruser")]
        Task<string> UpdateSignalRUser([Body]SignalRUser signalRUser);

        [Post("/signalr/createsignalrroom")]
        Task<string> CreateSignalRRoom([Body]SignalRRoom signalRRoom);

        [Post("/signalr/createsignalruserroom")]
        Task<string> CreateSignalRUserRoom([Body]SignalRUserRoom signalRUserRoom);

        [Post("/signalr/deletesignalruserroom")]
        Task<string> DeleteSignalRUserRoom([Body]SignalRUserRoom signalRUserRoom);

        [Post("/signalr/createsignalrmessage")]
        Task<string> CreateSignalRMessage([Body]SignalRMessage signalRMessage);
    }
}