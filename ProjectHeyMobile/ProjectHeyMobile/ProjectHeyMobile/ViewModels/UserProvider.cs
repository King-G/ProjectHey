
namespace ProjectHeyMobile.ViewModels
{
    public class UserProvider
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int ProviderUserId { get; set; }
    }
}
