using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _Category;

        public CategoryViewModel(Category Category)
        {
            _Category = Category;
        }
        public Category Category
        {
            get { return _Category; }
            set { SetValue(ref _Category, value); }
        }
    }
}