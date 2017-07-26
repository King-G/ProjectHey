using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class BlockedViewModel : BaseViewModel
    {
        private Connection _Blocked;
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        public Connection Blocked
        {
            get { return _Blocked; }
            set { SetValue(ref _Blocked, value); }
        }
        public BlockedViewModel(Connection Blocked)
        {
            _Blocked = Blocked;
            //Get username
            _Username = "ASimpleUsername";
        }
    }
}