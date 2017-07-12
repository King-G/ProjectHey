using System.Collections.Generic;

namespace ProjectHeyMobile.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Category can have multiple users
        public ICollection<UserCategory> UserCategory { get; set; }

        //Category can have multiple advertisements
        public ICollection<AdvertisementCategory> AdvertisementCategory { get; set; }
    }
}
