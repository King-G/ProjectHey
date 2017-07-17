using ProjectHeyMobile.Views.Chatpages;
using ProjectHeyMobile.Views.Settingspages;
using ProjectHeyMobile.Views.Utilitypages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectHeyMobile.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        private CategoryViewModel _SelectedCategory;

        public CategoryViewModel SelectedCategory
        {
            get { return _SelectedCategory; }
            set { SetValue(ref _SelectedCategory, value); }
        }

        public ICommand SelectCategoryCommand { get; private set; }
        public ICommand SelectChannelCommand { get; private set; }

        public ICommand SearchCategoryCommand { get; private set; }
        public ICommand SearchChannelCommand { get; private set; }

        public ICommand AddCategoryCommand { get; private set; }
        public ICommand JoinChannelCommand { get; private set; }

        public ICommand RemoveCategoryCommand { get; private set; }
        public ICommand LeaveChannelCommand { get; private set; }

        public CategoriesViewModel(): this(new List<CategoryViewModel>())
        {

        }
        public CategoriesViewModel(List<CategoryViewModel> categories)
        {
            Categories = new ObservableCollection<CategoryViewModel>(categories);

            SelectCategoryCommand = new Command<CategoryViewModel>(x => SelectCategory(x));
            SelectChannelCommand = new Command<CategoryViewModel>(async x => await SelectChannel(x));

            SearchCategoryCommand = new Command<CategoryViewModel>(async x => await SearchCategory());
            SearchChannelCommand = new Command<CategoryViewModel>(async x => await SearchChannel());

            AddCategoryCommand = new Command<CategoryViewModel>(async x => await AddCategory(x));
            JoinChannelCommand = new Command<CategoryViewModel>(async x => await JoinChannel(x));

            RemoveCategoryCommand = new Command<CategoryViewModel>(x => RemoveCategory(x));
            LeaveChannelCommand = new Command<CategoryViewModel>(x => LeaveChannel(x));


        }

        private async Task SearchCategory()
        {
            await App.Main.PageService.PushAsync(new CategorySearchPage());
        }
        private async Task SearchChannel()
        {
            await App.Main.PageService.PushAsync(new ChannelSearchPage());
        }

        private async Task AddCategory(CategoryViewModel category)
        {
            bool yes = await App.Main.PageService.DisplayAlert("Add Category:", string.Format("Do you want to add {0} to your profile?", category.Category.Name), "Yes", "No");
            if (yes)
                await App.Main.PageService.DisplayAlert("Success", string.Format("{0} has been added to your profile", category.Category.Name), "Ok");
        }
        private async Task JoinChannel(CategoryViewModel category)
        {
            bool yes = await App.Main.PageService.DisplayAlert("Join Channel:", string.Format("Do you want to join {0} channel?", category.Category.Name), "Yes", "No");
            if (yes)
                await App.Main.PageService.DisplayAlert("Success", string.Format("{0} channel joined.", category.Category.Name), "Ok");
        }

        private void RemoveCategory(CategoryViewModel category)
        {
            Categories.Remove(category);
        }
        private void LeaveChannel(CategoryViewModel category)
        {
            //Set category.isinchannel = false;
            Categories.Remove(category);
        }

        private void SelectCategory(CategoryViewModel category)
        {
            if (category == null)
                return;

            SelectedCategory = null;
        }
        private async Task SelectChannel(CategoryViewModel category)
        {
            if (category == null)
                return;

            SelectedCategory = null;

            await App.Main.PageService.PushAsync(new ChatPage());

        }
    }
}
