using ProjectHey.DOMAIN;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectHey.Web.ProjectHeyAPI
{
    public interface IProjectHeyAPI
    {
        [Get("/signalr/getsignalruserbyid/{id}")]
        Task<string> GetSignalRUserById(int id);

        [Get("/signalr/getsignalrroombyname/{roomname}")]
        Task<string> GetSignalRRoomByName(string roomname);

        [Post("/signalr/createsignalruser")]
        Task<string> CreateSignalRUser([Body(BodySerializationMethod.UrlEncoded)]SignalRUser signalRUser);

        [Post("/signalr/createsignalrconversationroom")]
        Task<string> CreateSignalRConversationRoom([Body(BodySerializationMethod.UrlEncoded)]SignalRConversationRoom signalRConversationRoom);

        [Post("/signalr/deletesignalruserconversationroom")]
        Task<string> DeleteSignalRUserConversationRoom([Body(BodySerializationMethod.UrlEncoded)]SignalRUserConversationRoom signalRUserConversationRoom);

    }
}