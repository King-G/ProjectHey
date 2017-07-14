using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class UserCategoryViewModel : BaseViewModel
    {
        private UserCategory _UserCategory;

        public UserCategoryViewModel(UserCategory UserCategory)
        {
            _UserCategory = UserCategory;
        }
        public UserCategory UserCategory
        {
            get { return _UserCategory; }
            set { SetValue(ref _UserCategory, value); }
        }
    }
}