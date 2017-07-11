using System.Collections.Generic;

namespace ProjectHey.DOMAIN
{
    public class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Provider can have multiple users
        public ICollection<UserProvider> UserProvider { get; set; }
    }
}
