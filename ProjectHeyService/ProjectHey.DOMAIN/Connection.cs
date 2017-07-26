namespace ProjectHey.DOMAIN
{
    public class Connection
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UserConnectionId { get; set; }
        public User UserConnection { get; set; }

        public double Progress { get; set; }

        public string GivenUsername { get; set; }

        public bool IsBlocked { get; set; }
        public bool IsHidden { get; set; }

        public int SignalRRoomId { get; set; }
        public SignalRRoom SignalRRoom { get; set; }
    }
}
