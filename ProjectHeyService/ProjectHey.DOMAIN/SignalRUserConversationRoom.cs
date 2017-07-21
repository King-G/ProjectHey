using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHey.DOMAIN
{
    public class SignalRUserConversationRoom
    {
        public int SignalRUserId { get; set; } //send with Context.User.Identity.Name
        public SignalRUser SignalRUser { get; set; }
        public int SignalRConversationRoomId { get; set; }
        public SignalRConversationRoom SignalRConversationRoom { get; set; }

    }
}
