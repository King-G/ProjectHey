using System.Collections.Generic;

namespace ProjectHeyMobile.ViewModels
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Role can have multiple users
        public ICollection<UserRole> UserRole { get; set; }
    }
}
