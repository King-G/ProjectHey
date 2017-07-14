using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class BlockedViewModel : BaseViewModel
    {
        private Blocked _Blocked;

        public BlockedViewModel(Blocked Blocked)
        {
            _Blocked = Blocked;
        }
        public Blocked Blocked
        {
            get { return _Blocked; }
            set { SetValue(ref _Blocked, value); }
        }
    }
}