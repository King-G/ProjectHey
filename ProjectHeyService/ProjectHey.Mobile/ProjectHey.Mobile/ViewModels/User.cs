using ProjectHey.Mobile.Enums;
using ProjectHey.Mobile.Structs;
using System;
using System.Collections.Generic;

namespace ProjectHey.Mobile
{
    public class User
    {
        public int Id { get; set; }

        private string username = Guid.NewGuid().ToString("N");

        public string Username
        {
            get {
                return username;
            }
        }
        public string ResetUsername()
        {
            username = Guid.NewGuid().ToString("N");
            return username;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ActivityDate { get; set; } = DateTime.Now;

        public string ProfilePictureURL { get; set; }

        public Gender Gender { get; set; } = Gender.Unknown;

        public Location Location { get; set; }

        public AppSetting Appsetting { get; set; }

        public string Email { get; set; }

        public bool IsHidden { get; set; } = false;

        public bool IsBanned { get; set; } = false;

        //User can have multiple feedbacks
        public ICollection<Feedback> Feedback { get; set; }

        //User can have multiple reported users
        public ICollection<Reported> ReportedUsers { get; set; }

        //User can have multiple blocked users
        public ICollection<Blocked> BlockedUsers { get; set; }

        //User can have multiple connections
        public ICollection<Connection> Connections { get; set; }

        //User can have multiple categories
        public ICollection<UserCategory> UserCategory { get; set; }

        //User can have multiple roles
        public ICollection<UserRole> UserRole { get; set; }

        //User can have multiple messages
        public ICollection<MessageViewModel> Messages { get; set; }

        //User can watch multiple advertisements
        public ICollection<Advertisement> Advertisement { get; set; }

        //User can watch multiple advertisements
        public ICollection<UserAdvertisement> WatchedAdvertisement { get; set; }

        //User can have multiple providers
        public ICollection<UserProvider> UserProvider { get; set; }

    }
}
