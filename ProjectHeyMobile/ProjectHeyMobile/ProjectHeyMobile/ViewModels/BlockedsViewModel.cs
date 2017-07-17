using ProjectHeyMobile.Views.Chatpages;
using ProjectHeyMobile.Views.Utilitypages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class BlockedsViewModel : BaseViewModel
    {
        public ObservableCollection<BlockedViewModel> Blockeds { get; set; }
        private BlockedViewModel _SelectedBlocked;

        public BlockedViewModel SelectedBlocked
        {
            get { return _SelectedBlocked; }
            set { SetValue(ref _SelectedBlocked, value); }
        }

        public ICommand SelectBlockedCommand { get; private set; }
        public ICommand AddBlockedCommand { get; private set; }
        public ICommand UnblockCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public BlockedsViewModel() : this(new List<BlockedViewModel>())
        {

        }
        public BlockedsViewModel(List<BlockedViewModel> blockeds)
        {
            Blockeds = new ObservableCollection<BlockedViewModel>(blockeds);

            SelectBlockedCommand = new Command<BlockedViewModel>(x => SelectBlockeds(x));
            AddBlockedCommand = new Command<BlockedViewModel>(x => AddBlockeds(x));
            UnblockCommand = new Command<BlockedViewModel>(x => BlockBlockeds(x));
            DeleteCommand = new Command<BlockedViewModel>(x => DeleteBlocked(x));

        }

        private void AddBlockeds(BlockedViewModel blocked)
        {
            Blockeds.Add(blocked);
        }
        private void BlockBlockeds(BlockedViewModel blocked)
        {
            //API (BlockUser) add blocked to users.blocked
            Blockeds.Remove(blocked);
        }
        private void DeleteBlocked(BlockedViewModel blocked)
        {
            //API hide user
            Blockeds.Remove(blocked);

        }

        private void SelectBlockeds(BlockedViewModel blocked)
        {
            if (blocked == null)
                return;

            SelectedBlocked = null;
        }
    }
}
