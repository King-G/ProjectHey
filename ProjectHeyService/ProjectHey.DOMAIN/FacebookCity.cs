using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHey.DOMAIN
{
    public class FacebookCity
    {
        public int Id { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public int SignalRRoomId { get; set; }
        public SignalRRoom SignalRRoom { get; set; }

        //Facebookcity can have multiple users
        public ICollection<User> Users { get; set; }
    }
}
