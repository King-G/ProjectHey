using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Category can have multiple users
        public ICollection<UserCategory> UserCategory { get; set; }

        //Category can have multiple advertisements
        public ICollection<AdvertisementCategory> AdvertisementCategory { get; set; }

        public int TotalUsers { get; set; }

        public int TotalSignalRUsers { get; set; }

        public int SignalRRoomId { get; set; }
        public SignalRRoom SignalRRoom { get; set; }
    }
}
