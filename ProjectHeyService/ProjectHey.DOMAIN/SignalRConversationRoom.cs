using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class SignalRConversationRoom
    {
        public int Id { get; set; }
        public string RoomName { get; set; }

        public ICollection<SignalRMessage> Messages { get; set; }
        public ICollection<SignalRUserConversationRoom> Users { get; set; }
    }
}