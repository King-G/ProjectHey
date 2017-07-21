namespace ProjectHey.DOMAIN
{
    public class Connection
    {
        public int UserOneId { get; set; }
        public User UserOne { get; set; }

        public int UserTwoId { get; set; }
        public User UserTwo { get; set; }

        public double Progress { get; set; }

        public string CustomUsername { get; set; }
    }
}
