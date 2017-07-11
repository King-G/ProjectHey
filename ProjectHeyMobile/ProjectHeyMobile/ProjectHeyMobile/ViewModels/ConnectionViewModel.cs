namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionViewModel
    {
        public int UserOneId { get; set; }
        public User UserOne { get; set; }

        public int UserTwoId { get; set; }
        public User UserTwo { get; set; }

        public int Progress { get; set; } = 0;
    }
}
