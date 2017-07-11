using ProjectHey.Mobile.Enums;
using System;

namespace ProjectHey.Mobile
{
    public class Feedback
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public string Message { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
