using System;

namespace ProjectHey.Mobile
{
    public class UserAdvertisement
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }

        public DateTime ViewDate { get; set; } = DateTime.Now;

        public bool IsClicked { get; set; } = false;

        public Report Report { get; set; }
    }
}
