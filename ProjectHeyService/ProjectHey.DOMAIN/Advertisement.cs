using ProjectHey.DOMAIN.Enums;
using ProjectHey.DOMAIN.Structs;
using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string PictureURL { get; set; }

        public string AdvertisementURL { get; set; }

        public AdvertisementType AdvertisementType { get; set; } = AdvertisementType.View;

        public int AmountRemaining { get; set; } = 0;

        public int UserId { get; set; }
        public User User { get; set; }

        public Location Location { get; set; }

        //Advertisement can be in multiple categories
        public ICollection<AdvertisementCategory> AdvertisementCategory { get; set; }

        //Advertisement can be watch by multiple users
        public ICollection<UserAdvertisement> WatchedAdvertisement { get; set; }
    }
}
