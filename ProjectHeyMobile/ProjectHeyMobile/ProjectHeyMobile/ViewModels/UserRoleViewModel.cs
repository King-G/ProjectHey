using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class UserRoleViewModel : BaseViewModel
    {
        private UserRole _UserRole;

        public UserRoleViewModel(UserRole UserRole)
        {
            _UserRole = UserRole;
        }
        public UserRole UserRole
        {
            get { return _UserRole; }
            set { SetValue(ref _UserRole, value); }
        }
    }
}