using ProjectHey.DOMAIN.Enums;
using ProjectHey.DOMAIN.Structs;
using System;
using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class User
    {
        public int Id { get; set; }

        public string FacebookId { get; set; }

        public string FacebookToken { get; set; }

        public FacebookCity FacebookCity { get; set; }

        public string Username { get; set; }

        public string ResetUsername()
        {
           return Guid.NewGuid().ToString("N");
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreationDate { get; set; } 
        public DateTime ActivityDate { get; set; } 

        public string ProfilePictureURL { get; set; }

        public Gender Gender { get; set; }
        public Location Location { get; set; }

        public AppSetting Appsetting { get; set; }
        public SignalRUser SignalRUser { get; set; }

        public string Email { get; set; }

        public bool IsHidden { get; set; }

        public bool IsBanned { get; set; }

        //User can have multiple feedbacks
        public ICollection<Feedback> Feedback { get; set; }

        //User can have multiple reported users
        public ICollection<Reported> ReportedUsers { get; set; }

        //User can have multiple connections
        public ICollection<Connection> Connections { get; set; }

        //User can have multiple categories
        public ICollection<UserCategory> UserCategory { get; set; }

        //User can watch multiple advertisements
        public ICollection<Advertisement> Advertisement { get; set; }

        //User can watch multiple advertisements
        public ICollection<UserAdvertisement> WatchedAdvertisement { get; set; }


    }
}
