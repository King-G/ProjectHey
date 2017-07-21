using System;

namespace ProjectHey.DOMAIN
{
    public class SignalRMessage
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int SignalRUserId { get; set; }
        public SignalRUser SignalRUser { get; set; }

        public int SignalRConversationRoomId { get; set; }
        public SignalRConversationRoom SignalRConversationRoom{ get; set; }

    }
}
