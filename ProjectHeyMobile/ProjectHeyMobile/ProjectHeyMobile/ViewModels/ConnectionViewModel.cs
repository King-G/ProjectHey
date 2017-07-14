
using ProjectHey.DOMAIN;
using System.Windows.Input;

namespace ProjectHeyMobile.ViewModels
{
    public class ConnectionViewModel : Connection
    {
        public readonly ICommand Command;

        public string Username { get; set; }
    }
}
