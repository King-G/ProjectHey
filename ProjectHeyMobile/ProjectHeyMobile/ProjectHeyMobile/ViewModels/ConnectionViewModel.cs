using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionViewModel : BaseViewModel
    {
        private Connection _Connection;
        private string _Username;

        public Connection Connection
        {
            get { return _Connection; }
            set { SetValue(ref _Connection, value); }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public ConnectionViewModel(Connection Connection)
        {
            _Connection = Connection;

            //Get username
            _Username = "ASimpleUsername";
        }

    }
}
