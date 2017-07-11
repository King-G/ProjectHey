using ProjectHeyMobile.ViewModels.Enums;
using ProjectHeyMobile.ViewModels.Structs;
using System.Collections.Generic;

namespace ProjectHeyMobile.ViewModels
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
