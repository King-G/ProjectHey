using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionViewModel : BaseViewModel
    {
        private Connection _Connection;

        public ConnectionViewModel(Connection Connection)
        {
            _Connection = Connection;
        }
        public Connection Connection
        {
            get { return _Connection; }
            set { SetValue(ref _Connection, value); }
        }
    }
}
