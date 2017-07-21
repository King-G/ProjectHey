using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.DOMAIN
{
    public class AppSetting
    {
        public int Id { get; set; }

        public int Radius { get; set; }

        public int MaximumConnections { get; set; }

        public Language Language { get; set; }

        public bool Sound { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public AppSetting GetDefaultAppSettings()
        {
            AppSetting defaultAppSetting = new AppSetting()
            {
                Radius = 1500,
                Language = Language.English,
                Sound = true,
                MaximumConnections = 20
            };
            return defaultAppSetting;
        }
    }
}
