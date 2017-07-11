using ProjectHey.Mobile.Enums;

namespace ProjectHey.Mobile
{
    public class AppSetting
    {
        public int Id { get; set; }

        public int Radius { get; set; } = 1000;

        public int MaximumNotifications { get; set; } = 10;

        public int MaximumConversations { get; set; } = 10;

        public Language Language { get; set; } = Language.English;

        public bool Sound { get; set; } = true;

        public bool Vibrate { get; set; } = true;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
