namespace ProjectHey.DOMAIN
{
    public class SignalRConnection
    {
        public int Id { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }

        public int SignalRUserId { get; set; }
        public SignalRUser SignalRUser { get; set; }
    }
}