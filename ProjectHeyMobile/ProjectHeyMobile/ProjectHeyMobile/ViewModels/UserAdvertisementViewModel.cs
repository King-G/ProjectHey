using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class UserAdvertisementViewModel : BaseViewModel
    {
        private UserAdvertisement _UserAdvertisement;

        public UserAdvertisementViewModel(UserAdvertisement UserAdvertisement)
        {
            _UserAdvertisement = UserAdvertisement;
        }
        public UserAdvertisement UserAdvertisement
        {
            get { return _UserAdvertisement; }
            set { SetValue(ref _UserAdvertisement, value); }
        }
    }
}