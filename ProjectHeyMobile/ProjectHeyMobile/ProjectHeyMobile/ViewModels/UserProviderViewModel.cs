using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class UserProviderViewModel : BaseViewModel
    {
        private UserProvider _UserProvider;

        public UserProviderViewModel(UserProvider UserProvider)
        {
            _UserProvider = UserProvider;
        }
        public UserProvider UserProvider
        {
            get { return _UserProvider; }
            set { SetValue(ref _UserProvider, value); }
        }
    }
}