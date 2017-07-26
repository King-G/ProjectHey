using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHey.DOMAIN
{
    public class SignalRUserRoom
    {
        public int SignalRUserId { get; set; } //send with Context.User.Identity.Name
        public SignalRUser SignalRUser { get; set; }
        public int SignalRRoomId { get; set; }
        public SignalRRoom SignalRRoom { get; set; }

    }
}
