using System;

namespace ProjectHey.Mobile
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserSenderId { get; set; }
        public User UserSender { get; set; }

        public int UserReceiverId { get; set; }
        public User UserReceiver { get; set; }

    }
}
