using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHey.DOMAIN
{
    public class SignalRUser
    {
        public int Id { get; set; }
        public int UserId { get; set; } //send with Context.User.Identity.Name
        public User User { get; set; }
        public bool IsConnected { get; set; }
        public virtual ICollection<SignalRUserRoom> Rooms { get; set; }
        public ICollection<SignalRMessage> Messages { get; set; }

    }
}
