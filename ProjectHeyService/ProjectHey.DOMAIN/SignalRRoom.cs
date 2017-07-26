using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class SignalRRoom
    {
        public int Id { get; set; }
        public string Roomname { get; set; }

        public string Password { get; set; }

        public ICollection<SignalRMessage> Messages { get; set; }
        public ICollection<SignalRUserRoom> Users { get; set; }
    }
}