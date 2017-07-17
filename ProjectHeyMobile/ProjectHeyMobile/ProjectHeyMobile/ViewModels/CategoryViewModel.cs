using ProjectHey.DOMAIN;

namespace ProjectHeyMobile.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _Category;
        private int _UsersInCategory;

        public Category Category
        {
            get { return _Category; }
            set { SetValue(ref _Category, value); }
        }
        public int UsersInCategory
        {
            get { return _UsersInCategory; }
            set { SetValue(ref _UsersInCategory, value); }
        }
        public CategoryViewModel(Category Category)
        {
            _Category = Category;
            if (_Category == null)
            {
                _Category = new Category() { Name = "#Chillen" };
            }

        }
    }
}